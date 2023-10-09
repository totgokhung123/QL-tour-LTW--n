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
            txtMAKH.Text = string.Empty;
            txtHO.Text = string.Empty;
            txtTEN.Text = string.Empty;
            txtSODT.Text = string.Empty;
            txtCCCD.Text = string.Empty;
            txtEMAIL.Text = string.Empty;
            txtSLTV.Text = string.Empty;
        }
        private void btnLUU_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMAKH.Text == "" || txtHO.Text == "" || txtTEN.Text == "" ||
                    txtSODT.Text == "" || txtCCCD.Text == "" || txtEMAIL.Text == "")
                    MessageBox.Show("Thiếu thông tin khách hàng!", "thông báo");
                else
                {
                    KHACHHANG kh = new KHACHHANG()
                    {
                        MAKH = txtMAKH.Text,
                        HO = txtHO.Text,
                        TEN = txtTEN.Text,
                        SDT = txtSODT.Text,
                        CCCD = txtCCCD.Text,
                        EMAIL = txtEMAIL.Text,
                        SL = int.Parse(txtSLTV.Text),
                        
                    };
                    context.KHACHHANGs.Add(kh);
                    context.SaveChanges();
                    MessageBox.Show("thêm mới khách hàng thành công !");
                    clearTextBox();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void btnHUY_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát! ", "Xác Nhận thoát !", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
