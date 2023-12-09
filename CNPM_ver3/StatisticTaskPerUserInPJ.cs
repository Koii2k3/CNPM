using BLL;
using BLLL;
using DTOO;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNPM_ver3
{
    public partial class StatisticTaskPerUserInPJ : Form
    {
        String curPjName;
        String curPjID;
        ProjectBLL pj = new ProjectBLL();
        UserBLL user_access = new UserBLL();
        TaskBLL task_access = new TaskBLL();
        DataRow curPj ;


        public StatisticTaskPerUserInPJ(DataRow curPj)
        { 
            this.curPj = curPj;

            curPjID = curPj["PJ_ID"].ToString();
            curPjName = curPj["PJ_NAME"].ToString();

            InitializeComponent();
        }



        private void StatisticTaskPerUserInPJ_Load(object sender, EventArgs e)
        {
            // Remove grid from chart
            chart_taskProgress.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chart_taskProgress.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            chart_taskProgress.ChartAreas[0].AxisY.Maximum = 100;

            chart_stateTask.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chart_stateTask.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            chart_stateTask.ChartAreas[0].AxisY.Interval = 1;
            chart_stateTask.ChartAreas[0].AxisY.IntervalOffset = 0;


            showTaskProcess();
            showTaskState();
            showProgressBarPJ();

            dataGridView_projectTasks.EnableHeadersVisualStyles = false;
            dataGridView_projectTasks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView_projectTasks.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue;
            showAllTaskInProject();

        }

        public void showAllTaskInProject()
        {
            // dataGridView_projectTasks.ReadOnly = true;
            DataTable allTasks = task_access.GetTaskOfProject(curPjID);
            dataGridView_projectTasks.DataSource = allTasks;


            if (allTasks != null)
            {
                int i = 0;
                foreach (DataRow row in allTasks.Rows)
                {
                    DataTable subTasks = task_access.GetAllSubTaskOfTask(row["J_ID"].ToString(), -1);
                    DataGridViewComboBoxCell task = new DataGridViewComboBoxCell();
                    task.Items.Add(row["J_NAME"]);

                    if (subTasks != null)
                    {
                        foreach (DataRow sTask in subTasks.Rows)
                        {
                            //Create comboBox
                            task.Items.Add(sTask["SJ_NAME"]);
                        }

                        dataGridView_projectTasks.Rows[i].Cells["J_NAME"] = task;
                    }
                    i += 1;
                }
            }
        }

        private void showTaskProcess()
        {
            // Định chỉ show những task chưa hoàn thành thôi, vì nếu hoàn thành rồi thống kê
            // vào luôn sẽ chiếm nhiều space

            DataTable allTasks = task_access.GetTaskOfProject(curPjID);
            if (allTasks != null)
            {
                foreach (DataRow row in allTasks.Rows)
                {
                    if (row != null)
                    {
                        DataTable process = task_access.GetTaskProcess(row["J_ID"].ToString());

                        foreach (DataRow pr in process.Rows)
                        {
                            if (pr != null)
                            {
                                if (Int32.Parse(pr["PERCENT"].ToString()) < 1)
                                {
                                    pr["PERCENT"] = 1;
                                }

                                String taskName = task_access.GetTaskInfo(pr["J_ID"].ToString())["J_NAME"].ToString();
                                chart_taskProgress.Series["Tasks"].Points.AddXY(taskName, pr["PERCENT"]);
                            }
                        }
                    }
                }
            }
        }

        private void showTaskState()
        {
            DataTable allTasks = pj.GetStateJobsInProject(curPjID);

            foreach (DataRow row in allTasks.Rows)
            {
                if (row != null)
                {
                    chart_stateTask.Series["TaskState"].Points.AddXY("New task", row["NEW_TASK"]);
                    chart_stateTask.Series["TaskState"].Points.AddXY("Processing task", row["PROCESSING_TASK"]);
                    chart_stateTask.Series["TaskState"].Points.AddXY("Done task", row["DONE_TASK"]);
                }
            }
        }

        private void showProgressBarPJ()
        {
            float floatProgress = 0;
            try
            {
                floatProgress = float.Parse(pj.GetProjectProgress(curPjID)["PJ_PROCESS"].ToString());

            }
            catch
            {
                MessageBox.Show(pj.GetProjectProgress(curPjID)["PJ_PROCESS"].ToString());
            }

            label_detailProgress.Text = String.Format("{0:0.00}", floatProgress) + " %";


            int pjProgress = (int)Math.Round(floatProgress);
            progressBar_pj.Value = pjProgress;

        }


        private void button_addTask_Click(object sender, EventArgs e)
        {
            //AssignTaskForm taskInfoForm = new AssignTaskForm(this.curPj);
            //taskInfoForm.ShowDialog();
        }

        private void button_addMember_Click(object sender, EventArgs e)
        {
            AddMember2Project form = new AddMember2Project(curPjID);
            form.ShowDialog();
        }

        private void dataGridView_projectTasks_Click(object sender, DataGridViewCellEventArgs e)
        {
            String selectedTaskID = dataGridView_projectTasks.CurrentRow.Cells["J_ID"].Value.ToString();
            String selectedPjName = dataGridView_projectTasks.CurrentRow.Cells["J_NAME"].Value.ToString();
            //AssignTaskForm taskInfoForm = new AssignTaskForm(this.curPj, taskInfoShow: true, selectedTaskID);
            //taskInfoForm.ShowDialog();
        }
    }
}
