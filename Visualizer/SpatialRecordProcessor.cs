/* Copyright (C) 2015-16 AgGateway and ADAPT Contributors
  * Copyright (C) 2015-16 Deere and Company
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    Kelly Nelson - implemented based on like classes in this project
  *    Andrew Vardeman - optimized rendering of large datasets
  *******************************************************************************/

using System.Drawing.Imaging;
using AgGateway.ADAPT.ApplicationDataModel.LoggedData;
using AgGateway.ADAPT.ApplicationDataModel.Equipment;
using AgGateway.ADAPT.ApplicationDataModel.ADM;
using AgGateway.ADAPT.ApplicationDataModel.Representations;
using Point = AgGateway.ADAPT.ApplicationDataModel.Shapes.Point;

namespace AgGateway.ADAPT.Visualizer
{
    public class SpatialRecordProcessor
    {
        private DrawingUtil _drawingUtil;
        private readonly TabPage _spatialViewer;
        private Dictionary<string, WorkingData> _workingDataDictionary;
        private OperationData _lastOperationData;
        private List<SpatialRecord> _spatialRecords;
        private Bitmap? _bitmap;

        public SpatialRecordProcessor(TabPage spatialViewer)
        {
            _spatialViewer = spatialViewer;
        }

        /// <summary>
        /// Populates all DeviceElementUses/WorkingDatas and draws a black polygon
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="catalog"></param>
        public void ProcessOperation(OperationData operation, List<SpatialRecord> spatialRecords, Catalog catalog)
        {
            _workingDataDictionary = GetWorkingDataDictionary(operation, catalog);
            _lastOperationData = operation;
            _spatialRecords = spatialRecords;
        }

        /// <summary>
        /// Draws a Red polygon if all values 0, a DarkMagenta polygon if all values the same non-zero value, or else themes Red/DarkOrange/Gold/YellowGreen/LawnGreen/LimeGreen/ForestGreen/DarkGreen.
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="workingDataKey"></param>
        public void ThemeMap(string workingDataKey)
        {
            using (var graphics = _spatialViewer.CreateGraphics())
            {
                int width = _spatialViewer.Width;
                int height = _spatialViewer.Height;
                graphics.Clear(Color.White);
                _drawingUtil = new DrawingUtil(width, height, graphics);

                List<Point> projectedPoints = new List<Point>();
                List<double> doubleValues = null;
                foreach (SpatialRecord record in _spatialRecords)
                {
                    Point point = record.Geometry as Point;
                    projectedPoints.Add(point.ToUtm());

                    if (_workingDataDictionary.ContainsKey(workingDataKey))
                    {
                        WorkingData workingData = _workingDataDictionary[workingDataKey];
                        RepresentationValue repValue = record.GetMeterValue(workingData);
                        if (repValue is NumericRepresentationValue)
                        {
                            NumericRepresentationValue numericValue = repValue as NumericRepresentationValue;
                            if (doubleValues == null)
                            {
                                doubleValues = new List<double>();
                            }
                            doubleValues.Add(numericValue.Value.Value);
                        }
                        else if (repValue is EnumeratedValue)
                        {
                            EnumeratedValue enumValue = repValue as EnumeratedValue;
                            if (enumValue.Representation.Code == "dtRecordingStatus")
                            {
                                if (doubleValues == null)
                                {
                                    doubleValues = new List<double>();
                                }
                                doubleValues.Add(enumValue.Value.Value == "On" ? 1d : -1d);
                            }
                        }
                    }
                }

                if (!projectedPoints.Any())
                {
                    return;
                }

                _drawingUtil.SetMinMax(projectedPoints);
                var screenPolygon = projectedPoints.Select(point => point.ToXy(_drawingUtil.MinX, _drawingUtil.MinY, _drawingUtil.GetDelta())).ToArray();

                if (screenPolygon.All(p => !double.IsNaN(p.X) && !double.IsNaN(p.Y)))
                {
                    if (doubleValues == null)
                    {
                        //WorkingData is not numeric
                        graphics.DrawPolygon(DrawingUtil.B_Black, screenPolygon);
                    }
                    else
                    {
                        if (doubleValues.Max() == doubleValues.Min())
                        {
                            //All values are the same
                            if (doubleValues.Max() <= 0d)
                            {
                                //Zero values
                                graphics.DrawPolygon(DrawingUtil.E_Red, screenPolygon);
                            }
                            else
                            {
                                //Non-zero values
                                graphics.DrawPolygon(DrawingUtil.L_DarkGreen, screenPolygon);
                            }
                        }
                        else
                        {
                            double max = doubleValues.Max();
                            double min = doubleValues.Min();
                            double average = doubleValues.Average();
                            List<double> removedZeroValues = doubleValues.Where(dv => dv != 0).ToList();
                            double averageWithoutZeroes = removedZeroValues.Average();
                            if (average != averageWithoutZeroes)
                            {
                                min = removedZeroValues.Min();
                            }

                            int i = 0;
                            double range = (max - min) / 7.0;
                            double e7th = min;
                            double f7th = e7th + range;
                            double g7th = f7th + range;
                            double h7th = g7th + range;
                            double i7th = h7th + range;
                            double j7th = i7th + range;
                            double k7th = j7th + range;
                            double l7th = max;

                            if (width <= 0 || height <= 0)
                            {
                                return;
                            }

                            if (_bitmap == null || _bitmap.Width < width || _bitmap.Height < height)
                            {
                                int maxWidth = _bitmap == null ? width : Math.Max(width, _bitmap.Width);
                                int maxHeight = _bitmap == null ? height : Math.Max(height, _bitmap.Height);
                                _bitmap?.Dispose();
                                _bitmap = new Bitmap(maxWidth, maxHeight, PixelFormat.Format32bppArgb);
                            }

                            using (Graphics g = Graphics.FromImage(_bitmap))
                            {
                                g.Clear(Color.White);
                            }

                            BitmapData bitmapData = _bitmap.LockBits(new Rectangle(0, 0, width, height),
                                ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);


                            foreach (PointF f in screenPolygon)
                            {
                                double dbl = i < doubleValues.Count
                                    ? doubleValues[i]
                                    : 0d; //Values will be in same order as points
                                Color color = Color.Black;

                                if (dbl <= e7th)
                                {
                                    color = DrawingUtil.E_Red.Color;
                                }
                                else if (dbl <= f7th)
                                {
                                    color = DrawingUtil.F_DarkOrange.Color;
                                }
                                else if (dbl <= g7th)
                                {
                                    color = DrawingUtil.G_Gold.Color;
                                }
                                else if (dbl <= h7th)
                                {
                                    color = DrawingUtil.H_YellowGreen.Color;
                                }
                                else if (dbl <= i7th)
                                {
                                    color = DrawingUtil.I_LawnGreen.Color;
                                }
                                else if (dbl <= j7th)
                                {
                                    color = DrawingUtil.J_LimeGreen.Color;
                                }
                                else if (dbl <= k7th)
                                {
                                    color = DrawingUtil.K_ForestGreen.Color;
                                }
                                else if (dbl <= l7th)
                                {
                                    color = DrawingUtil.L_DarkGreen.Color;
                                }

                                unsafe
                                {
                                    byte* bytes = (byte*) bitmapData.Scan0;
                                    int cx = (int) f.X;
                                    int cy = (int) f.Y;
                                    for (int x = Math.Max(cx - 2, 0); x <= Math.Min(cx + 1, width - 1); x++)
                                    {
                                        for (int y = Math.Max(cy - 2, 0); y <= Math.Min(cy + 1, height - 1); y++)
                                        {
                                            byte* p = bytes + y * bitmapData.Stride + x * 4;
                                            p[0] = color.B;
                                            p[1] = color.G;
                                            p[2] = color.R;
                                            p[3] = color.A;
                                        }
                                    }
                                }

                                i++;
                            }

                            _bitmap.UnlockBits(bitmapData);
                            graphics.DrawImage(_bitmap, 0, 0);
                        }

                    }
                }
            }
        }

