using BLL;
using BLLL;
using System;
using System.Windows.Forms;

namespace CNPM_ver3
{
    public partial class AddUser2Task : Form
    {
        UserBLL ul = new UserBLL();
        string cur_task_id;
        string cur_pj_id;
        TaskBLL task = new TaskBLL();
        ProjectBLL pj = new ProjectBLL();

        public AddUser2Task(string pj_id, string task_id)
        {
            cur_task_id = task_id;
            cur_pj_id = pj_id;
            InitializeComponent();
        }

        private void AddUser2Task_Load(object sender, EventArgs e)
        {
            showTableOutTask();
            showTableInTask();
        }

        public void showTableOutTask()
        {
            dataGridView_user.ReadOnly = true;
            dataGridView_user.DataSource = pj.GetUserOfProject(cur_pj_id);
        }

        private void dataGridView_user_Click(object sender, EventArgs e)
        {
            //string u_id = dataGridView_user.CurrentRow.Cells[0].Value.ToString();
            //string u_email = dataGridView_user.CurrentRow.Cells["USER_EMAIL"].Value.ToString();
            string u_id = dataGridView_user.CurrentRow.Cells["USER_ID"].Value.ToString();

            if (task.AddUserToTask(cur_task_id, u_id))
            {
                // Hide row
                int rowindex = dataGridView_user.CurrentRow.Index;
                CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dataGridView_user.DataSource];
                currencyManager1.SuspendBinding();
                dataGridView_user.Rows[rowindex].Visible = false;
                currencyManager1.ResumeBinding();
                MessageBox.Show("Add member to task successfully");


                // Update member in project table
                showTableInTask();
            }
            else
            {
                MessageBox.Show(Properties.Resources.add_mem_2_pj_fail);
            }
        }

        public void showTableInTask()
        {
            dataGridView_mInTask.ReadOnly = true;
            dataGridView_mInTask.DataSource = task.GetUserOfTask(cur_task_id);
        }
    }
}
