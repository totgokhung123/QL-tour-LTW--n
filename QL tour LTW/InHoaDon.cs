using Microsoft.Reporting.WinForms;
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
    public partial class InHoaDon : Form
    {
        static QLTOURDBContext context = new QLTOURDBContext();
        private string sohd;
        public InHoaDon(string sohd)
        {
            InitializeComponent();
            this.sohd = sohd;
        }

        private void InHoaDon_Load(object sender, EventArgs e)
        {

            List<HOADON> listHoaDon = context.HOADONs.ToList();
            var hoadon = context.HOADONs.Where(s => s.SOHD == sohd).ToList();
            List<TOUR> listTour = context.TOURs.ToList();
            List<InHoaDonReportReal> listRPInHD = new List<InHoaDonReportReal>();

            foreach (HOADON hd in hoadon)
            {
                InHoaDonReportReal temp = new InHoaDonReportReal();
                temp.soHD = hd.SOHD;
                temp.ngayLapHD = hd.NGAYLAP;
                temp.TenNV = hd.NHANVIEN.HOTEN;
                temp.TenKH = hd.KHACHHANG.HO + " " + hd.KHACHHANG.TEN;
                temp.SdtKH = hd.KHACHHANG.SDT;
                temp.TenTour = hd.TOUR.TENTOUR;
                temp.DiemDi = hd.TOUR.DIEMDI.TENDDI;
                temp.DiemDen = hd.TOUR.DIEMDEN.TENDDEN;
                if (hd.TOUR.MAPT == null)
                {
                    temp.PT = "Không có";
                }

                else
                {
                    temp.PT = hd.TOUR.PHUONGTIEN.TENPT;
                }
                //temp.KS = tour.MAKS;
                if (hd.TOUR.MAKS == null)
                {
                    temp.KS = "Không có";
                }

                else
                {
                    temp.KS = hd.TOUR.KHACHSAN.TENKS;
                }
                temp.NgayDi = hd.TOUR.NGAYDI;
                temp.NgayKetThuc = hd.TOUR.NGAYKETTHUC;
                temp.ThanhTien = hd.TOUR.GIATOUR;
                listRPInHD.Add(temp);
            }

            rpvInHD.LocalReport.ReportPath = "ReportInHoaDon.rdlc";
            var source = new ReportDataSource("DataSetInHD", listRPInHD);
            rpvInHD.LocalReport.DataSources.Clear();
            rpvInHD.LocalReport.DataSources.Add(source);
            this.rpvInHD.RefreshReport();
        }
    }
}
