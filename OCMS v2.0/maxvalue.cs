using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
namespace OCMS_v2_0
{
    public class maxvalue : connection
    {

        
        
        
        
        public int max(string query)
        {

            
            //string conString = "datasource=192.168.2.11;port=3306;username=root;password=admin";
            MySqlConnection conn = new MySqlConnection(myConnection);
           
            conn.Open();
            try
            {
                MySqlCommand command = new MySqlCommand(query, conn);
                string c = command.ExecuteScalar().ToString();
                if (c == "")
                {
                    c = "0";
                 }
                return  Convert.ToInt32(c);            

            }
            finally
            {
                conn.Close();
            }

        }
    }
}
