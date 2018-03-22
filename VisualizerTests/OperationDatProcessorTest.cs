﻿using System;
using System.Collections.Generic;
using System.Linq;
using AgGateway.ADAPT.ApplicationDataModel.Equipment;
using AgGateway.ADAPT.ApplicationDataModel.LoggedData;
using AgGateway.ADAPT.ApplicationDataModel.Representations;
using AgGateway.ADAPT.ApplicationDataModel.Shapes;
using AgGateway.ADAPT.Representation.RepresentationSystem;
using AgGateway.ADAPT.Representation.RepresentationSystem.ExtensionMethods;
using AgGateway.ADAPT.Representation.UnitSystem;
using AgGateway.ADAPT.Visualizer;
using NUnit.Framework;

namespace VisualizerTests
{
    [TestFixture]
    public class OperationDatProcessorTest
    {
        private OperationDataProcessor _operationDataProcessor;
        private OperationData _operationData;
        private List<SpatialRecord> _spatialRecords;
        private Dictionary<int, List<DeviceElementUse>> _deviceElementUses;
        private List<WorkingData> _workingDatas;

        [SetUp]
        public void Setup()
        {
            _workingDatas = new List<WorkingData>();
            _deviceElementUses = new Dictionary<int, List<DeviceElementUse>>();
            _spatialRecords = new List<SpatialRecord>();
            _operationData = new OperationData
            {
                GetSpatialRecords = () => _spatialRecords,
                GetDeviceElementUses = x => _deviceElementUses[x],
                MaxDepth = 0
            };

            _operationDataProcessor = new OperationDataProcessor();

        }

        [Test]
        public void GivenOperationDataWhenProcessOperationDataThenColumnsAreAdded()
        {
            _workingDatas.Add(new NumericWorkingData { Representation = RepresentationInstanceList.vrHarvestMoisture.ToModelRepresentation() });
            _deviceElementUses.Add(0, new List<DeviceElementUse>
            {
                new DeviceElementUse
                {
                    Depth = 0,
                    GetWorkingDatas = () => _workingDatas,
                }
            });
            _spatialRecords.Add(new SpatialRecord());

            var dataTable = _operationDataProcessor.ProcessOperationData(_operationData);

            Assert.AreEqual(5, dataTable.Columns.Count);
            Assert.AreEqual(_workingDatas.First().Representation.Code + "-" + _workingDatas.First().Id.ReferenceId + "-0", dataTable.Columns[4].ColumnName);
        }

        [Test]
        public void GivenOperationDataWithSpatialRecordDataWithNumericRepValueWhenProcessOperationDAtaThenRowsAreAdded()
        {
            var harvestMoistureMeter = new NumericWorkingData { Representation = RepresentationInstanceList.vrHarvestMoisture.ToModelRepresentation() };
            _workingDatas.Add(harvestMoistureMeter);
            _deviceElementUses.Add(0, new List<DeviceElementUse>
            {
                new DeviceElementUse
                {
                    Depth = 0,
                    GetWorkingDatas = () => _workingDatas,
                }
            });

            var spatialRecord = new SpatialRecord();
            var numericRepresentation = new NumericRepresentationValue(RepresentationInstanceList.vrHarvestMoisture.ToModelRepresentation(), UnitSystemManager.GetUnitOfMeasure("prcnt"), new NumericValue(UnitSystemManager.GetUnitOfMeasure("prcnt"), 3.0));

            spatialRecord.SetMeterValue(harvestMoistureMeter, numericRepresentation);

            _spatialRecords.Add(spatialRecord);

            var dataTable = _operationDataProcessor.ProcessOperationData(_operationData);

            Assert.AreEqual(1, dataTable.Rows.Count);
            Assert.AreEqual(numericRepresentation.Value.Value.ToString(), dataTable.Rows[0][4]);
        }

        [Test]
        public void GivenOperationDataWithSpatialRecordDataWithEnumeratedValueWhenProcessOperationDataThenRowsAreAdded()
        {
            var meter = new EnumeratedWorkingData { Representation = RepresentationInstanceList.dtRecordingStatus.ToModelRepresentation() };
            _workingDatas.Add(meter);
            _deviceElementUses.Add(0, new List<DeviceElementUse>
            {
                new DeviceElementUse
                {
                    Depth = 0,
                    GetWorkingDatas = () => _workingDatas,
                }
            });

            var spatialRecord = new SpatialRecord();
            var enumeratedValue = new EnumeratedValue { Value = DefinedTypeEnumerationInstanceList.dtiRecordingStatusOn.ToModelEnumMember() };

            spatialRecord.SetMeterValue(meter, enumeratedValue);

            _spatialRecords.Add(spatialRecord);

            var dataTable = _operationDataProcessor.ProcessOperationData(_operationData);

            Assert.AreEqual(1, dataTable.Rows.Count);
            Assert.AreEqual(enumeratedValue.Value.Value, dataTable.Rows[0][4]);
        }

