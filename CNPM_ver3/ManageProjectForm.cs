using BLL;
using BLLL;
using DTOO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CNPM_ver3
{
    public partial class ManageProjectForm : Form
    {
        ProjectBLL pj = new ProjectBLL();
        TaskBLL task = new TaskBLL();
        OverwriteForm ovf = new OverwriteForm();
        string curr_pj_id = null;

        public ManageProjectForm()
        {
            InitializeComponent();
            if (Users.SPU == true)
            {
                button_update.Visible = false;
                button_del.Visible = false;
                button_addMember.Visible = false;
                button_addGroup.Visible = false;
                button_search.Visible = false;
                textBox_search.Visible = false;
                toolStripLabel_addProject.Visible = false;
                toolStripLabel_addProject.Enabled = false;
                ovf.HomeForm(ref panel_main, ref panel_cover);
            }
            else
            {
                button_update.Visible = true;
                button_del.Visible = true;
                button_addMember.Visible = true;
                button_addGroup.Visible = true;
                button_search.Visible = true;
                textBox_search.Visible = true;
                toolStripLabel_addProject.Visible = true;
                toolStripLabel_addProject.Enabled = true;
            }
        }

        private void ManageProjectForm_Load(object sender, EventArgs e)
        {
            showPj();
        }

        public void showPj()
        {
            dataGridView_project.ReadOnly = true;

            if (Users.SPU == true)
            {
                dataGridView_project.DataSource = pj.getProjectOfUser(Users.CSU);
                Users.SPU = false;
            }
            else
            {
                dataGridView_project.DataSource = pj.GetProjectInfoAllOfMan(Users.PK);
            }
        }

        public void showTask()
        {
            dataGridView_task.ReadOnly = true;
            dataGridView_task.DataSource = task.GetTaskOfProject(curr_pj_id);
        }

        private void toolStripLabel_addProject_Click(object sender, EventArgs e)
        {
            ovf.openChildForm(new AddProjectForm(), ref panel_main);
        }

        private void toolStripLabel_back_Click(object sender, EventArgs e)
        {
            ovf.HomeForm(ref panel_main, ref panel_cover);
        }

        private void DataGridView_Project_Click(object sender, EventArgs e)
        {
            curr_pj_id = dataGridView_project.CurrentRow.Cells["PJ_ID"].Value.ToString();
            ovf.openChildForm(new StatisticTaskPerUserInPJ(curr_pj_id), ref panel_main);

            /*
            if (dataGridView_project.CurrentRow != null)
            {
                curr_pj_id = dataGridView_project.CurrentRow.Cells["PJ_ID"].Value.ToString();

                textBox_name.Text = dataGridView_project.CurrentRow.Cells["PJ_NAME"].Value.ToString();
                textBox_desc.Text = dataGridView_project.CurrentRow.Cells["PJ_DES"].Value.ToString();

                if (dataGridView_project.CurrentRow.Cells["PJ_PUBLIC"].Value.ToString() == "1")
                {
                    comboBox_public.Text = "Public";
                }
                else
                {
                    comboBox_public.Text = "Private";
                }

                try
                {
                    checkBox_deadline.Checked = true;

                    dateTimePicker_exp.Value = (DateTime)dataGridView_project.CurrentRow.Cells["PJ_EXPECT_FIN"].Value;
                    dateTimePicker_start.Value = (DateTime)dataGridView_project.CurrentRow.Cells["PJ_START"].Value;
                    dateTimePicker_end.Value = (DateTime)dataGridView_project.CurrentRow.Cells["PJ_FINISH"].Value;
                }
                catch
                {
                    checkBox_deadline.Checked = false;
                }

                textBox_ver.Text = dataGridView_project.CurrentRow.Cells["PJ_VERSION"].Value.ToString();
                showTask();
            }*/
        }

        private void button_addMember_Click(object sender, EventArgs e)
        {
            if (curr_pj_id != null)
            {
                ovf.openChildForm(new AddMember2Project(curr_pj_id), ref panel_main);
            }
            else
            {
                MessageBox.Show("Choose a project", "Project", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_del_Click(object sender, EventArgs e)
        {
        }


        private void button_update_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            errorProvider2.Clear();
            errorProvider3.Clear();

            if (curr_pj_id != null)
            {
                string pj_name = textBox_name.Text;
                string desc = textBox_desc.Text;
                string isPublic = comboBox_public.Text;
                string ver = textBox_ver.Text;
                DateTime? exp = null;
                DateTime? start = null;
                DateTime? end = null;

                // Validate date
                if (dateTimePicker_start.Format==DateTimePickerFormat.Long)
                {
                    exp = dateTimePicker_exp.Value;
                    start = dateTimePicker_start.Value;
                    end = dateTimePicker_end.Value;
                }

                if (exp!=null && start!=null && end!=null && !pj.ValidateDeadline((DateTime)start, (DateTime)end, (DateTime)exp))
                {
                    errorProvider1.SetError(dateTimePicker_start, "Invalid deadline");
                    errorProvider2.SetError(dateTimePicker_exp, "Invalid deadline");
                    errorProvider3.SetError(dateTimePicker_end, "Invalid deadline");
                    return;
                }
                else
                {
                    if (pj.UpdateProject(curr_pj_id, pj_name, desc, exp, start, end, ver, isPublic, Users.PK))
                    {
                        MessageBox.Show("Update project information successfully");

                        textBox_name.Clear();
                        textBox_desc.Clear();
                        comboBox_public.Text = string.Empty;
                        textBox_ver.Clear();
                        curr_pj_id = null;

                        showPj();
                    }
                    else
                    {
                        MessageBox.Show("Fail to update project information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            else
            {
                MessageBox.Show("Choose a project", "Project", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void button_search_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox_search.Text))
            {
                dataGridView_project.DataSource = pj.SearchProject(textBox_search.Text);
            }
            else
            {
                MessageBox.Show("Search without any hint error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dateTimePicker_start_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker_start.Format = DateTimePickerFormat.Long;
        }

        private void dateTimePicker_end_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker_end.Format = DateTimePickerFormat.Long;
        }

        private void dateTimePicker_exp_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker_exp.Format = DateTimePickerFormat.Long;
        }

        private void button_addTask_Click(object sender, EventArgs e)
        {
            if (curr_pj_id != null)
            {
                ovf.openChildForm(new AddTaskForm(curr_pj_id), ref panel_main);
            }
            else
            {
                MessageBox.Show("Choose a project", "Project", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button_addTask_Click_1(object sender, EventArgs e)
        {
            if (curr_pj_id != null)
            {
                ovf.openChildForm(new AddTaskForm(curr_pj_id), ref panel_main);
            }
            else
            {
                MessageBox.Show("Choose a project", "Project", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_task_Click(object sender, EventArgs e)
        {
            string task_id = dataGridView_task.CurrentRow.Cells["J_ID"].Value.ToString();
            ovf.openChildForm(new AddUser2Task(curr_pj_id, task_id), ref panel_main);
        }

        private void checkBox_deadline_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox_deadline.Checked)
            {
                dateTimePicker_start.CustomFormat = " ";
                dateTimePicker_start.Format = DateTimePickerFormat.Custom;

                dateTimePicker_end.CustomFormat = " ";
                dateTimePicker_end.Format = DateTimePickerFormat.Custom;

                dateTimePicker_exp.CustomFormat = " ";
                dateTimePicker_exp.Format = DateTimePickerFormat.Custom;
            }
            else
            {
                dateTimePicker_start.Format = DateTimePickerFormat.Long;
                dateTimePicker_end.Format = DateTimePickerFormat.Long;
                dateTimePicker_exp.Format = DateTimePickerFormat.Long;
            }
        }


    }
}
