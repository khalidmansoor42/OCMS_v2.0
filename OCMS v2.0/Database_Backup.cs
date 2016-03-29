using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCMS_v2_0
{
    class Database_Backup
    {
        connection con = new connection();
        public void dbBackup()
        {
            try
            {
                string constring = con.myConnection;
                string file = "C:\\backup.sql";
                using (MySqlConnection conn = new MySqlConnection(constring))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = conn;
                            conn.Open();
                            mb.ExportToFile(file);
                            conn.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
