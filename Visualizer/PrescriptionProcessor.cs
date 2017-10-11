/* Copyright (C) 2015-16 AgGateway and ADAPT Contributors
  * Copyright (C) 2015-16 Deere and Company
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    Kelly Nelson - implemented based on like classes in this project
  *******************************************************************************/

using System.Linq;
using System.Windows.Forms;
using AgGateway.ADAPT.ApplicationDataModel.FieldBoundaries;
using AgGateway.ADAPT.ApplicationDataModel.LoggedData;
using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.Shapes;
using AgGateway.ADAPT.ApplicationDataModel.Prescriptions;

namespace AgGateway.ADAPT.Visualizer
{
    public class PrescriptionProcessor
    {
        private DrawingUtil _drawingUtil;
        private readonly TabPage _spatialViewer;

        public PrescriptionProcessor(TabPage spatialViewer)
        {
            _spatialViewer = spatialViewer;
        }

        public void ProcessPrescription(Prescription prescription)
        {
            if (prescription is VectorPrescription) //Only Vector currently supported for the Visualizer map
            {
                VectorPrescription vectorPrescription = prescription as VectorPrescription;

                using (var graphics = _spatialViewer.CreateGraphics())
                {
                    _drawingUtil = new DrawingUtil(_spatialViewer.Width, _spatialViewer.Height, graphics);

                    List<Point> allPoints = new List<Point>();
                    List<List<Point>> projectedPointsPerPolygon = new List<List<Point>>();
                    foreach (Polygon polygon in vectorPrescription.RxShapeLookups.SelectMany(x => x.Shape.Polygons))
                    {
                        List<Point> polygonPoints = new List<Point>();
                        foreach (Point point in polygon.ExteriorRing.Points)
                        {
                            Point projectedPoint = point.ToUtm();
                            allPoints.Add(projectedPoint);
                            polygonPoints.Add(projectedPoint);
                        }
                        projectedPointsPerPolygon.Add(polygonPoints);
                    }
                    _drawingUtil.SetMinMax(allPoints);
                    foreach (List<Point> polygonPoints in projectedPointsPerPolygon)
                    {
                        var screenPolygon = polygonPoints.Select(point => point.ToXy(_drawingUtil.MinX, _drawingUtil.MinY, _drawingUtil.GetDelta())).ToArray();
                        graphics.DrawPolygon(DrawingUtil.Pen, screenPolygon);
                    }
                }
            }
        }
    }
}
