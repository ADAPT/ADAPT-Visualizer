namespace AgGateway.ADAPT.Visualizer.UI
{
    partial class SettingsForm
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
            _showLimitDataUICheckBox = new CheckBox();
            _mainTableLayoutPanel = new TableLayoutPanel();
            _okButton = new Button();
            _cancelButton = new Button();
            _rememberWindowSettingsCheckBox = new CheckBox();
            _propsFileExtensionTableLayoutPanel = new TableLayoutPanel();
            _propsFileExtensionLabel = new Label();
            _propsFileExtensionTextBox = new TextBox();
            _mainTableLayoutPanel.SuspendLayout();
            _propsFileExtensionTableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // _showLimitDataUICheckBox
            // 
            _showLimitDataUICheckBox.AutoSize = true;
            _mainTableLayoutPanel.SetColumnSpan(_showLimitDataUICheckBox, 2);
            _showLimitDataUICheckBox.Location = new Point(6, 6);
            _showLimitDataUICheckBox.Margin = new Padding(6);
            _showLimitDataUICheckBox.Name = "_showLimitDataUICheckBox";
            _showLimitDataUICheckBox.Size = new Size(158, 24);
            _showLimitDataUICheckBox.TabIndex = 0;
            _showLimitDataUICheckBox.Text = "Show Limit Data UI";
            _showLimitDataUICheckBox.UseVisualStyleBackColor = true;
            // 
            // _mainTableLayoutPanel
            // 
            _mainTableLayoutPanel.AutoSize = true;
            _mainTableLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            _mainTableLayoutPanel.ColumnCount = 2;
            _mainTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            _mainTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            _mainTableLayoutPanel.Controls.Add(_showLimitDataUICheckBox, 0, 0);
            _mainTableLayoutPanel.Controls.Add(_okButton, 0, 3);
            _mainTableLayoutPanel.Controls.Add(_cancelButton, 1, 3);
            _mainTableLayoutPanel.Controls.Add(_rememberWindowSettingsCheckBox, 0, 1);
            _mainTableLayoutPanel.Controls.Add(_propsFileExtensionTableLayoutPanel, 0, 2);
            _mainTableLayoutPanel.Location = new Point(12, 12);
            _mainTableLayoutPanel.Margin = new Padding(12);
            _mainTableLayoutPanel.Name = "_mainTableLayoutPanel";
            _mainTableLayoutPanel.RowCount = 4;
            _mainTableLayoutPanel.RowStyles.Add(new RowStyle());
            _mainTableLayoutPanel.RowStyles.Add(new RowStyle());
            _mainTableLayoutPanel.RowStyles.Add(new RowStyle());
            _mainTableLayoutPanel.RowStyles.Add(new RowStyle());
            _mainTableLayoutPanel.Size = new Size(392, 166);
            _mainTableLayoutPanel.TabIndex = 1;
            // 
            // _okButton
            // 
            _okButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _okButton.Location = new Point(96, 131);
            _okButton.Margin = new Padding(6, 20, 6, 6);
            _okButton.Name = "_okButton";
            _okButton.Size = new Size(94, 29);
            _okButton.TabIndex = 1;
            _okButton.Text = "OK";
            _okButton.UseVisualStyleBackColor = true;
            _okButton.Click += _okButton_Click;
            // 
            // _cancelButton
            // 
            _cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _cancelButton.Location = new Point(202, 131);
            _cancelButton.Margin = new Padding(6, 20, 6, 6);
            _cancelButton.Name = "_cancelButton";
            _cancelButton.Size = new Size(94, 29);
            _cancelButton.TabIndex = 2;
            _cancelButton.Text = "Cancel";
            _cancelButton.UseVisualStyleBackColor = true;
            // 
            // _rememberWindowSettingsCheckBox
            // 
            _rememberWindowSettingsCheckBox.AutoSize = true;
            _mainTableLayoutPanel.SetColumnSpan(_rememberWindowSettingsCheckBox, 2);
            _rememberWindowSettingsCheckBox.Location = new Point(6, 42);
            _rememberWindowSettingsCheckBox.Margin = new Padding(6);
            _rememberWindowSettingsCheckBox.Name = "_rememberWindowSettingsCheckBox";
            _rememberWindowSettingsCheckBox.Size = new Size(220, 24);
            _rememberWindowSettingsCheckBox.TabIndex = 3;
            _rememberWindowSettingsCheckBox.Text = "Remember Window Settings";
            _rememberWindowSettingsCheckBox.UseVisualStyleBackColor = true;
            // 
            // _propsFileExtensionTableLayoutPanel
            // 
            _propsFileExtensionTableLayoutPanel.AutoSize = true;
            _propsFileExtensionTableLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            _propsFileExtensionTableLayoutPanel.ColumnCount = 2;
            _mainTableLayoutPanel.SetColumnSpan(_propsFileExtensionTableLayoutPanel, 2);
            _propsFileExtensionTableLayoutPanel.ColumnStyles.Add(new ColumnStyle());
            _propsFileExtensionTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            _propsFileExtensionTableLayoutPanel.Controls.Add(_propsFileExtensionLabel, 0, 0);
            _propsFileExtensionTableLayoutPanel.Controls.Add(_propsFileExtensionTextBox, 1, 0);
            _propsFileExtensionTableLayoutPanel.Location = new Point(3, 75);
            _propsFileExtensionTableLayoutPanel.Name = "_propsFileExtensionTableLayoutPanel";
            _propsFileExtensionTableLayoutPanel.RowCount = 1;
            _propsFileExtensionTableLayoutPanel.RowStyles.Add(new RowStyle());
            _propsFileExtensionTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            _propsFileExtensionTableLayoutPanel.Size = new Size(296, 33);
            _propsFileExtensionTableLayoutPanel.TabIndex = 4;
            // 
            // _propsFileExtensionLabel
            // 
            _propsFileExtensionLabel.Anchor = AnchorStyles.Left;
            _propsFileExtensionLabel.AutoSize = true;
            _propsFileExtensionLabel.Location = new Point(3, 6);
            _propsFileExtensionLabel.Name = "_propsFileExtensionLabel";
            _propsFileExtensionLabel.Size = new Size(159, 20);
            _propsFileExtensionLabel.TabIndex = 0;
            _propsFileExtensionLabel.Text = "Property File Extension";
            // 
            // _propsFileExtensionTextBox
            // 
            _propsFileExtensionTextBox.Anchor = AnchorStyles.Left;
            _propsFileExtensionTextBox.Location = new Point(168, 3);
            _propsFileExtensionTextBox.Name = "_propsFileExtensionTextBox";
            _propsFileExtensionTextBox.Size = new Size(125, 27);
            _propsFileExtensionTextBox.TabIndex = 1;
            // 
            // SettingsForm
            // 
            AcceptButton = _okButton;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            CancelButton = _cancelButton;
            ClientSize = new Size(572, 278);
            ControlBox = false;
            Controls.Add(_mainTableLayoutPanel);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
            FormClosed += SettingsForm_FormClosed;
            _mainTableLayoutPanel.ResumeLayout(false);
            _mainTableLayoutPanel.PerformLayout();
            _propsFileExtensionTableLayoutPanel.ResumeLayout(false);
            _propsFileExtensionTableLayoutPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel _propsFileExtensionTableLayoutPanel;
        private TableLayoutPanel _mainTableLayoutPanel;
        private CheckBox _showLimitDataUICheckBox;
        private Button _okButton;
        private Button _cancelButton;
        private CheckBox _rememberWindowSettingsCheckBox;
        private Label _propsFileExtensionLabel;
        private TextBox _propsFileExtensionTextBox;
    }
}