namespace CNPM_ver3
{
    partial class ManageRequestForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageRequestForm));
            this.dataGridView_req = new System.Windows.Forms.DataGridView();
            this.panel_header = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_subject = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_content = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_sender = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button_accept = new System.Windows.Forms.Button();
            this.button_reject = new System.Windows.Forms.Button();
            this.dateTimePicker_sentDay = new System.Windows.Forms.DateTimePicker();
            this.dataGridView_files = new System.Windows.Forms.DataGridView();
            this.textBox_status = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.bunifuDatePicker1 = new Bunifu.UI.WinForms.BunifuDatePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_req)).BeginInit();
            this.panel_header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_files)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_req
            // 
            this.dataGridView_req.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_req.Location = new System.Drawing.Point(8, 62);
            this.dataGridView_req.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView_req.Name = "dataGridView_req";
            this.dataGridView_req.RowHeadersWidth = 62;
            this.dataGridView_req.RowTemplate.Height = 28;
            this.dataGridView_req.Size = new System.Drawing.Size(1044, 269);
            this.dataGridView_req.TabIndex = 0;
            this.dataGridView_req.Click += new System.EventHandler(this.dataGridView_req_Click);
            // 
            // panel_header
            // 
            this.panel_header.BackColor = System.Drawing.Color.Firebrick;
            this.panel_header.Controls.Add(this.label1);
            this.panel_header.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_header.Location = new System.Drawing.Point(0, 0);
            this.panel_header.Name = "panel_header";
            this.panel_header.Size = new System.Drawing.Size(1060, 57);
            this.panel_header.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(366, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(347, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Request Management";
            // 
            // textBox_subject
            // 
            this.textBox_subject.Location = new System.Drawing.Point(40, 393);
            this.textBox_subject.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_subject.Name = "textBox_subject";
            this.textBox_subject.ReadOnly = true;
            this.textBox_subject.Size = new System.Drawing.Size(164, 20);
            this.textBox_subject.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 411);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Subject";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 443);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Content";
            // 
            // textBox_content
            // 
            this.textBox_content.Location = new System.Drawing.Point(11, 458);
            this.textBox_content.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_content.Multiline = true;
            this.textBox_content.Name = "textBox_content";
            this.textBox_content.ReadOnly = true;
            this.textBox_content.Size = new System.Drawing.Size(486, 104);
            this.textBox_content.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(622, 440);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Attach file";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(61, 378);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Sent by";
            // 
            // textBox_sender
            // 
            this.textBox_sender.Location = new System.Drawing.Point(40, 356);
            this.textBox_sender.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_sender.Name = "textBox_sender";
            this.textBox_sender.ReadOnly = true;
            this.textBox_sender.Size = new System.Drawing.Size(164, 20);
            this.textBox_sender.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(629, 378);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Send Day ";
            // 
            // button_accept
            // 
            this.button_accept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button_accept.Location = new System.Drawing.Point(817, 575);
            this.button_accept.Margin = new System.Windows.Forms.Padding(2);
            this.button_accept.Name = "button_accept";
            this.button_accept.Size = new System.Drawing.Size(90, 30);
            this.button_accept.TabIndex = 12;
            this.button_accept.Text = "Accept";
            this.button_accept.UseVisualStyleBackColor = false;
            this.button_accept.Click += new System.EventHandler(this.button_accept_Click);
            // 
            // button_reject
            // 
            this.button_reject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button_reject.Location = new System.Drawing.Point(923, 575);
            this.button_reject.Margin = new System.Windows.Forms.Padding(2);
            this.button_reject.Name = "button_reject";
            this.button_reject.Size = new System.Drawing.Size(90, 30);
            this.button_reject.TabIndex = 13;
            this.button_reject.Text = "Reject";
            this.button_reject.UseVisualStyleBackColor = false;
            this.button_reject.Click += new System.EventHandler(this.button_reject_Click);
            // 
            // dateTimePicker_sentDay
            // 
            this.dateTimePicker_sentDay.Enabled = false;
            this.dateTimePicker_sentDay.Location = new System.Drawing.Point(688, 378);
            this.dateTimePicker_sentDay.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker_sentDay.Name = "dateTimePicker_sentDay";
            this.dateTimePicker_sentDay.Size = new System.Drawing.Size(339, 20);
            this.dateTimePicker_sentDay.TabIndex = 14;
            // 
            // dataGridView_files
            // 
            this.dataGridView_files.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_files.Location = new System.Drawing.Point(688, 440);
            this.dataGridView_files.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView_files.Name = "dataGridView_files";
            this.dataGridView_files.RowHeadersWidth = 62;
            this.dataGridView_files.RowTemplate.Height = 28;
            this.dataGridView_files.Size = new System.Drawing.Size(337, 98);
            this.dataGridView_files.TabIndex = 15;
            this.dataGridView_files.Click += new System.EventHandler(this.dataGridView_files_Click);
            // 
            // textBox_status
            // 
            this.textBox_status.Location = new System.Drawing.Point(306, 393);
            this.textBox_status.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_status.Name = "textBox_status";
            this.textBox_status.ReadOnly = true;
            this.textBox_status.Size = new System.Drawing.Size(164, 20);
            this.textBox_status.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(316, 378);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Status";
            // 
            // bunifuDatePicker1
            // 
            this.bunifuDatePicker1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuDatePicker1.BorderRadius = 1;
            this.bunifuDatePicker1.Color = System.Drawing.Color.Silver;
            this.bunifuDatePicker1.DateBorderThickness = Bunifu.UI.WinForms.BunifuDatePicker.BorderThickness.Thin;
            this.bunifuDatePicker1.DateTextAlign = Bunifu.UI.WinForms.BunifuDatePicker.TextAlign.Left;
            this.bunifuDatePicker1.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuDatePicker1.DisplayWeekNumbers = false;
            this.bunifuDatePicker1.DPHeight = 0;
            this.bunifuDatePicker1.FillDatePicker = false;
            this.bunifuDatePicker1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bunifuDatePicker1.ForeColor = System.Drawing.Color.Black;
            this.bunifuDatePicker1.Icon = ((System.Drawing.Image)(resources.GetObject("bunifuDatePicker1.Icon")));
            this.bunifuDatePicker1.IconColor = System.Drawing.Color.Gray;
            this.bunifuDatePicker1.IconLocation = Bunifu.UI.WinForms.BunifuDatePicker.Indicator.Right;
            this.bunifuDatePicker1.LeftTextMargin = 5;
            this.bunifuDatePicker1.Location = new System.Drawing.Point(766, 396);
            this.bunifuDatePicker1.MinimumSize = new System.Drawing.Size(0, 32);
            this.bunifuDatePicker1.Name = "bunifuDatePicker1";
            this.bunifuDatePicker1.Size = new System.Drawing.Size(220, 32);
            this.bunifuDatePicker1.TabIndex = 18;
            // 
            // ManageRequestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 646);
            this.Controls.Add(this.bunifuDatePicker1);
            this.Controls.Add(this.textBox_status);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dataGridView_files);
            this.Controls.Add(this.dateTimePicker_sentDay);
            this.Controls.Add(this.button_reject);
            this.Controls.Add(this.button_accept);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_sender);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_content);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_subject);
            this.Controls.Add(this.panel_header);
            this.Controls.Add(this.dataGridView_req);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ManageRequestForm";
            this.Text = " n, ygjv n";
            this.Load += new System.EventHandler(this.ManageRequestForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_req)).EndInit();
            this.panel_header.ResumeLayout(false);
            this.panel_header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_files)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_req;
        private System.Windows.Forms.Panel panel_header;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_subject;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_content;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_sender;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_accept;
        private System.Windows.Forms.Button button_reject;
        private System.Windows.Forms.DateTimePicker dateTimePicker_sentDay;
        private System.Windows.Forms.DataGridView dataGridView_files;
        private System.Windows.Forms.TextBox textBox_status;
        private System.Windows.Forms.Label label7;
        private Bunifu.UI.WinForms.BunifuDatePicker bunifuDatePicker1;
    }
}