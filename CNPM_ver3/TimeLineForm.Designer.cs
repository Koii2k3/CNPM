namespace CNPM_ver3
{
    partial class TimeLineForm
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
            this.weekStartDatePicker = new System.Windows.Forms.DateTimePicker();
            this.button_1 = new System.Windows.Forms.Button();
            this.button = new System.Windows.Forms.Button();
            this.dgv_timeline = new System.Windows.Forms.DataGridView();
            this.button_today = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_timeline)).BeginInit();
            this.SuspendLayout();
            // 
            // weekStartDatePicker
            // 
            this.weekStartDatePicker.Location = new System.Drawing.Point(324, 13);
            this.weekStartDatePicker.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.weekStartDatePicker.Name = "weekStartDatePicker";
            this.weekStartDatePicker.Size = new System.Drawing.Size(198, 20);
            this.weekStartDatePicker.TabIndex = 8;
            this.weekStartDatePicker.ValueChanged += new System.EventHandler(this.dtpk_timeline_changed);
            // 
            // button_1
            // 
            this.button_1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.button_1.Location = new System.Drawing.Point(214, 11);
            this.button_1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_1.Name = "button_1";
            this.button_1.Size = new System.Drawing.Size(91, 22);
            this.button_1.TabIndex = 7;
            this.button_1.Text = "Previous week";
            this.button_1.UseVisualStyleBackColor = false;
            this.button_1.Click += new System.EventHandler(this.button_1_Click);
            // 
            // button
            // 
            this.button.BackColor = System.Drawing.SystemColors.ControlDark;
            this.button.Location = new System.Drawing.Point(615, 7);
            this.button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(92, 24);
            this.button.TabIndex = 6;
            this.button.Text = "Next week";
            this.button.UseVisualStyleBackColor = false;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // dgv_timeline
            // 
            this.dgv_timeline.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_timeline.Location = new System.Drawing.Point(9, 38);
            this.dgv_timeline.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgv_timeline.Name = "dgv_timeline";
            this.dgv_timeline.RowHeadersWidth = 62;
            this.dgv_timeline.RowTemplate.Height = 28;
            this.dgv_timeline.Size = new System.Drawing.Size(874, 388);
            this.dgv_timeline.TabIndex = 5;
            // 
            // button_today
            // 
            this.button_today.BackColor = System.Drawing.SystemColors.ControlDark;
            this.button_today.Location = new System.Drawing.Point(525, 9);
            this.button_today.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_today.Name = "button_today";
            this.button_today.Size = new System.Drawing.Size(67, 24);
            this.button_today.TabIndex = 9;
            this.button_today.Text = "Today";
            this.button_today.UseVisualStyleBackColor = false;
            this.button_today.Click += new System.EventHandler(this.button_today_Click);
            // 
            // TimeLineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 442);
            this.Controls.Add(this.button_today);
            this.Controls.Add(this.weekStartDatePicker);
            this.Controls.Add(this.button_1);
            this.Controls.Add(this.button);
            this.Controls.Add(this.dgv_timeline);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "TimeLineForm";
            this.Text = "Timeline";
            this.Load += new System.EventHandler(this.Timeline_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_timeline)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DateTimePicker weekStartDatePicker;
        private System.Windows.Forms.Button button_1;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.DataGridView dgv_timeline;
        private System.Windows.Forms.Button button_today;
    }
}