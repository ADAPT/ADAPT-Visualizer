namespace AgGateway.ADAPT.Visualizer.UI
{
    partial class ValidateForm
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
            this._validationListView = new System.Windows.Forms.ListView();
            this._errorsLabel = new System.Windows.Forms.Label();
            this.Error = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // _validationListView
            // 
            this._validationListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Error});
            this._validationListView.Location = new System.Drawing.Point(32, 52);
            this._validationListView.Name = "_validationListView";
            this._validationListView.Size = new System.Drawing.Size(1739, 801);
            this._validationListView.TabIndex = 0;
            this._validationListView.UseCompatibleStateImageBehavior = false;
            this._validationListView.View = System.Windows.Forms.View.List;
            // 
            // _errorsLabel
            // 
            this._errorsLabel.AutoSize = true;
            this._errorsLabel.Location = new System.Drawing.Point(27, 13);
            this._errorsLabel.Name = "_errorsLabel";
            this._errorsLabel.Size = new System.Drawing.Size(70, 25);
            this._errorsLabel.TabIndex = 1;
            this._errorsLabel.Text = "Errors";
            // 
            // Error
            // 
            this.Error.Width = 705;
            // 
            // ValidateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1808, 885);
            this.Controls.Add(this._errorsLabel);
            this.Controls.Add(this._validationListView);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ValidateForm";
            this.ShowIcon = false;
            this.Text = "Validate Data On Card";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView _validationListView;
        private System.Windows.Forms.Label _errorsLabel;
        private System.Windows.Forms.ColumnHeader Error;
    }
}