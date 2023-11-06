namespace CNPM_ver3
{
    partial class ManageJoinedProjectForm
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
            this.dataGridView_myJProject = new System.Windows.Forms.DataGridView();
            this.panel_head = new System.Windows.Forms.Panel();
            this.button_search = new System.Windows.Forms.Button();
            this.textBox_search = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView_task = new System.Windows.Forms.DataGridView();
            this.button_allTask = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_myJProject)).BeginInit();
            this.panel_head.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_task)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_myJProject
            // 
            this.dataGridView_myJProject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_myJProject.Location = new System.Drawing.Point(8, 62);
            this.dataGridView_myJProject.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView_myJProject.Name = "dataGridView_myJProject";
            this.dataGridView_myJProject.RowHeadersWidth = 62;
            this.dataGridView_myJProject.RowTemplate.Height = 28;
            this.dataGridView_myJProject.Size = new System.Drawing.Size(1044, 252);
            this.dataGridView_myJProject.TabIndex = 0;
            this.dataGridView_myJProject.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_myJProject_CellContentClick);
            this.dataGridView_myJProject.Click += new System.EventHandler(this.dataGridView_myJProject_Click);
            // 
            // panel_head
            // 
            this.panel_head.BackColor = System.Drawing.Color.Firebrick;
            this.panel_head.Controls.Add(this.button_search);
            this.panel_head.Controls.Add(this.textBox_search);
            this.panel_head.Controls.Add(this.label1);
            this.panel_head.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_head.Location = new System.Drawing.Point(0, 0);
            this.panel_head.Name = "panel_head";
            this.panel_head.Size = new System.Drawing.Size(1060, 57);
            this.panel_head.TabIndex = 1;
            // 
            // button_search
            // 
            this.button_search.BackColor = System.Drawing.Color.Silver;
            this.button_search.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_search.Location = new System.Drawing.Point(964, 14);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(79, 29);
            this.button_search.TabIndex = 5;
            this.button_search.Text = "Search";
            this.button_search.UseVisualStyleBackColor = false;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // textBox_search
            // 
            this.textBox_search.Location = new System.Drawing.Point(741, 20);
            this.textBox_search.Name = "textBox_search";
            this.textBox_search.Size = new System.Drawing.Size(219, 20);
            this.textBox_search.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(364, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(286, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "My Joined Project";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dataGridView_task
            // 
            this.dataGridView_task.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_task.Location = new System.Drawing.Point(9, 351);
            this.dataGridView_task.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView_task.Name = "dataGridView_task";
            this.dataGridView_task.RowHeadersWidth = 62;
            this.dataGridView_task.RowTemplate.Height = 28;
            this.dataGridView_task.Size = new System.Drawing.Size(1043, 287);
            this.dataGridView_task.TabIndex = 2;
            // 
            // button_allTask
            // 
            this.button_allTask.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_allTask.Location = new System.Drawing.Point(973, 319);
            this.button_allTask.Margin = new System.Windows.Forms.Padding(2);
            this.button_allTask.Name = "button_allTask";
            this.button_allTask.Size = new System.Drawing.Size(79, 28);
            this.button_allTask.TabIndex = 3;
            this.button_allTask.Text = "All task";
            this.button_allTask.UseVisualStyleBackColor = false;
            this.button_allTask.Click += new System.EventHandler(this.button_allTask_Click);
            // 
            // ManageJoinedProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 646);
            this.Controls.Add(this.button_allTask);
            this.Controls.Add(this.dataGridView_task);
            this.Controls.Add(this.panel_head);
            this.Controls.Add(this.dataGridView_myJProject);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ManageJoinedProjectForm";
            this.Text = "ManageJoinedProjectForm";
            this.Load += new System.EventHandler(this.ManageJoinedProjectForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_myJProject)).EndInit();
            this.panel_head.ResumeLayout(false);
            this.panel_head.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_task)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_myJProject;
        private System.Windows.Forms.Panel panel_head;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.TextBox textBox_search;
        private System.Windows.Forms.DataGridView dataGridView_task;
        private System.Windows.Forms.Button button_allTask;
    }
}