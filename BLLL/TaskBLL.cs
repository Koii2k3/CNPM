using DALL;
using DTOO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace BLLL
{
    public class TaskBLL
    {

        /*
         * BLL layer is to implement and manage the business rules and processes of the application.It focuses on
        the core functionality and operations that define the behavior and logic of the application
         - This is where the data manipulation requirements of the GUI layer are met, processing the data source from the
        Presentation Layer before transmitting it to the Data Access Layer (TaskDAL) and saving it to the database management system.
         - This is also the place to check constraints, data integrity and validity, perform calculations and process business 
        requirements, before returning results to the Presentation Layer.
        */

        TaskAccessDAL task_access = new TaskAccessDAL();
        NotiBLL notiAccess = new NotiBLL();

        public DataRow GetTaskInfo(string taskID)
        {
            return task_access.GetTaskInfo(taskID);
        }


        public DataTable GetJobInProjectOfUser(String userID, String pjID)
        {
            return task_access.GetJobInProjectOfUser(userID, pjID);
        }

        public DataTable GetTaskOfProject(String pjID)
        {
            return task_access.GetTaskOfProject(pjID);
        }

        public DataTable GetTaskWithStatus(String pjID, int taskState)
        {
            return task_access.GetTaskWithStatus(pjID, taskState);
        }

        public bool AddUserToTask(string jobID, string userID)
        {
            return task_access.AddUserToTask(jobID, userID);
        }

        public DataTable GetUserOfTask(string pjID)
        {
            return task_access.GetUserOfTask(pjID);
        }


        public DataTable GetAllTaskOfUser(String uID)
        {
            return task_access.GetAllTaskOfUser(uID);
        }

        public bool InsertTask(string name, string desc, DateTime? exp, DateTime? start, DateTime? end, string isHL, string status, string pjID)
        {
            return task_access.InsertTask(name, desc, exp, start, end, isHL, status, pjID);
        }

        public String AssignTask(String taskName, String taskDesc, DateTime start, DateTime end, int isHL, String taskState,
            String pjID, String pjManagerPK, List<String> assigneePKs, List<String> filenames, List<String> subTasks,
            String contentAssign)
        {
            String taskID = task_access.InsertTask1(taskName, taskDesc, start, end, isHL, taskState, pjID);

            if (taskID != "-1")
            {
                if (filenames.Count > 0)
                {
                    // Add files for task
                    foreach (var file in filenames)
                    {
                        FileStream fstream = System.IO.File.OpenRead(file);
                        byte[] content = new byte[fstream.Length];
                        fstream.Read(content, 0, (int)fstream.Length);
                        fstream.Read(content, 0, (int)fstream.Length);
                        fstream.Close();
                        string file_name = System.IO.Path.GetFileName(file);
                        task_access.AddFileForTask(taskID, pjManagerPK, file_name, content);
                    }
                }

                if (assigneePKs.Count > 0)
                {
                    foreach (var assigneePK in assigneePKs)
                    {
                        // Add users to task
                        task_access.AddUserToTask(taskID, assigneePK);
                    }

                    // Notify to assignees
                    notiAccess.AddNoti(contentAssign, pjManagerPK, assigneePKs);
                }


                // Add subtask to task
                if (subTasks.Count > 0)
                {
                    foreach (var subTask in subTasks)
                    {
                        task_access.AddSubtask(taskID, subTask);
                    }
                }
                return taskID;
            }
            else
            {
                return "";
            }
        }

        public DataTable GetTaskProcess(String jobID)
        {
            return task_access.GetTaskProcess(jobID);
        }

        public DataTable GetAllSubTaskOfTask(String taskID, int subTaskState)
        {
            return task_access.GetAllSubTaskOfTask(taskID, subTaskState);
        }

        public DataTable GetResourceOfTask(String taskID)
        {
            return task_access.GetResourceOfTask(taskID);
        }

        public DataTable GetSubmitFileOfTask(String taskID)
        {
            return task_access.GetSubmitFileOfTask(taskID);
        }


        public bool SubmitOneSubtask(String subtaskID)
        {
            if (task_access.SubmitSubtask(subtaskID))
            {
                return true;
            } else
            {
                return false;
            }
        }

        public Boolean SubmitSubtask(List<String> subtaskIDs)
        {
            if (subtaskIDs.Count > 0)
            {
                foreach (String stId in subtaskIDs)
                {
                    if(!task_access.SubmitSubtask(stId))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public Boolean SubmitTask(String taskID, String assigneeID, List<String> subtaskIDs, List<String> filenames)
        {
/*            if (SubmitSubtask(subtaskIDs))
            {*/
            AddSubmitFileTask(taskID, assigneeID, filenames);
            return true;
/*                return true;
            } else
            {
                return false;
            }*/
            
        }

        public void AddSubmitFileTask(String taskID, String assigneeID, List<String> filenames)
        {
            foreach (var file in filenames)
            {
                try
                {
                    FileStream fstream = System.IO.File.OpenRead(file);
                    byte[] content = new byte[fstream.Length];
                    fstream.Read(content, 0, (int)fstream.Length);
                    fstream.Read(content, 0, (int)fstream.Length);
                    fstream.Close();
                    string file_name = System.IO.Path.GetFileName(file);
                    task_access.AddFileForTask(taskID, assigneeID, file_name, content);
                } catch
                {

                }

            }
        }

        public Boolean UpdateTask(String pjManagerPK, String contentAssign, String taskID, String taskName, String taskDesc,
            DateTime start, DateTime deadline, DateTime? finish, int taskHL, String taskState,
            List<String> moreAssignees, List<String> moreSubtasks, List<String> moreFilenames)
        {
            // Update information task basically
            task_access.UpdateTask(taskID, taskName, taskDesc, start, deadline, finish, taskHL, taskState);

            if (moreFilenames.Count > 0)
            {
                // Add files for task
                foreach (var file in moreFilenames)
                {
                    FileStream fstream = System.IO.File.OpenRead(file);
                    byte[] content = new byte[fstream.Length];
                    fstream.Read(content, 0, (int)fstream.Length);
                    fstream.Read(content, 0, (int)fstream.Length);
                    fstream.Close();
                    string file_name = System.IO.Path.GetFileName(file);
                    task_access.AddFileForTask(taskID, pjManagerPK, file_name, content);
                }
            }

            if (moreAssignees.Count > 0)
            {
                foreach (var assigneePK in moreAssignees)
                {
                    // Add users to task
                    task_access.AddUserToTask(taskID, assigneePK);
                }

                // Notify to assignees
                notiAccess.AddNoti(contentAssign, pjManagerPK, moreAssignees);
            }


            // Add subtask to task
            if (moreSubtasks.Count > 0)
            {
                foreach (var subTask in moreSubtasks)
                {
                    task_access.AddSubtask(taskID, subTask);
                }
            }
            return true;
        }

        public bool DeleteTask(String taskID)
        {
            return task_access.DeleteTask(taskID);
        }

        public DataRow GetTaskHLPercent(string pjId, int hl)
        {
            return task_access.GetTaskHLPercent(pjId, hl);
        }

        public DataTable GetTaskWithStartDate(String pjID, DateTime startDate)
        {
            return task_access.GetTaskWithStartDate(pjID, startDate);
        }
    }
}
