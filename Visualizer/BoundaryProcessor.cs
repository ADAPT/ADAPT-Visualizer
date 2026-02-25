/* Copyright (C) 2015-16 AgGateway and ADAPT Contributors
  * Copyright (C) 2015-16 Deere and Company
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    Tarak Reddy - initial implementation
  *    Joseph Ross - Made changes to account for mapping multiple guidence patterns with the same context
  *******************************************************************************/

using System.Linq;
using System.Windows.Forms;
using AgGateway.ADAPT.ApplicationDataModel.FieldBoundaries;
using AgGateway.ADAPT.Visualizer.Mapping;
using AgGateway.ADAPT.Visualizer.UI;

namespace AgGateway.ADAPT.Visualizer
{
    public class BoundaryProcessor
    {
        private readonly MapControl _mapControl;

        public BoundaryProcessor(MapControl mapControl)
        {
            _mapControl = mapControl;
        }

        public void ProcessBoundary(FieldBoundary fieldBoundary)
        {
            Map map = new Map();

            foreach (var polygon in fieldBoundary.SpatialData.Polygons)
            {
                map.AddMapObject(new MapPolygon { Polygon = polygon.ToUtm(), Pen = DrawingUtil.B_Black });
            }

            _mapControl.Map = map;
        }
    }
}