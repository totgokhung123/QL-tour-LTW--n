using QL_tour_LTW.ModelQLTOUR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_tour_LTW
{
    public partial class ThemMoiKH : Form
    {
        QLTOURDBContext context = new QLTOURDBContext();
        public ThemMoiKH()
        {
            InitializeComponent();
        }
        public void clearTextBox()
        {
            txtMAKH.Texts = string.Empty;
            txtHO.Texts = string.Empty;
            txtTEN.Texts = string.Empty;
            txtSODT.Texts = string.Empty;
            txtCCCD.Texts = string.Empty;
            txtEMAIL.Texts = string.Empty;
            txtSLTV.Texts = string.Empty;
        }
        private int checkMAKH(string maT)
        {
            KHACHHANG tim = context.KHACHHANGs.FirstOrDefault(s => s.MAKH == maT);
            if (tim != null)
            {
                return 4;
            }
            return 5;
        }
        private void btnLUU_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txtMAKH.Texts == "" || txtHO.Texts == "" || txtTEN.Texts == "" ||
                    txtSODT.Texts == "" || txtCCCD.Texts == "" || txtEMAIL.Texts == "")
                    MessageBox.Show("Thiếu thông tin khách hàng!", "thông báo");
                else
                {
                    
                    int temp = checkMAKH(txtMAKH.Texts);
                    //KHACHHANG themKH = context.KHACHHANGs.FirstOrDefault(s => s.MAKH == txtMAKH.Texts);
                    //string mapt = cbbMAPT.SelectedValue != null ? cbbMAPT.SelectedValue.ToString() : null;
                    if(temp == 4)
                    {
                        MessageBox.Show("Đã tồn tại khách hàng!");
                        return;
                    }
                    else
                    {
                        if (txtSLTV.Texts != "")
                        {
                            KHACHHANG kh = new KHACHHANG()
                            {
                                MAKH = txtMAKH.Texts,
                                HO = txtHO.Texts,
                                TEN = txtTEN.Texts,
                                SDT = txtSODT.Texts,
                                CCCD = txtCCCD.Texts,
                                EMAIL = txtEMAIL.Texts,
                                SL = int.Parse(txtSLTV.Texts.ToString())
                            };
                            context.KHACHHANGs.Add(kh);
                            context.SaveChanges();
                            MessageBox.Show("thêm mới khách hàng thành công !");
                        }
                        else
                        {
                            KHACHHANG kh = new KHACHHANG()
                            {
                                MAKH = txtMAKH.Texts,
                                HO = txtHO.Texts,
                                TEN = txtTEN.Texts,
                                SDT = txtSODT.Texts,
                                CCCD = txtCCCD.Texts,
                                EMAIL = txtEMAIL.Texts,
                                SL = null
                            };
                            context.KHACHHANGs.Add(kh);
                            context.SaveChanges();
                            MessageBox.Show("thêm mới khách hàng thành công !");
                        }
                    }
                    
                    clearTextBox();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Khách hàng đã tồn tại!", "Thông báo", MessageBoxButtons.OKCancel);
                MessageBox.Show(ex.ToString());

            }
        }

        private void btnHUY_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát! ", "Xác Nhận thoát !", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }
        

        private void txtMAKH_Enter(object sender, EventArgs e)
        {
            txtMAKH.BackColor = Color.Gainsboro;
        }

        private void txtMAKH_Leave(object sender, EventArgs e)
        {
            txtMAKH.BackColor = Color.White;
        }

        private void txtHO_Enter(object sender, EventArgs e)
        {
            txtHO.BackColor = Color.Gainsboro;
        }

        private void txtHO_Leave(object sender, EventArgs e)
        {
            txtHO.BackColor = Color.White;
        }

        private void txtTEN_Enter(object sender, EventArgs e)
        {
            txtTEN.BackColor = Color.Gainsboro;
        }

        private void txtTEN_Leave(object sender, EventArgs e)
        {
            txtTEN.BackColor = Color.White;
        }

        private void txtSODT_Enter(object sender, EventArgs e)
        {
            txtSODT.BackColor = Color.Gainsboro;
        }

        private void txtSODT_Leave(object sender, EventArgs e)
        {
            txtSODT.BackColor= Color.White;
        }

        private void txtCCCD_Enter(object sender, EventArgs e)
        {
            txtCCCD.BackColor = Color.Gainsboro;
        }

        private void txtCCCD_Leave(object sender, EventArgs e)
        {
            txtCCCD.BackColor = Color.White;
        }

        private void txtEMAIL_Enter(object sender, EventArgs e)
        {
            txtEMAIL.BackColor = Color.Gainsboro;
        }

        private void txtEMAIL_Leave(object sender, EventArgs e)
        {
            txtEMAIL.BackColor = Color.White;
        }

        private void txtSLTV_Enter(object sender, EventArgs e)
        {
            txtSLTV.BackColor = Color.Gainsboro;
        }

        private void txtSLTV_Leave(object sender, EventArgs e)
        {
            txtSLTV.BackColor = Color.White;
        }

        private void txtMAKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 22) // 22 là mã ASCII của ký tự Ctrl + V
            {
                e.Handled = true;
                return;
            }
            if (!char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Chỉ Nhập chữ, só", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtMAKH.Texts.Length >= 12 && e.KeyChar != '\b')
            {
                e.Handled = true; // Hủy sự kiện KeyPress
                MessageBox.Show("Mã khách hàng không quá 11 ký tự!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void txtHO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Chỉ Nhập chữ", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (e.KeyChar == 22) // 22 là mã ASCII của ký tự Ctrl + V
            {
                e.Handled = true;
                return;
            }
            if (txtHO.Texts.Length >= 33 && e.KeyChar != '\b')
            {
                e.Handled = true; // Hủy sự kiện KeyPress
                MessageBox.Show("Tên tour không quá 32 ký tự!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void txtSODT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Chỉ Nhập số", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (e.KeyChar == 22)
            {
                e.Handled = true;
                return;
            }
        }

        private void txtTEN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 22) // 22 là mã ASCII của ký tự Ctrl + V
            {
                e.Handled = true;
                return;
            }
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Chỉ Nhập chữ!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtTEN.Texts.Length >= 12 && e.KeyChar != '\b')
            {
                e.Handled = true; // Hủy sự kiện KeyPress
                MessageBox.Show("Tên tour không quá 11 ký tự!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void txtEMAIL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 22) // 22 là mã ASCII của ký tự Ctrl + V
            {
                e.Handled = true;
                return;
            }
            if (!char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '@' && e.KeyChar != '.')
            {
                e.Handled = true;
                MessageBox.Show("Chỉ Nhập chữ, só", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtEMAIL.Texts.Length >= 255 && e.KeyChar != '\b')
            {
                e.Handled = true; // Hủy sự kiện KeyPress
                MessageBox.Show("Email không quá 255 ký tự!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}
