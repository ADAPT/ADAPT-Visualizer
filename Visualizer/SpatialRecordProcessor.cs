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

using AgGateway.ADAPT.ApplicationDataModel.ADM;
using AgGateway.ADAPT.ApplicationDataModel.Equipment;
using AgGateway.ADAPT.ApplicationDataModel.LoggedData;
using AgGateway.ADAPT.ApplicationDataModel.Representations;
using AgGateway.ADAPT.ApplicationDataModel.Shapes;
using AgGateway.ADAPT.Visualizer.Mapping;
using AgGateway.ADAPT.Visualizer.UI;
using Point = AgGateway.ADAPT.ApplicationDataModel.Shapes.Point;

namespace AgGateway.ADAPT.Visualizer
{
    public class SpatialRecordProcessor
    {
        private DrawingUtil _drawingUtil;
        private readonly MapControl _mapControl;
        private Dictionary<string, WorkingData> _workingDataDictionary;
        private OperationData _lastOperationData;
        private List<SpatialRecord> _spatialRecords;
        private Bitmap? _bitmap;

        public SpatialRecordProcessor(MapControl mapControl)
        {
            _mapControl = mapControl;
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
            Map map = new Map();

            List<Point> projectedPoints = new List<Point>();
            List<double> doubleValues = null;
            foreach (SpatialRecord record in _spatialRecords)
            {
                Point? point = record.Geometry.FirstPoint();
                if (point is null)
                {
                    continue;
                }

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

                        if (numericValue != null && numericValue.Value != null)
                        {
                            doubleValues.Add(numericValue.Value.Value);
                        }
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

            if (projectedPoints.All(p => !double.IsNaN(p.X) && !double.IsNaN(p.Y)))
            {
                if (doubleValues == null || doubleValues.Count == 0)
                {
                    //WorkingData is not numeric
                    AddMapObject(map, projectedPoints, DrawingUtil.B_Black);
                }
                else
                {
                    if (doubleValues.Max() == doubleValues.Min())
                    {
                        //All values are the same
                        if (doubleValues.Max() <= 0d)
                        {
                            //Zero values
                            AddMapObject(map, projectedPoints, DrawingUtil.E_Red);
                        }
                        else
                        {
                            //Non-zero values
                            AddMapObject(map, projectedPoints, DrawingUtil.C_DarkMagenta);
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

                        foreach (ADAPT.ApplicationDataModel.Shapes.Point f in projectedPoints)
                        {
                            double dbl = i < doubleValues.Count
                                ? doubleValues[i]
                                : 0d; //Values will be in same order as points
                            Pen pen = DrawingUtil.B_Black;

                            if (dbl <= e7th)
                            {
                                pen = DrawingUtil.E_Red;
                            }
                            else if (dbl <= f7th)
                            {
                                pen = DrawingUtil.F_DarkOrange;
                            }
                            else if (dbl <= g7th)
                            {
                                pen = DrawingUtil.G_Gold;
                            }
                            else if (dbl <= h7th)
                            {
                                pen = DrawingUtil.H_YellowGreen;
                            }
                            else if (dbl <= i7th)
                            {
                                pen = DrawingUtil.I_LawnGreen;
                            }
                            else if (dbl <= j7th)
                            {
                                pen = DrawingUtil.J_LimeGreen;
                            }
                            else if (dbl <= k7th)
                            {
                                pen = DrawingUtil.K_ForestGreen;
                            }
                            else if (dbl <= l7th)
                            {
                                pen = DrawingUtil.L_DarkGreen;
                            }

                            map.AddMapObject(new MapPoint
                            {
                                Point = f,
                                Pen = pen
                            });

                            i++;
                        }
                    }

                }
            }
            _mapControl.Map = map;
        }

        public void AddMapObject(Map map, List<Point> points, Pen pen)
        {
            if (map == null || points == null || points.Count == 0)
            {
                return;
            }
            if (points.Count == 1)
            {
                map.AddMapObject(new MapPoint
                {
                    Point = points[0],
                    Pen = pen
                });
            }
            else
            {
                map.AddMapObject(new MapLineString
                {
                    LineString = new LineString { Points = points },
                    Pen = pen
                });
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
