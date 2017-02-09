using System;
using System.Xml;
using System.IO;
using System.Drawing;

namespace Dragonfly.Common.Utils
{
    public class XmlHelper
    {
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
            catch(Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
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
