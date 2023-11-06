using BLLL;
using DTOO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace CNPM_ver3
{
    public partial class ManageRequestForm : Form
    {
        RequestBLL req = new RequestBLL();
        public ManageRequestForm()
        {
            InitializeComponent();
        }

        private bool VerifySelectedReq()
        {
            if (string.IsNullOrEmpty(textBox_sender.Text) || string.IsNullOrEmpty(textBox_subject.Text))
            {
                MessageBox.Show("Please, select a specific request", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void ManageRequestForm_Load(object sender, EventArgs e)
        {
            showTable();
        }

        public void showTable()
        {
            dataGridView_req.ReadOnly = true;
            dataGridView_req.DataSource = req.GetRequestReceiver(Users.PK);
        }

        private void button_accept_Click(object sender, EventArgs e)
        {
            if (VerifySelectedReq())
            {

                if (textBox_status.Text.Equals("Chưa xử lí"))
                {
                    req.UpdateRequestStatus(textBox_sender.Text, Users.PK, "Đã xử lí");
                    MessageBox.Show("Accept request successfully");
                }
                else
                {
                    MessageBox.Show("Request has already processed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void button_reject_Click(object sender, EventArgs e)
        {
            if (VerifySelectedReq())
            {
                if (textBox_status.Text.Equals("Chưa xử lí"))
                {
                    req.UpdateRequestStatus(textBox_sender.Text, Users.PK, "Từ chối xử lí");
                    MessageBox.Show("Reject request successfully");
                }
                else
                {
                    MessageBox.Show("Request has already processed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void dataGridView_req_Click(object sender, EventArgs e)
        {
            string req_id = dataGridView_req.CurrentRow.Cells["R_ID"].Value.ToString();
            textBox_sender.Text = dataGridView_req.CurrentRow.Cells["SENDER_ID"].Value.ToString();
            textBox_subject.Text = dataGridView_req.CurrentRow.Cells["R_DES"].Value.ToString();
            textBox_content.Text = dataGridView_req.CurrentRow.Cells["R_CONTENT"].Value.ToString();
            textBox_status.Text = dataGridView_req.CurrentRow.Cells["R_STATUS"].Value.ToString();
            dateTimePicker_sentDay.Value = (DateTime)dataGridView_req.CurrentRow.Cells["R_DATE"].Value;

            dataGridView_files.ReadOnly = true;
            dataGridView_files.DataSource = req.GetFileFromRequest(req_id);
            dataGridView_files.Columns["F_FILE"].Visible = false;
            dataGridView_files.Columns["F_ID"].Visible = false;
            dataGridView_files.Columns["R_ID"].Visible = false;

        }

        private void dataGridView_files_Click(object sender, EventArgs e)
        {
            if (VerifySelectedReq())
            {
                string filename = dataGridView_files.CurrentRow.Cells["F_NAME"].Value.ToString();
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Text documents (.pdf)|*.pdf|JPEG Image (.jpeg)|*.jpeg|Png Image (.png)|*.png";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        DialogResult dialog = MessageBox.Show("Are you sure you want to download this file", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        // Default filename
                        //sfd.FileName = filename;


                        if (dialog == DialogResult.Yes)
                        {
                            filename = sfd.FileName;
                            try
                            {
                                byte[] fileData = (byte[])dataGridView_files.CurrentRow.Cells["F_FILE"].Value;
                                using (FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.ReadWrite))
                                {
                                    using (BinaryWriter bw = new BinaryWriter(fs))
                                    {
                                        bw.Write(fileData);
                                        bw.Close();
                                    }
                                }
                                MessageBox.Show("Saved file in " + filename);
                            }
                            catch
                            {
                                MessageBox.Show("File is not found ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }
    }
}
