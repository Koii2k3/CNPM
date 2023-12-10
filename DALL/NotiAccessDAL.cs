using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL
{

/*        DAL layer is to encapsulate the data access code and provide a standardized interface for
        performing CRUD(Create, Read, Update, Delete) operations on the underlying database.It
        ensures separation of concerns by isolating the database-specific operations from the rest
        of the application.*/
    public class NotiAccessDAL : DataAccessDAL
    {
        public object MessageBox { get; private set; }


        // Add notification
        public String AddNoti(string notiDesc, string fromID)
        {
            MySqlCommand command = new MySqlCommand("SELECT ADD_NOTI(@notiDesc, @fromID) as Result", con);

            command.Parameters.Add("@notiDesc", MySqlDbType.VarChar).Value = notiDesc;
            command.Parameters.Add("@fromID", MySqlDbType.VarChar).Value = fromID;

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();

            adapter.Fill(table);
            string notiID = "-1";
            foreach (DataRow row in table.Rows)
            {
                notiID = row["Result"].ToString();
            }
            return notiID;
        }


        // Add receiver to notification object
        public Boolean AddReceiverToNoti(string notiID, string receiverID)
        {
            MySqlCommand command = new MySqlCommand("SELECT ADD_NOTI_RECEIVER(@notiID, @receiverID) as Result", con);

            command.Parameters.Add("@notiID", MySqlDbType.VarChar).Value = notiID;
            command.Parameters.Add("@receiverID", MySqlDbType.VarChar).Value = receiverID;

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


        // Get list of receiver's notification 
        public DataTable GetNotiOfReceiver(string receiverID)
        {
            String query = String.Format("call GET_NOTI_RECEIVER(@receiverID)");
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.Add("@receiverID", MySqlDbType.VarChar).Value = receiverID;

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


        // Get list of sender's notification 
        public DataTable GetNotiOfSender(string senderID)
        {
            String query = String.Format("call GET_NOTI_SENDER(@senderID)");
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.Add("@senderID", MySqlDbType.VarChar).Value = senderID;

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

        // Get list of notification's receivers
        public DataTable GetReceiverOfNoti(string notiID)
        {
            String query = String.Format("call GET_RECEIVER_OF_NOTI(@notiID)");
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.Add("@notiID", MySqlDbType.VarChar).Value = notiID;

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

        // Update notification to is read status
        public bool UpdateNotiRead(string notiID, string receiverID)
        {
            MySqlCommand command = new MySqlCommand("SELECT UPDATE_NOTI_READ(@notiID, @receiverID) as Result", con);

            command.Parameters.Add("@notiID", MySqlDbType.VarChar).Value = notiID;
            command.Parameters.Add("@receiverID", MySqlDbType.VarChar).Value = receiverID;

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

        // Get the number of unread notifications
        public string GetNumNewNoti(string receiverId)
        {
            MySqlCommand command = new MySqlCommand("CALL GET_NOTI_NOT_READ_COUNT(@receiverId)", con);

            command.Parameters.Add("@receiverId", MySqlDbType.VarChar).Value = receiverId;

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table.Rows[0]["COUNT"].ToString();
        }
    }
}
