using QL_tour_LTW.ModelQLTOUR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_tour_LTW
{
    public partial class DANGKYTOUR : Form
    {
        public DANGKYTOUR()
        {
            InitializeComponent();
        }
        private void FillLOAITOURCbb( List<DIEMDI> diemdilist, List<DIEMDEN> diemdenlist, List<PHUONGTIEN> phuongtienlist, List<KHACHSAN> khachsanlist)
        {
            //
            cbbDIEMDI.DataSource = diemdilist;
            cbbDIEMDI.DisplayMember = "TENDDI";
            cbbDIEMDI.ValueMember = "MADDI";
            //
            cbbDIEMDEN.DataSource = diemdenlist;
            cbbDIEMDEN.DisplayMember = "TENDDEN";
            cbbDIEMDEN.ValueMember = "MADDEN";
            //
            cbbPT.DataSource = phuongtienlist;
            cbbPT.DisplayMember = "TENPT";
            cbbPT.ValueMember = "MAPT";
            //
            cbbKS.DataSource = khachsanlist;
            cbbKS.DisplayMember = "TENKS";
            cbbKS.ValueMember = "MAKS";
        }

        private void Bindinggrid(List<TOUR> tourlist)
        {
            // xóa toàn bộ dữ liệu trong đatagritview
            dgvDATTOUR.Rows.Clear();
            foreach (var item in tourlist)
            {
                int index = dgvDATTOUR.Rows.Add();
                dgvDATTOUR.Rows[index].Cells[0].Value = item.MATOUR;
                dgvDATTOUR.Rows[index].Cells[1].Value = item.TENTOUR;
                dgvDATTOUR.Rows[index].Cells[2].Value = item.GIATOUR;
                dgvDATTOUR.Rows[index].Cells[3].Value = item.NGAYDI;
                dgvDATTOUR.Rows[index].Cells[4].Value = item.NGAYKETTHUC;
                dgvDATTOUR.Rows[index].Cells[5].Value = item.MOTA;
                dgvDATTOUR.Rows[index].Cells[6].Value = item.TRANGTHAI;
                dgvDATTOUR.Rows[index].Cells[7].Value = item.LOAITOUR.TENLTOUR;
                dgvDATTOUR.Rows[index].Cells[8].Value = item.DIEMDI.TENDDI;
                dgvDATTOUR.Rows[index].Cells[9].Value = item.DIEMDEN.TENDDEN;
                if (item.MAPT == null)
                {
                    dgvDATTOUR.Rows[index].Cells[10].Value = null;
                }
                else
                {
                    dgvDATTOUR.Rows[index].Cells[10].Value = item.PHUONGTIEN.TENPT;
                }
                if (item.MAKS == null)
                {
                    dgvDATTOUR.Rows[index].Cells[11].Value = null;
                }
                else
                {
                    dgvDATTOUR.Rows[index].Cells[11].Value = item.KHACHSAN.TENKS;
                }
                dgvDATTOUR.Rows[index].Cells[12].Value = item.ANH1;
                dgvDATTOUR.Rows[index].Cells[13].Value = item.ANH2;
                dgvDATTOUR.Rows[index].Cells[14].Value = item.ANH3;
                // txttesst.Text = item.NGAYDI.ToString();
            }

        }
        private void DANGKYTOUR_Load(object sender, EventArgs e)
        {
            QLTOURDBContext context = new QLTOURDBContext();
            List<LOAITOUR> loaitourlisst = context.LOAITOURs.ToList();
            List<DIEMDI> diemdilist = context.DIEMDIs.ToList();
            List<DIEMDEN> diemden = context.DIEMDENs.ToList();
            List<PHUONGTIEN> phuongtien = context.PHUONGTIENs.ToList();
            List<KHACHSAN> khachsan = context.KHACHSANs.ToList();
            FillLOAITOURCbb(diemdilist, diemden, phuongtien, khachsan);
            List<TOUR> tourlist = context.TOURs.ToList();
            Bindinggrid(tourlist);
        }
        private void resetnull()
        {
             txtTENTOUR.Texts = cbbKS.Text = cbbPT.Text = cbbDIEMDI.Text = cbbDIEMDEN.Text = string.Empty;
            dtpNGAYDI.Value = DateTime.Today;
            dtpNGAYKETTHUC.Value = DateTime.Today;
            pcboxANH1.Image = null;
            pcboxANH2.Image = null;          
            pcboxANH3.Image = null;
            lblTENTOUR.Text = "Tên Tour:";
            lblTIEN.Text = "xxxx/đ khách";
            lblTGnho.Text = "Thời gian";
            lblPT.Text = "Phương tiện";
            lblKS.Text = "Khách sạn";
            lblDiemDen.Text = "Điểm đến";
            lbLMATOUR.Text = lbKhoangTG.Text = lbMOTA.Text = lbTGkhoihanh.Text = lbMATOUR.Text =lbDiemDI.Text = string.Empty;
            btnNGOAINUOC.IdleFillColor = Color.White;
            btnTRONGNUOC.IdleFillColor = Color.White;
            btnNGOAINUOC.IdleForecolor = Color.MidnightBlue;
            btnTRONGNUOC.IdleForecolor = Color.MidnightBlue;
            QLTOURDBContext context = new QLTOURDBContext();
            List<TOUR> tourlist = context.TOURs.ToList();
            Bindinggrid(tourlist);
        }
        private void btnRESET_Click(object sender, EventArgs e)
        {
            resetnull();
        }
        private string getMaTour;
        private void dgvTHONGTINTOUR_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = int.Parse(e.RowIndex.ToString());
            lbMATOUR.Text = dgvDATTOUR.Rows[index].Cells[0].Value.ToString();
            lblTENTOUR.Text = "[" + dgvDATTOUR.Rows[index].Cells[0].Value.ToString() + "] " + dgvDATTOUR.Rows[index].Cells[1].Value.ToString();
            txtTENTOUR.Texts = dgvDATTOUR.Rows[index].Cells[1].Value.ToString();
            lblTIEN.Text = string.Format("{0:#,##0}", dgvDATTOUR.Rows[index].Cells[2].Value) +"/đ Khách";//.Replace(".", string.Empty)     
            dtpNGAYDI.Value = DateTime.Parse(dgvDATTOUR.Rows[index].Cells[3].Value.ToString());
            lbTGkhoihanh.Text = DateTime.Parse(dgvDATTOUR.Rows[index].Cells[3].Value.ToString()).ToShortDateString();
            dtpNGAYKETTHUC.Value = DateTime.Parse(dgvDATTOUR.Rows[index].Cells[4].Value.ToString());
            if (dgvDATTOUR.Rows[index].Cells[5].Value == null)
            {
                lbMOTA.Text = "";
            }
            else
            {
                lbMOTA.Text = dgvDATTOUR.Rows[index].Cells[5].Value.ToString();
            }
            //if (dgvTHONGTINTOUR.Rows[index].Cells[6].Value == null)
            //{
            //    txtTRANGTHAI.Texts = "";
            //}
            //else
            //{
            //    txtTRANGTHAI.Texts = dgvTHONGTINTOUR.Rows[index].Cells[6].Value.ToString();
            //}
            DateTime ngayDi = DateTime.Parse(dgvDATTOUR.Rows[index].Cells[3].Value.ToString());
            DateTime ngayKetThuc = DateTime.Parse(dgvDATTOUR.Rows[index].Cells[4].Value.ToString());
            TimeSpan khoangThoiGian = ngayKetThuc.Date - ngayDi.Date;
            int soNgay = khoangThoiGian.Days;
            lblTGnho.Text =  lbKhoangTG.Text = soNgay.ToString()+ " ngày";
            lbLMATOUR.Text =  dgvDATTOUR.Rows[index].Cells[7].Value.ToString();
            lbDiemDI.Text = cbbDIEMDI.Text = dgvDATTOUR.Rows[index].Cells[8].Value.ToString();
            lblDiemDen.Text = cbbDIEMDEN.Text = dgvDATTOUR.Rows[index].Cells[9].Value.ToString();           
            if (dgvDATTOUR.Rows[index].Cells[10].Value == null)
            {
                cbbPT.Text = "";
                lblPT.Text = "chưa có";
            }
            else
            {
                lblPT.Text =  cbbPT.Text = dgvDATTOUR.Rows[index].Cells[10].Value.ToString();
                
            }
            if (dgvDATTOUR.Rows[index].Cells[11].Value == null)
            {
                cbbKS.Text = "";
                lblKS.Text = "chưa có";
            }
            else
            {
                lblKS.Text = cbbKS.Text = dgvDATTOUR.Rows[index].Cells[11].Value.ToString();
            }
            byte[] imageBytes = dgvDATTOUR.Rows[index].Cells[12].Value as byte[];
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
            byte[] imageBytes2 = dgvDATTOUR.Rows[index].Cells[13].Value as byte[];
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
            byte[] imageBytes3 = dgvDATTOUR.Rows[index].Cells[14].Value as byte[];
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
        private void checkmaubtnTRONGNUOC()
        {
            btnTRONGNUOC.IdleFillColor = Color.MidnightBlue;
            btnTRONGNUOC.IdleForecolor = Color.White;
            btnNGOAINUOC.IdleFillColor = Color.White;
            btnNGOAINUOC.IdleForecolor = Color.MidnightBlue;
        }
        private void btnTRONGNUOC_Click(object sender, EventArgs e)
        {
            checkmaubtnTRONGNUOC();
            QLTOURDBContext context = new QLTOURDBContext();
            var trongnuoc = context.TOURs.Where(s => s.MALTOUR == "LT01").ToList();
            Bindinggrid(trongnuoc);
        }
        private void checkmaubtnNGOAINUOC()
        {
            btnTRONGNUOC.IdleForecolor = Color.MidnightBlue;
            btnTRONGNUOC.IdleFillColor = Color.White;
            btnNGOAINUOC.IdleFillColor = Color.MidnightBlue;
            btnNGOAINUOC.IdleForecolor = Color.White;
        }
        private void btnNGOAINUOC_Click(object sender, EventArgs e)
        {
            checkmaubtnNGOAINUOC();
            QLTOURDBContext context = new QLTOURDBContext();
            var ngoainuoc = context.TOURs.Where(s => s.MALTOUR == "LT02").ToList();
            Bindinggrid(ngoainuoc);
        }
        private string checkbtnLTOUR()
        {
            string MaLTour = "";
            if (btnTRONGNUOC.IdleFillColor == Color.MidnightBlue)
            {
                MaLTour = "LT01";
            }

            if (btnNGOAINUOC.IdleFillColor == Color.MidnightBlue)
            {
                MaLTour = "LT02";
            }
            return MaLTour;
        }
        private void btnLOCKQ_Click(object sender, EventArgs e)
        {
            string tentour = txtTENTOUR.Texts.Trim();

            DateTime ngaydi = DateTime.Parse(dtpNGAYDI.Value.ToString());
            //txttesst.Text = dtpNGAYDI.Value.ToString();
            DateTime ngayketthuc = DateTime.Parse(dtpNGAYKETTHUC.Value.ToString());
            string loaitour = checkbtnLTOUR();
            txttesst.Text = checkbtnLTOUR();
            string diemdi = cbbDIEMDI.Text != "" ? cbbDIEMDI.SelectedValue.ToString() : "";
            string diemden = cbbDIEMDEN.Text != "" ? cbbDIEMDEN.SelectedValue.ToString() : "";
            string phuongtien = cbbPT.Text != "" ? cbbPT.SelectedValue.ToString() : "";
            string khachsan = cbbKS.Text != "" ? cbbKS.SelectedValue.ToString() : "";
            List<TOUR> result = new List<TOUR>();

            QLTOURDBContext context = new QLTOURDBContext();


            IQueryable<TOUR> query = context.TOURs;
            if (string.IsNullOrEmpty(tentour) && string.IsNullOrEmpty(cbbDIEMDI.Text)
               && ngaydi == null && ngayketthuc == null && string.IsNullOrEmpty(loaitour)
               && string.IsNullOrEmpty(cbbDIEMDEN.Text) && string.IsNullOrEmpty(cbbPT.Text)
               && string.IsNullOrEmpty(cbbKS.Text))
            {
                // Hiển thị danh sách tất cả sinh viên
                result = context.TOURs.ToList();
                Bindinggrid(result);
            }
            else
            {
                // Thực hiện tìm kiếm sinh viên dựa trên các điều kiện
                if (!string.IsNullOrEmpty(tentour))
                {
                    query = query.Where(s => s.TENTOUR.Contains(tentour));
                }                
                // tìm từ ngày di đến ngày kết thúc
                if (!(ngaydi == null) && !(ngayketthuc == null))
                {
                    query = query.Where(s => s.NGAYDI >= ngaydi && s.NGAYKETTHUC <= ngayketthuc);
                    // query = query.Where(s => s.NGAYDI >= dtpNGAYDI.Value);
                }
                if (!string.IsNullOrEmpty(loaitour))
                {
                        query = query.Where(s => s.MALTOUR == loaitour);
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
                    if (cbbPT.SelectedItem != null)
                    {
                        query = query.Where(s => s.MAPT == phuongtien);
                    }
                }
                if (!string.IsNullOrEmpty(khachsan))
                {
                    if (cbbKS.SelectedItem != null)
                    {
                        query = query.Where(s => s.MAKS == khachsan);
                    }
                }
                result = query.ToList();
                // Hiển thị kết quả tìm kiếm trong DataGridView
                Bindinggrid(result);
            }
        }

        private void btnTRONGNUOC_MouseDown(object sender, EventArgs e)
        {
            //btnTRONGNUOC.IdleFillColor = Color.MidnightBlue;
        }

        private void btnDATTOUR_Click(object sender, EventArgs e)
        {
            if (this.dgvDATTOUR.SelectedRows.Count > 0)
            {
                var mabuttontour = dgvDATTOUR.Rows[dgvDATTOUR.SelectedRows[0].Index].Cells[0].Value.ToString();
                THONGTINDANGKYTOUR f = new THONGTINDANGKYTOUR(mabuttontour);
                f.ShowDialog();
            }
        }

        private void txtTENTOUR_Enter(object sender, EventArgs e)
        {
            txtTENTOUR.BackColor = Color.Gainsboro;
        }

        private void txtTENTOUR_Leave(object sender, EventArgs e)
        {
            txtTENTOUR.BackColor = Color.White;
        }

        private void txtTENTOUR_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Chỉ Nhập chữ", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (e.KeyChar == 22)
            {
                e.Handled = true;
                return;
            }
        }

        private void btnLOCKQ_MouseDown(object sender, MouseEventArgs e)
        {
            btnLOCKQ.BorderSize = 3;
            btnLOCKQ.BorderColor = Color.MidnightBlue;
        }

        private void btnLOCKQ_MouseUp(object sender, MouseEventArgs e)
        {
            btnRESET.BorderSize = 0;
        }

        private void btnRESET_MouseDown(object sender, MouseEventArgs e)
        {
            btnRESET.BorderSize = 3;
            btnRESET.BorderColor = Color.MidnightBlue;
        }

        private void btnRESET_MouseUp(object sender, MouseEventArgs e)
        {
            btnRESET.BorderSize = 0;
        }

        private void btnDATTOUR_MouseDown(object sender, MouseEventArgs e)
        {
            btnDATTOUR.BorderSize = 3;
            btnDATTOUR.BorderColor = Color.MidnightBlue;
        }

        private void btnDATTOUR_MouseUp(object sender, MouseEventArgs e)
        {
            btnDATTOUR.BorderSize = 0;
        }
    }
}
