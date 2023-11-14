using BLLL;
using DTOO;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace CNPM_ver3
{
    public partial class StatisticTaskPerUserInPJ : Form
    {
        String cur_pjID;
        ProjectBLL pj = new ProjectBLL();
        TaskBLL task_access = new TaskBLL();
        public StatisticTaskPerUserInPJ(String pjID)
        {
            cur_pjID = pjID;
            InitializeComponent();
        }

        Func<ChartPoint, string> labelPoint = chartpoint => string.Format("{0} ({1:P})", chartpoint.Y, chartpoint.Participation);

        private void showStatistic()
        {
            SeriesCollection series = new SeriesCollection();
            DataTable dt = pj.GetTaskPerUser(cur_pjID);
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (row != null)
                    {
                        //series.Add(new PieSeries() { Title = row.Cells["USER_ID"].Value.ToString(), Values = new ChartValues<int> { Int32.Parse(row.Cells["QUANTITY"].Value.ToString()) }, DataLabels = true, LabelPoint = labelPoint });
                        series.Add(new PieSeries() { Title = row["USER_ID"].ToString(), Values = new ChartValues<int> { Int32.Parse(row["QUANTITY"].ToString()) }, DataLabels = true, LabelPoint = labelPoint });
                    }
                }
                pieChart1.Series = series;
            } else
            {
                MessageBox.Show("Null return");
            }
        }

        private void StatisticTaskPerUserInPJ_Load(object sender, EventArgs e)
        {
            pieChart1.LegendLocation = LegendLocation.Bottom;
            showStatistic();
            showTaskProcess();

            // chart_taskState
        }
        
        private void showTaskProcess()
        {
            SeriesCollection series = new SeriesCollection();
            DataTable allTasks = task_access.GetTaskOfProject(cur_pjID);
            DataTable allProcess = new DataTable();

            foreach (DataRow row in allTasks.Rows)
            {
                if (row != null)
                {
                    DataTable process = task_access.GetTaskProcess(row["J_ID"].ToString());

                    foreach (DataRow pr in process.Rows)
                    {
                        if (pr != null)
                        {
                            allProcess.Rows.Add(pr);
                            //series.Add(new PieSeries() { Title = row.Cells["USER_ID"].Value.ToString(), Values = new ChartValues<int> { Int32.Parse(row.Cells["QUANTITY"].Value.ToString()) }, DataLabels = true, LabelPoint = labelPoint });
                        }
                    }
                    //series.Add(new PieSeries() { Title = row.Cells["USER_ID"].Value.ToString(), Values = new ChartValues<int> { Int32.Parse(row.Cells["QUANTITY"].Value.ToString()) }, DataLabels = true, LabelPoint = labelPoint });
                }
            }
            chart_taskState.DataSource = allProcess;
        }

        private void showTaskState()
        {
            SeriesCollection series = new SeriesCollection();
            DataTable allTasks = task_access.GetTaskOfProject(cur_pjID);
            DataTable allProcess = new DataTable();

            foreach (DataRow row in allTasks.Rows)
            {
                if (row != null)
                {
                    DataTable process = task_access.GetTaskProcess(row["J_ID"].ToString());

                    foreach (DataRow pr in process.Rows)
                    {
                        if (pr != null)
                        {
                            allProcess.Rows.Add(pr);
                            //series.Add(new PieSeries() { Title = row.Cells["USER_ID"].Value.ToString(), Values = new ChartValues<int> { Int32.Parse(row.Cells["QUANTITY"].Value.ToString()) }, DataLabels = true, LabelPoint = labelPoint });
                        }
                    }
                    //series.Add(new PieSeries() { Title = row.Cells["USER_ID"].Value.ToString(), Values = new ChartValues<int> { Int32.Parse(row.Cells["QUANTITY"].Value.ToString()) }, DataLabels = true, LabelPoint = labelPoint });
                }
            }
            chart_taskState.DataSource = allProcess;
        }

    }
}
