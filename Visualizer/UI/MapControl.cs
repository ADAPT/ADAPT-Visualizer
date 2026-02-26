/* Copyright (C) 2015-16 AgGateway and ADAPT Contributors
 * Copyright (C) 2015-16 Deere and Company
 * All rights reserved. This program and the accompanying materials
 * are made available under the terms of the Eclipse Public License v1.0
 * which accompanies this distribution, and is available at
 * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html>
 *
 * Contributors:
 *    Andrew Vardeman - Initial Implementation
 *******************************************************************************/

using System.Drawing.Imaging;
using System.Globalization;
using AgGateway.ADAPT.Visualizer.Mapping;

namespace AgGateway.ADAPT.Visualizer.UI
{
    public partial class MapControl : UserControl
    {
        private Map _map;
        private ADAPT.ApplicationDataModel.Shapes.Point _centerPoint;
        private double _scale = 1.0;
        private PointF _lastMouseDownPoint;
        private ADAPT.ApplicationDataModel.Shapes.Point? _lastMouseDownCenterPoint;
        private Bitmap? _bitmap;
        internal Map? Map
        {
            get => _map;
            set
            {
                _map = value;
                ZoomToMap();
            }
        }

        public MapControl()
        {
            InitializeComponent();
            MouseWheel += MapControl_MouseWheel;
        }

        public void ZoomToMap()
        {
            if (Map != null)
            {
                _centerPoint = Map.MapBoundingBox.Center;
                var mapRatio = Map.MapBoundingBox.Width / Map.MapBoundingBox.Height;
                var controlRatio = (double)ClientSize.Width / ClientSize.Height;
                if (mapRatio > controlRatio)
                {
                    _scale = ClientSize.Width / Map.MapBoundingBox.Width;
                }
                else
                {
                    _scale = ClientSize.Height / Map.MapBoundingBox.Height;
                }
            }

            Invalidate();
        }

        public void ZoomIn()
        {
            _scale *= 1.1;
            Invalidate();
        }

        public void ZoomOut()
        {
            _scale /= 1.1;
            Invalidate();
        }

