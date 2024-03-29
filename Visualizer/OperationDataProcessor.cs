/* Copyright (C) 2015-16 AgGateway and ADAPT Contributors
  * Copyright (C) 2015-16 Deere and Company
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    Tarak Reddy - initial implementation
  *    Joseph Ross - added null checks for recntly added code
  *    Andrew Vardeman - optimized for repeated calls with identical parameters
  *******************************************************************************/

using System.Data;
using System.Globalization;
using AgGateway.ADAPT.ApplicationDataModel.LoggedData;
using AgGateway.ADAPT.ApplicationDataModel.Representations;

using Point = AgGateway.ADAPT.ApplicationDataModel.Shapes.Point;

namespace AgGateway.ADAPT.Visualizer
{
    public class OperationDataProcessor
    {
        private DataTable? _dataTable;
        private int _firstDynamicColumnIndex;
        private OperationData? _lastOperationData;
        private List<SpatialRecord>? _lastSpatialRecords;
        private bool _lastUseMaxCols;
        private int _lastMaxCols;

        public DataTable ProcessOperationData(OperationData operationData, List<SpatialRecord> spatialRecords, bool useMaxCols, int maxCols)
        {
            if (operationData != _lastOperationData || spatialRecords != _lastSpatialRecords ||
                useMaxCols != _lastUseMaxCols || maxCols != _lastMaxCols)
            {
                _lastOperationData = operationData;
                _lastSpatialRecords = spatialRecords;
                _lastUseMaxCols = useMaxCols;
                _lastMaxCols = maxCols;

                _dataTable = new DataTable();

                //Add extra columns
                _dataTable.Columns.Add(new DataColumn("Index")); //Record Index within the OperationData
                _dataTable.Columns.Add(new DataColumn("Latitude")); //Y
                _dataTable.Columns.Add(new DataColumn("Longitude")); //X
                _dataTable.Columns.Add(new DataColumn("Elevation")); //Z
                _dataTable.Columns.Add(new DataColumn("TimeStamp")); //time
                _firstDynamicColumnIndex = _dataTable.Columns.Count;

                if (spatialRecords.Any())
                {
                    var meters = GetWorkingData(operationData, useMaxCols, maxCols);

                    CreateColumns(meters);

                    int index = 0;
                    foreach (var spatialRecord in spatialRecords)
                    {
                        CreateRow(meters, spatialRecord, index++);
                    }

                    UpdateColumnNamesWithUom(meters, spatialRecords);
                }
            }

            return _dataTable!;
        }

        private static Dictionary<int, IEnumerable<WorkingData>> GetWorkingData(OperationData operationData, bool useMaxCols, int maxCols)
        {
            int totalCount = 0;
            var workingDataWithDepth = new Dictionary<int, IEnumerable<WorkingData>>();
            for (var i = 0; i <= operationData.MaxDepth; i++)
            {
                IEnumerable<WorkingData> meters;
                if (useMaxCols)
                {
                    if (totalCount >= maxCols)
                    {
                        break;
                    }

                    var list = operationData.GetDeviceElementUses(i).SelectMany(x => x.GetWorkingDatas())
                        .Where(x => x.Representation != null).Take(maxCols - totalCount).ToList();
                    totalCount += list.Count;
                    meters = list;
                }
                else
                {
                    meters = operationData.GetDeviceElementUses(i).SelectMany(x => x.GetWorkingDatas())
                        .Where(x => x.Representation != null);
                }
                workingDataWithDepth.Add(i, meters);
            }

            return workingDataWithDepth;
        }

        private void CreateColumns(Dictionary<int, IEnumerable<WorkingData>> workingDataDictionary)
        {
            for (int depth = 0; depth < workingDataDictionary.Count; depth++)
            {
                foreach (var workingData in workingDataDictionary[depth])
                {
                    _dataTable!.Columns.Add(GetColumnName(workingData, depth));
                }
            }
        }

        private void CreateRow(Dictionary<int, IEnumerable<WorkingData>> workingDataDictionary, SpatialRecord spatialRecord, int index)
        {
            var dataRow = _dataTable!.NewRow();

            int colIdx = _firstDynamicColumnIndex;
            for (int depth = 0; depth < workingDataDictionary.Count; depth++)
            {
                foreach (var workingData in workingDataDictionary[depth])
                {
                    if (workingData as NumericWorkingData != null)
                        CreateNumericMeterCell(spatialRecord, workingData, depth, dataRow, colIdx);

                    if (workingData as EnumeratedWorkingData != null)
                        CreateEnumeratedMeterCell(spatialRecord, workingData, depth, dataRow, colIdx);
                    colIdx++;
                }
            }

            dataRow["Index"] = index;
            if (spatialRecord.Geometry is Point ptData)
            {
                //Fill in the other cells
                dataRow["Latitude"] = ptData.Y.ToString(); //Y
                dataRow["Longitude"] = ptData.X.ToString(); //X
                dataRow["Elevation"] = ptData.Z.ToString(); //Z
            }
            if (spatialRecord.Timestamp != null)
            {
                dataRow["TimeStamp"] = spatialRecord.Timestamp.ToString();
            }

            _dataTable.Rows.Add(dataRow);
        }

        private static void CreateEnumeratedMeterCell(SpatialRecord spatialRecord, WorkingData workingData, int depth, DataRow dataRow, int columnIndex)
        {
            var enumeratedValue = spatialRecord.GetMeterValue(workingData) as EnumeratedValue;

            dataRow[columnIndex] = enumeratedValue != null && enumeratedValue.Value != null ? enumeratedValue.Value.Value : "";
        }

        private static void CreateNumericMeterCell(SpatialRecord spatialRecord, WorkingData workingData, int depth, DataRow dataRow, int columnIndex)
        {
            var numericRepresentationValue = spatialRecord.GetMeterValue(workingData) as NumericRepresentationValue;
            var value = numericRepresentationValue != null
                ? numericRepresentationValue.Value.Value.ToString(CultureInfo.InvariantCulture)
                : "";

            dataRow[columnIndex] = value;
        }

        private void UpdateColumnNamesWithUom(Dictionary<int, IEnumerable<WorkingData>> workingDatas, List<SpatialRecord> spatialRecords)
        {
            foreach (var kvp in workingDatas)
            {
                foreach (var data in kvp.Value)
                {
                    var data1 = data;
                    var workingDataValues = spatialRecords.Select(x => x.GetMeterValue(data1) as NumericRepresentationValue);
                    var numericRepresentationValues = workingDataValues.Where(x => x != null);
                    var uoms = numericRepresentationValues.Select(x => x.Value.UnitOfMeasure).ToList();
                
                    if (uoms.Any())
                        _dataTable.Columns[GetColumnName(data, kvp.Key)].ColumnName += "-" + uoms.First()?.Code;
                }
            }
        }

        private static string GetColumnName(WorkingData workingData, int depth)
        {
            return String.Format("{0}-{1}-{2}", workingData.Representation.Code, workingData.Id.ReferenceId, depth);
        }
    }
}