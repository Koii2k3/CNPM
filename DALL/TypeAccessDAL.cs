using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL
{
    public class TypeAccessDAL : DataAccessDAL
    {

        public string [] getUserType()
        {
            string query = "SELECT * FROM TYPE";
            MySqlCommand command = new MySqlCommand(query, con);

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();

            adapter.Fill(table);
            List<string> termsList = new List<string>();
            foreach (DataRow row in table.Rows)
            {
                termsList.Add(row["VT_NAME"].ToString());
            }
            string[] types = termsList.ToArray();
            return types;
        }
    }
}
