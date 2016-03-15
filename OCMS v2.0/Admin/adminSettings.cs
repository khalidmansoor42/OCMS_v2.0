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
    public partial class adminSettings : MetroForm
    {
        public adminSettings()
        {
            InitializeComponent();
        }

        private void metroTile2_MouseEnter(object sender, EventArgs e)
        {
            metroTile2.Style = MetroFramework.MetroColorStyle.Red;
        }

        private void metroTile2_MouseLeave(object sender, EventArgs e)
        {
            metroTile2.Style = MetroFramework.MetroColorStyle.Green;
        }

        private void metroTile1_MouseEnter(object sender, EventArgs e)
        {
            metroTile1.Style = MetroFramework.MetroColorStyle.Red;
        }

        private void metroTile1_MouseLeave(object sender, EventArgs e)
        {
            metroTile1.Style = MetroFramework.MetroColorStyle.Silver;
        }

        private void metroTile3_MouseEnter(object sender, EventArgs e)
        {
            metroTile3.Style = MetroFramework.MetroColorStyle.Red;
        }

        private void metroTile3_MouseLeave(object sender, EventArgs e)
        {
            metroTile3.Style = MetroFramework.MetroColorStyle.Teal;
        }

        private void metroTile4_MouseEnter(object sender, EventArgs e)
        {
            metroTile4.Style = MetroFramework.MetroColorStyle.Red;
        }

        private void metroTile4_MouseLeave(object sender, EventArgs e)
        {
            metroTile4.Style = MetroFramework.MetroColorStyle.Blue;
        }

        private void metroTile5_MouseEnter(object sender, EventArgs e)
        {
            metroTile5.Style = MetroFramework.MetroColorStyle.Red;
        }

        private void metroTile5_MouseLeave(object sender, EventArgs e)
        {
            metroTile5.Style = MetroFramework.MetroColorStyle.Purple;
        }

        private void metroTile6_MouseEnter(object sender, EventArgs e)
        {
            metroTile6.Style = MetroFramework.MetroColorStyle.Red;
        }

        private void metroTile6_MouseLeave(object sender, EventArgs e)
        {
            metroTile6.Style = MetroFramework.MetroColorStyle.Yellow;
        }

    }
}
