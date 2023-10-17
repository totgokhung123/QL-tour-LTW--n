namespace QL_tour_LTW
{
    partial class InHoaDon
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
            this.rpvInHD = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpvInHD
            // 
            this.rpvInHD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvInHD.LocalReport.ReportEmbeddedResource = "QL_tour_LTW.ReportInHoaDon.rdlc";
            this.rpvInHD.Location = new System.Drawing.Point(0, 0);
            this.rpvInHD.Name = "rpvInHD";
            this.rpvInHD.ServerReport.BearerToken = null;
            this.rpvInHD.Size = new System.Drawing.Size(891, 609);
            this.rpvInHD.TabIndex = 0;
            // 
            // InHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 609);
            this.Controls.Add(this.rpvInHD);
            this.Name = "InHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InHoaDon";
            this.Load += new System.EventHandler(this.InHoaDon_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvInHD;
    }
}