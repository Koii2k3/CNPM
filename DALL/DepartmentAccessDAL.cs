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
    // Inherit from DataAccessDAL for database connection
    public class DepartmentAccessDAL : DataAccessDAL 
    {
        // Get all Departments
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
