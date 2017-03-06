using Dragonfly.Questions.Core;
using Dragonfly.Task.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Dragonfly.Questions.Notify
{
    internal partial class MainForm : LockScreenForm
    {
        MockExamUtil mockExamUtil = new MockExamUtil();
        private Reading reading;
        private int currentQuestionIndex;
        private object[] userAnswers = null;

        public override string ClockText
        {
            get
            {
                return this.label_clock.Text;
            }
            set
            {
                this.label_clock.Text = value;
            }
        }

        public MainForm()
        {
            InitializeComponent();

#if DEBUG
            //this.IsDebugMode = true;
#endif

            this.panelMain.Visible = false;
            this.panelMain.Dock = DockStyle.Fill;
            this.panelStart.Visible = true;
            this.panelStart.Dock = DockStyle.Fill;

            this.label_tip.Text = "Please do exercises and SAVE time .";
        }

        private void btn_start_exam_Click(object sender, EventArgs e)
        {
            Reading reading = mockExamUtil.GetMockReading();
            if (reading == null)
            {
                MessageBox.Show(this, "试题库里面的题都做完了，没有试题了，请联系出题老师。", "提示", MessageBoxButtons.OK);
                Clear();
                return;
            }

            this.panelStart.Visible = false;
            this.panelMain.Visible = true;

            this.btn_previous.Enabled = true;
            this.btn_next.Enabled = true;

            Init(reading);
        }

        private void Init(Reading reading)
        {
            this.reading = reading;
            userAnswers = new object[reading.Questions.Count];

            currentQuestionIndex = 0;
            PrintQuestionToScreen();
        }

        private void Clear()
        {
            this.btn_previous.Enabled = false;
            this.btn_next.Enabled = false;

            labelReadingTitle.Text = "";
            txt_reading.Clear();
            labelQuestionNo.Text = "";
            txt_question.Clear();

            RemoveOptions();
        }

        private void btn_previous_Click(object sender, EventArgs e)
        {
            if (currentQuestionIndex <= 0)
            {
                MessageBox.Show(this, "It's the first question.", "Tips", MessageBoxButtons.OK);
                return;
            }

            userAnswers[currentQuestionIndex] = SelectedAnswer();

            currentQuestionIndex--;
            PrintQuestionToScreen();
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            if (currentQuestionIndex >= reading.Questions.Count - 1)
            {
                if (MessageBox.Show(this, "This is the last question,  do you want to end exercises ?", "Tips", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    FinishExam();
                    this.panelMain.Visible = false;
                    this.panelStart.Visible = true;
                }
                return;
            }

            userAnswers[currentQuestionIndex] = SelectedAnswer();

            currentQuestionIndex++;
            PrintQuestionToScreen();
        }

        private void PrintQuestionToScreen()
        {
            RemoveOptions();
            Question question = reading.Questions[currentQuestionIndex];
            labelQuestionNo.Text = question.No.ToString();
            txt_question.SetLineHeight(1, 0);
            txt_question.Text = question.Text;
            AddOptions(question.Options, question.IsMultipleChoice);

            if (currentQuestionIndex == 0)
            {
                labelReadingTitle.Text = reading.Title;

                txt_reading.Clear();
                txt_reading.SelectionIndent = 60;
                txt_reading.SelectionHangingIndent = -40;
                txt_reading.SelectionRightIndent = 12;
                txt_reading.SetLineHeight(1, 0);
                txt_reading.SelectedText = reading.Text;
            }

        }

        private void AddOptions(List<Option> options, bool isMultipleChoice)
        {
            for (int i = 0; i < options.Count; i++)
            {
                if (isMultipleChoice)
                {
                    CheckBox chk = new CheckBox()
                    {
                        AutoSize = true,
                        Text = options[i].Alphabet + ". - " + options[i].Text,
                        Name = "chk" + options[i].Alphabet,
                    };
                    if (userAnswers[currentQuestionIndex] != null && ((char[])userAnswers[currentQuestionIndex]).Contains(options[i].Alphabet))
                        chk.Checked = true;
                    this.flp_options.Controls.Add(chk);
                }
                else
                {
                    RadioButton rdb = new RadioButton()
                    {
                        AutoSize = true,
                        Text = options[i].Alphabet + ". - " + options[i].Text,
                        Name = "rdb" + options[i].Alphabet,
                    };
                    if (userAnswers[currentQuestionIndex] != null && (char)userAnswers[currentQuestionIndex] == options[i].Alphabet)
                        rdb.Checked = true;
                    this.flp_options.Controls.Add(rdb);
                }
            }
        }

        private void RemoveOptions()
        {
            for (int j = this.flp_options.Controls.OfType<RadioButton>().Count() - 1; j >= 0; --j)
            {
                var controls = this.flp_options.Controls.OfType<RadioButton>();
                var control = controls.ElementAt(j);
                this.flp_options.Controls.Remove(control);
                control.Dispose();
            }
            for (int j = this.flp_options.Controls.OfType<CheckBox>().Count() - 1; j >= 0; --j)
            {
                var controls = this.flp_options.Controls.OfType<CheckBox>();
                var control = controls.ElementAt(j);
                this.flp_options.Controls.Remove(control);
                control.Dispose();
            }
        }

        private object SelectedAnswer()
        {
            // Get the current question
            Question currentQuestion = reading.Questions[currentQuestionIndex];
            // Determine the question type and return an answer
            if (currentQuestion.IsMultipleChoice)
            {
                var chks = flp_options.Controls.OfType<CheckBox>().Where(s => s.Checked);
                if (chks == null || chks.Count() == 0)
                {
                    return new List<char>().ToArray();
                }
                else
                {
                    return chks.Select(s => Convert.ToChar(s.Text.Substring(0, 1))).ToArray();
                }
            }
            else
            {
                var rdb = flp_options.Controls.OfType<RadioButton>().FirstOrDefault(s => s.Checked);
                if (rdb == null)
                {
                    return '\0';
                }
                else
                {
                    return Convert.ToChar(rdb.Text.Substring(0, 1));
                }
            }
        }

        private void FinishExam()
        {
            //Save current answer
            userAnswers[currentQuestionIndex] = SelectedAnswer();

            int numOfAnswers = 0;
            int numOfCorrectAnswers = 0;
            for (int i = 0; i < reading.Questions.Count; i++)
            {
                if (userAnswers[i] != null)
                {
                    numOfAnswers++;
                    if (userAnswers[i].GetType().IsArray)
                    {
                        if (((char[])userAnswers[i]).SequenceEqual(reading.Questions[i].Answers))
                        {
                            numOfCorrectAnswers++;
                        }
                    }
                    else if ((char)userAnswers[i] == reading.Questions[i].Answer)
                    {
                        numOfCorrectAnswers++;
                    }
                }
            }

            decimal temp = numOfCorrectAnswers;
            if (mockExamUtil.Examination.ExamProperties.Score < 1)
            {
                temp = 0;
            }
            else
            {
                temp = (temp / reading.Questions.Count * mockExamUtil.Examination.ExamProperties.Score);
            }

            int resultScore = Convert.ToInt32(temp);
            int savingMinutes = resultScore;
            string tip = string.Format("Answer the {0} questions, the correct {1}, save for {2} minutes.", numOfAnswers, numOfCorrectAnswers, savingMinutes);

            if (resultScore >= mockExamUtil.Examination.ExamProperties.PassScore)
            {
                ReadingResult readingResult = new ReadingResult();
                readingResult.Title = reading.Title;
                readingResult.NumberOfQuestions = reading.Questions.Count;
                readingResult.NumberOfCorrectAnswers = numOfCorrectAnswers;

                mockExamUtil.SaveMockResult(readingResult);

                MessageBox.Show(this, tip, "Tips", MessageBoxButtons.OK);
                this.AddIntervalSeconds(0 - savingMinutes * 60);

            }
            else
            {
                tip += "\n你获得" + resultScore + "分，本题总分是" + mockExamUtil.Examination.ExamProperties.Score +
                    "，你需要达到至少" + mockExamUtil.Examination.ExamProperties.PassScore + "分才能过关。";
                MessageBox.Show(this, tip, "Tips", MessageBoxButtons.OK);
            }
        }

        private void btn_change_Click(object sender, EventArgs e)
        {
            if (reading != null)
            {
                if (MessageBox.Show(this, "Waste 5 minutes to change incomplete exercises, are you sure?", "Tips", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
                this.AddIntervalSeconds(300);
            }
            this.panelMain.Visible = false;
            this.panelStart.Visible = true;

        }



    }
}
