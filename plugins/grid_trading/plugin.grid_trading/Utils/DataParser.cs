using Microsoft.VisualBasic.FileIO;
using System.Collections.Generic;
using System.Text;

namespace Dragonfly.Plugin.GridTrading.Utils
{
    internal class DataParser
    {
        internal static List<string[]> ReadCsv(string fileName)
        {
            using (TextFieldParser parser = new TextFieldParser(fileName, Encoding.GetEncoding("gbk")))
            {
                List<string[]> rows = new List<string[]>();
                parser.TextFieldType = FieldType.Delimited;
                parser.HasFieldsEnclosedInQuotes = false;
                parser.Delimiters = (new string[] { " " });
                parser.CommentTokens = new string[] { "-" };
                parser.TrimWhiteSpace = true;

                while (!parser.EndOfData)
                {
                    rows.Add(filterEmpty(parser.ReadFields()));
                }
                return rows;
            }
        }

        private static string[] filterEmpty(string[] param)
        {
            List<string> ret = new List<string>();
            foreach (string item in param)
            {
                if (item.Length == 0 || item.Trim().Length == 0)
                {
                    continue;
                }
                ret.Add(item);
            }
            return ret.ToArray();
        }

    }
}
