using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL
{
    public class DepartmentAccessDAL : DataAccessDAL
    {
        public string[] GetUserDP()
        {
            string query = "SELECT * FROM DEPARTMENT";
            MySqlCommand command = new MySqlCommand(query, con);

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();

            adapter.Fill(table);
            List<string> termsList = new List<string>();
            foreach (DataRow row in table.Rows)
            {
                termsList.Add(row["PB_NAME"].ToString());
            }
            string[] types = termsList.ToArray();
            return types;
        }
    }
}
