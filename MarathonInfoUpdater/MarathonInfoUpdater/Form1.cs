using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MarathonInfoUpdater
{
    public partial class MarathonInfoUpdaterForm : Form
    {
        public MarathonInfoUpdaterForm()
        {
            InitializeComponent();
        }

        private void MarathonInfoUpdaterForm_Load(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo textFiles = Directory.CreateDirectory("Text Files");
                ReadRunnerInfo();
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Warning: The directory and / or text files could not be found.\r\n" +
                                        "The files will be created upon first update of runner information.", "Warning",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void updateRunnerButton_Click(object sender, EventArgs e)
        {
            try
            {
                if ((this.nextGameTextBox.Text.Length > 0 &&
                    this.nextCategoryTextBox.Text.Length > 0 &&
                    this.nextEstimateTextBox.Text.Length > 0 &&
                    this.nextRunner1TextBox.Text.Length > 0))
                {
                    WriteRunnerInfo();
                    ReadRunnerInfo();
                } else
                {
                    var emptyRunnerDialog = MessageBox.Show(this, "Warning: You haven't filled out the runner's information.\r\n" +
                                                                    "Are you sure you still want to update it?", "Warning",
                                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                    switch (emptyRunnerDialog)
                    {
                        case DialogResult.Yes:
                            WriteRunnerInfo();
                            ReadRunnerInfo();
                            break;
                        case DialogResult.No:
                            break;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Error: The directory \"Text Files\" could not be found.\r\n" +
                                        "Please create the directory.", "Error",
                                           MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void WriteRunnerInfo()
        {
            StreamWriter gameWriter = new StreamWriter("./Text Files/game.txt", false);
            StreamWriter categoryWriter = new StreamWriter("./Text Files/category.txt", false);
            StreamWriter estimateWriter = new StreamWriter("./Text Files/estimate.txt", false);
            StreamWriter runner1Writer = new StreamWriter("./Text Files/runner1.txt", false);
            StreamWriter runner2Writer = new StreamWriter("./Text Files/runner2.txt", false);
            StreamWriter runner3Writer = new StreamWriter("./Text Files/runner3.txt", false);
            StreamWriter runner4Writer = new StreamWriter("./Text Files/runner4.txt", false);
            gameWriter.Write(this.nextGameTextBox.Text);
            categoryWriter.Write(this.nextCategoryTextBox.Text);
            estimateWriter.Write(this.nextEstimateTextBox.Text);
            runner1Writer.Write(this.nextRunner1TextBox.Text);
            runner2Writer.Write(this.nextRunner2TextBox.Text);
            runner3Writer.Write(this.nextRunner3TextBox.Text);
            runner4Writer.Write(this.nextRunner4TextBox.Text);
            gameWriter.Close();
            categoryWriter.Close();
            estimateWriter.Close();
            runner1Writer.Close();
            runner2Writer.Close();
            runner3Writer.Close();
            runner4Writer.Close();
        }

        private void ReadRunnerInfo()
        {
            StreamReader gameReader = new StreamReader("./Text Files/game.txt");
            StreamReader categoryReader = new StreamReader("./Text Files/category.txt");
            StreamReader estimateReader = new StreamReader("./Text Files/estimate.txt");
            StreamReader runner1Reader = new StreamReader("./Text Files/runner1.txt");
            StreamReader runner2Reader = new StreamReader("./Text Files/runner2.txt");
            StreamReader runner3Reader = new StreamReader("./Text Files/runner3.txt");
            StreamReader runner4Reader = new StreamReader("./Text Files/runner4.txt");
            this.currentGameTextBox.Text = gameReader.ReadToEnd();
            this.currentCategoryTextBox.Text = categoryReader.ReadToEnd();
            this.currentEstimateTextBox.Text = estimateReader.ReadToEnd();
            this.currentRunner1TextBox.Text = runner1Reader.ReadToEnd();
            this.currentRunner2TextBox.Text = runner2Reader.ReadToEnd();
            this.currentRunner3TextBox.Text = runner3Reader.ReadToEnd();
            this.currentRunner4TextBox.Text = runner4Reader.ReadToEnd();
            gameReader.Close();
            categoryReader.Close();
            estimateReader.Close();
            runner1Reader.Close();
            runner2Reader.Close();
            runner3Reader.Close();
            runner4Reader.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Runner Info Updater\r\n" +
                                    "Version 2019.02.26\r\n" + 
                                    "\u00A9 2019 Christopher Manuel\r\n\n" +
                                    "This program is provided for as-is and without warranty or support.\r\n" +
                                    "You may distribute this program any way you like.", "About Runner Info Updater", MessageBoxButtons.OK);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
