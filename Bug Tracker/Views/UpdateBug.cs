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
    public partial class UpdateBug : Form
    {
        private string imageName;
        private string ImageName;
        private string programmingLanguage;
        private string currentImageName;
        private string codeFileName;

        public static int bugId = 0;
        private int codeId = 0;
        private int imageId = 0;
        private bool disableButtons = false;

        BugDAO bugDAO = new BugDAO();
        BugViewModel bug = null;

        public UpdateBug(bool disableButtons)
        {
            InitializeComponent();
            this.disableButtons = disableButtons;
        }

        private void UpdateBug_Load(object sender, EventArgs e)
        {
            bug = bugDAO.GetById(Program.bugId);
            this.StartPosition = FormStartPosition.CenterScreen;
            //this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            if (disableButtons)
            {
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                button2.Hide();
                button3.Hide();
                updatebtn.Hide();
                button5.Show();
            }
            else
            {
                button5.Show();
            }



            //binding value to related labels and textbox
            label2.Text = bug.ProjectName;
            textBox2.Text = bug.ClassName;
            textBox3.Text = bug.MethodName;
            textBox4.Text = bug.StartLine.ToString();
            textBox5.Text = bug.EndLine.ToString();
            programmingLanguage = bug.Codes.ProgrammingLanguage;
            currentImageName = bug.Images.ImageName;
            codeFileName = bug.Codes.CodeFileName;
            //assiging related table's id
            bugId = bug.BugId;
            codeId = bug.Codes.CodeId;
            imageId = bug.Images.ImageId;
            linkLabel1.Text = bug.SourceControl.Link;

            /*
             *Open the file to read from.
             * reading text from code file
             */
            string path = bug.Codes.CodeFilePath + "/" + bug.Codes.CodeFileName + ".txt";
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    fastColoredTextBox1.Text = fastColoredTextBox1.Text + Environment.NewLine + s;
                }
            }

            //assigning programming language for text box
            string pl = bug.Codes.ProgrammingLanguage;

            if (pl == "CSharp")
            {
                fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.CSharp;
            }
            else if (pl == "HTML")
            {
                fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.HTML;
            }
            else if (pl == "JavaScript")
            {
                fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.JS;
            }
            else if (pl == "Lua")
            {
                fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.Lua;
            }
            else if (pl == "PHP")
            {
                fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.PHP;
            }
            else if (pl == "SQL")
            {
                fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.SQL;
            }
            else if (pl == "VB")
            {
                fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.VB;
            }
            else if (pl == "XML")
            {
                fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.XML;
            }

            if (bug.Images.ImageName != "")
            {
                pictureBox1.Image = new Bitmap(Path.Combine(bug.Images.ImagePath + "/", bug.Images.ImageName));
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Bugs().Show();
            this.Dispose();
        }



        private void button2_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            //openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog.Filter = "Images|*.png;*.bmp;*.jpg";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                imageName = openFileDialog.FileName;
                //imgn = Path.GetFileName(openFileDialog.FileName);
                ImageName = openFileDialog.SafeFileName;
                pictureBox1.Image = new Bitmap(imageName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            ImageDAO imageDAO = new ImageDAO();
            CodeDAO codeDAO = new CodeDAO();
            VersionControlDAO sourceControl = new VersionControlDAO();
            BugDAO bugDAO = new BugDAO();

            DialogResult dr = MessageBox.Show("Are you sure want to delete this bug?", "Are you sure", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    codeDAO.Delete(bugId);
                    imageDAO.Delete(bugId);
                    bugDAO.Delete(bugId);
                    sourceControl.Delete(bugId);

                    MessageBox.Show("Deleted");
                    this.Dispose();
                    new Bugs().Show();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabel1.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new SymptomsAndCause().Show();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            string codeFileName = bug.Codes.CodeFileName;
            string codeFilePath = bug.Codes.CodeFilePath;
            string c = fastColoredTextBox1.Text;

            BugFixerDAO fixerDAO = new BugFixerDAO();
            BugDAO bugDAO = new BugDAO();

            BugFixerViewModel fixer = new BugFixerViewModel
            {
                FixBy = Login.userId,
                BugId = Program.bugId
            };

            try
            {
                fixerDAO.Insert(fixer);
                bugDAO.BugFixed(Program.bugId);
                MessageBox.Show("Oh great work");
                this.Dispose();
                new Bugs().Show();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            string path = "code/" + codeFileName + ".txt";
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine(c);
            }
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabel1.Text);
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            //bug
            BugViewModel bug = new BugViewModel
            {
                BugId = bugId,
                ProjectName = label1.Text,
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
                bugDao.Update(bug);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //image


            if (!string.IsNullOrEmpty(ImageName))
            {
                string appPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\code_image\";
                Bug_Tracker.Model.PictureViewModel image = new Bug_Tracker.Model.PictureViewModel
                {
                    ImageId = imageId,
                    ImagePath = "code_image",
                    ImageName = ImageName,
                    BugId = bug.BugId
                };

                try
                {
                    ImageDAO codeDao = new ImageDAO();
                    codeDao.Update(image);

                    File.Delete("code_image/" + currentImageName);
                    File.Copy(imageName, appPath + ImageName);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ////code
            string c = fastColoredTextBox1.Text;

            //Code code = new Code
            //{
            //    CodeId = codeId,
            //    CodeFilePath = "code",
            //    CodeFileName = codeFileName,
            //    ProgrammingLanguage = programminLanguage,
            //    BugId = bug.BugId
            //};

            try
            {
                string path = @"code/" + codeFileName + ".txt";
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(c);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            MessageBox.Show("Updated");
        }
    }
    
}
