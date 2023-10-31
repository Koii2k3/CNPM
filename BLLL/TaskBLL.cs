using DALL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
    }
}
