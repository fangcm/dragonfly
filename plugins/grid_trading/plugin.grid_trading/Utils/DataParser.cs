using Microsoft.VisualBasic.FileIO;
using System.Collections.Generic;

namespace Dragonfly.Plugin.GridTrading.Utils
{
    internal class DataParser
    {
        internal static List<string[]> ReadCsv(string fileName, string separator = " ", bool quote = false)
        {
            List<string[]> rows = new List<string[]>();
            TextFieldParser parser = new TextFieldParser(fileName /*, Encoding.GetEncoding("shift_jis")*/);
            //parser.TextFieldType = FieldType.FixedWidth;
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(separator);
            parser.HasFieldsEnclosedInQuotes = quote;

            while (!parser.EndOfData)
            {
                rows.Add(parser.ReadFields());
            }
            return rows;
        }
    }
}
