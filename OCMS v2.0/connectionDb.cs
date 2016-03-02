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
        public MySqlConnection myConn;
        public MySqlCommand SelectCommand;
        public void connectionOpen()
        {
            try {
                MySqlConnection myConn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=''");
                myConn.Open();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
        }
        public void connectionClose()
        {
            myConn.Close();
        }
    }
}
