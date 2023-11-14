namespace CNPM_ver3
{
    partial class AssignTaskForm
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
            this.textBox_taskDesc = new System.Windows.Forms.TextBox();
            this.button_clearFiles = new System.Windows.Forms.Button();
            this.comboBox_files = new System.Windows.Forms.ComboBox();
            this.button_file = new System.Windows.Forms.Button();
            this.button_assign = new System.Windows.Forms.Button();
            this.button_clear = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePicker_end = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_start = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_pjName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_taskName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView_assignees = new System.Windows.Forms.DataGridView();
            this.comboBox_assignees = new System.Windows.Forms.ComboBox();
            this.dataGridView_subtasks = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_assignees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_subtasks)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_taskDesc
            // 
            this.textBox_taskDesc.Location = new System.Drawing.Point(115, 363);
            this.textBox_taskDesc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_taskDesc.Multiline = true;
            this.textBox_taskDesc.Name = "textBox_taskDesc";
            this.textBox_taskDesc.Size = new System.Drawing.Size(311, 94);
            this.textBox_taskDesc.TabIndex = 0;
            // 
            // button_clearFiles
            // 
            this.button_clearFiles.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_clearFiles.Location = new System.Drawing.Point(709, 377);
            this.button_clearFiles.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_clearFiles.Name = "button_clearFiles";
            this.button_clearFiles.Size = new System.Drawing.Size(53, 23);
            this.button_clearFiles.TabIndex = 19;
            this.button_clearFiles.Text = "Clear";
            this.button_clearFiles.UseVisualStyleBackColor = false;
            this.button_clearFiles.Click += new System.EventHandler(this.button_clearFiles_Click);
            // 
            // comboBox_files
            // 
            this.comboBox_files.FormattingEnabled = true;
            this.comboBox_files.Location = new System.Drawing.Point(503, 376);
            this.comboBox_files.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox_files.Name = "comboBox_files";
            this.comboBox_files.Size = new System.Drawing.Size(127, 21);
            this.comboBox_files.TabIndex = 18;
            // 
            // button_file
            // 
            this.button_file.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.button_file.Location = new System.Drawing.Point(631, 372);
            this.button_file.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_file.Name = "button_file";
            this.button_file.Size = new System.Drawing.Size(74, 27);
            this.button_file.TabIndex = 17;
            this.button_file.Text = "Attach file";
            this.button_file.UseVisualStyleBackColor = false;
            this.button_file.Click += new System.EventHandler(this.button_file_Click);
            // 
            // button_assign
            // 
            this.button_assign.BackColor = System.Drawing.Color.CornflowerBlue;
            this.button_assign.Location = new System.Drawing.Point(639, 411);
            this.button_assign.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_assign.Name = "button_assign";
            this.button_assign.Size = new System.Drawing.Size(117, 44);
            this.button_assign.TabIndex = 20;
            this.button_assign.Text = "Assign task";
            this.button_assign.UseVisualStyleBackColor = false;
            this.button_assign.Click += new System.EventHandler(this.button_assign_Click);
            // 
            // button_clear
            // 
            this.button_clear.BackColor = System.Drawing.Color.DarkSalmon;
            this.button_clear.Location = new System.Drawing.Point(511, 411);
            this.button_clear.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(117, 44);
            this.button_clear.TabIndex = 21;
            this.button_clear.Text = "Clear";
            this.button_clear.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 154);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Assignees";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(440, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 121;
            this.label6.Text = "Deadline";
            // 
            // dateTimePicker_end
            // 
            this.dateTimePicker_end.Location = new System.Drawing.Point(503, 131);
            this.dateTimePicker_end.Name = "dateTimePicker_end";
            this.dateTimePicker_end.Size = new System.Drawing.Size(255, 20);
            this.dateTimePicker_end.TabIndex = 120;
            // 
            // dateTimePicker_start
            // 
            this.dateTimePicker_start.Location = new System.Drawing.Point(503, 98);
            this.dateTimePicker_start.Name = "dateTimePicker_start";
            this.dateTimePicker_start.Size = new System.Drawing.Size(255, 20);
            this.dateTimePicker_start.TabIndex = 118;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(459, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 119;
            this.label5.Text = "Start";
            // 
            // textBox_pjName
            // 
            this.textBox_pjName.Location = new System.Drawing.Point(107, 100);
            this.textBox_pjName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_pjName.Name = "textBox_pjName";
            this.textBox_pjName.ReadOnly = true;
            this.textBox_pjName.Size = new System.Drawing.Size(311, 20);
            this.textBox_pjName.TabIndex = 114;
            this.textBox_pjName.Text = "Auto fill this  field";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 365);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 126;
            this.label1.Text = "Task description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 105);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 128;
            this.label3.Text = "Project";
            // 
            // textBox_taskName
            // 
            this.textBox_taskName.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_taskName.Location = new System.Drawing.Point(83, 34);
            this.textBox_taskName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_taskName.Name = "textBox_taskName";
            this.textBox_taskName.Size = new System.Drawing.Size(675, 44);
            this.textBox_taskName.TabIndex = 127;
            this.textBox_taskName.Text = "Manage High School";
            this.textBox_taskName.UseWaitCursor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 48);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 129;
            this.label4.Text = "Task name";
            // 
            // dataGridView_assignees
            // 
            this.dataGridView_assignees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_assignees.Location = new System.Drawing.Point(107, 179);
            this.dataGridView_assignees.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView_assignees.Name = "dataGridView_assignees";
            this.dataGridView_assignees.RowHeadersWidth = 62;
            this.dataGridView_assignees.RowTemplate.Height = 28;
            this.dataGridView_assignees.Size = new System.Drawing.Size(309, 176);
            this.dataGridView_assignees.TabIndex = 131;
            this.dataGridView_assignees.Click += new System.EventHandler(this.dataGridView_assignees_Click);
            // 
            // comboBox_assignees
            // 
            this.comboBox_assignees.FormattingEnabled = true;
            this.comboBox_assignees.Location = new System.Drawing.Point(105, 154);
            this.comboBox_assignees.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox_assignees.Name = "comboBox_assignees";
            this.comboBox_assignees.Size = new System.Drawing.Size(311, 21);
            this.comboBox_assignees.TabIndex = 132;
            this.comboBox_assignees.SelectedIndexChanged += new System.EventHandler(this.comboBox_assignees_SelectedIndexChanged);
            // 
            // dataGridView_subtasks
            // 
            this.dataGridView_subtasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_subtasks.Location = new System.Drawing.Point(443, 179);
            this.dataGridView_subtasks.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView_subtasks.Name = "dataGridView_subtasks";
            this.dataGridView_subtasks.RowHeadersWidth = 62;
            this.dataGridView_subtasks.RowTemplate.Height = 28;
            this.dataGridView_subtasks.Size = new System.Drawing.Size(349, 176);
            this.dataGridView_subtasks.TabIndex = 133;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(442, 164);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 134;
            this.label7.Text = "Subtasks";
            // 
            // AssignTaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 473);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dataGridView_subtasks);
            this.Controls.Add(this.comboBox_assignees);
            this.Controls.Add(this.dataGridView_assignees);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_taskName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dateTimePicker_end);
            this.Controls.Add(this.dateTimePicker_start);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_pjName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.button_assign);
            this.Controls.Add(this.button_clearFiles);
            this.Controls.Add(this.comboBox_files);
            this.Controls.Add(this.button_file);
            this.Controls.Add(this.textBox_taskDesc);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AssignTaskForm";
            this.Text = "AssignTaskForm";
            this.Load += new System.EventHandler(this.AssignTaskForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_assignees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_subtasks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_taskDesc;
        private System.Windows.Forms.Button button_clearFiles;
        private System.Windows.Forms.ComboBox comboBox_files;
        private System.Windows.Forms.Button button_file;
        private System.Windows.Forms.Button button_assign;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePicker_end;
        private System.Windows.Forms.DateTimePicker dateTimePicker_start;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_pjName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_taskName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView_assignees;
        private System.Windows.Forms.ComboBox comboBox_assignees;
        private System.Windows.Forms.DataGridView dataGridView_subtasks;
        private System.Windows.Forms.Label label7;
    }
}