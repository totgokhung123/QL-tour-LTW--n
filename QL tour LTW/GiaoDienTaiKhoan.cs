using QL_tour_LTW.ModelQLTOUR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_tour_LTW
{
    public partial class GiaoDienTaiKhoan : Form
    {
        private string tentaikhoan;
        public GiaoDienTaiKhoan(string tentaikhoan)
        {
            InitializeComponent();
            this.MouseDown += GiaoDienTaiKhoan_MouseDown;
            this.MouseMove += GiaoDienTaiKhoan_MouseMove;
            this.MouseUp += GiaoDienTaiKhoan_MouseUp;
            this.tentaikhoan = tentaikhoan;
        }
        private bool isDragging = false;
        private Point startPoint;
        private void GiaoDienTaiKhoan_Load(object sender, EventArgs e)
        {
            QLTOURDBContext context = new QLTOURDBContext();
            var list = context.NHANVIENs.Where(s => s.SDT == tentaikhoan || s.EMAIL == tentaikhoan).ToList();
            foreach (var item in list)
            {
                txtMANV.Texts = item.MANV;
                txtHOTENNV.Texts = item.HOTEN;
                if(item.GIOITINH == "Nam")
                {
                    rbNAM.Checked = true;
                }
                else if(item.GIOITINH == "Nữ")
                {
                    rbNU.Checked = true;
                }
                else
                {
                    rbKHAC.Checked = true;
                }
                dtpNGAYDI.Value = item.NGAYSINH;
                txtSODTNV.Texts = item.SDT;
                txtCCCDNV.Texts = item.CCCD;
                txtEMAILNV.Texts = item.EMAIL;
            }
        }

        private void GiaoDienTaiKhoan_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                startPoint = new Point(e.X, e.Y);
            }
        }

        private void GiaoDienTaiKhoan_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - startPoint.X, p.Y - startPoint.Y);
            }
        }

        private void GiaoDienTaiKhoan_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtMANV_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void rbKHAC_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnDOIMATKHAU_Click(object sender, EventArgs e)
        {
            DoiMatKhau f = new DoiMatKhau(tentaikhoan);
            f.ShowDialog();
        }
        private byte[] selectedImageBytes1;
        private void btnDOIANH_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png, *.gif) | *.jpg; *.jpeg; *.png; *.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                selectedImageBytes1 = File.ReadAllBytes(imagePath);

                // Hiển thị ảnh lên PictureBox

                picboxANH.Image = Image.FromFile(imagePath);
            }
        }

        private void txtLUU_Click(object sender, EventArgs e)
        {
            //string masach = txtMATOUR.Text;
            string GIOITINH = rbNAM.Checked ? "Nam" : rbNU.Checked ? "Nữ" : rbKHAC.Checked ? "Khác": "";
            QLTOURDBContext context = new QLTOURDBContext();
            NHANVIEN update = context.NHANVIENs.FirstOrDefault(s => s.MANV == txtMANV.Texts);
            if (update != null)
            {
                update.MANV = txtMANV.Texts;
                update.HOTEN = txtHOTENNV.Texts;

                update.GIOITINH = GIOITINH;
                update.NGAYSINH = dtpNGAYDI.Value;
                update.SDT = txtSODTNV.Texts;
                update.CCCD = txtCCCDNV.Texts;
                update.EMAIL = txtEMAILNV.Texts;
                if (selectedImageBytes1 != null)
                {
                    update.ANH = selectedImageBytes1;
                }
                else
                {
                    update.ANH = null;
                }
                context.SaveChanges();
                MessageBox.Show("sửa ảnh thành công !", "Thông báo");
            }
            else
            {
                MessageBox.Show("Sai thông tin nhân viên!", "Thông báo!");
            }
        }

        private void dtpNGAYDI_MouseClick(object sender, MouseEventArgs e)
        {
            
        }
    }
}