        [Test]
        public void GivenOperationDataWithSpatialRecordDataWithNullMeterWhenProcessOperationDataThenRowsAreAdded()
        {
            var meter = new EnumeratedWorkingData { Representation = RepresentationInstanceList.dtRecordingStatus.ToModelRepresentation() };
            _workingDatas.Add(meter);
            _deviceElementUses.Add(0, new List<DeviceElementUse>
            {
                new DeviceElementUse
                {
                    Depth = 0,
                    GetWorkingDatas = () => _workingDatas,
                }
            });

            var spatialRecord = new SpatialRecord();

            _spatialRecords.Add(spatialRecord);

            var dataTable = _operationDataProcessor.ProcessOperationData(_operationData);

            Assert.AreEqual(1, dataTable.Rows.Count);
            Assert.AreEqual("", dataTable.Rows[0][4]);
        }

        [Test]
        public void GivenOperationDataWithSpatialRecordDataWithNullEnumeratedValueWhenProcessOperationDataThenRowsAreAdded()
        {
            var meter = new EnumeratedWorkingData { Representation = RepresentationInstanceList.dtRecordingStatus.ToModelRepresentation() };
            _workingDatas.Add(meter);
            _deviceElementUses.Add(0, new List<DeviceElementUse>
            {
                new DeviceElementUse
                {
                    Depth = 0,
                    GetWorkingDatas = () => _workingDatas,
                }
            });
            var spatialRecord = new SpatialRecord();
            var enumeratedValue = new EnumeratedValue { Representation = RepresentationInstanceList.dtRecordingStatus.ToModelRepresentation(), Value = null };

            spatialRecord.SetMeterValue(meter, enumeratedValue);

            _spatialRecords.Add(spatialRecord);

            var dataTable = _operationDataProcessor.ProcessOperationData(_operationData);

            Assert.AreEqual(1, dataTable.Rows.Count);
            Assert.AreEqual("", dataTable.Rows[0][4]);
        }

        [Test]
        public void GivenOperationDataWithSpatialRecordDataWithNumericRepValueWhenProcessOperationDataThenColumnNamesContainUom()
        {
            var harvestMoistureMeter = new NumericWorkingData { Representation = RepresentationInstanceList.vrHarvestMoisture.ToModelRepresentation() };
            _workingDatas.Add(harvestMoistureMeter);
            _deviceElementUses.Add(0, new List<DeviceElementUse>
            {
                new DeviceElementUse
                {
                    Depth = 0,
                    GetWorkingDatas = () => _workingDatas,
                }
            });

            var spatialRecord = new SpatialRecord();
            var numericRepresentation = new NumericRepresentationValue(RepresentationInstanceList.vrHarvestMoisture.ToModelRepresentation(), UnitSystemManager.GetUnitOfMeasure("prcnt"), new NumericValue(UnitSystemManager.GetUnitOfMeasure("prcnt"), 3.0));

            spatialRecord.SetMeterValue(harvestMoistureMeter, numericRepresentation);

            _spatialRecords.Add(spatialRecord);

            var dataTable = _operationDataProcessor.ProcessOperationData(_operationData);

            var expectedColumnName = _workingDatas.First().Representation.Code + "-" + _workingDatas.First().Id.ReferenceId + "-0-" + numericRepresentation.Value.UnitOfMeasure.Code;
            Assert.AreEqual(expectedColumnName, dataTable.Columns[4].ColumnName);
        }

        [Test]
        public void GivenOperationDataWithMultipleMeterValuesWhenProcessOperationDataThenRowsAreAdded()
        {
            _workingDatas.Add(new NumericWorkingData { Representation = RepresentationInstanceList.vrHarvestMoisture.ToModelRepresentation() });
            _deviceElementUses.Add(0, new List<DeviceElementUse>
            {
                new DeviceElementUse
                {
                    Depth = 0,
                    GetWorkingDatas = () => _workingDatas,
                }
            });

            CreateHavestMoistureSpatialRecord(_workingDatas[0], 3.0);
            CreateHavestMoistureSpatialRecord(_workingDatas[0], 5.0);
            CreateHavestMoistureSpatialRecord(_workingDatas[0], 9.0);
            CreateHavestMoistureSpatialRecord(_workingDatas[0], 2.0);
            CreateHavestMoistureSpatialRecord(_workingDatas[0], 333.0);

            var dataTable = _operationDataProcessor.ProcessOperationData(_operationData);

            Assert.AreEqual(5, dataTable.Rows.Count);
            Assert.AreEqual("3", dataTable.Rows[0][4]);
            Assert.AreEqual("5", dataTable.Rows[1][4]);
            Assert.AreEqual("9", dataTable.Rows[2][4]);
            Assert.AreEqual("2", dataTable.Rows[3][4]);
            Assert.AreEqual("333", dataTable.Rows[4][4]);
        }

