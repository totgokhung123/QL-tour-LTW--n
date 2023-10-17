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
using System.Text.RegularExpressions;
using System.Runtime.Remoting.Contexts;
using System.Xml;

namespace QL_tour_LTW
{
    public partial class THONGTINDANGKYTOUR : Form
    {
        private string matour;
        public THONGTINDANGKYTOUR(string MATOUR)
        {
            this.matour = MATOUR;
            InitializeComponent();
        }

        private void picboxCOPYANH1_Click(object sender, EventArgs e)
        {

        }

        private void lblTongCong_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }
        private void FillLOAITOURCbb(List<NHANVIEN> nhanvienlist)
        {
            cbbTENNV.DataSource = nhanvienlist;
            cbbTENNV.DisplayMember = "HOTEN";
            cbbTENNV.ValueMember = "MANV";
        }
        QLTOURDBContext context = new QLTOURDBContext();
        private void bindingtxt()
        {
           // QLTOURDBContext context = new QLTOURDBContext();
            var tim = context.TOURs.Where(s => s.MATOUR == matour).ToList();
            if (tim != null)
            {
                foreach (var item in tim)
                {
                    lbMaTour.Text = item.MATOUR;
                    lbtentourHD.Text = item.TENTOUR;
                    lbTenTour.Text = "[" + item.MATOUR + "] " + item.TENTOUR;
                    lbTHANHTIEN.Text = lbGIATOUR.Text = string.Format("{0:#,##0}",item.GIATOUR) + "/đ Khách";
                    lbDateBatDauChuyenDi.Text = lbTGkhoihanh.Text = item.NGAYDI.ToShortDateString();
                    lbDateKetThucChuyenDi.Text  = item.NGAYKETTHUC.ToShortDateString();
                    lbLoaitour.Text = item.LOAITOUR.TENLTOUR;
                    lbDiemDi.Text = item.DIEMDI.TENDDI;
                    lbDIEMDEN.Text = item.DIEMDEN.TENDDEN;
                    if (item.MAPT == null)
                    {
                        lbPT.Text = "chưa có";
                    }
                    else
                    {
                        lbPT.Text = item.PHUONGTIEN.TENPT;
                    }
                    if (item.MAKS == null)
                    {
                        lbKS.Text = "chưa có";
                    }
                    else
                    {
                        lbKS.Text = item.KHACHSAN.TENKS;
                    }
                    byte[] imageBytes = item.ANH1 as byte[];
                    if (imageBytes != null)
                    {
                        using (MemoryStream ms1 = new MemoryStream(imageBytes))
                        {
                            picboxANH1.Image = Image.FromStream(ms1);
                            picboxCOPYANH1.Image = Image.FromStream(ms1);
                        }
                    }
                    else
                    {
                        picboxANH1.Image = default;
                        picboxCOPYANH1.Image= default;
                    }                    
                }
            }
        }
        private void THONGTINDANGKYTOUR_Load(object sender, EventArgs e)
        {
            lbNgayTaoHD.Text = DateTime.Today.ToString();
            List<NHANVIEN> nhanvien = context.NHANVIENs.ToList();
            FillLOAITOURCbb(nhanvien);
            bindingtxt();
            lbSoHD.Text = GenerateSOHD();
        }
        private int checktxt()
        {
            if(txtHODEMKH.Texts == "" ||txtTENKH.Texts == "" || txtSDT.Texts == ""|| txtEMAIL.Texts ==""||txtCCCD.Texts == ""||txtSL.Texts == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 2;
            }
            return -1;
        }
        private int checkMAKH(string cccd)
        {
         //   QLTOURDBContext context = new QLTOURDBContext();
            KHACHHANG timkh = context.KHACHHANGs.FirstOrDefault(s => s.CCCD == cccd);
            if (timkh != null)
            {
                return 4;
            }
            return 5;
        }
        private string GenerateMaKH()
        {
            // Kết nối đến CSDL và truy vấn mã khách hàng lớn nhất hiện tại
            QLTOURDBContext context = new QLTOURDBContext();
            string maxMaKH = context.KHACHHANGs.Max(s => s.MAKH);
            // Tách phần số từ mã khách hàng lớn nhất hiện tại (ví dụ: "KH01" -> "01")
            string soThuTu = maxMaKH.Substring(2);
            // Chuyển phần số thành số nguyên
            int soThuTuInt = int.Parse(soThuTu);
            // Tăng số thứ tự lên 1
            soThuTuInt++;
            // Tạo mã khách hàng mới (ví dụ: "KH02")
            string maKHMoi = "KH" + soThuTuInt.ToString("D2");

            return maKHMoi;
        }
        private string GenerateSOHD()
        {
            // Kết nối đến CSDL và truy vấn mã khách hàng lớn nhất hiện tại
            QLTOURDBContext context = new QLTOURDBContext();
            string maxsohd = context.HOADONs.Max(s => s.SOHD);
            // Tách phần số từ mã khách hàng lớn nhất hiện tại (ví dụ: "HD01" -> "01")
            string soThuTu = maxsohd.Substring(2);
            // Chuyển phần số thành số nguyên
            int soThuTuInt = int.Parse(soThuTu);
            // Tăng số thứ tự lên 1
            soThuTuInt++;
            // Tạo mã khách hàng mới (ví dụ: "KH02")
            string mahdmoi = "HD" + soThuTuInt.ToString("D2");

            return mahdmoi;
        }
        private void themDATAKH()
        {
            
            KHACHHANG insert = new KHACHHANG
            {
                MAKH = GenerateMaKH(),
                HO = txtHODEMKH.Texts,
                TEN = txtTENKH.Texts,
                 SDT= txtSDT.Texts,
                CCCD = txtCCCD.Texts,
                EMAIL = txtEMAIL.Texts,
                SL = int.Parse(txtSL.Texts)
            };
            QLTOURDBContext context = new QLTOURDBContext();
            context.KHACHHANGs.Add(insert);
            context.SaveChanges();
            MessageBox.Show("Thêm khách hàng thành công !", "Thông báo");
        }      
        private void themkhachhang()
        {
            int kiemtratxt = checktxt();
            if(kiemtratxt == 2)
            {
                return;
            }
            else
            {
                
                if (rbKHONGCHUYENKHOAN.Checked == true)
                {
                    lbSL.Text = txtSL.Texts;
                    decimal giatour = decimal.Parse(lbTHANHTIEN.Text.Replace("/đ Khách", string.Empty).Replace(",", string.Empty));
                    decimal soluong = decimal.Parse(txtSL.Texts);
                    decimal tongtien = (decimal)giatour * soluong;
                    lbTongCong.Text = string.Format("{0:#,##0}", tongtien).ToString() + " đồng";
                    int kiemtrathongtinKH = checkMAKH(txtCCCD.Texts);

                    if (kiemtrathongtinKH == 4)
                    {
                        DialogResult dr = MessageBox.Show("Đã có khách hàng trong data, Bạn sẽ tiếp tục thanh toán chứ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            var timkh = context.KHACHHANGs.Where(s => s.CCCD.Equals(txtCCCD.Texts)).ToList();
                            foreach (var item in timkh)
                            {
                                lbTenKH.Text = item.HO + " " + item.TEN;
                            }
                            if (cbbTENNV.Text == "")
                            {
                                MessageBox.Show("Vui lòng chọn nhân viên", "Thông báo!");
                                return;
                            }
                            else
                            {
                                QLTOURDBContext context = new QLTOURDBContext();
                                var kh = context.KHACHHANGs.Where(s => s.CCCD.Equals(txtCCCD.Texts)).ToList();
                                string tennv = cbbTENNV.SelectedValue != null ? cbbTENNV.SelectedValue.ToString() : null;
                                foreach (var makhachhang in kh)
                                {
                                    HOADON insert = new HOADON
                                    {
                                        SOHD = GenerateSOHD(),
                                        NGAYLAP = DateTime.Parse(lbNgayTaoHD.Text),
                                        THANHTIEN = tongtien,
                                        MATOUR = lbMaTour.Text,
                                        MAKH = makhachhang.MAKH,
                                        MANV = tennv,
                                        TRANGTHAI = null
                                    };
                                    QLTOURDBContext context1 = new QLTOURDBContext();
                                    context1.HOADONs.Add(insert);
                                    context1.SaveChanges();
                                    MessageBox.Show("Thanh toán thành công !", "Thông báo");
                                    QLTOURDBContext context2 = new QLTOURDBContext();
                                    string maxsohd = context2.HOADONs.Max(s => s.SOHD);
                                    InHoaDon inHoaDon = new InHoaDon(maxsohd);
                                    inHoaDon.ShowDialog();
                                }

                            }
                        }
                    }
                    else
                    {
                        try
                        {
                            themDATAKH();

                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message);
                        }
                        QLTOURDBContext context2 = new QLTOURDBContext();
                        var timkh = context2.KHACHHANGs.Where(s => s.CCCD.Equals(txtCCCD.Texts)).ToList();
                        foreach (var item in timkh)
                        {
                            lbTenKH.Text = item.HO + " " + item.TEN;
                        }
                        QLTOURDBContext context = new QLTOURDBContext();
                        var kh = context.KHACHHANGs.Where(s => s.CCCD.Equals(txtCCCD.Texts)).ToList();
                        string tennv = cbbTENNV.SelectedValue != null ? cbbTENNV.SelectedValue.ToString() : null;
                        foreach (var makhachhang in kh)
                        {
                            HOADON insert = new HOADON
                            {
                                SOHD = GenerateSOHD(),
                                NGAYLAP = DateTime.Parse(lbNgayTaoHD.Text),
                                THANHTIEN = tongtien,
                                MATOUR = lbMaTour.Text,
                                MAKH = makhachhang.MAKH,
                                MANV = tennv,
                                TRANGTHAI = null
                            };
                            QLTOURDBContext context1 = new QLTOURDBContext();
                            context1.HOADONs.Add(insert);
                            context1.SaveChanges();
                             MessageBox.Show("Thanh toán thành công !", "Thông báo");
                            string maxsohd = context2.HOADONs.Max(s => s.SOHD);
                            InHoaDon inHoaDon = new InHoaDon(maxsohd);
                            inHoaDon.ShowDialog();
                        }
                    }
                }
                else if(rbCHUYENKHOAN.Checked == true)
                {
                    panelMAQR.Visible = true;
                    if(rbBIDV.Checked == false && SATCOMBANK.Checked == false && rbMOMO.Checked == false)
                    {
                        MessageBox.Show("Hãy chọn ngân hàng chuyển khoản", "Thông báo");
                        return;
                    }
                    else
                    {
                        lbSL.Text = txtSL.Texts;
                        decimal giatour = decimal.Parse(lbTHANHTIEN.Text.Replace("/đ Khách", string.Empty).Replace(",", string.Empty));
                        decimal soluong = decimal.Parse(txtSL.Texts);
                        decimal tongtien = (decimal)giatour * soluong;
                        lbTongCong.Text = string.Format("{0:#,##0}", tongtien).ToString() + " đồng";
                        int kiemtrathongtinKH = checkMAKH(txtCCCD.Texts);

                        if (kiemtrathongtinKH == 4)
                        {
                            DialogResult dr = MessageBox.Show("Đã có khách hàng trong data, Bạn sẽ tiếp tục thanh toán chứ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dr == DialogResult.Yes)
                            {
                                var timkh = context.KHACHHANGs.Where(s => s.CCCD.Equals(txtCCCD.Texts)).ToList();
                                foreach (var item in timkh)
                                {
                                    lbTenKH.Text = item.HO + " " + item.TEN;
                                }
                                if (cbbTENNV.Text == "")
                                {
                                    MessageBox.Show("Vui lòng chọn nhân viên", "Thông báo!");
                                    return;
                                }
                                else
                                {
                                    QLTOURDBContext context = new QLTOURDBContext();
                                    var kh = context.KHACHHANGs.Where(s => s.CCCD.Equals(txtCCCD.Texts)).ToList();
                                    string tennv = cbbTENNV.SelectedValue != null ? cbbTENNV.SelectedValue.ToString() : null;
                                    foreach (var makhachhang in kh)
                                    {
                                        HOADON insert = new HOADON
                                        {
                                            SOHD = GenerateSOHD(),
                                            NGAYLAP = DateTime.Parse(lbNgayTaoHD.Text),
                                            THANHTIEN = tongtien,
                                            MATOUR = lbMaTour.Text,
                                            MAKH = makhachhang.MAKH,
                                            MANV = tennv,
                                            TRANGTHAI = null
                                        };
                                        QLTOURDBContext context1 = new QLTOURDBContext();
                                        context1.HOADONs.Add(insert);
                                        context1.SaveChanges();
                                        //  MessageBox.Show("Thanh toán thành công !", "Thông báo");
                                        QLTOURDBContext context2 = new QLTOURDBContext();
                                        string maxsohd = context2.HOADONs.Max(s => s.SOHD);
                                        InHoaDon inHoaDon = new InHoaDon(maxsohd);
                                        inHoaDon.ShowDialog();
                                    }

                                }
                            }
                        }
                        else
                        {
                            try
                            {
                                themDATAKH();

                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show(ex.Message);
                            }
                            QLTOURDBContext context2 = new QLTOURDBContext();
                            var timkh = context2.KHACHHANGs.Where(s => s.CCCD.Equals(txtCCCD.Texts)).ToList();
                            foreach (var item in timkh)
                            {
                                lbTenKH.Text = item.HO + " " + item.TEN;
                            }
                            QLTOURDBContext context = new QLTOURDBContext();
                            var kh = context.KHACHHANGs.Where(s => s.CCCD.Equals(txtCCCD.Texts)).ToList();
                            string tennv = cbbTENNV.SelectedValue != null ? cbbTENNV.SelectedValue.ToString() : null;
                            foreach (var makhachhang in kh)
                            {
                                HOADON insert = new HOADON
                                {
                                    SOHD = GenerateSOHD(),
                                    NGAYLAP = DateTime.Parse(lbNgayTaoHD.Text),
                                    THANHTIEN = tongtien,
                                    MATOUR = lbMaTour.Text,
                                    MAKH = makhachhang.MAKH,
                                    MANV = tennv,
                                    TRANGTHAI = null
                                };
                                QLTOURDBContext context1 = new QLTOURDBContext();
                                context1.HOADONs.Add(insert);
                                context1.SaveChanges();
                                // MessageBox.Show("Thanh toán thành công !", "Thông báo");
                                string maxsohd = context2.HOADONs.Max(s => s.SOHD);
                                InHoaDon inHoaDon = new InHoaDon(maxsohd);
                                inHoaDon.ShowDialog();
                            }
                        }
                    }
                }
                
            }
        }

