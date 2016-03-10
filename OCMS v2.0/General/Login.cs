using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OCMS_v2_0.General
{
    public partial class Login : MetroForm
    {
        public Login()
        {
            InitializeComponent();
            metroToolTip1.SetToolTip(usernameTxt, "Enter credentials here");
            metroToolTip1.SetToolTip(passwordTxt, "Enter credentials here");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            Receptionist.receptionMenu obj = new Receptionist.receptionMenu();
            this.Hide();
            obj.Show();
        }
    }
}
