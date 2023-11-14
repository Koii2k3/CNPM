using BLLL;
using DTOO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNPM_ver3
{
    public partial class CEOProjectForm : Form
    {
        ProjectBLL pj = new ProjectBLL();
        TaskBLL task = new TaskBLL();
        OverwriteForm ovf = new OverwriteForm();
        string curr_pj_id = null;

        public CEOProjectForm()
        {
            InitializeComponent();
        }

        private void CEOProjectForm_Load(object sender, EventArgs e)
        {
            showPj();
        }

        public void showPj()
        {
            dataGridView_project.ReadOnly = true;
            dataGridView_project.DataSource = pj.GetAllProject();
        }
    }
}
