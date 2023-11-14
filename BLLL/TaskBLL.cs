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
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace BLLL
{
    public class TaskBLL
    {
        TaskAccessDAL task_access = new TaskAccessDAL();

        public DataTable GetJobInProjectOfUser(String userID, String pjID)
        {
            return task_access.GetJobInProjectOfUser(userID, pjID);
        }

        public DataTable GetTaskOfProject(String pjID)
        {
            return task_access.GetTaskOfProject(pjID);
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

        public bool AssignTask(String taskName, String taskDesc, DateTime start, DateTime end,
            int isHL, String taskState, String pjID, String pjManagerPK, List<String>  assigneePKs, List<String> filenames, List<String> subTasks)
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

                // Add users to task
                if (assigneePKs.Count > 0)
                {
                    foreach (var assigneePK in assigneePKs)
                    {
                        task_access.AddUserToTask(taskID, assigneePK);
                    }
                }


                // Add subtask to task
                if (subTasks.Count > 0)
                {
                    foreach (var subTask in subTasks)
                    {
                        task_access.AddSubtask(taskID, subTask);
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable GetTaskProcess(String jobID)
        {
            return task_access.GetTaskProcess(jobID);
        }


    }
}
