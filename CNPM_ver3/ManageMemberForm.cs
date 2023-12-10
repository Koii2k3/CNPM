using BLL;
using BLLL;
using DTOO;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CNPM_ver3
{
    public partial class ManageMemberForm : Form
    {

        UserBLL ul = new UserBLL();
        OverwriteForm ovf = new OverwriteForm();
        string curr_pk = "";
        int flag = 0;

        public ManageMemberForm()
        {
            InitializeComponent();
            btDisable.Text = "Disable";
            button_update.Visible = true;
            Users.SPU = false;
        }

        private void ManageMemberForm_Load(object sender, EventArgs e)
        {
            loadTable();
        }

        public void loadTable()
        {
            TypeBLL tl = new TypeBLL();
            string[] types = tl.getUserType();
            foreach (string t in types)
            {
                comboBox_type.Items.Add(t);
            }

            LevelBLL lv = new LevelBLL();
            string[] levels = lv.GetUserLevel();
            foreach (string t in levels)
            {
                comboBox_lv.Items.Add(t);
            }

            DepartmentBLL dp = new DepartmentBLL();
            string[] dps = dp.GetUserDP();
            foreach (string t in dps)
            {
                comboBox_dp.Items.Add(t);
            }
            showTable();
        }

        public void showTable()
        {
            dataGridView_user.ReadOnly = true;
            dataGridView_user.DataSource = ul.getUserInfoAll();
            dataGridView_user.RowTemplate.Height = 80;

            // Show image
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)dataGridView_user.Columns["USER_IMAGE"];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }

        private void toolStripLabel_addUser_Click(object sender, EventArgs e)
        {
            ovf.openChildForm(new AddUserForm(), ref panel_main);
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            string u_name = textBox_username.Text;
            DateTime bd = dateTimePicker_birthdate.Value;
            string cccd = textBox_cccd.Text;
            string addr = textBox_addr.Text;
            string gd = comboBox_gender.Text;
            string email = textBox_email.Text;
            string vt_name = comboBox_type.Text;
            string u_pass = textBox_pass.Text;
            string lv_name = comboBox_lv.Text;
            string dp_name = comboBox_dp.Text;
            string u_phone = textBox_phone.Text;

            MemoryStream ms = new MemoryStream();
            pictureBox_user.Image.Save(ms, pictureBox_user.Image.RawFormat);
            byte[] img = ms.ToArray();
            if (ul.UpdateUserInfo(curr_pk, u_name, bd, cccd, addr, gd, email, vt_name, u_pass, lv_name, dp_name, u_phone, img))
            {
                MessageBox.Show("Update user information successfully");
                loadTable();
            }
            else
            {
                MessageBox.Show("Fail to update user information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_upload_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Select Photo(*.jpg;*.png;*.gif) | *.jpg;*.png;*.gif";
            if (ofd.ShowDialog() == DialogResult.OK)
                pictureBox_user.Image = Image.FromFile(ofd.FileName);
        }

        private void btDisable_Click(object sender, EventArgs e)
        {

            if (curr_pk.Equals("")) return;
            if (curr_pk.Equals(Users.PK))
            {
                MessageBox.Show("Cannot disable yourself", "Error Disable User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(flag == 0)
            {
                if (MessageBox.Show("Do you want to disable this user?", "Disable User", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int res = ul.disableUser(curr_pk, flag);

                    if (res == 1)
                    {

                        MessageBox.Show("This user has been disabled", "Sucessfully Disable User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        loadTable();

                    }
                }

                return;
            }

            if (flag == 1)
            {
                if (MessageBox.Show("Do you want to enable this user?", "Enable User", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int res = ul.disableUser(curr_pk, flag);

                    if (res == 1)
                    {

                        MessageBox.Show("This user has been enabled", "Sucessfully Enable User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        loadTableDis();

                    }
                }

                return;
            }


        }


        // function loadTableDisable 
        // copy from function loadTable above

        public void loadTableDis()
        {
            TypeBLL tl = new TypeBLL();
            string[] types = tl.getUserType();
            foreach (string t in types)
            {
                comboBox_type.Items.Add(t);
            }

            LevelBLL lv = new LevelBLL();
            string[] levels = lv.GetUserLevel();
            foreach (string t in levels)
            {
                comboBox_lv.Items.Add(t);
            }

            DepartmentBLL dp = new DepartmentBLL();
            string[] dps = dp.GetUserDP();
            foreach (string t in dps)
            {
                comboBox_dp.Items.Add(t);
            }
            showTableDis();
        }

        // function showTableDisable
        // copy from function showTable above

        public void showTableDis()
        {
            dataGridView_user.ReadOnly = true;
            dataGridView_user.DataSource = ul.getUserInfoDis();
            dataGridView_user.RowTemplate.Height = 80;

            try
            {
                // Show image
                DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                imageColumn = (DataGridViewImageColumn)dataGridView_user.Columns[7];
                imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            } catch { }
            
        }


        // function to switch between disable and enable list
        private void btDisableList_Click(object sender, EventArgs e)
        {
            if(flag == 0)
            {
                loadTableDis();
                flag = 1;
                btDisableList.Text = "Return management form";
                btDisable.Text = "Enable";
                button_update.Visible = false;
                return;
            }

            if(flag == 1)
            {
                loadTable();
                flag = 0;
                btDisableList.Text = "Disabled user list";
                btDisable.Text = "Disable";
                button_update.Visible = true;
                return;

            }
        }

        private void dataGridView_user_Click(object sender, EventArgs e)
        {
            curr_pk = dataGridView_user.CurrentRow.Cells["USER_ID"].Value.ToString();
            textBox_username.Text = dataGridView_user.CurrentRow.Cells["USER_NAME"].Value.ToString();
            dateTimePicker_birthdate.Value = (DateTime)dataGridView_user.CurrentRow.Cells["USER_BIRTH"].Value;
            textBox_email.Text = dataGridView_user.CurrentRow.Cells["USER_EMAIL"].Value.ToString();
            textBox_cccd.Text = dataGridView_user.CurrentRow.Cells["USER_CCCD"].Value.ToString();

            try
            {
                byte[] img = (byte[])dataGridView_user.CurrentRow.Cells["USER_IMAGE"].Value;
                MemoryStream ms = new MemoryStream(img);
                pictureBox_user.Image = Image.FromStream(ms);
            }
            catch
            {

            }
            comboBox_gender.Text = dataGridView_user.CurrentRow.Cells["USER_GENDER"].Value.ToString();
            comboBox_enable.Text = dataGridView_user.CurrentRow.Cells["U_EN"].Value.ToString();
            textBox_pass.Text = dataGridView_user.CurrentRow.Cells["U_PASS"].Value.ToString();
            comboBox_type.Text = dataGridView_user.CurrentRow.Cells["VT_NAME"].Value.ToString();
            comboBox_lv.Text = dataGridView_user.CurrentRow.Cells["LV_NAME"].Value.ToString();
            comboBox_dp.Text = dataGridView_user.CurrentRow.Cells["PB_NAME"].Value.ToString();
            textBox_addr.Text = dataGridView_user.CurrentRow.Cells["USER_ADDRESS"].Value.ToString();
            textBox_phone.Text = dataGridView_user.CurrentRow.Cells["USER_PHONE"].Value.ToString();
        }

        private void button_search_user_Click(object sender, EventArgs e)
        {
            String description = tb_search_user.Text;
            if (description.Equals(""))
            {
                loadTable();
                return;
            }
            loadTableSearch(description);
        }







        public void loadTableSearch(string description)
        {
            TypeBLL tl = new TypeBLL();
            string[] types = tl.getUserType();
            foreach (string t in types)
            {
                comboBox_type.Items.Add(t);
            }

            LevelBLL lv = new LevelBLL();
            string[] levels = lv.GetUserLevel();
            foreach (string t in levels)
            {
                comboBox_lv.Items.Add(t);
            }

            DepartmentBLL dp = new DepartmentBLL();
            string[] dps = dp.GetUserDP();
            foreach (string t in dps)
            {
                comboBox_dp.Items.Add(t);
            }
            showTableSearch(description);
        }

        public void showTableSearch(string description)
        {
            dataGridView_user.ReadOnly = true;
            dataGridView_user.DataSource = ul.getUserFromSearch(description);
            dataGridView_user.RowTemplate.Height = 80;

            try
            {
                // Show image
                DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                imageColumn = (DataGridViewImageColumn)dataGridView_user.Columns[7];
                imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            }
            catch { }

        }

        private void button_see_project_Click(object sender, EventArgs e)
        {
            Users.SPU = true;
            Users.CSU = curr_pk;
            ManageProjectForm manageProjectForm = new ManageProjectForm();
            manageProjectForm.Show();   
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox_type_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox_cccd_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
