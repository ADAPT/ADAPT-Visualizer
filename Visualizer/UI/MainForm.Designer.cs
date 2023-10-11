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
            _splitContainerViewer = new SplitContainer();
            _treeViewMetadata = new TreeView();
            _splitContainerMap = new SplitContainer();
            _tabControlViewer = new TabControl();
            _tabPageSpatial = new TabPage();
            _tabPageRawData = new TabPage();
            _tableLayoutPanelRawData = new TableLayoutPanel();
            _dataGridViewRawData = new DataGridView();
            _buttonExportRawData = new Button();
            _limitDataPanel = new TableLayoutPanel();
            _limitDataCheckBox = new CheckBox();
            _maxRowsLabel = new Label();
            _maxColumnsLabel = new Label();
            _maxRowsNumericUpDown = new NumericUpDown();
            _maxColumnsNumericUpDown = new NumericUpDown();
            _dataGridViewTotals = new DataGridView();
            _dataGridColumnDescription = new DataGridViewTextBoxColumn();
            _dataGridColumnValue = new DataGridViewTextBoxColumn();
            _labelTotals = new Label();
            _toolStrip = new ToolStrip();
            _importToolStripButton = new ToolStripButton();
            _exportToolStripButton = new ToolStripButton();
            _findToolStripButton = new ToolStripButton();
            _settingsToolStripButton = new ToolStripButton();
            _aboutToolStripButton = new ToolStripButton();
            _menuStrip = new MenuStrip();
            _dummyMenuItem = new ToolStripMenuItem();
            _importMenuItem = new ToolStripMenuItem();
            _exportMenuItem = new ToolStripMenuItem();
            _findMenuItem = new ToolStripMenuItem();
            _findNextMenuItem = new ToolStripMenuItem();
            workingDataComboBox = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)_splitContainerViewer).BeginInit();
            _splitContainerViewer.Panel1.SuspendLayout();
            _splitContainerViewer.Panel2.SuspendLayout();
            _splitContainerViewer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_splitContainerMap).BeginInit();
            _splitContainerMap.Panel1.SuspendLayout();
            _splitContainerMap.Panel2.SuspendLayout();
            _splitContainerMap.SuspendLayout();
            _tabControlViewer.SuspendLayout();
            _tabPageRawData.SuspendLayout();
            _tableLayoutPanelRawData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dataGridViewRawData).BeginInit();
            _limitDataPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_maxRowsNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_maxColumnsNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_dataGridViewTotals).BeginInit();
            _toolStrip.SuspendLayout();
            _menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // _splitContainerViewer
            // 
            _splitContainerViewer.Dock = DockStyle.Fill;
            _splitContainerViewer.Location = new Point(0, 79);
            _splitContainerViewer.Margin = new Padding(4, 5, 4, 5);
            _splitContainerViewer.Name = "_splitContainerViewer";
            // 
            // _splitContainerViewer.Panel1
            // 
            _splitContainerViewer.Panel1.Controls.Add(_treeViewMetadata);
            // 
            // _splitContainerViewer.Panel2
            // 
            _splitContainerViewer.Panel2.Controls.Add(_splitContainerMap);
            _splitContainerViewer.Size = new Size(887, 682);
            _splitContainerViewer.SplitterDistance = 221;
            _splitContainerViewer.TabIndex = 1;
            _splitContainerViewer.SplitterMoved += _splitContainerViewer_SplitterMoved;
            // 
            // _treeViewMetadata
            // 
            _treeViewMetadata.Dock = DockStyle.Fill;
            _treeViewMetadata.Location = new Point(0, 0);
            _treeViewMetadata.Margin = new Padding(4, 5, 4, 5);
            _treeViewMetadata.Name = "_treeViewMetadata";
            _treeViewMetadata.Size = new Size(221, 682);
            _treeViewMetadata.TabIndex = 0;
            _treeViewMetadata.NodeMouseClick += _treeViewMetadata_NodeMouseClick;
            // 
            // _splitContainerMap
            // 
            _splitContainerMap.Dock = DockStyle.Fill;
            _splitContainerMap.Location = new Point(0, 0);
            _splitContainerMap.Margin = new Padding(4, 5, 4, 5);
            _splitContainerMap.Name = "_splitContainerMap";
            _splitContainerMap.Orientation = Orientation.Horizontal;
            // 
            // _splitContainerMap.Panel1
            // 
            _splitContainerMap.Panel1.Controls.Add(_tabControlViewer);
            _splitContainerMap.Panel1.Controls.Add(_limitDataPanel);
            // 
            // _splitContainerMap.Panel2
            // 
            _splitContainerMap.Panel2.Controls.Add(_dataGridViewTotals);
            _splitContainerMap.Panel2.Controls.Add(_labelTotals);
            _splitContainerMap.Size = new Size(662, 682);
            _splitContainerMap.SplitterDistance = 453;
            _splitContainerMap.SplitterWidth = 6;
            _splitContainerMap.TabIndex = 0;
            _splitContainerMap.SplitterMoved += _splitContainerMap_SplitterMoved;
            // 
            // _tabControlViewer
            // 
            _tabControlViewer.Controls.Add(_tabPageSpatial);
            _tabControlViewer.Controls.Add(_tabPageRawData);
            _tabControlViewer.Dock = DockStyle.Fill;
            _tabControlViewer.Location = new Point(0, 44);
            _tabControlViewer.Margin = new Padding(4, 5, 4, 5);
            _tabControlViewer.Name = "_tabControlViewer";
            _tabControlViewer.SelectedIndex = 0;
            _tabControlViewer.Size = new Size(662, 409);
            _tabControlViewer.TabIndex = 1;
            // 
            // _tabPageSpatial
            // 
            _tabPageSpatial.Location = new Point(4, 29);
            _tabPageSpatial.Margin = new Padding(4, 5, 4, 5);
            _tabPageSpatial.Name = "_tabPageSpatial";
            _tabPageSpatial.Padding = new Padding(4, 5, 4, 5);
            _tabPageSpatial.Size = new Size(654, 376);
            _tabPageSpatial.TabIndex = 0;
            _tabPageSpatial.Text = "Spatial Viewer";
            _tabPageSpatial.UseVisualStyleBackColor = true;
            _tabPageSpatial.Paint += _tabPageSpatial_Paint;
            // 
            // _tabPageRawData
            // 
            _tabPageRawData.Controls.Add(_tableLayoutPanelRawData);
            _tabPageRawData.Location = new Point(4, 29);
            _tabPageRawData.Margin = new Padding(4, 5, 4, 5);
            _tabPageRawData.Name = "_tabPageRawData";
            _tabPageRawData.Size = new Size(654, 376);
            _tabPageRawData.TabIndex = 1;
            _tabPageRawData.Text = "Raw data Viewer";
            _tabPageRawData.UseVisualStyleBackColor = true;
            // 
            // _tableLayoutPanelRawData
            // 
            _tableLayoutPanelRawData.ColumnCount = 1;
            _tableLayoutPanelRawData.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            _tableLayoutPanelRawData.Controls.Add(_dataGridViewRawData, 0, 0);
            _tableLayoutPanelRawData.Controls.Add(_buttonExportRawData, 0, 1);
            _tableLayoutPanelRawData.Dock = DockStyle.Fill;
            _tableLayoutPanelRawData.Location = new Point(0, 0);
            _tableLayoutPanelRawData.Margin = new Padding(0);
            _tableLayoutPanelRawData.Name = "_tableLayoutPanelRawData";
            _tableLayoutPanelRawData.RowCount = 2;
            _tableLayoutPanelRawData.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            _tableLayoutPanelRawData.RowStyles.Add(new RowStyle());
            _tableLayoutPanelRawData.Size = new Size(654, 376);
            _tableLayoutPanelRawData.TabIndex = 2;
            // 
            // _dataGridViewRawData
            // 
            _dataGridViewRawData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _dataGridViewRawData.Dock = DockStyle.Fill;
            _dataGridViewRawData.Location = new Point(4, 5);
            _dataGridViewRawData.Margin = new Padding(4, 5, 4, 5);
            _dataGridViewRawData.Name = "_dataGridViewRawData";
            _dataGridViewRawData.RowHeadersWidth = 62;
            _dataGridViewRawData.Size = new Size(646, 321);
            _dataGridViewRawData.TabIndex = 0;
            _dataGridViewRawData.ColumnAdded += _dataGridViewRawData_ColumnAdded;
            _dataGridViewRawData.Paint += _dataGridViewRawData_Paint;
            // 
            // _buttonExportRawData
            // 
            _buttonExportRawData.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _buttonExportRawData.Location = new Point(531, 336);
            _buttonExportRawData.Margin = new Padding(4, 5, 4, 5);
            _buttonExportRawData.Name = "_buttonExportRawData";
            _buttonExportRawData.Size = new Size(119, 35);
            _buttonExportRawData.TabIndex = 1;
            _buttonExportRawData.Text = "Export";
            _buttonExportRawData.UseVisualStyleBackColor = true;
            _buttonExportRawData.Click += _buttonExportRawData_Click;
            // 
            // _limitDataPanel
            // 
            _limitDataPanel.AutoSize = true;
            _limitDataPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            _limitDataPanel.ColumnCount = 6;
            _limitDataPanel.ColumnStyles.Add(new ColumnStyle());
            _limitDataPanel.ColumnStyles.Add(new ColumnStyle());
            _limitDataPanel.ColumnStyles.Add(new ColumnStyle());
            _limitDataPanel.ColumnStyles.Add(new ColumnStyle());
            _limitDataPanel.ColumnStyles.Add(new ColumnStyle());
            _limitDataPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            _limitDataPanel.Controls.Add(_limitDataCheckBox, 0, 0);
            _limitDataPanel.Controls.Add(_maxRowsLabel, 1, 0);
            _limitDataPanel.Controls.Add(_maxColumnsLabel, 3, 0);
            _limitDataPanel.Controls.Add(_maxRowsNumericUpDown, 2, 0);
            _limitDataPanel.Controls.Add(_maxColumnsNumericUpDown, 4, 0);
            _limitDataPanel.Dock = DockStyle.Top;
            _limitDataPanel.Location = new Point(0, 0);
            _limitDataPanel.Margin = new Padding(3, 4, 3, 4);
            _limitDataPanel.Name = "_limitDataPanel";
            _limitDataPanel.Padding = new Padding(0, 6, 0, 6);
            _limitDataPanel.RowCount = 1;
            _limitDataPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            _limitDataPanel.Size = new Size(662, 44);
            _limitDataPanel.TabIndex = 0;
            _limitDataPanel.VisibleChanged += _limitDataPanel_VisibleChanged;
            // 
            // _limitDataCheckBox
            // 
            _limitDataCheckBox.Anchor = AnchorStyles.Left;
            _limitDataCheckBox.AutoSize = true;
            _limitDataCheckBox.Location = new Point(3, 10);
            _limitDataCheckBox.Margin = new Padding(3, 4, 3, 4);
            _limitDataCheckBox.Name = "_limitDataCheckBox";
            _limitDataCheckBox.Size = new Size(100, 24);
            _limitDataCheckBox.TabIndex = 0;
            _limitDataCheckBox.Text = "Limit Data";
            _limitDataCheckBox.UseVisualStyleBackColor = true;
            _limitDataCheckBox.CheckedChanged += _limitDataCheckBox_CheckedChanged;
            // 
            // _maxRowsLabel
            // 
            _maxRowsLabel.Anchor = AnchorStyles.Left;
            _maxRowsLabel.AutoSize = true;
            _maxRowsLabel.Enabled = false;
            _maxRowsLabel.Location = new Point(112, 12);
            _maxRowsLabel.Margin = new Padding(6, 0, 3, 0);
            _maxRowsLabel.Name = "_maxRowsLabel";
            _maxRowsLabel.Size = new Size(76, 20);
            _maxRowsLabel.TabIndex = 1;
            _maxRowsLabel.Text = "Max Rows";
            // 
            // _maxColumnsLabel
            // 
            _maxColumnsLabel.Anchor = AnchorStyles.Left;
            _maxColumnsLabel.AutoSize = true;
            _maxColumnsLabel.Enabled = false;
            _maxColumnsLabel.Location = new Point(260, 12);
            _maxColumnsLabel.Margin = new Padding(6, 0, 3, 0);
            _maxColumnsLabel.Name = "_maxColumnsLabel";
            _maxColumnsLabel.Size = new Size(98, 20);
            _maxColumnsLabel.TabIndex = 3;
            _maxColumnsLabel.Text = "Max Columns";
            // 
            // _maxRowsNumericUpDown
            // 
            _maxRowsNumericUpDown.Anchor = AnchorStyles.Left;
            _maxRowsNumericUpDown.Enabled = false;
            _maxRowsNumericUpDown.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            _maxRowsNumericUpDown.Location = new Point(194, 8);
            _maxRowsNumericUpDown.Margin = new Padding(3, 0, 3, 0);
            _maxRowsNumericUpDown.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            _maxRowsNumericUpDown.Name = "_maxRowsNumericUpDown";
            _maxRowsNumericUpDown.Size = new Size(57, 27);
            _maxRowsNumericUpDown.TabIndex = 2;
            _maxRowsNumericUpDown.Value = new decimal(new int[] { 100, 0, 0, 0 });
            _maxRowsNumericUpDown.ValueChanged += _maxRowsNumericUpDown_ValueChanged;
            // 
            // _maxColumnsNumericUpDown
            // 
            _maxColumnsNumericUpDown.Anchor = AnchorStyles.Left;
            _maxColumnsNumericUpDown.Enabled = false;
            _maxColumnsNumericUpDown.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            _maxColumnsNumericUpDown.Location = new Point(364, 8);
            _maxColumnsNumericUpDown.Margin = new Padding(3, 0, 3, 0);
            _maxColumnsNumericUpDown.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            _maxColumnsNumericUpDown.Name = "_maxColumnsNumericUpDown";
            _maxColumnsNumericUpDown.Size = new Size(57, 27);
            _maxColumnsNumericUpDown.TabIndex = 4;
            _maxColumnsNumericUpDown.Value = new decimal(new int[] { 50, 0, 0, 0 });
            _maxColumnsNumericUpDown.ValueChanged += _maxColumnsNumericUpDown_ValueChanged;
            // 
            // _dataGridViewTotals
            // 
            _dataGridViewTotals.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _dataGridViewTotals.Columns.AddRange(new DataGridViewColumn[] { _dataGridColumnDescription, _dataGridColumnValue });
            _dataGridViewTotals.Dock = DockStyle.Fill;
            _dataGridViewTotals.Location = new Point(0, 20);
            _dataGridViewTotals.Margin = new Padding(4, 5, 4, 5);
            _dataGridViewTotals.Name = "_dataGridViewTotals";
            _dataGridViewTotals.RowHeadersVisible = false;
            _dataGridViewTotals.RowHeadersWidth = 62;
            _dataGridViewTotals.Size = new Size(662, 203);
            _dataGridViewTotals.TabIndex = 1;
            // 
            // _dataGridColumnDescription
            // 
            _dataGridColumnDescription.HeaderText = "Description";
            _dataGridColumnDescription.MinimumWidth = 8;
            _dataGridColumnDescription.Name = "_dataGridColumnDescription";
            _dataGridColumnDescription.Width = 250;
            // 
            // _dataGridColumnValue
            // 
            _dataGridColumnValue.HeaderText = "Value";
            _dataGridColumnValue.MinimumWidth = 8;
            _dataGridColumnValue.Name = "_dataGridColumnValue";
            _dataGridColumnValue.Width = 150;
            // 
            // _labelTotals
            // 
            _labelTotals.AutoSize = true;
            _labelTotals.Dock = DockStyle.Top;
            _labelTotals.Location = new Point(0, 0);
            _labelTotals.Name = "_labelTotals";
            _labelTotals.Size = new Size(48, 20);
            _labelTotals.TabIndex = 0;
            _labelTotals.Text = "Totals";
            // 
            // _toolStrip
            // 
            _toolStrip.GripStyle = ToolStripGripStyle.Hidden;
            _toolStrip.ImageScalingSize = new Size(32, 32);
            _toolStrip.Items.AddRange(new ToolStripItem[] { _importToolStripButton, _exportToolStripButton, _findToolStripButton, _settingsToolStripButton, _aboutToolStripButton });
            _toolStrip.Location = new Point(0, 0);
            _toolStrip.Name = "_toolStrip";
            _toolStrip.Size = new Size(887, 79);
            _toolStrip.TabIndex = 2;
            _toolStrip.Text = "toolStrip1";
            // 
            // _importToolStripButton
            // 
            _importToolStripButton.Image = Properties.Resources.Enter;
            _importToolStripButton.ImageScaling = ToolStripItemImageScaling.None;
            _importToolStripButton.ImageTransparentColor = Color.Magenta;
            _importToolStripButton.Name = "_importToolStripButton";
            _importToolStripButton.Size = new Size(58, 76);
            _importToolStripButton.Text = "Import";
            _importToolStripButton.TextImageRelation = TextImageRelation.ImageAboveText;
            _importToolStripButton.ToolTipText = "Import (Ctrl+I)";
            _importToolStripButton.Click += _importToolStripButton_Click;
            // 
            // _exportToolStripButton
            // 
            _exportToolStripButton.Image = Properties.Resources.Exit;
            _exportToolStripButton.ImageScaling = ToolStripItemImageScaling.None;
            _exportToolStripButton.ImageTransparentColor = Color.Magenta;
            _exportToolStripButton.Name = "_exportToolStripButton";
            _exportToolStripButton.Size = new Size(56, 76);
            _exportToolStripButton.Text = "Export";
            _exportToolStripButton.TextImageRelation = TextImageRelation.ImageAboveText;
            _exportToolStripButton.ToolTipText = "Export (Ctrl+E)";
            _exportToolStripButton.Click += _exportToolStripButton_Click;
            // 
            // _findToolStripButton
            // 
            _findToolStripButton.Image = Properties.Resources.Search;
            _findToolStripButton.ImageScaling = ToolStripItemImageScaling.None;
            _findToolStripButton.ImageTransparentColor = Color.Magenta;
            _findToolStripButton.Name = "_findToolStripButton";
            _findToolStripButton.Size = new Size(56, 76);
            _findToolStripButton.Text = "Find";
            _findToolStripButton.TextImageRelation = TextImageRelation.ImageAboveText;
            _findToolStripButton.ToolTipText = "Find (Ctrl+F)";
            _findToolStripButton.Click += _findMenuItem_Click;
            // 
            // _settingsToolStripButton
            // 
            _settingsToolStripButton.Image = Properties.Resources.Settings_3;
            _settingsToolStripButton.ImageScaling = ToolStripItemImageScaling.None;
            _settingsToolStripButton.ImageTransparentColor = Color.Magenta;
            _settingsToolStripButton.Name = "_settingsToolStripButton";
            _settingsToolStripButton.Size = new Size(66, 76);
            _settingsToolStripButton.Text = "Settings";
            _settingsToolStripButton.TextImageRelation = TextImageRelation.ImageAboveText;
            _settingsToolStripButton.Click += _settingsToolStripButton_Click;
            // 
            // _aboutToolStripButton
            // 
            _aboutToolStripButton.Image = Properties.Resources.About_52;
            _aboutToolStripButton.ImageScaling = ToolStripItemImageScaling.None;
            _aboutToolStripButton.ImageTransparentColor = Color.Magenta;
            _aboutToolStripButton.Name = "_aboutToolStripButton";
            _aboutToolStripButton.Size = new Size(56, 76);
            _aboutToolStripButton.Text = "About";
            _aboutToolStripButton.TextImageRelation = TextImageRelation.ImageAboveText;
            _aboutToolStripButton.Click += _aboutToolStripButton_Click;
            // 
            // _menuStrip
            // 
            _menuStrip.ImageScalingSize = new Size(32, 32);
            _menuStrip.Items.AddRange(new ToolStripItem[] { _dummyMenuItem });
            _menuStrip.Location = new Point(0, 0);
            _menuStrip.Name = "_menuStrip";
            _menuStrip.Padding = new Padding(4, 2, 0, 2);
            _menuStrip.Size = new Size(831, 37);
            _menuStrip.TabIndex = 10;
            _menuStrip.Text = "menuStrip1";
            _menuStrip.Visible = false;
            // 
            // _dummyMenuItem
            // 
            _dummyMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _importMenuItem, _exportMenuItem, _findMenuItem, _findNextMenuItem });
            _dummyMenuItem.Name = "_dummyMenuItem";
            _dummyMenuItem.Size = new Size(196, 33);
            _dummyMenuItem.Text = "{dummy_for_shorcut_keys}";
            // 
            // _importMenuItem
            // 
            _importMenuItem.Name = "_importMenuItem";
            _importMenuItem.ShortcutKeys = Keys.Control | Keys.I;
            _importMenuItem.Size = new Size(185, 26);
            _importMenuItem.Text = "import";
            _importMenuItem.Click += _importMenuItem_Click;
            // 
            // _exportMenuItem
            // 
            _exportMenuItem.Name = "_exportMenuItem";
            _exportMenuItem.ShortcutKeys = Keys.Control | Keys.E;
            _exportMenuItem.Size = new Size(185, 26);
            _exportMenuItem.Text = "export";
            _exportMenuItem.Click += _exportMenuItem_Click;
            // 
            // _findMenuItem
            // 
            _findMenuItem.Name = "_findMenuItem";
            _findMenuItem.ShortcutKeys = Keys.Control | Keys.F;
            _findMenuItem.Size = new Size(185, 26);
            _findMenuItem.Text = "find";
            _findMenuItem.Click += _findMenuItem_Click;
            // 
            // _findNextMenuItem
            // 
            _findNextMenuItem.Name = "_findNextMenuItem";
            _findNextMenuItem.ShortcutKeys = Keys.F3;
            _findNextMenuItem.Size = new Size(185, 26);
            _findNextMenuItem.Text = "find_next";
            _findNextMenuItem.Click += _findNextMenuItem_Click;
            // 
            // workingDataComboBox
            // 
            workingDataComboBox.FormattingEnabled = true;
            workingDataComboBox.Location = new Point(352, 17);
            workingDataComboBox.Margin = new Padding(2);
            workingDataComboBox.Name = "workingDataComboBox";
            workingDataComboBox.Size = new Size(474, 28);
            workingDataComboBox.TabIndex = 0;
            workingDataComboBox.Visible = false;
            workingDataComboBox.SelectedIndexChanged += workingDataComboBox_SelectedIndexChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(887, 761);
            Controls.Add(workingDataComboBox);
            Controls.Add(_splitContainerViewer);
            Controls.Add(_toolStrip);
            Controls.Add(_menuStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = _menuStrip;
            Margin = new Padding(4, 5, 4, 5);
            Name = "MainForm";
            Text = "ADAPT - Visualizer";
            WindowState = FormWindowState.Maximized;
            FormClosed += MainForm_FormClosed;
            Load += MainForm_Load;
            LocationChanged += MainForm_LocationChanged;
            SizeChanged += MainForm_SizeChanged;
            _splitContainerViewer.Panel1.ResumeLayout(false);
            _splitContainerViewer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_splitContainerViewer).EndInit();
            _splitContainerViewer.ResumeLayout(false);
            _splitContainerMap.Panel1.ResumeLayout(false);
            _splitContainerMap.Panel1.PerformLayout();
            _splitContainerMap.Panel2.ResumeLayout(false);
            _splitContainerMap.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_splitContainerMap).EndInit();
            _splitContainerMap.ResumeLayout(false);
            _tabControlViewer.ResumeLayout(false);
            _tabPageRawData.ResumeLayout(false);
            _tableLayoutPanelRawData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dataGridViewRawData).EndInit();
            _limitDataPanel.ResumeLayout(false);
            _limitDataPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_maxRowsNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)_maxColumnsNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)_dataGridViewTotals).EndInit();
            _toolStrip.ResumeLayout(false);
            _toolStrip.PerformLayout();
            _menuStrip.ResumeLayout(false);
            _menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private SplitContainer _splitContainerViewer;
        private TreeView _treeViewMetadata;
        private SplitContainer _splitContainerMap;
        private TabControl _tabControlViewer;
        private TabPage _tabPageSpatial;
        private TabPage _tabPageRawData;
        private Button _buttonExportRawData;
        private DataGridView _dataGridViewRawData;
        private DataGridView _dataGridViewTotals;
        private DataGridViewTextBoxColumn _dataGridColumnDescription;
        private DataGridViewTextBoxColumn _dataGridColumnValue;
        private Label _labelTotals;
        private ToolStripButton _importToolStripButton;
        private ToolStrip _toolStrip;
        private ToolStripButton _findToolStripButton;
        private ToolStripButton _aboutToolStripButton;
        private MenuStrip _menuStrip;
        private ToolStripMenuItem _dummyMenuItem;
        private ToolStripMenuItem _importMenuItem;
        private ToolStripMenuItem _exportMenuItem;
        private ToolStripMenuItem _findMenuItem;
        private ToolStripMenuItem _findNextMenuItem;
        private ToolStripButton _exportToolStripButton;
        private ComboBox workingDataComboBox;
        private CheckBox _limitDataCheckBox;
        private TableLayoutPanel _limitDataPanel;
        private Label _maxRowsLabel;
        private Label _maxColumnsLabel;
        private NumericUpDown _maxRowsNumericUpDown;
        private NumericUpDown _maxColumnsNumericUpDown;
        private ToolStripButton _settingsToolStripButton;
        private TableLayoutPanel _tableLayoutPanelRawData;
    }
}

