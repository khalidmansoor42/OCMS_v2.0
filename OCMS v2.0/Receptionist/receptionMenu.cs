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
    public partial class receptionMenu : MetroForm
    {
        public receptionMenu()
        {
            InitializeComponent();
            notifyIcon1.BalloonTipText = "Application Minimized";
            notifyIcon1.BalloonTipTitle = "Eminence";
            dateLabel.Text = DateTime.Now.ToString("dddd  dd, MMM yyyy");
            company.Text = "© Techagentx";
        }
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowInTaskbar = true;
            notifyIcon1.Visible = false;
            WindowState = FormWindowState.Normal;
        }

        private void Doctor_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                ShowInTaskbar = false;
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(1000);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeLabel.Text = DateTime.Now.ToString("hh:mm:ss tt");
            menuProgressBar.Value = menuProgressBar.Value + 5;
            if (menuProgressBar.Value == 100)
            {
                menuProgressBar.Visible = false;
            }
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
            metroTile2.Style = MetroFramework.MetroColorStyle.Purple;
        }

        private void metroButton1_MouseEnter(object sender, EventArgs e)
        {
            metroButton1.BackColor = System.Drawing.Color.Gray;
        }

        private void metroButton1_MouseLeave(object sender, EventArgs e)
        {
            metroButton1.BackColor = System.Drawing.Color.MediumSeaGreen;
        }

        private void metroButton1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void metroButton1_MouseUp(object sender, MouseEventArgs e)
        {
            metroButton1.BackColor = System.Drawing.Color.Gray;
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
        }

        private void metroTile3_MouseEnter(object sender, EventArgs e)
        {
            metroTile3.Style = MetroFramework.MetroColorStyle.Red;
        }

        private void metroTile3_MouseLeave(object sender, EventArgs e)
        {
            metroTile3.Style = MetroFramework.MetroColorStyle.Green;
        }
    }
}
