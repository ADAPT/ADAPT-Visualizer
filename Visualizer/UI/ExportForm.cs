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
    public partial class ExportForm : Form
    {
        private readonly Model _model;
        private readonly string _propsFilter;
        private bool _isDirty;

        public ExportForm(Model model, string propsFilter)
        {
            InitializeComponent();

            _model = model;

            _propsFilter = propsFilter;

            if (_model.AvailablePlugins().Any())
                _loadedPluginsListBox.DataSource = _model.AvailablePlugins();

            string lastProfile = Settings.Default.ExportProfile;
            foreach (var applicationDataModel in _model.ApplicationDataModels.OrderBy(x => x.Catalog.Description))
            {
                cardProfileSelection.Items.Add(applicationDataModel.Catalog.Description);
                if ((!string.IsNullOrEmpty(lastProfile)) && (applicationDataModel.Catalog.Description.Equals(lastProfile, StringComparison.CurrentCultureIgnoreCase)))
                {
                    cardProfileSelection.SelectedIndex = cardProfileSelection.Items.Count - 1;
                }
            }
            if ((cardProfileSelection.Items.Count > 0) && (cardProfileSelection.SelectedIndex < 0))
            {
                cardProfileSelection.SelectedIndex = 0;
            }
        }

        private void BrowsePluginLocation_Click(object sender, EventArgs e)
        {
            Model.BrowseFolderDialog(this, _pluginPathTextBox, _labelPluginLocation.Text);
        }

        private void BrowseExportPath_Click(object sender, EventArgs e)
        {
            Model.BrowseFolderDialog(this, _exportPathTextBox, _pathLabel.Text);
        }

        private void _loadPluginsButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            _loadedPluginsListBox.DataSource = _model.LoadPlugins(_pluginPathTextBox);

            Cursor.Current = Cursors.Default;
        }

        private void _exportDatacardButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            ApplicationDataModel.ADM.Properties properties = new ApplicationDataModel.ADM.Properties();
            foreach (DataGridViewRow row in _proprietaryDataGridView.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[1].Value != null)
                {
                    properties.SetProperty(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());
                }
            }

            _model.Export(((KeyValuePair<string, string>)_loadedPluginsListBox.SelectedItem).Key,
                           _initializeStringTextBox.Text,
                           _exportPathTextBox.Text,
                           cardProfileSelection.SelectedItem.ToString(),
                           properties);

            Cursor.Current = Cursors.Default;

            DialogResult = DialogResult.OK;
        }

        private void _cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void ExportForm_Load(object sender, EventArgs e)
        {
            _pluginPathTextBox.Text = Settings.Default.PluginPath;
            _initializeStringTextBox.Text = Settings.Default.InitializeString;
            _exportPathTextBox.Text = Settings.Default.ExportPath;

            _proprietaryDataGridView.LoadFromCollection(Settings.Default.ExportProperties);

            if (Settings.Default.AutoLoadPlugins)
            {   // Issue a click
                _loadPluginsButton_Click(null, null);
            }
            // Try to select the last plugin used
            string lastPlugin = Settings.Default.ExportPlugin;
            int i = _loadedPluginsListBox.FindStringExact(lastPlugin);
            if (i >= 0) _loadedPluginsListBox.SelectedIndex = i;
        }

        private void ExportForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isDirty)
            {
                _proprietaryDataGridView.PersistToCollection(Settings.Default.ExportProperties);
            }

            Settings.Default.PluginPath = _pluginPathTextBox.Text;
            Settings.Default.InitializeString = _initializeStringTextBox.Text;
            Settings.Default.ExportPlugin = _loadedPluginsListBox.Text;
            Settings.Default.ExportPath = _exportPathTextBox.Text;
            Settings.Default.ExportProfile = cardProfileSelection.Text;
            Settings.Default.Save();
        }

        private void _proprietaryDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            _isDirty = true;
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
