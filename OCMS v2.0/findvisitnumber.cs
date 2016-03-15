using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

using System.Windows.Forms;
namespace OCMS_v2_0
{
    class findvisitnumber
    {
        int a;
        connection cons = new connection();
        public  int findvisits(string query)
        {
           
           
            try
            {
                 MySqlConnection myConn = new MySqlConnection(cons.myConnection);

                

               
                MySqlCommand SelectCommand = new MySqlCommand(query, myConn);
                MySqlDataReader myReader;
                myConn.Open();
                myReader = SelectCommand.ExecuteReader();



               


                while (myReader.Read()) {

                  a=Convert.ToInt32(myReader.GetString("visit_no")); 
                }
                myConn.Close();
                return a;
               
                

            }

            catch (Exception )
            {
                return 0;
                //MessageBox.Show(ex.Message);
            }
        }

        public int findpatientid(string query)
        {
        
           
           
            try
            {
            
                MySqlConnection myConn = new MySqlConnection(cons.myConnection);

                

               
                MySqlCommand SelectCommand = new MySqlCommand(query, myConn);
                MySqlDataReader myReader;
                myConn.Open();
                myReader = SelectCommand.ExecuteReader();



               


                while (myReader.Read()) {

                  a=Convert.ToInt32(myReader.GetString("patient_reg")); 
                }
                myConn.Close();
                return a;
               
                

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
              
            }
        }
     

    }
 

}
