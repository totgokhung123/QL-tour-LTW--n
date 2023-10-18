using OfficeOpenXml;
using QL_tour_LTW.ModelQLTOUR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_tour_LTW
{
    public partial class QLNhanVien : Form
    {
        QLTOURDBContext contest = new QLTOURDBContext();
        public QLNhanVien()
        {
            InitializeComponent();
            cbbGioiTinh.Text = "Nam";
        }
        private void BindGridView(List<NHANVIEN> listNhanVien)
        {
            dgvDSNV.Rows.Clear();
            foreach (var item in listNhanVien)
            {
                int index = dgvDSNV.Rows.Add();
                dgvDSNV.Rows[index].Cells[0].Value = item.MANV;
                dgvDSNV.Rows[index].Cells[1].Value = item.HOTEN;
                dgvDSNV.Rows[index].Cells[2].Value = item.GIOITINH;
                dgvDSNV.Rows[index].Cells[3].Value = item.NGAYSINH;
                dgvDSNV.Rows[index].Cells[4].Value = item.SDT;
                dgvDSNV.Rows[index].Cells[5].Value = item.CCCD;
                dgvDSNV.Rows[index].Cells[6].Value = item.EMAIL;
            }
        }
        public bool IsEmployeeExists(string manv)
        {
            using (QLTOURDBContext context = new QLTOURDBContext())
            {
                var existingEmployee = context.NHANVIENs
                    .FirstOrDefault(e => e.MANV == manv);

                return existingEmployee != null;
            }
        }
        public bool IsSDTExists(string sdt)
        {
            using (QLTOURDBContext context = new QLTOURDBContext())
            {
                var existingEmployee = context.NHANVIENs
                    .FirstOrDefault(e => e.SDT == sdt);

                return existingEmployee != null;
            }
        }

        public bool IsCCCDExists(string cccd)
        {
            using (QLTOURDBContext context = new QLTOURDBContext())
            {
                var existingEmployee = context.NHANVIENs
                    .FirstOrDefault(e => e.CCCD == cccd);

                return existingEmployee != null;
            }
        }
        public bool IsEMAILExists(string email)
        {
            using (QLTOURDBContext context = new QLTOURDBContext())
            {
                var existingEmployee = context.NHANVIENs
                    .FirstOrDefault(e => e.EMAIL == email);

                return existingEmployee != null;
            }
        }
        public bool IsNameValid(string input)
        {
            return Regex.IsMatch(input, "^[A-Za-zÀ-Ỹà-ỹĂ-Ắă-ằÂ-Ấâ-âÉ-Ỷé-ỷÊ-Ểê-ểÍ-Ỹí-ỹÔ-Ổô-ổƠ-Ởơ-ởÚ-ỹú-ỹỨ-Ỵứ-ỵ ]+$");
        }

        public bool IsNumeric(string input)
        {
            return Regex.IsMatch(input, @"^\d+$");
        }

        private void QLNhanVien_Load(object sender, EventArgs e)
        {
            List<NHANVIEN> listNhanVien = contest.NHANVIENs.ToList();
            BindGridView(listNhanVien);
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            string MaNV = txtMaNV.Texts;
            string hoten = txtHoTen.Texts;
            string gioiTinh = cbbGioiTinh.Text;
            string NgaySinh = dpkNgaySinh.Text;
            DateTime ngaySinh = dpkNgaySinh.Value;
            string SDT = txtSDT.Texts;
            string CCCD = txtCCCD.Texts;
            string email = txtEmail.Texts;
            if (txtMaNV.Texts == "")
            {
                MessageBox.Show("Mã nhân viên không được bỏ trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNV.Select();
                return;
            }
            if (txtMaNV.Texts.Length < 4)
            {
                MessageBox.Show("Mã NV phải có ít nhất 4 chữ số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNV.Select();
                return;
            }
            if (txtHoTen.Texts == "")
            {
                MessageBox.Show("Họ tên nhân viên không được bỏ trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHoTen.Select();
                return;
            }
            if (txtHoTen.Texts.Length > 50)
            {
                MessageBox.Show("Họ tên không được vượt quá 50 kí tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Select();
                return;
            }
            if (txtSDT.Texts == "")
            {
                MessageBox.Show("SĐT nhân viên không được bỏ trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSDT.Select();
                return;
            }
            if (txtCCCD.Texts == "")
            {
                MessageBox.Show("CCCD nhân viên không được bỏ trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCCCD.Select();
                return;
            }
            if (txtEmail.Texts == "")
            {
                MessageBox.Show("Email nhân viên không được bỏ trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Select();
                return;
            }
            string maNV = txtMaNV.Texts;
            string sdt = txtSDT.Texts;
            string cccd = txtCCCD.Texts;

            if (IsEmployeeExists(maNV))
            {
                MessageBox.Show("Nhân viên đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNV.Select();
                return;
            }

            if (!IsNameValid(txtHoTen.Texts))
            {
                MessageBox.Show("Họ tên nhân viên chỉ được chứa ký tự chữ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHoTen.Select();
                return;
            }

            if (!IsNumeric(txtSDT.Texts))
            {
                MessageBox.Show("SĐT chỉ được chứa ký tự số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSDT.Select();
                return;
            }

            if (!IsNumeric(txtCCCD.Texts))
            {
                MessageBox.Show("CCCD chỉ được chứa ký tự số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCCCD.Select();
                return;
            }
            if (IsSDTExists(txtSDT.Texts))
            {
                MessageBox.Show("SDT đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSDT.Select();
                return;
            }
            if (IsCCCDExists(txtCCCD.Texts))
            {
                MessageBox.Show("CCCD đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCCCD.Select();
                return;
            }
            if (IsEMAILExists(txtEmail.Texts))
            {
                MessageBox.Show("Email đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Select();
                return;
            }
            byte[] imageBytes = null;
            if (ptbAnh.Image != null)
            {
                // Chuyển đổi ảnh từ PictureBox thành mảng bytes
                using (MemoryStream ms = new MemoryStream())
                {
                    ptbAnh.Image.Save(ms, ptbAnh.Image.RawFormat);
                    imageBytes = ms.ToArray();
                }
            }
            var newNhanVien = new NHANVIEN
            {
                MANV = MaNV,
                HOTEN = hoten,
                GIOITINH = gioiTinh,
                NGAYSINH = ngaySinh,
                SDT = SDT,
                CCCD = CCCD,
                EMAIL = email,
                ANH = imageBytes
            };

            //using (var context = new QLTOURDBContext())
            //{
            contest.NHANVIENs.Add(newNhanVien);
            contest.SaveChanges();
            //}

            dgvDSNV.Rows.Add(MaNV, hoten, gioiTinh, ngaySinh.ToString("dd/MM/yyyy"), SDT, CCCD, email);
            MessageBox.Show("Đã thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtMaNV.Texts = string.Empty;
            txtHoTen.Texts = string.Empty;
            cbbGioiTinh.Text = "Nam";
            txtSDT.Texts = string.Empty;
            txtCCCD.Texts = string.Empty;
            txtEmail.Texts = string.Empty;
            ptbAnh.Image = null;
        }

        private void btSửa_Click(object sender, EventArgs e)
        {
            if (dgvDSNV.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvDSNV.SelectedRows[0];
                string maNV = txtMaNV.Texts;
                using (var context = new QLTOURDBContext())
                {
                    var selectedSoHD = selectedRow.Cells[0].Value.ToString();

                    var duplicateSoHD = context.NHANVIENs.FirstOrDefault(s => s.MANV == maNV && s.MANV != selectedSoHD);

                    if (duplicateSoHD != null)
                    {
                        MessageBox.Show("Mã NV đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtMaNV.Select();
                        return;
                    }
                }
                string hoTen = txtHoTen.Texts;
                string gioiTinh = cbbGioiTinh.Text;
                string sdt = txtSDT.Texts;
                using (var context = new QLTOURDBContext())
                {
                    var selectedSoHD = selectedRow.Cells[4].Value.ToString();

                    var duplicateSoHD = context.NHANVIENs.FirstOrDefault(s => s.SDT == sdt && s.SDT != selectedSoHD);

                    if (duplicateSoHD != null)
                    {
                        MessageBox.Show("SĐT đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtSDT.Select();
                        return;
                    }
                }
                string CCCD = txtCCCD.Texts;
                using (var context = new QLTOURDBContext())
                {
                    var selectedSoHD = selectedRow.Cells[5].Value.ToString();

                    var duplicateSoHD = context.NHANVIENs.FirstOrDefault(s => s.CCCD == CCCD && s.CCCD != selectedSoHD);

                    if (duplicateSoHD != null)
                    {
                        MessageBox.Show("CCCD đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCCCD.Select();
                        return;
                    }
                }
                string Email =txtEmail.Texts;
                using (var context = new QLTOURDBContext())
                {
                    var selectedSoHD = selectedRow.Cells[6].Value.ToString();

                    var duplicateSoHD = context.NHANVIENs.FirstOrDefault(s => s.EMAIL == Email && s.EMAIL != selectedSoHD);

                    if (duplicateSoHD != null)
                    {
                        MessageBox.Show("Email đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtEmail.Select();
                        return;
                    }
                }
                Image image = ptbAnh.Image;
                byte[] imageBytes;
                DateTime NgaySinh = dpkNgaySinh.Value;
                if (string.IsNullOrEmpty(maNV))
                {
                    MessageBox.Show("Mã NV không được bỏ trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaNV.Select();
                    return;
                }

                if (maNV.Length > 12)
                {
                    MessageBox.Show("Mã NV không được quá 12 chữ số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaNV.Select();
                    return;
                }

                using (var context = new QLTOURDBContext())
                {
                    var selectedSoHD = selectedRow.Cells[0].Value.ToString(); // Lấy giá trị MaNV của dòng đang chọn

                    // Kiểm tra trùng MaNV với những dòng khác (không bao gồm dòng đang chọn)
                    var duplicateSoHD = context.NHANVIENs.FirstOrDefault(s => s.MANV == maNV && s.MANV != selectedSoHD);
                    if (duplicateSoHD != null)
                    {
                        MessageBox.Show("Số hóa đơn đã tồn tại. Vui lòng chọn một số hóa đơn khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtMaNV.Select();
                        return;
                    }

                    var nhanvienUpdate = context.NHANVIENs.SingleOrDefault(s => s.MANV == selectedSoHD);
                    if (nhanvienUpdate != null)
                    {
                        nhanvienUpdate.MANV = maNV;
                        nhanvienUpdate.HOTEN = hoTen;
                        nhanvienUpdate.GIOITINH = gioiTinh;
                        nhanvienUpdate.SDT = sdt;
                        nhanvienUpdate.NGAYSINH = NgaySinh;
                        nhanvienUpdate.CCCD = CCCD;
                        nhanvienUpdate.EMAIL = Email;
                        /*using (MemoryStream stream = new MemoryStream())
                        {
                            image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                            imageBytes = stream.ToArray();
                            stream.Close();
                        }
                        nhanvienUpdate.ANH = imageBytes;*/
                        context.SaveChanges();
                        // Cập nhật dữ liệu trong DataGridView
                        selectedRow.Cells[0].Value = maNV;
                        selectedRow.Cells[1].Value = hoTen;
                        selectedRow.Cells[2].Value = gioiTinh;
                        selectedRow.Cells[3].Value = NgaySinh;
                        selectedRow.Cells[4].Value = sdt;
                        selectedRow.Cells[5].Value = CCCD;
                        selectedRow.Cells[6].Value = Email;
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
            }
        }
        private void reset()
        {
            this.txtMaNV.Texts = string.Empty;
            this.txtHoTen.Texts = string.Empty;
            this.cbbGioiTinh.Text = "Nam";
            this.txtSDT.Texts = string.Empty;
            this.txtCCCD.Texts = string.Empty;
            this.txtEmail.Texts = string.Empty;
            this.ptbAnh.Image = null;
        }
        private void xoa(string manv)
        {
            QLTOURDBContext context = new QLTOURDBContext();
            List<HOADON> hoadonlist = context.HOADONs.ToList();
            NHANVIEN delete = context.NHANVIENs.FirstOrDefault(p => p.MANV.ToString() == manv);
            foreach (var hoadon in hoadonlist)
            {
                if (hoadon.MANV.ToString() == manv)
                {
                    HOADON deletehoadonFKTOUR = context.HOADONs.FirstOrDefault(s => s.MANV.ToString() == manv);
                    if (delete != null)
                    {
                        context.HOADONs.Remove(deletehoadonFKTOUR);

                        context.SaveChanges();
                    }
                }
            }
            context.NHANVIENs.Remove(delete);
            context.SaveChanges();
        }
        private void btXoa_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvDSNV.Rows.Count; i++)
            {
                if (dgvDSNV.Rows[i].Cells[7].Value != null)
                {
                    if (MessageBox.Show("Bạn có chắc muốn xóa nhân viên: " + dgvDSNV.Rows[i].Cells[1].Value.ToString() + " ?", "Xác Nhận Xóa !!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //dgvDSNV.Rows.RemoveAt(i);
                        xoa(dgvDSNV.Rows[i].Cells[0].Value.ToString());
                    }
                }
            }
            List<NHANVIEN> listNhanVien = contest.NHANVIENs.ToList();
            BindGridView(listNhanVien);
        }

        private void btTim_Click(object sender, EventArgs e)
        {
            List<NHANVIEN> listNhanVen = contest.NHANVIENs.ToList();

            if (!string.IsNullOrEmpty(txtMaNV.Texts))
            {
                listNhanVen = listNhanVen.Where(s => s.MANV.Equals(txtMaNV.Texts)).ToList();
            }
            else if (!string.IsNullOrEmpty(txtHoTen.Texts))
            {
                listNhanVen = listNhanVen.Where(s => s.HOTEN.Equals(txtHoTen.Texts)).ToList();
            }
            else if (!string.IsNullOrEmpty(cbbGioiTinh.Text))
            {
                listNhanVen = listNhanVen.Where(s => s.GIOITINH.Equals(cbbGioiTinh.Text)).ToList();
            }
            else if (!string.IsNullOrEmpty(dpkNgaySinh.Text))
            {
                listNhanVen = listNhanVen.Where(s => s.NGAYSINH.Equals(cbbGioiTinh.Text)).ToList();
            }
            else if (!string.IsNullOrEmpty(txtSDT.Texts))
            {
                listNhanVen = listNhanVen.Where(s => s.SDT.Equals(txtSDT.Texts)).ToList();
            }
            else if (!string.IsNullOrEmpty(txtCCCD.Texts))
            {
                listNhanVen = listNhanVen.Where(s => s.CCCD.Equals(txtCCCD.Texts)).ToList();
            }
            else if (!string.IsNullOrEmpty(cbbGioiTinh.Text))
            {
                listNhanVen = listNhanVen.Where(s => s.EMAIL.Equals(txtEmail.Text)).ToList();
            }
            BindGridView(listNhanVen);
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            this.txtMaNV.Texts = string.Empty;
            this.txtHoTen.Texts = string.Empty;
            this.cbbGioiTinh.Text = "Nam";
            this.txtSDT.Texts = string.Empty;
            this.txtCCCD.Texts = string.Empty;
            this.txtEmail.Texts = string.Empty;
            this.ptbAnh.Image = null;
            List<NHANVIEN> listNhanVien = contest.NHANVIENs.ToList();
            BindGridView(listNhanVien);
        }

        private void btTaiLen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Tệp ảnh|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog.Title = "Chọn ảnh";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;

                try
                {
                    ptbAnh.SizeMode = PictureBoxSizeMode.Zoom;
                    ptbAnh.Image = Image.FromFile(selectedFilePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvDSNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvDSNV.Rows[e.RowIndex];
                string maNV = selectedRow.Cells[0].Value.ToString();
                txtMaNV.Texts = maNV;
                txtHoTen.Texts = selectedRow.Cells[1].Value.ToString();
                cbbGioiTinh.SelectedItem = selectedRow.Cells[2].Value.ToString();
                txtSDT.Texts = selectedRow.Cells[4].Value.ToString();
                txtCCCD.Texts = selectedRow.Cells[5].Value.ToString();
                txtEmail.Texts = selectedRow.Cells[6].Value.ToString();
                string ngaySinhStr = selectedRow.Cells[3].Value.ToString();
                if (DateTime.TryParse(ngaySinhStr, out DateTime ngaySinh))
                {
                    dpkNgaySinh.Value = ngaySinh;
                }
                else
                {
                    dpkNgaySinh.Value = DateTime.Today;
                }

                using (var context = new QLTOURDBContext())
                {
                    var nhanvien = context.NHANVIENs.SingleOrDefault(nv => nv.MANV == maNV);
                    if (nhanvien != null && nhanvien.ANH != null)
                    {
                        using (MemoryStream ms = new MemoryStream(nhanvien.ANH))
                        {
                            ptbAnh.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        ptbAnh.Image = null;
                    }
                }
            }
            else
            {
                ptbAnh.Image = null;
            }
        }

        private void txtMaNV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 22) // 22 là mã ASCII của ký tự Ctrl + V
            {
                e.Handled = true;
                return;
            }
            if (!char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Chỉ Nhập chữ", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtMaNV.Texts.Length >= 11 && e.KeyChar != '\b')
            {
                e.Handled = true; // Hủy sự kiện KeyPress
                MessageBox.Show("Mã nhân viên không quá 11 ký tự!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (IsDiacritic(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtHoTen_KeyPress(object sender, KeyPressEventArgs e)
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
            if (txtHoTen.Texts.Length >= 50 && e.KeyChar != '\b')
            {
                e.Handled = true; // Hủy sự kiện KeyPress
                MessageBox.Show("Tên nhân viên không quá 50 ký tự!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
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
            if (txtSDT.Texts.Length > 12 && e.KeyChar != '\b')
            {
                e.Handled = true; // Hủy sự kiện KeyPress
                MessageBox.Show("số điện thoại nhân viên không quá 12 ký tự!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
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
        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtEmail.Texts.Length >= 254 && e.KeyChar != '\b')
            {
                e.Handled = true; // Hủy sự kiện KeyPress
                MessageBox.Show("Email không quá 254 ký tự!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (IsDiacritic(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cbbGioiTinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void dpkNgaySinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtMaNV_Enter(object sender, EventArgs e)
        {
            txtMaNV.BackColor = Color.Gainsboro;
        }

        private void txtMaNV_Leave(object sender, EventArgs e)
        {
            txtMaNV.BackColor = Color.White;
        }

        private void txtHoTen_Enter(object sender, EventArgs e)
        {
            txtHoTen.BackColor = Color.Gainsboro;
        }

        private void txtHoTen_Leave(object sender, EventArgs e)
        {
            txtHoTen.BackColor = Color.White;
        }

        private void txtSDT_Enter(object sender, EventArgs e)
        {
            txtSDT.BackColor = Color.Gainsboro;
        }

        private void txtSDT_Leave(object sender, EventArgs e)
        {
            txtSDT.BackColor = Color.White;
        }

        private void txtCCCD_Enter(object sender, EventArgs e)
        {
            txtCCCD.BackColor = Color.Gainsboro;
        }

        private void txtCCCD_Leave(object sender, EventArgs e)
        {
            txtCCCD.BackColor = Color.White;
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            txtEmail.BackColor = Color.Gainsboro;
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            txtEmail.BackColor = Color.White;
        }

        private void btnTHOAT_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvDSNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7 && e.RowIndex >= 0)
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)dgvDSNV.Rows[e.RowIndex].Cells[7];
                bool currentValue = Convert.ToBoolean(cell.Value);
                cell.Value = !currentValue;
                dgvDSNV.EndEdit(); // Kết thúc chỉnh sửa ô để cập nhật giá trị
                // Tiếp tục xử lý logic khác tại đây nếu cần thiết
            }
        }

        private void txtCCCD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtCCCD.Texts.Length > 12 && e.KeyChar != '\b')
            {
                e.Handled = true; // Hủy sự kiện KeyPress
                MessageBox.Show("Căn cước công dân nhân viên không quá 12 ký tự!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
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

        private void btnXUATEXCEL_Click(object sender, EventArgs e)
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "Save Excel File";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    // Khởi tạo một package Excel
                    using (ExcelPackage package = new ExcelPackage())
                    {
                        // Tạo một worksheet mới
                        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");

                        // Xuất dữ liệu từ DataGridView
                        for (int i = 0; i < dgvDSNV.Rows.Count; i++)
                        {
                            for (int j = 0; j < dgvDSNV.Columns.Count; j++)
                            {
                                worksheet.Cells[i + 1, j + 1].Value = dgvDSNV.Rows[i].Cells[j].Value;
                            }
                        }

                        // Lưu file Excel
                        package.SaveAs(new FileInfo(filePath));
                    }

                    MessageBox.Show("Xuất file Excel thành công!");
                }
            }
        }
    }
}
