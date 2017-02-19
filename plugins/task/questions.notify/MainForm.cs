﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Dragonfly.Questions.Notify
{
    public partial class MainForm : Form
    {
        MockExamUtil mockExamUtil;
        private Reading reading;
        private int currentQuestionIndex;
        private object[] userAnswers = null;

        public MainForm()
        {
            InitializeComponent();
            mockExamUtil = new MockExamUtil();
            Init(mockExamUtil.GetMockReading());
        }

        public void Init(Reading reading)
        {
            this.reading = reading;
            currentQuestionIndex = 0;
            userAnswers = new object[reading.Questions.Count];

            PrintQuestionToScreen();
        }

        private void btn_previous_Click(object sender, EventArgs e)
        {
            userAnswers[currentQuestionIndex] = SelectedAnswer();

            RemoveOptions();

            currentQuestionIndex--;
            PrintQuestionToScreen();
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            userAnswers[currentQuestionIndex] = SelectedAnswer();

            RemoveOptions();

            currentQuestionIndex++;
            PrintQuestionToScreen();
        }

        private void PrintQuestionToScreen()
        {
            Question question = reading.Questions[currentQuestionIndex];
            labelReadingTitle.Text = reading.Title;
            txt_reading.Text = reading.Text;
            labelQuestionNo.Text = question.No.ToString();
            txt_question.Text = question.Text;
            AddOptions(question.Options, question.IsMultipleChoice);

            if (currentQuestionIndex == 0)
            {
                btn_previous.Enabled = false;
            }
            else
            {
                btn_previous.Enabled = true;
            }
            if (currentQuestionIndex == reading.Questions.Count - 1)
            {
                btn_next.Enabled = false;
            }
            else
            {
                btn_next.Enabled = true;
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

        private void EndExam()
        {
            //Save current answer
            userAnswers[currentQuestionIndex] = SelectedAnswer();
            //
            int numOfCorrectAnswers = 0;
            for (int i = 0; i < reading.Questions.Count; i++)
            {
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


    }
}
