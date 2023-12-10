namespace CNPM_ver3
{
    partial class RequestForm
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
            this.bt_Heading = new System.Windows.Forms.Button();
            this.bt_Request = new System.Windows.Forms.Button();
            this.textBox_toUser = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_file = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_subject = new System.Windows.Forms.TextBox();
            this.textBox_content = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buton_clear = new System.Windows.Forms.Button();
            this.dataGridView_myReq = new System.Windows.Forms.DataGridView();
            this.comboBox_files = new System.Windows.Forms.ComboBox();
            this.button_clearFiles = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_myReq)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_Heading
            // 
            this.bt_Heading.BackColor = System.Drawing.SystemColors.Highlight;
            this.bt_Heading.Dock = System.Windows.Forms.DockStyle.Top;
            this.bt_Heading.Font = new System.Drawing.Font("Microsoft YaHei UI", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Heading.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bt_Heading.Location = new System.Drawing.Point(0, 0);
            this.bt_Heading.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bt_Heading.Name = "bt_Heading";
            this.bt_Heading.Size = new System.Drawing.Size(1060, 58);
            this.bt_Heading.TabIndex = 0;
            this.bt_Heading.Text = "ADD REQUEST";
            this.bt_Heading.UseVisualStyleBackColor = false;
            // 
            // bt_Request
            // 
            this.bt_Request.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.bt_Request.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Request.ForeColor = System.Drawing.SystemColors.Control;
            this.bt_Request.Location = new System.Drawing.Point(869, 540);
            this.bt_Request.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bt_Request.Name = "bt_Request";
            this.bt_Request.Size = new System.Drawing.Size(144, 34);
            this.bt_Request.TabIndex = 1;
            this.bt_Request.Text = "Send";
            this.bt_Request.UseVisualStyleBackColor = false;
            this.bt_Request.Click += new System.EventHandler(this.bt_Request_Click);
            // 
            // textBox_toUser
            // 
            this.textBox_toUser.Location = new System.Drawing.Point(77, 486);
            this.textBox_toUser.Name = "textBox_toUser";
            this.textBox_toUser.Size = new System.Drawing.Size(171, 20);
            this.textBox_toUser.TabIndex = 2;
            this.textBox_toUser.TextChanged += new System.EventHandler(this.textBox_toUser_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 488);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Send to";
            // 
            // button_file
            // 
            this.button_file.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.button_file.Location = new System.Drawing.Point(542, 481);
            this.button_file.Margin = new System.Windows.Forms.Padding(2);
            this.button_file.Name = "button_file";
            this.button_file.Size = new System.Drawing.Size(74, 27);
            this.button_file.TabIndex = 5;
            this.button_file.Text = "Attach file";
            this.button_file.UseVisualStyleBackColor = false;
            this.button_file.Click += new System.EventHandler(this.button_file_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 443);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Subject";
            // 
            // textBox_subject
            // 
            this.textBox_subject.Location = new System.Drawing.Point(77, 441);
            this.textBox_subject.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_subject.Name = "textBox_subject";
            this.textBox_subject.Size = new System.Drawing.Size(171, 20);
            this.textBox_subject.TabIndex = 7;
            // 
            // textBox_content
            // 
            this.textBox_content.Location = new System.Drawing.Point(77, 528);
            this.textBox_content.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_content.Multiline = true;
            this.textBox_content.Name = "textBox_content";
            this.textBox_content.Size = new System.Drawing.Size(741, 107);
            this.textBox_content.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 530);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Content";
            // 
            // buton_clear
            // 
            this.buton_clear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.buton_clear.Font = new System.Drawing.Font("Microsoft YaHei UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buton_clear.ForeColor = System.Drawing.SystemColors.Control;
            this.buton_clear.Location = new System.Drawing.Point(869, 586);
            this.buton_clear.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buton_clear.Name = "buton_clear";
            this.buton_clear.Size = new System.Drawing.Size(144, 36);
            this.buton_clear.TabIndex = 0;
            this.buton_clear.Text = "Clear";
            this.buton_clear.UseVisualStyleBackColor = false;
            this.buton_clear.Click += new System.EventHandler(this.bt_delete_Click);
            // 
            // dataGridView_myReq
            // 
            this.dataGridView_myReq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_myReq.Location = new System.Drawing.Point(9, 64);
            this.dataGridView_myReq.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView_myReq.Name = "dataGridView_myReq";
            this.dataGridView_myReq.RowHeadersWidth = 62;
            this.dataGridView_myReq.RowTemplate.Height = 28;
            this.dataGridView_myReq.Size = new System.Drawing.Size(1043, 367);
            this.dataGridView_myReq.TabIndex = 13;
            this.dataGridView_myReq.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_myReq_CellContentClick);
            // 
            // comboBox_files
            // 
            this.comboBox_files.FormattingEnabled = true;
            this.comboBox_files.Location = new System.Drawing.Point(413, 485);
            this.comboBox_files.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_files.Name = "comboBox_files";
            this.comboBox_files.Size = new System.Drawing.Size(127, 21);
            this.comboBox_files.TabIndex = 14;
            this.comboBox_files.SelectedIndexChanged += new System.EventHandler(this.comboBox_files_SelectedIndexChanged);
            // 
            // button_clearFiles
            // 
            this.button_clearFiles.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_clearFiles.Location = new System.Drawing.Point(620, 484);
            this.button_clearFiles.Margin = new System.Windows.Forms.Padding(2);
            this.button_clearFiles.Name = "button_clearFiles";
            this.button_clearFiles.Size = new System.Drawing.Size(53, 23);
            this.button_clearFiles.TabIndex = 15;
            this.button_clearFiles.Text = "Clear";
            this.button_clearFiles.UseVisualStyleBackColor = false;
            this.button_clearFiles.Click += new System.EventHandler(this.button_clearFiles_Click);
            // 
            // RequestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 646);
            this.Controls.Add(this.button_clearFiles);
            this.Controls.Add(this.comboBox_files);
            this.Controls.Add(this.dataGridView_myReq);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_content);
            this.Controls.Add(this.textBox_subject);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_file);
            this.Controls.Add(this.bt_Heading);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bt_Request);
            this.Controls.Add(this.textBox_toUser);
            this.Controls.Add(this.buton_clear);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "RequestForm";
            this.Text = "RequestForm";
            this.Load += new System.EventHandler(this.RequestForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_myReq)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bt_Request;
        private System.Windows.Forms.Button bt_Heading;
        private System.Windows.Forms.TextBox textBox_toUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_file;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_subject;
        private System.Windows.Forms.TextBox textBox_content;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buton_clear;
        private System.Windows.Forms.DataGridView dataGridView_myReq;
        private System.Windows.Forms.ComboBox comboBox_files;
        private System.Windows.Forms.Button button_clearFiles;
    }
}