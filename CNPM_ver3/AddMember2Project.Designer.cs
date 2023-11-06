namespace CNPM_ver3
{
    partial class AddMember2Project
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
            this.dataGridView_mInProject = new System.Windows.Forms.DataGridView();
            this.dataGridView_user = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_mInProject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_user)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_mInProject
            // 
            this.dataGridView_mInProject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_mInProject.Location = new System.Drawing.Point(34, 352);
            this.dataGridView_mInProject.Name = "dataGridView_mInProject";
            this.dataGridView_mInProject.RowHeadersWidth = 62;
            this.dataGridView_mInProject.Size = new System.Drawing.Size(994, 337);
            this.dataGridView_mInProject.TabIndex = 1;
            this.dataGridView_mInProject.Click += new System.EventHandler(this.dataGridView_mInProject_Click);
            // 
            // dataGridView_user
            // 
            this.dataGridView_user.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_user.Location = new System.Drawing.Point(34, 29);
            this.dataGridView_user.Name = "dataGridView_user";
            this.dataGridView_user.RowHeadersWidth = 62;
            this.dataGridView_user.Size = new System.Drawing.Size(994, 304);
            this.dataGridView_user.TabIndex = 0;
            this.dataGridView_user.Click += new System.EventHandler(this.dataGridView_user_Click);
            // 
            // AddMember2Project
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1054, 701);
            this.Controls.Add(this.dataGridView_user);
            this.Controls.Add(this.dataGridView_mInProject);
            this.Name = "AddMember2Project";
            this.Text = "AddMember2Project";
            this.Load += new System.EventHandler(this.AddMember2Project_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_mInProject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_user)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView_mInProject;
        private System.Windows.Forms.DataGridView dataGridView_user;
    }
}