using Bug_Tracker.DAO;
using Bug_Tracker.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Bug_Tracker.Views
{
    public partial class Main : Form
    {
        private int childFormNumber = 0;
        private string programminLanguage;
        private string imageName;
        private string ImageName;
        private string imageSource;
        private bool inserted = false;
        private bool inserted1 = false;
        private bool inserted2 = false;
        private bool inserted3 = false;
        public Main()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            //this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
                imageSource = Path.GetDirectoryName(FileName);
                Console.WriteLine(imageSource);
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.CSharp;
            label7.Text = "Programming language: C#";
            programminLanguage = "CSharp";

            ProjectDAO projectDAO = new ProjectDAO();
            List<string> list = projectDAO.GetAllProjectByUserId();

            foreach (string projectName in list)
            {
                comboBox1.Items.Add(projectName);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutUs().Show();
        }

        private void hTMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.HTML;
            label7.Text = "Programming language: HTML";
            programminLanguage = "HTML";
        }

        private void jSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.JS;
            label7.Text = "Programming language: JavaScript";
            programminLanguage = "JavaScript";
        }

        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.CSharp;
            label7.Text = "Programming language: C#";
            programminLanguage = "CSharp";
        }

        private void luaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.Lua;
            label7.Text = "Programming language: Lua";
            programminLanguage = "Lua";
        }

        private void pHPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.PHP;
            label7.Text = "Programming language: PHP";
            programminLanguage = "PHP";
        }

        private void sQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.SQL;
            label7.Text = "Programming language: SQL";
            programminLanguage = "SQL";
        }

        private void vBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.VB;
            label7.Text = "Programming language: VB";
            programminLanguage = "VB";
        }

        private void xMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.XML;
            label7.Text = "Programming language: XML";
            programminLanguage = "XML";
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            //openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog.Filter = "Images|*.png;*.bmp;*.jpg";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                imageName = openFileDialog.FileName;
                ImageName = openFileDialog.SafeFileName;
                pictureBox1.Image = new Bitmap(imageName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.SelectedItem.ToString()) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text) || string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox6.Text) || string.IsNullOrEmpty(textBox7.Text))
            {
                MessageBox.Show("You must add all project information");
            }
            else if (string.IsNullOrEmpty(fastColoredTextBox1.Text))
            {
                MessageBox.Show("Code field cann't be null");
            }
            else
            {
                //bug
                BugViewModel bug = new BugViewModel
                {
                    ProjectName = comboBox1.SelectedItem.ToString(),
                    ClassName = textBox2.Text,
                    MethodName = textBox3.Text,
                    StartLine = Convert.ToInt16(textBox4.Text),
                    EndLine = Convert.ToInt16(textBox5.Text),
                    ProgrammerId = Login.userId,
                    Status = "0"
                };

                try
                {
                    BugDAO bugDao = new BugDAO();
                    bugDao.Insert(bug);
                    inserted = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //image

                if (!string.IsNullOrEmpty(imageName))
                {
                    string appPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\code_image\";
                    Bug_Tracker.Model.PictureViewModel image = new Bug_Tracker.Model.PictureViewModel
                    {
                        ImagePath = "code_image",
                        ImageName = imageName,
                        BugId = bug.BugId
                    };

                    try
                    {
                        ImageDAO codeDao = new ImageDAO();
                        codeDao.Insert(image);

                        File.Copy(imageName, appPath + ImageName);

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    ////code
                    string c = fastColoredTextBox1.Text;
                    string codeFileName = DateTime.Now.Second.ToString();

                    CodeViewModel code = new CodeViewModel
                    {
                        CodeFilePath = "code",
                        CodeFileName = codeFileName,
                        ProgrammingLanguage = programminLanguage,
                        BugId = bug.BugId
                    };

                    try
                    {
                        CodeDAO codeDao = new CodeDAO();
                        codeDao.Insert(code);

                        string path = "code/" + codeFileName + ".txt";
                        if (!File.Exists(path))
                        {
                            // Create a file to write to.
                            using (StreamWriter sw = File.CreateText(path))
                            {
                                sw.WriteLine(c);
                            }
                        }

                        inserted2 = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    ////Link

                    VersionControl sourceControl = new VersionControl
                    {
                        Link = textBox1.Text,
                        StartLine = Convert.ToInt32(textBox6.Text),
                        EndLine = Convert.ToInt32(textBox7.Text),
                        BugId = bug.BugId
                    };

                    VersionControlDAO sourceControlDAO = new VersionControlDAO();

                    try
                    {
                        sourceControlDAO.Insert(sourceControl);
                        inserted3 = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    MessageBox.Show("Added");

                }
            }

        }

        private void toolStripSeparator5_Click(object sender, EventArgs e)
        {

        }

        private void allBugsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Bugs().Show();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.V))
            {
                try
                {
                    (sender as TextBox).Paste();
                    label8.Text = textBox1.Text;
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void fastColoredTextBox1_KeyUp(object sender, KeyEventArgs e)
        {

        }



        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(label8.Text);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void textBox1_KeyUp_1(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.V))
            {
                try
                {
                    (sender as TextBox).Paste();
                    linkLabel1.Text = textBox1.Text;
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            new Login().Show();
        }
    }
}
