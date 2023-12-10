namespace CNPM_ver3
{
    partial class StatisticTaskPerUserInPJ
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.button_update = new System.Windows.Forms.Button();
            this.button_addMember = new System.Windows.Forms.Button();
            this.button_addTask = new System.Windows.Forms.Button();
            this.label_noTasks = new System.Windows.Forms.Label();
            this.dataGridView_projectTasks = new System.Windows.Forms.DataGridView();
            this.label_detailProgress = new System.Windows.Forms.Label();
            this.chart_stateTask = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label4 = new System.Windows.Forms.Label();
            this.chart_taskProgress = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar_pj = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_projectTasks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_stateTask)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_taskProgress)).BeginInit();
            this.SuspendLayout();
            // 
            // button_update
            // 
            this.button_update.BackColor = System.Drawing.Color.SteelBlue;
            this.button_update.Location = new System.Drawing.Point(1059, 509);
            this.button_update.Margin = new System.Windows.Forms.Padding(2);
            this.button_update.Name = "button_update";
            this.button_update.Size = new System.Drawing.Size(94, 38);
            this.button_update.TabIndex = 30;
            this.button_update.Text = "Update project";
            this.button_update.UseVisualStyleBackColor = false;
            // 
            // button_addMember
            // 
            this.button_addMember.BackColor = System.Drawing.Color.SandyBrown;
            this.button_addMember.Location = new System.Drawing.Point(1059, 551);
            this.button_addMember.Margin = new System.Windows.Forms.Padding(2);
            this.button_addMember.Name = "button_addMember";
            this.button_addMember.Size = new System.Drawing.Size(94, 38);
            this.button_addMember.TabIndex = 29;
            this.button_addMember.Text = "Add member";
            this.button_addMember.UseVisualStyleBackColor = false;
            this.button_addMember.Click += new System.EventHandler(this.button_addMember_Click);
            // 
            // button_addTask
            // 
            this.button_addTask.BackColor = System.Drawing.Color.OrangeRed;
            this.button_addTask.Location = new System.Drawing.Point(1163, 551);
            this.button_addTask.Margin = new System.Windows.Forms.Padding(2);
            this.button_addTask.Name = "button_addTask";
            this.button_addTask.Size = new System.Drawing.Size(93, 38);
            this.button_addTask.TabIndex = 28;
            this.button_addTask.Text = "Add task";
            this.button_addTask.UseVisualStyleBackColor = false;
            this.button_addTask.Click += new System.EventHandler(this.button_addTask_Click);
            // 
            // label_noTasks
            // 
            this.label_noTasks.AutoSize = true;
            this.label_noTasks.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_noTasks.Location = new System.Drawing.Point(541, 104);
            this.label_noTasks.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_noTasks.Name = "label_noTasks";
            this.label_noTasks.Size = new System.Drawing.Size(262, 26);
            this.label_noTasks.TabIndex = 27;
            this.label_noTasks.Text = "No any task for statistic";
            this.label_noTasks.Visible = false;
            // 
            // dataGridView_projectTasks
            // 
            this.dataGridView_projectTasks.AllowDrop = true;
            this.dataGridView_projectTasks.AllowUserToAddRows = false;
            this.dataGridView_projectTasks.AllowUserToDeleteRows = false;
            this.dataGridView_projectTasks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_projectTasks.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_projectTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_projectTasks.Location = new System.Drawing.Point(109, 323);
            this.dataGridView_projectTasks.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView_projectTasks.Name = "dataGridView_projectTasks";
            this.dataGridView_projectTasks.RowHeadersWidth = 62;
            this.dataGridView_projectTasks.RowTemplate.Height = 28;
            this.dataGridView_projectTasks.Size = new System.Drawing.Size(911, 299);
            this.dataGridView_projectTasks.TabIndex = 26;
            this.dataGridView_projectTasks.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_projectTasks_Click);
            // 
            // label_detailProgress
            // 
            this.label_detailProgress.AutoSize = true;
            this.label_detailProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_detailProgress.Location = new System.Drawing.Point(474, 257);
            this.label_detailProgress.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_detailProgress.Name = "label_detailProgress";
            this.label_detailProgress.Size = new System.Drawing.Size(39, 20);
            this.label_detailProgress.TabIndex = 25;
            this.label_detailProgress.Text = "0 %";
            // 
            // chart_stateTask
            // 
            chartArea1.Name = "ChartArea1";
            this.chart_stateTask.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_stateTask.Legends.Add(legend1);
            this.chart_stateTask.Location = new System.Drawing.Point(899, 11);
            this.chart_stateTask.Name = "chart_stateTask";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "TaskState";
            this.chart_stateTask.Series.Add(series1);
            this.chart_stateTask.Size = new System.Drawing.Size(342, 188);
            this.chart_stateTask.TabIndex = 24;
            this.chart_stateTask.Text = "chart1";
            title1.Name = "Title1";
            title1.Text = "Task State";
            this.chart_stateTask.Titles.Add(title1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(781, 726);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Progress of each task";
            // 
            // chart_taskProgress
            // 
            chartArea2.Name = "ChartArea1";
            this.chart_taskProgress.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart_taskProgress.Legends.Add(legend2);
            this.chart_taskProgress.Location = new System.Drawing.Point(411, 11);
            this.chart_taskProgress.Name = "chart_taskProgress";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series2.Legend = "Legend1";
            series2.Name = "Tasks";
            this.chart_taskProgress.Series.Add(series2);
            this.chart_taskProgress.Size = new System.Drawing.Size(390, 188);
            this.chart_taskProgress.TabIndex = 22;
            this.chart_taskProgress.Text = "chart1";
            title2.Name = "Title1";
            title2.Text = "Task Progress Statistic";
            this.chart_taskProgress.Titles.Add(title2);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(335, 261);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Progress of project";
            // 
            // progressBar_pj
            // 
            this.progressBar_pj.Location = new System.Drawing.Point(338, 230);
            this.progressBar_pj.Name = "progressBar_pj";
            this.progressBar_pj.Size = new System.Drawing.Size(911, 18);
            this.progressBar_pj.TabIndex = 19;
            // 
            // StatisticTaskPerUserInPJ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1385, 826);
            this.Controls.Add(this.button_update);
            this.Controls.Add(this.button_addMember);
            this.Controls.Add(this.button_addTask);
            this.Controls.Add(this.label_noTasks);
            this.Controls.Add(this.dataGridView_projectTasks);
            this.Controls.Add(this.label_detailProgress);
            this.Controls.Add(this.chart_stateTask);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chart_taskProgress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar_pj);
            this.Name = "StatisticTaskPerUserInPJ";
            this.Text = "StatisticTaskPerUserInPJ";
            this.Load += new System.EventHandler(this.StatisticTaskPerUserInPJ_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_projectTasks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_stateTask)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_taskProgress)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_update;
        private System.Windows.Forms.Button button_addMember;
        private System.Windows.Forms.Button button_addTask;
        private System.Windows.Forms.Label label_noTasks;
        private System.Windows.Forms.DataGridView dataGridView_projectTasks;
        private System.Windows.Forms.Label label_detailProgress;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_stateTask;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_taskProgress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar_pj;
    }
}