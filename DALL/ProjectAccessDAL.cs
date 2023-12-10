using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace DALL
{
    /*        DAL layer is to encapsulate the data access code and provide a standardized interface for
        performing CRUD(Create, Read, Update, Delete) operations on the underlying database.It
        ensures separation of concerns by isolating the database-specific operations from the rest
        of the application.*/
    public class ProjectAccessDAL : DataAccessDAL
    {

        // Get project object with project id
        public DataRow GetProject(string pjID)
        {
            MySqlCommand command = new MySqlCommand("CALL GET_INFO_PJ(@pjID)", con);
            command.Parameters.Add("@pjID", MySqlDbType.VarChar).Value = pjID;

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

        // Get project progress of project object with project id
        public DataRow GetProjectProgress(string pjID)
        {
            MySqlCommand command = new MySqlCommand("CALL GET_PROJECT_PROCESS(@pjID)", con);
            command.Parameters.Add("@pjID", MySqlDbType.VarChar).Value = pjID;

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

        // Get list of project meeting description
        public DataTable SearchProject(string desc)
        {
            MySqlCommand command = new MySqlCommand("CALL SEARCH_IN_PJ_MANAGE (@desc)", con);

            command.Parameters.Add("@desc", MySqlDbType.VarChar).Value = desc;

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();

            adapter.Fill(table);

            return table;
        }
        public DataTable SearchProjectU(string pk_u, string pj_desc)
        {
            MySqlCommand command = new MySqlCommand("CALL SEARCH_IN_PJ_U (@pk, @desc)", con);

            command.Parameters.Add("@pk", MySqlDbType.VarChar).Value = pk_u;
            command.Parameters.Add("@desc", MySqlDbType.VarChar).Value = pj_desc;

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();

            adapter.Fill(table);

            return table;
        }

        // Get list of project meeting description
        public bool InsertPJ(string name, string desc, DateTime? exp, DateTime? start, DateTime? end, string ver, string isPublic, string pk)
        {
            MySqlCommand command = new MySqlCommand("SELECT ADD_PJ (@name, @desc, @exp, @start, @end, @ver, @isPublic, @u_id) as Result", con);

            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@desc", MySqlDbType.VarChar).Value = desc;
            command.Parameters.Add("@exp", MySqlDbType.Date).Value = exp;
            command.Parameters.Add("@start", MySqlDbType.Date).Value = start;
            command.Parameters.Add("@end", MySqlDbType.Date).Value = end;
            command.Parameters.Add("@ver", MySqlDbType.Int32).Value = Int32.Parse(ver);
            command.Parameters.Add("@isPublic", MySqlDbType.Int32).Value = Int32.Parse(isPublic);
            command.Parameters.Add("@u_id", MySqlDbType.VarChar).Value = pk;

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

        // Get list of project of manager
        public DataTable GetProjectInfoAllOfMan(string pk)
        {
            String query = String.Format("call GET_PJ_USER_MANAGE(@pk)");
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.Add("@pk", MySqlDbType.VarChar).Value = pk;

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

        // Add user to project and notify them
        public bool AddMember2Project(string u_id, string u_email, string pj_id)
        {
            MySqlCommand command = new MySqlCommand("SELECT ADD_U_PJ_NG (@u_id, @pj_id) as Result", con);

            command.Parameters.Add("@u_id", MySqlDbType.VarChar).Value = u_id;
            command.Parameters.Add("@pj_id", MySqlDbType.VarChar).Value = pj_id;

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
                UserAccessDAL ul = new UserAccessDAL();
                string title = "Welcome to new project!";
                string message = "You've just been added to Project:" + pj_id;
                ul.verifyEmail(u_email, title, message);
                return true;
            }
            else
            {
                return false;
            }
        }

        // Add user to project and notify them
        public bool DelMemberFromProject(string u_pk, string pj_id)
        {
            MySqlCommand command = new MySqlCommand("SELECT DEL_U_PJ(@u_pk, @pj_id) as Result", con);

            command.Parameters.Add("@u_pk", MySqlDbType.VarChar).Value = u_pk;
            command.Parameters.Add("@pj_id", MySqlDbType.VarChar).Value = pj_id;

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
                UserAccessDAL ul = new UserAccessDAL();
                return true;
            }
            else
            {
                return false;
            }
        }


        // Update project information
        public bool UpdateProject(string pj_id, string pj_name, string desc, DateTime? exp, DateTime? start, DateTime? end, string ver, string isPublic, string u_pk)
        {
            MySqlCommand command = new MySqlCommand("SELECT UPDATE_PJ (@pj_id, @pj_name, @desc, @exp, @start, @end, @ver, @isPublic, @u_pk) as Result", con);

            command.Parameters.Add("@pj_id", MySqlDbType.VarChar).Value = pj_id;
            command.Parameters.Add("@pj_name", MySqlDbType.VarChar).Value = pj_name;
            command.Parameters.Add("@desc", MySqlDbType.VarChar).Value = desc;
            command.Parameters.Add("@exp", MySqlDbType.Date).Value = exp;
            command.Parameters.Add("@start", MySqlDbType.Date).Value = start;
            command.Parameters.Add("@end", MySqlDbType.Date).Value = end;
            command.Parameters.Add("@ver", MySqlDbType.Int32).Value = Int32.Parse(ver);
            command.Parameters.Add("@isPublic", MySqlDbType.Int32).Value = Int32.Parse(isPublic);
            command.Parameters.Add("@u_pk", MySqlDbType.VarChar).Value = u_pk;

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

        // Get list of user joining in project
        public DataTable GetUserOfProject(string pj_id)
        {
            String query = String.Format("call GET_USER_OF_PJ(@pj_id)");
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.Add("@pj_id", MySqlDbType.VarChar).Value = pj_id;

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

        // Get list of project which user take part in
        public DataTable getProjectOfUser(string pk)
        {
            String query = String.Format("call GET_PJ_USER_MANAGE(@pk)");
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.Add("@pk", MySqlDbType.VarChar).Value = pk;

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            String query1 = String.Format("call GET_PJ_USER(@pk)");
            MySqlCommand command1 = new MySqlCommand(query1, con);
            command1.Parameters.Add("@pk", MySqlDbType.VarChar).Value = pk;

            MySqlDataAdapter adapter1 = new MySqlDataAdapter(command1);
            DataTable table1 = new DataTable();
            adapter1.Fill(table1);

            table.Merge(table1);


            if (table.Rows.Count > 0)
            {
                return table;
            }
            else
            {
                return null;
            }
        }

        // Get list of project which user take part in
        public DataTable GetAllProject()
        {
            String query = String.Format("call GET_PJ_ALL()");
            MySqlCommand command = new MySqlCommand(query, con);
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

        // Get statistic workload of each user in project
        public DataTable GetTaskPerUser(String pjID)
        {
            String query = String.Format("call GET_TASK_PER_USER(@pjID)");
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

        // Get statistic of task status in project
        public DataTable GetStateJobsInProject(String pjID)
        {
            String query = String.Format("call GET_STATUS_LIST_OF_JOBS_IN_PROJECT(@pjID)");
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

        // Get the number tasks in project
        public int GetNumTaskOfProject(String pjID)
        {
            String query = String.Format("call GET_COUNT_J_OF_PJ(@pjID)");
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.Add("@pjID", MySqlDbType.VarChar).Value = pjID;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            int i = 0;
            foreach (DataRow row in table.Rows)
            {
                string r = row["COUNT"].ToString();
                i = Int32.Parse(r);
            }

            return i;
        }

        // Get the number ramaining dates to finish project
        public DataRow GetRemainTimePJ(string pjID)
        {
            MySqlCommand command = new MySqlCommand("CALL GET_DAY_REMAIN_BEFORE_DEADLINE_OF_PROJECT(@pjId)", con);
            command.Parameters.Add("@pjId", MySqlDbType.VarChar).Value = pjID;

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

        // Get updated progress today of project
        public DataRow GetUpdatedProgressPJ(string pjID)
        {
            MySqlCommand command = new MySqlCommand("CALL GET_PROJECT_PROCESS_DONE_TODAY(@pjId)", con);
            command.Parameters.Add("@pjId", MySqlDbType.VarChar).Value = pjID;

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
    }
}
