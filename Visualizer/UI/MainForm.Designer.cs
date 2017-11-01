namespace AgGateway.ADAPT.Visualizer.UI
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this._splitContainerViewer = new System.Windows.Forms.SplitContainer();
            this._treeViewMetadata = new System.Windows.Forms.TreeView();
            this._splitContainerMap = new System.Windows.Forms.SplitContainer();
            this._tabControlViewer = new System.Windows.Forms.TabControl();
            this._tabPageSpatial = new System.Windows.Forms.TabPage();
            this._tabPageRawData = new System.Windows.Forms.TabPage();
            this._buttonExportRawData = new System.Windows.Forms.Button();
            this._dataGridViewRawData = new System.Windows.Forms.DataGridView();
            this._dataGridViewTotals = new System.Windows.Forms.DataGridView();
            this._dataGridColumnDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._dataGridColumnValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._labelTotals = new System.Windows.Forms.Label();
            this._toolStrip = new System.Windows.Forms.ToolStrip();
            this._importToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._exportToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._findToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._aboutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._menuStrip = new System.Windows.Forms.MenuStrip();
            this._dummyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._importMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._exportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._findMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._findNextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.workingDataComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainerViewer)).BeginInit();
            this._splitContainerViewer.Panel1.SuspendLayout();
            this._splitContainerViewer.Panel2.SuspendLayout();
            this._splitContainerViewer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainerMap)).BeginInit();
            this._splitContainerMap.Panel1.SuspendLayout();
            this._splitContainerMap.Panel2.SuspendLayout();
            this._splitContainerMap.SuspendLayout();
            this._tabControlViewer.SuspendLayout();
            this._tabPageRawData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewRawData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewTotals)).BeginInit();
            this._toolStrip.SuspendLayout();
            this._menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _splitContainerViewer
            // 
            this._splitContainerViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._splitContainerViewer.Location = new System.Drawing.Point(0, 91);
            this._splitContainerViewer.Margin = new System.Windows.Forms.Padding(6);
            this._splitContainerViewer.Name = "_splitContainerViewer";
            // 
            // _splitContainerViewer.Panel1
            // 
            this._splitContainerViewer.Panel1.Controls.Add(this._treeViewMetadata);
            // 
            // _splitContainerViewer.Panel2
            // 
            this._splitContainerViewer.Panel2.Controls.Add(this._splitContainerMap);
            this._splitContainerViewer.Size = new System.Drawing.Size(1998, 1336);
            this._splitContainerViewer.SplitterDistance = 500;
            this._splitContainerViewer.SplitterWidth = 8;
            this._splitContainerViewer.TabIndex = 0;
            // 
            // _treeViewMetadata
            // 
            this._treeViewMetadata.Dock = System.Windows.Forms.DockStyle.Fill;
            this._treeViewMetadata.Location = new System.Drawing.Point(0, 0);
            this._treeViewMetadata.Margin = new System.Windows.Forms.Padding(6);
            this._treeViewMetadata.Name = "_treeViewMetadata";
            this._treeViewMetadata.Size = new System.Drawing.Size(500, 1336);
            this._treeViewMetadata.TabIndex = 0;
            this._treeViewMetadata.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this._treeViewMetadata_NodeMouseClick);
            // 
            // _splitContainerMap
            // 
            this._splitContainerMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this._splitContainerMap.Location = new System.Drawing.Point(0, 0);
            this._splitContainerMap.Margin = new System.Windows.Forms.Padding(6);
            this._splitContainerMap.Name = "_splitContainerMap";
            this._splitContainerMap.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // _splitContainerMap.Panel1
            // 
            this._splitContainerMap.Panel1.Controls.Add(this._tabControlViewer);
            // 
            // _splitContainerMap.Panel2
            // 
            this._splitContainerMap.Panel2.Controls.Add(this._dataGridViewTotals);
            this._splitContainerMap.Panel2.Controls.Add(this._labelTotals);
            this._splitContainerMap.Size = new System.Drawing.Size(1490, 1336);
            this._splitContainerMap.SplitterDistance = 890;
            this._splitContainerMap.SplitterWidth = 8;
            this._splitContainerMap.TabIndex = 0;
            // 
            // _tabControlViewer
            // 
            this._tabControlViewer.Controls.Add(this._tabPageSpatial);
            this._tabControlViewer.Controls.Add(this._tabPageRawData);
            this._tabControlViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tabControlViewer.Location = new System.Drawing.Point(0, 0);
            this._tabControlViewer.Margin = new System.Windows.Forms.Padding(6);
            this._tabControlViewer.Name = "_tabControlViewer";
            this._tabControlViewer.SelectedIndex = 0;
            this._tabControlViewer.Size = new System.Drawing.Size(1490, 890);
            this._tabControlViewer.TabIndex = 0;
            // 
            // _tabPageSpatial
            // 
            this._tabPageSpatial.Location = new System.Drawing.Point(8, 39);
            this._tabPageSpatial.Margin = new System.Windows.Forms.Padding(6);
            this._tabPageSpatial.Name = "_tabPageSpatial";
            this._tabPageSpatial.Padding = new System.Windows.Forms.Padding(6);
            this._tabPageSpatial.Size = new System.Drawing.Size(1474, 843);
            this._tabPageSpatial.TabIndex = 0;
            this._tabPageSpatial.Text = "Spatial Viewer";
            this._tabPageSpatial.UseVisualStyleBackColor = true;
            this._tabPageSpatial.Paint += new System.Windows.Forms.PaintEventHandler(this._tabPageSpatial_Paint);
            // 
            // _tabPageRawData
            // 
            this._tabPageRawData.Controls.Add(this._buttonExportRawData);
            this._tabPageRawData.Controls.Add(this._dataGridViewRawData);
            this._tabPageRawData.Location = new System.Drawing.Point(8, 39);
            this._tabPageRawData.Margin = new System.Windows.Forms.Padding(6);
            this._tabPageRawData.Name = "_tabPageRawData";
            this._tabPageRawData.Padding = new System.Windows.Forms.Padding(6);
            this._tabPageRawData.Size = new System.Drawing.Size(1474, 843);
            this._tabPageRawData.TabIndex = 1;
            this._tabPageRawData.Text = "Raw data Viewer";
            this._tabPageRawData.UseVisualStyleBackColor = true;
            // 
            // _buttonExportRawData
            // 
            this._buttonExportRawData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonExportRawData.Location = new System.Drawing.Point(1260, 747);
            this._buttonExportRawData.Margin = new System.Windows.Forms.Padding(6);
            this._buttonExportRawData.Name = "_buttonExportRawData";
            this._buttonExportRawData.Size = new System.Drawing.Size(178, 44);
            this._buttonExportRawData.TabIndex = 1;
            this._buttonExportRawData.Text = "Export";
            this._buttonExportRawData.UseVisualStyleBackColor = true;
            this._buttonExportRawData.Click += new System.EventHandler(this._buttonExportRawData_Click);
            // 
            // _dataGridViewRawData
            // 
            this._dataGridViewRawData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dataGridViewRawData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridViewRawData.Location = new System.Drawing.Point(6, 6);
            this._dataGridViewRawData.Margin = new System.Windows.Forms.Padding(6);
            this._dataGridViewRawData.Name = "_dataGridViewRawData";
            this._dataGridViewRawData.Size = new System.Drawing.Size(1446, 734);
            this._dataGridViewRawData.TabIndex = 0;
            this._dataGridViewRawData.Paint += new System.Windows.Forms.PaintEventHandler(this._dataGridViewRawData_Paint);
            // 
            // _dataGridViewTotals
            // 
            this._dataGridViewTotals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridViewTotals.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._dataGridColumnDescription,
            this._dataGridColumnValue});
            this._dataGridViewTotals.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dataGridViewTotals.Location = new System.Drawing.Point(0, 25);
            this._dataGridViewTotals.Margin = new System.Windows.Forms.Padding(6);
            this._dataGridViewTotals.Name = "_dataGridViewTotals";
            this._dataGridViewTotals.RowHeadersVisible = false;
            this._dataGridViewTotals.Size = new System.Drawing.Size(1490, 413);
            this._dataGridViewTotals.TabIndex = 1;
            // 
            // _dataGridColumnDescription
            // 
            this._dataGridColumnDescription.HeaderText = "Description";
            this._dataGridColumnDescription.Name = "_dataGridColumnDescription";
            this._dataGridColumnDescription.Width = 250;
            // 
            // _dataGridColumnValue
            // 
            this._dataGridColumnValue.HeaderText = "Value";
            this._dataGridColumnValue.Name = "_dataGridColumnValue";
            // 
            // _labelTotals
            // 
            this._labelTotals.AutoSize = true;
            this._labelTotals.Dock = System.Windows.Forms.DockStyle.Top;
            this._labelTotals.Location = new System.Drawing.Point(0, 0);
            this._labelTotals.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this._labelTotals.Name = "_labelTotals";
            this._labelTotals.Size = new System.Drawing.Size(71, 25);
            this._labelTotals.TabIndex = 0;
            this._labelTotals.Text = "Totals";
            // 
            // _toolStrip
            // 
            this._toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this._toolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._importToolStripButton,
            this._exportToolStripButton,
            this._findToolStripButton,
            this._aboutToolStripButton});
            this._toolStrip.Location = new System.Drawing.Point(0, 0);
            this._toolStrip.Name = "_toolStrip";
            this._toolStrip.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this._toolStrip.Size = new System.Drawing.Size(1998, 91);
            this._toolStrip.TabIndex = 9;
            this._toolStrip.Text = "toolStrip1";
            // 
            // _importToolStripButton
            // 
            this._importToolStripButton.Image = global::AgGateway.ADAPT.Visualizer.Properties.Resources.Enter;
            this._importToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this._importToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._importToolStripButton.Name = "_importToolStripButton";
            this._importToolStripButton.Size = new System.Drawing.Size(90, 88);
            this._importToolStripButton.Text = "Import";
            this._importToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._importToolStripButton.ToolTipText = "Import (Ctrl+I)";
            this._importToolStripButton.Click += new System.EventHandler(this._importToolStripButton_Click);
            // 
            // _exportToolStripButton
            // 
            this._exportToolStripButton.Image = global::AgGateway.ADAPT.Visualizer.Properties.Resources.Exit;
            this._exportToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this._exportToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._exportToolStripButton.Name = "_exportToolStripButton";
            this._exportToolStripButton.Size = new System.Drawing.Size(86, 88);
            this._exportToolStripButton.Text = "Export";
            this._exportToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._exportToolStripButton.ToolTipText = "Export (Ctrl+E)";
            this._exportToolStripButton.Click += new System.EventHandler(this._exportToolStripButton_Click);
            // 
            // _findToolStripButton
            // 
            this._findToolStripButton.Image = global::AgGateway.ADAPT.Visualizer.Properties.Resources.Search;
            this._findToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this._findToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._findToolStripButton.Name = "_findToolStripButton";
            this._findToolStripButton.Size = new System.Drawing.Size(65, 88);
            this._findToolStripButton.Text = "Find";
            this._findToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._findToolStripButton.ToolTipText = "Find (Ctrl+F)";
            this._findToolStripButton.Click += new System.EventHandler(this._findMenuItem_Click);
            // 
            // _aboutToolStripButton
            // 
            this._aboutToolStripButton.Image = global::AgGateway.ADAPT.Visualizer.Properties.Resources.About_52;
            this._aboutToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this._aboutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._aboutToolStripButton.Name = "_aboutToolStripButton";
            this._aboutToolStripButton.Size = new System.Drawing.Size(84, 88);
            this._aboutToolStripButton.Text = "About";
            this._aboutToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._aboutToolStripButton.Click += new System.EventHandler(this._aboutToolStripButton_Click);
            // 
            // _menuStrip
            // 
            this._menuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this._menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._dummyMenuItem});
            this._menuStrip.Location = new System.Drawing.Point(0, 0);
            this._menuStrip.Name = "_menuStrip";
            this._menuStrip.Padding = new System.Windows.Forms.Padding(12, 4, 0, 4);
            this._menuStrip.Size = new System.Drawing.Size(1998, 46);
            this._menuStrip.TabIndex = 10;
            this._menuStrip.Text = "menuStrip1";
            this._menuStrip.Visible = false;
            // 
            // _dummyMenuItem
            // 
            this._dummyMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._importMenuItem,
            this._exportMenuItem,
            this._findMenuItem,
            this._findNextMenuItem});
            this._dummyMenuItem.Name = "_dummyMenuItem";
            this._dummyMenuItem.Size = new System.Drawing.Size(309, 38);
            this._dummyMenuItem.Text = "{dummy_for_shorcut_keys}";
            // 
            // _importMenuItem
            // 
            this._importMenuItem.Name = "_importMenuItem";
            this._importMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this._importMenuItem.Size = new System.Drawing.Size(262, 38);
            this._importMenuItem.Text = "import";
            this._importMenuItem.Click += new System.EventHandler(this._importMenuItem_Click);
            // 
            // _exportMenuItem
            // 
            this._exportMenuItem.Name = "_exportMenuItem";
            this._exportMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this._exportMenuItem.Size = new System.Drawing.Size(262, 38);
            this._exportMenuItem.Text = "export";
            this._exportMenuItem.Click += new System.EventHandler(this._exportMenuItem_Click);
            // 
            // _findMenuItem
            // 
            this._findMenuItem.Name = "_findMenuItem";
            this._findMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this._findMenuItem.Size = new System.Drawing.Size(262, 38);
            this._findMenuItem.Text = "find";
            this._findMenuItem.Click += new System.EventHandler(this._findMenuItem_Click);
            // 
            // _findNextMenuItem
            // 
            this._findNextMenuItem.Name = "_findNextMenuItem";
            this._findNextMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this._findNextMenuItem.Size = new System.Drawing.Size(262, 38);
            this._findNextMenuItem.Text = "find_next";
            this._findNextMenuItem.Click += new System.EventHandler(this._findNextMenuItem_Click);
            // 
            // workingDataComboBox
            // 
            this.workingDataComboBox.FormattingEnabled = true;
            this.workingDataComboBox.Location = new System.Drawing.Point(901, 23);
            this.workingDataComboBox.Name = "workingDataComboBox";
            this.workingDataComboBox.Size = new System.Drawing.Size(563, 33);
            this.workingDataComboBox.TabIndex = 0;
            this.workingDataComboBox.Visible = false;
            this.workingDataComboBox.SelectedIndexChanged += new System.EventHandler(this.workingDataComboBox_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1998, 1427);
            this.Controls.Add(this.workingDataComboBox);
            this.Controls.Add(this._splitContainerViewer);
            this.Controls.Add(this._toolStrip);
            this.Controls.Add(this._menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this._menuStrip;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "MainForm";
            this.Text = "ADAPT - Visualizer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.LocationChanged += new System.EventHandler(this.MainForm_LocationChanged);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this._splitContainerViewer.Panel1.ResumeLayout(false);
            this._splitContainerViewer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._splitContainerViewer)).EndInit();
            this._splitContainerViewer.ResumeLayout(false);
            this._splitContainerMap.Panel1.ResumeLayout(false);
            this._splitContainerMap.Panel2.ResumeLayout(false);
            this._splitContainerMap.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainerMap)).EndInit();
            this._splitContainerMap.ResumeLayout(false);
            this._tabControlViewer.ResumeLayout(false);
            this._tabPageRawData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewRawData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewTotals)).EndInit();
            this._toolStrip.ResumeLayout(false);
            this._toolStrip.PerformLayout();
            this._menuStrip.ResumeLayout(false);
            this._menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer _splitContainerViewer;
        private System.Windows.Forms.TreeView _treeViewMetadata;
        private System.Windows.Forms.SplitContainer _splitContainerMap;
        private System.Windows.Forms.TabControl _tabControlViewer;
        private System.Windows.Forms.TabPage _tabPageSpatial;
        private System.Windows.Forms.TabPage _tabPageRawData;
        private System.Windows.Forms.Button _buttonExportRawData;
        private System.Windows.Forms.DataGridView _dataGridViewRawData;
        private System.Windows.Forms.DataGridView _dataGridViewTotals;
        private System.Windows.Forms.DataGridViewTextBoxColumn _dataGridColumnDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn _dataGridColumnValue;
        private System.Windows.Forms.Label _labelTotals;
        private System.Windows.Forms.ToolStripButton _importToolStripButton;
        private System.Windows.Forms.ToolStrip _toolStrip;
        private System.Windows.Forms.ToolStripButton _findToolStripButton;
        private System.Windows.Forms.ToolStripButton _aboutToolStripButton;
        private System.Windows.Forms.MenuStrip _menuStrip;
        private System.Windows.Forms.ToolStripMenuItem _dummyMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _importMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _exportMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _findMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _findNextMenuItem;
        private System.Windows.Forms.ToolStripButton _exportToolStripButton;
        private System.Windows.Forms.ComboBox workingDataComboBox;
    }
}

