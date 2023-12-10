using BLL;
using BLLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CNPM_ver3
{
    public partial class AssignTaskForm : Form
    {
        UserBLL ul = new UserBLL();
        TaskBLL task_access = new TaskBLL();
        int number_assignee = 1;
        List<String> assignee_PKs = new List<String>();
        List<string> files = new List<string>();
        List<string> subTasks = new List<string>();

        String curIdPj;
        String curNamePj;
        String curManagePjPK;
        public AssignTaskForm(String pjID, String namePj, String mnPjPK)
        {
            curIdPj = pjID;
            curNamePj = namePj;
            curManagePjPK = mnPjPK;
            InitializeComponent();
        }

        private void getSubtasksList()
        {
            foreach (DataGridViewRow row in dataGridView_subtasks.Rows)
            {
                // Check if the current row is not the header row
                if (!row.IsNewRow)
                {
                    // Access the cell value of a specific column using the column index or column name
                    string cellValue = row.Cells["Subtask"].Value.ToString();
                    subTasks.Add(cellValue);

                }
            }
        }

        private void AssignTaskForm_Load(object sender, EventArgs e)
        {
            // Initialize datagridview column
            dataGridView_assignees.Columns.Add("No.", "No.");
            dataGridView_assignees.Columns.Add("AssigneeID", "Assigness ID");
            dataGridView_assignees.Columns.Add("Assignee", "Assignee");
            dataGridView_subtasks.Columns.Add("Subtask", "Subtask");

            // Project name fill
            textBox_pjName.Text = curNamePj;

            // Load all staffs from database
            DataTable staffs = ul.GetUserByLevel(0);
            foreach (DataRow staff in staffs.Rows)
            {
                comboBox_assignees.Items.Add(staff["USER_ID"] + " " + staff["USER_NAME"]);
            }
        }

        private void comboBox_assignees_SelectedIndexChanged(object sender, EventArgs e)
        {
            string assignInfo = comboBox_assignees.Text;
            string assigneePK = assignInfo.Substring(0, assignInfo.IndexOf(' '));
            string assigneeName = assignInfo.Substring(assignInfo.IndexOf(' ') + 1);
            MessageBox.Show(assigneePK +  " " + assigneePK.Length);
            assignee_PKs.Add(assigneePK);
            dataGridView_assignees.Rows.Add(number_assignee++, assigneePK, assigneeName);
            comboBox_assignees.Items.Remove(comboBox_assignees.Text);
        }

        private void dataGridView_assignees_Click(object sender, EventArgs e)
        {
            String assigneePK = dataGridView_assignees.CurrentRow.Cells["AssigneeID"].Value.ToString();
            String assigneeName = dataGridView_assignees.CurrentRow.Cells["Assignee"].Value.ToString();
            comboBox_assignees.Items.Add(assigneePK + " " + assigneeName);
            assignee_PKs.Remove(assigneePK);
            dataGridView_assignees.Rows.RemoveAt(dataGridView_assignees.CurrentRow.Index);
            number_assignee--;
        }

        private void button_assign_Click(object sender, EventArgs e)
        {
            getSubtasksList();
            String taskName = textBox_taskName.Text;
            String taskDesc = textBox_taskDesc.Text;
            DateTime start = dateTimePicker_start.Value;
            DateTime end = dateTimePicker_end.Value;
            int isHL = 0;
            String taskState = "New task";
            String pjID = curIdPj;

            if (task_access.AssignTask(taskName, taskDesc, start, end, isHL, taskState, pjID, curManagePjPK, assignee_PKs, files, subTasks))
            {
                MessageBox.Show("Add task successfully", Properties.Resources.title_success, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Fail to add task", Properties.Resources.title_fail, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button_file_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in openFileDialog.FileNames)
                {
                    string file_name = System.IO.Path.GetFileName(file);
                    comboBox_files.Items.Add(file_name);
                    files.Add(file);
                }
                MessageBox.Show("Uploaded " + files.Count + " successfully");
            }
        }

        private void button_clearFiles_Click(object sender, EventArgs e)
        {
            if (files.Count > 0)
            {
                files.RemoveAt(files.Count - 1);
                comboBox_files.Items.RemoveAt(comboBox_files.Items.Count - 1);
            }
        }
    }
}
