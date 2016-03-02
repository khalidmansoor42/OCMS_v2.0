using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OCMS_v2._0
{
    class connectionDb
    {
        MySqlConnection con = null;
        //public string myConnection = "datasource=127.0.0.1;port=3306;username=root;password=admin;database=mydb";
        public string myConnection = "datasource=127.0.0.1;port=3306;username=root;password=''";
        MySqlCommand cmd;
        MySqlTransaction trans;
        MySqlDataAdapter Adapt;
       
        public MySqlConnection openConnection()
        {
            try
            {
                con = new MySqlConnection(myConnection);
                con.Open();
                return con;
            }
            catch (MySqlException err)
            {
                MessageBox.Show("Error: " + err.ToString());
                return con = null;
            }
        }
       
        public Boolean closeConnection()
        {
            con.Close();
            return true;
        }
    }
}
