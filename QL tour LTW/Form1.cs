using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace QL_tour_LTW
{
    public partial class Form1 : Form
    {
        private string tentaikhoan;
        public Form1(string tentaikhoan)
        {
            InitializeComponent();
            mdiprop();
            this.tentaikhoan = tentaikhoan;
        }
        private void mdiprop()
        {
            this.SetBevel(false);
            Controls.OfType<MdiClient>().FirstOrDefault().BackColor = Color.FromArgb(232, 234, 237);
        }
        bool time = true;
        private void menutimer1_Tick(object sender, EventArgs e)
        {
            if (time)
            {
                panelMenu.Width -= 5;
                if (panelMenu.Width == panelMenu.MinimumSize.Width)
                {
                    time = false;
                    menutimer1.Stop();
                    panelTRANGCHU.Width = panelMenu.Width;
                    panelQLNV.Width = panelMenu.Width;
                    flpanelKH.Width = panelMenu.Width;
                    flpanelQLTOUR.Width = panelMenu.Width;
                    flpanelHOADON.Width = panelMenu.Width;
                    flpanelQLDICHVU.Width = panelMenu.Width;
                    flpanelQLHETHONG.Width = panelMenu.Width;                    
                    panelthoat.Width = panelMenu.Width;
                    panelKhungMENU.Width = panelMenu.Width;
                    if (panelQLNV.Height >= 106)
                    {
                        QLNVtimer.Start();
                        panelQLNV.Height -= 20;
                        if (panelQLNV.Height <= 49)
                        {
                            QLNVtime = false;
                            QLNVtimer.Stop();
                        }
                    }
                    if (flpanelKH.Height >= 106)
                    {
                        QLKHtimer.Start();
                        flpanelKH.Height -= 20;
                        if (flpanelKH.Height <= 49)
                        {
                            QLKHtime = false;
                            QLKHtimer.Stop();
                        }
                    }
                    if (flpanelQLTOUR.Height >= 161)
                    {
                        QLTOURtimer.Start();
                        flpanelQLTOUR.Height -= 20;
                        if (flpanelQLTOUR.Height <= 49)
                        {
                            QLTOURtime = false;
                            QLTOURtimer.Stop();
                        }
                    }
                    if (flpanelHOADON.Height >= 160)
                    {
                        QLHOADONtimer.Start();
                        flpanelHOADON.Height -= 20;
                        if (flpanelHOADON.Height <= 49)
                        {
                            QLHOADONtime = false;
                            QLHOADONtimer.Stop();
                        }
                    }
                    if (flpanelQLDICHVU.Height >= 106)
                    {
                        QLDICHVUtimer.Start();
                        flpanelQLDICHVU.Height -= 20;
                        if (flpanelQLDICHVU.Height <= 49)
                        {
                            QLDICHVUtime = false;
                            QLDICHVUtimer.Stop();
                        }
                    }
                    if (flpanelQLHETHONG.Height >= 200)
                    {
                        QLHETHONGtimer.Start();
                        flpanelQLHETHONG.Height -= 20;
                        if (flpanelQLHETHONG.Height <= 49)
                        {
                            QLHETHONGtime = false;
                            QLHETHONGtimer.Stop();
                        }
                    }
                }
            }
            else
            {
                panelMenu.Width += 5;
                if (panelMenu.Width == panelMenu.MaximumSize.Width)
                {
                    time = true;
                    menutimer1.Stop();
                    panelQLNV.Width = panelMenu.Width;
                    flpanelKH.Width = panelMenu.Width;
                    flpanelQLTOUR.Width = panelMenu.Width;
                    flpanelHOADON.Width = panelMenu.Width;
                    flpanelQLDICHVU.Width = panelMenu.Width;
                    flpanelQLHETHONG.Width = panelMenu.Width;
                    panelthoat.Width = panelMenu.Width;
                    panelTRANGCHU.Width = panelMenu.Width;
                    panelKhungMENU.Width = panelMenu.Width;
                }
            }
        }
        TRANGCHU formtrangchu;
        private void button1_Click(object sender, EventArgs e)
        {
            if (formtrangchu == null || formtrangchu.IsDisposed)
            {
                CloseOtherForms(formtrangchu);
                formtrangchu = new TRANGCHU();
                //formDICHVU.FormClosed += frmQuanLyDichVu_FormClosed;
                formtrangchu.MdiParent = this;
                formtrangchu.Dock = DockStyle.Fill;
                formtrangchu.ControlBox = false;
                formtrangchu.FormBorderStyle = FormBorderStyle.None;
                formtrangchu.Show();
            }
            else
            {
                formtrangchu.Activate();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            QLNVtimer.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetFullScreen();
            if (formtrangchu == null || formtrangchu.IsDisposed)
            {
                CloseOtherForms(formtrangchu);
                formtrangchu = new TRANGCHU();
                //formDICHVU.FormClosed += frmQuanLyDichVu_FormClosed;
                formtrangchu.MdiParent = this;
                formtrangchu.Dock = DockStyle.Fill;
                formtrangchu.ControlBox = false;
                formtrangchu.FormBorderStyle = FormBorderStyle.None;
                formtrangchu.Show();
            }
            else
            {
                formtrangchu.Activate();
            }
            // mdiprop();
        }
        private void SetFullScreen()
        {
            // Thiết lập thuộc tính của form
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.Sizable;

            // Đảm bảo rằng form không che phủ taskbar
            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Size = workingArea.Size;
            this.Location = workingArea.Location;
        }
        QLNhanVien formnhanvien;
        private void button7_Click(object sender, EventArgs e)
        {
            if (formnhanvien == null || formnhanvien.IsDisposed)
            {
                CloseOtherForms(formnhanvien);
                formnhanvien = new QLNhanVien();
                //formDICHVU.FormClosed += frmQuanLyDichVu_FormClosed;
                formnhanvien.MdiParent = this;
                formnhanvien.Dock = DockStyle.Fill;
                formnhanvien.ControlBox = false;
                formnhanvien.FormBorderStyle = FormBorderStyle.None;
                formnhanvien.Show();
            }
            else
            {
                formnhanvien.Activate();
            }
        }

        private void formQLNV_FormClosed(object sender, FormClosedEventArgs e)
        {
            formQLNV = null;
        }
        private void formQLTOUR_FormClosed(object sender, FormClosedEventArgs e)
        {
            formTOUR = null;
        }
        private void formQLKH_FormClosed(object sender, FormClosedEventArgs e)
        {
            formKH = null;
        }
        private void frmQuanLyDichVu_FormClosed(object sender, FormClosedEventArgs e)
        {
            formDICHVU = null;
        }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        bool QLNVtime = false;
        private void QLNVtimer_Tick(object sender, EventArgs e)
        {
            if (QLNVtime == false)
            {               
                panelQLNV.Height += 10;
                if (panelQLNV.Height >= 106)
                {
                  //  time = false;
                  //  menutimer1.Start();
                    QLNVtimer.Stop();                  
                    QLNVtime = true;
                }
            }
            else
            {
                panelQLNV.Height -= 10;
                if (panelQLNV.Height <= 49)
                {
                    QLNVtime = false;
                    QLNVtimer.Stop();
                }
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            QLHETHONGtimer.Start();
        }
        bool QLKHtime = false;
        private void QLKHtimer_Tick(object sender, EventArgs e)
        {
            if (QLKHtime == false)
            {
                flpanelKH.Height += 10;
                if (flpanelKH.Height >= 106)
                {
                    QLKHtimer.Stop();
                    QLKHtime = true;
                }
            }
            else
            {
                flpanelKH.Height -= 10;
                if (flpanelKH.Height <= 49)
                {
                    QLKHtime = false;
                    QLKHtimer.Stop();
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            QLKHtimer.Start();
        }
        bool QLTOURtime = false;
        private void QLTOURtimer_Tick(object sender, EventArgs e)
        {
            if (QLTOURtime == false)
            {
                flpanelQLTOUR.Height += 10;
                if (flpanelQLTOUR.Height >= 160)
                {
                    QLTOURtimer.Stop();
                    QLTOURtime = true;
                }
            }
            else
            {
                flpanelQLTOUR.Height -= 10;
                if (flpanelQLTOUR.Height <= 49)
                {
                    QLTOURtime = false;
                    QLTOURtimer.Stop();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            QLTOURtimer.Start();
        }
        bool QLHOADONtime = false;
        private void QLHOADON_Tick(object sender, EventArgs e)
        {
            if (QLHOADONtime == false)
            {
                flpanelHOADON.Height += 10;
                if (flpanelHOADON.Height >= 160)
                {
                    QLHOADONtimer.Stop();
                    QLHOADONtime = true;
                }
            }
            else
            {
                flpanelHOADON.Height -= 10;
                if (flpanelHOADON.Height <= 49)
                {
                    QLHOADONtime = false;
                    QLHOADONtimer.Stop();
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            QLHOADONtimer.Start();
        }
        bool QLDICHVUtime = false;
        private void QLDICHVU_Tick(object sender, EventArgs e)
        {
            if (QLDICHVUtime == false)
            {
                flpanelQLDICHVU.Height += 10;
                if (flpanelQLDICHVU.Height >= 106)
                {
                    QLDICHVUtimer.Stop();
                    QLDICHVUtime = true;
                }
            }
            else
            {
                flpanelQLDICHVU.Height -= 10;
                if (flpanelQLDICHVU.Height <= 49)
                {
                    QLDICHVUtime = false;
                    QLDICHVUtimer.Stop();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            QLDICHVUtimer.Start();
        }
        bool QLHETHONGtime = false;
        private void QLHETHONGtimer_Tick(object sender, EventArgs e)
        {
            if (QLHETHONGtime == false)
            {
                flpanelQLHETHONG.Height += 10;
                if (flpanelQLHETHONG.Height >= 200)
                {
                    QLHETHONGtimer.Stop();
                    QLHETHONGtime = true;
                }
            }
            else
            {
                flpanelQLHETHONG.Height -= 10;
                if (flpanelQLHETHONG.Height <= 49)
                {
                    QLHETHONGtime = false;
                    QLHETHONGtimer.Stop();
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panelMenu_MouseClick(object sender, MouseEventArgs e)
        {
            menutimer1.Start();
        }

        private void panelMenu_MouseLeave(object sender, EventArgs e)
        {
          //  TGroichuot.Start();
        }
   //     bool TGroichuottime = false;
        private void TGroichuot_Tick(object sender, EventArgs e)
        {
            if(time)
            {
                panelMenu.Width -= 20;
                if (panelMenu.Width == panelMenu.MinimumSize.Width)
                {
                    time = false;
                    TGroichuot.Stop();
                }
            }
            
        }

        private void TGxoramenu_Tick(object sender, EventArgs e)
        {
            if(time == false)
            {
                panelMenu.Width += 20;
                if (panelMenu.Width == panelMenu.MaximumSize.Width)
                {
                    time = true;
                    TGxoramenu.Stop();
                }
            }
        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button23_Click(object sender, EventArgs e)
        {
            menutimer1.Start();
            
        }        
        private void btnTHONGTINTOUR_Click(object sender, EventArgs e)
        {
            if (formTOUR == null || formTOUR.IsDisposed)
            {
                CloseOtherForms(formTOUR);
                formTOUR = new MainQLTOUR();
                //formDICHVU.FormClosed += frmQuanLyDichVu_FormClosed;
                formTOUR.MdiParent = this;
                formTOUR.Dock = DockStyle.Fill;
                formTOUR.ControlBox = false;
                formTOUR.FormBorderStyle = FormBorderStyle.None;
                formTOUR.Show();
            }
            else
            {
                formTOUR.Activate();
            }
        }
        
        private void btnTHONGTINKHACHHANG_Click(object sender, EventArgs e)
        {
            if (formKH == null || formKH.IsDisposed)
            {
                CloseOtherForms(formKH);
                formKH = new GiaoDienQLThongTInKH();
                //formDICHVU.FormClosed += frmQuanLyDichVu_FormClosed;
                formKH.MdiParent = this;
                formKH.Dock = DockStyle.Fill;
                formKH.ControlBox = false;
                formKH.FormBorderStyle = FormBorderStyle.None;
                formKH.Show();
            }
            else
            {
                formKH.Activate();
            }
        }
        
        private void btnTHONGTINDV_Click(object sender, EventArgs e)
        {
            if (formDICHVU == null || formDICHVU.IsDisposed)
            {
                    CloseOtherForms(formDICHVU);
                    formDICHVU = new frmQuanLyDichVu();
                    //formDICHVU.FormClosed += frmQuanLyDichVu_FormClosed;
                    formDICHVU.MdiParent = this;
                    formDICHVU.Dock = DockStyle.Fill;
                    formDICHVU.ControlBox = false;
                    formDICHVU.FormBorderStyle = FormBorderStyle.None;
                    formDICHVU.Show();
            }
            else
            {
                formDICHVU.Activate();
            }
        }
        QLThongTinNV formQLNV;
        MainQLTOUR formTOUR;
        GiaoDienQLThongTInKH formKH;
        frmQuanLyDichVu formDICHVU;
        private void CloseOtherForms(Form currentForm)
        {
            if (formnhanvien != currentForm && formnhanvien != null && !formnhanvien.IsDisposed)
            {
                formnhanvien.Close();
                formnhanvien.Dispose();
            }
            if (formTOUR != currentForm && formTOUR != null && !formTOUR.IsDisposed)
            {
                formTOUR.Close();
                formTOUR.Dispose();
            }
            if (formKH != currentForm && formKH != null && !formKH.IsDisposed)
            {
                formKH.Close();
                formKH.Dispose();
            }
            if (formDICHVU != currentForm && formDICHVU != null && !formDICHVU.IsDisposed)
            {
                formDICHVU.Close();
                formDICHVU.Dispose();
            }
            if (formdangkytour != currentForm && formdangkytour != null && !formdangkytour.IsDisposed)
            {
                formdangkytour.Close();
                formdangkytour.Dispose();
            }
            if (formtrangchu != currentForm && formtrangchu != null && !formtrangchu.IsDisposed)
            {
                formtrangchu.Close();
                formtrangchu.Dispose();
            }
            if (formhoadon != currentForm && formhoadon != null && !formhoadon.IsDisposed)
            {
                formhoadon.Close();
                formhoadon.Dispose();
            }
        }
        DANGKYTOUR formdangkytour;
        private void btnDKTOUR_Click(object sender, EventArgs e)
        {
            if (formdangkytour == null || formdangkytour.IsDisposed)
            {
                CloseOtherForms(formdangkytour);
                formdangkytour = new DANGKYTOUR();
                //formDICHVU.FormClosed += frmQuanLyDichVu_FormClosed;
                formdangkytour.MdiParent = this;
                formdangkytour.Dock = DockStyle.Fill;
                formdangkytour.ControlBox = false;
                formdangkytour.FormBorderStyle = FormBorderStyle.None;
                formdangkytour.Show();
            }
            else
            {
                formdangkytour.Activate();
            }
        }
        GiaoDienTaiKhoan formthongtintaikhoan;
        private void btnTHONGTINTK_Click(object sender, EventArgs e)
        {
            formthongtintaikhoan = new GiaoDienTaiKhoan(tentaikhoan);
            formthongtintaikhoan.ShowDialog();
        }
        DangKy formdangkytk;
        private void btnDKTK_Click(object sender, EventArgs e)
        {
            formdangkytk = new DangKy();
            formdangkytk.ShowDialog();
        }
        HoaDon formhoadon;
        private void btnTHONGTINHD_Click(object sender, EventArgs e)
        {
            if (formhoadon == null || formhoadon.IsDisposed)
            {
                CloseOtherForms(formhoadon);
                formhoadon = new HoaDon();
                //formDICHVU.FormClosed += frmQuanLyDichVu_FormClosed;
                formhoadon.MdiParent = this;
                formhoadon.Dock = DockStyle.Fill;
                formhoadon.ControlBox = false;
                formhoadon.FormBorderStyle = FormBorderStyle.None;
                formhoadon.Show();
            }
            else
            {
                formhoadon.Activate();
            }
        }
        DoiMatKhau formdoimk;
        private void button22_Click(object sender, EventArgs e)
        {
            formdoimk = new DoiMatKhau(tentaikhoan);
            formdoimk.ShowDialog();
        }
    }
}
