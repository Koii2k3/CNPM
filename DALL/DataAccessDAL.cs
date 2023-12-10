using MySql.Data.MySqlClient;
namespace DALL
{
    public class DataAccessDAL
    {
        // Database information
        private static string connstring = "server=s88d91.cloudnetwork.vn;PORT=3306;uid=sho27414_admin;pwd=admin21112023;database=sho27414_epdcs;Charset=utf8";
        protected MySqlConnection con = new MySqlConnection(connstring);


        public MySqlConnection getConnection
        {
            get { return con; }
        }

        // Open connection
        public void openConnect()
        {
            if (con == null)
            {
                con = new MySqlConnection(connstring);
            }
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Close();
            }
        }

        // Close connection
        public void closeConnect()
        {
            if (con != null && con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
