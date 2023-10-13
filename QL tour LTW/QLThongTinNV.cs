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
    public partial class QLThongTinNV : Form
    {
        public QLThongTinNV()
        {
            InitializeComponent();
        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void QLThongTinNV_Load(object sender, EventArgs e)
        {
            QLTOURDBContext context = new QLTOURDBContext();
            List<KHACHHANG> kHACHHANGs = context.KHACHHANGs.ToList();
            BindGrid(kHACHHANGs);
        }
        private void BindGrid(List<KHACHHANG> khachhang)
        {
            //hien thi thong tin ben csdl len datagridview
            dgvtest.Rows.Clear();
            foreach (var item in khachhang)
            {
                int index = dgvtest.Rows.Add();
                dgvtest.Rows[index].Cells[0].Value = item.MAKH;
                dgvtest.Rows[index].Cells[1].Value = item.HO;
                dgvtest.Rows[index].Cells[2].Value = item.TEN;
                dgvtest.Rows[index].Cells[3].Value = item.SDT;
                dgvtest.Rows[index].Cells[4].Value = item.CCCD;
                dgvtest.Rows[index].Cells[5].Value = item.EMAIL;
            }
        }
    }
}
