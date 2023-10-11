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
            showLimitDataUICheckBox = new CheckBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            okButton = new Button();
            cancelButton = new Button();
            rememberWindowSettingsCheckBox = new CheckBox();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // showLimitDataUICheckBox
            // 
            showLimitDataUICheckBox.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(showLimitDataUICheckBox, 2);
            showLimitDataUICheckBox.Location = new Point(6, 6);
            showLimitDataUICheckBox.Margin = new Padding(6);
            showLimitDataUICheckBox.Name = "showLimitDataUICheckBox";
            showLimitDataUICheckBox.Size = new Size(158, 24);
            showLimitDataUICheckBox.TabIndex = 0;
            showLimitDataUICheckBox.Text = "Show Limit Data UI";
            showLimitDataUICheckBox.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(showLimitDataUICheckBox, 0, 0);
            tableLayoutPanel1.Controls.Add(okButton, 0, 2);
            tableLayoutPanel1.Controls.Add(cancelButton, 1, 2);
            tableLayoutPanel1.Controls.Add(rememberWindowSettingsCheckBox, 0, 1);
            tableLayoutPanel1.Location = new Point(12, 12);
            tableLayoutPanel1.Margin = new Padding(12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(252, 127);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // okButton
            // 
            okButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            okButton.Location = new Point(26, 92);
            okButton.Margin = new Padding(6, 20, 6, 6);
            okButton.Name = "okButton";
            okButton.Size = new Size(94, 29);
            okButton.TabIndex = 1;
            okButton.Text = "OK";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cancelButton.Location = new Point(132, 92);
            cancelButton.Margin = new Padding(6, 20, 6, 6);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(94, 29);
            cancelButton.TabIndex = 2;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // rememberWindowSettingsCheckBox
            // 
            rememberWindowSettingsCheckBox.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(rememberWindowSettingsCheckBox, 2);
            rememberWindowSettingsCheckBox.Location = new Point(6, 42);
            rememberWindowSettingsCheckBox.Margin = new Padding(6);
            rememberWindowSettingsCheckBox.Name = "rememberWindowSettingsCheckBox";
            rememberWindowSettingsCheckBox.Size = new Size(220, 24);
            rememberWindowSettingsCheckBox.TabIndex = 3;
            rememberWindowSettingsCheckBox.Text = "Remember Window Settings";
            rememberWindowSettingsCheckBox.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            AcceptButton = okButton;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            CancelButton = cancelButton;
            ClientSize = new Size(572, 278);
            ControlBox = false;
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
            FormClosed += SettingsForm_FormClosed;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox showLimitDataUICheckBox;
        private TableLayoutPanel tableLayoutPanel1;
        private Button okButton;
        private Button cancelButton;
        private CheckBox rememberWindowSettingsCheckBox;
    }
}