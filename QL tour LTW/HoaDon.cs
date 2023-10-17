using QL_tour_LTW.ModelQLTOUR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_tour_LTW
{
    public partial class HoaDon : Form
    {
        QLTOURDBContext context = new QLTOURDBContext();
        public HoaDon()
        {
            InitializeComponent();
        }

        private void HoaDon_Load(object sender, EventArgs e)
        {
            List<HOADON> listHoaDon = context.HOADONs.ToList();
            List<TOUR> listTour = context.TOURs.ToList();
            List<NHANVIEN> listNhanVien = context.NHANVIENs.ToList();
            List<KHACHHANG> listKhachHang = context.KHACHHANGs.ToList();
            BindGridView(listHoaDon);
            fillMaTour(listTour);
            fillMaKH(listKhachHang);
            fillMaNV(listNhanVien);
        }
        private void fillMaKH(List<KHACHHANG> listKhachHang)
        {
            cbbMaKH.DataSource = listKhachHang;
            cbbMaKH.DisplayMember = "MAKH";
            cbbMaKH.ValueMember = "MAKH";
        }

        private void fillMaNV(List<NHANVIEN> listNhanVien)
        {
            cbbMaNV.DataSource = listNhanVien;
            cbbMaNV.DisplayMember = "MANV";
            cbbMaNV.ValueMember = "MANV";
        }

        private void fillMaTour(List<TOUR> listTour)
        {
            cbbMaTour.DataSource = listTour;
            cbbMaTour.DisplayMember = "MATOUR";
            cbbMaTour.ValueMember = "MATOUR";
        }

        private void BindGridView(List<HOADON> listHoaDon)
        {
            dgvDSHD.Rows.Clear();
            foreach (var item in listHoaDon)
            {
                int index = dgvDSHD.Rows.Add();
                dgvDSHD.Rows[index].Cells[0].Value = item.SOHD;
                dgvDSHD.Rows[index].Cells[1].Value = item.NGAYLAP;
                dgvDSHD.Rows[index].Cells[2].Value = item.THANHTIEN;
                dgvDSHD.Rows[index].Cells[3].Value = item.MATOUR;
                dgvDSHD.Rows[index].Cells[4].Value = item.MAKH;
                dgvDSHD.Rows[index].Cells[5].Value = item.MANV;
                dgvDSHD.Rows[index].Cells[6].Value = item.TRANGTHAI;
            }
        }

        private bool IsEnglishCharacter(char c)
        {
            // Kiểm tra xem ký tự có thuộc tiếng Anh (a-z, A-Z) không
            return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z');
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
        private void txtSoHD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)3 || e.KeyChar == (char)22 || e.KeyChar == ' ')
            {
                e.Handled = true;
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

        private void txtThanhTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)3 || e.KeyChar == (char)22 || e.KeyChar == ' ')
            {
                e.Handled = true;
            }
            if (e.KeyChar == 22) // 22 là mã ASCII của ký tự Ctrl + V
            {
                e.Handled = true;
                return;
            }
        }

        private void txtTrangThai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)3 || e.KeyChar == (char)22)
            {
                e.Handled = true;
            }
            if (e.KeyChar == 22) // 22 là mã ASCII của ký tự Ctrl + V
            {
                e.Handled = true;
                return;
            }
        }
        public bool IsNumeric(string input)
        {
            return Regex.IsMatch(input, @"^\d+$");
        }

        public bool IsNameValid(string input)
        {
            return Regex.IsMatch(input, "^[A-Za-zÀ-Ỹà-ỹĂ-Ắă-ằÂ-Ấâ-âÉ-Ỷé-ỷÊ-Ểê-ểÍ-Ỹí-ỹÔ-Ổô-ổƠ-Ởơ-ởÚ-ỹú-ỹỨ-Ỵứ-ỵ ]+$");
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            if (dgvDSHD.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvDSHD.SelectedRows[0];
                string MaNV = cbbMaNV.Text;
                string soHD = txtSoHD.Texts;
                using (var context = new QLTOURDBContext())
                {
                    var selectedSoHD = selectedRow.Cells[0].Value.ToString();

                    // Kiểm tra xem 'SoHD' mới đã tồn tại trong cơ sở dữ liệu hoặc không
                    var duplicateSoHD = context.HOADONs.FirstOrDefault(hd => hd.SOHD == soHD && hd.SOHD != selectedSoHD);

                    if (duplicateSoHD != null)
                    {
                        MessageBox.Show("Số hóa đơn đã tồn tại. Vui lòng chọn một số hóa đơn khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtSoHD.Select();
                        return;
                    }
                }
                string thanhTien = txtThanhTien.Texts;
                string ngayLap = dpkNgayLap.Text;
                DateTime NgayLap = dpkNgayLap.Value;
                string maTour = cbbMaTour.Text;               
                string maNV = cbbMaNV.Text;
                string maKH = cbbMaKH.Text;
                string trangThai = txtTrangThai.Texts;

                if (txtSoHD.Texts == "")
                {
                    MessageBox.Show("Số hóa đơn không được bỏ trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSoHD.Select();
                    return;
                }
                if (txtSoHD.Texts.Length > 12)
                {
                    MessageBox.Show("Số hóa đơn không được quá 12 chữ số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoHD.Select();
                    return;
                }
                if (txtThanhTien.Texts == "")
                {
                    MessageBox.Show("Họ tên nhân viên không được bỏ trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtThanhTien.Select();
                    return;
                }
                if (!IsNumeric(txtThanhTien.Texts))
                {
                    MessageBox.Show("Thành tiền chỉ được chứa ký tự số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtThanhTien.Select();
                    return;
                }

                if (txtTrangThai.Texts.Length > 30)
                {
                    MessageBox.Show("Trạng thái không vượt quá 30 kí tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTrangThai.Select();
                    return;
                }

                /*if (!IsNameValid(txtTrangThai.Texts))
                {
                    MessageBox.Show("Trạng thái chỉ được chứa ký tự chữ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTrangThai.Select();
                    return;
                }*/

                if (IsNameValid(txtTrangThai.Texts) || txtTrangThai.Texts != "")
                {
                    MessageBox.Show("Trạng thái chỉ được chứa ký tự chữ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTrangThai.Select();
                    return;
                }

                using (var context = new QLTOURDBContext())
                {
                    var hoadonUpdate = context.HOADONs.SingleOrDefault(nv => nv.SOHD == soHD);
                    if (hoadonUpdate != null)
                    {
                        hoadonUpdate.SOHD = soHD;
                        hoadonUpdate.NGAYLAP = NgayLap;
                        hoadonUpdate.THANHTIEN = decimal.Parse(thanhTien);
                        hoadonUpdate.MATOUR = maTour;
                        hoadonUpdate.MAKH = maKH;
                        hoadonUpdate.MANV = maNV;
                        hoadonUpdate.TRANGTHAI = trangThai;
                        context.SaveChanges();
                        // Cập nhật dữ liệu trong DataGridView
                        selectedRow.Cells[0].Value = soHD;
                        selectedRow.Cells[1].Value = NgayLap;
                        selectedRow.Cells[2].Value = thanhTien;
                        selectedRow.Cells[3].Value = maTour;
                        selectedRow.Cells[4].Value = maKH;
                        selectedRow.Cells[5].Value = maNV;
                        selectedRow.Cells[6].Value = trangThai;
                        MessageBox.Show("Đã sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Sửa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void dgvDSHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvDSHD.Rows[e.RowIndex];
                cbbMaNV.Text = selectedRow.Cells[5].Value.ToString();
                txtSoHD.Texts = selectedRow.Cells[0].Value.ToString();
                txtThanhTien.Texts = selectedRow.Cells[2].Value.ToString();
                cbbMaTour.Text = selectedRow.Cells[3].Value.ToString();
                cbbMaKH.Text = selectedRow.Cells[4].Value.ToString();
                if (selectedRow.Cells[6].Value != null)
                {
                    txtTrangThai.Text = selectedRow.Cells[6].Value.ToString();
                }
                else
                {
                    txtTrangThai.Text = "";
                }
                string ngayLap = selectedRow.Cells[1].Value.ToString();
                if (DateTime.TryParse(ngayLap, out DateTime NgayLap))
                {
                    dpkNgayLap.Value = NgayLap;
                }
                else
                {
                    dpkNgayLap.Value = DateTime.Today;
                }
            }
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            this.cbbMaNV.Text = string.Empty;
            this.txtSoHD.Texts = string.Empty;
            this.txtThanhTien.Texts = string.Empty;
            this.cbbMaTour.Text = string.Empty;
            this.cbbMaKH.Text = string.Empty;
            this.txtTrangThai.Texts = string.Empty;
            List<HOADON> listHoaDon = context.HOADONs.ToList();
            BindGridView(listHoaDon);
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (dgvDSHD.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    int selectedRowIndex = dgvDSHD.SelectedRows[0].Index;
                    string soHD = dgvDSHD.Rows[selectedRowIndex].Cells[0].Value.ToString();
                    dgvDSHD.Rows.RemoveAt(selectedRowIndex);

                    var hoadondl = context.HOADONs.SingleOrDefault(nv => nv.SOHD == soHD);
                    if (hoadondl != null)
                    {
                        context.HOADONs.Remove(hoadondl);
                        context.SaveChanges();
                        MessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.cbbMaNV.Text = string.Empty;
                        this.txtSoHD.Texts = string.Empty;
                        this.txtThanhTien.Texts = string.Empty;
                        this.cbbMaTour.Text = string.Empty;
                        this.cbbMaKH.Text = string.Empty;
                        this.txtTrangThai.Texts = string.Empty;
                    }
                    else
                    {
                        MessageBox.Show("Hóa đơn không tồn tại trong CSDL.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void cbbMaTour_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)3 || e.KeyChar == (char)22 || e.KeyChar == ' ')
            {
                e.Handled = true;
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

        private void cbbMaKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)3 || e.KeyChar == (char)22 || e.KeyChar == ' ')
            {
                e.Handled = true;
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

        private void cbbMaNV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)3 || e.KeyChar == (char)22 || e.KeyChar == ' ')
            {
                e.Handled = true;
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

        private void txtSoHD_Enter(object sender, EventArgs e)
        {
            txtSoHD.BackColor = Color.Gainsboro;
        }

        private void txtSoHD_Leave(object sender, EventArgs e)
        {
            txtSoHD.BackColor = Color.White;
            
            
        }

        private void txtThanhTien_Enter(object sender, EventArgs e)
        {
            txtThanhTien.BackColor = Color.Gainsboro;
        }

        private void txtTrangThai_Enter(object sender, EventArgs e)
        {
            txtTrangThai.BackColor = Color.Gainsboro;
        }

        private void btSua_MouseDown(object sender, MouseEventArgs e)
        {
            btSua.BorderSize = 2;
            btSua.BorderColor = Color.MidnightBlue;
        }

        private void txtThanhTien_Leave(object sender, EventArgs e)
        {
            txtThanhTien.BackColor = Color.White;
        }

        private void txtTrangThai_Leave(object sender, EventArgs e)
        {
            txtTrangThai.BackColor = Color.White;
        }

        private void btSua_MouseUp(object sender, MouseEventArgs e)
        {
            btSua.BorderSize = 0;
            btReset.BorderSize = 0;
            btThoat.BorderSize = 0;
            btXoa.BorderSize = 0;
        }

        private void btXoa_MouseDown(object sender, MouseEventArgs e)
        {
            btXoa.BorderSize = 2;
            btXoa.BorderColor = Color.MidnightBlue;
        }

        private void btReset_MouseDown(object sender, MouseEventArgs e)
        {
            btReset.BorderSize = 2;
            btReset.BorderColor = Color.MidnightBlue;
        }

        private void btThoat_MouseDown(object sender, MouseEventArgs e)
        {
            btThoat.BorderSize = 2;
            btThoat.BorderColor = Color.MidnightBlue;
        }

        private void btTim_Click(object sender, EventArgs e)
        {
            List<HOADON> listHoaDon = context.HOADONs.ToList();

            if (!string.IsNullOrEmpty(txtSoHD.Texts))
            {
                listHoaDon = listHoaDon.Where(s => s.SOHD.Equals(txtSoHD.Texts)).ToList();
            }
            else if (!string.IsNullOrEmpty(txtThanhTien.Texts))
            {
                listHoaDon = listHoaDon.Where(s => s.THANHTIEN.Equals(txtThanhTien.Texts)).ToList();
            }
            else if (!string.IsNullOrEmpty(cbbMaTour.Text))
            {
                listHoaDon = listHoaDon.Where(s => s.MATOUR.Equals(cbbMaTour.Text)).ToList();
            }
            else if (!string.IsNullOrEmpty(dpkNgayLap.Text))
            {
                listHoaDon = listHoaDon.Where(s => s.NGAYLAP.Equals(dpkNgayLap.Text)).ToList();
            }
            else if (!string.IsNullOrEmpty(cbbMaKH.Text))
            {
                listHoaDon = listHoaDon.Where(s => s.MAKH.Equals(cbbMaKH.Text)).ToList();
            }
            else if (!string.IsNullOrEmpty(cbbMaNV.Text))
            {
                listHoaDon = listHoaDon.Where(s => s.MANV.Equals(cbbMaNV.Text)).ToList();
            }
            else if (!string.IsNullOrEmpty(txtTrangThai.Texts))
            {
                listHoaDon = listHoaDon.Where(s => s.TRANGTHAI.Equals(txtTrangThai.Texts)).ToList();
            }
            BindGridView(listHoaDon);
        }
    }
}
/*string MaNV = cbbMaNV.Text;
            string soHD = txtSoHD.Texts;
            string thanhTien = txtThanhTien.Text;           
            string ngayLap = dpkNgayLap.Text;
            DateTime NgayLap = dpkNgayLap.Value;
            string maTour = cbbMaTour.Text;
            string maNV = cbbMaNV.Text;
            string maKH = cbbMaKH.Text;
            string trangThai = txtTrangThai.Texts;

            if (txtSoHD.Texts == "")
            {
                MessageBox.Show("Số hóa đơn không được bỏ trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoHD.Select();
                return;
            }
            if (txtSoHD.Texts.Length > 12)
            {
                MessageBox.Show("Số hóa đơn không được quá 12 chữ số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoHD.Select();
                return;
            }
            if (txtThanhTien.Texts == "")
            {
                MessageBox.Show("Họ tên nhân viên không được bỏ trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtThanhTien.Select();
                return;
            }
            if (!IsNumeric(txtThanhTien.Texts))
            {
                MessageBox.Show("Thành tiền chỉ được chứa ký tự số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtThanhTien.Select();
                return;
            }

            if (txtTrangThai.Texts.Length > 30)
            {
                MessageBox.Show("Trạng thái không vượt quá 30 kí tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTrangThai.Select();
                return;
            }

            if (!IsNameValid(txtTrangThai.Texts))
            {
                MessageBox.Show("Trạng thái chỉ được chứa ký tự chữ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTrangThai.Select();
                return;
            }            
            var hoadonAdd = context.HOADONs.SingleOrDefault(nv => nv.SOHD == soHD);
            if (hoadonAdd != null)
            {
                hoadonAdd.SOHD = soHD;
                hoadonAdd.NGAYLAP = NgayLap;              
                hoadonAdd.THANHTIEN = decimal.Parse(thanhTien);
                hoadonAdd.MATOUR = maTour;
                hoadonAdd.MAKH = maKH;
                hoadonAdd.MANV = maNV;
                hoadonAdd.TRANGTHAI = trangThai;
            }
            context.HOADONs.Add(hoadonAdd);
            context.SaveChanges();
            dgvDSHD.Rows.Add(soHD,ngayLap,thanhTien,maTour,maKH,maNV,trangThai);
            MessageBox.Show("Đã thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.cbbMaNV.Text = string.Empty;
            this.txtSoHD.Texts = string.Empty;
            this.txtThanhTien.Texts = string.Empty;
            this.cbbMaTour.Text = string.Empty;
            this.cbbMaKH.Text = string.Empty;
            this.txtTrangThai.Texts = string.Empty;*/
