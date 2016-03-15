using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCMS_v2._0.Class
{
    class maxValue:connectionDb
    {
        public int max(string query)
        {
            MySqlCommand SelectCommand = new MySqlCommand(query, openConnection());
            try
            {
                string c = SelectCommand.ExecuteScalar().ToString();
                if (c == "")
                {
                    c = "0";
                }
                return Convert.ToInt32(c);
            }
            finally
            {
                closeConnection();
            }

        }

    }
}
