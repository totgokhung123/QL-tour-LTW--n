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
    public partial class GiaoDienDangNhap : Form
    {
        public GiaoDienDangNhap()
        {
            InitializeComponent();
        }

        
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
