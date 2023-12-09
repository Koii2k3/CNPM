using BLL;
using BLLL;
using DTOO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNPM_ver3
{
    public partial class RequestForm : Form
    {
        RequestBLL reqBll = new RequestBLL();
        List<string> files = new List<string>();


        public RequestForm()
        {
            InitializeComponent();
            //checkState();
            
        }


        /*void checkState()
        {
            UserBLL myUL = new UserBLL();

            string s_id = Users.PK;
            //string s_id = "05907";
            DataRow myRow = myUL.checkRequest(s_id);
            if(myRow != null)
            {
                tReq.Text = myRow["R_DES"].ToString();
                bt_Request.Text = "CHANGE";
            } else
            {
                tReq.Text = "";
                bt_Request.Text = "REQUEST";
            }

        }*/
        

        private void bt_delete_Click(object sender, EventArgs e)
        {
            textBox_subject.Clear();
            textBox_toUser.Clear();
            textBox_content.Clear();
            files.Clear();
            comboBox_files.Items.Clear();
        }

        private void bt_Request_Click(object sender, EventArgs e)
        {
            string subject = textBox_subject.Text;
            string pk_receiver = textBox_toUser.Text;
            string content = textBox_content.Text;
            string pk_sender = Users.PK;
            if (reqBll.AddRequest(subject, content, pk_sender, pk_receiver, files))
            {
                MessageBox.Show("Request successfully", "Add Request", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Fail to request", "Add Request", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void RequestForm_Load(object sender, EventArgs e)
        {
            showTable();
        }

        public void showTable()
        {
            dataGridView_myReq.ReadOnly = true;
            dataGridView_myReq.DataSource = reqBll.GetMyRequest(Users.PK);
        }

        private void button_clearFiles_Click(object sender, EventArgs e)
        {
            files.Clear();
            comboBox_files.Items.Clear();
        }

        private void dataGridView_myReq_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox_toUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_files_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
