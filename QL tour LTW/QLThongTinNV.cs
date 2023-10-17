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
        ThemMoiKH form;
        private void frmQuanLyDichVu_FormClosed(object sender, FormClosedEventArgs e)
        {
            form = null;
           
           
        }
        private void button2_Click(object sender, EventArgs e)
        {

            if (formgiaodien == null || formgiaodien.IsDisposed)
            {
                // Đóng các form khác (nếu có)
                CloseOtherForms(formgiaodien);

                // Tạo và hiển thị form 1
                formgiaodien = new GiaoDienQLThongTInKH();
                formgiaodien.Show();
            }
            else
            {
                form.Activate();
            }
        }
        private void formQLTOUR_FormClosed(object sender, FormClosedEventArgs e)
        {
            formgiaodien = null;
        }
        GiaoDienQLThongTInKH formgiaodien;
        private void button1_Click(object sender, EventArgs e)
        {

            if (form == null || form.IsDisposed)
            {
                // Đóng các form khác (nếu có)
                CloseOtherForms(form);

                // Tạo và hiển thị form 1
                form = new ThemMoiKH();
                form.Show();
            }
            else
            {
                form.Activate();
            }
        }
        private void CloseOtherForms(Form currentForm)
        {
            if (form != currentForm && form != null && !form.IsDisposed)
            {
                form.Close();
                form.Dispose();
            }

            if (formgiaodien != currentForm && formgiaodien != null && !formgiaodien.IsDisposed)
            {
                formgiaodien.Close();
                formgiaodien.Dispose();
            }

            
        }
    }
}
