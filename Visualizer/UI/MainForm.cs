/* Copyright (C) 2015-16 AgGateway and ADAPT Contributors
  * Copyright (C) 2015-16 Deere and Company
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    Tarak Reddy - initial implementation
  *    Martin Sperlich - added Find (Ctrl+F) and Find Next (F3).
  *    Andrew Vardeman - added Limit Data option and some performance optimizations.
  *******************************************************************************/

using System;
using System.Drawing;
using System.Windows.Forms;
using AgGateway.ADAPT.ApplicationDataModel.FieldBoundaries;
using AgGateway.ADAPT.ApplicationDataModel.Guidance;
using AgGateway.ADAPT.ApplicationDataModel.LoggedData;
using AgGateway.ADAPT.Visualizer.Properties;
using AgGateway.ADAPT.ApplicationDataModel.Prescriptions;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AgGateway.ADAPT.Visualizer.UI
{
    public partial class MainForm : Form
    {
        private readonly Model _model;
        private readonly BoundaryProcessor _boundaryProcessor;
        private readonly GuidanceProcessor _guidanceProcessor;
        private readonly OperationDataProcessor _operationDataProcessor;
        private readonly SpatialRecordProcessor _spatialRecordProcessor;
        private readonly PrescriptionProcessor _prescriptionProcessor;
        private Action<Model.State, string> _updateStatusAction;
        private static BusyForm _busyForm;

        private string _findWhat;
        private bool _loaded;
        private ProcessDataRequest? _lastProcessDataRequest;

        private TreeNode? ProcessedNode => _tabPageSpatial.Tag as TreeNode;

        public MainForm()
        {
            InitializeComponent();

            _updateStatusAction = UpdateStatus;
            _model = new Model(_updateStatusAction);
            _operationDataProcessor = new OperationDataProcessor();
            _boundaryProcessor = new BoundaryProcessor(_tabPageSpatial);
            _guidanceProcessor = new GuidanceProcessor(_tabPageSpatial);
            _spatialRecordProcessor = new SpatialRecordProcessor(_tabPageSpatial);
            _prescriptionProcessor = new PrescriptionProcessor(_tabPageSpatial);
            _limitDataPanel.Visible = Settings.Default.ShowLimitDataUI;
            _limitDataCheckBox.Checked = Settings.Default.ShowLimitDataUI && Settings.Default.LimitData;

            _maxRowsNumericUpDown.Value = Settings.Default.MaxRows;
            _maxColumnsNumericUpDown.Value = Settings.Default.MaxColumns;

            if (Settings.Default.RememberWindowSettings)
            {
                SuspendLayout();
                if (!Settings.Default.UnmaximizedLocation.IsEmpty)
                {
                    StartPosition = FormStartPosition.Manual;
                    Location = Settings.Default.UnmaximizedLocation;
                }
                WindowState = Settings.Default.Maximized ? FormWindowState.Maximized : FormWindowState.Normal;
                ResumeLayout();
            }

            _busyForm = new BusyForm();
        }

        private void UpdateStatus(Model.State state, string s)
        {
            if (state == Model.State.StateIdle)
            {
                _busyForm.Invoke(new Action(() =>
                {
                    _busyForm.Hide();
                    _busyForm.UpdateLabel("Busy");
                }));

                return;
            }

            if (_busyForm != null)
            {
                if (_busyForm.InvokeRequired)
                {
                    _busyForm.Invoke(new Action(() =>
                    {
                        _busyForm.UpdateLabel(s);
                    }));
                }
                else
                {
                    _busyForm.UpdateLabel(s);
                }
            }
        }

        private void _treeViewMetadata_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            _tabControlViewer.SelectTab(_tabPageSpatial);
            workingDataComboBox.Visible = false;

            using (var g = _tabPageSpatial.CreateGraphics())
            {
                g.Clear(Color.White);
            }
            _dataGridViewRawData.DataSource = null;
            _dataGridViewTotals.DataSource = null;

            var treeNode = e.Node;

            _tabPageSpatial.Tag = treeNode.Tag == null ? treeNode.Tag : treeNode;

            if (treeNode.Tag == null)
                return;

            Cursor.Current = Cursors.WaitCursor;
            ProcessData(GetProcessDataRequest(treeNode));
            Cursor.Current = Cursors.Default;
        }

        private void _tabPageSpatial_Paint(object sender, PaintEventArgs e)
        {
            if (ProcessedNode == null)
            {
                return;
            }
            ProcessData(GetProcessDataRequest(ProcessedNode));
        }

        private void _aboutToolStripButton_Click(object sender, EventArgs e)
        {
            ShowForm(new AboutForm());
        }

        private bool OkToShowImportExport()
        {
            if (_model.CurrentState == Model.State.StateImporting)
            {
                MessageBox.Show("Currently importing.  Please Wait.");
                return false;
            }

            if (_model.CurrentState == Model.State.StateExporting)
            {
                MessageBox.Show("Currently exporting.  Please Wait.");
                return false;
            }

            if (_model.CurrentState != Model.State.StateIdle)
            {
                MessageBox.Show("Currently busy.  Please Wait.");
                return false;
            }

            return true;
        }

        private void _importToolStripButton_Click(object sender, EventArgs e)
        {
            if (OkToShowImportExport())
            {
                ShowForm(new ImportForm(_model, _treeViewMetadata, _dataGridViewRawData));
                CheckIfBusy();
            }
        }

        private void _exportToolStripButton_Click(object sender, EventArgs e)
        {
            if (OkToShowImportExport())
            {
                ShowForm(new ExportForm(_model));
                CheckIfBusy();
            }
        }

        private void ShowForm(Form form)
        {
            form.ShowDialog(this);
        }

        private void CheckIfBusy()
        {
            if (_model.CurrentState != Model.State.StateIdle)
            {
                _busyForm.Show(this);
            }
        }

        private void _buttonExportRawData_Click(object sender, EventArgs e)
        {
            if (_dataGridViewRawData.DataSource is not DataTable dataTable)
            {
                return;
            }

            var saveFileDialog = new SaveFileDialog
            {
                DefaultExt = ".csv",
                Filter = @"CSV File (.csv)|*.csv"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Cursor.Current = Cursors.WaitCursor;
                ProcessData(GetProcessDataRequest(ProcessedNode, true));
                _model.WriteCsvFile(saveFileDialog.FileName, dataTable);
                Cursor.Current = Cursors.Default;
            }
        }

        private void ProcessData(ProcessDataRequest request)
        {
            var matchesLastRequest = request.Equals(_lastProcessDataRequest);
            if (matchesLastRequest)
            {
                request.SpatialRecords = _lastProcessDataRequest!.SpatialRecords;
            }
            var treeNode = request.Node;
            var objectWithIndex = (ObjectWithIndex)treeNode.Tag;
            var element = objectWithIndex.Element;
            ApplicationDataModel.ADM.ApplicationDataModel model = _model.ApplicationDataModels[objectWithIndex.ApplicationDataModelIndex];

            workingDataComboBox.Visible = false;
            if (element is FieldBoundary)
            {
                _boundaryProcessor.ProcessBoundary(element as FieldBoundary);
                _tabControlViewer.SelectedTab = _tabPageSpatial;
            }
            else if (element is GuidanceGroup)
            {
                _guidanceProcessor.ProcessGuidance(element as GuidanceGroup, model.Catalog.GuidancePatterns);
                _tabControlViewer.SelectedTab = _tabPageSpatial;
            }
            else if (element is GuidancePattern)
            {
                _guidanceProcessor.ProccessGuidancePattern(element as GuidancePattern);
                _tabControlViewer.SelectedTab = _tabPageSpatial;
            }
            else if (element is OperationData operation)
            {
                List<SpatialRecord> spatialRecords = new List<SpatialRecord>();
                if (request.SpatialRecords != null)
                {
                    spatialRecords = request.SpatialRecords;
                }
                else if (operation.GetSpatialRecords != null)
                {
                    IEnumerable<SpatialRecord> spatialRecordsEnumerable = operation.GetSpatialRecords();
                    if (spatialRecordsEnumerable == null)
                    {
                        spatialRecords = new List<SpatialRecord>();
                    }
                    else
                    {
                        //Iterate the records once here for multiple consumers below
                        spatialRecords = request.LimitData ?
                            spatialRecordsEnumerable.Take(request.MaxRows).ToList() : // Limit iterations for a more responsive UI
                            spatialRecordsEnumerable.ToList();
                    }
                    request.SpatialRecords = spatialRecords;
                }

                _dataGridViewRawData.DataSource = _operationDataProcessor.ProcessOperationData(operation, spatialRecords, request.LimitData, request.MaxColumns);

                _spatialRecordProcessor.ProcessOperation(operation, spatialRecords, model.Catalog);
                workingDataComboBox.Visible = true;
                if (matchesLastRequest)
                {
                    DrawSpatialRecords();
                }
                else
                {
                    workingDataComboBox.DataSource = _spatialRecordProcessor.WorkingDataList;
                }
            }
            else if (element is Prescription)
            {
                _prescriptionProcessor.ProcessPrescription(element as Prescription);
            }

            _lastProcessDataRequest = request;
        }

        private void MainForm_LocationChanged(object sender, EventArgs e)
        {
            ResizeBusyForm();
            SaveWindowSettings();
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            ResizeBusyForm();
            SaveWindowSettings();
        }

        private void ResizeBusyForm()
        {
            if (_busyForm == null || _busyForm.Visible != true)
                return;

            Point mainFormCoords = this.Location;
            int mainFormWidth = this.Size.Width;
            int mainFormHeight = this.Size.Height;
            Point mainFormCenter = new Point();
            mainFormCenter.X = mainFormCoords.X + (mainFormWidth / 2);
            mainFormCenter.Y = mainFormCoords.Y + (mainFormHeight / 2);
            Point waitFormLocation = new Point();
            waitFormLocation.X = mainFormCenter.X - (_busyForm.Width / 2);
            waitFormLocation.Y = mainFormCenter.Y - (_busyForm.Height / 2);
            _busyForm.StartPosition = FormStartPosition.Manual;
            _busyForm.Location = waitFormLocation;
        }

        private void SaveWindowSettings()
        {
            if (_loaded)
            {
                Settings.Default.AutoScaleWidth = CurrentAutoScaleDimensions.Width;
                Settings.Default.AutoScaleHeight = CurrentAutoScaleDimensions.Height;
                Settings.Default.Maximized = WindowState == FormWindowState.Maximized;

                if (WindowState == FormWindowState.Normal)
                {
                    Settings.Default.UnmaximizedLocation = Location;
                    Settings.Default.UnmaximizedSize = Size;
                }
            }
        }

        private Boolean _inputQuery(String caption, String prompt, ref String value)
        {
            Form form;
            form = new Form();
            form.AutoScaleMode = AutoScaleMode.Font;
            form.Font = SystemFonts.IconTitleFont;

            SizeF dialogUnits;
            dialogUnits = form.AutoScaleDimensions;

            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.Text = caption;

            form.ClientSize = new Size(
                        MulDiv(180, dialogUnits.Width, 4),
                        MulDiv(63, dialogUnits.Height, 8));

            form.StartPosition = FormStartPosition.CenterScreen;

            System.Windows.Forms.Label lblPrompt;
            lblPrompt = new System.Windows.Forms.Label();
            lblPrompt.Parent = form;
            lblPrompt.AutoSize = true;
            lblPrompt.Left = MulDiv(8, dialogUnits.Width, 4);
            lblPrompt.Top = MulDiv(8, dialogUnits.Height, 8);
            lblPrompt.Text = prompt;

            System.Windows.Forms.TextBox edInput;
            edInput = new System.Windows.Forms.TextBox();
            edInput.Parent = form;
            edInput.Left = lblPrompt.Left;
            edInput.Top = MulDiv(19, dialogUnits.Height, 8);
            edInput.Width = MulDiv(164, dialogUnits.Width, 4);
            edInput.Text = value;
            edInput.SelectAll();


            int buttonTop = MulDiv(41, dialogUnits.Height, 8);
            //Command buttons should be 50x14 dlus
            Size buttonSize = ScaleSize(new Size(50, 14), dialogUnits.Width / 4, dialogUnits.Height / 8);

            System.Windows.Forms.Button bbOk = new System.Windows.Forms.Button();
            bbOk.Parent = form;
            bbOk.Text = "OK";
            bbOk.DialogResult = DialogResult.OK;
            form.AcceptButton = bbOk;
            bbOk.Location = new Point(MulDiv(38, dialogUnits.Width, 4), buttonTop);
            bbOk.Size = buttonSize;

            System.Windows.Forms.Button bbCancel = new System.Windows.Forms.Button();
            bbCancel.Parent = form;
            bbCancel.Text = "Cancel";
            bbCancel.DialogResult = DialogResult.Cancel;
            form.CancelButton = bbCancel;
            bbCancel.Location = new Point(MulDiv(92, dialogUnits.Width, 4), buttonTop);
            bbCancel.Size = buttonSize;

            if (form.ShowDialog() == DialogResult.OK)
            {
                value = edInput.Text;
                return true;
            }
            else
            {
                return false;
            }
        }

        private static Size ScaleSize(Size original, float factorX, float factorY)
        {
            original.Width = (int)(original.Width * factorX);
            original.Height = (int)(original.Height * factorY);
            return original;
        }

        private static int MulDiv(int number, float numeratorA, int denominator)
        {
            int numerator = (int)numeratorA;
            return (int)(((long)number * numerator + (denominator >> 1)) / denominator);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _findWhat = Settings.Default.FindString;

            ApplyWindowSettings();
            _loaded = true;
        }

        private void ApplyWindowSettings()
        {
            SuspendLayout();
            Size size = Size;
            Rectangle bounds = Screen.GetWorkingArea(this);
            SizeF scale = CurrentAutoScaleDimensions;
            bool applySettings = Settings.Default.RememberWindowSettings &&
                                 scale.Width == Settings.Default.AutoScaleWidth &&
                                 scale.Height == Settings.Default.AutoScaleHeight;
            if (applySettings)
            {
                if (!Settings.Default.UnmaximizedSize.IsEmpty)
                {
                    size = Settings.Default.UnmaximizedSize;
                }
            }

            size.Width = Math.Min(size.Width, bounds.Width);
            size.Height = Math.Min(size.Height, bounds.Height);

            if (WindowState == FormWindowState.Normal)
            {
                Size = size;

                if (Right > bounds.Right)
                {
                    Left = bounds.Right - Width;
                }

                if (Bottom > bounds.Bottom)
                {
                    Top = bounds.Bottom - Height;
                }

                if (Left < bounds.Left)
                {
                    Left = bounds.Left;
                }

                if (Top < bounds.Top)
                {
                    Top = bounds.Top;
                }
            }

            ResumeLayout();

            if (applySettings)
            {
                if (Settings.Default.SplitterDistanceMap != 0)
                {
                    _splitContainerMap.SplitterDistance = Settings.Default.SplitterDistanceMap;
                }

                if (Settings.Default.SplitterDistanceViewer != 0)
                {
                    _splitContainerViewer.SplitterDistance = Settings.Default.SplitterDistanceViewer;
                }
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.FindString = _findWhat;
            Settings.Default.Save();
        }

        private void _findNextMenuItem_Click(object sender, EventArgs e)
        {
            _model.FindNextInTree(_treeViewMetadata);
        }

        private void _findMenuItem_Click(object sender, EventArgs e)
        {
            if (_inputQuery("Find", "Find:", ref _findWhat))
            {
                _model.FindInTree(_treeViewMetadata, _findWhat);
            }
        }

        private void _importMenuItem_Click(object sender, EventArgs e)
        {
            _importToolStripButton_Click(sender, e);
        }

        private void _exportMenuItem_Click(object sender, EventArgs e)
        {
            _exportToolStripButton_Click(sender, e);
        }

        private void workingDataComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrawSpatialRecords();
        }

        private void DrawSpatialRecords()
        {
            string workingDataKey = (string)workingDataComboBox.SelectedItem;
            _spatialRecordProcessor.ThemeMap(workingDataKey);
        }

        private void _dataGridViewRawData_Paint(object sender, PaintEventArgs e)
        {
            workingDataComboBox.Visible = false;
        }

        private void _dataGridViewRawData_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.FillWeight = 1;
        }

        private void _limitDataCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool limit = _limitDataCheckBox.Checked;
            Settings.Default.LimitData = limit;
            _maxRowsNumericUpDown.Enabled = limit;
            _maxColumnsNumericUpDown.Enabled = limit;
            _maxRowsLabel.Enabled = limit;
            _maxColumnsLabel.Enabled = limit;
            if (ProcessedNode != null)
            {
                Cursor.Current = Cursors.WaitCursor;
                ProcessData(GetProcessDataRequest(ProcessedNode));
                Cursor.Current = Cursors.Default;
            }
        }

        private void _settingsToolStripButton_Click(object sender, EventArgs e)
        {
            new SettingsForm().ShowDialog(this);
            _limitDataPanel.Visible = Settings.Default.ShowLimitDataUI;
            if (!_limitDataPanel.Visible)
            {
                _limitDataCheckBox.Checked = false;
            }
        }

        private void _splitContainerMap_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (_loaded)
            {
                Settings.Default.SplitterDistanceMap = _splitContainerMap.SplitterDistance;
            }
        }

        private void _splitContainerViewer_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (_loaded)
            {
                Settings.Default.SplitterDistanceViewer = _splitContainerViewer.SplitterDistance;
            }
        }

        private void _maxRowsNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.MaxRows = (int)_maxRowsNumericUpDown.Value;
        }

        private void _maxColumnsNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.MaxColumns = (int)_maxColumnsNumericUpDown.Value;
        }

        private void _limitDataPanel_VisibleChanged(object sender, EventArgs e)
        {
            if (!_limitDataPanel.Visible)
            {
                _limitDataCheckBox.Checked = false;
            }
        }

        private ProcessDataRequest GetProcessDataRequest(TreeNode node, bool overrideLimitDataCheckBox = false, bool overrideValue = false)
        {
            bool limitData = overrideLimitDataCheckBox ? overrideValue : _limitDataCheckBox.Checked;
            return new ProcessDataRequest(node, limitData, (int)_maxRowsNumericUpDown.Value,
                (int)_maxColumnsNumericUpDown.Value);
        }

    }
}