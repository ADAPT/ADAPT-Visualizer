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

using AgGateway.ADAPT.ApplicationDataModel.Shapes;
using AgGateway.ADAPT.ApplicationDataModel.Prescriptions;
using AgGateway.ADAPT.Visualizer.Mapping;
using AgGateway.ADAPT.Visualizer.UI;

namespace AgGateway.ADAPT.Visualizer
{
    public class PrescriptionProcessor
    {
        private DrawingUtil _drawingUtil;
        private readonly MapControl _mapControl;

        public PrescriptionProcessor(MapControl mapControl)
        {
            _mapControl = mapControl;
        }

        public void ProcessPrescription(Prescription prescription)
        {
            Map map = new Map();
            if (prescription is VectorPrescription) //Only Vector currently supported for the Visualizer map
            {
                VectorPrescription vectorPrescription = prescription as VectorPrescription;

                foreach (Polygon polygon in vectorPrescription.RxShapeLookups.SelectMany(x => x.Shape.Polygons))
                {
                    map.AddMapObject(new MapPolygon
                    {
                        Polygon = polygon.ToUtm(),
                        Pen = DrawingUtil.B_Black
                    });
                }
            }
            _mapControl.Map = map;
        }
    }
}
