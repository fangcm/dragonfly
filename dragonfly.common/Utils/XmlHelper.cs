using System;
using System.Xml;

namespace Dragonfly.Common.Utils
{
    public class XmlHelper
    {
        public static bool GetBoolean(XmlNode node, string param, bool defaultValue)
        {
            return Convert.ToBoolean(GetString(node, param, Convert.ToString(defaultValue)));
        }

        public static int GetInt(XmlNode node, string param, int defaultValue)
        {
            return Convert.ToInt32(GetString(node, param, Convert.ToString(defaultValue)));
        }

        public static DateTime GetDateTime(XmlNode node, string param, DateTime defaultValue)
        {
            return Convert.ToDateTime(GetString(node, param, Convert.ToString(defaultValue)));
        }

        public static string GetString(XmlNode node, string param, string defaultValue)
        {
            string value = GetString(node, param);
            if (value == null)
            {
                return defaultValue;
            }
            else
            {
                return value;
            }
        }

        public static string GetString(XmlNode node, string attributeName)
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

        public static void PutBoolean(XmlNode node, string param, bool value)
        {
            PutString(node, param, Convert.ToString(value));
        }

        public static void PutInt(XmlNode node, string param, int value)
        {
            PutString(node, param, Convert.ToString(value));
        }

        public static void PutDateTime(XmlNode node, string param, DateTime value)
        {
            PutString(node, param, Convert.ToString(value));
        }

        public static void PutString(XmlNode node, string attributeName, string value)
        {
            if (node == null)
                return;

            XmlDocument doc = node.OwnerDocument;
            XmlAttribute attribute = doc.CreateAttribute(attributeName);
            attribute.Value = value;
            node.Attributes.Append(attribute);
        }

        public static string GetElementText(XmlNode node, string elementName, string defaultValue)
        {
            if (node == null)
                return defaultValue;
            XmlNode child = node.SelectSingleNode(elementName);
            if (child == null)
                return defaultValue;
            return child.InnerText;
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

        public static XmlDocument Load(string path)
        {
            try
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(path);
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
                xmldoc.Save(path);
                return true;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                return false;
            }
        }


    }

}
