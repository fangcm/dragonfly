﻿using System;
using System.IO;
using System.Xml;

namespace Dragonfly.Common.Utils
{
    public class XmlHelper
    {
        private readonly XmlDocument document;

        public XmlHelper()
        {
            document = new XmlDocument();
        }

        public XmlDocument Document
        {
            get { return document; }
        }

        public static bool GetBoolean(XmlNode node, string param, bool defaultValue)
        {
            try
            {
                return Convert.ToBoolean(GetString(node, param, Convert.ToString(defaultValue)));
            }
            catch
            {
                return defaultValue;
            }
        }

        public static int GetInt(XmlNode node, string param, int defaultValue)
        {
            try
            {
                return Convert.ToInt32(GetString(node, param, Convert.ToString(defaultValue)));
            }
            catch
            {
                return defaultValue;
            }
        }

        public static DateTime GetDateTime(XmlNode node, string param, DateTime defaultValue)
        {
            try
            {
                return Convert.ToDateTime(GetString(node, param, Convert.ToString(defaultValue)));
            }
            catch
            {
                return defaultValue;
            }
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
                child = node.OwnerDocument.CreateElement(elementName);
                node.AppendChild(child);
            }
            child.InnerText = value;
        }

        public XmlElement CreateRootElement(string rootName)
        {
            XmlDeclaration xmldecl = document.CreateXmlDeclaration("1.0", "UTF-8", null);
            document.AppendChild(xmldecl);

            XmlElement rootNode = document.CreateElement(rootName);
            document.AppendChild(rootNode);

            return rootNode;
        }

        public bool Load(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return false;
            }

            try
            {
                document.Load(path);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Save(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return false;
            }

            try
            {
                document.Save(path);
                return true;
            }
            catch
            {
                return false;
            }
        }


    }

}
