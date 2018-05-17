using Bug_Tracker.DAO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bug_Tracker.Views
{
    public partial class Bugs : Form
    {
        public Bugs()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void Bugs_Load(object sender, EventArgs e)
        {
            panelBugs.AutoScroll = false;
            panelBugs.HorizontalScroll.Enabled = false;
            panelBugs.HorizontalScroll.Visible = false;
            panelBugs.HorizontalScroll.Maximum = 0;
            panelBugs.AutoScroll = true;

            panelAssigned.AutoScroll = false;
            panelAssigned.HorizontalScroll.Enabled = false;
            panelAssigned.HorizontalScroll.Visible = false;
            panelAssigned.HorizontalScroll.Maximum = 0;
            panelAssigned.AutoScroll = true;

            BugDAO bugDao = new BugDAO();
            ArrayList list = bugDao.getAllBugs();

            foreach(var l in list)
            {
                Console.WriteLine(l);
            }

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelBugs_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
