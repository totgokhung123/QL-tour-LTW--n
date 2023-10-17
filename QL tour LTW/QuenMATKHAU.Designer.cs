namespace QL_tour_LTW
{
    partial class QuenMATKHAU
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
            this.picCaptcha = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtCaptcha = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtkiemtramacapcha = new System.Windows.Forms.TextBox();
            this.btnkiemtra = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picCaptcha)).BeginInit();
            this.SuspendLayout();
            // 
            // picCaptcha
            // 
            this.picCaptcha.Location = new System.Drawing.Point(478, 111);
            this.picCaptcha.Name = "picCaptcha";
            this.picCaptcha.Size = new System.Drawing.Size(286, 201);
            this.picCaptcha.TabIndex = 0;
            this.picCaptcha.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(56, 178);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 83);
            this.button1.TabIndex = 1;
            this.button1.Text = "Lấy mã capcha";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtCaptcha
            // 
            this.txtCaptcha.Location = new System.Drawing.Point(193, 210);
            this.txtCaptcha.Name = "txtCaptcha";
            this.txtCaptcha.Size = new System.Drawing.Size(255, 20);
            this.txtCaptcha.TabIndex = 2;
            this.txtCaptcha.TextChanged += new System.EventHandler(this.txtCaptcha_TextChanged);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(193, 67);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(255, 20);
            this.txtEmail.TabIndex = 2;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtCaptcha_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(118, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "ten tài khoản";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(118, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "mật khẩu mới";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "xác nhận mật khẩu mới";
            // 
            // txtkiemtramacapcha
            // 
            this.txtkiemtramacapcha.Location = new System.Drawing.Point(179, 292);
            this.txtkiemtramacapcha.Name = "txtkiemtramacapcha";
            this.txtkiemtramacapcha.Size = new System.Drawing.Size(255, 20);
            this.txtkiemtramacapcha.TabIndex = 2;
            this.txtkiemtramacapcha.TextChanged += new System.EventHandler(this.txtCaptcha_TextChanged);
            // 
            // btnkiemtra
            // 
            this.btnkiemtra.Location = new System.Drawing.Point(98, 292);
            this.btnkiemtra.Name = "btnkiemtra";
            this.btnkiemtra.Size = new System.Drawing.Size(75, 23);
            this.btnkiemtra.TabIndex = 4;
            this.btnkiemtra.Text = "kiểm tra";
            this.btnkiemtra.UseVisualStyleBackColor = true;
            this.btnkiemtra.Click += new System.EventHandler(this.btnkiemtra_Click);
            // 
            // QuenMATKHAU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 537);
            this.Controls.Add(this.btnkiemtra);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtkiemtramacapcha);
            this.Controls.Add(this.txtCaptcha);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.picCaptcha);
            this.Name = "QuenMATKHAU";
            this.Text = "QuenMATKHAU";
            this.Load += new System.EventHandler(this.QuenMATKHAU_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCaptcha)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCaptcha;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtCaptcha;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtkiemtramacapcha;
        private System.Windows.Forms.Button btnkiemtra;
    }
}