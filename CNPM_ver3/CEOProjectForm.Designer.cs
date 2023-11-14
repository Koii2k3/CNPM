namespace CNPM_ver3
{
    partial class CEOProjectForm
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
            this.dataGridView_project = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_project)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_project
            // 
            this.dataGridView_project.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_project.Location = new System.Drawing.Point(12, 12);
            this.dataGridView_project.Name = "dataGridView_project";
            this.dataGridView_project.RowHeadersWidth = 62;
            this.dataGridView_project.RowTemplate.Height = 28;
            this.dataGridView_project.Size = new System.Drawing.Size(1378, 688);
            this.dataGridView_project.TabIndex = 0;
            // 
            // CEOProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1402, 761);
            this.Controls.Add(this.dataGridView_project);
            this.Name = "CEOProjectForm";
            this.Text = "CEOProjectForm";
            this.Load += new System.EventHandler(this.CEOProjectForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_project)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_project;
    }
}