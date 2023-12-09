namespace CNPM_ver3
{
    partial class AddTaskForm
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
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_desc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePicker_exp = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePicker_end = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_start = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.button_add = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(382, 257);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(385, 26);
            this.textBox_name.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(289, 260);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Task name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(252, 310);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Task description";
            // 
            // textBox_desc
            // 
            this.textBox_desc.Location = new System.Drawing.Point(382, 307);
            this.textBox_desc.Multiline = true;
            this.textBox_desc.Name = "textBox_desc";
            this.textBox_desc.Size = new System.Drawing.Size(385, 103);
            this.textBox_desc.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(800, 379);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 20);
            this.label3.TabIndex = 112;
            this.label3.Text = "Expect";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(816, 378);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 20);
            this.label7.TabIndex = 111;
            // 
            // dateTimePicker_exp
            // 
            this.dateTimePicker_exp.Location = new System.Drawing.Point(866, 379);
            this.dateTimePicker_exp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePicker_exp.Name = "dateTimePicker_exp";
            this.dateTimePicker_exp.Size = new System.Drawing.Size(408, 26);
            this.dateTimePicker_exp.TabIndex = 110;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(821, 318);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 20);
            this.label6.TabIndex = 109;
            this.label6.Text = "End";
            // 
            // dateTimePicker_end
            // 
            this.dateTimePicker_end.Location = new System.Drawing.Point(866, 319);
            this.dateTimePicker_end.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePicker_end.Name = "dateTimePicker_end";
            this.dateTimePicker_end.Size = new System.Drawing.Size(408, 26);
            this.dateTimePicker_end.TabIndex = 108;
            // 
            // dateTimePicker_start
            // 
            this.dateTimePicker_start.Location = new System.Drawing.Point(866, 254);
            this.dateTimePicker_start.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePicker_start.Name = "dateTimePicker_start";
            this.dateTimePicker_start.Size = new System.Drawing.Size(408, 26);
            this.dateTimePicker_start.TabIndex = 106;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(816, 253);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 20);
            this.label5.TabIndex = 107;
            this.label5.Text = "Start";
            // 
            // button_add
            // 
            this.button_add.BackColor = System.Drawing.Color.Firebrick;
            this.button_add.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_add.Location = new System.Drawing.Point(1127, 430);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(147, 47);
            this.button_add.TabIndex = 113;
            this.button_add.Text = "Add";
            this.button_add.UseVisualStyleBackColor = false;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // AddTaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1566, 851);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dateTimePicker_exp);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dateTimePicker_end);
            this.Controls.Add(this.dateTimePicker_start);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_desc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_name);
            this.Name = "AddTaskForm";
            this.Text = "AddTaskForm";
            this.Load += new System.EventHandler(this.AddTaskForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_desc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePicker_exp;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePicker_end;
        private System.Windows.Forms.DateTimePicker dateTimePicker_start;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_add;
    }
}