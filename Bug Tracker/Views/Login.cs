using Bug_Tracker.DAO;
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
    public partial class Login : Form
    {

        public static int userId = 0;

        public Login()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
            this.StartPosition = FormStartPosition.CenterScreen;
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.WindowState = FormWindowState.Maximized;
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //getting user input from text box
            string AccountType = comboBox1.GetItemText(comboBox1.SelectedItem);
            string username = textBox1.Text;
            string password = textBox2.Text;

            //checking nullable
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username and password cann't be null");
            } else
            {
                if (AccountType == "Programmer")
                {
                    if (new ProgrammerDAO().IsLogin(username, password) > 0)
                    {
                        userId = new ProgrammerDAO().IsLogin(username, password);
                        this.Hide();
                        new Main().Show();
                    } else
                    {
                        MessageBox.Show("Invalid username or password");
                    }
                }
                else
                {
                    if (new TesterDAO().IsLogin(username, password) > 0)
                    {
                        userId = new TesterDAO().IsLogin(username, password);
                        this.Hide();
                        new Main().Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password");
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //opening new windows form
            Application.Exit();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loginAsAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Admin().Show();
        }
    }
}
