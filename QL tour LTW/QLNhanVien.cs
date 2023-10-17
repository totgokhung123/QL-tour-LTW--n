using QL_tour_LTW.ModelQLTOUR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
                string MaNV = txtMaNV.Texts;
                string hoten = txtHoTen.Texts;
                string gioiTinh = cbbGioiTinh.Text;
                string NgaySinh = dpkNgaySinh.Text;
                DateTime ngaySinh = dpkNgaySinh.Value;
                string SDT = txtSDT.Texts;
                string CCCD = txtCCCD.Texts;
                string email = txtEmail.Texts;

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
                if (txtMaNV.Texts == "")
                {
                    MessageBox.Show("Mã nhân viên không được bỏ trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaNV.Select();
                    return;
                }
                if (txtMaNV.Texts.Length < 4)
                {
                    MessageBox.Show("Mã NV phải ít nhất có 4 chữ số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                using (var context = new QLTOURDBContext())
                {
                    var nhanvienUpdate = context.NHANVIENs.SingleOrDefault(nv => nv.MANV == MaNV);
                    if (nhanvienUpdate != null)
                    {
                        nhanvienUpdate.MANV = MaNV;
                        nhanvienUpdate.HOTEN = hoten;
                        nhanvienUpdate.GIOITINH = gioiTinh;
                        nhanvienUpdate.NGAYSINH = ngaySinh;
                        nhanvienUpdate.SDT = SDT;
                        nhanvienUpdate.CCCD = CCCD;
                        nhanvienUpdate.EMAIL = email;
                        nhanvienUpdate.ANH = imageBytes;
                        context.SaveChanges();
                        MessageBox.Show("Đã sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Cập nhật dữ liệu trong DataGridView
                        selectedRow.Cells["MaNV"].Value = maNV;
                        selectedRow.Cells["Hoten"].Value = hoten;
                        selectedRow.Cells["GioiTinh"].Value = gioiTinh;
                        selectedRow.Cells["NgaySinh"].Value = ngaySinh;
                        selectedRow.Cells["SDT"].Value = sdt;
                        selectedRow.Cells["CCCD"].Value = cccd;
                        selectedRow.Cells["Email"].Value = email;
                        selectedRow.Cells["Anh"].Value = imageBytes;
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

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (dgvDSNV.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Bạn có muốn xóa ?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    int selectedRowIndex = dgvDSNV.SelectedRows[0].Index;
                    string maNV = dgvDSNV.Rows[selectedRowIndex].Cells[0].Value.ToString();
                    dgvDSNV.Rows.RemoveAt(selectedRowIndex);
                    //using (var contest = new QLTOURDBContext())
                    //{
                    var employee = contest.NHANVIENs.SingleOrDefault(nv => nv.MANV == maNV);
                    if (employee != null)
                    {
                        contest.NHANVIENs.Remove(employee);
                        contest.SaveChanges();
                        MessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.txtMaNV.Texts = string.Empty;
                        this.txtHoTen.Texts = string.Empty;
                        this.cbbGioiTinh.Text = "Nam";
                        this.txtSDT.Texts = string.Empty;
                        this.txtCCCD.Texts = string.Empty;
                        this.txtEmail.Texts = string.Empty;
                        this.ptbAnh.Image = null;
                    }
                }
                else
                {
                    MessageBox.Show("Nhân viên không tồn tại trong CSDL.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //}
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
            if (txtSDT.Texts.Length > 13 && e.KeyChar != '\b')
            {
                e.Handled = true; // Hủy sự kiện KeyPress
                MessageBox.Show("số điện thoại nhân viên không quá 13 ký tự!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtCCCD.Texts.Length > 13 && e.KeyChar != '\b')
            {
                e.Handled = true; // Hủy sự kiện KeyPress
                MessageBox.Show("Căn cước công dân nhân viên không quá 13 ký tự!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtEmail.Texts.Length >= 254 && e.KeyChar != '\b')
            {
                e.Handled = true; // Hủy sự kiện KeyPress
                MessageBox.Show("Email không quá 254 ký tự!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
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
    }
}
