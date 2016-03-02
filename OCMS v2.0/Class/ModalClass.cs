using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OCMS_v2._0.Class
{
    class ModalClass:connectionDb
    {
        public void insertData(string query)
        {
            try
            {
                connectionOpen();

                SelectCommand = new MySqlCommand(query, myConn);
                MySqlDataReader myReader;                
                myReader = SelectCommand.ExecuteReader();

                connectionClose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
