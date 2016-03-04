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

namespace OCMS_v2._0
{
    public partial class changePassword : MetroForm
    {
        public changePassword()
        {
            InitializeComponent();
            metroToolTip1.SetToolTip(metroButton2, "Update");
            metroToolTip1.SetToolTip(metroButton1, "Show/Hide Characters");
        }
    }
}
