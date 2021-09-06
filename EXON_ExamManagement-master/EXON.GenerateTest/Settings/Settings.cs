using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using Tung.Log;

namespace EXON.GenerateTest.Settings
{
    public static class XMLSettings
    {
        public const string VERSION = "RELEASE3";
        public static bool GenerateTestNotSame { get; private set; }
        public static bool AutoNumberOfTest { get; private set; }
        public static ushort NumberOfOriginalTest { get; private set; }
        public static bool GenerateFromOrignalTest { get; private set; }
        public static bool GenerateFromBank { get; private set; }
        public static bool RandomQuestion { get; private set; }

        public static float ScaleNumOfTest { get; private set; }

        private static string _settingsFilePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
            "Application",
            "GenerateTest",
            "settings.xml");

        public static bool WriteDefaultSettings()
        {
            try
            {
                if (!File.Exists(_settingsFilePath))
                {
                    XmlDocument doc = new XmlDocument();
                    XmlNode root = doc.CreateElement("settings");
                    doc.AppendChild(root);

                    root.AppendChild(doc.CreateElement("GenerateTestNotSame")).InnerText = "True";
                    root.AppendChild(doc.CreateElement("AutoNumberOfTest")).InnerText = "False";
                    root.AppendChild(doc.CreateElement("NumberOfOriginalTest")).InnerText = "3";
                    root.AppendChild(doc.CreateElement("GenerateFromOrignalTest")).InnerText = "False";
                    root.AppendChild(doc.CreateElement("GenerateFromBank")).InnerText = "True";
                    root.AppendChild(doc.CreateElement("ScaleNumOfTest")).InnerText = "1.5";
                    root.AppendChild(doc.CreateElement("RandomQuestion")).InnerText = "False";

                    doc.Save(_settingsFilePath);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string ReadValue(string pstrValueToRead)
        {
            try
            {
                string directoryPath = Path.GetDirectoryName(_settingsFilePath);
                if (!Directory.Exists(directoryPath))
                    Directory.CreateDirectory(directoryPath);

                XPathDocument doc = new XPathDocument(_settingsFilePath);
                XPathNavigator nav = doc.CreateNavigator();
                var expr = nav.Compile(@"/settings/" + pstrValueToRead);
                XPathNodeIterator iterator = nav.Select(expr);
                while (iterator.MoveNext())
                {
                    return iterator.Current.Value;
                }

                return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }

        public static bool WriteValue(string pstrValueToRead, string pstrValueToWrite)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                using (var reader = new XmlTextReader(_settingsFilePath))
                {
                    doc.Load(reader);
                }

                XmlElement root = doc.DocumentElement;
                var oldNode = root.SelectSingleNode(@"/settings/" + pstrValueToRead);
                if (oldNode == null) // create if not exist
                {
                    oldNode = doc.SelectSingleNode("settings");
                    oldNode.AppendChild(doc.CreateElement(pstrValueToRead)).InnerText = pstrValueToWrite;
                    doc.Save(_settingsFilePath);
                    return true;
                }
                oldNode.InnerText = pstrValueToWrite;
                doc.Save(_settingsFilePath);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void ReadSettings(bool writeIfNotExist = true)
        {
            if (writeIfNotExist)
                XMLSettings.WriteDefaultSettings();

            try
            {
                XMLSettings.GenerateTestNotSame = bool.Parse(XMLSettings.ReadValue("GenerateTestNotSame"));
                XMLSettings.AutoNumberOfTest = bool.Parse(XMLSettings.ReadValue("AutoNumberOfTest"));
                XMLSettings.NumberOfOriginalTest = ushort.Parse(XMLSettings.ReadValue("NumberOfOriginalTest"));
                XMLSettings.GenerateFromOrignalTest = bool.Parse(XMLSettings.ReadValue("GenerateFromOrignalTest"));
                //XMLSettings.ScaleNumOfTest = float.Parse(XMLSettings.ReadValue("ScaleNumOfTest"));
                XMLSettings.ScaleNumOfTest = 1.5f;
                XMLSettings.RandomQuestion = bool.Parse(XMLSettings.ReadValue("RandomQuestion"));
                XMLSettings.GenerateFromBank = bool.Parse(XMLSettings.ReadValue("GenerateFromBank"));
            }
            catch (Exception ex)
            {
                Log.Instance.WriteErrorLog(LogType.ERROR, ex.Message);
            }
        }
    }
}