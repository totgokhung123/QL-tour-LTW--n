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
        private void btnLUU_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txtMAKH.Texts == "" || txtHO.Texts == "" || txtTEN.Texts == "" ||
                    txtSODT.Texts == "" || txtCCCD.Texts == "" || txtEMAIL.Texts == "")
                    MessageBox.Show("Thiếu thông tin khách hàng!", "thông báo");
                else
                {
                    checkThongTinKhachHang();
                    if(txtSLTV.Texts != "")
                    {
                        KHACHHANG kh = new KHACHHANG()
                        {
                            MAKH = txtMAKH.Texts.ToString(),
                            HO = txtHO.Texts.ToString(),
                            TEN = txtTEN.Texts.ToString(),
                            SDT = txtSODT.Texts.ToString(),
                            CCCD = txtCCCD.Texts.ToString(),
                            EMAIL = txtEMAIL.Texts.ToString(),
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
                            MAKH = txtMAKH.Texts.ToString(),
                            HO = txtHO.Texts.ToString(),
                            TEN = txtTEN.Texts.ToString(),
                            SDT = txtSODT.Texts.ToString(),
                            CCCD = txtCCCD.Texts.ToString(),
                            EMAIL = txtEMAIL.Texts.ToString(),
                            SL = null
                        };
                        context.KHACHHANGs.Add(kh);
                        context.SaveChanges();
                        MessageBox.Show("thêm mới khách hàng thành công !");
                    }
                    clearTextBox();
                }
            }
            catch (Exception ex)
            {
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
        private void checkThongTinKhachHang()
        {
            if (txtMAKH.Texts.Length > 11)
            {
                MessageBox.Show("Mã khách hàng không quá 11 ký tự!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (txtHO.Texts.Length > 32)
            {
                MessageBox.Show("Hj của khánh hàng không quá 32 ký tự!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (txtTEN.Texts.Length > 11)
            {
                MessageBox.Show("Tên khách hàng không quá 11 ký tự!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (txtSODT.Texts.Length > 13)
            {
                MessageBox.Show("Số điện thoại không quá 13 số!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (txtCCCD.Texts.Length > 13)
            {
                MessageBox.Show("CCCD không quá 13 số!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (txtEMAIL.Texts.Length > 254)
            {
                MessageBox.Show("Email không quá 254 ký tự!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
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
    }
}
