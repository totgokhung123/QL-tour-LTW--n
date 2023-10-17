using Microsoft.Win32;
using QL_tour_LTW.ModelQLTOUR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
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
        private UserCredentials GetSavedUserCredentials()
        {
            UserCredentials credentials = null;

            // Đường dẫn trong Registry để lưu trữ thông tin người dùng
            const string registryPath = "Software\\MyApp";

            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(registryPath))
                {
                    if (key != null)
                    {
                        // Đọc thông tin người dùng từ Registry
                        string username = key.GetValue("Username") as string;
                        string password = key.GetValue("Password") as string;

                        if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                        {
                            // Tạo đối tượng UserCredentials từ thông tin đọc được
                            credentials = new UserCredentials
                            {
                                Username = username,
                                Password = password
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu cần thiết
                Console.WriteLine("Lỗi khi truy xuất thông tin người dùng: " + ex.Message);
            }

            return credentials;
        }
        private bool GetRememberPasswordStatus()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\YourAppName"))
            {
                if (key != null)
                {
                    object rememberPassword = key.GetValue("RememberPassword");
                    if (rememberPassword != null && rememberPassword is int)
                    {
                        return (int)rememberPassword == 1;
                    }
                }
            }

            return false;
        }
        private void GIAODIENDANGNHAP_Load(object sender, EventArgs e)
        {

            bool rememberPassword = GetRememberPasswordStatus();
            ckbNHOMATKHAU.Checked = rememberPassword;

            if (rememberPassword)
            {
                // Nếu checkbox đã được chọn, lấy thông tin đăng nhập đã lưu
                UserCredentials savedCredentials = GetSavedUserCredentials();
                if (savedCredentials != null)
                {
                    txtTAIKHOAN.Text = savedCredentials.Username;
                    txtMATKHAU.Text = savedCredentials.Password;

                }
            }
            ckbNHOMATKHAU.Checked = false;
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
        private bool IsDiacritic(char c)
        {
            string normalizedText = c.ToString().Normalize(NormalizationForm.FormD);
            foreach (char ch in normalizedText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(ch) == UnicodeCategory.NonSpacingMark)
                {
                    return true;
                }
            }
            return false;
        }
        private void txtMATKHAU_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 22) // 22 là mã ASCII của ký tự Ctrl + V
            {
                e.Handled = true;
                return;
            }
            if (IsDiacritic(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTAIKHOAN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true; // Loại bỏ ký tự khoảng trắng
            }
            if (IsDiacritic(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void linkLblQUENMATKHAU_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            QuenMATKHAU f = new QuenMATKHAU();
            f.ShowDialog();
        }

        private void ckbNHOMATKHAU_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void SaveUserCredentials(string username, string password)
        {
            // Đường dẫn trong Registry để lưu trữ thông tin người dùng
            const string registryPath = "Software\\MyApp";

            try
            {
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(registryPath))
                {
                    if (key != null)
                    {
                        // Lưu thông tin người dùng vào Registry
                        key.SetValue("Username", username);
                        key.SetValue("Password", password);
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu cần thiết
                Console.WriteLine("Lỗi khi lưu thông tin người dùng: " + ex.Message);
            }
        }
        private void ClearUserCredentials()
        {
            // Đường dẫn trong Registry để lưu trữ thông tin người dùng
            const string registryPath = "Software\\MyApp";

            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(registryPath, true))
                {
                    if (key != null)
                    {
                        // Xóa khóa con và tất cả giá trị bên trong
                        key.DeleteSubKeyTree("");
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu cần thiết
                Console.WriteLine("Lỗi khi xóa thông tin người dùng: " + ex.Message);
            }
        }
        private void ckbNHOMATKHAU_Click(object sender, EventArgs e)
        {
            if (ckbNHOMATKHAU.Checked)
            {
                // Nếu checkbox "Nhớ mật khẩu" được chọn, lưu thông tin đăng nhập
                SaveUserCredentials(txtTAIKHOAN.Text, txtMATKHAU.Text);
            }
            else
            {
                // Nếu checkbox không được chọn, xóa thông tin đăng nhập đã lưu
                ClearUserCredentials();
            }
        }
    }
}
