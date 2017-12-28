using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
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

        public ImportForm(Model model, TreeView treeView, DataGridView dataGridViewRawData)
        {
            InitializeComponent();

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

                if (_model.Import(_importPathTextbox, _initializeStringTextBox.Text, _treeView))
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
            
            _proprietaryDataGridView.Rows.Clear();

            if (Settings.Default.AutoLoadPlugins)
            {   // Issue a click
                _loadPluginsButton_Click(null, null);
            }

            //TODO: where do these values come from
//            foreach (var kvp in Settings.Default.ProprietaryValues)
//            {
//                var strings = kvp.Split(';');
//
//                var dataGridViewRow = new DataGridViewRow();
//                dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell{Value = strings[0]});
//                dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell{Value = strings[1]});
//
//                _proprietaryDataGridView.Rows.Add(dataGridViewRow);
//            }
        }

        private void ImportForm_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
