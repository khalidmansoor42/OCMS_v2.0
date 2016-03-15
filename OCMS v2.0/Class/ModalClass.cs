using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OCMS_v2._0.Class
{
    class ModalClass
    {
        connectionDb con = new connectionDb();
        public MySqlCommand SelectCommand;

        public void insertData(string query)
        {
            try
            {
                SelectCommand = new MySqlCommand(query, con.openConnection());
                MySqlDataReader myReader;
                myReader = SelectCommand.ExecuteReader();
                con.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
