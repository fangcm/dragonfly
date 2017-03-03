﻿using System;
using System.Drawing;
using System.Linq;
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

            panel_exam.Dock = DockStyle.Fill;
            panelReading.Dock = DockStyle.Fill;
            panel_question.Dock = DockStyle.Fill;

            closeToolStripMenuItem.Enabled = true;
            saveAsToolStripMenuItem.Enabled = true;
            saveToolStripMenuItem.Enabled = true;

            PopulateBlankExam();
            IsDirty = false;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeToolStripMenuItem_Click(sender, e);

            if (!splitContainerMain.Panel2.Controls.Contains(this.panel_exam))
            {
                splitContainerMain.Panel2.Controls.Clear();
                splitContainerMain.Panel2.Controls.Add(this.panel_exam);
            }
            PopulateBlankExam();
            IsDirty = false;
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
                PopulateExam();
                IsDirty = false;
            }
            else
            {
                MessageBox.Show("Sorry, the exam selected is either old or corrupt. If it is an old exam, please upgrade it ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void PopulateExam()
        {
            this.treeViewExam.Nodes.Clear();
            if (this.exam != null)
            {
                ExamNode examNode = new ExamNode(exam.ExamProperties);
                treeViewExam.Nodes.Add(examNode);
                foreach (Reading reading in exam.Readings)
                {
                    ReadingNode readingNode = new ReadingNode(reading);

                    foreach (Question question in reading.Questions)
                    {
                        QuestionNode questionNode = new QuestionNode(question);
                        readingNode.Nodes.Add(questionNode);
                    }
                    examNode.Nodes.Add(readingNode);
                }
                treeViewExam.ExpandAll();

                if (!splitContainerMain.Panel2.Controls.Contains(panel_exam))
                {
                    splitContainerMain.Panel2.Controls.Clear();
                    splitContainerMain.Panel2.Controls.Add(panel_exam);
                }

                txt_exam_title.Text = exam.ExamProperties.Title;
                num_exam_score.Value = exam.ExamProperties.Score;
                num_exam_passscore.Value = exam.ExamProperties.PassScore;
            }
            else
            {
                PopulateBlankExam();
            }
            treeViewExam.SelectedNode = treeViewExam.Nodes[0];
        }

        private void PopulateBlankExam()
        {
            if (this.exam == null)
            {
                this.exam = new Examination();
                txt_exam_title.Text = exam.ExamProperties.Title = "New Title";
                num_exam_score.Value = exam.ExamProperties.Score = 0;
                num_exam_passscore.Value = exam.ExamProperties.PassScore = 0;

                save_properties();
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
                commit_change();
                if (treeViewExam.Nodes.Count == 0)
                {
                    MessageBox.Show("No data to save.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    IsDirty = false;
                    return;
                }

                fillExam();

                Helper.SaveExaminationToFile(currentExamFile, this.exam);
                MessageBox.Show("Exam has been sucessfully saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IsDirty = false;
            }

        }

        private void fillExam()
        {
            if (treeViewExam.Nodes.Count == 0)
                return;

            ExamNode examNode = (ExamNode)treeViewExam.Nodes[0];
            if (this.exam == null)
            {
                this.exam = new Examination();
            }
            this.exam.ExamProperties = examNode.ExamProperties;
            this.exam.Readings.Clear();
            foreach (ReadingNode readingNode in examNode.Nodes)
            {
                Reading reading = readingNode.Reading;
                reading.Questions.Clear();
                foreach (QuestionNode questionNode in readingNode.Nodes)
                {
                    Question question = questionNode.Question;
                    reading.Questions.Add(question);
                }
                this.exam.Readings.Add(reading);
            }
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


            this.treeViewExam.Nodes.Clear();

            if (splitContainerMain.Panel2.Contains(panelReading))
            {
                splitContainerMain.Panel2.Controls.Remove(panelReading);
                splitContainerMain.Panel2.Controls.Add(panel_exam);
            }
            else if (splitContainerMain.Panel2.Contains(panel_question))
            {
                splitContainerMain.Panel2.Controls.Remove(panel_question);
                splitContainerMain.Panel2.Controls.Add(panel_exam);
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
                addQuestionToolStripMenuItem.Enabled = false;
                delQuestionToolStripMenuItem.Enabled = false;
                delReadingToolStripMenuItem.Enabled = false;

                if (splitContainerMain.Panel2.Controls.Contains(panel_question))
                {
                    splitContainerMain.Panel2.Controls.Remove(panel_question);
                    splitContainerMain.Panel2.Controls.Add(panel_exam);
                }
                else if (splitContainerMain.Panel2.Controls.Contains(panelReading))
                {
                    splitContainerMain.Panel2.Controls.Remove(panelReading);
                    splitContainerMain.Panel2.Controls.Add(panel_exam);
                }

                txt_exam_title.TextChanged -= new System.EventHandler(this.Changed);
                num_exam_score.ValueChanged -= new System.EventHandler(this.Changed);
                num_exam_passscore.ValueChanged -= new System.EventHandler(this.Changed);

                ExamProperties properties = ((ExamNode)treeViewExam.SelectedNode).ExamProperties;
                txt_exam_title.Text = properties.Title;
                num_exam_score.Value = properties.Score;
                num_exam_passscore.Value = properties.PassScore;

                txt_exam_title.TextChanged += new System.EventHandler(this.Changed);
                num_exam_score.ValueChanged += new System.EventHandler(this.Changed);
                num_exam_passscore.ValueChanged += new System.EventHandler(this.Changed);
            }
            else if (treeViewExam.SelectedNode.GetType() == typeof(ReadingNode))
            {
                addQuestionToolStripMenuItem.Enabled = true;
                delQuestionToolStripMenuItem.Enabled = false;
                delReadingToolStripMenuItem.Enabled = true;

                if (splitContainerMain.Panel2.Controls.Contains(panel_exam))
                {
                    splitContainerMain.Panel2.Controls.Remove(panel_exam);
                    splitContainerMain.Panel2.Controls.Add(panelReading);
                }
                else if (splitContainerMain.Panel2.Controls.Contains(panel_question))
                {
                    splitContainerMain.Panel2.Controls.Remove(panel_question);
                    splitContainerMain.Panel2.Controls.Add(panelReading);
                }

                txt_reading_title.TextChanged -= new System.EventHandler(this.Changed);
                txt_reading_text.TextChanged -= new System.EventHandler(this.Changed);

                Reading reading = ((ReadingNode)treeViewExam.SelectedNode).Reading;
                txt_reading_title.Text = reading.Title;

                txt_reading_text.Clear();
                txt_reading_text.SelectionIndent = 60;
                txt_reading_text.SelectionHangingIndent = -40;
                txt_reading_text.SelectionRightIndent = 12;
                txt_reading_text.SetLineHeight(1, 0);
                txt_reading_text.SelectedText = reading.Text ?? "";

                txt_reading_title.TextChanged += new System.EventHandler(this.Changed);
                txt_reading_text.TextChanged += new System.EventHandler(this.Changed);
            }
            else
            {
                addQuestionToolStripMenuItem.Enabled = true;
                delQuestionToolStripMenuItem.Enabled = true;
                delReadingToolStripMenuItem.Enabled = false;

                if (splitContainerMain.Panel2.Controls.Contains(panel_exam))
                {
                    splitContainerMain.Panel2.Controls.Remove(panel_exam);
                    splitContainerMain.Panel2.Controls.Add(panel_question);
                }
                else if (splitContainerMain.Panel2.Controls.Contains(panelReading))
                {
                    splitContainerMain.Panel2.Controls.Remove(panelReading);
                    splitContainerMain.Panel2.Controls.Add(panel_question);
                }
                //
                Question question = ((QuestionNode)treeViewExam.SelectedNode).Question;
                lbl_reading_question.Text = "Reading: " + treeViewExam.SelectedNode.Parent.Text + ", Question " + question.No;

                txt_question_text.TextChanged -= new System.EventHandler(this.Changed);
                chkMulipleChoice.CheckedChanged -= new System.EventHandler(this.Changed);
                panel_question_options.ControlAdded -= new ControlEventHandler(this.OptionsChanged);
                panel_question_options.ControlRemoved -= new ControlEventHandler(this.OptionsChanged);

                txt_question_text.Text = question.Text;
                chkMulipleChoice.Checked = question.IsMultipleChoice;
                //
                panel_question_options.Controls.Clear();
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
                        ctrl.chkLetter.CheckedChanged += Changed;
                        panel_question_options.Controls.Add(ctrl);
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
                        ctrl.rdb_letter.CheckedChanged += Changed;
                        panel_question_options.Controls.Add(ctrl);
                        i++;
                    }
                }

                txt_question_text.TextChanged += new System.EventHandler(this.Changed);
                chkMulipleChoice.CheckedChanged += new System.EventHandler(this.Changed);
                panel_question_options.ControlAdded += new ControlEventHandler(this.OptionsChanged);
                panel_question_options.ControlRemoved += new ControlEventHandler(this.OptionsChanged);

                if (panel_question_options.Controls.Count > 0)
                    btn_remove_option.Enabled = true;
                else
                    btn_remove_option.Enabled = false;
            }

        }


        private void OptionsChanged(object sender, ControlEventArgs e)
        {
            if (panel_question_options.Controls.Count > 0)
                btn_remove_option.Enabled = true;
            else
                btn_remove_option.Enabled = false;

            IsDirty = true;
        }

        private void btn_add_options_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkMulipleChoice.Checked)
                {
                    if (panel_question_options.Controls.Count > 0)
                    {
                        OptionsControl ctrl = new OptionsControl()
                        {
                            Name = "option" + (panel_question_options.Controls.Count - 1),
                            Letter = (char)(Convert.ToInt32(((OptionsControl)panel_question_options.Controls[panel_question_options.Controls.Count - 1]).Letter) + 1),
                            Location = new Point(2, 2 + (panel_question_options.Controls.Count * 36))
                        };
                        ctrl.chkLetter.CheckedChanged += Changed;
                        panel_question_options.Controls.Add(ctrl);
                    }
                    else
                    {
                        OptionsControl ctrl = new OptionsControl()
                        {
                            Location = new Point(2, 2),
                            Name = "option0",
                            Letter = 'A'
                        };
                        ctrl.chkLetter.CheckedChanged += Changed;
                        panel_question_options.Controls.Add(ctrl);
                    }
                }
                else
                {
                    if (panel_question_options.Controls.Count > 0)
                    {
                        OptionControl ctrl = new OptionControl()
                        {
                            Name = "option" + (panel_question_options.Controls.Count - 1),
                            Letter = (char)(Convert.ToInt32(((OptionControl)panel_question_options.Controls[panel_question_options.Controls.Count - 1]).Letter) + 1),
                            Location = new Point(2, 2 + (panel_question_options.Controls.Count * 36))
                        };
                        ctrl.rdb_letter.CheckedChanged += Changed;
                        panel_question_options.Controls.Add(ctrl);
                    }
                    else
                    {
                        OptionControl ctrl = new OptionControl()
                        {
                            Location = new Point(2, 2),
                            Name = "option0",
                            Letter = 'A'
                        };
                        ctrl.rdb_letter.CheckedChanged += Changed;
                        panel_question_options.Controls.Add(ctrl);
                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Sorry, you cannot mix option types. First remove the existing options then replace them.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_remove_option_Click(object sender, EventArgs e)
        {
            if (chkMulipleChoice.Checked)
            {
                panel_question_options.Controls.Remove(panel_question_options.Controls.OfType<OptionsControl>().ElementAt(panel_question_options.Controls.OfType<OptionsControl>().Count() - 1));
            }
            else
            {
                panel_question_options.Controls.Remove(panel_question_options.Controls.OfType<OptionControl>().ElementAt(panel_question_options.Controls.OfType<OptionControl>().Count() - 1));
            }

        }


        private void addReadingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExamNode examNode = (ExamNode)treeViewExam.Nodes[0];
            Reading reading = new Reading()
            {
                Title = "new reading"
            };

            ReadingNode readingNode = new ReadingNode(reading);
            treeViewExam.Nodes[0].Nodes.Add(readingNode);

            treeViewExam.ExpandAll();

            IsDirty = true;
        }

        private void addQuestionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReadingNode nodeToBeAddedTo = treeViewExam.SelectedNode.GetType() == typeof(ReadingNode) ? (ReadingNode)treeViewExam.SelectedNode : (ReadingNode)treeViewExam.SelectedNode.Parent;
            Question question = new Question()
            {
                No = nodeToBeAddedTo.Nodes.Count + 1
            };

            QuestionNode questionNode = new QuestionNode(question);
            nodeToBeAddedTo.Nodes.Add(questionNode);

            treeViewExam.ExpandAll();

            IsDirty = true;
        }

        private void delReadingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var examNode = treeViewExam.SelectedNode.Parent;

            examNode.Nodes.Remove(treeViewExam.SelectedNode);

            IsDirty = true;
        }

        private void delQuestionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var readingNode = treeViewExam.SelectedNode.Parent;

            readingNode.Nodes.Remove(treeViewExam.SelectedNode);

            int i = 1;
            foreach (QuestionNode questionNode in readingNode.Nodes)
            {
                questionNode.Question.No = 1;
                questionNode.Text = "Question " + i;
                i++;
            }

            IsDirty = true;
        }

        private void treeViewExam_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            commit_change();
        }

        private void commit_change()
        {
            if (treeViewExam.SelectedNode == null)
                return;

            if (IsDirty)
            {
                Type selectType = treeViewExam.SelectedNode.GetType();
                if (selectType == typeof(ExamNode))
                {
                    save_properties();
                }
                else if (selectType == typeof(ReadingNode))
                {
                    save_reading();
                }
                else if (selectType == typeof(QuestionNode))
                {
                    save_question();
                }
            }
        }

        private void save_properties()
        {
            if (treeViewExam.Nodes.Count > 0)
            {
                ExamNode examNode = (ExamNode)treeViewExam.Nodes[0];
                examNode.ExamProperties.Title = txt_exam_title.Text;
                examNode.ExamProperties.Score = Convert.ToInt32(num_exam_score.Value);
                examNode.ExamProperties.PassScore = Convert.ToInt32(num_exam_passscore.Value);
                treeViewExam.Nodes[0].Text = examNode.ExamProperties.Title;
            }
            else
            {
                ExamProperties properties = new ExamProperties()
                {
                    Score = Convert.ToInt32(num_exam_score.Value),
                    PassScore = Convert.ToInt32(num_exam_passscore.Value),
                    Title = txt_exam_title.Text,
                };

                ExamNode examNode = new ExamNode(properties);
                treeViewExam.Nodes.Add(examNode);
            }

            treeViewExam.ExpandAll();

        }

        private void save_reading()
        {
            Reading reading = ((ReadingNode)treeViewExam.SelectedNode).Reading;
            reading.Title = txt_reading_title.Text;
            reading.Text = txt_reading_text.Text;

            treeViewExam.SelectedNode.Text = reading.Title;

        }

        private void save_question()
        {
            Question question = ((QuestionNode)treeViewExam.SelectedNode).Question;
            question.IsMultipleChoice = chkMulipleChoice.Checked;
            if (question.IsMultipleChoice)
            {
                var answerCtrls = panel_question_options.Controls.OfType<OptionsControl>().Where(s => s.Checked);
                question.Answers = answerCtrls.Select(x => x.Letter).ToArray();
            }
            else
            {
                var answerCtrl = panel_question_options.Controls.OfType<OptionControl>().FirstOrDefault(s => s.Checked);
                question.Answer = answerCtrl == null ? '\0' : answerCtrl.Letter;
            }

            question.No = treeViewExam.SelectedNode.Index + 1;
            question.Options.Clear();
            if (question.IsMultipleChoice)
            {
                foreach (var ctrl in panel_question_options.Controls.OfType<OptionsControl>())
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
                foreach (var ctrl in panel_question_options.Controls.OfType<OptionControl>())
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

        private void Changed(object sender, EventArgs e)
        {
            IsDirty = true;
        }

        private void chkMulipleChoice_CheckChanged(object sender, EventArgs e)
        {
            Changed(sender, e);
            panel_question_options.Controls.Clear();

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsDirty)
            {
                DialogResult result = MessageBox.Show("The current exam has not been saved, do you want to save and close?", "Unsaved Changes",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Cancel)
                    e.Cancel = true;
                else if (result == DialogResult.Yes)
                    saveToolStripMenuItem_Click(sender, e);
            }
        }

        private void tabControlMain_Selecting(object sender, TabControlCancelEventArgs e)
        {
            switch (tabControlMain.SelectedIndex)
            {
                case 0:
                    if (string.IsNullOrWhiteSpace(txt_exam_source.Text))
                    {
                        this.exam = null;
                    }
                    else
                    {
                        try
                        {
                            exam = Helper.LoadExaminationFromString(txt_exam_source.Text);
                        }
                        catch (Exception ex)
                        {
                            e.Cancel = true;
                            MessageBox.Show("转换文本错误" + ex.Message, "错误", MessageBoxButtons.OK);
                            return;
                        }
                        if (this.exam == null)
                        {
                            e.Cancel = true;
                            MessageBox.Show("转换文本错误", "错误", MessageBoxButtons.OK);
                            return;
                        }
                    }
                    PopulateExam();
                    break;
                case 1:
                    txt_exam_source.TextChanged -= new System.EventHandler(this.Changed);
                    commit_change();
                    fillExam();
                    txt_exam_source.Clear();
                    txt_exam_source.SetLineHeight(1, 0);
                    txt_exam_source.SelectedText = (exam == null) ? "" : Helper.SaveExaminationToString(exam, false);
                    txt_exam_source.TextChanged += new System.EventHandler(this.Changed);
                    break;
            }
        }

        private void txtToReadingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConvertTxtToReadingForm form = new ConvertTxtToReadingForm();
            form.ShowDialog(this);
        }
    }
}
