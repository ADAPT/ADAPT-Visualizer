namespace AgGateway.ADAPT.Visualizer.UI
{
    partial class ExportForm
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
            _proprietaryDataGridView = new DataGridView();
            _keyColumn = new DataGridViewTextBoxColumn();
            _valueColumn = new DataGridViewTextBoxColumn();
            _proprietaryLabel = new Label();
            _initializeStringTextBox = new TextBox();
            _loadedPluginsListBox = new ListBox();
            _labelPluginLocation = new Label();
            _loadedPluginsLabel = new Label();
            _browsePluginLocationButton = new Button();
            _loadPluginsButton = new Button();
            _initializeStringLabel = new Label();
            _pluginPathTextBox = new TextBox();
            _exportGroupBox = new GroupBox();
            label1 = new Label();
            cardProfileSelection = new ComboBox();
            _cancelButton = new Button();
            _exportDatacardButton = new Button();
            _browseExportPathButton = new Button();
            _exportPathTextBox = new TextBox();
            _pathLabel = new Label();
            _savePropertiesButton = new Button();
            _loadPropertiesButton = new Button();
            _preferencesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_proprietaryDataGridView).BeginInit();
            _exportGroupBox.SuspendLayout();
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
            _preferencesGroupBox.Controls.Add(_labelPluginLocation);
            _preferencesGroupBox.Controls.Add(_loadedPluginsLabel);
            _preferencesGroupBox.Controls.Add(_browsePluginLocationButton);
            _preferencesGroupBox.Controls.Add(_loadPluginsButton);
            _preferencesGroupBox.Controls.Add(_initializeStringLabel);
            _preferencesGroupBox.Controls.Add(_pluginPathTextBox);
            _preferencesGroupBox.Location = new Point(16, 6);
            _preferencesGroupBox.Margin = new Padding(4, 5, 4, 5);
            _preferencesGroupBox.Name = "_preferencesGroupBox";
            _preferencesGroupBox.Padding = new Padding(4, 5, 4, 5);
            _preferencesGroupBox.Size = new Size(613, 465);
            _preferencesGroupBox.TabIndex = 0;
            _preferencesGroupBox.TabStop = false;
            _preferencesGroupBox.Text = "Preferences";
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
            _proprietaryDataGridView.TabIndex = 9;
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
            _proprietaryLabel.Size = new Size(104, 42);
            _proprietaryLabel.TabIndex = 8;
            _proprietaryLabel.Text = "Export Properties";
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
            _loadedPluginsListBox.Size = new Size(479, 104);
            _loadedPluginsListBox.TabIndex = 7;
            // 
            // _labelPluginLocation
            // 
            _labelPluginLocation.AutoSize = true;
            _labelPluginLocation.Location = new Point(13, 100);
            _labelPluginLocation.Margin = new Padding(4, 0, 4, 0);
            _labelPluginLocation.Name = "_labelPluginLocation";
            _labelPluginLocation.Size = new Size(108, 20);
            _labelPluginLocation.TabIndex = 2;
            _labelPluginLocation.Text = "&Plugin location";
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
            // _exportGroupBox
            // 
            _exportGroupBox.Controls.Add(label1);
            _exportGroupBox.Controls.Add(cardProfileSelection);
            _exportGroupBox.Controls.Add(_cancelButton);
            _exportGroupBox.Controls.Add(_exportDatacardButton);
            _exportGroupBox.Controls.Add(_browseExportPathButton);
            _exportGroupBox.Controls.Add(_exportPathTextBox);
            _exportGroupBox.Controls.Add(_pathLabel);
            _exportGroupBox.Location = new Point(16, 480);
            _exportGroupBox.Margin = new Padding(4, 5, 4, 5);
            _exportGroupBox.Name = "_exportGroupBox";
            _exportGroupBox.Padding = new Padding(4, 5, 4, 5);
            _exportGroupBox.Size = new Size(613, 175);
            _exportGroupBox.TabIndex = 1;
            _exportGroupBox.TabStop = false;
            _exportGroupBox.Text = "Export";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 78);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(87, 20);
            label1.TabIndex = 3;
            label1.Text = "&Card Profile";
            // 
            // cardProfileSelection
            // 
            cardProfileSelection.DropDownStyle = ComboBoxStyle.DropDownList;
            cardProfileSelection.FormattingEnabled = true;
            cardProfileSelection.Location = new Point(125, 74);
            cardProfileSelection.Margin = new Padding(4, 5, 4, 5);
            cardProfileSelection.Name = "cardProfileSelection";
            cardProfileSelection.Size = new Size(388, 28);
            cardProfileSelection.TabIndex = 4;
            // 
            // _cancelButton
            // 
            _cancelButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cancelButton.DialogResult = DialogResult.Cancel;
            _cancelButton.Location = new Point(443, 115);
            _cancelButton.Margin = new Padding(4, 5, 4, 5);
            _cancelButton.Name = "_cancelButton";
            _cancelButton.Size = new Size(72, 35);
            _cancelButton.TabIndex = 5;
            _cancelButton.Text = "Cancel";
            _cancelButton.UseVisualStyleBackColor = true;
            _cancelButton.Click += _cancelButton_Click;
            // 
            // _exportDatacardButton
            // 
            _exportDatacardButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _exportDatacardButton.Location = new Point(523, 115);
            _exportDatacardButton.Margin = new Padding(4, 5, 4, 5);
            _exportDatacardButton.Name = "_exportDatacardButton";
            _exportDatacardButton.Size = new Size(72, 35);
            _exportDatacardButton.TabIndex = 6;
            _exportDatacardButton.Text = "Export";
            _exportDatacardButton.UseVisualStyleBackColor = true;
            _exportDatacardButton.Click += _exportDatacardButton_Click;
            // 
            // _browseExportPathButton
            // 
            _browseExportPathButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _browseExportPathButton.Location = new Point(523, 32);
            _browseExportPathButton.Margin = new Padding(4, 5, 4, 5);
            _browseExportPathButton.Name = "_browseExportPathButton";
            _browseExportPathButton.Size = new Size(72, 35);
            _browseExportPathButton.TabIndex = 2;
            _browseExportPathButton.Text = "Br&owse";
            _browseExportPathButton.UseVisualStyleBackColor = true;
            _browseExportPathButton.Click += BrowseExportPath_Click;
            // 
            // _exportPathTextBox
            // 
            _exportPathTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _exportPathTextBox.Location = new Point(125, 34);
            _exportPathTextBox.Margin = new Padding(4, 5, 4, 5);
            _exportPathTextBox.Name = "_exportPathTextBox";
            _exportPathTextBox.Size = new Size(388, 27);
            _exportPathTextBox.TabIndex = 1;
            // 
            // _pathLabel
            // 
            _pathLabel.AutoSize = true;
            _pathLabel.Location = new Point(35, 38);
            _pathLabel.Margin = new Padding(4, 0, 4, 0);
            _pathLabel.Name = "_pathLabel";
            _pathLabel.Size = new Size(84, 20);
            _pathLabel.TabIndex = 0;
            _pathLabel.Text = "&Export Path";
            // 
            // _savePropertiesButton
            // 
            _savePropertiesButton.Location = new Point(13, 380);
            _savePropertiesButton.Name = "_savePropertiesButton";
            _savePropertiesButton.Size = new Size(92, 54);
            _savePropertiesButton.TabIndex = 14;
            _savePropertiesButton.Text = "Save to File";
            _savePropertiesButton.UseVisualStyleBackColor = true;
            _savePropertiesButton.Click += _savePropertiesButton_Click;
            // 
            // _loadPropertiesButton
            // 
            _loadPropertiesButton.Location = new Point(13, 320);
            _loadPropertiesButton.Name = "_loadPropertiesButton";
            _loadPropertiesButton.Size = new Size(92, 54);
            _loadPropertiesButton.TabIndex = 13;
            _loadPropertiesButton.Text = "Load from File";
            _loadPropertiesButton.UseVisualStyleBackColor = true;
            _loadPropertiesButton.Click += _loadPropertiesButton_Click;
            // 
            // ExportForm
            // 
            AcceptButton = _exportDatacardButton;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = _cancelButton;
            ClientSize = new Size(645, 674);
            Controls.Add(_exportGroupBox);
            Controls.Add(_preferencesGroupBox);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ExportForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Export";
            FormClosing += ExportForm_FormClosing;
            Load += ExportForm_Load;
            _preferencesGroupBox.ResumeLayout(false);
            _preferencesGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_proprietaryDataGridView).EndInit();
            _exportGroupBox.ResumeLayout(false);
            _exportGroupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox _preferencesGroupBox;
        private TextBox _initializeStringTextBox;
        private ListBox _loadedPluginsListBox;
        private Label _labelPluginLocation;
        private Label _loadedPluginsLabel;
        private Button _browsePluginLocationButton;
        private Button _loadPluginsButton;
        private Label _initializeStringLabel;
        private TextBox _pluginPathTextBox;
        private Label _proprietaryLabel;
        private GroupBox _exportGroupBox;
        private Button _exportDatacardButton;
        private Button _browseExportPathButton;
        private TextBox _exportPathTextBox;
        private Label _pathLabel;
        private Button _cancelButton;
        private DataGridView _proprietaryDataGridView;
        private DataGridViewTextBoxColumn _keyColumn;
        private DataGridViewTextBoxColumn _valueColumn;
        private Label label1;
        private ComboBox cardProfileSelection;
        private Button _savePropertiesButton;
        private Button _loadPropertiesButton;
    }
}