        public List<string> WorkingDataList
        {
            get
            {
                if (_workingDataDictionary != null)
                {
                    return _workingDataDictionary.Keys.Select(k => new { Key = k, DepthVsOrder = k.Split(':')[0].Split('.') })
                                                       .OrderBy(x => int.Parse(x.DepthVsOrder[0]))
                                                       .ThenBy(x => int.Parse(x.DepthVsOrder[1]))
                                                       .Select(x => x.Key)
                                                       .ToList();
                }
                else
                {
                    return null;
                }
            }
        }

        private Dictionary<string, WorkingData> GetWorkingDataDictionary(OperationData operation, Catalog catalog)
        {
            Dictionary<string, WorkingData> workingDataDictionary = new Dictionary<string, WorkingData>();
            for (int i = 0; i <= operation.MaxDepth; i++)
            {
                IEnumerable<DeviceElementUse> deviceElementUses = operation.GetDeviceElementUses(i);
                foreach (DeviceElementUse deviceElementUse in deviceElementUses)
                {
                    DeviceElementConfiguration config = catalog.DeviceElementConfigurations.FirstOrDefault(c => c.Id.ReferenceId == deviceElementUse.DeviceConfigurationId);
                    string deviceName = deviceElementUse.Id.ReferenceId.ToString();
                    if (config != null)
                    {
                        deviceName = config.Id.ReferenceId + "_" + config.Description;
                    }

                    IEnumerable<WorkingData> workingDatas = deviceElementUse.GetWorkingDatas();
                    foreach (WorkingData workingData in workingDatas)
                    {
                        if (workingData.Representation != null)
                        {
                            string key = $"{deviceElementUse.Depth}.{deviceElementUse.Order}:__{deviceName}_{workingData.Representation.Code}";
                            if (!workingDataDictionary.ContainsKey(key))
                            {
                                workingDataDictionary.Add(key, workingData);
                            }
                        }
                    }
                }
            }
            return workingDataDictionary;
        }
    }
}
