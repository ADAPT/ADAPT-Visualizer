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

using AgGateway.ADAPT.ApplicationDataModel.Shapes;

namespace AgGateway.ADAPT.Visualizer.Mapping
{
    public class MapBoundingBox
    {
        public double MinX { get; set; } = double.MaxValue;
        public double MinY { get; set; } = double.MaxValue;
        public double MaxX { get; set; } = double.MinValue;
        public double MaxY { get; set; } = double.MinValue;
        public double CenterX => (MinX + MaxX) / 2;
        public double CenterY => (MinY + MaxY) / 2;
        public double Width => MaxX - MinX;
        public double Height => MaxY - MinY;

        public ApplicationDataModel.Shapes.Point Center =>
            new ApplicationDataModel.Shapes.Point { X = CenterX, Y = CenterY };

        public MapBoundingBox() { }

        public MapBoundingBox(Shape shape)
        {
            Update(shape);
        }

        public void Update(Shape shape)
        {
            if (shape is ApplicationDataModel.Shapes.Point point)
            {
                Update(point);
            }
            else if (shape is LineString lineString)
            {
                foreach (var p in lineString.Points)
                {
                    Update(p);
                }
            }
            else if (shape is Polygon polygon)
            {
                foreach (var p in polygon.ExteriorRing.Points)
                {
                    Update(p);
                }

                foreach (var interiorRing in polygon.InteriorRings)
                {
                    foreach (var p in interiorRing.Points)
                    {
                        Update(p);
                    }
                }
            }
        }

        public void Update(ApplicationDataModel.Shapes.Point point)
        {
            MinX = Math.Min(MinX, point.X);
            MinY = Math.Min(MinY, point.Y);
            MaxX = Math.Max(MaxX, point.X);
            MaxY = Math.Max(MaxY, point.Y);
        }
    }
}
