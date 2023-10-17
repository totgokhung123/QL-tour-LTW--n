using QL_tour_LTW.ModelQLTOUR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
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
                        if(tentaikhoan != "ADMIN" || tentaikhoan != "admin")
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
                            if(cbbVAITRO.Text != "ADMIN")
                            {
                                MessageBox.Show("Bạn chưa chọn vai trò", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);                              
                                return;
                            }
                            else
                            {
                                QLTOURDBContext context = new QLTOURDBContext();
                                TKUSER capnhat = context.TKUSERs.FirstOrDefault(s => s.TENTAIKHOAN == tentaikhoan && s.VAITRO == "ADMIN");
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
                MessageBox.Show("Thếu thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        }

        private void txtMATKHAUCU_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 22) // 22 là mã ASCII của ký tự Ctrl + V
            {
                e.Handled = true;
                return;
            }
        }

        private void txtMATKHAUMOI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 22) // 22 là mã ASCII của ký tự Ctrl + V
            {
                e.Handled = true;
                return;
            }
        }

        private void txtXACNHANMATKHAU_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 22) // 22 là mã ASCII của ký tự Ctrl + V
            {
                e.Handled = true;
                return;
            }
        }

        private void cbbVAITRO_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
