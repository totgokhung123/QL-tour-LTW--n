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
    public partial class QLThongTInKH : Form
    {
        QLTOURDBContext context = new QLTOURDBContext();
        public QLThongTInKH()
        {
            InitializeComponent();
        }
        public void loadfrm()
        {
            List<KHACHHANG> khachhang = context.KHACHHANGs.ToList();
            BindGrid(khachhang);
        }

        private void BindGrid(List<KHACHHANG> khachhang)
        {
            //hien thi thong tin ben csdl len datagridview
            dgvDSKHACHHANG.Rows.Clear();
            foreach (var item in khachhang)
            {
                int index = dgvDSKHACHHANG.Rows.Add();
                dgvDSKHACHHANG.Rows[index].Cells[0].Value = item.MAKH;
                dgvDSKHACHHANG.Rows[index].Cells[1].Value = item.HO;
                dgvDSKHACHHANG.Rows[index].Cells[2].Value = item.TEN;
                dgvDSKHACHHANG.Rows[index].Cells[3].Value = item.SDT;
                dgvDSKHACHHANG.Rows[index].Cells[4].Value = item.CCCD;
                dgvDSKHACHHANG.Rows[index].Cells[5].Value = item.EMAIL;
                dgvDSKHACHHANG.Rows[index].Cells[6].Value = item.SL;
            }
        }

        private void QLThongTInKH_Load(object sender, EventArgs e)
        {
            loadfrm();
        }

        private void dgvDSKHACHHANG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //do thong tin len tung textbox tuong ung
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvDSKHACHHANG.Rows[e.RowIndex];
                txtMAKH.Text = selectedRow.Cells[0].Value.ToString();
                txtHO.Text = selectedRow.Cells[1].Value.ToString();
                txtTEN.Text = selectedRow.Cells[2].Value.ToString();
                txtSODT.Text = selectedRow.Cells[3].Value.ToString();
                txtCCCD.Text = selectedRow.Cells[4].Value.ToString();
                txtEMAIL.Text = selectedRow.Cells[5].Value.ToString();
                if (selectedRow.Cells[6].Value != null)
                {
                    txtSLTV.Text = selectedRow.Cells[6].Value.ToString();

                }
                else
                {
                    txtSLTV.Text = string.Empty;
                }
            }
        }

        private void btnTIMKIEM_Click(object sender, EventArgs e)
        {
            loadfrm();
            //neu textbox ma kh dc nhap thi se tim kiem
            if (txtMAKH.Text != "")
            {
                string maKHCanTim = txtMAKH.Text.Trim();
                var timMaKH = context.KHACHHANGs.Where(id => id.MAKH.Equals(maKHCanTim)).ToList();
                BindGrid(timMaKH);
            }
            //neu textbox ho dc nhap thi se tim kiem
            else if (txtHO.Text != "")
            {
                string hoCanTim = txtHO.Text.Trim();
                var timHo = context.KHACHHANGs.Where(h => h.HO.Equals(hoCanTim)).ToList();
                BindGrid(timHo);
            }
            //neu textbox ten dc nhap thi se tim kiem
            else if (txtTEN.Text != "")
            {
                string tenCanTim = txtTEN.Text.Trim();
                var timTen = context.KHACHHANGs.Where(t => t.TEN.Equals(tenCanTim)).ToList();
                BindGrid(timTen);
            }
            //neu textbox so dt dc nhap thi se tim kiem
            else if (txtSODT.Text != "")
            {
                string soDTCanTim = txtSODT.Text.Trim();
                var timSoDT = context.KHACHHANGs.Where(s => s.SDT.Equals(soDTCanTim)).ToList();
                BindGrid(timSoDT);
            }
            //neu textbox cccd dc nhap thi se tim kiem
            else if (txtCCCD.Text != "")
            {
                string cccdCanTim = txtCCCD.Text.Trim();
                var timCCCD = context.KHACHHANGs.Where(c => c.CCCD.Equals(cccdCanTim)).ToList();
                BindGrid(timCCCD);
            }
            //neu textbox email dc nhap thi se tim kiem
            else 
            {
                string emailCanTim = txtEMAIL.Text.Trim();
                var timEmail = context.KHACHHANGs.Where(em => em.EMAIL.Equals(emailCanTim)).ToList();
                BindGrid(timEmail);
            }
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
        private void btnRESET_Click(object sender, EventArgs e)
        {
            loadfrm();
            clearTextBox();
        }
        private void insertKhachHang(int row)
        {
            dgvDSKHACHHANG.Rows[row].Cells[0].Value = txtMAKH.Text;
            dgvDSKHACHHANG.Rows[row].Cells[1].Value = txtHO.Text;
            dgvDSKHACHHANG.Rows[row].Cells[2].Value = txtTEN.Text;
            dgvDSKHACHHANG.Rows[row].Cells[3].Value = txtSODT.Text;
            dgvDSKHACHHANG.Rows[row].Cells[4].Value = txtCCCD.Text;
            dgvDSKHACHHANG.Rows[row].Cells[5].Value = txtEMAIL.Text;
            dgvDSKHACHHANG.Rows[row].Cells[6].Value = txtSLTV.Text;
        }
        private int GetSelectedRow(string maKH)
        {
            try
            {
                for (int i = 0; i < dgvDSKHACHHANG.Rows.Count; i++)
                {
                    if (dgvDSKHACHHANG.Rows[i].Cells[0].Value.ToString() == maKH)
                    {
                        return i;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tìm thấy khách hàng", "thông báo");
            }
            return -1;
        }
        private void btnTHEM_Click(object sender, EventArgs e)
        {
            ThemMoiKH themMoiKH = new ThemMoiKH();
            themMoiKH.ShowDialog();
            loadfrm();
        }
        private KHACHHANG timKhanhHang(string maKH)
        {
            return context.KHACHHANGs.FirstOrDefault(kh => kh.MAKH.ToString() == maKH);
        }
        private void btnXOA_Click(object sender, EventArgs e)
        {
            int seledtedRow = GetSelectedRow(txtMAKH.Text);
            if (seledtedRow == -1)
            {
                MessageBox.Show("Không có sinh viên!", "thông báo");
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn xóa ?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    dgvDSKHACHHANG.Rows.RemoveAt(seledtedRow);
                    context.KHACHHANGs.Remove(timKhanhHang(txtMAKH.Text));
                    context.SaveChanges();
                }
            }
        }

        private void btnCAPNHAT_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMAKH.Text == "" || txtHO.Text == "" || txtTEN.Text == "" ||
                        txtSODT.Text == "" || txtCCCD.Text == "" || txtEMAIL.Text == "")
                    MessageBox.Show("Thiếu thông tin khách hàng!", "thông báo");
                else
                {
                    int seledtedRow = GetSelectedRow(txtMAKH.Text);
                    if (seledtedRow == -1)
                    {
                        MessageBox.Show("Đã có sinh viên!", "thông báo");
                    }
                    else
                    {
                        insertKhachHang(seledtedRow);
                        if (txtSLTV.Text == "")
                        {
                            KHACHHANG kh = timKhanhHang(txtMAKH.Text);
                            kh.MAKH = txtMAKH.Text;
                            kh.HO = txtHO.Text;
                            kh.TEN = txtTEN.Text;
                            kh.SDT = txtSODT.Text;
                            kh.CCCD = txtCCCD.Text;
                            kh.EMAIL = txtEMAIL.Text;
                            kh.SL = null;
                            context.SaveChanges();
                        }
                        else
                        {
                            KHACHHANG kh = timKhanhHang(txtMAKH.Text);
                            kh.MAKH = txtMAKH.Text;
                            kh.HO = txtHO.Text;
                            kh.TEN = txtTEN.Text;
                            kh.SDT = txtSODT.Text;
                            kh.CCCD = txtCCCD.Text;
                            kh.EMAIL = txtEMAIL.Text;
                            kh.SL = int.Parse(txtSLTV.Text);
                            context.SaveChanges();
                        }
                        MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK);
                    }
                }
                clearTextBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }
    }
}
