using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OCMS_v2._0.Class
{
    class getId
    {
        connectionDb cons = new connectionDb();
        public string getid(string query)
        {
            string id = "";
            try
            {
                MySqlCommand SelectCommand = new MySqlCommand(query, cons.openConnection());
                MySqlDataReader myReader;
                myReader = SelectCommand.ExecuteReader();
                while (myReader.Read())
                {
                    id = myReader.GetString("employee_id");
                }
                cons.closeConnection();
                                           }
            catch (Exception)
            {
                MessageBox.Show("donot Find Form ic");
            }
            return id;
        }

    }
}
