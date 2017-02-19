﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dragonfly.Questions;

namespace Dragonfly.Questions.Creator
{
    public class ExamNode : TreeNode
    {
        public Dragonfly.Questions.Properties Properties { get; set; }

        public ExamNode(Dragonfly.Questions.Properties properties)
        {
            this.Text = properties.Title;
            this.Properties = properties;
            this.ImageIndex = 0;
            this.SelectedImageIndex = 0;
        }
    }

    public class ReadingNode : TreeNode
    {
        public string Title { get; set; }

        public ReadingNode(string title)
        {
            this.Text = title;
            this.Title = title;
            this.ImageIndex = 1;
            this.SelectedImageIndex = 1;
        }
    }

    public class QuestionNode : TreeNode
    {
        public Question Question { get; set; }

        public QuestionNode(Question question)
        {
            this.Text = "Question " + question.No;
            this.ImageIndex = 2;
            this.SelectedImageIndex = 2;
            this.Question = question;
        }
    }

}
