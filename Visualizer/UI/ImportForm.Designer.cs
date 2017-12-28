﻿namespace AgGateway.ADAPT.Visualizer.UI
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
            this._preferencesGroupBox = new System.Windows.Forms.GroupBox();
            this._proprietaryDataGridView = new System.Windows.Forms.DataGridView();
            this._keyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._valueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._proprietaryLabel = new System.Windows.Forms.Label();
            this._initializeStringTextBox = new System.Windows.Forms.TextBox();
            this._loadedPluginsListBox = new System.Windows.Forms.ListBox();
            this._pluginLocationLabel = new System.Windows.Forms.Label();
            this._loadedPluginsLabel = new System.Windows.Forms.Label();
            this._browsePluginLocationButton = new System.Windows.Forms.Button();
            this._loadPluginsButton = new System.Windows.Forms.Button();
            this._initializeStringLabel = new System.Windows.Forms.Label();
            this._pluginPathTextBox = new System.Windows.Forms.TextBox();
            this._importGroupBox = new System.Windows.Forms.GroupBox();
            this._validateDataButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._importButton = new System.Windows.Forms.Button();
            this._browseDatacardButton = new System.Windows.Forms.Button();
            this._importPathTextbox = new System.Windows.Forms.TextBox();
            this._dataCardLabel = new System.Windows.Forms.Label();
            this._preferencesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._proprietaryDataGridView)).BeginInit();
            this._importGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // _preferencesGroupBox
            // 
            this._preferencesGroupBox.Controls.Add(this._proprietaryDataGridView);
            this._preferencesGroupBox.Controls.Add(this._proprietaryLabel);
            this._preferencesGroupBox.Controls.Add(this._initializeStringTextBox);
            this._preferencesGroupBox.Controls.Add(this._loadedPluginsListBox);
            this._preferencesGroupBox.Controls.Add(this._pluginLocationLabel);
            this._preferencesGroupBox.Controls.Add(this._loadedPluginsLabel);
            this._preferencesGroupBox.Controls.Add(this._browsePluginLocationButton);
            this._preferencesGroupBox.Controls.Add(this._loadPluginsButton);
            this._preferencesGroupBox.Controls.Add(this._initializeStringLabel);
            this._preferencesGroupBox.Controls.Add(this._pluginPathTextBox);
            this._preferencesGroupBox.Location = new System.Drawing.Point(24, 4);
            this._preferencesGroupBox.Margin = new System.Windows.Forms.Padding(6);
            this._preferencesGroupBox.Name = "_preferencesGroupBox";
            this._preferencesGroupBox.Padding = new System.Windows.Forms.Padding(6);
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
            this._proprietaryDataGridView.Margin = new System.Windows.Forms.Padding(6);
            this._proprietaryDataGridView.Name = "_proprietaryDataGridView";
            this._proprietaryDataGridView.Size = new System.Drawing.Size(720, 225);
            this._proprietaryDataGridView.TabIndex = 10;
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
            this._proprietaryLabel.Size = new System.Drawing.Size(116, 52);
            this._proprietaryLabel.TabIndex = 8;
            this._proprietaryLabel.Text = "P&roprietary values";
            // 
            // _initializeStringTextBox
            // 
            this._initializeStringTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._initializeStringTextBox.Location = new System.Drawing.Point(180, 37);
            this._initializeStringTextBox.Margin = new System.Windows.Forms.Padding(6);
            this._initializeStringTextBox.Name = "_initializeStringTextBox";
            this._initializeStringTextBox.Size = new System.Drawing.Size(716, 31);
            this._initializeStringTextBox.TabIndex = 1;
            // 
            // _loadedPluginsListBox
            // 
            this._loadedPluginsListBox.FormattingEnabled = true;
            this._loadedPluginsListBox.ItemHeight = 25;
            this._loadedPluginsListBox.Location = new System.Drawing.Point(180, 198);
            this._loadedPluginsListBox.Margin = new System.Windows.Forms.Padding(6);
            this._loadedPluginsListBox.MultiColumn = true;
            this._loadedPluginsListBox.Name = "_loadedPluginsListBox";
            this._loadedPluginsListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this._loadedPluginsListBox.Size = new System.Drawing.Size(716, 129);
            this._loadedPluginsListBox.TabIndex = 7;
            // 
            // _pluginLocationLabel
            // 
            this._pluginLocationLabel.AutoSize = true;
            this._pluginLocationLabel.Location = new System.Drawing.Point(20, 125);
            this._pluginLocationLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this._pluginLocationLabel.Name = "_pluginLocationLabel";
            this._pluginLocationLabel.Size = new System.Drawing.Size(153, 25);
            this._pluginLocationLabel.TabIndex = 2;
            this._pluginLocationLabel.Text = "&Plugin location";
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
            this._browsePluginLocationButton.Margin = new System.Windows.Forms.Padding(6);
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
            this._loadPluginsButton.Margin = new System.Windows.Forms.Padding(6);
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
            this._pluginPathTextBox.Margin = new System.Windows.Forms.Padding(6);
            this._pluginPathTextBox.Name = "_pluginPathTextBox";
            this._pluginPathTextBox.Size = new System.Drawing.Size(418, 31);
            this._pluginPathTextBox.TabIndex = 3;
            // 
            // _importGroupBox
            // 
            this._importGroupBox.Controls.Add(this._validateDataButton);
            this._importGroupBox.Controls.Add(this._cancelButton);
            this._importGroupBox.Controls.Add(this._importButton);
            this._importGroupBox.Controls.Add(this._browseDatacardButton);
            this._importGroupBox.Controls.Add(this._importPathTextbox);
            this._importGroupBox.Controls.Add(this._dataCardLabel);
            this._importGroupBox.Location = new System.Drawing.Point(24, 596);
            this._importGroupBox.Margin = new System.Windows.Forms.Padding(6);
            this._importGroupBox.Name = "_importGroupBox";
            this._importGroupBox.Padding = new System.Windows.Forms.Padding(6);
            this._importGroupBox.Size = new System.Drawing.Size(920, 199);
            this._importGroupBox.TabIndex = 1;
            this._importGroupBox.TabStop = false;
            this._importGroupBox.Text = "Import";
            // 
            // _validateDataButton
            // 
            this._validateDataButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._validateDataButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._validateDataButton.Location = new System.Drawing.Point(664, 93);
            this._validateDataButton.Margin = new System.Windows.Forms.Padding(6);
            this._validateDataButton.Name = "_validateDataButton";
            this._validateDataButton.Size = new System.Drawing.Size(228, 44);
            this._validateDataButton.TabIndex = 5;
            this._validateDataButton.Text = "Validate Data";
            this._validateDataButton.UseVisualStyleBackColor = true;
            this._validateDataButton.Click += new System.EventHandler(this._validateDataButton_Click);
            // 
            // _cancelButton
            // 
            this._cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Location = new System.Drawing.Point(664, 149);
            this._cancelButton.Margin = new System.Windows.Forms.Padding(6);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(108, 44);
            this._cancelButton.TabIndex = 4;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this._cancelButton_Click);
            // 
            // _importButton
            // 
            this._importButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._importButton.Location = new System.Drawing.Point(784, 149);
            this._importButton.Margin = new System.Windows.Forms.Padding(6);
            this._importButton.Name = "_importButton";
            this._importButton.Size = new System.Drawing.Size(108, 44);
            this._importButton.TabIndex = 3;
            this._importButton.Text = "Import";
            this._importButton.UseVisualStyleBackColor = true;
            this._importButton.Click += new System.EventHandler(this._importButton_Click);
            // 
            // _browseDatacardButton
            // 
            this._browseDatacardButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._browseDatacardButton.Location = new System.Drawing.Point(784, 37);
            this._browseDatacardButton.Margin = new System.Windows.Forms.Padding(6);
            this._browseDatacardButton.Name = "_browseDatacardButton";
            this._browseDatacardButton.Size = new System.Drawing.Size(108, 44);
            this._browseDatacardButton.TabIndex = 2;
            this._browseDatacardButton.Text = "Br&owse";
            this._browseDatacardButton.UseVisualStyleBackColor = true;
            this._browseDatacardButton.Click += new System.EventHandler(this.BrowseDataCardPath_Click);
            // 
            // _importPathTextbox
            // 
            this._importPathTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._importPathTextbox.Location = new System.Drawing.Point(180, 40);
            this._importPathTextbox.Margin = new System.Windows.Forms.Padding(6);
            this._importPathTextbox.Name = "_importPathTextbox";
            this._importPathTextbox.Size = new System.Drawing.Size(588, 31);
            this._importPathTextbox.TabIndex = 1;
            // 
            // _dataCardLabel
            // 
            this._dataCardLabel.AutoSize = true;
            this._dataCardLabel.Location = new System.Drawing.Point(20, 46);
            this._dataCardLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this._dataCardLabel.Name = "_dataCardLabel";
            this._dataCardLabel.Size = new System.Drawing.Size(149, 25);
            this._dataCardLabel.TabIndex = 0;
            this._dataCardLabel.Text = "&Datacard Path";
            // 
            // ImportForm
            // 
            this.AcceptButton = this._importButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._cancelButton;
            this.ClientSize = new System.Drawing.Size(968, 820);
            this.Controls.Add(this._importGroupBox);
            this.Controls.Add(this._preferencesGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImportForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Import";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImportForm_FormClosing);
            this.Load += new System.EventHandler(this.ImportForm_Load);
            this._preferencesGroupBox.ResumeLayout(false);
            this._preferencesGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._proprietaryDataGridView)).EndInit();
            this._importGroupBox.ResumeLayout(false);
            this._importGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox _preferencesGroupBox;
        private System.Windows.Forms.Label _proprietaryLabel;
        private System.Windows.Forms.TextBox _initializeStringTextBox;
        private System.Windows.Forms.ListBox _loadedPluginsListBox;
        private System.Windows.Forms.Label _pluginLocationLabel;
        private System.Windows.Forms.Label _loadedPluginsLabel;
        private System.Windows.Forms.Button _browsePluginLocationButton;
        private System.Windows.Forms.Button _loadPluginsButton;
        private System.Windows.Forms.Label _initializeStringLabel;
        private System.Windows.Forms.TextBox _pluginPathTextBox;
        private System.Windows.Forms.GroupBox _importGroupBox;
        private System.Windows.Forms.Label _dataCardLabel;
        private System.Windows.Forms.TextBox _importPathTextbox;
        private System.Windows.Forms.Button _browseDatacardButton;
        private System.Windows.Forms.Button _importButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.DataGridView _proprietaryDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn _keyColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _valueColumn;
        private System.Windows.Forms.Button _validateDataButton;
    }
}