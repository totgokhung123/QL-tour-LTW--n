namespace QL_tour_LTW
{
    partial class GiaoDienQLThongTInKH
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNgangCach = new System.Windows.Forms.Label();
            this.linklblThemKH = new System.Windows.Forms.LinkLabel();
            this.linklblTHONGTINKH = new System.Windows.Forms.LinkLabel();
            this.panelLoadFormKH = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackgroundImage = global::QL_tour_LTW.Properties.Resources.backgroundcolor;
            this.flowLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1187, 36);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lblNgangCach);
            this.panel1.Controls.Add(this.linklblThemKH);
            this.panel1.Controls.Add(this.linklblTHONGTINKH);
            this.panel1.Location = new System.Drawing.Point(0, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1187, 42);
            this.panel1.TabIndex = 1;
            // 
            // lblNgangCach
            // 
            this.lblNgangCach.AutoSize = true;
            this.lblNgangCach.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgangCach.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblNgangCach.Location = new System.Drawing.Point(288, 3);
            this.lblNgangCach.Name = "lblNgangCach";
            this.lblNgangCach.Size = new System.Drawing.Size(24, 31);
            this.lblNgangCach.TabIndex = 1;
            this.lblNgangCach.Text = "/";
            // 
            // linklblThemKH
            // 
            this.linklblThemKH.AutoSize = true;
            this.linklblThemKH.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linklblThemKH.ForeColor = System.Drawing.Color.MidnightBlue;
            this.linklblThemKH.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linklblThemKH.LinkColor = System.Drawing.Color.MidnightBlue;
            this.linklblThemKH.Location = new System.Drawing.Point(303, 3);
            this.linklblThemKH.Name = "linklblThemKH";
            this.linklblThemKH.Size = new System.Drawing.Size(210, 31);
            this.linklblThemKH.TabIndex = 0;
            this.linklblThemKH.TabStop = true;
            this.linklblThemKH.Text = "Thêm Khách Hàng";
            // 
            // linklblTHONGTINKH
            // 
            this.linklblTHONGTINKH.AutoSize = true;
            this.linklblTHONGTINKH.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linklblTHONGTINKH.ForeColor = System.Drawing.Color.MidnightBlue;
            this.linklblTHONGTINKH.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linklblTHONGTINKH.LinkColor = System.Drawing.Color.MidnightBlue;
            this.linklblTHONGTINKH.Location = new System.Drawing.Point(13, 3);
            this.linklblTHONGTINKH.Name = "linklblTHONGTINKH";
            this.linklblTHONGTINKH.Size = new System.Drawing.Size(259, 31);
            this.linklblTHONGTINKH.TabIndex = 0;
            this.linklblTHONGTINKH.TabStop = true;
            this.linklblTHONGTINKH.Text = "Thông Tin Khách Hàng";
            this.linklblTHONGTINKH.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblTHONGTINKH_LinkClicked);
            // 
            // panelLoadFormKH
            // 
            this.panelLoadFormKH.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelLoadFormKH.Location = new System.Drawing.Point(0, 84);
            this.panelLoadFormKH.Name = "panelLoadFormKH";
            this.panelLoadFormKH.Size = new System.Drawing.Size(1187, 618);
            this.panelLoadFormKH.TabIndex = 2;
            // 
            // GiaoDienQLThongTInKH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 702);
            this.Controls.Add(this.panelLoadFormKH);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "GiaoDienQLThongTInKH";
            this.Text = "GiaoDienQLThongTInKH";
            this.Load += new System.EventHandler(this.GiaoDienQLThongTInKH_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel linklblTHONGTINKH;
        private System.Windows.Forms.Panel panelLoadFormKH;
        public System.Windows.Forms.LinkLabel linklblThemKH;
        public System.Windows.Forms.Label lblNgangCach;
    }
}