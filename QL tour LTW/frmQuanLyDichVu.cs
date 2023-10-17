using QL_tour_LTW.ModelQLTOUR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_tour_LTW
{
    public partial class frmQuanLyDichVu : Form
    {
        static QLTOURDBContext context = new QLTOURDBContext();
        public frmQuanLyDichVu()
        {
            InitializeComponent();
        }

        private void frmQuanLyDichVu_Load(object sender, EventArgs e)
        {
            List<KHACHSAN> listKS = context.KHACHSANs.ToList();
            List<PHUONGTIEN> listPT = context.PHUONGTIENs.ToList();
            List<DIEMDI> listDDi = context.DIEMDIs.ToList();
            List<DIEMDEN> listDDen = context.DIEMDENs.ToList();
            List<LOAITOUR> listLTour = context.LOAITOURs.ToList();

            BindToGridKS(listKS);
            BindToGridPT(listPT);
            BindToGridDDi(listDDi);
            FillMaLTourDDiCombobox(listLTour);
            BindToGridDDen(listDDen);
            FillMaLTourDDenCombobox(listLTour);
        }
        private void FillMaLTourDDiCombobox(List<LOAITOUR> listDiemDi)
        {
            this.cbxMaLTourDDi.DataSource = listDiemDi;
            this.cbxMaLTourDDi.DisplayMember = "MALTOUR";
            this.cbxMaLTourDDi.ValueMember = "MALTOUR";
        }
        private void FillMaLTourDDenCombobox(List<LOAITOUR> listDiemDen)
        {
            this.cbxMaLTourDDen.DataSource = listDiemDen;
            this.cbxMaLTourDDen.DisplayMember = "MALTOUR";
            this.cbxMaLTourDDen.ValueMember = "MALTOUR";
        }

        private void BindToGridDDen(List<DIEMDEN> listDDen)
        {
            dgvDSDDen.Rows.Clear();
            foreach (var item in listDDen)
            {
                int index = dgvDSDDen.Rows.Add();
                dgvDSDDen.Rows[index].Cells[0].Value = item.MADDEN;
                dgvDSDDen.Rows[index].Cells[1].Value = item.TENDDEN;
                dgvDSDDen.Rows[index].Cells[2].Value = item.MALTOUR;
            }
        }

        private void BindToGridDDi(List<DIEMDI> listDDi)
        {
            dgvDSDDi.Rows.Clear();
            foreach (var item in listDDi)
            {
                int index = dgvDSDDi.Rows.Add();
                dgvDSDDi.Rows[index].Cells[0].Value = item.MADDI;
                dgvDSDDi.Rows[index].Cells[1].Value = item.TENDDI;
                dgvDSDDi.Rows[index].Cells[2].Value = item.MALTOUR;
            }
        }

        private void BindToGridKS(List<KHACHSAN> listKS)
        {
            dgvDSKS.Rows.Clear();
            foreach (var item in listKS)
            {
                int index = dgvDSKS.Rows.Add();
                dgvDSKS.Rows[index].Cells[0].Value = item.MAKS;
                dgvDSKS.Rows[index].Cells[1].Value = item.TENKS;
                dgvDSKS.Rows[index].Cells[2].Value = item.DIACHI;
                dgvDSKS.Rows[index].Cells[3].Value = item.TRANGTHAI;
            }
        }

        private void BindToGridPT(List<PHUONGTIEN> listPT)
        {
            dgvDSPT.Rows.Clear();
            foreach (var item in listPT)
            {
                int index = dgvDSPT.Rows.Add();
                dgvDSPT.Rows[index].Cells[0].Value = item.MAPT;
                dgvDSPT.Rows[index].Cells[1].Value = item.TENPT;
                dgvDSPT.Rows[index].Cells[2].Value = item.TRANGTHAI;
            }
        }
        public bool checkNullKS()
        {
            if (txtMaKS.Texts == "" || txtTenKS.Texts == "" || txtTrangThaiKS.Texts == "" || txtDiaChiKS.Texts == "")
                return true;
            return false;
        }
        public bool checkNullPT()
        {
            if (txtMaPT.Texts == "" || txtTenPT.Texts == "" || txtTrangThaiPT.Texts == "")
                return true;
            return false;
        }
        public bool checkNullDiemDi()
        {
            if (txtMaDDi.Texts == "" || txtTenDDi.Texts == "" || cbxMaLTourDDi.Text == "")
                return true;
            return false;
        }
        public bool checkNullDiemDen()
        {
            if (txtMaDDen.Texts == "" || txtTenDDen.Texts == "" || cbxMaLTourDDen.Text == "")
                return true;
            return false;
        }
        public bool checkMaKS()
        {
            if (txtMaKS.Texts.Length < 4)
                return false;
            return true;
        }

        public bool checkMaPT()
        {
            if (txtMaPT.Texts.Length < 4)
                return false;
            return true;
        }

        public bool checkMaDiemDi()
        {
            if (txtMaDDi.Texts.Length < 5)
                return false;
            return true;
        }

        public bool checkMaDiemDen()
        {
            if (txtMaDDen.Texts.Length < 5)
                return false;
            return true;
        }

        private bool timKhachSan()
        {
            var timKS = context.KHACHSANs.FirstOrDefault(s => s.MAKS.Equals(txtMaKS.Texts));
            if (timKS != null)
                return true;
            return false;
        }
        private bool timPhuongTien()
        {
            var timPT = context.PHUONGTIENs.FirstOrDefault(s => s.MAPT.Equals(txtMaPT.Texts));
            if (timPT != null)
                return true;
            return false;
        }
        private bool timDiemDi()
        {
            var timDDi = context.DIEMDIs.FirstOrDefault(s => s.MADDI.Equals(txtMaDDi.Texts));
            if (timDDi != null)
                return true;
            return false;
        }
        private bool timDiemDen()
        {
            var timDDen = context.DIEMDENs.FirstOrDefault(s => s.MADDEN.Equals(txtMaDDen.Texts));
            if (timDDen != null)
                return true;
            return false;
        }

        public void resetNullKS()
        {
            txtMaKS.Texts = txtTenKS.Texts = txtTrangThaiKS.Texts = txtDiaChiKS.Texts = string.Empty;
        }
        public void resetNullPT()
        {
            txtMaPT.Texts = txtTenPT.Texts = txtTrangThaiPT.Texts = string.Empty;
        }
        public void resetNullDDi()
        {
            txtMaDDi.Texts = txtTenDDi.Texts = cbxMaLTourDDi.Text = string.Empty;
        }
        public void resetNullDDen()
        {
            txtMaDDen.Texts = txtTenDDen.Texts = cbxMaLTourDDen.Text = string.Empty;
        }

        private int GetSelectedRowKS(string MaKS)
        {
            try
            {
                for (int i = 0; i < dgvDSKS.Rows.Count; i++)
                {
                    if (dgvDSKS.Rows[i].Cells[0].Value != null && dgvDSKS.Rows[i].Cells[0].Value.ToString() == MaKS)
                    {
                        return i;
                    }
                }
            }
            catch { }
            return -1;
        }

        private int GetSelectedRowPT(string MaPT)
        {
            try
            {
                for (int i = 0; i < dgvDSPT.Rows.Count; i++)
                {
                    if (dgvDSPT.Rows[i].Cells[0].Value != null && dgvDSPT.Rows[i].Cells[0].Value.ToString() == MaPT)
                    {
                        return i;
                    }
                }
            }
            catch { }
            return -1;
        }
        private int GetSelectedRowDDi(string MaDDi)
        {
            try
            {
                for (int i = 0; i < dgvDSDDi.Rows.Count; i++)
                {
                    if (dgvDSDDi.Rows[i].Cells[0].Value != null && dgvDSDDi.Rows[i].Cells[0].Value.ToString() == MaDDi)
                    {
                        return i;
                    }
                }
            }
            catch { }
            return -1;
        }
        private int GetSelectedRowDDen(string MaDDen)
        {
            try
            {
                for (int i = 0; i < dgvDSDDen.Rows.Count; i++)
                {
                    if (dgvDSDDen.Rows[i].Cells[0].Value != null && dgvDSDDen.Rows[i].Cells[0].Value.ToString() == MaDDen)
                    {
                        return i;
                    }
                }
            }
            catch { }
            return -1;
        }

        private void btnThemKS_Click(object sender, EventArgs e)
        {
            if (checkNullKS())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            if (checkMaKS() == false)
            {
                MessageBox.Show("Mã khách sạn phải có ít nhất 4 ký tự!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (timKhachSan())
            {
                MessageBox.Show("Khách sạn đã tồn tại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                int row = dgvDSKS.Rows.Add();
                insertKS(row);
                MessageBox.Show("Thêm khách sạn thành công!", "Thông báo!", MessageBoxButtons.OK);
                resetNullKS();
            }
        }
        public void insertKS(int row)
        {
            dgvDSKS.Rows[row].Cells[0].Value = txtMaKS.Texts;
            dgvDSKS.Rows[row].Cells[1].Value = txtTenKS.Texts;
            dgvDSKS.Rows[row].Cells[2].Value = txtDiaChiKS.Texts;
            dgvDSKS.Rows[row].Cells[3].Value = txtTrangThaiKS.Texts;
            KHACHSAN khachSan = new KHACHSAN() { MAKS = txtMaKS.Texts, TENKS = txtTenKS.Texts, DIACHI = txtDiaChiKS.Texts, TRANGTHAI = txtTrangThaiKS.Texts };
            context.KHACHSANs.Add(khachSan);
            context.SaveChanges();
        }
        private void xoaks(string maks)
        {
            KHACHSAN delete = context.KHACHSANs.FirstOrDefault(p => p.MAKS == maks);
            context.KHACHSANs.Remove(delete);
            context.SaveChanges();
            MessageBox.Show("Xóa thành công!", "Thông báo");
            resetNullKS();
        }
        private void btnXoaKS_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvDSKS.Rows.Count; i++)
            {
                if (dgvDSKS.Rows[i].Cells[4].Value != null)
                {
                    if (MessageBox.Show("Bạn có chắc muốn xóa khách sạn: " + dgvDSKS.Rows[i].Cells[1].Value.ToString() + " ?", "Xác Nhận Xóa !!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //dgvDSNV.Rows.RemoveAt(i);
                        xoaks(dgvDSKS.Rows[i].Cells[0].Value.ToString());
                    }
                }
            }
            QLTOURDBContext context = new QLTOURDBContext();
            List<KHACHSAN> listNhanVien = context.KHACHSANs.ToList();
            BindToGridKS(listNhanVien);
            //try
            //{
            //    int selcetedRow = GetSelectedRowKS(txtMaKS.Texts);
            //    if (selcetedRow == -1)
            //    {
            //        throw new Exception("Không tìm thấy khách sạn cần xóa!");
            //    }
            //    else
            //    {
            //        if (MessageBox.Show("Bạn có muốn xóa", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            //        {
            //            KHACHSAN delete = context.KHACHSANs.FirstOrDefault(p => p.MAKS == txtMaKS.Texts);
            //            dgvDSKS.Rows.RemoveAt(selcetedRow);
            //            context.KHACHSANs.Remove(delete);
            //            context.SaveChanges();
            //            MessageBox.Show("Xóa thành công!", "Thông báo");
            //            resetNullKS();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void btnSuaKS_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkNullKS())
                    throw new Exception("Vui lòng nhập đẩy đủ thông tin!");
                int seledtedRow = GetSelectedRowKS(txtMaKS.Texts);
                if (seledtedRow != -1)
                {
                    updateKS(seledtedRow);
                    MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tồn tại khách sạn!", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void updateKS(int row)
        {
            dgvDSKS.Rows[row].Cells[0].Value = txtMaKS.Texts;
            dgvDSKS.Rows[row].Cells[1].Value = txtTenKS.Texts;
            dgvDSKS.Rows[row].Cells[2].Value = txtTrangThaiKS.Texts;
            dgvDSKS.Rows[row].Cells[3].Value = txtDiaChiKS.Texts;
            KHACHSAN dbUpdate = context.KHACHSANs.FirstOrDefault(p => p.MAKS == txtMaKS.Texts);
            if (dbUpdate != null)
            {
                dbUpdate.MAKS = txtMaKS.Texts;
                dbUpdate.TENKS = txtTenKS.Texts;
                dbUpdate.TRANGTHAI = txtTrangThaiKS.Texts;
                dbUpdate.DIACHI = txtDiaChiKS.Texts;
                context.SaveChanges();
            }
        }

        private void dgvDSKS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = int.Parse(e.RowIndex.ToString());

            if (index >= 0)
            {
                txtMaKS.Texts = dgvDSKS.Rows[index].Cells[0].Value.ToString();
                txtTenKS.Texts = dgvDSKS.Rows[index].Cells[1].Value.ToString();
                txtDiaChiKS.Texts = dgvDSKS.Rows[index].Cells[2].Value.ToString();

                if (dgvDSKS.Rows[index].Cells[3].Value == null)
                {
                    txtTrangThaiKS.Texts = "Null";
                }
                else
                {
                    txtTrangThaiKS.Texts = dgvDSKS.Rows[index].Cells[3].Value.ToString();
                }
            }
        }

        private void btnTimKS_Click(object sender, EventArgs e)
        {
            List<KHACHSAN> searchListKhachSan = new List<KHACHSAN>();

            if (txtMaKS.Texts != "")
            {
                searchListKhachSan = context.KHACHSANs.Where(s => s.MAKS == txtMaKS.Texts).ToList();
                BindToGridKS(searchListKhachSan);
            }

            else if (txtTenKS.Texts != "")
            {
                searchListKhachSan = context.KHACHSANs.Where(s => s.TENKS == txtTenKS.Texts).ToList();
                BindToGridKS(searchListKhachSan);
            }
            else if (txtDiaChiKS.Texts != "")
            {
                searchListKhachSan = context.KHACHSANs.Where(s => s.DIACHI == txtDiaChiKS.Texts).ToList();
                BindToGridKS(searchListKhachSan);
            }

            else if (txtMaKS.Texts == "" && txtTenKS.Texts == "" && txtDiaChiKS.Texts == "")
            {
                List<KHACHSAN> listKS = context.KHACHSANs.ToList();
                BindToGridKS(listKS);
            }
        }

        private void txtMaKS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ContainsDiacriticOrWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // Ngăn chặn ký tự có dấu và khoảng trắng được nhập vào
                return;
            }
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtTenKS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void txtDiaChiKS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtTrangThaiKS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void btnThemPT_Click(object sender, EventArgs e)
        {
            if (checkNullPT())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            if (checkMaPT() == false)
            {
                MessageBox.Show("Mã phương tiện phải có ít nhất 4 ký tự!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (timPhuongTien())
            {
                MessageBox.Show("Phương tiện đã tồn tại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                int row = dgvDSPT.Rows.Add();
                insertPT(row);
                MessageBox.Show("Thêm phương tiện thành công!", "Thông báo!", MessageBoxButtons.OK);
                resetNullKS();
            }
        }
        public void insertPT(int row)
        {
            dgvDSPT.Rows[row].Cells[0].Value = txtMaPT.Texts;
            dgvDSPT.Rows[row].Cells[1].Value = txtTenPT.Texts;
            dgvDSPT.Rows[row].Cells[2].Value = txtTrangThaiPT.Texts;
            PHUONGTIEN phuongTien = new PHUONGTIEN() { MAPT = txtMaPT.Texts, TENPT = txtTenPT.Texts, TRANGTHAI = txtTrangThaiPT.Texts };
            context.PHUONGTIENs.Add(phuongTien);
            context.SaveChanges();
        }

        private void btnSuaPT_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkNullPT())
                    throw new Exception("Vui lòng nhập đẩy đủ thông tin!");
                int seledtedRow = GetSelectedRowPT(txtMaPT.Texts);
                if (seledtedRow != -1)
                {
                    updatePT(seledtedRow);
                    MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tồn tại phương tiện cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void updatePT(int row)
        {
            dgvDSPT.Rows[row].Cells[0].Value = txtMaPT.Texts;
            dgvDSPT.Rows[row].Cells[1].Value = txtTenPT.Texts;
            dgvDSPT.Rows[row].Cells[2].Value = txtTrangThaiPT.Texts;
            PHUONGTIEN dbUpdate = context.PHUONGTIENs.FirstOrDefault(p => p.MAPT == txtMaPT.Texts);
            if (dbUpdate != null)
            {
                dbUpdate.MAPT = txtMaPT.Texts;
                dbUpdate.TENPT = txtTenPT.Texts;
                dbUpdate.TRANGTHAI = txtTrangThaiPT.Texts;
                context.SaveChanges();
            }
        }
        private void xoapt(string maks)
        {
            PHUONGTIEN delete = context.PHUONGTIENs.FirstOrDefault(p => p.MAPT == maks);
            context.PHUONGTIENs.Remove(delete);
            context.SaveChanges();
            MessageBox.Show("Xóa thành công!", "Thông báo");
            resetNullKS();
        }
        private void btnXoaPT_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvDSKS.Rows.Count; i++)
            {
                if (dgvDSKS.Rows[i].Cells[3].Value != null)
                {
                    if (MessageBox.Show("Bạn có chắc muốn xóa Phương tiện: " + dgvDSKS.Rows[i].Cells[1].Value.ToString() + " ?", "Xác Nhận Xóa !!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //dgvDSNV.Rows.RemoveAt(i);
                        xoapt(dgvDSKS.Rows[i].Cells[0].Value.ToString());
                    }
                }
            }
            QLTOURDBContext context = new QLTOURDBContext();
            List<PHUONGTIEN> listNhanVien = context.PHUONGTIENs.ToList();
            BindToGridPT(listNhanVien);
        }

        private void btnTimPT_Click(object sender, EventArgs e)
        {
            List<PHUONGTIEN> searchListPhuongTien = new List<PHUONGTIEN>();

            if (txtMaPT.Texts != "")
            {
                searchListPhuongTien = context.PHUONGTIENs.Where(s => s.MAPT == txtMaPT.Texts).ToList();
                BindToGridPT(searchListPhuongTien);
            }

            else if (txtTenPT.Texts != "")
            {
                searchListPhuongTien = context.PHUONGTIENs.Where(s => s.TENPT == txtTenPT.Texts).ToList();
                BindToGridPT(searchListPhuongTien);
            }

            else if (txtMaPT.Texts == "" && txtTenPT.Texts == "")
            {
                List<PHUONGTIEN> listPT = context.PHUONGTIENs.ToList();
                BindToGridPT(listPT);
            }
        }

        private void dgvDSPT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = int.Parse(e.RowIndex.ToString());

            if (index >= 0)
            {
                txtMaPT.Texts = dgvDSPT.Rows[index].Cells[0].Value.ToString();
                txtTenPT.Texts = dgvDSPT.Rows[index].Cells[1].Value.ToString();

                if (dgvDSPT.Rows[index].Cells[2].Value == null)
                {
                    txtTrangThaiPT.Texts = "Null";
                }
                else
                {
                    txtTrangThaiPT.Texts = dgvDSPT.Rows[index].Cells[2].Value.ToString();
                }
            }
        }

        private void txtMaPT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ContainsDiacriticOrWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // Ngăn chặn ký tự có dấu và khoảng trắng được nhập vào
                return;
            }
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtTenPT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void txtTrangThaiPT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void btnThemDDi_Click(object sender, EventArgs e)
        {
            if (checkNullDiemDi())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            if (checkMaDiemDi() == false)
            {
                MessageBox.Show("Mã điểm đi phải có ít nhất 5 ký tự!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else if (timDiemDi())
            {
                MessageBox.Show("Điểm đi đã tồn tại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                int row = dgvDSDDi.Rows.Add();
                insertDDi(row);
                MessageBox.Show("Thêm điểm đi thành công!", "Thông báo!", MessageBoxButtons.OK);
                resetNullKS();
            }
        }
        public void insertDDi(int row)
        {
            dgvDSDDi.Rows[row].Cells[0].Value = txtMaDDi.Texts;
            dgvDSDDi.Rows[row].Cells[1].Value = txtTenDDi.Texts;
            dgvDSDDi.Rows[row].Cells[2].Value = cbxMaLTourDDi.Text;
            DIEMDI diemDI = new DIEMDI() { MADDI = txtMaDDi.Texts, TENDDI = txtTenDDi.Texts, MALTOUR = cbxMaLTourDDi.Text };
            context.DIEMDIs.Add(diemDI);
            context.SaveChanges();
        }

        private void btnSuaDDi_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkNullDiemDi())
                    throw new Exception("Vui lòng nhập đẩy đủ thông tin!");
                int seledtedRow = GetSelectedRowDDi(txtMaDDi.Texts);
                if (seledtedRow != -1)
                {
                    updateDDi(seledtedRow);
                    MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Không tồn tại điểm đi cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void updateDDi(int row)
        {
            dgvDSDDi.Rows[row].Cells[0].Value = txtMaDDi.Texts;
            dgvDSDDi.Rows[row].Cells[1].Value = txtTenDDi.Texts;
            dgvDSDDi.Rows[row].Cells[2].Value = cbxMaLTourDDi.Text;
            DIEMDI dbUpdate = context.DIEMDIs.FirstOrDefault(p => p.MADDI == txtMaDDi.Texts);
            if (dbUpdate != null)
            {
                dbUpdate.MADDI = txtMaDDi.Texts;
                dbUpdate.TENDDI = txtTenDDi.Texts;
                dbUpdate.MALTOUR = cbxMaLTourDDi.Text;
                context.SaveChanges();
            }
        }
        private void xoadi(string maks)
        {
            DIEMDI delete = context.DIEMDIs.FirstOrDefault(p => p.MADDI == maks);
            context.DIEMDIs.Remove(delete);
            context.SaveChanges();
            MessageBox.Show("Xóa thành công!", "Thông báo");
            resetNullKS();
        }
        private void btnXoaDDi_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvDSKS.Rows.Count; i++)
            {
                if (dgvDSKS.Rows[i].Cells[3].Value != null)
                {
                    if (MessageBox.Show("Bạn có chắc muốn xóa điểm đi: " + dgvDSKS.Rows[i].Cells[1].Value.ToString() + " ?", "Xác Nhận Xóa !!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //dgvDSNV.Rows.RemoveAt(i);
                        xoadi(dgvDSKS.Rows[i].Cells[0].Value.ToString());
                    }
                }
            }
            QLTOURDBContext context = new QLTOURDBContext();
            List<DIEMDI> listNhanVien = context.DIEMDIs.ToList();
            BindToGridDDi(listNhanVien);
        }

        private void btnTimDDi_Click(object sender, EventArgs e)
        {
            List<DIEMDI> searchListDiemDi = new List<DIEMDI>();

            if (txtMaDDi.Texts != "")
            {
                searchListDiemDi = context.DIEMDIs.Where(s => s.MADDI == txtMaDDi.Texts).ToList();
                BindToGridDDi(searchListDiemDi);
            }

            else if (txtTenDDi.Texts != "")
            {
                searchListDiemDi = context.DIEMDIs.Where(s => s.TENDDI == txtTenDDi.Texts).ToList();
                BindToGridDDi(searchListDiemDi);
            }

            else if (txtMaDDi.Texts == "" && txtTenDDi.Texts == "")
            {
                List<DIEMDI> listDDi = context.DIEMDIs.ToList();
                BindToGridDDi(listDDi);
            }
        }

        private void dgvDSDDi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = int.Parse(e.RowIndex.ToString());

            if (index >= 0)
            {
                txtMaDDi.Texts = dgvDSDDi.Rows[index].Cells[0].Value.ToString();
                txtTenDDi.Texts = dgvDSDDi.Rows[index].Cells[1].Value.ToString();
                cbxMaLTourDDi.Text = dgvDSDDi.Rows[index].Cells[2].Value.ToString();
            }
        }

        private void txtMaDDi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ContainsDiacriticOrWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // Ngăn chặn ký tự có dấu và khoảng trắng được nhập vào
                return;
            }
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtTenDDi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void btnThemDDen_Click(object sender, EventArgs e)
        {
            if (checkNullDiemDen())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            if (checkMaDiemDen() == false)
            {
                MessageBox.Show("Mã điểm đến phải có ít nhất 5 ký tự!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else if (timDiemDen())
            {
                MessageBox.Show("Điểm đến đã tồn tại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                int row = dgvDSDDen.Rows.Add();
                insertDDen(row);
                MessageBox.Show("Thêm điểm đến thành công!", "Thông báo!", MessageBoxButtons.OK);
                resetNullDDen();
            }
        }
        public void insertDDen(int row)
        {
            dgvDSDDen.Rows[row].Cells[0].Value = txtMaDDen.Texts;
            dgvDSDDen.Rows[row].Cells[1].Value = txtTenDDen.Texts;
            dgvDSDDen.Rows[row].Cells[2].Value = cbxMaLTourDDen.Text;
            DIEMDEN diemDen = new DIEMDEN() { MADDEN = txtMaDDen.Texts, TENDDEN = txtTenDDen.Texts, MALTOUR = cbxMaLTourDDen.Text };
            context.DIEMDENs.Add(diemDen);
            context.SaveChanges();
        }

        private void btnSuaDDen_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkNullDiemDen())
                    throw new Exception("Vui lòng nhập đẩy đủ thông tin!");
                int seledtedRow = GetSelectedRowDDen(txtMaDDen.Texts);
                if (seledtedRow != -1)
                {
                    updateDDen(seledtedRow);
                    MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Không tồn tại điểm đến cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void updateDDen(int row)
        {
            dgvDSDDen.Rows[row].Cells[0].Value = txtMaDDen.Texts;
            dgvDSDDen.Rows[row].Cells[1].Value = txtTenDDen.Texts;
            dgvDSDDen.Rows[row].Cells[2].Value = cbxMaLTourDDen.Text;
            DIEMDEN dbUpdate = context.DIEMDENs.FirstOrDefault(p => p.MADDEN == txtMaDDen.Texts);
            if (dbUpdate != null)
            {
                dbUpdate.MADDEN = txtMaDDen.Texts;
                dbUpdate.TENDDEN = txtTenDDen.Texts;
                dbUpdate.MALTOUR = cbxMaLTourDDen.Text;
                context.SaveChanges();
            }
        }
        private void xoaden(string maks)
        {
            DIEMDEN delete = context.DIEMDENs.FirstOrDefault(p => p.MADDEN == maks);
            context.DIEMDENs.Remove(delete);
            context.SaveChanges();
            MessageBox.Show("Xóa thành công!", "Thông báo");
            resetNullKS();
        }
        private void btnXoaDDen_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvDSKS.Rows.Count; i++)
            {
                if (dgvDSKS.Rows[i].Cells[3].Value != null)
                {
                    if (MessageBox.Show("Bạn có chắc muốn xóa điểm đến: " + dgvDSKS.Rows[i].Cells[1].Value.ToString() + " ?", "Xác Nhận Xóa !!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //dgvDSNV.Rows.RemoveAt(i);
                        xoaden(dgvDSKS.Rows[i].Cells[0].Value.ToString());
                    }
                }
            }
            QLTOURDBContext context = new QLTOURDBContext();
            List<DIEMDEN> listNhanVien = context.DIEMDENs.ToList();
            BindToGridDDen(listNhanVien);
        }

        private void btnTimDDen_Click(object sender, EventArgs e)
        {
            List<DIEMDEN> searchListDiemDen = new List<DIEMDEN>();

            if (txtMaDDen.Texts != "")
            {
                searchListDiemDen = context.DIEMDENs.Where(s => s.MADDEN == txtMaDDen.Texts).ToList();
                BindToGridDDen(searchListDiemDen);
            }

            else if (txtTenDDen.Texts != "")
            {
                searchListDiemDen = context.DIEMDENs.Where(s => s.TENDDEN == txtTenDDen.Texts).ToList();
                BindToGridDDen(searchListDiemDen);
            }

            else if (txtMaDDen.Texts == "" && txtTenDDen.Texts == "")
            {
                List<DIEMDEN> listDDen = context.DIEMDENs.ToList();
                BindToGridDDen(listDDen);
            }
        }

        private void dgvDSDDen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = int.Parse(e.RowIndex.ToString());

            if (index >= 0)
            {
                txtMaDDen.Texts = dgvDSDDen.Rows[index].Cells[0].Value.ToString();
                txtTenDDen.Texts = dgvDSDDen.Rows[index].Cells[1].Value.ToString();
                cbxMaLTourDDen.Text = dgvDSDDen.Rows[index].Cells[2].Value.ToString();
            }
        }
        private bool ContainsDiacriticOrWhiteSpace(char c)
        {
            string diacriticsAndWhiteSpace = "ÀÁÂÃẠĂẮẰẤẦẴẶẤẨẪÈÉÊẺẼẸỀẾỂỄỆÌÍỈĨỊÒÓÔÕỌƠỚỜỢỞỠÙÚỦŨỤƯỨỪỬỮỰỲÝỶỸỴàáâãạăắằấầẵặấẩẫèéêẻẽẹềếểễệìíỉĩịòóôõọơớờợởỡùúủũụưứừửữựỳýỷỹỵ ";
            return diacriticsAndWhiteSpace.Contains(c);
        }
        private void txtMaDDen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ContainsDiacriticOrWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // Ngăn chặn ký tự có dấu và khoảng trắng được nhập vào
                return;
            }
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtTenDDen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void btnThemKS_MouseDown(object sender, MouseEventArgs e)
        {
            btnThemKS.BorderSize = 2;
            btnThemKS.BorderColor = Color.MidnightBlue;
        }

        private void btnThemKS_MouseUp(object sender, MouseEventArgs e)
        {
            btnThemKS.BorderSize = 0;
            btnThemKS.BorderColor = Color.White;
        }

        private void btnSuaKS_MouseDown(object sender, MouseEventArgs e)
        {
            btnSuaKS.BorderSize = 2;
            btnSuaKS.BorderColor = Color.MidnightBlue;
        }

        private void btnSuaKS_MouseUp(object sender, MouseEventArgs e)
        {
            btnSuaKS.BorderSize = 0;
            btnSuaKS.BorderColor = Color.White;
        }

        private void btnXoaKS_MouseDown(object sender, MouseEventArgs e)
        {
            btnXoaKS.BorderSize = 2;
            btnXoaKS.BorderColor = Color.MidnightBlue;
        }

        private void btnXoaKS_MouseUp(object sender, MouseEventArgs e)
        {
            btnXoaKS.BorderSize = 0;
        }

        private void btnTimKS_MouseDown(object sender, MouseEventArgs e)
        {
            btnTimKS.BorderSize = 2;
            btnTimKS.BorderColor = Color.MidnightBlue;
        }

        private void btnTimKS_MouseUp(object sender, MouseEventArgs e)
        {
            btnTimKS.BorderSize = 0;
        }

        private void btnThemPT_MouseDown(object sender, MouseEventArgs e)
        {
            btnThemPT.BorderSize = 2;
            btnThemPT.BorderColor = Color.MidnightBlue;
        }

        private void btnThemPT_MouseUp(object sender, MouseEventArgs e)
        {
            btnThemPT.BorderSize = 0;
            btnThemPT.BorderColor = Color.MidnightBlue;
        }

        private void btnSuaPT_MouseDown(object sender, MouseEventArgs e)
        {
            btnSuaPT.BorderSize = 2;
            btnSuaPT.BorderColor = Color.MidnightBlue;
        }

        private void btnSuaPT_MouseUp(object sender, MouseEventArgs e)
        {
            btnSuaPT.BorderSize = 0;
            btnSuaPT.BorderColor = Color.White;
        }

        private void btnXoaPT_MouseDown(object sender, MouseEventArgs e)
        {
            btnXoaPT.BorderSize = 2;
            btnXoaPT.BorderColor = Color.MidnightBlue;
        }

        private void btnXoaPT_MouseUp(object sender, MouseEventArgs e)
        {
            btnXoaPT.BorderSize = 0;
            btnXoaPT.BorderColor = Color.White;
        }

        private void btnTimPT_MouseDown(object sender, MouseEventArgs e)
        {

            btnTimPT.BorderSize = 2;
            btnTimPT.BorderColor = Color.MidnightBlue;
        }

        private void btnTimPT_MouseUp(object sender, MouseEventArgs e)
        {
            btnTimPT.BorderSize = 0;
            btnTimPT.BorderColor = Color.White;
        }

        private void btnThemDDi_MouseDown(object sender, MouseEventArgs e)
        {
            btnThemDDi.BorderSize = 2;
            btnThemDDi.BorderColor = Color.MidnightBlue;
        }

        private void btnThemDDi_MouseUp(object sender, MouseEventArgs e)
        {
            btnThemDDi.BorderSize = 0;
            btnThemDDi.BorderColor = Color.White;
        }

        private void btnSuaDDi_MouseDown(object sender, MouseEventArgs e)
        {
            btnSuaDDi.BorderSize = 2;
            btnSuaDDi.BorderColor = Color.MidnightBlue;
        }

        private void btnSuaDDi_MouseUp(object sender, MouseEventArgs e)
        {
            btnSuaDDi.BorderSize = 0;
            btnSuaDDi.BorderColor = Color.White;
        }

        private void btnXoaDDi_MouseDown(object sender, MouseEventArgs e)
        {
            btnXoaDDi.BorderSize = 2;
            btnXoaDDi.BorderColor = Color.MidnightBlue;
        }

        private void btnXoaDDi_MouseUp(object sender, MouseEventArgs e)
        {
            btnXoaDDi.BorderSize = 0;
            btnXoaDDi.BorderColor = Color.White;
        }

        private void btnTimDDi_MouseDown(object sender, MouseEventArgs e)
        {
            btnTimDDi.BorderSize = 2;
            btnTimDDi.BorderColor = Color.MidnightBlue;
        }

        private void btnTimDDi_MouseUp(object sender, MouseEventArgs e)
        {
            btnTimDDi.BorderSize = 0;
            btnTimDDi.BorderColor = Color.White;
        }

        private void btnThemDDen_MouseDown(object sender, MouseEventArgs e)
        {
            btnThemDDen.BorderSize = 2;
            btnThemDDen.BorderColor = Color.MidnightBlue;
        }

        private void btnThemDDen_MouseUp(object sender, MouseEventArgs e)
        {
            btnThemDDen.BorderSize = 0;
            btnThemDDen.BorderColor = Color.White;
        }

        private void btnSuaDDen_MouseDown(object sender, MouseEventArgs e)
        {
            btnSuaDDen.BorderSize = 2;
            btnSuaDDen.BorderColor = Color.MidnightBlue;
        }

        private void btnSuaDDen_MouseUp(object sender, MouseEventArgs e)
        {
            btnSuaDDen.BorderSize = 0;
            btnSuaDDen.BorderColor = Color.White;
        }

        private void btnXoaDDen_MouseDown(object sender, MouseEventArgs e)
        {
            btnXoaDDen.BorderSize = 2;
            btnXoaDDen.BorderColor = Color.MidnightBlue;
        }

        private void btnXoaDDen_MouseUp(object sender, MouseEventArgs e)
        {
            btnXoaDDen.BorderSize = 0;
            btnXoaDDen.BorderColor = Color.White;
        }

        private void btnTimDDen_MouseDown(object sender, MouseEventArgs e)
        {
            btnTimDDen.BorderSize = 2;
            btnTimDDen.BorderColor = Color.MidnightBlue;
        }

        private void btnTimDDen_MouseUp(object sender, MouseEventArgs e)
        {
            btnTimDDen.BorderSize = 0;
            btnTimDDen.BorderColor = Color.White;
        }

        private void frmQuanLyDichVu_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void txtMaDDi__TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMaKS_Enter(object sender, EventArgs e)
        {
            txtMaKS.BackColor = Color.Gainsboro;
        }

        private void txtMaKS_Leave(object sender, EventArgs e)
        {
            txtMaKS.BackColor = Color.White;
        }

        private void txtTenKS_Enter(object sender, EventArgs e)
        {
            txtTenKS.BackColor = Color.Gainsboro;
        }

        private void txtTenKS_Leave(object sender, EventArgs e)
        {
            txtTenKS.BackColor = Color.White;
        }

        private void txtDiaChiKS_Enter(object sender, EventArgs e)
        {
            txtDiaChiKS.BackColor = Color.Gainsboro;
        }

        private void txtDiaChiKS_Leave(object sender, EventArgs e)
        {
            txtDiaChiKS.BackColor = Color.White;
        }

        private void txtTrangThaiKS_Enter(object sender, EventArgs e)
        {
            txtTrangThaiKS.BackColor = Color.Gainsboro;
        }

        private void txtTrangThaiKS_Leave(object sender, EventArgs e)
        {
            txtTrangThaiKS.BackColor = Color.White;
        }

        private void txtMaPT_Enter(object sender, EventArgs e)
        {
            txtMaPT.BackColor = Color.Gainsboro;
        }

        private void txtMaPT_Leave(object sender, EventArgs e)
        {
            txtMaPT.BackColor = Color.White;
        }

        private void txtTenPT_Enter(object sender, EventArgs e)
        {
            txtTenPT.BackColor = Color.Gainsboro;
        }

        private void txtTenPT_Leave(object sender, EventArgs e)
        {
            txtTenPT.BackColor = Color.White;
        }

        private void txtTrangThaiPT_Enter(object sender, EventArgs e)
        {
            txtTrangThaiPT.BackColor = Color.Gainsboro;
        }

        private void txtTrangThaiPT_Leave(object sender, EventArgs e)
        {
            txtTrangThaiPT.BackColor = Color.White;
        }

        private void txtMaDDi_Enter(object sender, EventArgs e)
        {
            txtMaDDi.BackColor = Color.Gainsboro;
        }

        private void txtMaDDi_Leave(object sender, EventArgs e)
        {
            txtMaDDi.BackColor = Color.White;
        }

        private void txtTenDDi_Enter(object sender, EventArgs e)
        {
            txtTenPT.BackColor = Color.Gainsboro;
        }

        private void txtTenDDi_Leave(object sender, EventArgs e)
        {
            txtTenDDi.BackColor = Color.White;
        }

        private void txtMaDDen_Enter(object sender, EventArgs e)
        {
            txtMaDDen.BackColor = Color.Gainsboro;
        }

        private void txtMaDDen_Leave(object sender, EventArgs e)
        {
            txtMaDDen.BackColor = Color.White;
        }

        private void txtTenDDen_Enter(object sender, EventArgs e)
        {
            txtTenDDen.BackColor = Color.Gainsboro;
        }

        private void txtTenDDen_Leave(object sender, EventArgs e)
        {
            txtTenDDen.BackColor = Color.White;
        }

        private void dgvDSKS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex >= 0)
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)dgvDSKS.Rows[e.RowIndex].Cells[4];
                bool currentValue = Convert.ToBoolean(cell.Value);
                cell.Value = !currentValue;
                dgvDSKS.EndEdit(); // Kết thúc chỉnh sửa ô để cập nhật giá trị
                // Tiếp tục xử lý logic khác tại đây nếu cần thiết
            }
        }

        private void dgvDSPT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex >= 0)
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)dgvDSPT.Rows[e.RowIndex].Cells[4];
                bool currentValue = Convert.ToBoolean(cell.Value);
                cell.Value = !currentValue;
                dgvDSPT.EndEdit(); // Kết thúc chỉnh sửa ô để cập nhật giá trị
                // Tiếp tục xử lý logic khác tại đây nếu cần thiết
            }
        }

        private void dgvDSDDi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.RowIndex >= 0)
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)dgvDSDDi.Rows[e.RowIndex].Cells[3];
                bool currentValue = Convert.ToBoolean(cell.Value);
                cell.Value = !currentValue;
                dgvDSDDi.EndEdit(); // Kết thúc chỉnh sửa ô để cập nhật giá trị
                // Tiếp tục xử lý logic khác tại đây nếu cần thiết
            }
        }

        private void dgvDSDDen_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.RowIndex >= 0)
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)dgvDSDDen.Rows[e.RowIndex].Cells[3];
                bool currentValue = Convert.ToBoolean(cell.Value);
                cell.Value = !currentValue;
                dgvDSDDen.EndEdit(); // Kết thúc chỉnh sửa ô để cập nhật giá trị
                // Tiếp tục xử lý logic khác tại đây nếu cần thiết
            }
        }
    }
}
