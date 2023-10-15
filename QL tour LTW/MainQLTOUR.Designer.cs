namespace QL_tour_LTW
{
    partial class MainQLTOUR
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainQLTOUR));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelLoadFormTOUR = new System.Windows.Forms.Panel();
            this.panelLinkLabel = new System.Windows.Forms.Panel();
            this.lbCACH = new System.Windows.Forms.Label();
            this.linklbThemTOUR = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.panelLinkLabel.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("flowLayoutPanel1.BackgroundImage")));
            this.flowLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1223, 27);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panelLoadFormTOUR
            // 
            this.panelLoadFormTOUR.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelLoadFormTOUR.Location = new System.Drawing.Point(0, 30);
            this.panelLoadFormTOUR.Name = "panelLoadFormTOUR";
            this.panelLoadFormTOUR.Size = new System.Drawing.Size(1220, 680);
            this.panelLoadFormTOUR.TabIndex = 2;
            this.panelLoadFormTOUR.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.panelLoadFormTOUR_ControlAdded);
            // 
            // panelLinkLabel
            // 
            this.panelLinkLabel.Controls.Add(this.lbCACH);
            this.panelLinkLabel.Controls.Add(this.linklbThemTOUR);
            this.panelLinkLabel.Controls.Add(this.linkLabel1);
            this.panelLinkLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLinkLabel.Location = new System.Drawing.Point(0, 27);
            this.panelLinkLabel.Name = "panelLinkLabel";
            this.panelLinkLabel.Size = new System.Drawing.Size(1223, 30);
            this.panelLinkLabel.TabIndex = 3;
            // 
            // lbCACH
            // 
            this.lbCACH.AutoSize = true;
            this.lbCACH.Font = new System.Drawing.Font("Segoe UI Black", 11.25F, System.Drawing.FontStyle.Bold);
            this.lbCACH.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lbCACH.Location = new System.Drawing.Point(142, 4);
            this.lbCACH.Name = "lbCACH";
            this.lbCACH.Size = new System.Drawing.Size(16, 20);
            this.lbCACH.TabIndex = 1;
            this.lbCACH.Text = "/";
            this.lbCACH.Visible = false;
            // 
            // linklbThemTOUR
            // 
            this.linklbThemTOUR.AutoSize = true;
            this.linklbThemTOUR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linklbThemTOUR.Font = new System.Drawing.Font("Segoe UI Black", 11.25F, System.Drawing.FontStyle.Bold);
            this.linklbThemTOUR.ForeColor = System.Drawing.Color.Black;
            this.linklbThemTOUR.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linklbThemTOUR.LinkColor = System.Drawing.Color.MidnightBlue;
            this.linklbThemTOUR.Location = new System.Drawing.Point(156, 5);
            this.linklbThemTOUR.Name = "linklbThemTOUR";
            this.linklbThemTOUR.Size = new System.Drawing.Size(90, 20);
            this.linklbThemTOUR.TabIndex = 0;
            this.linklbThemTOUR.TabStop = true;
            this.linklbThemTOUR.Text = "Thêm Tour";
            this.linklbThemTOUR.Visible = false;
            this.linklbThemTOUR.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklbThemTOUR_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkLabel1.Font = new System.Drawing.Font("Segoe UI Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel1.LinkColor = System.Drawing.Color.MidnightBlue;
            this.linkLabel1.Location = new System.Drawing.Point(3, 5);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(142, 20);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "THÔNG TIN TOUR";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked_1);
            // 
            // MainQLTOUR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 710);
            this.Controls.Add(this.panelLinkLabel);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panelLoadFormTOUR);
            this.Name = "MainQLTOUR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainQLTOUR";
            this.Load += new System.EventHandler(this.MainQLTOUR_Load);
            this.panelLinkLabel.ResumeLayout(false);
            this.panelLinkLabel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panelLoadFormTOUR;
        private System.Windows.Forms.Panel panelLinkLabel;
        private System.Windows.Forms.LinkLabel linkLabel1;
        public System.Windows.Forms.Label lbCACH;
        public System.Windows.Forms.LinkLabel linklbThemTOUR;
    }
}