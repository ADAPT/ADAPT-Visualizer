using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AgGateway.ADAPT.Visualizer.Properties;

namespace AgGateway.ADAPT.Visualizer.UI
{
    public partial class ExportForm : Form
    {
        private readonly Model _model;
        private bool _isDirty;  

        public ExportForm(Model model)
        {
            InitializeComponent();

            _model = model;

            if (_model.AvailablePlugins().Any())
                _loadedPluginsListBox.DataSource = _model.AvailablePlugins();

            string lastProfile = Settings.Default.ExportProfile;
            foreach (var applicationDataModel in _model.ApplicationDataModels.OrderBy(x => x.Catalog.Description))
            {
                cardProfileSelection.Items.Add(applicationDataModel.Catalog.Description);
                if ((!string.IsNullOrEmpty(lastProfile)) && (applicationDataModel.Catalog.Description.Equals(lastProfile, StringComparison.CurrentCultureIgnoreCase))) {
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

            _proprietaryDataGridView.Rows.Clear();

            if (Settings.Default.AutoLoadPlugins)
            {   // Issue a click
                _loadPluginsButton_Click(null, null);
            }
        }

        private void ExportForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isDirty)
            {
                Settings.Default.ProprietaryValues.Clear();

                foreach (DataGridViewRow row in _proprietaryDataGridView.Rows)
                {
                    Settings.Default.ProprietaryValues.Add(string.Format("{0};{1}", row.Cells[0].Value, row.Cells[1].Value));
                }    
            }

            Settings.Default.PluginPath = _pluginPathTextBox.Text;
            Settings.Default.InitializeString = _initializeStringTextBox.Text;
            Settings.Default.ExportPath = _exportPathTextBox.Text;
            Settings.Default.ExportProfile = cardProfileSelection.Text; 
            Settings.Default.Save();
        }

        private void _proprietaryDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            _isDirty = true;
        }
    }
}