        private void btnTHANHTIEN_Click(object sender, EventArgs e)
        {
            themkhachhang();
        }
        bool isChecked = false;
        private void rbCHUYENKHOAN_CheckedChanged(object sender, EventArgs e)
        {
            isChecked = rbCHUYENKHOAN.Checked;
        }

        private void rbCHUYENKHOAN_Click(object sender, EventArgs e)
        {
            if (rbCHUYENKHOAN.Checked && !isChecked)
            {
                rbCHUYENKHOAN.Checked = false;
                panelMAQR.Visible = false;
            }                
            else
            {
                rbCHUYENKHOAN.Checked = true;
                panelMAQR.Visible = true;
                isChecked = false;
            }
        }

        private void cbbTENNV_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtHODEMKH_KeyPress(object sender, KeyPressEventArgs e)
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
            if (txtHODEMKH.Texts.Length >= 32 && e.KeyChar != '\b')
            {
                e.Handled = true; // Hủy sự kiện KeyPress
                MessageBox.Show("Họ tên đệm không quá 32 ký tự!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtTENKH.Texts.Length >= 11 && e.KeyChar != '\b')
            {
                e.Handled = true; // Hủy sự kiện KeyPress
                MessageBox.Show("Tên không quá 11 ký tự!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void txtCCCD_KeyPress(object sender, KeyPressEventArgs e)
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
            if (txtSDT.Texts.Length >= 13 && e.KeyChar != '\b')
            {
                e.Handled = true; // Hủy sự kiện KeyPress
                MessageBox.Show("Số điện thoại không quá 13 ký tự!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtCCCD.Texts.Length >= 13 && e.KeyChar != '\b')
            {
                e.Handled = true; // Hủy sự kiện KeyPress
                MessageBox.Show("Căn cước không quá 13 ký tự!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void txtHODEMKH_Enter(object sender, EventArgs e)
        {
            txtHODEMKH.BackColor = Color.Gainsboro;
        }

        private void txtHODEMKH_Leave(object sender, EventArgs e)
        {
            txtHODEMKH.BackColor = Color.White;
        }

        private void txtTENKH_Enter(object sender, EventArgs e)
        {
            txtTENKH.BackColor = Color.Gainsboro;
        }

        private void txtTENKH_Leave(object sender, EventArgs e)
        {
            txtTENKH.BackColor = Color.White;
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

        private void txtEMAIL_Enter(object sender, EventArgs e)
        {
            txtEMAIL.BackColor = Color.Gainsboro;
        }

        private void txtEMAIL_Leave(object sender, EventArgs e)
        {
            txtEMAIL.BackColor = Color.White;
        }

        private void txtSL_Enter(object sender, EventArgs e)
        {
            txtSL.BackColor = Color.Gainsboro;
        }

        private void txtSL_Leave(object sender, EventArgs e)
        {
            txtSL.BackColor = Color.White;
        }

        private void btnTHANHTIEN_MouseDown(object sender, MouseEventArgs e)
        {
            btnTHANHTIEN.BorderSize = 2;
            btnTHANHTIEN.BorderColor = Color.MidnightBlue;
        }

        private void btnTHANHTIEN_MouseUp(object sender, MouseEventArgs e)
        {
            btnTHANHTIEN.BorderSize = 0;
        }

        private void btnHUY_MouseDown(object sender, MouseEventArgs e)
        {
            btnHUY.BorderSize = 2;
            btnHUY.BorderColor = Color.MidnightBlue;
        }

        private void btnHUY_MouseUp(object sender, MouseEventArgs e)
        {
            btnHUY.BorderSize = 0;
        }

        private void btnHUY_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
