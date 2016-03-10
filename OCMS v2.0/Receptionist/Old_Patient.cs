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

namespace OCMS_v2_0.Receptionist
{
    public partial class Old_Patient : MetroForm
    {
        public Old_Patient()
        {
            InitializeComponent();
            metroToolTip1.SetToolTip(metroButton4, "Assign Doctor");
            metroToolTip1.SetToolTip(metroButton8, "Patient Registration");
        }
    }
}
