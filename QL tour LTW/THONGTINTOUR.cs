using CustomControls.RJControls;
using QL_tour_LTW.ModelQLTOUR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
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
        private void FillLOAITOURCbb(List<LOAITOUR> loaitourlist)
        {
            cbbMALTOUR.DataSource = loaitourlist;
            cbbMALTOUR.DisplayMember = "TENLTOUR";
            cbbMALTOUR.ValueMember = "MALTOUR";
        }
        private void FillDIEMDICbb(List<DIEMDI> diemdilist)
        {
            cbbDIEMDI.DataSource = diemdilist;
            cbbDIEMDI.DisplayMember = "TENDDI";
            cbbDIEMDI.ValueMember = "MADDI";
        }
        private void FillDIEMDENCbb(List<DIEMDEN> diemdenlist)
        {
            cbbDIEMDEN.DataSource = diemdenlist;
            cbbDIEMDEN.DisplayMember = "TENDDEN";
            cbbDIEMDEN.ValueMember = "MADDEN";
        }
        private void FillPHUONGTIENCbb(List<PHUONGTIEN> phuongtienlist)
        {
            cbbMAPT.DataSource = phuongtienlist;
            cbbMAPT.DisplayMember = "TENPT";
            cbbMAPT.ValueMember = "MAPT";
        }
        private void FillKHACHSANCbb(List<KHACHSAN> khachsanlist)
        {
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
            }
        }
        private void THONGTINTOUR_Load(object sender, EventArgs e)
        {
            try
            {
                QLTOURDBContext context = new QLTOURDBContext();
                List<LOAITOUR> loaitourlisst = context.LOAITOURs.ToList();
                List<DIEMDI> diemdilist = context.DIEMDIs.ToList();
                List<DIEMDEN> diemden = context.DIEMDENs.ToList();
                List<PHUONGTIEN> phuongtien = context.PHUONGTIENs.ToList();
                List<KHACHSAN> khachsan = context.KHACHSANs.ToList();
                FillLOAITOURCbb(loaitourlisst);
                FillDIEMDICbb(diemdilist);
                FillDIEMDENCbb(diemden);
                FillPHUONGTIENCbb(phuongtien);
                FillKHACHSANCbb(khachsan);
                List<TOUR> tourlist = context.TOURs.ToList();
                Bindinggrid(tourlist);
                bunifuiOSSwitch1.Value = false;
            
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnTIMKIEM_Click(object sender, EventArgs e)
        {
            string tentour = txtTENTOUR.Texts.Trim();
            string matour = txtMATOUR.Texts.Trim();

            DateTime ngaydi = dtpNGAYDI.Value;
            DateTime ngayketthuc = dtpKETTHUC.Value;
            string mota = txtMOTA.Texts;
            string trangthai = txtTRANGTHAI.Texts;
            string loaitour;
            if (cbbMALTOUR.SelectedValue != null)
            {
                 loaitour = cbbMALTOUR.SelectedValue.ToString();
            }
            else
            {
                 loaitour = "";
            }
            string diemdi;
            if(cbbDIEMDI.SelectedValue != null)
            {
                diemdi = cbbDIEMDI.SelectedValue.ToString();
            }
            else
            {
                diemdi = "";
            }
            string diemden;
            if(cbbDIEMDEN.SelectedValue != null)
            {
                diemden = cbbDIEMDEN.SelectedValue.ToString();
            }
            else
            {
                diemden = "";
            }
            string phuongtien;
            if(cbbMAPT.SelectedValue != null)
            {
                phuongtien = cbbMAPT.SelectedValue.ToString();
            }
            else
            {
                phuongtien = "";
            }
            string khachsan;
            if(cbbMAKS.SelectedValue != null)
            {
                khachsan = cbbMAKS.SelectedValue.ToString();
            }
            else
            {
                khachsan = "";
            }
            List<TOUR> result = new List<TOUR>();

            QLTOURDBContext context = new QLTOURDBContext();


            IQueryable<TOUR> query = context.TOURs;
            if (string.IsNullOrEmpty(tentour) && string.IsNullOrEmpty(matour) && string.IsNullOrEmpty(txtGIATOUR.Texts)
               && ngaydi == DateTime.Today && ngayketthuc == DateTime.Today && string.IsNullOrEmpty(cbbMALTOUR.Text)
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
                    if(txtGIATOUR.Texts == "")
                    {
                        return; 
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
                   query = query.Where(s => s.NGAYDI >= ngaydi.Date && s.NGAYKETTHUC <= ngayketthuc.Date);
                   // query = query.Where(s => s.NGAYDI == ngaydi);
                }
                if (!string.IsNullOrEmpty(loaitour))
                {
                    if(cbbMALTOUR.SelectedItem != null)
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
        }
        private void rjButton1_Click(object sender, EventArgs e)
        {
            resetnull();
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
            txtMATOUR.BackColor = Color.Gainsboro;
        }

        private void txtGIATOUR_Leave(object sender, EventArgs e)
        {
            txtMATOUR.BackColor = Color.White;
        }

        private void txtMOTA_Enter(object sender, EventArgs e)
        {
            txtMATOUR.BackColor = Color.Gainsboro;
        }

        private void txtMOTA_Leave(object sender, EventArgs e)
        {
            txtMATOUR.BackColor = Color.White;
        }

        private void txtTRANGTHAI_Enter(object sender, EventArgs e)
        {
            txtMATOUR.BackColor = Color.Gainsboro;
        }

        private void txtTRANGTHAI_Leave(object sender, EventArgs e)
        {
            txtMATOUR.BackColor = Color.White;
        }
        private void them(int row)
        {
            dgvTHONGTINTOUR.Rows[row].Cells[0].Value = txtMATOUR.Texts;
            dgvTHONGTINTOUR.Rows[row].Cells[1].Value = txtTENTOUR.Texts;
            dgvTHONGTINTOUR.Rows[row].Cells[2].Value = txtGIATOUR.Texts;
            dgvTHONGTINTOUR.Rows[row].Cells[3].Value = dtpNGAYDI.Value;
            dgvTHONGTINTOUR.Rows[row].Cells[4].Value = dtpKETTHUC.Value;
            dgvTHONGTINTOUR.Rows[row].Cells[5].Value = txtMOTA.Texts;
            dgvTHONGTINTOUR.Rows[row].Cells[6].Value = txtTRANGTHAI.Texts;
            dgvTHONGTINTOUR.Rows[row].Cells[7].Value = cbbMALTOUR.Text;
            dgvTHONGTINTOUR.Rows[row].Cells[8].Value = cbbDIEMDI.Text;
            dgvTHONGTINTOUR.Rows[row].Cells[9].Value = cbbDIEMDEN.Text;
            dgvTHONGTINTOUR.Rows[row].Cells[10].Value = cbbMAPT.Text;
            dgvTHONGTINTOUR.Rows[row].Cells[11].Value = cbbMAKS.Text;            
            //
            TOUR insert = new TOUR { MATOUR = txtMATOUR.Texts, TENTOUR = txtTENTOUR.Texts, GIATOUR = int.Parse(txtGIATOUR.Texts),
            NGAYDI = dtpNGAYDI.Value, NGAYKETTHUC = dtpKETTHUC.Value,MOTA = txtMOTA.Texts, TRANGTHAI = txtTRANGTHAI.Texts,MALTOUR = cbbMALTOUR.SelectedValue.ToString(),
            MADDI = cbbDIEMDI.SelectedValue.ToString(), MADDEN = cbbDIEMDEN.SelectedValue.ToString(),
            MAPT =cbbMAKS.SelectedValue.ToString(), MAKS = cbbMAKS.SelectedValue.ToString()};
            QLTOURDBContext context = new QLTOURDBContext();
            context.TOURs.Add(insert);
            context.SaveChanges();
        }
        private void btnTHEM_Click_1(object sender, EventArgs e)
        {
            if (mainForm != null)
            {
                ThemTour themTourForm = new ThemTour();
                mainForm.OPENFORM(themTourForm);
                mainForm.linklbThemTOUR.Visible = true;
                mainForm.lbCACH.Visible = true;
            }
        }
        private  void gioihankytu()
        {
            if(txtMATOUR.Texts.Length > 11)
            {
                MessageBox.Show("Mã tour không quá 11 ký tự!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (txtTENTOUR.Texts.Length > 150)
            {
                MessageBox.Show("tên tour không quá 150 ký tự!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (txtMOTA.Texts.Length > 400)
            {
                MessageBox.Show("mô tả không quá 400 ký tự!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (txtTRANGTHAI.Texts.Length > 50)
            {
                MessageBox.Show("trạng thái không quá 50 ký tự!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void checktxt()
        {
            if(txtMATOUR.Texts ==""|| txtTENTOUR.Texts =="" ||
           txtGIATOUR.Texts =="" || cbbMALTOUR.Text == "" ||  cbbDIEMDI.Text =="" ||
           cbbDIEMDEN.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (dtpKETTHUC.Value < dtpNGAYDI.Value)
            {
                MessageBox.Show("Ngày kết thúc phải sau ngày đi!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void btnSUA_Click(object sender, EventArgs e)
        {
            try
            {
                checktxt();
                gioihankytu();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
