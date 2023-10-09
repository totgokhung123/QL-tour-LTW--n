using QL_tour_LTW.ModelQLTOUR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_tour_LTW
{
    public partial class THONGTINTOUR : Form
    {
        public THONGTINTOUR()
        {
            InitializeComponent();
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {

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
                dgvTHONGTINTOUR.Rows[index].Cells[6].Value = item.LOAITOUR.TENLTOUR;
                dgvTHONGTINTOUR.Rows[index].Cells[7].Value = item.DIEMDI.TENDDI;
                dgvTHONGTINTOUR.Rows[index].Cells[8].Value = item.DIEMDEN.TENDDEN;
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

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void btnTIMKIEM_Click(object sender, EventArgs e)
        {
            string tentour = txtTENTOUR.Text.Trim();
            string matour = txtMATOUR.Text.Trim();

            DateTime ngaydi = dtpNGAYDI.Value;
            DateTime ngayketthuc = dtpKETTHUC.Value;
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
            if (string.IsNullOrEmpty(tentour) && string.IsNullOrEmpty(matour) && string.IsNullOrEmpty(txtGIATOUR.Text)
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
                if (!string.IsNullOrEmpty(txtGIATOUR.Text))
                {
                    if(txtGIATOUR.Text == "")
                    {
                        return; 
                    }
                    else
                    {
                        decimal giatour = decimal.Parse(txtGIATOUR.Text);
                        query = query.Where(s => s.GIATOUR == giatour);
                    }
                    
                }
                if (!(ngaydi == null) && !(ngayketthuc == null))
                {
                   query = query.Where(s => s.NGAYDI >= ngaydi.Date && s.NGAYKETTHUC <= ngayketthuc.Date);
                   // query = query.Where(s => s.NGAYDI == ngaydi);
                }
                //if (!(ngayketthuc == null))
                //{
                //    query = query.Where(s => s.NGAYKETTHUC == ngayketthuc);
                //}
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
    }
}
