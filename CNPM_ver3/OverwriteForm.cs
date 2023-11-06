using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNPM_ver3
{
    public class OverwriteForm
    {
        public Form activeform = null;
        public void openChildForm(Form childForm, ref Panel panel_main)
        {
            if (activeform != null)
                activeform.Close();
            activeform = childForm;

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panel_main.Controls.Add(childForm);

            panel_main.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        public void HomeForm(ref Panel panel_main, ref Panel panel_cover)
        {
            if (activeform != null)
                activeform.Close();
            panel_main.Controls.Add(panel_cover);
        }
    }
}
