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
    public partial class Doctor : MetroForm
    {
        public Doctor()
        {
            InitializeComponent();
            company.Text = "© Techagentx";
            dateLabel.Text = DateTime.Now.ToString("dddd  dd, MMM yyyy");
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = System.Drawing.Color.SlateGray;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = System.Drawing.Color.Transparent;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = System.Drawing.Color.SlateGray;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = System.Drawing.Color.Transparent;
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.BackColor = System.Drawing.Color.SlateGray;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = System.Drawing.Color.Transparent;
        }

        private void button9_MouseEnter(object sender, EventArgs e)
        {
            button9.BackColor = System.Drawing.Color.SlateGray;
        }

        private void button9_MouseLeave(object sender, EventArgs e)
        {
            button9.BackColor = System.Drawing.Color.Transparent;
        }

        private void button8_MouseEnter(object sender, EventArgs e)
        {
            button8.BackColor = System.Drawing.Color.SlateGray;
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {
            button8.BackColor = System.Drawing.Color.Transparent;
        }

        private void button10_MouseEnter(object sender, EventArgs e)
        {
            button10.BackColor = System.Drawing.Color.SlateGray;
        }

        private void button10_MouseLeave(object sender, EventArgs e)
        {
            button10.BackColor = System.Drawing.Color.Transparent;
        }

        private void button7_MouseEnter(object sender, EventArgs e)
        {
            button7.BackColor = System.Drawing.Color.SlateGray;
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            button7.BackColor = System.Drawing.Color.Transparent;
        }

        private void inventoryTile_MouseEnter(object sender, EventArgs e)
        {
            inventoryTile.Style = MetroFramework.MetroColorStyle.Red;
        }

        private void inventoryTile_MouseLeave(object sender, EventArgs e)
        {
            inventoryTile.Style = MetroFramework.MetroColorStyle.Teal;
        }

        private void metroTile2_MouseEnter(object sender, EventArgs e)
        {
            metroTile2.Style = MetroFramework.MetroColorStyle.Red;
        }

        private void metroTile2_MouseLeave(object sender, EventArgs e)
        {
            metroTile2.Style = MetroFramework.MetroColorStyle.Green;
        }

        private void metroTile3_MouseEnter(object sender, EventArgs e)
        {
            metroTile3.Style = MetroFramework.MetroColorStyle.Red;
        }

        private void metroTile3_MouseLeave(object sender, EventArgs e)
        {
            metroTile3.Style = MetroFramework.MetroColorStyle.Orange;
        }

        private void metroTile4_MouseEnter(object sender, EventArgs e)
        {
            metroTile4.Style = MetroFramework.MetroColorStyle.Red;
        }

        private void metroTile4_MouseLeave(object sender, EventArgs e)
        {
            metroTile4.Style = MetroFramework.MetroColorStyle.Silver;
        }

        private void metroTile5_MouseEnter(object sender, EventArgs e)
        {
            metroTile5.Style = MetroFramework.MetroColorStyle.Red;
        }

        private void metroTile5_MouseLeave(object sender, EventArgs e)
        {
            metroTile5.Style = MetroFramework.MetroColorStyle.Lime;
        }

        private void metroTile7_MouseEnter(object sender, EventArgs e)
        {
            metroTile7.Style = MetroFramework.MetroColorStyle.Red;
        }

        private void metroTile7_MouseLeave(object sender, EventArgs e)
        {
            metroTile7.Style = MetroFramework.MetroColorStyle.Brown;
        }

        private void metroTile8_MouseEnter(object sender, EventArgs e)
        {
            metroTile8.Style = MetroFramework.MetroColorStyle.Red;
        }

        private void metroTile8_MouseLeave(object sender, EventArgs e)
        {
            metroTile8.Style = MetroFramework.MetroColorStyle.Purple;
        }

        private void metroTile10_MouseEnter(object sender, EventArgs e)
        {
            metroTile10.Style = MetroFramework.MetroColorStyle.Red;
        }

        private void metroTile10_MouseLeave(object sender, EventArgs e)
        {
            metroTile10.Style = MetroFramework.MetroColorStyle.Red;
        }

        private void metroTile11_MouseEnter(object sender, EventArgs e)
        {
            metroTile11.Style = MetroFramework.MetroColorStyle.Red;
        }

        private void metroTile11_MouseLeave(object sender, EventArgs e)
        {
            metroTile11.Style = MetroFramework.MetroColorStyle.Yellow;
        }

        private void metroTile13_MouseEnter(object sender, EventArgs e)
        {
            metroTile13.Style = MetroFramework.MetroColorStyle.Red;
        }

        private void metroTile13_MouseLeave(object sender, EventArgs e)
        {
            metroTile13.Style = MetroFramework.MetroColorStyle.Pink;
        }

        private void metroTile14_MouseEnter(object sender, EventArgs e)
        {
            metroTile14.Style = MetroFramework.MetroColorStyle.Red;
        }

        private void metroTile14_MouseLeave(object sender, EventArgs e)
        {
            metroTile14.Style = MetroFramework.MetroColorStyle.Blue;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            timeLabel.Text = DateTime.Now.ToString("hh:mm:ss tt");
            menuProgressBar.Value = menuProgressBar.Value + 5;
            if (menuProgressBar.Value == 100)
            {
                menuProgressBar.Visible = false;
            }
        }
    }
}
