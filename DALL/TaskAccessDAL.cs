﻿using MySql.Data.MySqlClient;
using System;
using System.Data;


namespace DALL
{
    /*        DAL layer is to encapsulate the data access code and provide a standardized interface for
            performing CRUD(Create, Read, Update, Delete) operations on the underlying database.It
            ensures separation of concerns by isolating the database-specific operations from the rest
            of the application.*/

    // Inherit from DataAccessDAL for database connection
    public class TaskAccessDAL : DataAccessDAL
    {
        // Get task information
        public DataRow GetTaskInfo(string taskID)
        {
            MySqlCommand command = new MySqlCommand("CALL GET_INFO_JOB(@taskID)", con);
            command.Parameters.Add("@taskID", MySqlDbType.VarChar).Value = taskID;

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return table.Rows[0];
            }
            else
            {
                return null;
            }
        }

        // Get all task in a specific project of user
        public DataTable GetJobInProjectOfUser(String userID, String pjID)
        {
            String query = String.Format("call GET_JOU(@userID, @pjID)");
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.Add("@userID", MySqlDbType.VarChar).Value = userID;
            command.Parameters.Add("@pjID", MySqlDbType.VarChar).Value = pjID;

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return table;
            }
            else
            {
                return null;
            }
        }

        // Get all task in a specific project of user
        public DataTable GetTaskOfProject(String pjID)
        {
            String query = String.Format("call GET_J_OF_PJ(@pjID)");
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.Add("@pjID", MySqlDbType.VarChar).Value = pjID;

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return table;
            }
            else
            {
                return null;
            }
        }

        // Get list of task having a specific status
        public DataTable GetTaskWithStatus(String pjID, int taskState)
        {
            String query = String.Format("call GET_JOB_WITH_STATUS(@pjID, @taskState)");
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.Add("@pjID", MySqlDbType.VarChar).Value = pjID;
            command.Parameters.Add("@taskState", MySqlDbType.Int32).Value = taskState;

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return table;
            }
            else
            {
                return null;
            }
        }

        // Get list of task having a specific status
        public DataTable GetAllTaskOfUser(String uID)
        {
            String query = String.Format("call GET_JOU_ALL(@uID)");
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.Add("@uID", MySqlDbType.VarChar).Value = uID;

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return table;
            }
            else
            {
                return null;
            }
        }

        // Assign task for user
        public bool AddUserToTask(string jobID, string userID)
        {
            MySqlCommand command = new MySqlCommand("SELECT ADD_J_MEMBER (@jobID, @uID) as Result", con);

            command.Parameters.Add("@jobID", MySqlDbType.VarChar).Value = jobID;
            command.Parameters.Add("@uID", MySqlDbType.VarChar).Value = userID;

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();

            adapter.Fill(table);

            int i = 0;
            foreach (DataRow row in table.Rows)
            {
                string r = row["Result"].ToString();
                i = Int32.Parse(r);
            }

            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Get assignees of task
        public DataTable GetUserOfTask(string taskID)
        {
            String query = String.Format("call GET_USER_OF_JOB(@taskID)");
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.Add("@taskID", MySqlDbType.VarChar).Value = taskID;

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return table;
            }
            else
            {
                return null;
            }
        }

        // Add new task
        public bool InsertTask(string name, string desc, DateTime? exp, DateTime? start, DateTime? end, string isHL, string status, string pjID)
        {
            MySqlCommand command = new MySqlCommand("SELECT ADD_JOB (@name, @desc, @exp, @start, @end, @isHL, @status, @pjID) as Result", con);

            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@desc", MySqlDbType.VarChar).Value = desc;
            command.Parameters.Add("@exp", MySqlDbType.Date).Value = exp;
            command.Parameters.Add("@start", MySqlDbType.Date).Value = start;
            command.Parameters.Add("@end", MySqlDbType.Date).Value = end;
            command.Parameters.Add("@isHL", MySqlDbType.Int32).Value = Int32.Parse(isHL);
            command.Parameters.Add("@status", MySqlDbType.VarChar).Value = status;
            command.Parameters.Add("@pjID", MySqlDbType.VarChar).Value = pjID;

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();

            adapter.Fill(table);

            int i = 0;
            foreach (DataRow row in table.Rows)
            {
                string r = row["Result"].ToString();
                i = Int32.Parse(r);
            }

            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Attach file for task
        public void AddFileForTask(String taskID, String assigneeID, String file_name, byte[] file)
        {
            String query = String.Format("select ADD_JOB_RESOURCE_FILE(@taskID, @assigneeID, @file_name, @file) as Result");
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.Add("@taskID", MySqlDbType.VarChar).Value = taskID;
            command.Parameters.Add("@assigneeID", MySqlDbType.VarChar).Value = assigneeID;
            command.Parameters.Add("@file_name", MySqlDbType.VarChar).Value = file_name;
            command.Parameters.Add("@file", MySqlDbType.LongBlob).Value = file;

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
        }

        // Add subtask for a task
        public void AddSubtask(String taskID, String subTaskName)
        {
            // Check subtask having same name in BLL later
            String query = String.Format("select ADD_SUB_JOB(@taskID, @subTaskName)");
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.Add("@taskID", MySqlDbType.VarChar).Value = taskID;
            command.Parameters.Add("@subTaskName", MySqlDbType.VarChar).Value = subTaskName;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
        }

        // Add task without finish day (the day user submit task)
        public String InsertTask1(String taskName, String taskDesc, DateTime start, DateTime end,
                                int isHL, String taskState, String pjID)
        {
            MySqlCommand command = new MySqlCommand("SELECT ADD_JOB_WITHOUT_FINISH_DAY (@name, @desc, @start, @end, @isHL, @status, @pjID) as Result", con);

            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = taskName;
            command.Parameters.Add("@desc", MySqlDbType.VarChar).Value = taskDesc;
            command.Parameters.Add("@start", MySqlDbType.Date).Value = start;
            command.Parameters.Add("@end", MySqlDbType.Date).Value = end;
            command.Parameters.Add("@isHL", MySqlDbType.Int32).Value = isHL;
            command.Parameters.Add("@status", MySqlDbType.VarChar).Value = taskState;
            command.Parameters.Add("@pjID", MySqlDbType.VarChar).Value = pjID;

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();

            adapter.Fill(table);

            string taskID = "-1";
            foreach (DataRow row in table.Rows)
            {
                taskID = row["Result"].ToString();
            }
            return taskID;
        }

        // Get task's progress
        public DataTable GetTaskProcess(String jobID)
        {
            String query = String.Format("call GET_ONE_JOB_PROCESS(@jobID)");
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.Add("@jobID", MySqlDbType.VarChar).Value = jobID;

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return table;
            }
            else
            {
                return null;
            }
        }

        // Get task's progress
        public DataTable GetAllSubTaskOfTask(String taskID, int subTaskState)
        {
            String query = String.Format("call GET_ALL_SUB_JOB(@taskID, @subTaskState)");
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.Add("@taskID", MySqlDbType.VarChar).Value = taskID;
            command.Parameters.Add("@subTaskState", MySqlDbType.Int32).Value = subTaskState;

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return table;
            }
            else
            {
                return null;
            }
        }

        // Get resource of task (which manager provide when he/she assign task)
        public DataTable GetResourceOfTask(String taskID)
        {
            String query = String.Format("call GET_RESOURCE_FILE_OF_MANAGER(@taskID)");
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.Add("@taskID", MySqlDbType.VarChar).Value = taskID;

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return table;
            }
            else
            {
                return null;
            }
        }

        // Get list of file user submit for the task
        public DataTable GetSubmitFileOfTask(String taskID)
        {
            String query = String.Format("call GET_RESOURCE_FILE_OF_USER(@taskID)");
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.Add("@taskID", MySqlDbType.VarChar).Value = taskID;

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return table;
            }
            else
            {
                return null;
            }
        }

        // Submit subtask
        public bool SubmitSubtask(String subtaskID)
        {
            MySqlCommand command = new MySqlCommand("SELECT UPDATE_SUB_JOB_DONE(@subtaskID) as Result", con);
            command.Parameters.Add("@subtaskID", MySqlDbType.VarChar).Value = subtaskID;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            foreach (DataRow row in table.Rows)
            {
                int i = Int32.Parse(row["Result"].ToString());
                if (i > 0)
                {
                    return true;
                }
            }
            return false;
        }

        // Update task infomation
        public bool UpdateTask(String taskID, String taskName, String taskDesc,
            DateTime start, DateTime deadline, DateTime? finish, int taskHL, String taskState)
        {
            MySqlCommand command = new MySqlCommand("SELECT UPDATE_JOB(@taskID, @taskName, " +
                "@taskDesc, @start, @deadline, @finish, @taskHL, @taskState) as Result", con);
            command.Parameters.Add("@taskID", MySqlDbType.VarChar).Value = taskID;
            command.Parameters.Add("@taskName", MySqlDbType.VarChar).Value = taskName;
            command.Parameters.Add("@taskDesc", MySqlDbType.VarChar).Value = taskDesc;
            command.Parameters.Add("@start", MySqlDbType.Date).Value = start;
            command.Parameters.Add("@deadline", MySqlDbType.Date).Value = deadline;
            command.Parameters.Add("@finish", MySqlDbType.Date).Value = finish;
            command.Parameters.Add("@taskHL", MySqlDbType.Int32).Value = taskHL;
            command.Parameters.Add("@taskState", MySqlDbType.VarChar).Value = taskState;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            foreach (DataRow row in table.Rows)
            {
                int i = Int32.Parse(row["Result"].ToString());
                if (i > 0)
                {
                    return true;
                }
            }
            return false;
        }

        // Delete task
        public bool DeleteTask(String taskID)
        {
            MySqlCommand command = new MySqlCommand("SELECT DEL_JOB(@taskID) as Result", con);
            command.Parameters.Add("@taskID", MySqlDbType.VarChar).Value = taskID;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            foreach (DataRow row in table.Rows)
            {
                int i = Int32.Parse(row["Result"].ToString());
                if (i > 0)
                {
                    return true;
                }
            }
            return false;
        }

        // Get the percentage of task with state (task close to deadline) 
        public DataRow GetTaskHLPercent(string pjId, int hl)
        {
            MySqlCommand command = new MySqlCommand("CALL GET_PERCENT_HL(@pjId, @hl)", con);
            command.Parameters.Add("@pjId", MySqlDbType.VarChar).Value = pjId;
            command.Parameters.Add("@hl", MySqlDbType.VarChar).Value = hl;

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return table.Rows[0];
            }
            else
            {
                return null;
            }
        }

        // Filter task from start date input onwards
        public DataTable GetTaskWithStartDate(String pjID, DateTime startDate)
        {
            String query = String.Format("call GET_J_OF_PJ_START_AFTER (@pjID, @startDate)");
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.Add("@pjID", MySqlDbType.VarChar).Value = pjID;
            command.Parameters.Add("@startDate", MySqlDbType.Date).Value = startDate;

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return table;
            }
            else
            {
                return null;
            }
        }

    }
}
