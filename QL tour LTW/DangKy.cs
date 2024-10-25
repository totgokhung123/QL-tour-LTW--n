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
using BotDetect.Web.UI;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Globalization;

namespace QL_tour_LTW
{
    public partial class DangKy : Form
    {
        private string correctCaptcha;
        public DangKy()
        {
            InitializeComponent();
        }
        private int checktrungtk(string tentk)
        {
            QLTOURDBContext context = new QLTOURDBContext();
            TKUSER tim = context.TKUSERs.FirstOrDefault(s => s.TENTAIKHOAN == tentk);
            if (tim != null)
            {
                return 4;
            }
            return 5;
        }
        private void checktxt()
        {
            if (txtTKMOI.Texts == "" || txtMATKHAUMOI.Texts == "" || txtXACNHANMATKHAUMOI.Texts =="")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if(txtMATKHAUMOI.Texts != txtXACNHANMATKHAUMOI.Texts)
                {
                    MessageBox.Show("xác nhận mật khẩu không đúng!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }
        private void themtk()
        {
            QLTOURDBContext context = new QLTOURDBContext();
            NHANVIEN laysdt = context.NHANVIENs.FirstOrDefault(s => s.SDT == txtTKMOI.Texts);
            NHANVIEN layemail = context.NHANVIENs.FirstOrDefault(s => s.EMAIL == txtTKMOI.Texts);


            //Phần mới dùng để TEST ĐĂNG KÝ
            TKUSER insert = new TKUSER
            {
                TENTAIKHOAN = txtTKMOI.Texts,
                MATKHAU = txtMATKHAUMOI.Texts,
                MAVAITRO = "CUSTOMER",
                ANH = null
            };
            context.TKUSERs.Add(insert);
            context.SaveChanges();
            MessageBox.Show("Thêm tài khoản thành công !", "Thông báo");
            cleartxt();


            //if(laysdt != null || layemail != null)
            //{
            //    TKUSER insert = new TKUSER
            //    {
            //        TENTAIKHOAN = txtTKMOI.Texts,
            //        MATKHAU = txtMATKHAUMOI.Texts,
            //        MAVAITRO = "CUSTOMER",
            //        ANH = null
            //    };
            //    context.TKUSERs.Add(insert);
            //    context.SaveChanges();
            //    MessageBox.Show("Thêm tài khoản thành công !", "Thông báo");
            //    cleartxt();
            //}
            //else
            //{
            //    MessageBox.Show("Chưa có thông tin của Nhân viên trong hệ thống!", "Thông báo");
            //    return;
            //}
        }
        private void cleartxt()
        {
            txtTKMOI.Texts = txtMATKHAUMOI.Texts = txtXACNHANMATKHAUMOI.Texts = string.Empty;
        }
        private void btnDANGKY_Click(object sender, EventArgs e)
        {
            try
            {
                checktxt();             
                int checktrung = checktrungtk(txtTKMOI.Texts);               
                if (checktrung == 5)
                {
                    if(correctCaptcha != null)
                    {
                        if (txtcapcha.Texts == correctCaptcha)
                        {
                            themtk();
                        }
                        else
                        {
                            MessageBox.Show("Sai mã Captcha mời bạn nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtcapcha.Select();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nhập mã xác thực trước khi đăng ký!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtcapcha.Select();
                        return;
                    }   
                }
                else
                {
                    // sua();
                    MessageBox.Show("Đã tồn tại tài khoản này!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTKMOI.Select();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DangKy_Load(object sender, EventArgs e)
        {
            
        }
        int number = 0;

        private void GenerateCaptcha()
        {
            // Tạo CAPTCHA ngẫu nhiên
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            correctCaptcha = new string(Enumerable.Repeat(chars, 6)
              .Select(s => s[random.Next(s.Length)]).ToArray());

            // Vẽ CAPTCHA lên PictureBox
            Bitmap bitmap = new Bitmap(picCaptcha.Width, picCaptcha.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.DrawString(correctCaptcha, new Font("Arial", 24), Brushes.Black, new PointF(0, 0));
            picCaptcha.Image = bitmap;
        }
        private void btnHUY_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bntcapcha_Click(object sender, EventArgs e)
        {
            GenerateCaptcha();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtTKMOI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true; // Loại bỏ ký tự khoảng trắng
            }
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
        private void txtMATKHAUMOI_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtXACNHANMATKHAUMOI_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtcapcha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(txtcapcha.Texts.Length > 7)
            {
                MessageBox.Show("Mã xác thực tối đa 7 ký tự!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (IsDiacritic(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
