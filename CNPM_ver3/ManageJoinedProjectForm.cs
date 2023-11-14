using BLL;
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
    public partial class ManageJoinedProjectForm : Form
    {
        UserBLL ul = new UserBLL();
        ProjectBLL pj = new ProjectBLL();
        TaskBLL task = new TaskBLL();
        string curr_pj_id = null;

        public ManageJoinedProjectForm()
        {
            Users.PK = "00682";
            InitializeComponent();
        }

        private void ManageJoinedProjectForm_Load(object sender, EventArgs e)
        {

            if (Users.LV_NAME == "Nhân viên")
            {
                panel_head.BackColor = Color.FromArgb(14, 33, 160);
            }

            showPj();
            showAllTask();
        }
        public void showPj()
        {
            dataGridView_myJProject.ReadOnly = true;
            dataGridView_myJProject.DataSource = ul.GetAllProjectOfUser(Users.PK);
        }

        public void showAllTask()
        {
            dataGridView_task.ReadOnly = true;
            dataGridView_task.DataSource = task.GetAllTaskOfUser(Users.PK);
        }

        public void showTaskPj()
        {
            dataGridView_task.ReadOnly = true;
            dataGridView_task.DataSource = task.GetJobInProjectOfUser(Users.PK, curr_pj_id);
        }

        private void button_search_Click(object sender, EventArgs e)
        {   
            if (!string.IsNullOrEmpty(textBox_search.Text))
            {
                dataGridView_myJProject.DataSource = pj.SearchProjectU(Users.PK, textBox_search.Text);
            }
            else
            {
                MessageBox.Show("Search without any hint error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_myJProject_Click(object sender, EventArgs e)
        {
            dataGridView_task.ReadOnly = true;
            curr_pj_id = dataGridView_myJProject.CurrentRow.Cells["PJ_ID"].Value.ToString();
            showTaskPj();
        }

        private void button_allTask_Click(object sender, EventArgs e)
        {
            showAllTask();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView_myJProject_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
