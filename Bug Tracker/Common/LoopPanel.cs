using Bug_Tracker.Model;
using Bug_Tracker.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bug_Tracker.Common
{
    class LoopPanel
    {
        //public int rowId = 0;
        public void loopPanel(List<BugViewModel> list, Panel mainPanel, Form closingFrame)
        {
            int x = 56;
            foreach (var bug in list)
            {//56
                //int x = 0;
                Panel panel = new Panel();
                panel.Text = bug.BugId.ToString();
                mainPanel.Controls.Add(panel);

                Label lblProject = new Label();
                Label lblClass = new Label();
                Label lblMethod = new Label();
                PictureBox pictureBox = new PictureBox();

                panel.Click += new EventHandler(toolStripClick);

                void toolStripClick(object sender, EventArgs e)
                {
                    Program.bugId = Convert.ToInt32(panel.Text);
                    new UpdateBug().Show();
                    closingFrame.Dispose();
                }

                //
                //panel
                //
                panel.BackColor = System.Drawing.Color.Black;
                panel.Controls.Add(lblMethod);
                panel.Controls.Add(lblClass);
                panel.Controls.Add(lblProject);
                panel.Controls.Add(pictureBox);
                panel.Location = new System.Drawing.Point(10, x);
                x += 105;
                panel.Name = panel + bug.BugId.ToString();
                panel.Size = new System.Drawing.Size(535, 100);
                panel.TabIndex = 1;
                //panel.Paint += new System.Windows.Forms.PaintEventHandler(panel_Paint);
                panel.SuspendLayout();
                //
                //lblProject
                //
                lblProject.AutoSize = true;
                lblProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lblProject.Location = new System.Drawing.Point(3, 3);
                lblProject.ForeColor = System.Drawing.Color.White;
                lblProject.Name = lblProject + bug.BugId.ToString();
                lblProject.Size = new System.Drawing.Size(50, 16);
                lblProject.TabIndex = 1;
                lblProject.Text = "Project: " + bug.ProjectName;

                //
                //lblClass
                //
                lblClass.AutoSize = true;
                lblClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lblClass.Location = new System.Drawing.Point(3, 34);
                lblClass.ForeColor = System.Drawing.Color.White;
                lblClass.Name = lblClass + bug.BugId.ToString();
                lblClass.Size = new System.Drawing.Size(42, 16);
                lblClass.TabIndex = 2;
                lblClass.Text = "Class: " + bug.ClassName;

                //
                //lblMethod
                //
                lblMethod.AutoSize = true;
                lblMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lblMethod.Location = new System.Drawing.Point(4, 71);
                lblMethod.ForeColor = System.Drawing.Color.White;
                lblMethod.Name = lblMethod + bug.BugId.ToString();
                lblMethod.Size = new System.Drawing.Size(53, 16);
                lblMethod.TabIndex = 3;
                lblMethod.Text = "Method: " + bug.MethodName;

                //
                //pictureBox
                //
                pictureBox.Location = new System.Drawing.Point(391, 3);
                pictureBox.Name = pictureBox + bug.BugId.ToString();
                pictureBox.Size = new System.Drawing.Size(141, 94);
                pictureBox.TabIndex = 0;
                pictureBox.TabStop = false;
                ((System.ComponentModel.ISupportInitialize)(pictureBox)).BeginInit();

                pictureBox.Image = new Bitmap(Path.Combine(bug.Images.ImagePath + "/", bug.Images.ImageName));
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

                panel.ResumeLayout(false);
                panel.PerformLayout();
                ((System.ComponentModel.ISupportInitialize)(pictureBox)).EndInit();
            }
        }
    }
}
