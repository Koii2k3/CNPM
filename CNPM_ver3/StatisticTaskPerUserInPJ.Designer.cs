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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pieChart1 = new LiveCharts.WinForms.PieChart();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chart_taskState = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chart_stateTaskStatistic = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart_taskState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_stateTaskStatistic)).BeginInit();
            this.SuspendLayout();
            // 
            // pieChart1
            // 
            this.pieChart1.Location = new System.Drawing.Point(31, 36);
            this.pieChart1.Margin = new System.Windows.Forms.Padding(2);
            this.pieChart1.Name = "pieChart1";
            this.pieChart1.Size = new System.Drawing.Size(436, 395);
            this.pieChart1.TabIndex = 1;
            this.pieChart1.Text = "pieChart1";
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(563, 48);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(578, 23);
            this.progressBar2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(560, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Progress of project";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(207, 452);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Task per user";
            // 
            // chart_taskState
            // 
            chartArea1.Name = "ChartArea1";
            this.chart_taskState.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_taskState.Legends.Add(legend1);
            this.chart_taskState.Location = new System.Drawing.Point(589, 100);
            this.chart_taskState.Name = "chart_taskState";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart_taskState.Series.Add(series1);
            this.chart_taskState.Size = new System.Drawing.Size(538, 290);
            this.chart_taskState.TabIndex = 7;
            this.chart_taskState.Text = "chart1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(805, 403);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Progress of each task";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(668, 808);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Progress of each task";
            // 
            // chart_stateTaskStatistic
            // 
            chartArea2.Name = "ChartArea1";
            this.chart_stateTaskStatistic.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart_stateTaskStatistic.Legends.Add(legend2);
            this.chart_stateTaskStatistic.Location = new System.Drawing.Point(341, 436);
            this.chart_stateTaskStatistic.Name = "chart_stateTaskStatistic";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart_stateTaskStatistic.Series.Add(series2);
            this.chart_stateTaskStatistic.Size = new System.Drawing.Size(538, 290);
            this.chart_stateTaskStatistic.TabIndex = 9;
            this.chart_stateTaskStatistic.Text = "chart1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(522, 740);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Task state statistics";
            // 
            // StatisticTaskPerUserInPJ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1247, 801);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chart_stateTaskStatistic);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chart_taskState);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.pieChart1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "StatisticTaskPerUserInPJ";
            this.Text = "StatisticTaskPerUserInPJ";
            this.Load += new System.EventHandler(this.StatisticTaskPerUserInPJ_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart_taskState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_stateTaskStatistic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private LiveCharts.WinForms.PieChart pieChart1;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_taskState;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_stateTaskStatistic;
        private System.Windows.Forms.Label label5;
    }
}