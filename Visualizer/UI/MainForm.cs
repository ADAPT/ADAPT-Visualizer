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
            ProcessData(treeNode);
            Cursor.Current = Cursors.Default;
        }

        private void _tabPageSpatial_Paint(object sender, PaintEventArgs e)
        {
            if (_tabPageSpatial.Tag == null)
            {
                return;
            }

            ProcessData(_tabPageSpatial.Tag as TreeNode);
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
            var saveFileDialog = new SaveFileDialog
            {
                DefaultExt = ".csv", 
                Filter = @"CSV File (.csv)|*.csv"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                _model.WriteCsvFile(saveFileDialog.FileName, _dataGridViewRawData);
            }
        }

        private void ProcessData(TreeNode treeNode)
        {
            var objectWithIndex = (ObjectWithIndex)treeNode.Tag;
            var element = objectWithIndex.Element;

            workingDataComboBox.Visible = false;
            if (element is FieldBoundary)
            {
                _boundaryProcessor.ProcessBoundary(element as FieldBoundary);
                _tabControlViewer.SelectedTab = _tabPageSpatial;
            }
            else if (element is GuidanceGroup)
            {
                _guidanceProcessor.ProcessGuidance(element as GuidanceGroup, _model.ApplicationDataModels[objectWithIndex.ApplicationDataModelIndex].Catalog.GuidancePatterns);
                _tabControlViewer.SelectedTab = _tabPageSpatial;
            }
            else if (element is GuidancePattern)
            {
                _guidanceProcessor.ProccessGuidancePattern(element as GuidancePattern);
                _tabControlViewer.SelectedTab = _tabPageSpatial;
            }
            else if (element is OperationData)
            {
                OperationData operation = element as OperationData;
                List<SpatialRecord> spatialRecords = new List<SpatialRecord>();
                if (operation.GetSpatialRecords != null)
                {
                    spatialRecords = operation.GetSpatialRecords().ToList(); //Iterate the records once here for multiple consumers below
                }
                _dataGridViewRawData.DataSource = _operationDataProcessor.ProcessOperationData(operation, spatialRecords);
                ApplicationDataModel.ADM.ApplicationDataModel model = _model.ApplicationDataModels[objectWithIndex.ApplicationDataModelIndex];
                _spatialRecordProcessor.ProcessOperation(operation, spatialRecords, _model.ApplicationDataModels[objectWithIndex.ApplicationDataModelIndex].Catalog);
                workingDataComboBox.Visible = true;
                workingDataComboBox.DataSource = _spatialRecordProcessor.WorkingDataList;
            }
            else if (element is Prescription)
            {
                _prescriptionProcessor.ProcessPrescription(element as Prescription);
            }
        }

        private void MainForm_LocationChanged(object sender, EventArgs e)
        {
            ResizeBusyForm();
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            ResizeBusyForm();
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
            string workingDataKey = (string)workingDataComboBox.SelectedItem;
            _spatialRecordProcessor.ThemeMap(workingDataKey);
        }

        private void _dataGridViewRawData_Paint(object sender, PaintEventArgs e)
        {
            workingDataComboBox.Visible = false;
        }
    }
}