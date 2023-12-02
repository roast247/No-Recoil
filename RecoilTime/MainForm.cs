using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecoilTime
{
    public partial class MainForm : Form
    {
        Thread t;

        public MainForm()
        {
            InitializeComponent();
        }

        private void ChangeEnabled(bool enabled)
        {
            numericUpDown1.Enabled = enabled;
            numericUpDown2.Enabled = enabled;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
            t = new Thread(Recoil.Loop);
            t.Start();
        }

        private void Enable()
        {
            ChangeEnabled(false);

            int sleeptime = (int)this.numericUpDown2.Value;
            int strength = (int)this.numericUpDown1.Value;
            Recoil.sleeptime = sleeptime;
            Recoil.strength = strength;
        }

        private void Disable()
        {
            ChangeEnabled(true);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (Recoil.Enabled)
            {
                label6.Text = "Enabled";
                label6.ForeColor = Color.Green;
                Enable();
            } else
            {
                label6.Text = "Disabled";
                label6.ForeColor = Color.Red;
                Disable();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            t.Abort();
        }

        private bool mouseDown;
        private Point lastLocation;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void label7_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void label7_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void label7_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Process.Start("https://lnks.win/OPKom");//website
        }
    }
}
