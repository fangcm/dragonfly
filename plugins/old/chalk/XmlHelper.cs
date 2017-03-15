using System;
using System.Drawing;
using System.IO;
using System.Xml;

namespace Dragonfly.Chalk
{
    public class XmlHelper
    {
        public static XmlDocument Load(string path)
        {
            try
            {
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(fs);
                fs.Flush();
                fs.Close();
                return xmldoc;
            }
            catch
            {
                return null;
            }
        }

        public static bool Save(string path, XmlDocument xmldoc)
        {
            try
            {
                FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Write);
                xmldoc.Save(fs);
                fs.Flush();
                fs.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool GetParamValue(XmlNode node, string param, bool defaultValue)
        {
            return Convert.ToBoolean(GetParamValue(node, param, Convert.ToString(defaultValue)));
        }

        public static int GetParamValue(XmlNode node, string param, int defaultValue)
        {
            return Convert.ToInt32(GetParamValue(node, param, Convert.ToString(defaultValue)));
        }

        public static DateTime GetParamValue(XmlNode node, string param, DateTime defaultValue)
        {
            return Convert.ToDateTime(GetParamValue(node, param, Convert.ToString(defaultValue)));
        }

        public static Color GetParamValue(XmlNode node, string param, Color defaultValue)
        {
            return ColorTranslator.FromWin32(GetParamValue(node, param, ColorTranslator.ToWin32(defaultValue)));
        }

        public static Font GetParamValue(XmlNode node, string param, Font defaultValue)
        {
            System.ComponentModel.TypeConverter converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(Font));
            return (Font)converter.ConvertFromString(GetParamValue(node, param, converter.ConvertToString(defaultValue)));
        }

        public static string GetParamValue(XmlNode node, string param, string defaultValue)
        {
            string value = GetAttributeValue(node, param);
            if (value == null)
            {
                return defaultValue;
            }
            else
            {
                return value;
            }
        }

        public static void PutParamValue(XmlNode node, string param, bool value)
        {
            PutParamValue(node, param, Convert.ToString(value));
        }

        public static void PutParamValue(XmlNode node, string param, int value)
        {
            PutParamValue(node, param, Convert.ToString(value));
        }

        public static void PutParamValue(XmlNode node, string param, DateTime value)
        {
            PutParamValue(node, param, Convert.ToString(value));
        }

        public static void PutParamValue(XmlNode node, string param, Color value)
        {
            PutParamValue(node, param, ColorTranslator.ToWin32(value));
        }

        public static void PutParamValue(XmlNode node, string param, Font value)
        {
            System.ComponentModel.TypeConverter converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(Font));
            PutParamValue(node, param, converter.ConvertToString(value));
        }

        public static void PutParamValue(XmlNode node, string param, string value)
        {
            PutAttributeValue(node,param,value);
        }

        public static string GetAttributeValue(XmlNode node, string attributeName)
        {
            if (node == null)
                return null;

            XmlAttribute attribute = node.Attributes[attributeName];
            if (attribute == null)
            {
                return null;
            }
            return attribute.Value;
        }

        public static string GetElementText(XmlNode node, string elementName)
        {
            if (node == null)
                return null;
            XmlNode child = node.SelectSingleNode(elementName);
            if (child == null)
                return null;
            return child.InnerText;
        }

        public static void PutAttributeValue(XmlNode node, string attributeName, string value)
        {
            if (node == null)
                return;

            XmlDocument doc = node.OwnerDocument;
            XmlAttribute attribute = doc.CreateAttribute(attributeName);
            attribute.Value = value;
            node.Attributes.Append(attribute);
        }

        public static void PutElementText(XmlNode node, string elementName, string value)
        {
            if (node == null)
                return;
            XmlNode child = node.SelectSingleNode(elementName);
            if (child == null)
            {
                child = node.OwnerDocument.CreateNode("element", elementName, "");
                node.AppendChild(child);
            }
            child.InnerText = value;
        }


    }
}
