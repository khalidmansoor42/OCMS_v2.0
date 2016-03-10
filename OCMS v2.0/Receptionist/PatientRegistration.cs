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
    public partial class PatientRegistration : MetroForm
    {
        public PatientRegistration()
        {
            InitializeComponent();
            metroToolTip1.SetToolTip(metroButton4, "Save");
            metroToolTip1.SetToolTip(metroButton2, "Add City");
            metroToolTip1.SetToolTip(metroButton1, "Search");
            metroToolTip1.SetToolTip(metroButton5, "Add Referring Doctor");
            metroToolTip1.SetToolTip(metroButton8, "Clear");
        }
    }
}
