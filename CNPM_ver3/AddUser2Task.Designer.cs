namespace CNPM_ver3
{
    partial class AddUser2Task
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
            this.dataGridView_user = new System.Windows.Forms.DataGridView();
            this.dataGridView_mInTask = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_user)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_mInTask)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_user
            // 
            this.dataGridView_user.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_user.Location = new System.Drawing.Point(13, 14);
            this.dataGridView_user.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView_user.Name = "dataGridView_user";
            this.dataGridView_user.RowHeadersWidth = 62;
            this.dataGridView_user.Size = new System.Drawing.Size(1540, 362);
            this.dataGridView_user.TabIndex = 2;
            this.dataGridView_user.Click += new System.EventHandler(this.dataGridView_user_Click);
            // 
            // dataGridView_mInTask
            // 
            this.dataGridView_mInTask.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_mInTask.Location = new System.Drawing.Point(13, 386);
            this.dataGridView_mInTask.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView_mInTask.Name = "dataGridView_mInTask";
            this.dataGridView_mInTask.RowHeadersWidth = 62;
            this.dataGridView_mInTask.Size = new System.Drawing.Size(1540, 451);
            this.dataGridView_mInTask.TabIndex = 3;
            // 
            // AddUser2Task
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1566, 851);
            this.Controls.Add(this.dataGridView_user);
            this.Controls.Add(this.dataGridView_mInTask);
            this.Name = "AddUser2Task";
            this.Text = "AddUserToTask";
            this.Load += new System.EventHandler(this.AddUser2Task_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_user)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_mInTask)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_user;
        private System.Windows.Forms.DataGridView dataGridView_mInTask;
    }
}