        private void MapControl_Paint(object sender, PaintEventArgs e)
        {
            if (_bitmap == null || _bitmap.Width != this.Width || _bitmap.Height != this.Height)
            {
                _bitmap?.Dispose();
                _bitmap = new Bitmap(this.Width, this.Height);
            }

            if (Map == null)
            {
                e.Graphics.Clear(Color.White);
                return;
            }

            if (Map.IsAllPoints)
            {
                using (Graphics graphics = Graphics.FromImage(_bitmap))
                {
                    graphics.Clear(Color.White);
                }
                BitmapData bitmapData = _bitmap.LockBits(new Rectangle(0, 0, _bitmap.Width, _bitmap.Height),
                    ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
                foreach (var mapObject in Map.MapObjects)
                {
                    if (mapObject is MapPoint mapPoint)
                    {
                        FastDrawMapPoint(bitmapData, mapPoint);
                    }
                }

                _bitmap.UnlockBits(bitmapData);
            }
            else
            {
                using (Graphics graphics = Graphics.FromImage(_bitmap))
                {
                    graphics.Clear(Color.White);
                    foreach (var mapObject in Map.MapObjects)
                    {
                        DrawMapObject(graphics, mapObject);
                    }
                }
            }

            e.Graphics.DrawImage(_bitmap, 0, 0);
        }

        private void DrawMapObject(Graphics graphics, MapObject mapObject)
        {
            if (mapObject is MapPoint mapPoint)
            {
                DrawMapPoint(graphics, mapPoint);
            }
            else if (mapObject is MapLineString mapLine)
            {
                DrawMapLineString(graphics, mapLine);
            }
            else if (mapObject is MapPolygon mapPolygon)
            {
                DrawMapPolygon(graphics, mapPolygon);
            }
        }

        private void DrawMapPoint(Graphics graphics, MapPoint mapPoint)
        {
            if (mapPoint is { Point: not null, Pen: not null })
            {
                PointF point = ProjectToControl(mapPoint.Point);
                graphics.DrawRectangle(mapPoint.Pen, point.X - 1, point.Y - 1, 2, 2);
            }
        }

        private void FastDrawMapPoint(BitmapData bitmapData, MapPoint mapPoint)
        {
            if (mapPoint.Point == null || mapPoint.Pen == null || mapPoint.Point == null)
            {
                return;
            }
            Color color = mapPoint.Pen.Color;
            unsafe
            {
                byte* bytes = (byte*)bitmapData.Scan0;
                PointF point = ProjectToControl(mapPoint.Point);
                int cx = (int)point.X;
                int cy = (int)point.Y;
                for (int x = Math.Max(cx - 2, 0); x <= Math.Min(cx + 1, Width - 1); x++)
                {
                    for (int y = Math.Max(cy - 2, 0); y <= Math.Min(cy + 1, Height - 1); y++)
                    {
                        byte* p = bytes + y * bitmapData.Stride + x * 4;
                        p[0] = color.B;
                        p[1] = color.G;
                        p[2] = color.R;
                        p[3] = color.A;
                    }
                }
            }
        }

        private void DrawMapLineString(Graphics graphics, MapLineString mapLineString)
        {
            if (mapLineString is { LineString: not null, Pen: not null })
            {
                PointF[] points = ProjectToControl(mapLineString.LineString.Points);
                graphics.DrawLines(mapLineString.Pen, points);
            }
        }

        private void DrawMapPolygon(Graphics graphics, MapPolygon mapPolygon)
        {
            if (mapPolygon.Polygon != null)
            {
                PointF[] exteriorPoints = ProjectToControl(mapPolygon.Polygon.ExteriorRing.Points);
                if (exteriorPoints != null && exteriorPoints.Length > 2)
                {
                    if (mapPolygon.Brush != null)
                    {
                        graphics.FillPolygon(mapPolygon.Brush, exteriorPoints);
                    }

                    if (mapPolygon.Pen != null)
                    {
                        graphics.DrawPolygon(mapPolygon.Pen, exteriorPoints);
                    }
                }

                foreach (var interiorRing in mapPolygon.Polygon.InteriorRings)
                {
                    PointF[] interiorPoints = ProjectToControl(interiorRing.Points);
                    if (interiorPoints != null && interiorPoints.Length > 2)
                    {
                        if (mapPolygon.Brush != null)
                        {
                            graphics.FillPolygon(mapPolygon.Brush, interiorPoints);
                        }

                        if (mapPolygon.Pen != null)
                        {
                            graphics.DrawPolygon(mapPolygon.Pen, interiorPoints);
                        }
                    }
                }
            }
        }

        private PointF ProjectToControl(ADAPT.ApplicationDataModel.Shapes.Point point)
        {
            float x = (float)((point.X - _centerPoint.X) * _scale + (float)ClientSize.Width / 2);
            float y = (float)((_centerPoint.Y - point.Y) * _scale + (float)ClientSize.Height / 2);
            return new PointF(x, y);
        }

        private PointF[] ProjectToControl(IEnumerable<ADAPT.ApplicationDataModel.Shapes.Point> points)
        {
            if (points == null)
            {
                return Array.Empty<PointF>();
            }
            return points.Select(p => ProjectToControl(p)).ToArray();
        }

        private void MapControl_MouseDown(object sender, MouseEventArgs e)
        {
            _lastMouseDownPoint = e.Location;
            _lastMouseDownCenterPoint = _centerPoint;
        }

        private void MapControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && _lastMouseDownCenterPoint != null)
            {
                float dx = e.X - _lastMouseDownPoint.X;
                float dy = e.Y - _lastMouseDownPoint.Y;
                _centerPoint = new ADAPT.ApplicationDataModel.Shapes.Point
                {
                    X = _lastMouseDownCenterPoint!.X - dx / _scale,
                    Y = _lastMouseDownCenterPoint.Y + dy / _scale
                };
                Invalidate();
            }
        }

        private void MapControl_MouseWheel(object? sender, MouseEventArgs e)
        {
            double fractionX = (double)e.X / ClientSize.Width;
            double fractionY = (double)e.Y / ClientSize.Height;
            double newScale = _scale * Math.Pow(1.1, e.Delta / 120.0);
            // Calculate the new center point to keep the zoom centered on the mouse position
            _centerPoint = new ADAPT.ApplicationDataModel.Shapes.Point
            {
                X = _centerPoint.X + (fractionX - 0.5) * ClientSize.Width * (1 / _scale - 1 / newScale),
                Y = _centerPoint.Y - (fractionY - 0.5) * ClientSize.Height * (1 / _scale - 1 / newScale)
            };
            _scale = newScale;
            Invalidate();
        }

    }
}
