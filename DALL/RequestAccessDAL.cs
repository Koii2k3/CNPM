using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace DALL
{
    /*        DAL layer is to encapsulate the data access code and provide a standardized interface for
    performing CRUD(Create, Read, Update, Delete) operations on the underlying database.It
    ensures separation of concerns by isolating the database-specific operations from the rest
    of the application.*/
    public class RequestAccessDAL : DataAccessDAL
    {
        // Add file for requestment
        public void AddRequestPhase2(string req_id, string file_name, byte[] file)
        {
            String query = String.Format("select ADD_R_FILE(@req_id, @file_name, @file) as Result");
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.Add("@req_id", MySqlDbType.VarChar).Value = req_id;
            command.Parameters.Add("@file_name", MySqlDbType.VarChar).Value = file_name;
            command.Parameters.Add("@file", MySqlDbType.LongBlob).Value = file;

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

        }

        // Add request object
        public string AddRequestPhase1(string subject, string content, string pk_sender, string pk_receiver)
        {
            String query = String.Format("select ADD_REQUEST(@subject, @content, @pk_sender, @pk_receiver) as Result");
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.Add("@subject", MySqlDbType.VarChar).Value = subject;
            command.Parameters.Add("@content", MySqlDbType.VarChar).Value = content;
            command.Parameters.Add("@pk_sender", MySqlDbType.VarChar).Value = pk_sender;
            command.Parameters.Add("@pk_receiver", MySqlDbType.VarChar).Value = pk_receiver;

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            string req_id = "-1";
            foreach (DataRow row in table.Rows)
            {
                req_id = row["Result"].ToString();
            }
            return req_id;
        }

        // Get sending request of user
        public DataTable GetRequestReceiver(string pk_receiver)
        {
            String query = String.Format("call GET_R_RECEIVER(@pk_receiver)");
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.Add("@pk_receiver", MySqlDbType.VarChar).Value = pk_receiver;

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

        // Get file attached with request
        public DataTable GetFileFromRequest(string req_id)
        {
            String query = String.Format("call GET_R_FILE(@req_id)");
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.Add("@req_id", MySqlDbType.VarChar).Value = req_id;

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

        // Update request status (Accept or Reject)
        public void UpdateRequestStatus(string pk_sender, string pk_receiver, string status)
        {
            String query = String.Format("select UPDATE_R_STATUS(@pk_sender, @pk_receiver, @status) as Result");
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.Add("@pk_sender", MySqlDbType.VarChar).Value = pk_sender;
            command.Parameters.Add("@pk_receiver", MySqlDbType.VarChar).Value = pk_receiver;
            command.Parameters.Add("@status", MySqlDbType.VarChar).Value = status;

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
        }


        // Get requests which user sends
        public DataTable GetMyRequest(string pk_sender) 
        {
            String query = String.Format("call GET_R_OF_U(@pk_sender)");
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.Add("@pk_sender", MySqlDbType.VarChar).Value = pk_sender;

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
