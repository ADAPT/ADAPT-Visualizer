namespace AgGateway.ADAPT.Visualizer.UI
{
    partial class ImportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            _preferencesGroupBox = new GroupBox();
            _savePropertiesButton = new Button();
            _loadPropertiesButton = new Button();
            _proprietaryDataGridView = new DataGridView();
            _keyColumn = new DataGridViewTextBoxColumn();
            _valueColumn = new DataGridViewTextBoxColumn();
            _proprietaryLabel = new Label();
            _initializeStringTextBox = new TextBox();
            _loadedPluginsListBox = new ListBox();
            _pluginLocationLabel = new Label();
            _loadedPluginsLabel = new Label();
            _browsePluginLocationButton = new Button();
            _loadPluginsButton = new Button();
            _initializeStringLabel = new Label();
            _pluginPathTextBox = new TextBox();
            _importGroupBox = new GroupBox();
            _validateDataButton = new Button();
            _cancelButton = new Button();
            _importButton = new Button();
            _browseDatacardButton = new Button();
            _importPathTextbox = new TextBox();
            _dataCardLabel = new Label();
            _preferencesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_proprietaryDataGridView).BeginInit();
            _importGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // _preferencesGroupBox
            // 
            _preferencesGroupBox.Controls.Add(_savePropertiesButton);
            _preferencesGroupBox.Controls.Add(_loadPropertiesButton);
            _preferencesGroupBox.Controls.Add(_proprietaryDataGridView);
            _preferencesGroupBox.Controls.Add(_proprietaryLabel);
            _preferencesGroupBox.Controls.Add(_initializeStringTextBox);
            _preferencesGroupBox.Controls.Add(_loadedPluginsListBox);
            _preferencesGroupBox.Controls.Add(_pluginLocationLabel);
            _preferencesGroupBox.Controls.Add(_loadedPluginsLabel);
            _preferencesGroupBox.Controls.Add(_browsePluginLocationButton);
            _preferencesGroupBox.Controls.Add(_loadPluginsButton);
            _preferencesGroupBox.Controls.Add(_initializeStringLabel);
            _preferencesGroupBox.Controls.Add(_pluginPathTextBox);
            _preferencesGroupBox.Location = new Point(16, 3);
            _preferencesGroupBox.Margin = new Padding(4, 5, 4, 5);
            _preferencesGroupBox.Name = "_preferencesGroupBox";
            _preferencesGroupBox.Padding = new Padding(4, 5, 4, 5);
            _preferencesGroupBox.Size = new Size(613, 465);
            _preferencesGroupBox.TabIndex = 0;
            _preferencesGroupBox.TabStop = false;
            _preferencesGroupBox.Text = "Preferences";
            // 
            // _savePropertiesButton
            // 
            _savePropertiesButton.Location = new Point(13, 380);
            _savePropertiesButton.Name = "_savePropertiesButton";
            _savePropertiesButton.Size = new Size(92, 54);
            _savePropertiesButton.TabIndex = 12;
            _savePropertiesButton.Text = "Save to File";
            _savePropertiesButton.UseVisualStyleBackColor = true;
            _savePropertiesButton.Click += _savePropertiesButton_Click;
            // 
            // _loadPropertiesButton
            // 
            _loadPropertiesButton.Location = new Point(13, 320);
            _loadPropertiesButton.Name = "_loadPropertiesButton";
            _loadPropertiesButton.Size = new Size(92, 54);
            _loadPropertiesButton.TabIndex = 11;
            _loadPropertiesButton.Text = "Load from File";
            _loadPropertiesButton.UseVisualStyleBackColor = true;
            _loadPropertiesButton.Click += _loadPropertiesButton_Click;
            // 
            // _proprietaryDataGridView
            // 
            _proprietaryDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _proprietaryDataGridView.Columns.AddRange(new DataGridViewColumn[] { _keyColumn, _valueColumn });
            _proprietaryDataGridView.Location = new Point(120, 275);
            _proprietaryDataGridView.Margin = new Padding(4, 5, 4, 5);
            _proprietaryDataGridView.Name = "_proprietaryDataGridView";
            _proprietaryDataGridView.RowHeadersWidth = 51;
            _proprietaryDataGridView.Size = new Size(480, 180);
            _proprietaryDataGridView.TabIndex = 10;
            _proprietaryDataGridView.CellEndEdit += _proprietaryDataGridView_CellEndEdit;
            // 
            // _keyColumn
            // 
            _keyColumn.HeaderText = "Key";
            _keyColumn.MinimumWidth = 6;
            _keyColumn.Name = "_keyColumn";
            _keyColumn.Width = 125;
            // 
            // _valueColumn
            // 
            _valueColumn.HeaderText = "Value";
            _valueColumn.MinimumWidth = 6;
            _valueColumn.Name = "_valueColumn";
            _valueColumn.Width = 200;
            // 
            // _proprietaryLabel
            // 
            _proprietaryLabel.AutoEllipsis = true;
            _proprietaryLabel.Location = new Point(13, 275);
            _proprietaryLabel.Margin = new Padding(4, 0, 4, 0);
            _proprietaryLabel.Name = "_proprietaryLabel";
            _proprietaryLabel.Size = new Size(77, 42);
            _proprietaryLabel.TabIndex = 8;
            _proprietaryLabel.Text = "Import Properties";
            // 
            // _initializeStringTextBox
            // 
            _initializeStringTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _initializeStringTextBox.Location = new Point(120, 30);
            _initializeStringTextBox.Margin = new Padding(4, 5, 4, 5);
            _initializeStringTextBox.Name = "_initializeStringTextBox";
            _initializeStringTextBox.Size = new Size(479, 27);
            _initializeStringTextBox.TabIndex = 1;
            // 
            // _loadedPluginsListBox
            // 
            _loadedPluginsListBox.FormattingEnabled = true;
            _loadedPluginsListBox.ItemHeight = 20;
            _loadedPluginsListBox.Location = new Point(120, 158);
            _loadedPluginsListBox.Margin = new Padding(4, 5, 4, 5);
            _loadedPluginsListBox.MultiColumn = true;
            _loadedPluginsListBox.Name = "_loadedPluginsListBox";
            _loadedPluginsListBox.SelectionMode = SelectionMode.None;
            _loadedPluginsListBox.Size = new Size(479, 104);
            _loadedPluginsListBox.TabIndex = 7;
            // 
            // _pluginLocationLabel
            // 
            _pluginLocationLabel.AutoSize = true;
            _pluginLocationLabel.Location = new Point(13, 100);
            _pluginLocationLabel.Margin = new Padding(4, 0, 4, 0);
            _pluginLocationLabel.Name = "_pluginLocationLabel";
            _pluginLocationLabel.Size = new Size(108, 20);
            _pluginLocationLabel.TabIndex = 2;
            _pluginLocationLabel.Text = "&Plugin location";
            // 
            // _loadedPluginsLabel
            // 
            _loadedPluginsLabel.AutoSize = true;
            _loadedPluginsLabel.Location = new Point(13, 158);
            _loadedPluginsLabel.Margin = new Padding(4, 0, 4, 0);
            _loadedPluginsLabel.Name = "_loadedPluginsLabel";
            _loadedPluginsLabel.Size = new Size(111, 20);
            _loadedPluginsLabel.TabIndex = 6;
            _loadedPluginsLabel.Text = "Loaded plugins";
            // 
            // _browsePluginLocationButton
            // 
            _browsePluginLocationButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _browsePluginLocationButton.Location = new Point(409, 92);
            _browsePluginLocationButton.Margin = new Padding(4, 5, 4, 5);
            _browsePluginLocationButton.Name = "_browsePluginLocationButton";
            _browsePluginLocationButton.Size = new Size(72, 35);
            _browsePluginLocationButton.TabIndex = 4;
            _browsePluginLocationButton.Text = "&Browse";
            _browsePluginLocationButton.UseVisualStyleBackColor = true;
            _browsePluginLocationButton.Click += BrowsePluginLocation_Click;
            // 
            // _loadPluginsButton
            // 
            _loadPluginsButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _loadPluginsButton.Location = new Point(489, 92);
            _loadPluginsButton.Margin = new Padding(4, 5, 4, 5);
            _loadPluginsButton.Name = "_loadPluginsButton";
            _loadPluginsButton.Size = new Size(105, 35);
            _loadPluginsButton.TabIndex = 5;
            _loadPluginsButton.Text = "&Load Plugins";
            _loadPluginsButton.UseVisualStyleBackColor = true;
            _loadPluginsButton.Click += _loadPluginsButton_Click;
            // 
            // _initializeStringLabel
            // 
            _initializeStringLabel.AccessibleDescription = "";
            _initializeStringLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _initializeStringLabel.AutoSize = true;
            _initializeStringLabel.Location = new Point(13, 34);
            _initializeStringLabel.Margin = new Padding(4, 0, 4, 0);
            _initializeStringLabel.Name = "_initializeStringLabel";
            _initializeStringLabel.Size = new Size(108, 20);
            _initializeStringLabel.TabIndex = 0;
            _initializeStringLabel.Text = "&Initialize String";
            // 
            // _pluginPathTextBox
            // 
            _pluginPathTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _pluginPathTextBox.Location = new Point(120, 94);
            _pluginPathTextBox.Margin = new Padding(4, 5, 4, 5);
            _pluginPathTextBox.Name = "_pluginPathTextBox";
            _pluginPathTextBox.Size = new Size(280, 27);
            _pluginPathTextBox.TabIndex = 3;
            // 
            // _importGroupBox
            // 
            _importGroupBox.Controls.Add(_validateDataButton);
            _importGroupBox.Controls.Add(_cancelButton);
            _importGroupBox.Controls.Add(_importButton);
            _importGroupBox.Controls.Add(_browseDatacardButton);
            _importGroupBox.Controls.Add(_importPathTextbox);
            _importGroupBox.Controls.Add(_dataCardLabel);
            _importGroupBox.Location = new Point(16, 477);
            _importGroupBox.Margin = new Padding(4, 5, 4, 5);
            _importGroupBox.Name = "_importGroupBox";
            _importGroupBox.Padding = new Padding(4, 5, 4, 5);
            _importGroupBox.Size = new Size(613, 159);
            _importGroupBox.TabIndex = 1;
            _importGroupBox.TabStop = false;
            _importGroupBox.Text = "Import";
            // 
            // _validateDataButton
            // 
            _validateDataButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _validateDataButton.DialogResult = DialogResult.Cancel;
            _validateDataButton.Location = new Point(443, 74);
            _validateDataButton.Margin = new Padding(4, 5, 4, 5);
            _validateDataButton.Name = "_validateDataButton";
            _validateDataButton.Size = new Size(152, 35);
            _validateDataButton.TabIndex = 5;
            _validateDataButton.Text = "Validate Data";
            _validateDataButton.UseVisualStyleBackColor = true;
            _validateDataButton.Click += _validateDataButton_Click;
            // 
            // _cancelButton
            // 
            _cancelButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cancelButton.DialogResult = DialogResult.Cancel;
            _cancelButton.Location = new Point(443, 119);
            _cancelButton.Margin = new Padding(4, 5, 4, 5);
            _cancelButton.Name = "_cancelButton";
            _cancelButton.Size = new Size(72, 35);
            _cancelButton.TabIndex = 4;
            _cancelButton.Text = "Cancel";
            _cancelButton.UseVisualStyleBackColor = true;
            _cancelButton.Click += _cancelButton_Click;
            // 
            // _importButton
            // 
            _importButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _importButton.Location = new Point(523, 119);
            _importButton.Margin = new Padding(4, 5, 4, 5);
            _importButton.Name = "_importButton";
            _importButton.Size = new Size(72, 35);
            _importButton.TabIndex = 3;
            _importButton.Text = "Import";
            _importButton.UseVisualStyleBackColor = true;
            _importButton.Click += _importButton_Click;
            // 
            // _browseDatacardButton
            // 
            _browseDatacardButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _browseDatacardButton.Location = new Point(523, 30);
            _browseDatacardButton.Margin = new Padding(4, 5, 4, 5);
            _browseDatacardButton.Name = "_browseDatacardButton";
            _browseDatacardButton.Size = new Size(72, 35);
            _browseDatacardButton.TabIndex = 2;
            _browseDatacardButton.Text = "Br&owse";
            _browseDatacardButton.UseVisualStyleBackColor = true;
            _browseDatacardButton.Click += BrowseDataCardPath_Click;
            // 
            // _importPathTextbox
            // 
            _importPathTextbox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _importPathTextbox.Location = new Point(120, 32);
            _importPathTextbox.Margin = new Padding(4, 5, 4, 5);
            _importPathTextbox.Name = "_importPathTextbox";
            _importPathTextbox.Size = new Size(393, 27);
            _importPathTextbox.TabIndex = 1;
            // 
            // _dataCardLabel
            // 
            _dataCardLabel.AutoSize = true;
            _dataCardLabel.Location = new Point(13, 37);
            _dataCardLabel.Margin = new Padding(4, 0, 4, 0);
            _dataCardLabel.Name = "_dataCardLabel";
            _dataCardLabel.Size = new Size(102, 20);
            _dataCardLabel.TabIndex = 0;
            _dataCardLabel.Text = "&Datacard Path";
            // 
            // ImportForm
            // 
            AcceptButton = _importButton;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = _cancelButton;
            ClientSize = new Size(645, 656);
            Controls.Add(_importGroupBox);
            Controls.Add(_preferencesGroupBox);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ImportForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Import";
            FormClosing += ImportForm_FormClosing;
            Load += ImportForm_Load;
            _preferencesGroupBox.ResumeLayout(false);
            _preferencesGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_proprietaryDataGridView).EndInit();
            _importGroupBox.ResumeLayout(false);
            _importGroupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox _preferencesGroupBox;
        private Label _proprietaryLabel;
        private TextBox _initializeStringTextBox;
        private ListBox _loadedPluginsListBox;
        private Label _pluginLocationLabel;
        private Label _loadedPluginsLabel;
        private Button _browsePluginLocationButton;
        private Button _loadPluginsButton;
        private Label _initializeStringLabel;
        private TextBox _pluginPathTextBox;
        private GroupBox _importGroupBox;
        private Label _dataCardLabel;
        private TextBox _importPathTextbox;
        private Button _browseDatacardButton;
        private Button _importButton;
        private Button _cancelButton;
        private DataGridView _proprietaryDataGridView;
        private DataGridViewTextBoxColumn _keyColumn;
        private DataGridViewTextBoxColumn _valueColumn;
        private Button _validateDataButton;
        private Button _savePropertiesButton;
        private Button _loadPropertiesButton;
    }
}