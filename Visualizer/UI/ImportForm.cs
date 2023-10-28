/* Copyright (C) 2015-16 AgGateway and ADAPT Contributors
  * Copyright (C) 2015-16 Deere and Company
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    ? - initial implementation
  *    Andrew Vardeman - Added support for loading and saving properties
  *******************************************************************************/
using AgGateway.ADAPT.Visualizer.Properties;

namespace AgGateway.ADAPT.Visualizer.UI
{
    public partial class ImportForm : Form
    {
        private readonly Model _model;
        private readonly TreeView _treeView;
        private readonly DataGridView _dataGridViewRawData;
        private bool _isDirty;
        private AutoCompleteStringCollection _importPathHistory;
        private readonly string _propsFilter;

        public ImportForm(Model model, TreeView treeView, DataGridView dataGridViewRawData, string propsFilter)
        {
            InitializeComponent();
            _propsFilter = propsFilter;

            _model = model;
            _treeView = treeView;
            _dataGridViewRawData = dataGridViewRawData;

            if (_model.AvailablePlugins().Any())
                _loadedPluginsListBox.DataSource = _model.AvailablePlugins();
        }

        private void BrowsePluginLocation_Click(object sender, EventArgs e)
        {
            Model.BrowseFolderDialog(this, _pluginPathTextBox, _pluginLocationLabel.Text);
        }

        private void BrowseDataCardPath_Click(object sender, EventArgs e)
        {
            Model.BrowseFolderDialog(this, _importPathTextbox, _dataCardLabel.Text);
        }

        private void _importButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (_model.ArePluginsLoaded(_pluginPathTextBox))
            {
                _treeView.Nodes.Clear();
                _dataGridViewRawData.Columns.Clear();

                ApplicationDataModel.ADM.Properties properties = new ApplicationDataModel.ADM.Properties();
                foreach (DataGridViewRow row in _proprietaryDataGridView.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[1].Value != null)
                    {
                        properties.SetProperty(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());
                    }
                }

                if (_model.Import(_importPathTextbox, _initializeStringTextBox.Text, _treeView, properties))
                {
                    // Content of _importPathComboBox was valid --> add to history.
                    string s = _importPathTextbox.Text;
                    if (_importPathHistory == null) _importPathHistory = new AutoCompleteStringCollection();
                    if (!_importPathHistory.Contains(s)) _importPathHistory.Add(s);
                }

                DialogResult = DialogResult.OK;
            }

            Cursor.Current = Cursors.Default;
        }

        private void _loadPluginsButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            _loadedPluginsListBox.DataSource = _model.LoadPlugins(_pluginPathTextBox);

            Cursor.Current = Cursors.Default;
        }

        private void _cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void ImportForm_Load(object sender, EventArgs e)
        {
            _pluginPathTextBox.Text = Settings.Default.PluginPath;
            _initializeStringTextBox.Text = Settings.Default.InitializeString;
            _importPathTextbox.Text = Settings.Default.ImportPath;
            _importPathTextbox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            _importPathTextbox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            _importPathHistory = Settings.Default.ImportPathHistory;
            _importPathTextbox.AutoCompleteCustomSource = _importPathHistory;

            _proprietaryDataGridView.LoadFromCollection(Settings.Default.ImportProperties);

            if (Settings.Default.AutoLoadPlugins)
            {   // Issue a click
                _loadPluginsButton_Click(null, null);
            }
        }

        private void ImportForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isDirty)
            {
                _proprietaryDataGridView.PersistToCollection(Settings.Default.ImportProperties);
            }

            Settings.Default.PluginPath = _pluginPathTextBox.Text;
            Settings.Default.InitializeString = _initializeStringTextBox.Text;
            Settings.Default.ImportPath = _importPathTextbox.Text;
            Settings.Default.ImportPathHistory = _importPathHistory;
            Settings.Default.Save();
        }

        private void _proprietaryDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            _isDirty = true;
        }

        private void _validateDataButton_Click(object sender, EventArgs e)
        {
            _model.ValidateDataOnCard(_importPathTextbox, _initializeStringTextBox.Text, this);
        }

        private void _loadPropertiesButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = _propsFilter;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _proprietaryDataGridView.LoadFromFile(ofd.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, $"Error loading properties: {ex.Message}");
                }
            }
        }

        private void _savePropertiesButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = _propsFilter;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _proprietaryDataGridView.PersistToFile(sfd.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, $"Error saving properties: {ex.Message}");
                }
            }
        }
    }
}