        [Test]
        public void GivenOperationalDataWithSpatialDataWhenMapThenBasePostionColumnsDataAreAdded()
        {
            _workingDatas.Add(new NumericWorkingData { Representation = RepresentationInstanceList.vrHarvestMoisture.ToModelRepresentation() });
            _deviceElementUses.Add(0, new List<DeviceElementUse>
            {
                new DeviceElementUse
                {
                    Depth = 0,
                    GetWorkingDatas = () => _workingDatas,
                }
            });

            var longitude = -96.66666;
            var latitude = 42.222222;
            var elevation = 12.1;
            var spatialRecord = new SpatialRecord
            {
                Geometry = new Point { Id = 5, X = longitude, Y = latitude, Z = elevation }
            };
            var meter1Value1 = CreateHarvestMoisture(15.5);
            spatialRecord.SetMeterValue(_workingDatas[0], meter1Value1);
            _spatialRecords.Add(spatialRecord);

            var dataTable = _operationDataProcessor.ProcessOperationData(_operationData);
            Assert.AreEqual(latitude.ToString(), dataTable.Rows[0][0]);
            Assert.AreEqual(longitude.ToString(), dataTable.Rows[0][1]);
            Assert.AreEqual(elevation.ToString(), dataTable.Rows[0][2]);
        }

        [Test]
        public void GivenOperationalDataWithTimeStampWhenMapThenBaseTimeColumnDataisAdded()
        {
            _workingDatas.Add(new NumericWorkingData { Representation = RepresentationInstanceList.vrHarvestMoisture.ToModelRepresentation() });
            _deviceElementUses.Add(0, new List<DeviceElementUse>
            {
                new DeviceElementUse
                {
                    Depth = 0,
                    GetWorkingDatas = () => _workingDatas,
                }
            });

            var dateTime = DateTime.Today;
            var spatialRecord = new SpatialRecord
            {
                Timestamp = dateTime
            };
            var meter1Value1 = CreateHarvestMoisture(15.5);
            spatialRecord.SetMeterValue(_workingDatas[0], meter1Value1);
            _spatialRecords.Add(spatialRecord);

            var dataTable = _operationDataProcessor.ProcessOperationData(_operationData);
            Assert.AreEqual(dateTime.ToString(), dataTable.Rows[0][3]);
        }

        [Test]
        public void GivenOperationalDataWhenMapThenBaseColumnsAreMapped()
        {
            _workingDatas.Add(new NumericWorkingData { Representation = RepresentationInstanceList.vrHarvestMoisture.ToModelRepresentation() });
            _deviceElementUses.Add(0, new List<DeviceElementUse>
            {
                new DeviceElementUse
                {
                    Depth = 0,
                    GetWorkingDatas = () => _workingDatas,
                }
            });

            CreateHavestMoistureSpatialRecord(_workingDatas[0], 3.0);

            var dataTable = _operationDataProcessor.ProcessOperationData(_operationData);
            Assert.AreEqual("Latitude", dataTable.Columns[0].ColumnName);
            Assert.AreEqual("Longitude", dataTable.Columns[1].ColumnName);
            Assert.AreEqual("Elevation", dataTable.Columns[2].ColumnName);
            Assert.AreEqual("TimeStamp", dataTable.Columns[3].ColumnName);
        }

        private void CreateHavestMoistureSpatialRecord(WorkingData workingData, double value)
        {
            var spatialRecord = new SpatialRecord();
            var meter1Value1 = CreateHarvestMoisture(value);
            spatialRecord.SetMeterValue(workingData, meter1Value1);
            _spatialRecords.Add(spatialRecord);
        }

        private static NumericRepresentationValue CreateHarvestMoisture(double value)
        {
            return new NumericRepresentationValue(RepresentationInstanceList.vrHarvestMoisture.ToModelRepresentation(), UnitSystemManager.GetUnitOfMeasure("prcnt"), new NumericValue(UnitSystemManager.GetUnitOfMeasure("prcnt"), value));
        }
    }
}
