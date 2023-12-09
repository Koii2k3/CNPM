namespace CNPM_ver3
{
    partial class NotiForm
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
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_receiverOfNoti = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView_sendNoti = new System.Windows.Forms.DataGridView();
            this.dateTimePicker_sendDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_sender = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_content = new System.Windows.Forms.TextBox();
            this.dataGridView_receiveNoti = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_sendNoti)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_receiveNoti)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(571, 240);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Receiver";
            // 
            // comboBox_receiverOfNoti
            // 
            this.comboBox_receiverOfNoti.FormattingEnabled = true;
            this.comboBox_receiverOfNoti.Location = new System.Drawing.Point(673, 240);
            this.comboBox_receiverOfNoti.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_receiverOfNoti.Name = "comboBox_receiverOfNoti";
            this.comboBox_receiverOfNoti.Size = new System.Drawing.Size(269, 21);
            this.comboBox_receiverOfNoti.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(152, 148);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Receive";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(152, 350);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Send";
            // 
            // dataGridView_sendNoti
            // 
            this.dataGridView_sendNoti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_sendNoti.Location = new System.Drawing.Point(155, 371);
            this.dataGridView_sendNoti.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView_sendNoti.Name = "dataGridView_sendNoti";
            this.dataGridView_sendNoti.RowHeadersWidth = 62;
            this.dataGridView_sendNoti.RowTemplate.Height = 28;
            this.dataGridView_sendNoti.Size = new System.Drawing.Size(399, 187);
            this.dataGridView_sendNoti.TabIndex = 17;
            // 
            // dateTimePicker_sendDate
            // 
            this.dateTimePicker_sendDate.Location = new System.Drawing.Point(673, 207);
            this.dateTimePicker_sendDate.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker_sendDate.Name = "dateTimePicker_sendDate";
            this.dateTimePicker_sendDate.Size = new System.Drawing.Size(266, 20);
            this.dateTimePicker_sendDate.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(571, 207);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Send date";
            // 
            // textBox_sender
            // 
            this.textBox_sender.Location = new System.Drawing.Point(673, 172);
            this.textBox_sender.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_sender.Name = "textBox_sender";
            this.textBox_sender.Size = new System.Drawing.Size(269, 20);
            this.textBox_sender.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(571, 172);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Sender";
            // 
            // textBox_content
            // 
            this.textBox_content.Location = new System.Drawing.Point(574, 270);
            this.textBox_content.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_content.Multiline = true;
            this.textBox_content.Name = "textBox_content";
            this.textBox_content.Size = new System.Drawing.Size(459, 289);
            this.textBox_content.TabIndex = 12;
            // 
            // dataGridView_receiveNoti
            // 
            this.dataGridView_receiveNoti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_receiveNoti.Location = new System.Drawing.Point(155, 170);
            this.dataGridView_receiveNoti.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView_receiveNoti.Name = "dataGridView_receiveNoti";
            this.dataGridView_receiveNoti.RowHeadersWidth = 62;
            this.dataGridView_receiveNoti.RowTemplate.Height = 28;
            this.dataGridView_receiveNoti.Size = new System.Drawing.Size(399, 171);
            this.dataGridView_receiveNoti.TabIndex = 11;
            this.dataGridView_receiveNoti.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_receiveNoti_Click);
            // 
            // NotiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1185, 706);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox_receiverOfNoti);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView_sendNoti);
            this.Controls.Add(this.dateTimePicker_sendDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_sender);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_content);
            this.Controls.Add(this.dataGridView_receiveNoti);
            this.Name = "NotiForm";
            this.Text = "NotiForm";
            this.Load += new System.EventHandler(this.NotiForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_sendNoti)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_receiveNoti)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_receiverOfNoti;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView_sendNoti;
        private System.Windows.Forms.DateTimePicker dateTimePicker_sendDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_sender;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_content;
        private System.Windows.Forms.DataGridView dataGridView_receiveNoti;
    }
}