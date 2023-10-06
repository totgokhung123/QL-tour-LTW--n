﻿using System;
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
        public Form1()
        {
            InitializeComponent();
           // this.WindowState = FormWindowState.Maximized;
        }

        bool time = true;
        private void menutimer1_Tick(object sender, EventArgs e)
        {
            if (time)
            {
                panelMenu.Width -= 20;
                if (panelMenu.Width == panelMenu.MinimumSize.Width)
                {
                    time = false;
                    menutimer1.Stop();
                }
            }
            else
            {
                panelMenu.Width += 20;
                if (panelMenu.Width == panelMenu.MaximumSize.Width)
                {
                    time = true;
                    menutimer1.Stop();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            menutimer1.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            QLNVtimer.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

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
                if (panelQLNV.Height >= 143)
                {
                    QLNVtimer.Stop();
                    QLNVtime = true;
                }
            }
            else
            {
                panelQLNV.Height -= 10;
                if (panelQLNV.Height <= 40)
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
                if (flpanelKH.Height >= 143)
                {
                    QLKHtimer.Stop();
                    QLKHtime = true;
                }
            }
            else
            {
                flpanelKH.Height -= 10;
                if (flpanelKH.Height <= 40)
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
                if (flpanelQLTOUR.Height >= 143)
                {
                    QLTOURtimer.Stop();
                    QLTOURtime = true;
                }
            }
            else
            {
                flpanelQLTOUR.Height -= 10;
                if (flpanelQLTOUR.Height <= 40)
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
                if (flpanelHOADON.Height >= 143)
                {
                    QLHOADONtimer.Stop();
                    QLHOADONtime = true;
                }
            }
            else
            {
                flpanelHOADON.Height -= 10;
                if (flpanelHOADON.Height <= 40)
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
                if (flpanelQLDICHVU.Height >= 143)
                {
                    QLDICHVUtimer.Stop();
                    QLDICHVUtime = true;
                }
            }
            else
            {
                flpanelQLDICHVU.Height -= 10;
                if (flpanelQLDICHVU.Height <= 40)
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
                if (flpanelQLHETHONG.Height >= 170)
                {
                    QLHETHONGtimer.Stop();
                    QLHETHONGtime = true;
                }
            }
            else
            {
                flpanelQLHETHONG.Height -= 10;
                if (flpanelQLHETHONG.Height <= 40)
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
    }
}
