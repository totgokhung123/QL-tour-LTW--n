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
        private int checkMAKH(string maT)
        {
            QLTOURDBContext context = new QLTOURDBContext();
            KHACHHANG tim = context.KHACHHANGs.FirstOrDefault(s => s.MAKH == maT);
            if (tim != null)
            {
                return 4;
            }
            return 5;
        }
        public bool IsSDTExists(string sdt)
        {
            using (QLTOURDBContext context = new QLTOURDBContext())
            {
                var existingEmployee = context.KHACHHANGs
                    .FirstOrDefault(e => e.SDT == sdt);

                return existingEmployee != null;
            }
        }
        public bool IsCCCDExists(string cccd)
        {
            using (QLTOURDBContext context = new QLTOURDBContext())
            {
                var existingEmployee = context.KHACHHANGs
                    .FirstOrDefault(e => e.CCCD == cccd);

                return existingEmployee != null;
            }

        }
        public bool IsEmailExists(string email)
        {
            using (QLTOURDBContext context = new QLTOURDBContext())
            {
                var existingEmployee = context.KHACHHANGs
                    .FirstOrDefault(e => e.EMAIL == email);

                return existingEmployee != null;
            }
        }
        private void btnTHEM_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMAKH.Texts == "" || txtHO.Texts == "" || txtTEN.Texts == "" ||
                    txtSODT.Texts == "" || txtCCCD.Texts == "" || txtEMAIL.Texts == "")
                    MessageBox.Show("Thiếu thông tin khách hàng!", "thông báo");
                else
                {
                    if (IsSDTExists(txtSODT.Texts))
                    {
                        MessageBox.Show("SDT đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtSODT.Select();
                        return;
                    }
                    else if (IsCCCDExists(txtCCCD.Texts))
                    {
                        MessageBox.Show("CCCD đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCCCD.Select();
                        return;
                    }
                    else if (IsEmailExists(txtEMAIL.Texts))
                    {
                        MessageBox.Show("EMAIL đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtEMAIL.Select();
                        return;
                    }
                    else
                    {
                        int temp = checkMAKH(txtMAKH.Texts);
                        //KHACHHANG themKH = context.KHACHHANGs.FirstOrDefault(s => s.MAKH == txtMAKH.Texts);
                        //string mapt = cbbMAPT.SelectedValue != null ? cbbMAPT.SelectedValue.ToString() : null;
                        if (temp == 4)
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
                                clearTextBox();
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
                                clearTextBox();
                            }
                        }
                    }
                    

                    
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Khách hàng đã tồn tại!", "Thông báo", MessageBoxButtons.OKCancel);
                MessageBox.Show(ex.ToString());

            }
        }

        private void btnXOA_Click(object sender, EventArgs e)
        {
            int seledtedRow = GetSelectedRow(txtMAKH.Texts);
            if (seledtedRow == -1)
            {
                MessageBox.Show("Không có sinh viên!", "thông báo");
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn xóa ?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    dgvDSKHACHHANG.Rows.RemoveAt(seledtedRow);
                    QLTOURDBContext context = new QLTOURDBContext();
                    List<HOADON> hoadonlist = context.HOADONs.ToList();
                    KHACHHANG delete = context.KHACHHANGs.FirstOrDefault(p => p.MAKH.ToString() == txtMAKH.Texts);
                    foreach (var hoadon in hoadonlist)
                    {
                        if (hoadon.MAKH.ToString() == txtMAKH.Texts)
                        {
                            HOADON deletehoadonFKTOUR = context.HOADONs.FirstOrDefault(s => s.MAKH.ToString() == txtMAKH.Texts);
                            if (delete != null)
                            {
                                context.HOADONs.Remove(deletehoadonFKTOUR);

                                context.SaveChanges();
                            }
                        }
                    }
                    context.KHACHHANGs.Remove(delete);
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
                        txtSODT.Texts == "" || txtCCCD.Texts == "" || txtEMAIL.Texts == "")
                    MessageBox.Show("Thiếu thông tin khách hàng!", "thông báo");
                else
                {
                    int seledtedRow = GetSelectedRow(txtMAKH.Texts);
                    if (seledtedRow == -1)
                    {
                        MessageBox.Show("Đã có sinh viên!", "thông báo");
                    }
                    else
                    {
                    string soluong = txtSLTV.Texts != null ? int.Parse(txtSLTV.Texts).ToString() : null;
                        
                    QLTOURDBContext context = new QLTOURDBContext();
                        KHACHHANG timsdtkhkhiclick = context.KHACHHANGs.FirstOrDefault(s => s.MAKH == txtMAKH.Texts || s.SDT == txtSODT.Texts  || s.CCCD == txtCCCD.Texts || s.EMAIL == txtEMAIL.Texts );
                        KHACHHANG timsdtkhkhiclick2 = context.KHACHHANGs.FirstOrDefault(s => s.MAKH == txtMAKH.Texts && s.SDT == txtSODT.Texts && s.CCCD == txtCCCD.Texts );
                        KHACHHANG timsdtkhkhiclick3 = context.KHACHHANGs.FirstOrDefault(s => s.MAKH == txtMAKH.Texts && s.SDT == txtSODT.Texts && s.EMAIL == txtEMAIL.Texts);
                        KHACHHANG timsdtkhkhiclick4 = context.KHACHHANGs.FirstOrDefault(s => s.MAKH == txtMAKH.Texts && s.CCCD == txtCCCD.Texts && s.EMAIL == txtEMAIL.Texts);
                        KHACHHANG tim = context.KHACHHANGs.FirstOrDefault(s => s.MAKH == txtMAKH.Texts);
                        if (timsdtkhkhiclick != null)
                        {
                            // cập nhật ko sửa thafh công
                            insertKhachHang(seledtedRow);
                            KHACHHANG kh = timKhanhHang(txtMAKH.Texts);
                            kh.MAKH = txtMAKH.Texts;
                            kh.HO = txtHO.Texts;
                            kh.TEN = txtTEN.Texts;
                            kh.SDT = txtSODT.Texts;
                            kh.CCCD = txtCCCD.Texts;
                            kh.EMAIL = txtEMAIL.Texts;
                            kh.SL = int.Parse(soluong);
                            context.SaveChanges();
                            MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK);
                            clearTextBox();
                        }
                        
                        else if (tim != null)
                        {
                            KHACHHANG sdt = context.KHACHHANGs.FirstOrDefault(s => s.SDT == txtSODT.Texts);
                            KHACHHANG cccd = context.KHACHHANGs.FirstOrDefault(s => s.CCCD == txtCCCD.Texts);
                            KHACHHANG email = context.KHACHHANGs.FirstOrDefault(s => s.EMAIL == txtEMAIL.Texts);
                            if (sdt != null)
                            {
                                // bị trùng thông báo                                 
                                MessageBox.Show("Số điện thoại bị trùng");
                                return;
                                
                            }
                            else if( cccd != null )
                            {
                                // cccd bị trùng                                
                                MessageBox.Show("căn cước bị trùng");
                                return;
                            }
                            else if( email != null )
                            {
                                // email bị trùng                               
                                MessageBox.Show("email bị trùng");
                                return;
                            }
                            else
                            {
                                insertKhachHang(seledtedRow);
                                KHACHHANG kh = timKhanhHang(txtMAKH.Texts);
                                kh.MAKH = txtMAKH.Texts;
                                kh.HO = txtHO.Texts;
                                kh.TEN = txtTEN.Texts;
                                kh.SDT = txtSODT.Texts;
                                kh.CCCD = txtCCCD.Texts;
                                kh.EMAIL = txtEMAIL.Texts;
                                kh.SL = int.Parse(soluong);
                                context.SaveChanges();
                                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK);
                                clearTextBox();
                            }
                        }
                        /// ham update
                           
                    }                    
                }
              
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

        private void txtHO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar !=' ')
            {
                MessageBox.Show("Vui lòng nhập chữ!", "thông báo");
                e.Handled = true;
            }
            if (txtHO.Texts.Length >= 32 && e.KeyChar != '\b')
            {
                e.Handled = true;
                MessageBox.Show("Họ tên đệm khống quá 32 ký tự!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (e.KeyChar == 22)
            {
                e.Handled = true;
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
            if (txtCCCD.Texts.Length > 13 && e.KeyChar != '\b')
            {
                e.Handled = true;
                MessageBox.Show("căn cước không quá 13 ký tự!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtSODT.Texts.Length > 13 && e.KeyChar != '\b')
            {
                e.Handled = true;
                MessageBox.Show("Số điện thoại không quá 13 ký tự!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
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
                MessageBox.Show("Họ tên đệm của khánh hàng không quá 32 ký tự!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private GiaoDienQLThongTInKH mainForm;
        public void setMainForm(GiaoDienQLThongTInKH form)
        {
            this.mainForm = form;
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
            txtSODT.BackColor = Color.White;
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

        private void btnRESET_MouseUp(object sender, MouseEventArgs e)
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

        private void btnCAPNHAT_MouseDown(object sender, MouseEventArgs e)
        {
            btnCAPNHAT.BorderSize = 3;
            btnCAPNHAT.BorderColor = Color.MidnightBlue;
        }

        private void btnXOA_MouseDown(object sender, MouseEventArgs e)
        {
            btnXOA.BorderSize = 3;
            btnXOA.BorderColor = Color.MidnightBlue;
        }

        private void btnTROVE_MouseDown(object sender, MouseEventArgs e)
        {
            btnTROVE.BorderSize = 3;
            btnTROVE.BorderColor = Color.MidnightBlue;
        }

        private void txtMAKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ContainsDiacriticOrWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // Ngăn chặn ký tự có dấu và khoảng trắng được nhập vào
                return;
            }
            if (e.KeyChar == 22) 
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
            if (txtMAKH.Texts.Length >= 11 && e.KeyChar != '\b')
            {
                e.Handled = true; 
                MessageBox.Show("Mã khách hàng không quá 11 ký tự!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void txtTEN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtTEN.Texts.Length >= 11 && e.KeyChar != '\b')
            {
                e.Handled = true;
                MessageBox.Show("Tên khách hàng không quá 11 ký tự!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (e.KeyChar == 22)
            {
                e.Handled = true;
                return;
            }
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Chỉ Nhập chữ", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void txtEMAIL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ContainsDiacriticOrWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // Ngăn chặn ký tự có dấu và khoảng trắng được nhập vào
                return;
            }
            if (txtEMAIL.Texts.Length >= 254 && e.KeyChar != '\b')
            {
                e.Handled = true; // Hủy sự kiện KeyPress
                MessageBox.Show("Email không quá 254 ký tự!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        private bool ContainsDiacriticOrWhiteSpace(char c)
        {
            string diacriticsAndWhiteSpace = "ÀÁÂÃẠĂẮẰẤẦẴẶẤẨẪÈÉÊẺẼẸỀẾỂỄỆÌÍỈĨỊÒÓÔÕỌƠỚỜỢỞỠÙÚỦŨỤƯỨỪỬỮỰỲÝỶỸỴàáâãạăắằấầẵặấẩẫèéêẻẽẹềếểễệìíỉĩịòóôõọơớờợởỡùúủũụưứừửữựỳýỷỹỵ ";
            return diacriticsAndWhiteSpace.Contains(c);
        }
        private bool IsInvalidCharacter(char ch)
        {
            // Kiểm tra ký tự có dấu
            if (char.IsLetter(ch) && !char.IsLetterOrDigit(ch))
            {
                return true;
            }

            return false;
        }
    }
}
