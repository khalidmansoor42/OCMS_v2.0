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

namespace OCMS_v2_0.Admin
{
    public partial class Search_Users : MetroForm
    {
        public Search_Users()
        {
            InitializeComponent();
            metroToolTip1.SetToolTip(metroComboBox1, "Select Search Criteria From Here");
        }
    }
}
