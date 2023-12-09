namespace CNPM_ver3
{
    partial class UserHomeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserHomeForm));
            this.panel_tool = new System.Windows.Forms.Panel();
            this.button_home = new System.Windows.Forms.Button();
            this.button_logout = new System.Windows.Forms.Button();
            this.pictureBox_user = new System.Windows.Forms.PictureBox();
            this.label_role = new System.Windows.Forms.Label();
            this.label_username = new System.Windows.Forms.Label();
            this.panel_main = new System.Windows.Forms.Panel();
            this.panel_cover = new System.Windows.Forms.Panel();
            this.button_manageReq = new System.Windows.Forms.Button();
            this.button_myJProject = new System.Windows.Forms.Button();
            this.button_manageProject = new System.Windows.Forms.Button();
            this.button_request = new System.Windows.Forms.Button();
            this.button_profile = new System.Windows.Forms.Button();
            this.button_4 = new System.Windows.Forms.Button();
            this.button_manageMember = new System.Windows.Forms.Button();
            this.panel_header = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_tool.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_user)).BeginInit();
            this.panel_main.SuspendLayout();
            this.panel_cover.SuspendLayout();
            this.panel_header.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_tool
            // 
            this.panel_tool.BackColor = System.Drawing.Color.Firebrick;
            this.panel_tool.Controls.Add(this.button_home);
            this.panel_tool.Controls.Add(this.button_logout);
            this.panel_tool.Controls.Add(this.pictureBox_user);
            this.panel_tool.Controls.Add(this.label_role);
            this.panel_tool.Controls.Add(this.label_username);
            resources.ApplyResources(this.panel_tool, "panel_tool");
            this.panel_tool.Name = "panel_tool";
            // 
            // button_home
            // 
            this.button_home.BackColor = System.Drawing.Color.IndianRed;
            resources.ApplyResources(this.button_home, "button_home");
            this.button_home.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_home.Name = "button_home";
            this.button_home.UseVisualStyleBackColor = false;
            this.button_home.Click += new System.EventHandler(this.button_home_Click);
            // 
            // button_logout
            // 
            this.button_logout.BackColor = System.Drawing.Color.Silver;
            resources.ApplyResources(this.button_logout, "button_logout");
            this.button_logout.Name = "button_logout";
            this.button_logout.UseVisualStyleBackColor = false;
            this.button_logout.Click += new System.EventHandler(this.button_logout_Click);
            // 
            // pictureBox_user
            // 
            this.pictureBox_user.BackColor = System.Drawing.Color.LightGray;
            resources.ApplyResources(this.pictureBox_user, "pictureBox_user");
            this.pictureBox_user.Name = "pictureBox_user";
            this.pictureBox_user.TabStop = false;
            // 
            // label_role
            // 
            resources.ApplyResources(this.label_role, "label_role");
            this.label_role.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label_role.Name = "label_role";
            // 
            // label_username
            // 
            resources.ApplyResources(this.label_username, "label_username");
            this.label_username.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label_username.Name = "label_username";
            // 
            // panel_main
            // 
            this.panel_main.Controls.Add(this.panel_cover);
            resources.ApplyResources(this.panel_main, "panel_main");
            this.panel_main.Name = "panel_main";
            // 
            // panel_cover
            // 
            this.panel_cover.Controls.Add(this.button_manageReq);
            this.panel_cover.Controls.Add(this.button_myJProject);
            this.panel_cover.Controls.Add(this.button_manageProject);
            this.panel_cover.Controls.Add(this.button_request);
            this.panel_cover.Controls.Add(this.button_profile);
            this.panel_cover.Controls.Add(this.button_4);
            this.panel_cover.Controls.Add(this.button_manageMember);
            this.panel_cover.Controls.Add(this.panel_header);
            resources.ApplyResources(this.panel_cover, "panel_cover");
            this.panel_cover.Name = "panel_cover";
            // 
            // button_manageReq
            // 
            this.button_manageReq.BackColor = System.Drawing.Color.Firebrick;
            this.button_manageReq.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            resources.ApplyResources(this.button_manageReq, "button_manageReq");
            this.button_manageReq.Name = "button_manageReq";
            this.button_manageReq.UseVisualStyleBackColor = false;
            this.button_manageReq.Click += new System.EventHandler(this.button_manageReq_Click);
            // 
            // button_myJProject
            // 
            this.button_myJProject.BackColor = System.Drawing.Color.Firebrick;
            this.button_myJProject.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            resources.ApplyResources(this.button_myJProject, "button_myJProject");
            this.button_myJProject.Name = "button_myJProject";
            this.button_myJProject.UseVisualStyleBackColor = false;
            this.button_myJProject.Click += new System.EventHandler(this.button_myJProject_Click);
            // 
            // button_manageProject
            // 
            this.button_manageProject.BackColor = System.Drawing.Color.Firebrick;
            this.button_manageProject.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            resources.ApplyResources(this.button_manageProject, "button_manageProject");
            this.button_manageProject.Name = "button_manageProject";
            this.button_manageProject.UseVisualStyleBackColor = false;
            this.button_manageProject.Click += new System.EventHandler(this.button_addProject_Click);
            // 
            // button_request
            // 
            this.button_request.BackColor = System.Drawing.Color.Firebrick;
            this.button_request.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            resources.ApplyResources(this.button_request, "button_request");
            this.button_request.Name = "button_request";
            this.button_request.UseVisualStyleBackColor = false;
            this.button_request.Click += new System.EventHandler(this.button_manageRequest_Click);
            // 
            // button_profile
            // 
            this.button_profile.BackColor = System.Drawing.Color.Firebrick;
            this.button_profile.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            resources.ApplyResources(this.button_profile, "button_profile");
            this.button_profile.Name = "button_profile";
            this.button_profile.UseVisualStyleBackColor = false;
            this.button_profile.Click += new System.EventHandler(this.button_profile_Click);
            // 
            // button_4
            // 
            this.button_4.BackColor = System.Drawing.Color.IndianRed;
            this.button_4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            resources.ApplyResources(this.button_4, "button_4");
            this.button_4.Name = "button_4";
            this.button_4.UseVisualStyleBackColor = false;
            // 
            // button_manageMember
            // 
            this.button_manageMember.BackColor = System.Drawing.Color.Firebrick;
            this.button_manageMember.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            resources.ApplyResources(this.button_manageMember, "button_manageMember");
            this.button_manageMember.Name = "button_manageMember";
            this.button_manageMember.UseVisualStyleBackColor = false;
            this.button_manageMember.Click += new System.EventHandler(this.button_manageMenber_Click);
            // 
            // panel_header
            // 
            this.panel_header.BackColor = System.Drawing.Color.Firebrick;
            this.panel_header.Controls.Add(this.label1);
            resources.ApplyResources(this.panel_header, "panel_header");
            this.panel_header.Name = "panel_header";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Name = "label1";
            // 
            // UserHomeForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel_main);
            this.Controls.Add(this.panel_tool);
            this.Name = "UserHomeForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.UserHomeForm_Load);
            this.panel_tool.ResumeLayout(false);
            this.panel_tool.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_user)).EndInit();
            this.panel_main.ResumeLayout(false);
            this.panel_cover.ResumeLayout(false);
            this.panel_header.ResumeLayout(false);
            this.panel_header.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_tool;
        private System.Windows.Forms.Label label_role;
        private System.Windows.Forms.Label label_username;
        private System.Windows.Forms.PictureBox pictureBox_user;
        private System.Windows.Forms.Button button_logout;
        private System.Windows.Forms.Panel panel_main;
        private System.Windows.Forms.Panel panel_cover;
        private System.Windows.Forms.Panel panel_header;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_profile;
        private System.Windows.Forms.Button button_4;
        private System.Windows.Forms.Button button_manageMember;
        private System.Windows.Forms.Button button_home;
        private System.Windows.Forms.Button button_request;
        private System.Windows.Forms.Button button_manageProject;
        private System.Windows.Forms.Button button_myJProject;
        private System.Windows.Forms.Button button_manageReq;
    }
}