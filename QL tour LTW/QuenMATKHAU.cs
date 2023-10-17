using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QL_tour_LTW.ModelQLTOUR;
using BotDetect.C5;
using static System.Net.WebRequestMethods;

namespace QL_tour_LTW
{
    public partial class QuenMATKHAU : Form
    {
        private string correctCaptcha;
        public QuenMATKHAU()
        {
            InitializeComponent();
        }

        private void QuenMATKHAU_Load(object sender, EventArgs e)
        {
            GenerateCaptcha();
        }
        private void GenerateCaptcha()
        {
            // Tạo CAPTCHA ngẫu nhiên
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            correctCaptcha = new string(Enumerable.Repeat(chars, 6)
              .Select(s => s[random.Next(s.Length)]).ToArray());

            //// Vẽ CAPTCHA lên PictureBox
            //Bitmap bitmap = new Bitmap(picCaptcha.Width, picCaptcha.Height);
            //Graphics graphics = Graphics.FromImage(bitmap);
            //graphics.DrawString(correctCaptcha, new Font("Arial", 24), Brushes.Black, new PointF(0, 0));
            //picCaptcha.Image = bitmap;
        }
        private void SendEmail(string toEmail, string subject, string body)
        {
            string fromEmail = "chutienbinh2003@gmail.com"; // Thay thế bằng địa chỉ email của bạn
            string password = "sshe aybc vncy mwsb"; // Thay thế bằng mật khẩu email của bạn

            MailMessage mail = new MailMessage(fromEmail, toEmail, subject, body);
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(fromEmail, password);

            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi gửi email: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetPasswordFromDatabase(string email)
        {
            // Thực hiện truy vấn cơ sở dữ liệu để lấy mật khẩu dựa trên địa chỉ email
            // Trả về mật khẩu nếu tìm thấy, hoặc null nếu không tìm thấy
            // Thêm mã logic của bạn ở đây
            QLTOURDBContext context = new QLTOURDBContext();
            TKUSER timmk = context.TKUSERs.FirstOrDefault(s => s.TENTAIKHOAN == email);
              string matkhau =timmk.MATKHAU;
            return matkhau;
        }
        Random random = new Random();
        int otp;
        private void button1_Click(object sender, EventArgs e)
        {
            //if (txtCaptcha.Text.ToLower() != correctCaptcha.ToLower())
            //{
            //    MessageBox.Show("CAPTCHA không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    GenerateCaptcha();
            //    txtCaptcha.Text = "";
            //    return;
            //}

            // Gửi email với mật khẩu đến địa chỉ email đã nhập
            string email = txtEmail.Text;
            string password = GetPasswordFromDatabase(email); // Thay thế hàm này bằng cách lấy mật khẩu từ cơ sở dữ liệu của bạn
            string macapcha = correctCaptcha;
            if (password != null)
            {
                try
                {
                    SendEmail(email, "Password Recovery", $"Mật khẩu của bạn là: {macapcha}");
                    MessageBox.Show("Mật khẩu đã được gửi đến địa chỉ email của bạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi gửi email: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Email không tồn tại trong hệ thống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtCaptcha_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnkiemtra_Click(object sender, EventArgs e)
        {
            if(txtkiemtramacapcha.Text == correctCaptcha)
            {
                MessageBox.Show("đúng");
            }
            else
            {
                MessageBox.Show("sai");
            }
        }
    }
}
