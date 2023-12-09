using BLLL;
using DTOO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNPM_ver3
{
    public partial class AddProjectForm : Form
    {
        ProjectBLL pj = new ProjectBLL();
        public AddProjectForm()
        {
            InitializeComponent();
        }


        private void button_addProject_Click(object sender, EventArgs e)
        {
            string name = textBox_name.Text;
            string ver = "1";
            string desc = textBox_desc.Text;
            string isPublic = comboBox_public.Text;
            string pk = Users.PK;

            if (checkBox_dl.Checked)
            {
                DateTime start = dateTimePicker_start.Value;
                DateTime end = dateTimePicker_end.Value;
                DateTime exp = dateTimePicker_exp.Value;
                if (ValidateChildren(ValidationConstraints.Enabled) && pj.ValidateDeadline(start, end, exp))
                {

                    if (pj.InsertPJ(name, desc, exp, start, end, ver, isPublic, pk))
                    {
                        MessageBox.Show(Properties.Resources.add_pj_success, Properties.Resources.title_success, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(Properties.Resources.add_pj_fail, Properties.Resources.title_fail, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Validate failure", Properties.Resources.title_fail, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (ValidateChildren(ValidationConstraints.Enabled))
                {
                    if (pj.InsertPJ(name, desc, null, null, null, ver, isPublic, pk))
                    {
                        MessageBox.Show(Properties.Resources.add_pj_success, Properties.Resources.title_success, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(Properties.Resources.add_pj_fail, Properties.Resources.title_fail, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Validate failure", Properties.Resources.title_fail, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void textBox_name_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(textBox_name.Text))
            {
                e.Cancel = true;
                textBox_name.Focus();
                errorProvider1.SetError(textBox_name, "Please enter project name");
            }
        }

        private void checkBox_dl_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox_dl.Checked)
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

        private void AddProjectForm_Load(object sender, EventArgs e)
        {
            dateTimePicker_start.CustomFormat = " ";
            dateTimePicker_start.Format = DateTimePickerFormat.Custom;

            dateTimePicker_end.CustomFormat = " ";
            dateTimePicker_end.Format = DateTimePickerFormat.Custom;

            dateTimePicker_exp.CustomFormat = " ";
            dateTimePicker_exp.Format = DateTimePickerFormat.Custom;
        }
    }
}
