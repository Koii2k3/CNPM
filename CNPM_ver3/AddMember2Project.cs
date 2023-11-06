using BLL;
using BLLL;
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
    public partial class AddMember2Project : Form
    {
        UserBLL ul = new UserBLL();
        string cur_pj_id;
        ProjectBLL pj = new ProjectBLL();
        public AddMember2Project(string pj_id)
        {
            cur_pj_id = pj_id;
            InitializeComponent();
        }

        private void AddMember2Project_Load(object sender, EventArgs e)
        {
            showTableOutPj();
            showTableInPj();
        }

        public void showTableOutPj()
        {
            dataGridView_user.ReadOnly = true;
            dataGridView_user.DataSource = ul.GetUserByLevel(0);
            dataGridView_user.RowTemplate.Height = 80;

            // Show image
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)dataGridView_user.Columns["USER_IMAGE"];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;

            /*DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Add member";
            btn.Name = "button_add";
            btn.Text = "Add";
            btn.UseColumnTextForButtonValue = true;
            btn.DefaultCellStyle.BackColor = Color.FromArgb(187, 37, 37);
            dataGridView_user.Columns.Add(btn);*/
        }

        public void showTableInPj()
        {
            dataGridView_mInProject.ReadOnly = true;
            dataGridView_mInProject.DataSource = pj.GetUserOfProject(cur_pj_id);
            dataGridView_mInProject.RowTemplate.Height = 80;

            // Show image
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)dataGridView_user.Columns["USER_IMAGE"];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }

        private void dataGridView_user_Click(object sender, EventArgs e)
        {
            //string u_id = dataGridView_user.CurrentRow.Cells[0].Value.ToString();
            string u_email = dataGridView_user.CurrentRow.Cells["USER_EMAIL"].Value.ToString();
            string u_id = dataGridView_user.CurrentRow.Cells["USER_ID"].Value.ToString();
            if (pj.AddMember2Project(u_id, u_email, cur_pj_id))
            {
                MessageBox.Show(Properties.Resources.add_mem_2_pj_success);
                // Hide row
                int rowindex = dataGridView_user.CurrentRow.Index;
                CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dataGridView_user.DataSource];
                currencyManager1.SuspendBinding();
                dataGridView_user.Rows[rowindex].Visible = false;
                currencyManager1.ResumeBinding();

                // Update member in project table
                showTableInPj();
            }
            else
            {
                MessageBox.Show(Properties.Resources.add_mem_2_pj_fail);
            }
        }

        private void dataGridView_mInProject_Click(object sender, EventArgs e)
        {
            //string u_id = dataGridView_user.CurrentRow.Cells[0].Value.ToString();
            string u_pk = dataGridView_mInProject.CurrentRow.Cells["USER_ID"].Value.ToString();
            if (DialogResult.Yes == MessageBox.Show("Do You Want Delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                if (pj.DelMemberFromProject(u_pk, cur_pj_id))
                {
                    MessageBox.Show("Delete member from project successfully");
                    // Hide row
                    dataGridView_mInProject.Rows.RemoveAt(dataGridView_mInProject.CurrentRow.Index);
                }
                else
                {
                    MessageBox.Show("Fail to delete member from project successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
