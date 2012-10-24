namespace RossCode.SkypeLight.UI
{
    partial class CallStatusForm
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
            this.pbCallStatus = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbCallStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCallStatus
            // 
            this.pbCallStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbCallStatus.Location = new System.Drawing.Point(0, 0);
            this.pbCallStatus.Name = "pbCallStatus";
            this.pbCallStatus.Size = new System.Drawing.Size(284, 262);
            this.pbCallStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCallStatus.TabIndex = 0;
            this.pbCallStatus.TabStop = false;
            // 
            // CallStatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.pbCallStatus);
            this.Name = "CallStatusForm";
            this.Text = "SkypeLight";
            ((System.ComponentModel.ISupportInitialize)(this.pbCallStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbCallStatus;
    }
}

