using QL_tour_LTW.ModelQLTOUR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_tour_LTW
{
    public partial class ThemTour : Form
    {
        MainQLTOUR formMainQLTOUR;
        private string matour;
        public ThemTour(string GetMaTour)
        {
            this.matour = GetMaTour;
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
        private void FillLOAITOURCbb(List<LOAITOUR> loaitourlist, List<DIEMDI> diemdilist, List<DIEMDEN> diemdenlist, List<PHUONGTIEN> phuongtienlist, List<KHACHSAN> khachsanlist)
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
        private void bindingtxt()
        {
            QLTOURDBContext context = new QLTOURDBContext();
            var tim = context.TOURs.Where(s => s.MATOUR ==  matour).ToList();
            if( tim != null)
            {
                foreach (var item in tim)
                {
                    txttesst.Text = matour;
                    txtMATOUR.Texts = item.MATOUR;
                    txtTENTOUR.Texts = item.TENTOUR;
                    txtGIATOUR.Texts = item.GIATOUR.ToString();
                    txtMOTA.Texts = item.MOTA;
                    txtTRANGTHAI.Texts = item.TRANGTHAI;
                    dtpNGAYDI.Value = item.NGAYDI;
                    dtpKETTHUC.Value = item.NGAYKETTHUC;
                    cbbMALTOUR.Text = item.LOAITOUR.TENLTOUR;
                    cbbDIEMDI.Text = item.DIEMDI.TENDDI;
                    cbbDIEMDEN.Text = item.DIEMDEN.TENDDEN;
                    if(item.MAPT  == null)
                    {
                        cbbMAPT.Text = "";
                    }
                    else
                    {
                        cbbMAPT.Text = item.PHUONGTIEN.TENPT;
                    }
                    if (item.MAKS == null)
                    {
                        cbbMAKS.Text = "";
                    }
                    else
                    {
                        cbbMAKS.Text = item.KHACHSAN.TENKS;
                    }
                    byte[] imageBytes = item.ANH1 as byte[];
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
                    byte[] imageBytes2 = item.ANH2 as byte[];
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
                    byte[] imageBytes3 = item.ANH3 as byte[];
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
        }
        private void ThemTour_Load(object sender, EventArgs e)
        {
            QLTOURDBContext context = new QLTOURDBContext();
            List<LOAITOUR> loaitourlisst = context.LOAITOURs.ToList();
            List<DIEMDI> diemdilist = context.DIEMDIs.ToList();
            List<DIEMDEN> diemden = context.DIEMDENs.ToList();
            List<PHUONGTIEN> phuongtien = context.PHUONGTIENs.ToList();
            List<KHACHSAN> khachsan = context.KHACHSANs.ToList();
            FillLOAITOURCbb(loaitourlisst, diemdilist, diemden, phuongtien, khachsan);
            bindingtxt();
            bunifuiOSSwitch1.Value = true;
        }
        private byte[] selectedImageBytes1;
        private byte[] selectedImageBytes2;
        private byte[] selectedImageBytes3;
        private void them()
        {
            string mota = txtMOTA.Texts;
            string trangthai = txtTRANGTHAI.Texts;
            string mapt = cbbMAPT.SelectedValue != null ? cbbMAPT.SelectedValue.ToString() : null;
            string maks = cbbMAKS.SelectedValue != null ? cbbMAKS.SelectedValue.ToString() : null;


                TOUR insert = new TOUR
                {
                    MATOUR = txtMATOUR.Texts,
                    TENTOUR = txtTENTOUR.Texts,
                    GIATOUR = decimal.Parse(txtGIATOUR.Texts),
                    NGAYDI = dtpNGAYDI.Value,
                    NGAYKETTHUC = dtpKETTHUC.Value,
                    MOTA = mota,
                    TRANGTHAI = trangthai,
                    MALTOUR = cbbMALTOUR.SelectedValue.ToString(),
                    MADDI = cbbDIEMDI.SelectedValue.ToString(),
                    MADDEN = cbbDIEMDEN.SelectedValue.ToString(),
                    MAPT = mapt,
                    MAKS = maks,
                    ANH1 = selectedImageBytes1 ?? null,
                    ANH2 = selectedImageBytes2 ?? null,
                    ANH3 = selectedImageBytes3 ?? null

                };
                QLTOURDBContext context = new QLTOURDBContext();
                context.TOURs.Add(insert);
                context.SaveChanges();
                MessageBox.Show("Thêm tour thành công !", "Thông báo");
            
            
        }
        private void sua()
        {
            //
            string mapt = cbbMAPT.SelectedValue != null ? cbbMAPT.SelectedValue.ToString() : null;
            string maks = cbbMAKS.SelectedValue != null ? cbbMAKS.SelectedValue.ToString() : null;
            //string masach = txtMATOUR.Text;
            QLTOURDBContext context = new QLTOURDBContext();
            TOUR update = context.TOURs.FirstOrDefault(s => s.MATOUR == txtMATOUR.Texts);
            if (update != null)
            {                
                update.MATOUR = txtMATOUR.Texts;
                update.TENTOUR = txtTENTOUR.Texts;
                update.GIATOUR = decimal.Parse(txtGIATOUR.Texts);
                update.NGAYDI = dtpNGAYDI.Value;
                update.NGAYKETTHUC = dtpKETTHUC.Value;
                update.MOTA = txtMOTA.Texts;
                update.TRANGTHAI = txtTRANGTHAI.Texts;
                update.MALTOUR = cbbMALTOUR.SelectedValue.ToString();
                update.MADDI = cbbDIEMDI.SelectedValue.ToString();
                update.MADDEN = cbbDIEMDEN.SelectedValue.ToString();
                update.MAPT = mapt;
                update.MAKS = maks;
                if (selectedImageBytes1 != null)
                {
                    update.ANH1 = selectedImageBytes1;
                }
                else
                {
                    update.ANH1 = null;
                }
                if (selectedImageBytes2 != null)
                {
                    update.ANH2 = selectedImageBytes2;
                }
                else
                {
                    update.ANH2 = null;
                }
                if (selectedImageBytes3 != null)
                {
                    update.ANH3 = selectedImageBytes3;
                }
                else
                {
                    update.ANH3 = null;
                }
                context.SaveChanges();
                MessageBox.Show("sửa tour thành công !", "Thông báo");
            }
            else
            {
                MessageBox.Show("Không tìm thấy tour cầ sửa!", "Thông báo!");
            }
        }
        private void btnUPANH1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png, *.gif) | *.jpg; *.jpeg; *.png; *.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                selectedImageBytes1 = File.ReadAllBytes(imagePath);

                // Hiển thị ảnh lên PictureBox

                pcboxANH1.Image = Image.FromFile(imagePath);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void checktxt()
        {
            if (txtMATOUR.Texts == "" || txtTENTOUR.Texts == "" ||
           txtGIATOUR.Texts == "" || cbbMALTOUR.Text == "" || cbbDIEMDI.Text == "" ||
           cbbDIEMDEN.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dtpKETTHUC.Value < dtpNGAYDI.Value)
            {
                MessageBox.Show("Ngày kết thúc phải sau ngày đi!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }
        private int checkMAtour(string maT)
        {
            QLTOURDBContext context = new QLTOURDBContext();
            TOUR tim = context.TOURs.FirstOrDefault(s => s.MATOUR == maT);
            if(tim != null)
            {
                return 4;
            }
           return 5;
        }
        private void rjButton2_Click(object sender, EventArgs e)
        {           
            try
            {
                checktxt();
                int capnhat = checkMAtour(txtMATOUR.Texts);
                txttesst.Text = capnhat.ToString();
                if (capnhat == 5)
                {
                    them();
                }
                else
                {
                    sua();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUPANH2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png, *.gif) | *.jpg; *.jpeg; *.png; *.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                selectedImageBytes2 = File.ReadAllBytes(imagePath);

                // Hiển thị ảnh lên PictureBox
                pcboxANH2.Image = Image.FromFile(imagePath);
            }
        }

        private void btnUPANH3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png, *.gif) | *.jpg; *.jpeg; *.png; *.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                selectedImageBytes3 = File.ReadAllBytes(imagePath);

                // Hiển thị ảnh lên PictureBox
                pcboxANH3.Image = Image.FromFile(imagePath);
            }
        }

        private void bunifuiOSSwitch1_OnValueChange(object sender, EventArgs e)
        {
            if (bunifuiOSSwitch1.Value == true)
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

        private void txtMATOUR_Enter(object sender, EventArgs e)
        {
            txtMATOUR.BackColor = Color.Gainsboro;
        }

        private void txtMATOUR_Leave(object sender, EventArgs e)
        {
            txtMATOUR.BackColor = Color.White;
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

        private void txtMATOUR_KeyPress(object sender, KeyPressEventArgs e)
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
            e.Handled = true;
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
    }
}
