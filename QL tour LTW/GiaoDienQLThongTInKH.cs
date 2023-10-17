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
    public partial class GiaoDienQLThongTInKH : Form
    {
        public GiaoDienQLThongTInKH()
        {
            InitializeComponent();
        }
        public void openForm(Form form)
        {
            this.panelLoadFormKH.Controls.Clear();
            form.TopLevel = false;
            form.AutoScroll = true;
            form.FormBorderStyle = FormBorderStyle.None;           
            form.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
            this.panelLoadFormKH.Controls.Add(form);
            form.Show();
        }

        private void GiaoDienQLThongTInKH_Load(object sender, EventArgs e)
        {
            lblNgangCach.Visible = false;
            linklblThemKH.Visible = false;
            QLThongTInKH kh = new QLThongTInKH();
            kh.setMainForm(this);
            openForm(kh);
        }
        QLThongTInKH frmTHKH;
        private void linklblTHONGTINKH_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (frmTHKH == null)
            {
                QLThongTInKH kh = new QLThongTInKH();
                kh.setMainForm(this);
                openForm(kh);
                lblNgangCach.Visible = false;
                linklblThemKH.Visible = false;
            }
            else
            {
                frmTHKH.Activate();
                frmTHKH.setMainForm(this);
                lblNgangCach.Visible = false;
                linklblThemKH.Visible = false;
            }
        }
    }
}
