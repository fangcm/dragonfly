using System.Windows.Forms;

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
        public Reading Reading { get; set; }

        public ReadingNode(Reading reading)
        {
            this.Text = reading.Title;
            this.Reading = reading;
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
