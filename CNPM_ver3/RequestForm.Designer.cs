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
            this.bt_Heading.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.bt_Heading.Name = "bt_Heading";
            this.bt_Heading.Size = new System.Drawing.Size(1590, 89);
            this.bt_Heading.TabIndex = 0;
            this.bt_Heading.Text = "ADD REQUEST";
            this.bt_Heading.UseVisualStyleBackColor = false;
            // 
            // bt_Request
            // 
            this.bt_Request.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.bt_Request.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Request.ForeColor = System.Drawing.SystemColors.Control;
            this.bt_Request.Location = new System.Drawing.Point(1294, 761);
            this.bt_Request.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.bt_Request.Name = "bt_Request";
            this.bt_Request.Size = new System.Drawing.Size(216, 52);
            this.bt_Request.TabIndex = 1;
            this.bt_Request.Text = "Send";
            this.bt_Request.UseVisualStyleBackColor = false;
            this.bt_Request.Click += new System.EventHandler(this.bt_Request_Click);
            // 
            // textBox_toUser
            // 
            this.textBox_toUser.Location = new System.Drawing.Point(118, 729);
            this.textBox_toUser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_toUser.Name = "textBox_toUser";
            this.textBox_toUser.Size = new System.Drawing.Size(254, 26);
            this.textBox_toUser.TabIndex = 2;
            this.textBox_toUser.TextChanged += new System.EventHandler(this.textBox_toUser_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 732);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Send to";
            // 
            // button_file
            // 
            this.button_file.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.button_file.Location = new System.Drawing.Point(1032, 724);
            this.button_file.Name = "button_file";
            this.button_file.Size = new System.Drawing.Size(111, 42);
            this.button_file.TabIndex = 5;
            this.button_file.Text = "Attach file";
            this.button_file.UseVisualStyleBackColor = false;
            this.button_file.Click += new System.EventHandler(this.button_file_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(435, 735);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Subject";
            // 
            // textBox_subject
            // 
            this.textBox_subject.Location = new System.Drawing.Point(507, 731);
            this.textBox_subject.Name = "textBox_subject";
            this.textBox_subject.Size = new System.Drawing.Size(254, 26);
            this.textBox_subject.TabIndex = 7;
            // 
            // textBox_content
            // 
            this.textBox_content.Location = new System.Drawing.Point(118, 788);
            this.textBox_content.Multiline = true;
            this.textBox_content.Name = "textBox_content";
            this.textBox_content.Size = new System.Drawing.Size(1110, 162);
            this.textBox_content.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(42, 791);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Content";
            // 
            // buton_clear
            // 
            this.buton_clear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.buton_clear.Font = new System.Drawing.Font("Microsoft YaHei UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buton_clear.ForeColor = System.Drawing.SystemColors.Control;
            this.buton_clear.Location = new System.Drawing.Point(1294, 832);
            this.buton_clear.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.buton_clear.Name = "buton_clear";
            this.buton_clear.Size = new System.Drawing.Size(216, 55);
            this.buton_clear.TabIndex = 0;
            this.buton_clear.Text = "Clear";
            this.buton_clear.UseVisualStyleBackColor = false;
            this.buton_clear.Click += new System.EventHandler(this.bt_delete_Click);
            // 
            // dataGridView_myReq
            // 
            this.dataGridView_myReq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_myReq.Location = new System.Drawing.Point(14, 98);
            this.dataGridView_myReq.Name = "dataGridView_myReq";
            this.dataGridView_myReq.RowHeadersWidth = 62;
            this.dataGridView_myReq.RowTemplate.Height = 28;
            this.dataGridView_myReq.Size = new System.Drawing.Size(1564, 565);
            this.dataGridView_myReq.TabIndex = 13;
            this.dataGridView_myReq.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_myReq_CellContentClick);
            // 
            // comboBox_files
            // 
            this.comboBox_files.FormattingEnabled = true;
            this.comboBox_files.Location = new System.Drawing.Point(839, 730);
            this.comboBox_files.Name = "comboBox_files";
            this.comboBox_files.Size = new System.Drawing.Size(188, 28);
            this.comboBox_files.TabIndex = 14;
            this.comboBox_files.SelectedIndexChanged += new System.EventHandler(this.comboBox_files_SelectedIndexChanged);
            // 
            // button_clearFiles
            // 
            this.button_clearFiles.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_clearFiles.Location = new System.Drawing.Point(1149, 729);
            this.button_clearFiles.Name = "button_clearFiles";
            this.button_clearFiles.Size = new System.Drawing.Size(80, 35);
            this.button_clearFiles.TabIndex = 15;
            this.button_clearFiles.Text = "Clear";
            this.button_clearFiles.UseVisualStyleBackColor = false;
            this.button_clearFiles.Click += new System.EventHandler(this.button_clearFiles_Click);
            // 
            // RequestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1590, 994);
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
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
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