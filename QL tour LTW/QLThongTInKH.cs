using QL_tour_LTW.ModelQLTOUR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
                txtMAKH.Texts = selectedRow.Cells[0].Value.ToString();
                txtHO.Texts = selectedRow.Cells[1].Value.ToString();
                txtTEN.Texts = selectedRow.Cells[2].Value.ToString();
                txtSODT.Texts = selectedRow.Cells[3].Value.ToString();
                txtCCCD.Texts = selectedRow.Cells[4].Value.ToString();
                txtEMAIL.Texts = selectedRow.Cells[5].Value.ToString();
                if (selectedRow.Cells[6].Value != null)
                {
                    txtSLTV.Texts = selectedRow.Cells[6].Value.ToString();

                }
                else
                {
                    txtSLTV.Texts = string.Empty;
                }
            }
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

        private void insertKhachHang(int row)
        {
            dgvDSKHACHHANG.Rows[row].Cells[0].Value = txtMAKH.Texts;
            dgvDSKHACHHANG.Rows[row].Cells[1].Value = txtHO.Texts;
            dgvDSKHACHHANG.Rows[row].Cells[2].Value = txtTEN.Texts;
            dgvDSKHACHHANG.Rows[row].Cells[3].Value = txtSODT.Texts;
            dgvDSKHACHHANG.Rows[row].Cells[4].Value = txtCCCD.Texts;
            dgvDSKHACHHANG.Rows[row].Cells[5].Value = txtEMAIL.Texts;
            dgvDSKHACHHANG.Rows[row].Cells[6].Value = txtSLTV.Texts;
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

        private KHACHHANG timKhanhHang(string maKH)
        {
            return context.KHACHHANGs.FirstOrDefault(kh => kh.MAKH.ToString() == maKH);
        }
        private void btnRESET_Click(object sender, EventArgs e)
        {
            loadfrm();
            clearTextBox();
        }

        private void btnTIMKIEM_Click(object sender, EventArgs e)
        {
            string maKH = txtMAKH.Texts.Trim();
            string ho = txtHO.Texts.Trim();
            string ten = txtTEN.Texts.Trim();
            string sdt = txtSODT.Texts.Trim();
            string cccd = txtCCCD.Texts.Trim();
            string email = txtEMAIL.Texts.Trim();
            string sl;
            if (txtSLTV != null)
            {
                sl = txtSLTV.Texts.Trim();
            }
            else
            {
                sl = "";
            }

            List<KHACHHANG> result = new List<KHACHHANG>();

            QLTOURDBContext context = new QLTOURDBContext();

            IQueryable<KHACHHANG> query = context.KHACHHANGs;
            if (string.IsNullOrEmpty(maKH) && string.IsNullOrEmpty(ho) && string.IsNullOrEmpty(ten)
               && string.IsNullOrEmpty(sdt) && string.IsNullOrEmpty(cccd) && string.IsNullOrEmpty(email))
            {
                // Hiển thị danh sách tất cả sinh viên
                result = context.KHACHHANGs.ToList();
                BindGrid(result);
            }
            else
            {
                // Thực hiện tìm kiếm sinh viên dựa trên các điều kiện
                if (!string.IsNullOrEmpty(maKH))
                {
                    query = query.Where(s => s.MAKH.Contains(maKH));
                }
                if (!string.IsNullOrEmpty(ho))
                {
                    query = query.Where(s => s.HO.Contains(ho));
                }
                if (!string.IsNullOrEmpty(ten))
                {
                    query = query.Where(s => s.TEN.Contains(ten));
                }
                if (!string.IsNullOrEmpty(sdt))
                {
                    query = query.Where(s => s.SDT.Contains(sdt));
                }
                if (!string.IsNullOrEmpty(cccd))
                {
                    query = query.Where(s => s.CCCD.Contains(cccd));
                }
                if (!string.IsNullOrEmpty(email))
                {
                    query = query.Where(s => s.EMAIL.Contains(email));
                }
                result = query.ToList();
                // Hiển thị kết quả tìm kiếm trong DataGridView
                BindGrid(result);
            }
        }

        private void btnTHEM_Click(object sender, EventArgs e)
        {
            //ThemMoiKH themMoiKH = new ThemMoiKH();
            //themMoiKH.ShowDialog();
            //loadfrm();
            if (mainForm != null)
            {
                ThemMoiKH themmoi = new ThemMoiKH();
                mainForm.openForm(themmoi);
                mainForm.linklblThemKH.Visible = true;
                mainForm.lblNgangCach.Visible = true;
            }
        }

        private void btnXOA_Click(object sender, EventArgs e)
        {
            int seledtedRow = GetSelectedRow(txtMAKH.Texts);
            if (seledtedRow == -1)
            {
                MessageBox.Show("Không có sinh viên!", "thông báo");
                return;
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn xóa ?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    dgvDSKHACHHANG.Rows.RemoveAt(seledtedRow);
                    context.KHACHHANGs.Remove(timKhanhHang(txtMAKH.Texts));
                    context.SaveChanges();
                }
            }
            clearTextBox();
        }
        
        private void btnCAPNHAT_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMAKH.Texts == "" || txtHO.Texts == "" || txtTEN.Texts == "" ||
                        txtSODT.Texts == "" || txtCCCD.Texts == "" || txtEMAIL.Texts == "" )
                    MessageBox.Show("Thiếu thông tin khách hàng!", "thông báo");
                else
                {
                    int seledtedRow = GetSelectedRow(txtMAKH.Texts);
                    if (seledtedRow == -1)
                    {
                        MessageBox.Show("Đã có khách hàng!", "thông báo");
                        return;
                    }
                    else
                    {   
                        KHACHHANG tim = context.KHACHHANGs.FirstOrDefault(s => s.MAKH == txtMAKH.Texts);
                        //sua sodt ========================================================================================
                        KHACHHANG timSdtKhiClick = context.KHACHHANGs.FirstOrDefault(s => s.MAKH == txtMAKH.Texts && s.SDT == txtSODT.Texts);
                        //KHACHHANG timEmailKhiClick = context.KHACHHANGs.FirstOrDefault(s => s.MAKH == txtMAKH.Texts && s.EMAIL == txtEMAIL.Texts);

                        if (timSdtKhiClick != null)
                        {
                            // cập nhật ko sửa thafh công
                            insertKhachHang(seledtedRow);
                            if (txtSLTV.Texts == "")
                            {
                                KHACHHANG kh = timKhanhHang(txtMAKH.Texts);
                                kh.MAKH = txtMAKH.Texts;
                                kh.HO = txtHO.Texts;
                                kh.TEN = txtTEN.Texts;
                                kh.SDT = txtSODT.Texts;
                                kh.CCCD = txtCCCD.Texts;
                                kh.EMAIL = txtEMAIL.Texts;
                                kh.SL = null;
                                context.SaveChanges();
                                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK);
                            }
                            else
                            {
                                KHACHHANG kh = timKhanhHang(txtMAKH.Texts);
                                kh.MAKH = txtMAKH.Texts;
                                kh.HO = txtHO.Texts;
                                kh.TEN = txtTEN.Texts;
                                kh.SDT = txtSODT.Texts;
                                kh.CCCD = txtCCCD.Texts;
                                kh.EMAIL = txtEMAIL.Texts;
                                kh.SL = int.Parse(txtSLTV.Texts);
                                context.SaveChanges();
                                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK);
                            }
                        }
                        else if (tim != null)
                        {
                            KHACHHANG sdt = context.KHACHHANGs.FirstOrDefault(s => s.SDT == txtSODT.Texts);
                            //KHACHHANG email = context.KHACHHANGs.FirstOrDefault(s => s.EMAIL == txtEMAIL.Texts);
                            if (sdt != null)
                            {
                                MessageBox.Show("Số điện thoại đã tồn tại!", "thông báo");
                            }
                            else
                            {
                                insertKhachHang(seledtedRow);
                                if (txtSLTV.Texts == "")
                                {
                                    KHACHHANG kh = timKhanhHang(txtMAKH.Texts);
                                    kh.MAKH = txtMAKH.Texts;
                                    kh.HO = txtHO.Texts;
                                    kh.TEN = txtTEN.Texts;
                                    kh.SDT = txtSODT.Texts;
                                    kh.CCCD = txtCCCD.Texts;
                                    kh.EMAIL = txtEMAIL.Texts;
                                    kh.SL = null;
                                    context.SaveChanges();
                                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK);
                                }
                                else
                                {
                                    KHACHHANG kh = timKhanhHang(txtMAKH.Texts);
                                    kh.MAKH = txtMAKH.Texts;
                                    kh.HO = txtHO.Texts;
                                    kh.TEN = txtTEN.Texts;
                                    kh.SDT = txtSODT.Texts;
                                    kh.CCCD = txtCCCD.Texts;
                                    kh.EMAIL = txtEMAIL.Texts;
                                    kh.SL = int.Parse(txtSLTV.Texts);
                                    context.SaveChanges();
                                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK);
                                }
                            }
                        }
                        //sua cccd =============================================================================
                        KHACHHANG timCCCDKhiClick = context.KHACHHANGs.FirstOrDefault(s => s.MAKH == txtMAKH.Texts && s.CCCD == txtCCCD.Texts);
                        if (timCCCDKhiClick != null)
                        {
                            // cập nhật ko sửa thafh công
                            insertKhachHang(seledtedRow);
                            if (txtSLTV.Texts == "")
                            {
                                KHACHHANG kh = timKhanhHang(txtMAKH.Texts);
                                kh.MAKH = txtMAKH.Texts;
                                kh.HO = txtHO.Texts;
                                kh.TEN = txtTEN.Texts;
                                kh.SDT = txtSODT.Texts;
                                kh.CCCD = txtCCCD.Texts;
                                kh.EMAIL = txtEMAIL.Texts;
                                kh.SL = null;
                                context.SaveChanges();
                                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK);
                            }
                            else
                            {
                                KHACHHANG kh = timKhanhHang(txtMAKH.Texts);
                                kh.MAKH = txtMAKH.Texts;
                                kh.HO = txtHO.Texts;
                                kh.TEN = txtTEN.Texts;
                                kh.SDT = txtSODT.Texts;
                                kh.CCCD = txtCCCD.Texts;
                                kh.EMAIL = txtEMAIL.Texts;
                                kh.SL = int.Parse(txtSLTV.Texts);
                                context.SaveChanges();
                                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK);
                            }
                        }
                        else if (tim != null)
                        {
                            KHACHHANG cccd = context.KHACHHANGs.FirstOrDefault(s => s.CCCD == txtCCCD.Texts);
                            //KHACHHANG email = context.KHACHHANGs.FirstOrDefault(s => s.EMAIL == txtEMAIL.Texts);
                            if (cccd != null)
                            {
                                MessageBox.Show("Số CCCD đã tồn tại!", "thông báo");
                            }
                            //else if (email != null)
                            //{
                            //    MessageBox.Show("Địa chỉ email đã tồn tại!", "thông báo");
                            //}
                            else
                            {
                                insertKhachHang(seledtedRow);
                                if (txtSLTV.Texts == "")
                                {
                                    KHACHHANG kh = timKhanhHang(txtMAKH.Texts);
                                    kh.MAKH = txtMAKH.Texts;
                                    kh.HO = txtHO.Texts;
                                    kh.TEN = txtTEN.Texts;
                                    kh.SDT = txtSODT.Texts;
                                    kh.CCCD = txtCCCD.Texts;
                                    kh.EMAIL = txtEMAIL.Texts;
                                    kh.SL = null;
                                    context.SaveChanges();
                                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK);
                                }
                                else
                                {
                                    KHACHHANG kh = timKhanhHang(txtMAKH.Texts);
                                    kh.MAKH = txtMAKH.Texts;
                                    kh.HO = txtHO.Texts;
                                    kh.TEN = txtTEN.Texts;
                                    kh.SDT = txtSODT.Texts;
                                    kh.CCCD = txtCCCD.Texts;
                                    kh.EMAIL = txtEMAIL.Texts;
                                    kh.SL = int.Parse(txtSLTV.Texts);
                                    context.SaveChanges();
                                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK);
                                }
                            }
                        }
                        //sua email ===============================================================
                    }
                }
                clearTextBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnTROVE_Click(object sender, EventArgs e)
        {
            Close();
        }

        
       

        private GiaoDienQLThongTInKH mainForm;
        public void setMainForm(GiaoDienQLThongTInKH form)
        {
            this.mainForm = form;
        }

        private void dgvDSKHACHHANG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
            //var checkSDT = context.KHACHHANGs.FirstOrDefault(s => s.SDT == txtSODT.Texts);
            //if (checkSDT != null)
            //{
            //    MessageBox.Show("Số điện thoại đã tồn tại!", "thông báo");
            //    txtSODT.Texts = "";
            //    return;
            //}
        }

        private void txtCCCD_Enter(object sender, EventArgs e)
        {
            txtCCCD.BackColor = Color.Gainsboro;
        }

        private void txtCCCD_Leave(object sender, EventArgs e)
        {
            txtCCCD.BackColor = Color.White;
            //var checkSDT = context.KHACHHANGs.FirstOrDefault(s => s.CCCD == txtCCCD.Texts);
            //if (checkSDT != null)
            //{
            //    MessageBox.Show("CCCD đã tồn tại!", "thông báo");

            //    return;
            //}
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
        private void btnRESET_MouseUp(object sender, MouseEventArgs e)
        {
            btnRESET.BorderSize = 0;
        }
        private void QLThongTInKH_MouseUp(object sender, MouseEventArgs e)
        {
            btnRESET.BorderSize = 0;
            btnTHEM.BorderSize = 0;
            btnTIMKIEM.BorderSize = 0;
            btnXOA.BorderSize = 0;
            btnCAPNHAT.BorderSize = 0;
            btnTROVE.BorderSize = 0;
        }

        private void btnRESET_MouseDown(object sender, MouseEventArgs e)
        {
            btnRESET.BorderSize = 3;
            btnRESET.BorderColor = Color.MidnightBlue;
        }

        private void btnTIMKIEM_MouseDown(object sender, MouseEventArgs e)
        {
            btnTIMKIEM.BorderSize = 3;
            btnTIMKIEM.BorderColor = Color.MidnightBlue;
        }

        private void btnTHEM_MouseDown(object sender, MouseEventArgs e)
        {
            btnTHEM.BorderSize = 3;
            btnTHEM.BorderColor = Color.MidnightBlue;
        }

        private void btnXOA_MouseDown(object sender, MouseEventArgs e)
        {
            btnXOA.BorderSize = 3;
            btnXOA.BorderColor = Color.MidnightBlue;
        }

        private void btnCAPNHAT_MouseDown(object sender, MouseEventArgs e)
        {
            btnCAPNHAT.BorderSize = 3;
            btnCAPNHAT.BorderColor = Color.MidnightBlue;
        }

        private void btnTROVE_MouseDown(object sender, MouseEventArgs e)
        {
            btnTROVE.BorderSize = 3;
            btnTROVE.BorderColor = Color.MidnightBlue;
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
