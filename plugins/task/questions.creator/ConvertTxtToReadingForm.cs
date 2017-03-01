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

namespace Dragonfly.Questions.Creator
{
    public partial class ConvertTxtToReadingForm : Form
    {
        private const int ProcessingTitle = 0;
        private const int ProcessingText = 1;
        private const int ProcessingQuestion = 2;
        private const int ProcessingOption = 3;

        public ConvertTxtToReadingForm()
        {
            InitializeComponent();
        }

        private Reading translate(string rawText)
        {
            using (StringReader sr = new StringReader(rawText))
            {
                Reading reading = new Reading();
                int processingType = ProcessingTitle;
                bool skipRead = false;
                string line = null;

                while (true)
                {
                    if (!skipRead)
                    {
                        line = sr.ReadLine();
                    }
                    skipRead = false;
                    if (line == null)
                    {
                        break;
                    }
                    switch (processingType)
                    {
                        case ProcessingTitle:
                            string title = line.Trim();
                            if (!string.IsNullOrWhiteSpace(title))
                            {
                                reading.Title = title;
                                processingType = ProcessingText;
                            }
                            break;

                        case ProcessingText:
                            string content = line.Trim();
                            if (content.StartsWith("1"))
                            {
                                processingType = ProcessingQuestion;
                                skipRead = true;
                            }
                            else
                            {
                                reading.Text += line + "\n";
                            }
                            break;

                        case ProcessingQuestion:
                            string question = line.Trim();
                            if (!string.IsNullOrWhiteSpace(question))
                            {
                                if (question.StartsWith("A"))
                                {
                                    processingType = ProcessingOption;
                                    skipRead = true;
                                }
                                else
                                {
                                    Question q = new Question()
                                    {
                                        No = reading.Questions.Count + 1,
                                        Text = question
                                    };
                                    reading.Questions.Add(q);
                                }
                            }
                            break;

                        case ProcessingOption:
                            string option = line.Trim();
                            if (!string.IsNullOrWhiteSpace(option))
                            {
                                char first = option[0];
                                if (first >= 'A' && first <= 'G')
                                {
                                    int startIdx = 1;
                                    if (option.Length > 2)
                                    {
                                        if (option[1] == '.' || option[1] == '．')
                                        {
                                            startIdx++;
                                        }
                                    }

                                    Option o = new Option()
                                    {
                                        Alphabet = first,
                                        Text = option.Substring(startIdx).Trim(),
                                    };
                                    Question q = reading.Questions.Last();
                                    q.Options.Add(o);
                                }
                                else if (first >= '1' && first <= '9')
                                {
                                    processingType = ProcessingQuestion;
                                    skipRead = true;
                                }
                                else
                                {
                                    processingType = ProcessingTitle;
                                    skipRead = true;
                                }
                            }
                            break;
                    }
                }
                return reading;
            }
        }

        private void tsb_translate_Click(object sender, EventArgs e)
        {
            txt_xmlreading.Clear();
            txt_xmlreading.SetLineHeight(1, 0);
            txt_xmlreading.SelectAll();
            Reading reading = translate(txt_rawtext.Text);
            txt_xmlreading.SelectedText = (reading == null) ? "" : Helper.SaveToString(reading, true);
        }
    }
}
