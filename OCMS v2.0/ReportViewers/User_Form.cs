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

namespace OCMS_v2_0.ReportViewers
{
    public partial class User_Form : MetroForm
    {
        public User_Form()
        {
            InitializeComponent();
            metroToolTip1.SetToolTip(metroButton1, "View Report");
            metroToolTip1.SetToolTip(metroButton2, "Print Report");
        }

        private void User_Form_Load(object sender, EventArgs e)
        {

        }
    }
}
