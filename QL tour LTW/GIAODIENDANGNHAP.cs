using QL_tour_LTW.ModelQLTOUR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_tour_LTW
{
    public partial class GIAODIENDANGNHAP : Form
    {
        public GIAODIENDANGNHAP()
        {
            InitializeComponent();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GIAODIENDANGNHAP_Load(object sender, EventArgs e)
        {
            
        }

        private void btnDANGNHAP_Click(object sender, EventArgs e)
        {
            string username = txtTAIKHOAN.Text;
            string password = txtMATKHAU.Text;
            //txttest.Text = username;

            if (Authenticate(username, password) == true)
            {
                this.Hide();
                Form1 mainForm = new Form1(username);
                mainForm.ShowDialog();
                this.Show();
                
            }
            else if (taikhoannhanvien(username, password) == true)
            {
                this.Hide();
                Form1 mainForm = new Form1(username);
                mainForm.btnDKTK.Enabled = false;
                mainForm.btnTHONGTINDV.Enabled = false;
                mainForm.btnTHONGTINNV.Enabled = false;
                mainForm.btnTHONGTINTOUR.Enabled = false;
                mainForm.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai mật khẩu hoặc tài khoản. Vui lòng thử lại sau!.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool Authenticate(string username, string password)
        {
            QLTOURDBContext context = new QLTOURDBContext();
            TKUSER timtkADMIN = context.TKUSERs.FirstOrDefault(s => s.TENTAIKHOAN == username && s.MATKHAU == password && s.VAITRO=="ADMIN");
            if (timtkADMIN != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool taikhoannhanvien(string username, string password)
        {
            // Kiểm tra tài khoản đăng nhập (username và password)
            QLTOURDBContext context = new QLTOURDBContext();            
            TKUSER timtk = context.TKUSERs.FirstOrDefault(s => s.TENTAIKHOAN== username && s.MATKHAU== password && s.VAITRO== null);
            if (timtk != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void linkLblDANGKY_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            DangKy f = new DangKy();
            f.ShowDialog();
            this.Show();
        }

        private void txtMATKHAU_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 22) // 22 là mã ASCII của ký tự Ctrl + V
            {
                e.Handled = true;
                return;
            }
        }

        private void txtTAIKHOAN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true; // Loại bỏ ký tự khoảng trắng
            }
        }
    }
}
