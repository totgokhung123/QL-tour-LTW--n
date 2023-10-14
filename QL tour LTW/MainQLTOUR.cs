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
    public partial class MainQLTOUR : Form
    {
        
        public MainQLTOUR()
        {
            InitializeComponent();
        }
        public void OPENFORM(Form f)
        {
            this.panelLoadFormTOUR.Controls.Clear();
            f.TopLevel = false;
            f.AutoScroll = true;
            f.FormBorderStyle = FormBorderStyle.None;
           // f.Dock = DockStyle.Fill;
            f.Anchor = AnchorStyles.Top| AnchorStyles.Left | AnchorStyles.Bottom ;
            //| AnchorStyles.Right
            this.panelLoadFormTOUR.Controls.Add(f);
            f.Show();

        }
        private void MainQLTOUR_Load(object sender, EventArgs e)
        {
            lbCACH.Visible = false;
            linklbThemTOUR.Visible = false;
            THONGTINTOUR tour = new THONGTINTOUR();
            tour.SetMainForm(this);
            OPENFORM(tour);
        }
        THONGTINTOUR formthongtintour;
        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (formthongtintour == null)
            {
                THONGTINTOUR tour = new THONGTINTOUR();
                tour.SetMainForm(this);
                OPENFORM(tour);
                lbCACH.Visible = false;
                linklbThemTOUR.Visible = false;
            }
            else
            {
                formthongtintour.Activate();
                formthongtintour.SetMainForm(this);
                lbCACH.Visible = false;
                linklbThemTOUR.Visible = false;
            }
        }
        ThemTour formthemtour;
        private void linklbThemTOUR_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
                lbCACH.Visible = true;
                linklbThemTOUR.Visible = true;
        }

        private void panelLoadFormTOUR_ControlAdded(object sender, ControlEventArgs e)
        {
            
        }
    }
}
