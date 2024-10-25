using QL_tour_LTW.ModelQLTOUR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_tour_LTW
{
    public partial class DoiMatKhau : Form
    {
        private string tentaikhoan;
        public DoiMatKhau(string tentaikhoan)
        {
            InitializeComponent();
            this.tentaikhoan = tentaikhoan;
        }

        private void btnHUY_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DoiMatKhau_Load(object sender, EventArgs e)
        {
            txtTKNV.Texts = tentaikhoan;
            if(txtTKNV.Texts == "ADMIN" || txtTKNV.Texts == "admin")
            {
                lbVAITRO.Visible = true;
                cbbVAITRO.Visible = true;
            }
        }
        private int checktxt()
        {
            if(txtTKNV.Texts =="" || txtMATKHAUMOI.Texts == ""|| txtXACNHANMATKHAU.Texts == "" || txtMATKHAUCU.Texts == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 1;
            }
            return 4;
        }
        private bool checkmkcu()
        {
            QLTOURDBContext context = new QLTOURDBContext();
            TKUSER capnhat = context.TKUSERs.FirstOrDefault(s => s.TENTAIKHOAN == tentaikhoan && s.MATKHAU == txtMATKHAUCU.Texts);
            if( capnhat != null)
            {
                return true;
            }
            return false;
        }
        private bool checkxacnhanmk()
        {
            if (txtMATKHAUMOI.Texts == txtXACNHANMATKHAU.Texts)
            {               
                return true;
            }
            return false;
        }
        private void reset()
        {
            txtXACNHANMATKHAU.Texts = txtMATKHAUMOI.Texts = txtMATKHAUCU.Texts = string.Empty;
        }
        private void btnLUU_Click(object sender, EventArgs e)
        {
            int check = checktxt();
            if(check == 4)
            {
                if(checkmkcu()== true)
                {
                    if (checkxacnhanmk() == true)
                    {                     
                        if(correctCaptcha != null)
                        {
                            if (txtcapcha.Texts == correctCaptcha)
                            {
                                if (tentaikhoan != "ADMIN" || tentaikhoan != "admin")
                                {
                                    QLTOURDBContext context = new QLTOURDBContext();
                                    TKUSER capnhat = context.TKUSERs.FirstOrDefault(s => s.TENTAIKHOAN == tentaikhoan && s.VAITRO == null);
                                    if (capnhat != null)
                                    {
                                        capnhat.TENTAIKHOAN = tentaikhoan;
                                        capnhat.MATKHAU = txtMATKHAUMOI.Texts;
                                        capnhat.VAITRO = null;
                                        capnhat.ANH = null;
                                        context.SaveChanges();
                                        MessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        reset();
                                    }
                                }
                                else
                                {
                                    lbVAITRO.Visible = true;
                                    cbbVAITRO.Visible = true;
                                    if (cbbVAITRO.Text != "ADMIN")
                                    {
                                        MessageBox.Show("Bạn chưa chọn vai trò", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                    else
                                    {
                                        QLTOURDBContext context = new QLTOURDBContext();
                                        TKUSER capnhat = context.TKUSERs.FirstOrDefault(s => s.TENTAIKHOAN == tentaikhoan && s.MAVAITRO == "ADMIN");
                                        if (capnhat != null)
                                        {
                                            capnhat.TENTAIKHOAN = tentaikhoan;
                                            capnhat.MATKHAU = txtMATKHAUMOI.Texts;
                                            capnhat.VAITRO = null;
                                            capnhat.ANH = null;
                                            context.SaveChanges();
                                            MessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            reset();
                                        }
                                    }

                                }
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
                            MessageBox.Show("Nhập mã xác thực trước khi lưu thông tin!", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtcapcha.Select();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu xác nhận không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtXACNHANMATKHAU.Select();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu cũ không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMATKHAUCU.Select();
                    return;
                }            
            }
            else
            {
                MessageBox.Show("Thiếu thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtTKNV_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (e.KeyChar == 22) // 22 là mã ASCII của ký tự Ctrl + V
            {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == ' ')
            {
                e.Handled = true; // Loại bỏ ký tự khoảng trắng
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
        private void txtMATKHAUCU_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtXACNHANMATKHAU_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cbbVAITRO_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnLUU_MouseDown(object sender, MouseEventArgs e)
        {
            btnLUU.BorderSize = 2;
            btnLUU.BorderColor = Color.MidnightBlue;
        }

        private void btnLUU_MouseUp(object sender, MouseEventArgs e)
        {
            btnLUU.BorderSize = 0;
        }

        private void btnHUY_MouseDown(object sender, MouseEventArgs e)
        {
            btnHUY.BorderSize = 2;
            btnHUY.BorderColor = Color.MidnightBlue;
        }

        private void btnHUY_MouseUp(object sender, MouseEventArgs e)
        {
            btnLUU.BorderSize = 0;
        }

        private void txtTKNV_Enter(object sender, EventArgs e)
        {
            txtTKNV.BackColor = Color.Gainsboro;
        }

        private void txtTKNV_Leave(object sender, EventArgs e)
        {
            txtTKNV.BackColor = Color.White;
        }

        private void txtMATKHAUCU_Enter(object sender, EventArgs e)
        {
            txtMATKHAUCU.BackColor = Color.Gainsboro;
        }

        private void txtMATKHAUCU_Leave(object sender, EventArgs e)
        {
            txtMATKHAUCU.BackColor = Color.White;
        }

        private void txtMATKHAUMOI_Enter(object sender, EventArgs e)
        {
            txtMATKHAUMOI.BackColor = Color.Gainsboro;
        }

        private void txtMATKHAUMOI_Leave(object sender, EventArgs e)
        {
            txtMATKHAUMOI.BackColor = Color.White;
        }

        private void txtXACNHANMATKHAU_Enter(object sender, EventArgs e)
        {
            txtXACNHANMATKHAU.BackColor = Color.Gainsboro;
        }

        private void txtXACNHANMATKHAU_Leave(object sender, EventArgs e)
        {
            txtXACNHANMATKHAU.BackColor = Color.White;
        }
        private string correctCaptcha;
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
        private void bntcapcha_Click(object sender, EventArgs e)
        {
            GenerateCaptcha();
        }

        private void bunifuCards1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtcapcha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (IsDiacritic(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
