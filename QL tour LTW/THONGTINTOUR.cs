using CustomControls.RJControls;
using QL_tour_LTW.ModelQLTOUR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QL_tour_LTW
{
    public partial class THONGTINTOUR : Form
    {
        public THONGTINTOUR()
        {
            InitializeComponent();
        }
        private void FillLOAITOURCbb(List<LOAITOUR> loaitourlist, List<DIEMDI> diemdilist, List<DIEMDEN> diemdenlist,List<PHUONGTIEN> phuongtienlist, List<KHACHSAN> khachsanlist)
        {
            cbbMALTOUR.DataSource = loaitourlist;
            cbbMALTOUR.DisplayMember = "TENLTOUR";
            cbbMALTOUR.ValueMember = "MALTOUR";
            //
            cbbDIEMDI.DataSource = diemdilist;
            cbbDIEMDI.DisplayMember = "TENDDI";
            cbbDIEMDI.ValueMember = "MADDI";
            //
            cbbDIEMDEN.DataSource = diemdenlist;
            cbbDIEMDEN.DisplayMember = "TENDDEN";
            cbbDIEMDEN.ValueMember = "MADDEN";
            //
            cbbMAPT.DataSource = phuongtienlist;
            cbbMAPT.DisplayMember = "TENPT";
            cbbMAPT.ValueMember = "MAPT";
            //
            cbbMAKS.DataSource = khachsanlist;
            cbbMAKS.DisplayMember = "TENKS";
            cbbMAKS.ValueMember = "MAKS";
        }
        
        private void Bindinggrid(List<TOUR> tourlist)
        {
            // xóa toàn bộ dữ liệu trong đatagritview
            dgvTHONGTINTOUR.Rows.Clear();
            foreach (var item in tourlist)
            {
                int index = dgvTHONGTINTOUR.Rows.Add();
                dgvTHONGTINTOUR.Rows[index].Cells[0].Value = item.MATOUR;
                dgvTHONGTINTOUR.Rows[index].Cells[1].Value = item.TENTOUR;
                dgvTHONGTINTOUR.Rows[index].Cells[2].Value = item.GIATOUR;
                dgvTHONGTINTOUR.Rows[index].Cells[3].Value = item.NGAYDI;
                dgvTHONGTINTOUR.Rows[index].Cells[4].Value = item.NGAYKETTHUC;
                dgvTHONGTINTOUR.Rows[index].Cells[5].Value = item.MOTA;
                dgvTHONGTINTOUR.Rows[index].Cells[6].Value = item.TRANGTHAI;
                dgvTHONGTINTOUR.Rows[index].Cells[7].Value = item.LOAITOUR.TENLTOUR;
                dgvTHONGTINTOUR.Rows[index].Cells[8].Value = item.DIEMDI.TENDDI;
                dgvTHONGTINTOUR.Rows[index].Cells[9].Value = item.DIEMDEN.TENDDEN;
                if(item.MAPT == null)
                {
                    dgvTHONGTINTOUR.Rows[index].Cells[10].Value = null;
                }
                else
                {
                    dgvTHONGTINTOUR.Rows[index].Cells[10].Value = item.PHUONGTIEN.TENPT;
                }
                if (item.MAKS == null)
                {
                    dgvTHONGTINTOUR.Rows[index].Cells[11].Value = null;
                }
                else
                {
                    dgvTHONGTINTOUR.Rows[index].Cells[11].Value = item.KHACHSAN.TENKS;
                }
                dgvTHONGTINTOUR.Rows[index].Cells[12].Value = item.ANH1;
                dgvTHONGTINTOUR.Rows[index].Cells[13].Value = item.ANH2;
                dgvTHONGTINTOUR.Rows[index].Cells[14].Value = item.ANH3;
               // txttesst.Text = item.NGAYDI.ToString();
            }
            
        }
        private void THONGTINTOUR_Load(object sender, EventArgs e)
        {
            QLTOURDBContext context = new QLTOURDBContext();
            List<LOAITOUR> loaitourlisst = context.LOAITOURs.ToList();
            List<DIEMDI> diemdilist = context.DIEMDIs.ToList();
            List<DIEMDEN> diemden = context.DIEMDENs.ToList();
            List<PHUONGTIEN> phuongtien = context.PHUONGTIENs.ToList();
            List<KHACHSAN> khachsan = context.KHACHSANs.ToList();
            FillLOAITOURCbb(loaitourlisst, diemdilist, diemden, phuongtien, khachsan);
            List<TOUR> tourlist = context.TOURs.ToList();
            Bindinggrid(tourlist);
            bunifuiOSSwitch1.Value = false;
            cleartxtcbb();
        }
        private void cleartxtcbb()
        {
            cbbDIEMDEN.Text = "";
            cbbDIEMDI.Text = "";
            cbbMALTOUR.Text = "";
            cbbMAPT.Text = "";
            cbbMAKS.Text = "";
        }
        //QLTOURDBContext context = new QLTOURDBContext();
        //var invoicelist = context.TOURs.Where(s => s.NGAYDI >= dtpNGAYDI.Value).ToList();
        //Bindinggrid(invoicelist);
        private void btnTIMKIEM_Click(object sender, EventArgs e)
        {
            string tentour = txtTENTOUR.Texts.Trim();
            string matour = txtMATOUR.Texts.Trim();
            DateTime ngaydi = DateTime.Parse(dtpNGAYDI.Value.ToString());
            DateTime ngayketthuc = DateTime.Parse(dtpKETTHUC.Value.ToString());
            string mota = txtMOTA.Texts.Trim();
            string trangthai = txtTRANGTHAI.Texts.Trim();
            string loaitour = cbbMALTOUR.Text != "" ? cbbMALTOUR.SelectedValue.ToString() : "";            
            string diemdi = cbbDIEMDI.Text != "" ? cbbDIEMDI.SelectedValue.ToString() : "";
            string diemden = cbbDIEMDEN.Text != "" ? cbbDIEMDEN.SelectedValue.ToString() : "";
            string phuongtien = cbbMAPT.Text != "" ? cbbMAPT.SelectedValue.ToString() : "";
            string khachsan = cbbMAKS.Text != "" ? cbbMAKS.SelectedValue.ToString() : "";     
            //
            List<TOUR> result = new List<TOUR>();
            QLTOURDBContext context = new QLTOURDBContext();
            IQueryable<TOUR> query = context.TOURs;
            if (string.IsNullOrEmpty(tentour) && string.IsNullOrEmpty(matour) && string.IsNullOrEmpty(txtGIATOUR.Texts)
               && ngaydi == null && ngayketthuc == null && string.IsNullOrEmpty(cbbMALTOUR.Text)
               && string.IsNullOrEmpty(cbbDIEMDI.Text) && string.IsNullOrEmpty(cbbDIEMDEN.Text) && string.IsNullOrEmpty(cbbMAPT.Text)
               && string.IsNullOrEmpty(cbbMAKS.Text))
            {
                // Hiển thị danh sách tất cả sinh viên
                result = context.TOURs.ToList();
                Bindinggrid(result);
            }
            else
            {
                // Thực hiện tìm kiếm sinh viên dựa trên các điều kiện
                if (!string.IsNullOrEmpty(matour))
                {
                    query = query.Where(s => s.MATOUR.Contains(matour));
                }
                if (!string.IsNullOrEmpty(tentour))
                {
                    query = query.Where(s => s.TENTOUR.Contains(tentour));
                }
                if (!string.IsNullOrEmpty(txtGIATOUR.Texts))
                {
                    if (txtGIATOUR.Texts == "")
                    {
                        query = query.Where(s => s.GIATOUR.ToString().Contains("0"));
                    }
                    else
                    {
                        decimal giatour = decimal.Parse(txtGIATOUR.Texts);
                        query = query.Where(s => s.GIATOUR == giatour);
                    }
                }
                // tìm từ ngày di đến ngày kết thúc
                if (!(ngaydi == null) && !(ngayketthuc == null))
                {
                     query = query.Where(s => s.NGAYDI >= ngaydi && s.NGAYKETTHUC <= ngayketthuc);
                   // query = query.Where(s => s.NGAYDI >= dtpNGAYDI.Value);
                }
                if (!string.IsNullOrEmpty(loaitour))
                {
                    if (cbbMALTOUR.SelectedItem != null)
                    {
                        query = query.Where(s => s.MALTOUR == loaitour);
                    }
                    
                }
                if (!string.IsNullOrEmpty(diemdi))
                {
                    if (cbbDIEMDI.SelectedItem != null)
                    {
                        query = query.Where(s => s.MADDI == diemdi);
                    }
                }
                if (!string.IsNullOrEmpty(diemden))
                {
                    if (cbbDIEMDEN.SelectedItem != null)
                    {
                        query = query.Where(s => s.MADDEN == diemden);
                    }
                }
                if (!string.IsNullOrEmpty(phuongtien))
                {
                    if (cbbMAPT.SelectedItem != null)
                    {
                        query = query.Where(s => s.MAPT == phuongtien);
                    }
                }
                if (!string.IsNullOrEmpty(khachsan))
                {
                    if (cbbMAKS.SelectedItem != null)
                    {
                        query = query.Where(s => s.MAKS == khachsan);
                    }
                }
                if (!string.IsNullOrEmpty(mota))
                {
                    query = query.Where(s => s.MOTA.Contains(mota));
                }
                if (!string.IsNullOrEmpty(trangthai))
                {
                    query = query.Where(s => s.TRANGTHAI.Contains(trangthai));
                }
                result = query.ToList();
                // Hiển thị kết quả tìm kiếm trong DataGridView
                Bindinggrid(result);
            }
        }

        private void bunifuiOSSwitch1_OnValueChange(object sender, EventArgs e)
        {
            if(bunifuiOSSwitch1.Value == true)
            {
                lbMOTA.Visible = true;
                lbTRANGTHAI.Visible = true;
                txtTRANGTHAI.Visible = true;
                txtMOTA.Visible = true;
            }
            else
            {
                lbMOTA.Visible = false;
                lbTRANGTHAI.Visible = false;
                txtTRANGTHAI.Visible = false;
                txtMOTA.Visible = false;
            }
        }
        private void rjTextBox1_Enter(object sender, EventArgs e)
        {
            txtMATOUR.BackColor = Color.Gainsboro;
        }

        private void rjTextBox1_Leave(object sender, EventArgs e)
        {
            txtMATOUR.BackColor = Color.White;
        }
        private MainQLTOUR mainForm;
        public void SetMainForm(MainQLTOUR form)
        {
            mainForm = form;
        }
        private void resetnull()
        {
            txtMATOUR.Texts = txtTENTOUR.Texts =
           txtGIATOUR.Texts = txtMOTA.Texts = txtTRANGTHAI.Texts =
           cbbMALTOUR.Text = cbbMAKS.Text = cbbMAPT.Text = cbbDIEMDI.Text =
           cbbDIEMDEN.Text = string.Empty;
            dtpNGAYDI.Value = DateTime.Today;
            dtpKETTHUC.Value = DateTime.Today;
            pcboxANH1.Image = null;
            pcboxANH2.Image = null;
            pcboxANH3.Image = null;
        }
        private void rjButton1_Click(object sender, EventArgs e)
        {
            resetnull();
            QLTOURDBContext context = new QLTOURDBContext();
            List<TOUR> tourlist = context.TOURs.ToList();
            Bindinggrid(tourlist);
        }

        private void txtTENTOUR_Enter(object sender, EventArgs e)
        {
            txtTENTOUR.BackColor = Color.Gainsboro;
        }

        private void txtTENTOUR_Leave(object sender, EventArgs e)
        {
            txtTENTOUR.BackColor = Color.White;
        }

        private void txtGIATOUR_Enter(object sender, EventArgs e)
        {
            txtGIATOUR.BackColor = Color.Gainsboro;
        }

        private void txtGIATOUR_Leave(object sender, EventArgs e)
        {
            txtGIATOUR.BackColor = Color.White;
        }

        private void txtMOTA_Enter(object sender, EventArgs e)
        {
            txtMOTA.BackColor = Color.Gainsboro;
        }

        private void txtMOTA_Leave(object sender, EventArgs e)
        {
            txtMOTA.BackColor = Color.White;
        }

        private void txtTRANGTHAI_Enter(object sender, EventArgs e)
        {
            txtTRANGTHAI.BackColor = Color.Gainsboro;
        }

        private void txtTRANGTHAI_Leave(object sender, EventArgs e)
        {
            txtTRANGTHAI.BackColor = Color.White;
        }       
        private string getMaTour ;
        private void btnTHEM_Click_1(object sender, EventArgs e)
        {

            if (mainForm != null)
            {
                getMaTour = txtMATOUR.Texts;
                ThemTour themTourForm = new ThemTour(getMaTour);
                mainForm.OPENFORM(themTourForm);
                mainForm.linklbThemTOUR.Visible = true;
                mainForm.lbCACH.Visible = true;
            }
        }        
        private void checktxt()
        {
            if(txtMATOUR.Texts =="")
            {
                MessageBox.Show("Vui lòng nhập mã tour cần sửa!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        private void btnSUA_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMATOUR.Texts == "")
                {
                    MessageBox.Show("Vui lòng nhập mã tour cần sửa!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    if (mainForm != null)
                    {
                        getMaTour = txtMATOUR.Texts;
                        ThemTour themTourForm = new ThemTour(getMaTour);
                        mainForm.OPENFORM(themTourForm);
                        mainForm.linklbThemTOUR.Visible = true;
                        mainForm.lbCACH.Visible = true;
                    }
                }
                //  gioihankytu();             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private byte[] selectedImageBytes1;
        private void dgvTHONGTINTOUR_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = int.Parse(e.RowIndex.ToString());
            if (e.RowIndex >= 0)
            {
               // dgvTHONGTINTOUR.Rows[index].Cells[15].Value = true ;
                txtMATOUR.Texts = dgvTHONGTINTOUR.Rows[index].Cells[0].Value.ToString();
                txtTENTOUR.Texts = dgvTHONGTINTOUR.Rows[index].Cells[1].Value.ToString();
                txtGIATOUR.Texts = dgvTHONGTINTOUR.Rows[index].Cells[2].Value.ToString();
                dtpNGAYDI.Value = DateTime.Parse(dgvTHONGTINTOUR.Rows[index].Cells[3].Value.ToString());
                dtpKETTHUC.Value = DateTime.Parse(dgvTHONGTINTOUR.Rows[index].Cells[4].Value.ToString());
                if (dgvTHONGTINTOUR.Rows[index].Cells[5].Value == null)
                {
                    txtMOTA.Texts = "";
                }
                else
                {
                    txtMOTA.Texts = dgvTHONGTINTOUR.Rows[index].Cells[5].Value.ToString();
                }
                if (dgvTHONGTINTOUR.Rows[index].Cells[6].Value == null)
                {
                    txtTRANGTHAI.Texts = "";
                }
                else
                {
                    txtTRANGTHAI.Texts = dgvTHONGTINTOUR.Rows[index].Cells[6].Value.ToString();
                }
                cbbMALTOUR.Text = dgvTHONGTINTOUR.Rows[index].Cells[7].Value.ToString();
                cbbDIEMDI.Text = dgvTHONGTINTOUR.Rows[index].Cells[8].Value.ToString();
                cbbDIEMDEN.Text = dgvTHONGTINTOUR.Rows[index].Cells[9].Value.ToString();
                if (dgvTHONGTINTOUR.Rows[index].Cells[10].Value == null)
                {
                    cbbMAPT.Text = "";
                }
                else
                {
                    cbbMAPT.Text = dgvTHONGTINTOUR.Rows[index].Cells[10].Value.ToString();
                }
                if (dgvTHONGTINTOUR.Rows[index].Cells[11].Value == null)
                {
                    cbbMAKS.Text = "";
                }
                else
                {
                    cbbMAKS.Text = dgvTHONGTINTOUR.Rows[index].Cells[11].Value.ToString();
                }
                byte[] imageBytes = dgvTHONGTINTOUR.Rows[index].Cells[12].Value as byte[];
                if (imageBytes != null)
                {
                    using (MemoryStream ms1 = new MemoryStream(imageBytes))
                    {
                        pcboxANH1.Image = Image.FromStream(ms1);
                    }
                }
                else
                {
                    pcboxANH1.Image = null;
                }
                byte[] imageBytes2 = dgvTHONGTINTOUR.Rows[index].Cells[13].Value as byte[];
                if (imageBytes2 != null)
                {
                    using (MemoryStream ms2 = new MemoryStream(imageBytes2))
                    {
                        pcboxANH2.Image = Image.FromStream(ms2);
                    }
                }
                else
                {
                    pcboxANH2.Image = null;
                }
                byte[] imageBytes3 = dgvTHONGTINTOUR.Rows[index].Cells[14].Value as byte[];
                if (imageBytes3 != null)
                {
                    using (MemoryStream ms3 = new MemoryStream(imageBytes3))
                    {
                        pcboxANH3.Image = Image.FromStream(ms3);
                    }
                }
                else
                {
                    pcboxANH3.Image = null;
                }
            }
            
        }
        private void xoa()
        {
            QLTOURDBContext context = new QLTOURDBContext();
            List<HOADON> hoadonlist = context.HOADONs.ToList();
            TOUR delete = context.TOURs.FirstOrDefault(p => p.MATOUR.ToString() == txtMATOUR.Texts);
            foreach (var hoadon in hoadonlist)
            {
                if (hoadon.MATOUR.ToString() == txtMATOUR.Texts)
                {
                    HOADON deletehoadonFKTOUR = context.HOADONs.FirstOrDefault(s => s.MATOUR.ToString() == txtMATOUR.Texts);
                    if (delete != null)
                    {
                        context.HOADONs.Remove(deletehoadonFKTOUR);

                        context.SaveChanges();
                    }
                }
            }
            context.TOURs.Remove(delete);
            context.SaveChanges();
        }
        private int checkMAtour(string matour)
        {
            for (int i = 0; i < dgvTHONGTINTOUR.Rows.Count; i++)
            {
                if (dgvTHONGTINTOUR.Rows[i].Cells[0].Value.ToString() == matour)
                {
                    return i;
                }
            }
            return -1;
        }
        private void delete(string matour)
        {
            QLTOURDBContext context = new QLTOURDBContext();
            List<HOADON> hoadonlist = context.HOADONs.ToList();
            TOUR delete = context.TOURs.FirstOrDefault(p => p.MATOUR.ToString() == matour);
            foreach (var hoadon in hoadonlist)
            {
                if (hoadon.MATOUR.ToString() == matour)
                {
                    HOADON deletehoadonFKTOUR = context.HOADONs.FirstOrDefault(s => s.MATOUR.ToString() == matour);
                    if (delete != null)
                    {
                        context.HOADONs.Remove(deletehoadonFKTOUR);

                        context.SaveChanges();
                    }
                }
            }
            context.TOURs.Remove(delete);
            context.SaveChanges();
        }
        private void btnXOA_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvTHONGTINTOUR.Rows.Count; i++)
            {
                if (dgvTHONGTINTOUR.Rows[i].Cells[15].Value != null)
                {
                    if (MessageBox.Show("Bạn có chắc muốn xóa Tour: " + dgvTHONGTINTOUR.Rows[i].Cells[1].Value.ToString() + " ?", "Xác Nhận Xóa !!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //dgvTHONGTINTOUR.Rows.RemoveAt(i);
                        delete(dgvTHONGTINTOUR.Rows[i].Cells[0].Value.ToString());
                    }
                }

            }
            
            QLTOURDBContext context = new QLTOURDBContext();
            List<TOUR> tourlist = context.TOURs.ToList();
            Bindinggrid(tourlist);
            //try
            //{
            //    int row = checkMAtour(txtMATOUR.Texts);
            //    if (row == -1)
            //    {
            //        throw new Exception("Không tìm thấy tour cần xóa!");
            //    }
            //    else
            //    {
            //        DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //        if (dr == DialogResult.Yes)
            //        {
            //            dgvTHONGTINTOUR.Rows.RemoveAt(row);
            //            xoa();
            //            resetnull();
            //            MessageBox.Show("Xóa tour thành công!", "Thông báo", MessageBoxButtons.OK);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
        private bool ContainsDiacriticOrWhiteSpace(char c)
        {
            string diacriticsAndWhiteSpace = "ÀÁÂÃẠĂẮẰẤẦẴẶẤẨẪÈÉÊẺẼẸỀẾỂỄỆÌÍỈĨỊÒÓÔÕỌƠỚỜỢỞỠÙÚỦŨỤƯỨỪỬỮỰỲÝỶỸỴàáâãạăắằấầẵặấẩẫèéêẻẽẹềếểễệìíỉĩịòóôõọơớờợởỡùúủũụưứừửữựỳýỷỹỵ ";
            return diacriticsAndWhiteSpace.Contains(c);
        }
        private void txtMATOUR_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ContainsDiacriticOrWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // Ngăn chặn ký tự có dấu và khoảng trắng được nhập vào
                return;
            }
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
            if (txtMATOUR.Texts.Length >= 6 && e.KeyChar != '\b')
            {
                e.Handled = true; // Hủy sự kiện KeyPress
                MessageBox.Show("Mã tour không quá 6 ký tự!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void txtTENTOUR_KeyPress(object sender, KeyPressEventArgs e)
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
            if (txtTENTOUR.Texts.Length >= 150 && e.KeyChar != '\b')
            {
                e.Handled = true; // Hủy sự kiện KeyPress
                MessageBox.Show("Tên tour không quá 150 ký tự!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void txtGIATOUR_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cbbMALTOUR_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
        }

        private void txtMOTA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Chỉ Nhập ký tự", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtMOTA.Texts.Length >= 400 && e.KeyChar != '\b')
            {
                e.Handled = true; // Hủy sự kiện KeyPress
                MessageBox.Show("Mô tả không quá 400 ký tự!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void txtTRANGTHAI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Chỉ Nhập ký tự", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtTRANGTHAI.Texts.Length >= 50 && e.KeyChar != '\b')
            {
                e.Handled = true; // Hủy sự kiện KeyPress
                MessageBox.Show("trạng thái không quá 50 ký tự!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void dtpNGAYDI_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void dtpKETTHUC_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
        private void btnReset_MouseClick(object sender, MouseEventArgs e)
        {
            btnReset.BorderSize = 2;
            btnReset.BorderColor = Color.MidnightBlue;
        }

        private void btnReset_MouseUp(object sender, MouseEventArgs e)
        {
            btnReset.BorderSize = 0;          
            btnTHEM.BorderSize = 0;
            btnTIMKIEM.BorderSize = 0;
            btnSUA.BorderSize = 0;
            btnXOA.BorderSize = 0;
            btnTROVE.BorderSize = 0;
        }

        private void btnTHEM_MouseClick(object sender, MouseEventArgs e)
        {
            btnTHEM.BorderSize = 2;
            btnTHEM.BorderColor = Color.MidnightBlue;
        }

        private void btnTIMKIEM_MouseClick(object sender, MouseEventArgs e)
        {
            btnTIMKIEM.BorderSize = 2;
            btnTIMKIEM.BorderColor = Color.MidnightBlue;
        }

        private void btnSUA_MouseClick(object sender, MouseEventArgs e)
        {
            btnSUA.BorderSize = 2;
            btnSUA.BorderColor = Color.MidnightBlue;
        }

        private void btnXOA_MouseClick(object sender, MouseEventArgs e)
        {
            btnXOA.BorderSize = 2;
            btnXOA.BorderColor = Color.MidnightBlue;
        }

        private void btnTROVE_MouseClick(object sender, MouseEventArgs e)
        {
            btnTROVE.BorderSize = 2;
            btnTROVE.BorderColor = Color.MidnightBlue;
        }

        private void dgvTHONGTINTOUR_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 15 && e.RowIndex >= 0)
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)dgvTHONGTINTOUR.Rows[e.RowIndex].Cells[15];
                bool currentValue = Convert.ToBoolean(cell.Value);
                cell.Value = !currentValue;
                dgvTHONGTINTOUR.EndEdit(); // Kết thúc chỉnh sửa ô để cập nhật giá trị
                // Tiếp tục xử lý logic khác tại đây nếu cần thiết
            }
        }
    }
}
