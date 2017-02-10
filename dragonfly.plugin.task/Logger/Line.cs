using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dragonfly.Plugin.Task.Logger
{
    public class Line
    {
        public long Row { get; set; }
        public string Type { get; set; }
        public string Text { get; set; }
        public DateTime Timestamp { get; set; }

        public string Assembly { get; set; }
        public string Filename { get; set; }
        public string Member { get; set; }
        public int LineNumber { get; set; }

        public static Line FromXmlNode(XmlNode lineNode)
        {
            var line = new Line();

            line.Text = lineNode.InnerText;

            DateTime ts = DateTime.MinValue;
            DateTime.TryParse(Attributes.Get(lineNode, "timestamp"), out ts);

            line.Timestamp = ts;
            line.Assembly = Attributes.Get(lineNode, "assembly");
            line.Filename = Attributes.Get(lineNode, "filename");
            line.Member = Attributes.Get(lineNode, "member");

            string lineNumber = Attributes.Get(lineNode, "line");
            if (lineNumber != null)
            {
                int n = -1;
                int.TryParse(lineNumber, out n);
                line.LineNumber = n;
            }

            return line;
        }
    }
}
