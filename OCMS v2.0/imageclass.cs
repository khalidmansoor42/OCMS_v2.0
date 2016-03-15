using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace OCMS_v2_0
{ 
          class imageclass
          {
              connection cons = new connection();
              string a;
        public string findimage(string query,string type)
        {

            try
            {
                MySqlConnection myConn = new MySqlConnection(cons.myConnection);
                MySqlCommand SelectCommand = new MySqlCommand(query, myConn);
                MySqlDataReader myReader;
                myConn.Open();
                myReader = SelectCommand.ExecuteReader();
                while (myReader.Read())
                {

                    a = myReader.GetString(type);
                }
                myConn.Close();
                return a;
                
            }

            catch (Exception)
            {
                return "";
            }
        }

    }
}
