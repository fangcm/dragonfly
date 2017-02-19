using Dragonfly.Questions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Dragonfly.Questions.Creator
{
    public partial class MainForm : Form
    {
        private Examination exam;
        private string currentExamFile;

        private bool IsDirty { get; set; }

        public MainForm()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeToolStripMenuItem_Click(sender, e);
            //
            this.exam = new Examination();
            this.splitContainer1.Panel2.Controls.Remove(this.panelSplash);
            splitContainer1.Panel2.Controls.Add(this.panelExam);
        }

 
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.openFileDialogExam.ShowDialog() == DialogResult.OK)
            {
                closeToolStripMenuItem_Click(sender, e);
                currentExamFile = openFileDialogExam.FileName;
                Open();
            }
        }

        private void Open()
        {
            this.exam = Helper.LoadExaminationFromFile(currentExamFile);
            if (this.exam != null)
            {
                this.treeViewExam.Nodes.Clear();
                //EnableExamControls();
                //EnableReadingControls();
                //
                ExamNode examNode = new ExamNode(exam.Properties);
                treeViewExam.Nodes.Add(examNode);
                foreach (Reading reading in exam.Readings)
                {
                    ReadingNode readingNode = new ReadingNode(reading.Title)
                    {
                        ContextMenuStrip = cms_reading
                    };
                    foreach (Question question in reading.Questions)
                    {
                        QuestionNode questionNode = new QuestionNode(question)
                        {
                            ContextMenuStrip = cms_question
                        };
                        //
                        readingNode.Nodes.Add(questionNode);
                    }
                    examNode.Nodes.Add(readingNode);
                }
                treeViewExam.ExpandAll();

                if (splitContainer1.Panel2.Controls.Contains(panelSplash))
                {
                    splitContainer1.Panel2.Controls.Remove(panelSplash);
                    splitContainer1.Panel2.Controls.Add(panelExam);
                }


                txt_title.Text = exam.Properties.Title;
                num_passmark.Value = (decimal)exam.Properties.Passmark;


            }
            else
            {
                MessageBox.Show("Sorry, the exam selected is either old or corrupt. If it is an old exam, please upgrade it with the upgrade tool at:\nhttps://sourceforge.net/projects/exam-upgrade-tool/", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentExamFile))
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }
            else
            {
                if (treeViewExam.SelectedNode != null)
                    if (treeViewExam.SelectedNode.GetType() == typeof(QuestionNode))
                        CommitQuestion();
                //
                ExamNode examNode = (ExamNode)treeViewExam.Nodes[0];
                this.exam.Properties = examNode.Properties;
                this.exam.Readings.Clear();
                foreach (ReadingNode readingNode in examNode.Nodes)
                {
                    Reading reading = new Reading()
                    {
                        Title = readingNode.Title
                    };
                    foreach (QuestionNode questionNode in readingNode.Nodes)
                    {
                        Question question = new Question();
                        question = questionNode.Question;
                        //
                        reading.Questions.Add(question);
                    }
                    this.exam.Readings.Add(reading);
                }
                //
                Helper.SaveExaminationToFile(currentExamFile, this.exam);
                MessageBox.Show("Exam has been sucessfully saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IsDirty = false;
            }


        }

        private void CommitQuestion()
        {
            Question question = ((QuestionNode)treeViewExam.SelectedNode).Question;
            question.IsMultipleChoice = chkMulipleChoice.Checked;
            if (question.IsMultipleChoice)
            {
                var answerCtrls = pan_options.Controls.OfType<OptionsControl>().Where(s => s.Checked);
                question.Answers = answerCtrls.Select(x => x.Letter).ToArray();
            }
            else
            {
                var answerCtrl = pan_options.Controls.OfType<OptionControl>().FirstOrDefault(s => s.Checked);
                question.Answer = answerCtrl == null ? '\0' : answerCtrl.Letter;
            }
 
            question.No = treeViewExam.SelectedNode.Index + 1;
            question.Options.Clear();
            if (question.IsMultipleChoice)
            {
                foreach (var ctrl in pan_options.Controls.OfType<OptionsControl>())
                {
                    Option option = new Option()
                    {
                        Alphabet = ctrl.Letter,
                        Text = ctrl.Text
                    };
                    question.Options.Add(option);
                }
            }
            else
            {
                foreach (var ctrl in pan_options.Controls.OfType<OptionControl>())
                {
                    Option option = new Option()
                    {
                        Alphabet = ctrl.Letter,
                        Text = ctrl.Text
                    };
                    question.Options.Add(option);
                }
            }
            question.Text = txt_question_text.Text;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.saveFileDialogExam.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialogExam.ShowDialog();
            if (string.IsNullOrWhiteSpace(saveFileDialogExam.FileName))
            {
                MessageBox.Show("Improper file name, Exam not saved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                currentExamFile = saveFileDialogExam.FileName;
                saveToolStripMenuItem_Click(sender, e);
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsDirty)
            {
                var response = MessageBox.Show("There are unsaved changes in your project. Do you want to save the changes before closing it?", "Unsaved Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (response == DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(sender, e);
                }
                else if (response == DialogResult.Cancel)
                {
                    return;
                }
            }
            //
            //ClearControls();
            this.treeViewExam.Nodes.Clear();
            //DisableAllControls();
            //
            if (splitContainer1.Panel2.Contains(panelReading))
            {
                splitContainer1.Panel2.Controls.Remove(panelReading);
                splitContainer1.Panel2.Controls.Add(panelSplash);
            }
            else if (splitContainer1.Panel2.Contains(panelQuestion))
            {
                splitContainer1.Panel2.Controls.Remove(panelQuestion);
                splitContainer1.Panel2.Controls.Add(panelSplash);
            }
            this.exam = null;
            IsDirty = false;


        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void treeViewExam_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeViewExam.SelectedNode.GetType() == typeof(ExamNode))
            {
                //
                if (splitContainer1.Panel2.Controls.Contains(panelQuestion))
                {
                    splitContainer1.Panel2.Controls.Remove(panelQuestion);
                    splitContainer1.Panel2.Controls.Add(panelExam);
                }
                else if (splitContainer1.Panel2.Controls.Contains(panelSplash))
                {
                    splitContainer1.Panel2.Controls.Remove(panelSplash);
                    splitContainer1.Panel2.Controls.Add(panelExam);
                }
            }
            else if (treeViewExam.SelectedNode.GetType() == typeof(ReadingNode))
            {
                //
                if (splitContainer1.Panel2.Controls.Contains(panelExam))
                {
                    splitContainer1.Panel2.Controls.Remove(panelExam);
                    splitContainer1.Panel2.Controls.Add(panelQuestion);
                }
                else if (splitContainer1.Panel2.Controls.Contains(panelSplash))
                {
                    splitContainer1.Panel2.Controls.Remove(panelSplash);
                    splitContainer1.Panel2.Controls.Add(panelQuestion);
                }
                panelQuestion.Enabled = false;
            }
            else
            {
                //
                if (splitContainer1.Panel2.Controls.Contains(panelExam))
                {
                    splitContainer1.Panel2.Controls.Remove(panelExam);
                    splitContainer1.Panel2.Controls.Add(panelQuestion);
                }
                else if (splitContainer1.Panel2.Controls.Contains(panelSplash))
                {
                    splitContainer1.Panel2.Controls.Remove(panelSplash);
                    splitContainer1.Panel2.Controls.Add(panelQuestion);
                }
                panelQuestion.Enabled = true;
                //
                Question question = ((QuestionNode)treeViewExam.SelectedNode).Question;
                txt_question_text.Text = question.Text;
                lbl_reading_question.Text = "Reading: " + treeViewExam.SelectedNode.Parent.Text + " Question " + question.No;

                //
                chkMulipleChoice.Checked = question.IsMultipleChoice;
                //
                pan_options.Controls.Clear();
                //
                int i = 0;
                if (question.IsMultipleChoice)
                {
                    foreach (var option in question.Options)
                    {
                        OptionsControl ctrl = new OptionsControl()
                        {
                            Letter = option.Alphabet,
                            Text = option.Text,
                            Location = new Point(2, i * 36)
                        };
                        if (question.Answers.Contains(option.Alphabet))
                        {
                            ctrl.Checked = true;
                        }
                        pan_options.Controls.Add(ctrl);
                        i++;
                    }
                }
                else
                {
                    foreach (var option in question.Options)
                    {
                        OptionControl ctrl = new OptionControl()
                        {
                            Letter = option.Alphabet,
                            Text = option.Text,
                            Location = new Point(2, i * 36)
                        };
                        if (option.Alphabet == question.Answer)
                        {
                            ctrl.Checked = true;
                        }
                        pan_options.Controls.Add(ctrl);
                        i++;
                    }
                }
            }
            //
            ReconnectHandlers();
        }

        private void treeViewExam_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            DisconnectHandlers();
            //
            if (treeViewExam.SelectedNode != null)
                if (treeViewExam.SelectedNode.GetType() == typeof(QuestionNode))
                {
                    CommitQuestion();
                    //
                    ClearControls();
                }
        }

        private void ClearControls()
        {
            lbl_reading_question.Text = "";
            txt_question_text.Clear();

            // Clear all the options
            pan_options.Controls.Clear();
            // Remove test in the text boxes
            txt_title.Clear();
        }

        private void DisconnectHandlers()
        {
            txt_question_text.TextChanged -= QuestionChanged;
        }

        private void ReconnectHandlers()
        {
            txt_question_text.TextChanged += QuestionChanged;
        }

        private void QuestionChanged(object sender, EventArgs e)
        {

        }

    }
}
