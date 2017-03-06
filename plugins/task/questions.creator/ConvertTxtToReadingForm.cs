using Dragonfly.Questions.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        private List<Reading> translate(string rawText)
        {
            using (StringReader sr = new StringReader(rawText))
            {
                List<Reading> result = new List<Reading>();
                Reading reading = new Reading();
                result.Add(reading);

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

                                    reading = new Reading();
                                    result.Add(reading);
                                }
                            }
                            break;
                    }
                }
                return result;
            }
        }

        private void tsb_translate_Click(object sender, EventArgs e)
        {
            txt_xmlreading.Clear();
            txt_xmlreading.SetLineHeight(1, 0);
            txt_xmlreading.SelectAll();
            var readings = translate(txt_rawtext.Text);
            txt_xmlreading.SelectedText = (readings == null) ? "" : Helper.SaveToString(readings, true);
        }
    }
}
