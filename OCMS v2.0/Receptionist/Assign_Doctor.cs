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
    public partial class Assign_Doctor : MetroForm
    {
        public Assign_Doctor()
        {
            InitializeComponent();
            metroToolTip1.SetToolTip(metroButton2, "Print Reciept");
        }
    }
}
