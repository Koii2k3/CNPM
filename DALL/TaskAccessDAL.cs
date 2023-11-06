using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DALL
{
    public class TaskAccessDAL : DataAccessDAL
    {

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
    }
}
