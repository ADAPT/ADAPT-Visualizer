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
using AgGateway.ADAPT.ApplicationDataModel.Equipment;
using AgGateway.ADAPT.ApplicationDataModel.Shapes;
using AgGateway.ADAPT.ApplicationDataModel.ADM;
using AgGateway.ADAPT.ApplicationDataModel.Representations;

namespace AgGateway.ADAPT.Visualizer
{
    public class SpatialRecordProcessor
    {
        private DrawingUtil _drawingUtil;
        private readonly TabPage _spatialViewer;
        private Dictionary<string, WorkingData> _workingDataDictionary;
        private OperationData _lastOperationData;

        public SpatialRecordProcessor(TabPage spatialViewer)
        {
            _spatialViewer = spatialViewer;
        }

        /// <summary>
        /// Populates all DeviceElementUses/WorkingDatas and draws a black polygon
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="catalog"></param>
        public void ProcessOperation(OperationData operation, Catalog catalog)
        {
            _workingDataDictionary = GetWorkingDataDictionary(operation, catalog);
            _lastOperationData = operation;
        }

        /// <summary>
        /// Draws a red polygon if all values 0, a green polygon if all values the same non-zero value, or else themes red/orange/yellow/green.
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="workingDataKey"></param>
        public void ThemeMap(string workingDataKey)
        {
            using (var graphics = _spatialViewer.CreateGraphics())
            {
                graphics.Clear(System.Drawing.Color.White);
                _drawingUtil = new DrawingUtil(_spatialViewer.Width, _spatialViewer.Height, graphics);

                List<Point> projectedPoints = new List<Point>();
                List<double> doubleValues = null;
                foreach (SpatialRecord record in _lastOperationData.GetSpatialRecords())
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
                                doubleValues.Add(enumValue.Value.Value == "On" ? 1d : 0d);
                            }
                        }
                    }
                }

                _drawingUtil.SetMinMax(projectedPoints);
                var screenPolygon = projectedPoints.Select(point => point.ToXy(_drawingUtil.MinX, _drawingUtil.MinY, _drawingUtil.GetDelta())).ToArray();

                if (screenPolygon.All(p => !double.IsNaN(p.X) && !double.IsNaN(p.Y)))
                {
                    if (doubleValues == null)
                    {
                        //WorkingData is not numeric
                        graphics.DrawPolygon(DrawingUtil.Pen, screenPolygon);
                    }
                    else
                    {
                        if (doubleValues.Max() == doubleValues.Min())
                        {
                            //All values are the same
                            if (doubleValues.Max() == 0d)
                            {
                                //Zero values
                                graphics.DrawPolygon(DrawingUtil.RedPen, screenPolygon);
                            }
                            else
                            {
                                //Non-zero values
                                graphics.DrawPolygon(DrawingUtil.GreenPen, screenPolygon);
                            }
                        }
                        else
                        {
                            //Simple scheme where
                            //Red = Minimum Value
                            //Orange = Value is in bottom third (non minimum)
                            //Yellow = Value is in middle third
                            //Green = Value is in top third
                            int i = 0;
                            double range = (doubleValues.Max() - doubleValues.Min()) / 3;
                            double firstThird = doubleValues.Min() + range;
                            double secondThird = firstThird + range;
                            foreach (System.Drawing.PointF f in screenPolygon)
                            {
                                double d = i < doubleValues.Count ? doubleValues[i] : 0d;  //Values will be in same order as points
                                System.Drawing.Pen pen = DrawingUtil.YellowPen;
                                if (d == doubleValues.Min())
                                {
                                    pen = DrawingUtil.RedPen;
                                }
                                else if (d <= firstThird)
                                {
                                    pen = DrawingUtil.OrangePen;
                                }
                                else if (d >= secondThird)
                                {
                                    pen = DrawingUtil.GreenPen;
                                }
                                graphics.DrawEllipse(pen, new System.Drawing.RectangleF(f.X, f.Y, 2, 2));
                                i++;
                            }
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
                        string key = $"{deviceElementUse.Depth}.{deviceElementUse.Order}:__{deviceName}_{workingData.Representation.Code}";
                        if (!workingDataDictionary.ContainsKey(key)) 
                        {
                            workingDataDictionary.Add(key, workingData);
                        }
                    }
                }
            }
            return workingDataDictionary;
        }
    }
}
