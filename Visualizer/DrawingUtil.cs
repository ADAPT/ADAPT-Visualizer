using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
/* Copyright (C) 2015-16 AgGateway and ADAPT Contributors
  * Copyright (C) 2015-16 Deere and Company
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    Tarak Reddy - initial implementation
  *    Joseph Ross - Made Changes to Account for mapping multiple guidence patterns with the same context
  *******************************************************************************/

using System.Linq;
using Point = AgGateway.ADAPT.ApplicationDataModel.Shapes.Point;

namespace AgGateway.ADAPT.Visualizer
{
    public class DrawingUtil
    {
        private readonly int _width;
        private readonly int _height;
        private bool _isMaxMinSet;

        public DrawingUtil(int width, int height, Graphics graphics)
        {
            _width = width;
            _height = height;
            Graphics = graphics;
            _isMaxMinSet = false;
        }

        public double MinX { get; private set; }
        public double MinY { get; private set; }
        public double MaxX { get; private set; }
        public double MaxY { get; private set; }
        public Graphics Graphics { get; private set; }

        //Default values
        public static Pen B_Black //WorkingData is not numeric
        {
            get { return new Pen(Color.Black, 2); }
        }
        public static Pen C_DarkMagenta //Non-zero values
        {
            get { return new Pen(Color.DarkMagenta, 2); }
        }
        public static Pen E_Red //Zero values or minimum values
        {
            get { return new Pen(Color.Red, 2); }
        }

        //Range 7 levels
        public static Pen F_DarkOrange
        {
            get { return new Pen(Color.DarkOrange, 2); }
        }
        public static Pen G_Gold
        {
            get { return new Pen(Color.Gold, 2); }
        }
        public static Pen H_YellowGreen
        {
            get { return new Pen(Color.YellowGreen, 2); }
        }
        public static Pen I_LawnGreen
        {
            get { return new Pen(Color.LawnGreen, 2); }
        }
        public static Pen J_LimeGreen
        {
            get { return new Pen(Color.LimeGreen, 2); }
        }
        public static Pen K_ForestGreen
        {
            get { return new Pen(Color.ForestGreen, 2); }
        }
        public static Pen L_DarkGreen
        {
            get { return new Pen(Color.DarkGreen, 2); }
        }

        public double GetDelta()
        {
            double delta;
            var lonDistance = (MaxX - MinX);
            var latDistance = (MaxY - MinY);

            var width = _width - 50;
            var height = _height - 50;

            if (width < height && latDistance > lonDistance)
            {
                delta = lonDistance / width;
            }
            else
            {
                delta = latDistance / height;
            }

            return delta;
        }

        public void SetMinMax(IList<Point> points)
        {
            if (_isMaxMinSet)
            {
                var minX = points.Min(point => point.X);
                MinX = minX < MinX ? minX : MinX;

                var maxX = points.Max(point => point.X);
                MaxX = maxX > MaxX ? maxX : MaxX;

                var minY = points.Min(point => point.Y);
                MinY = minY < MinY ? minY : MinY;

                var maxY = points.Max(point => point.Y);
                MaxY = maxY > MaxY ? maxY : MaxY;
            }
            else
            {
                MinX = points.Min(point => point.X);
                MaxX = points.Max(point => point.X);
                MinY = points.Min(point => point.Y);
                MaxY = points.Max(point => point.Y);
                _isMaxMinSet = true;
            }
            SetOriginPoint(GetDelta());
        }

        public void SetOriginPoint(double delta)
        {
            if (delta == 0.0)
                delta = 1.0;
            var max = ((MaxY - MinY)/delta + 25) + 20;
            Graphics.Transform = new Matrix(1, 0, 0, -1, 0, (float) max);
        }
    }
}