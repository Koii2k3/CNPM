namespace CNPM_ver3
{
    partial class ManageMemberForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageMemberForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_search_user = new System.Windows.Forms.Button();
            this.tb_search_user = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel_addUser = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.panel_main = new System.Windows.Forms.Panel();
            this.panel_cover = new System.Windows.Forms.Panel();
            this.button_see_project = new System.Windows.Forms.Button();
            this.btDisableList = new System.Windows.Forms.Button();
            this.btDisable = new System.Windows.Forms.Button();
            this.comboBox_lv = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBox_dp = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_phone = new System.Windows.Forms.TextBox();
            this.button_update = new System.Windows.Forms.Button();
            this.button_upload = new System.Windows.Forms.Button();
            this.comboBox_type = new System.Windows.Forms.ComboBox();
            this.comboBox_enable = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox_pass = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.comboBox_gender = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox_email = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.pictureBox_user = new System.Windows.Forms.PictureBox();
            this.textBox_cccd = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox_addr = new System.Windows.Forms.TextBox();
            this.label_address = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.dateTimePicker_birthdate = new System.Windows.Forms.DateTimePicker();
            this.textBox_username = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.dataGridView_user = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel_main.SuspendLayout();
            this.panel_cover.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_user)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_user)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Firebrick;
            this.panel1.Controls.Add(this.button_search_user);
            this.panel1.Controls.Add(this.tb_search_user);
            this.panel1.Controls.Add(this.label1);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // button_search_user
            // 
            this.button_search_user.BackColor = System.Drawing.Color.Silver;
            this.button_search_user.ForeColor = System.Drawing.SystemColors.ControlText;
            resources.ApplyResources(this.button_search_user, "button_search_user");
            this.button_search_user.Name = "button_search_user";
            this.button_search_user.UseVisualStyleBackColor = false;
            this.button_search_user.Click += new System.EventHandler(this.button_search_user_Click);
            // 
            // tb_search_user
            // 
            resources.ApplyResources(this.tb_search_user, "tb_search_user");
            this.tb_search_user.Name = "tb_search_user";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Name = "label1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel_addUser,
            this.toolStripLabel2});
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Name = "toolStrip1";
            // 
            // toolStripLabel_addUser
            // 
            this.toolStripLabel_addUser.Name = "toolStripLabel_addUser";
            resources.ApplyResources(this.toolStripLabel_addUser, "toolStripLabel_addUser");
            this.toolStripLabel_addUser.Click += new System.EventHandler(this.toolStripLabel_addUser_Click);
            // 
            // toolStripLabel2
            // 
            resources.ApplyResources(this.toolStripLabel2, "toolStripLabel2");
            this.toolStripLabel2.ForeColor = System.Drawing.Color.Red;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Click += new System.EventHandler(this.toolStripLabel2_Click);
            // 
            // panel_main
            // 
            this.panel_main.Controls.Add(this.panel_cover);
            resources.ApplyResources(this.panel_main, "panel_main");
            this.panel_main.Name = "panel_main";
            // 
            // panel_cover
            // 
            this.panel_cover.Controls.Add(this.button_see_project);
            this.panel_cover.Controls.Add(this.btDisableList);
            this.panel_cover.Controls.Add(this.btDisable);
            this.panel_cover.Controls.Add(this.comboBox_lv);
            this.panel_cover.Controls.Add(this.label11);
            this.panel_cover.Controls.Add(this.comboBox_dp);
            this.panel_cover.Controls.Add(this.label10);
            this.panel_cover.Controls.Add(this.label9);
            this.panel_cover.Controls.Add(this.textBox_phone);
            this.panel_cover.Controls.Add(this.button_update);
            this.panel_cover.Controls.Add(this.button_upload);
            this.panel_cover.Controls.Add(this.comboBox_type);
            this.panel_cover.Controls.Add(this.comboBox_enable);
            this.panel_cover.Controls.Add(this.label12);
            this.panel_cover.Controls.Add(this.label13);
            this.panel_cover.Controls.Add(this.textBox_pass);
            this.panel_cover.Controls.Add(this.label14);
            this.panel_cover.Controls.Add(this.comboBox_gender);
            this.panel_cover.Controls.Add(this.label15);
            this.panel_cover.Controls.Add(this.textBox_email);
            this.panel_cover.Controls.Add(this.label16);
            this.panel_cover.Controls.Add(this.pictureBox_user);
            this.panel_cover.Controls.Add(this.textBox_cccd);
            this.panel_cover.Controls.Add(this.label17);
            this.panel_cover.Controls.Add(this.textBox_addr);
            this.panel_cover.Controls.Add(this.label_address);
            this.panel_cover.Controls.Add(this.label18);
            this.panel_cover.Controls.Add(this.dateTimePicker_birthdate);
            this.panel_cover.Controls.Add(this.textBox_username);
            this.panel_cover.Controls.Add(this.label19);
            this.panel_cover.Controls.Add(this.dataGridView_user);
            resources.ApplyResources(this.panel_cover, "panel_cover");
            this.panel_cover.Name = "panel_cover";
            // 
            // button_see_project
            // 
            this.button_see_project.BackColor = System.Drawing.Color.Firebrick;
            resources.ApplyResources(this.button_see_project, "button_see_project");
            this.button_see_project.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_see_project.Name = "button_see_project";
            this.button_see_project.UseVisualStyleBackColor = false;
            this.button_see_project.Click += new System.EventHandler(this.button_see_project_Click);
            // 
            // btDisableList
            // 
            this.btDisableList.BackColor = System.Drawing.Color.Firebrick;
            resources.ApplyResources(this.btDisableList, "btDisableList");
            this.btDisableList.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btDisableList.Name = "btDisableList";
            this.btDisableList.UseVisualStyleBackColor = false;
            this.btDisableList.Click += new System.EventHandler(this.btDisableList_Click);
            // 
            // btDisable
            // 
            this.btDisable.BackColor = System.Drawing.Color.Firebrick;
            resources.ApplyResources(this.btDisable, "btDisable");
            this.btDisable.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btDisable.Name = "btDisable";
            this.btDisable.UseVisualStyleBackColor = false;
            this.btDisable.Click += new System.EventHandler(this.btDisable_Click);
            // 
            // comboBox_lv
            // 
            this.comboBox_lv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_lv.FormattingEnabled = true;
            resources.ApplyResources(this.comboBox_lv, "comboBox_lv");
            this.comboBox_lv.Name = "comboBox_lv";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // comboBox_dp
            // 
            this.comboBox_dp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_dp.FormattingEnabled = true;
            resources.ApplyResources(this.comboBox_dp, "comboBox_dp");
            this.comboBox_dp.Name = "comboBox_dp";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // textBox_phone
            // 
            resources.ApplyResources(this.textBox_phone, "textBox_phone");
            this.textBox_phone.Name = "textBox_phone";
            // 
            // button_update
            // 
            this.button_update.BackColor = System.Drawing.Color.Firebrick;
            resources.ApplyResources(this.button_update, "button_update");
            this.button_update.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_update.Name = "button_update";
            this.button_update.UseVisualStyleBackColor = false;
            this.button_update.Click += new System.EventHandler(this.button_update_Click);
            // 
            // button_upload
            // 
            this.button_upload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button_upload.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            resources.ApplyResources(this.button_upload, "button_upload");
            this.button_upload.Name = "button_upload";
            this.button_upload.UseVisualStyleBackColor = false;
            this.button_upload.Click += new System.EventHandler(this.button_upload_Click);
            // 
            // comboBox_type
            // 
            this.comboBox_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_type.FormattingEnabled = true;
            resources.ApplyResources(this.comboBox_type, "comboBox_type");
            this.comboBox_type.Name = "comboBox_type";
            this.comboBox_type.SelectedIndexChanged += new System.EventHandler(this.comboBox_type_SelectedIndexChanged);
            // 
            // comboBox_enable
            // 
            this.comboBox_enable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_enable.FormattingEnabled = true;
            this.comboBox_enable.Items.AddRange(new object[] {
            resources.GetString("comboBox_enable.Items"),
            resources.GetString("comboBox_enable.Items1")});
            resources.ApplyResources(this.comboBox_enable, "comboBox_enable");
            this.comboBox_enable.Name = "comboBox_enable";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // textBox_pass
            // 
            resources.ApplyResources(this.textBox_pass, "textBox_pass");
            this.textBox_pass.Name = "textBox_pass";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // comboBox_gender
            // 
            this.comboBox_gender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_gender.FormattingEnabled = true;
            this.comboBox_gender.Items.AddRange(new object[] {
            resources.GetString("comboBox_gender.Items"),
            resources.GetString("comboBox_gender.Items1"),
            resources.GetString("comboBox_gender.Items2")});
            resources.ApplyResources(this.comboBox_gender, "comboBox_gender");
            this.comboBox_gender.Name = "comboBox_gender";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // textBox_email
            // 
            resources.ApplyResources(this.textBox_email, "textBox_email");
            this.textBox_email.Name = "textBox_email";
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // pictureBox_user
            // 
            this.pictureBox_user.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.pictureBox_user, "pictureBox_user");
            this.pictureBox_user.Name = "pictureBox_user";
            this.pictureBox_user.TabStop = false;
            // 
            // textBox_cccd
            // 
            resources.ApplyResources(this.textBox_cccd, "textBox_cccd");
            this.textBox_cccd.Name = "textBox_cccd";
            this.textBox_cccd.TextChanged += new System.EventHandler(this.textBox_cccd_TextChanged);
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // textBox_addr
            // 
            resources.ApplyResources(this.textBox_addr, "textBox_addr");
            this.textBox_addr.Name = "textBox_addr";
            // 
            // label_address
            // 
            resources.ApplyResources(this.label_address, "label_address");
            this.label_address.Name = "label_address";
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.Name = "label18";
            // 
            // dateTimePicker_birthdate
            // 
            resources.ApplyResources(this.dateTimePicker_birthdate, "dateTimePicker_birthdate");
            this.dateTimePicker_birthdate.Name = "dateTimePicker_birthdate";
            // 
            // textBox_username
            // 
            resources.ApplyResources(this.textBox_username, "textBox_username");
            this.textBox_username.Name = "textBox_username";
            // 
            // label19
            // 
            resources.ApplyResources(this.label19, "label19");
            this.label19.Name = "label19";
            // 
            // dataGridView_user
            // 
            this.dataGridView_user.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dataGridView_user, "dataGridView_user");
            this.dataGridView_user.Name = "dataGridView_user";
            this.dataGridView_user.Click += new System.EventHandler(this.dataGridView_user_Click);
            // 
            // ManageMemberForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel_main);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.Name = "ManageMemberForm";
            this.Load += new System.EventHandler(this.ManageMemberForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel_main.ResumeLayout(false);
            this.panel_cover.ResumeLayout(false);
            this.panel_cover.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_user)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_user)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_addUser;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.Panel panel_main;
        private System.Windows.Forms.Panel panel_cover;
        private System.Windows.Forms.DataGridView dataGridView_user;
        private System.Windows.Forms.Button button_update;
        private System.Windows.Forms.Button button_upload;
        private System.Windows.Forms.ComboBox comboBox_type;
        private System.Windows.Forms.ComboBox comboBox_enable;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox_pass;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox comboBox_gender;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox_email;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.PictureBox pictureBox_user;
        private System.Windows.Forms.TextBox textBox_cccd;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBox_addr;
        private System.Windows.Forms.Label label_address;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DateTimePicker dateTimePicker_birthdate;
        private System.Windows.Forms.TextBox textBox_username;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox comboBox_lv;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBox_dp;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_phone;
        private System.Windows.Forms.Button btDisable;
        private System.Windows.Forms.Button btDisableList;
        private System.Windows.Forms.Button button_search_user;
        private System.Windows.Forms.TextBox tb_search_user;
        private System.Windows.Forms.Button button_see_project;
    }
}