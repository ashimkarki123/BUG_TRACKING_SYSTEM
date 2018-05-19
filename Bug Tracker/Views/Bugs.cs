using Bug_Tracker.Common;
using Bug_Tracker.DAO;
using Bug_Tracker.Model;
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

            BugDAO BugDAO = new BugDAO();
            try
            {
                List<BugViewModel> list = BugDAO.getAllBugs();
                var newLoopPanel = new LoopPanel();
                var newUpdateBug = new UpdateBug(false);
                newLoopPanel.loopPanel(list, panelBugs, this, newUpdateBug);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            try
            {
                List<BugViewModel> bug = BugDAO.GetAllBugsByProgrammerId(Login.userId);
                var newLoopPanel = new LoopPanel();
                var newUpdateBug = new UpdateBug(true);
                newLoopPanel.loopPanel(bug, panelAssigned, this, newUpdateBug);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
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
