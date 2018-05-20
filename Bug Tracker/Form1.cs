using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bug_Tracker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Views.Login().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Views.Admin().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Views.AboutUs().Show();

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bug Tracker By:" + Environment.NewLine +
                "Name: Ashim Karki" + Environment.NewLine +
                "Email: Lashimkarki@gmail.com" + Environment.NewLine +
                "Contact Num: +9779841647756" + Environment.NewLine +
                "Developed In: Microsoft Visual Studio 2017 Community" + Environment.NewLine,
                "Version 1.0.0 freeware"
                );
        }
    }
}
