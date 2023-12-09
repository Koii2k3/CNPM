using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL
{
    public class LevelAccessDAL : DataAccessDAL
    {

        public string[] GetUserLevel()
        {
            string query = "SELECT * FROM LEVEL";
            MySqlCommand command = new MySqlCommand(query, con);

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();

            adapter.Fill(table);
            List<string> termsList = new List<string>();
            foreach (DataRow row in table.Rows)
            {
                termsList.Add(row["LV_NAME"].ToString());
            }
            string[] types = termsList.ToArray();
            return types;
        }

        public int Level2ID(string lv_name)
        {
            string query = "SELECT LV_ID FROM LEVEL WHERE LV_NAME = @lv";
            MySqlCommand command = new MySqlCommand(query, con);

            command.Parameters.Add("@lv", MySqlDbType.VarChar).Value = lv_name;

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();

            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                int lv_id = 0;
                foreach (DataRow row in table.Rows)
                {
                    lv_id = Int32.Parse(row["LV_ID"].ToString());
                }
                return lv_id;
            }
            else
            {
                return 0;
            }

        }
    }
}
