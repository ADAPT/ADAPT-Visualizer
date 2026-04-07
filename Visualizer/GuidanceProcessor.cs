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

using AgGateway.ADAPT.ApplicationDataModel.Guidance;
using AgGateway.ADAPT.ApplicationDataModel.Shapes;
using AgGateway.ADAPT.Visualizer.Mapping;
using AgGateway.ADAPT.Visualizer.UI;
using Point = AgGateway.ADAPT.ApplicationDataModel.Shapes.Point;

namespace AgGateway.ADAPT.Visualizer
{
    public class GuidanceProcessor
    {
        private Map? _map;
        private readonly MapControl _mapControl;
        

        public GuidanceProcessor(MapControl mapControl)
        {
            _mapControl = mapControl;
        }

        public void ProcessGuidance(GuidanceGroup guidanceGroup, List<GuidancePattern> guidancePatterns)
        {
            _map = new Map();
            foreach (var id in guidanceGroup.GuidancePatternIds)
            {
                ProcessGuidancePattern(guidancePatterns, id);
            }
            _mapControl.Map = _map;
        }

        private void ProcessGuidancePattern(IEnumerable<GuidancePattern> guidancePatterns, int id)
        {
            var guidancePattern = guidancePatterns.First(pattern => pattern.Id.ReferenceId == id);
            ProcessPattern(guidancePattern);
        }

        public void ProccessGuidancePattern(GuidancePattern guidancePattern)
        {
            _map = new Map();

            ProcessPattern(guidancePattern);

            _mapControl.Map = _map;
        }

        private void ProcessPattern(GuidancePattern guidancePattern)
        {
            if (guidancePattern is APlus)
            {
                ProcessAPlus(guidancePattern as APlus);
            }
            else if (guidancePattern is AbLine)
            {
                ProcessAbLine(guidancePattern as AbLine);
            }
            else if (guidancePattern is AbCurve)
            {
                ProcessAbCurve(guidancePattern as AbCurve);
            }
            else if (guidancePattern is PivotGuidancePattern)
            {
                ProcessCenterPivot(guidancePattern as PivotGuidancePattern);
            }
            else if (guidancePattern is MultiAbLine)
            {
                ProcessMultiAbLine(guidancePattern as MultiAbLine);
            }
            else if (guidancePattern is Spiral)
            {
                ProcessSpiral(guidancePattern as Spiral);
            }
        }

        private void ProcessSpiral(Spiral spiral)
        {
            ProcessLineString(spiral.Shape.ToUtm());
        }

        private void ProcessMultiAbLine(MultiAbLine multiAbLine)
        {
            foreach (var abLine in multiAbLine.AbLines)
            {
                ProcessPoints(new List<Point> {abLine.A.ToUtm(), abLine.B.ToUtm()});
            }
        }

        private void ProcessCenterPivot(PivotGuidancePattern centerPivot)
        {
            var center = centerPivot.Center.ToUtm();
            var radius = GetRadius(centerPivot);
            var points = new List<Point>();
            for (int i = 0; i < 36; i++)
            {
                double angle = Math.PI * i / 18;
                double x = center.X + radius * Math.Cos(angle);
                double y = center.Y + radius * Math.Sin(angle);
                points.Add(new Point { X = x, Y = y });
            }
            _map.AddMapObject(new MapPolygon
            {
                Pen = DrawingUtil.B_Black,
                Polygon = new Polygon { ExteriorRing = new LinearRing { Points = points } }
            });
        }

        private float GetRadius(PivotGuidancePattern centerPivot)
        {
            var width = centerPivot.Center.ToUtm().X - centerPivot.EndPoint.ToUtm().X;
            
            return (float)Math.Abs(width);
        }

        private void ProcessAbCurve(AbCurve abCurve)
        {
            foreach (var lineString in abCurve.Shape)
            {
                ProcessLineString(lineString.ToUtm());
            }
        }

        private void ProcessAbLine(AbLine abLine)
        {
            ProcessPoints(new List<Point> {abLine.A.ToUtm(), abLine.B.ToUtm()});
        }

        private void ProcessAPlus(APlus aPlus)
        {
            var projectedPoint = aPlus.Point;
        }

        private void ProcessLineString(LineString lineString)
        {
            ProcessPoints(lineString.Points);
        }

        private void ProcessPoints(List<Point> points)
        {
            if (!points.Any() || points.Count() == 1)
                return;

            _map.AddMapObject(new MapLineString
            {
                LineString = new LineString { Points = points },
                Pen = DrawingUtil.B_Black
            });
        }
    }
}