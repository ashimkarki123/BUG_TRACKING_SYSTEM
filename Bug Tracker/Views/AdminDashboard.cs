using Bug_Tracker.DAO;
using Bug_Tracker.Model;
using System;
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
    public partial class AdminDashboard : Form
    {
        private int projectId = 0;
        private int programmerId = 0;

        public AdminDashboard()
        {
            InitializeComponent();
            GetAllProgrammers();
            btnAdd.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string projectName = txtProjectName.Text;
            ProjectViewModel project = new ProjectViewModel { ProjectName = projectName};

            if (string.IsNullOrEmpty(projectName)) {
                MessageBox.Show("You must add some project");
            } else
            {
                ProjectDAO projectDAO = new ProjectDAO();
                projectDAO.Insert(project);
                listView1.Items.Clear();
                GetAllProject();
            }
        }

        /// <summary>
        /// Return all the project
        /// </summary>
        private void GetAllProject()
        {
            ProjectDAO projectDAO = new ProjectDAO();
            List<ProjectViewModel> project = projectDAO.GetAll();

            foreach (var p in project)
            {
                listView1.Items.Add(p.ProjectId+","+p.ProjectName);
            }
        }
        /// <summary>
        /// returns all the programmers
        /// </summary>

        private void GetAllProgrammers()
        {
            ProgrammerDAO dao = new ProgrammerDAO();
            List<ProgrammerViewModel> list = dao.GetAll();

            foreach(var l in list)
            {
                comboBox1.Items.Add(l.ProgrammerId + "," + l.FullName);
            }
        }

        
        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            button3.Hide();
            button4.Hide();
            textBoxUpdate.Hide();
            GetAllProject();
        }

        private void addUserToComapnyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Register().Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Admin().Show();
            this.Hide();
            Program.adminId = 0;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Register().Show();
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            button3.Show();
            button4.Show();
            textBoxUpdate.Show();
            string[] arr = listView1.SelectedItems[0].ToString().Split(',');
            projectId = Convert.ToInt32(arr[0]);

            listBox1.Items.Clear();
            GetAllProgrammer();
        }

        private void GetAllProgrammer()
        {
            ProgrammerDAO programmerDAO = new ProgrammerDAO();
            //Programmer p = programmerDAO.GetById(programmerId);
            List<String> programmers = new List<String>();

            ProjectProgrammerDAO projectProgrammerDAO = new ProjectProgrammerDAO();
            List<ProjectProgrammer> list = projectProgrammerDAO.GetAllProjectsByProjectId(projectId);
            //projectProgrammerDAO.GetAll();

            foreach (var l in list)
            {
                ProgrammerViewModel p = programmerDAO.GetById(Convert.ToInt32(l.ProgrammerId));
                programmers.Add(p.ProgrammerId + "," + p.FullName);
            }

            foreach (var a in programmers)
            {
                listBox1.Items.Add(a);
            }

        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            //string selected = comboBox1.GetItemText(comboBox1.SelectedItem);
            //Console.WriteLine(comboBox1.Text);
            //btnAdd.Visible = true;
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAdd.Visible = true;

            string[] arr = comboBox1.Text.ToString().Split(',');
            programmerId = Convert.ToInt32(arr[0]);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (projectId == 0)
            {
                MessageBox.Show("Plase select project name first");
            } else
            {
                ProjectProgrammerDAO projectProgrammerDAO = new ProjectProgrammerDAO();
                ProjectProgrammer projectProgrammer = new ProjectProgrammer
                {
                    ProjectId = projectId,
                    ProgrammerId = programmerId
                };

                try
                {
                    projectProgrammerDAO.Insert(projectProgrammer);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                listBox1.Items.Clear();
                GetAllProgrammer();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            try
            {
                ProjectDAO projectDAO = new ProjectDAO();
                bool res = projectDAO.Delete(projectId);

                if (res)
                {
                    listView1.Items.Clear();
                    GetAllProject();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string projectName = textBoxUpdate.Text;
            ProjectDAO projectDAO = new ProjectDAO();
            ProjectViewModel project = new ProjectViewModel
            {
                ProjectId = projectId,
                ProjectName = projectName
            };

            if(string.IsNullOrEmpty(projectName))
            {
                MessageBox.Show("Project name is empty");
            } else
            {
                listView1.Items.Clear();
                projectDAO.Update(project);
                GetAllProject();
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            ProjectProgrammerDAO projectProgrammer = new ProjectProgrammerDAO();
            bool res = projectProgrammer.Delete(programmerId);
            listBox1.Items.Clear();
            GetAllProgrammer();
        }
    }
}
