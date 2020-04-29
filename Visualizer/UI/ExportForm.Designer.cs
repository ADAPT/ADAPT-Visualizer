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
            this._preferencesGroupBox = new System.Windows.Forms.GroupBox();
            this._proprietaryDataGridView = new System.Windows.Forms.DataGridView();
            this._keyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._valueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._proprietaryLabel = new System.Windows.Forms.Label();
            this._initializeStringTextBox = new System.Windows.Forms.TextBox();
            this._loadedPluginsListBox = new System.Windows.Forms.ListBox();
            this._labelPluginLocation = new System.Windows.Forms.Label();
            this._loadedPluginsLabel = new System.Windows.Forms.Label();
            this._browsePluginLocationButton = new System.Windows.Forms.Button();
            this._loadPluginsButton = new System.Windows.Forms.Button();
            this._initializeStringLabel = new System.Windows.Forms.Label();
            this._pluginPathTextBox = new System.Windows.Forms.TextBox();
            this._exportGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cardProfileSelection = new System.Windows.Forms.ComboBox();
            this._cancelButton = new System.Windows.Forms.Button();
            this._exportDatacardButton = new System.Windows.Forms.Button();
            this._browseExportPathButton = new System.Windows.Forms.Button();
            this._exportPathTextBox = new System.Windows.Forms.TextBox();
            this._pathLabel = new System.Windows.Forms.Label();
            this._preferencesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._proprietaryDataGridView)).BeginInit();
            this._exportGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // _preferencesGroupBox
            // 
            this._preferencesGroupBox.Controls.Add(this._proprietaryDataGridView);
            this._preferencesGroupBox.Controls.Add(this._proprietaryLabel);
            this._preferencesGroupBox.Controls.Add(this._initializeStringTextBox);
            this._preferencesGroupBox.Controls.Add(this._loadedPluginsListBox);
            this._preferencesGroupBox.Controls.Add(this._labelPluginLocation);
            this._preferencesGroupBox.Controls.Add(this._loadedPluginsLabel);
            this._preferencesGroupBox.Controls.Add(this._browsePluginLocationButton);
            this._preferencesGroupBox.Controls.Add(this._loadPluginsButton);
            this._preferencesGroupBox.Controls.Add(this._initializeStringLabel);
            this._preferencesGroupBox.Controls.Add(this._pluginPathTextBox);
            this._preferencesGroupBox.Location = new System.Drawing.Point(24, 8);
            this._preferencesGroupBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this._preferencesGroupBox.Name = "_preferencesGroupBox";
            this._preferencesGroupBox.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this._preferencesGroupBox.Size = new System.Drawing.Size(920, 581);
            this._preferencesGroupBox.TabIndex = 0;
            this._preferencesGroupBox.TabStop = false;
            this._preferencesGroupBox.Text = "Preferences";
            // 
            // _proprietaryDataGridView
            // 
            this._proprietaryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._proprietaryDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._keyColumn,
            this._valueColumn});
            this._proprietaryDataGridView.Location = new System.Drawing.Point(180, 344);
            this._proprietaryDataGridView.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this._proprietaryDataGridView.Name = "_proprietaryDataGridView";
            this._proprietaryDataGridView.Size = new System.Drawing.Size(720, 225);
            this._proprietaryDataGridView.TabIndex = 9;
            this._proprietaryDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this._proprietaryDataGridView_CellEndEdit);
            // 
            // _keyColumn
            // 
            this._keyColumn.HeaderText = "Key";
            this._keyColumn.Name = "_keyColumn";
            // 
            // _valueColumn
            // 
            this._valueColumn.HeaderText = "Value";
            this._valueColumn.Name = "_valueColumn";
            this._valueColumn.Width = 200;
            // 
            // _proprietaryLabel
            // 
            this._proprietaryLabel.AutoEllipsis = true;
            this._proprietaryLabel.Location = new System.Drawing.Point(20, 344);
            this._proprietaryLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this._proprietaryLabel.Name = "_proprietaryLabel";
            this._proprietaryLabel.Size = new System.Drawing.Size(156, 52);
            this._proprietaryLabel.TabIndex = 8;
            this._proprietaryLabel.Text = "Export Properties";
            // 
            // _initializeStringTextBox
            // 
            this._initializeStringTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._initializeStringTextBox.Location = new System.Drawing.Point(180, 37);
            this._initializeStringTextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this._initializeStringTextBox.Name = "_initializeStringTextBox";
            this._initializeStringTextBox.Size = new System.Drawing.Size(716, 31);
            this._initializeStringTextBox.TabIndex = 1;
            // 
            // _loadedPluginsListBox
            // 
            this._loadedPluginsListBox.FormattingEnabled = true;
            this._loadedPluginsListBox.ItemHeight = 25;
            this._loadedPluginsListBox.Location = new System.Drawing.Point(180, 198);
            this._loadedPluginsListBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this._loadedPluginsListBox.MultiColumn = true;
            this._loadedPluginsListBox.Name = "_loadedPluginsListBox";
            this._loadedPluginsListBox.Size = new System.Drawing.Size(716, 129);
            this._loadedPluginsListBox.TabIndex = 7;
            // 
            // _labelPluginLocation
            // 
            this._labelPluginLocation.AutoSize = true;
            this._labelPluginLocation.Location = new System.Drawing.Point(20, 125);
            this._labelPluginLocation.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this._labelPluginLocation.Name = "_labelPluginLocation";
            this._labelPluginLocation.Size = new System.Drawing.Size(153, 25);
            this._labelPluginLocation.TabIndex = 2;
            this._labelPluginLocation.Text = "&Plugin location";
            // 
            // _loadedPluginsLabel
            // 
            this._loadedPluginsLabel.AutoSize = true;
            this._loadedPluginsLabel.Location = new System.Drawing.Point(20, 198);
            this._loadedPluginsLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this._loadedPluginsLabel.Name = "_loadedPluginsLabel";
            this._loadedPluginsLabel.Size = new System.Drawing.Size(159, 25);
            this._loadedPluginsLabel.TabIndex = 6;
            this._loadedPluginsLabel.Text = "Loaded plugins";
            // 
            // _browsePluginLocationButton
            // 
            this._browsePluginLocationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._browsePluginLocationButton.Location = new System.Drawing.Point(614, 115);
            this._browsePluginLocationButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this._browsePluginLocationButton.Name = "_browsePluginLocationButton";
            this._browsePluginLocationButton.Size = new System.Drawing.Size(108, 44);
            this._browsePluginLocationButton.TabIndex = 4;
            this._browsePluginLocationButton.Text = "&Browse";
            this._browsePluginLocationButton.UseVisualStyleBackColor = true;
            this._browsePluginLocationButton.Click += new System.EventHandler(this.BrowsePluginLocation_Click);
            // 
            // _loadPluginsButton
            // 
            this._loadPluginsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._loadPluginsButton.Location = new System.Drawing.Point(734, 115);
            this._loadPluginsButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this._loadPluginsButton.Name = "_loadPluginsButton";
            this._loadPluginsButton.Size = new System.Drawing.Size(158, 44);
            this._loadPluginsButton.TabIndex = 5;
            this._loadPluginsButton.Text = "&Load Plugins";
            this._loadPluginsButton.UseVisualStyleBackColor = true;
            this._loadPluginsButton.Click += new System.EventHandler(this._loadPluginsButton_Click);
            // 
            // _initializeStringLabel
            // 
            this._initializeStringLabel.AccessibleDescription = "";
            this._initializeStringLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._initializeStringLabel.AutoSize = true;
            this._initializeStringLabel.Location = new System.Drawing.Point(20, 42);
            this._initializeStringLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this._initializeStringLabel.Name = "_initializeStringLabel";
            this._initializeStringLabel.Size = new System.Drawing.Size(152, 25);
            this._initializeStringLabel.TabIndex = 0;
            this._initializeStringLabel.Text = "&Initialize String";
            // 
            // _pluginPathTextBox
            // 
            this._pluginPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._pluginPathTextBox.Location = new System.Drawing.Point(180, 117);
            this._pluginPathTextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this._pluginPathTextBox.Name = "_pluginPathTextBox";
            this._pluginPathTextBox.Size = new System.Drawing.Size(418, 31);
            this._pluginPathTextBox.TabIndex = 3;
            // 
            // _exportGroupBox
            // 
            this._exportGroupBox.Controls.Add(this.label1);
            this._exportGroupBox.Controls.Add(this.cardProfileSelection);
            this._exportGroupBox.Controls.Add(this._cancelButton);
            this._exportGroupBox.Controls.Add(this._exportDatacardButton);
            this._exportGroupBox.Controls.Add(this._browseExportPathButton);
            this._exportGroupBox.Controls.Add(this._exportPathTextBox);
            this._exportGroupBox.Controls.Add(this._pathLabel);
            this._exportGroupBox.Location = new System.Drawing.Point(24, 600);
            this._exportGroupBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this._exportGroupBox.Name = "_exportGroupBox";
            this._exportGroupBox.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this._exportGroupBox.Size = new System.Drawing.Size(920, 219);
            this._exportGroupBox.TabIndex = 1;
            this._exportGroupBox.TabStop = false;
            this._exportGroupBox.Text = "Export";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 98);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "&Card Profile";
            // 
            // cardProfileSelection
            // 
            this.cardProfileSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cardProfileSelection.FormattingEnabled = true;
            this.cardProfileSelection.Location = new System.Drawing.Point(188, 92);
            this.cardProfileSelection.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cardProfileSelection.Name = "cardProfileSelection";
            this.cardProfileSelection.Size = new System.Drawing.Size(580, 33);
            this.cardProfileSelection.TabIndex = 4;
            // 
            // _cancelButton
            // 
            this._cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Location = new System.Drawing.Point(664, 144);
            this._cancelButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(108, 44);
            this._cancelButton.TabIndex = 5;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this._cancelButton_Click);
            // 
            // _exportDatacardButton
            // 
            this._exportDatacardButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._exportDatacardButton.Location = new System.Drawing.Point(784, 144);
            this._exportDatacardButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this._exportDatacardButton.Name = "_exportDatacardButton";
            this._exportDatacardButton.Size = new System.Drawing.Size(108, 44);
            this._exportDatacardButton.TabIndex = 6;
            this._exportDatacardButton.Text = "Export";
            this._exportDatacardButton.UseVisualStyleBackColor = true;
            this._exportDatacardButton.Click += new System.EventHandler(this._exportDatacardButton_Click);
            // 
            // _browseExportPathButton
            // 
            this._browseExportPathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._browseExportPathButton.Location = new System.Drawing.Point(784, 40);
            this._browseExportPathButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this._browseExportPathButton.Name = "_browseExportPathButton";
            this._browseExportPathButton.Size = new System.Drawing.Size(108, 44);
            this._browseExportPathButton.TabIndex = 2;
            this._browseExportPathButton.Text = "Br&owse";
            this._browseExportPathButton.UseVisualStyleBackColor = true;
            this._browseExportPathButton.Click += new System.EventHandler(this.BrowseExportPath_Click);
            // 
            // _exportPathTextBox
            // 
            this._exportPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._exportPathTextBox.Location = new System.Drawing.Point(188, 42);
            this._exportPathTextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this._exportPathTextBox.Name = "_exportPathTextBox";
            this._exportPathTextBox.Size = new System.Drawing.Size(580, 31);
            this._exportPathTextBox.TabIndex = 1;
            // 
            // _pathLabel
            // 
            this._pathLabel.AutoSize = true;
            this._pathLabel.Location = new System.Drawing.Point(52, 48);
            this._pathLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this._pathLabel.Name = "_pathLabel";
            this._pathLabel.Size = new System.Drawing.Size(124, 25);
            this._pathLabel.TabIndex = 0;
            this._pathLabel.Text = "&Export Path";
            // 
            // ExportForm
            // 
            this.AcceptButton = this._exportDatacardButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._cancelButton;
            this.ClientSize = new System.Drawing.Size(968, 842);
            this.Controls.Add(this._exportGroupBox);
            this.Controls.Add(this._preferencesGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Export";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExportForm_FormClosing);
            this.Load += new System.EventHandler(this.ExportForm_Load);
            this._preferencesGroupBox.ResumeLayout(false);
            this._preferencesGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._proprietaryDataGridView)).EndInit();
            this._exportGroupBox.ResumeLayout(false);
            this._exportGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox _preferencesGroupBox;
        private System.Windows.Forms.TextBox _initializeStringTextBox;
        private System.Windows.Forms.ListBox _loadedPluginsListBox;
        private System.Windows.Forms.Label _labelPluginLocation;
        private System.Windows.Forms.Label _loadedPluginsLabel;
        private System.Windows.Forms.Button _browsePluginLocationButton;
        private System.Windows.Forms.Button _loadPluginsButton;
        private System.Windows.Forms.Label _initializeStringLabel;
        private System.Windows.Forms.TextBox _pluginPathTextBox;
        private System.Windows.Forms.Label _proprietaryLabel;
        private System.Windows.Forms.GroupBox _exportGroupBox;
        private System.Windows.Forms.Button _exportDatacardButton;
        private System.Windows.Forms.Button _browseExportPathButton;
        private System.Windows.Forms.TextBox _exportPathTextBox;
        private System.Windows.Forms.Label _pathLabel;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.DataGridView _proprietaryDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn _keyColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _valueColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cardProfileSelection;
    }
}