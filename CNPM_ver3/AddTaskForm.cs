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
    public partial class AddTaskForm : Form
    {
        UserBLL ul = new UserBLL();
        string cur_pj_id;
        TaskBLL task = new TaskBLL();
        public AddTaskForm(string pj_id)
        {
            cur_pj_id = pj_id;
            InitializeComponent();
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            string name = textBox_name.Text;
            string desc = textBox_desc.Text;

            DateTime start = dateTimePicker_start.Value;
            DateTime end = dateTimePicker_end.Value;
            DateTime exp = dateTimePicker_exp.Value;

            if (task.InsertTask(name, desc, exp, start, end, "0", "New task", cur_pj_id))
            {
                MessageBox.Show("Add task successfully", Properties.Resources.title_success, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Fail to add task", Properties.Resources.title_fail, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AddTaskForm_Load(object sender, EventArgs e)
        {

        }
    }
}
