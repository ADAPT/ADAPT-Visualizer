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
  *    Joseph Ross - Made Changes to Account for mapping multiple guidance patterns with the same context
  *    Andrew Vardeman - Plugged GDI+ memory leaks due to un-disposed pens
  *******************************************************************************/

using Point = AgGateway.ADAPT.ApplicationDataModel.Shapes.Point;

namespace AgGateway.ADAPT.Visualizer
{
    public class DrawingUtil
    {
        //Default values
        public static Pen B_Black { get; } = new Pen(Color.Black, 2) { LineJoin = LineJoin.MiterClipped, MiterLimit = 4 }; //WorkingData is not numeric
        public static Pen C_DarkMagenta { get; } = new Pen(Color.DarkMagenta, 2) { LineJoin = LineJoin.MiterClipped, MiterLimit = 4 }; //Non-zero values
        public static Pen E_Red { get; } = new Pen(Color.Red, 2) { LineJoin = LineJoin.MiterClipped, MiterLimit = 4 }; //Zero values or minimum values

        //Range 7 levels
        public static Pen F_DarkOrange { get; } = new Pen(Color.DarkOrange, 2) { LineJoin = LineJoin.MiterClipped, MiterLimit = 4 };
        public static Pen G_Gold { get; } = new Pen(Color.Gold, 2) { LineJoin = LineJoin.MiterClipped, MiterLimit = 4 };
        public static Pen H_YellowGreen { get; } = new Pen(Color.YellowGreen, 2) { LineJoin = LineJoin.MiterClipped, MiterLimit = 4 };
        public static Pen I_LawnGreen { get; } = new Pen(Color.LawnGreen, 2) { LineJoin = LineJoin.MiterClipped, MiterLimit = 4 };
        public static Pen J_LimeGreen { get; } = new Pen(Color.LimeGreen, 2) { LineJoin = LineJoin.MiterClipped, MiterLimit = 4 };
        public static Pen K_ForestGreen { get; } = new Pen(Color.ForestGreen, 2) { LineJoin = LineJoin.MiterClipped, MiterLimit = 4 };
        public static Pen L_DarkGreen { get; } = new Pen(Color.DarkGreen, 2) { LineJoin = LineJoin.MiterClipped, MiterLimit = 4 };
    }
}