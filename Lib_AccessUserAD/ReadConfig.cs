using System;
using System.IO;
//using System.Reflection.PortableExecutable;
using System.Xml;

namespace Lib_AccessUserAD
{

    /// <summary>
    /// Чтение конфигов для настроек ПО
    /// </summary>
    public class xInfoConfig
    {
        string xLDAPUri_ActiveDyrectory;
        string xUserLDAPUri;

        public xInfoConfig(string xLDAPAD, string xLDAPUser)
        {
            if (((xLDAPAD != null) || (xLDAPAD != "")) && ((xLDAPUser != null) || (xLDAPUser != "")))
            {
                xLDAPUri_ActiveDyrectory = xLDAPAD;
                xUserLDAPUri = xLDAPUser;

                XmlDocument tXmlDocuments;
                tXmlDocuments = new XmlDocument();

                //XmlNode txmlNode;

                if (!File.Exists(Directory.GetCurrentDirectory().ToString() + "\\Config.xml"))
                {
                    tXmlDocuments.LoadXml("<CONFIG></CONFIG>");
                    tXmlDocuments.Save(Directory.GetCurrentDirectory().ToString() + "\\Config.xml");
                }
                else
                {
                    //---------------------------------------------------------------------------------------
                    //This piece of code checks to handle the exception when an error occurs during 
                    //loading. In this case, it may occur if the XML file structure is damaged. 
                    try
                    {
                        tXmlDocuments.Load(Directory.GetCurrentDirectory().ToString() + "\\Config.xml");
                    }
                    catch (XmlException)
                    {
                        //If a download error occurs, it simply creates a new file with a new structure
                        tXmlDocuments.LoadXml("<CONFIG></CONFIG>");
                        tXmlDocuments.Save(Directory.GetCurrentDirectory().ToString() + "\\Config.xml");
                    }
                    //---------------------------------------------------------------------------------------
                }

                //txmlNode = tXmlDocuments.CreateNode(XmlNodeType.Element, "LDAP", null);
                //tXmlDocuments.DocumentElement.AppendChild(txmlNode);

                XmlElement xmlElement_LDAP_AD; XmlText xmlText_LDAP_AD;
                XmlElement xmlElement_LDAP_User; XmlText xmlText_LDAP_User;

                if (tXmlDocuments.GetElementsByTagName("xmlElement_LDAP_AD") != null)
                {
                    //xmlElement_LDAP_AD = tXmlDocuments.GetElementsByTagName("xmlElement_LDAP_AD").Item(0).InnerText;
                } 
                else
                {
                    xmlElement_LDAP_AD = tXmlDocuments.CreateElement("LDAP_AD");
                    xmlText_LDAP_AD = tXmlDocuments.CreateTextNode(xLDAPAD);
                }
                
                xmlElement_LDAP_User = tXmlDocuments.CreateElement("LDAP_User");
                xmlText_LDAP_User = tXmlDocuments.CreateTextNode(xLDAPUser);
                
                //xmlElement_LDAP_AD.DocumentElement.AppendChild(xmlText_LDAP_AD);
                //tXmlDocuments.DocumentElement.AppendChild(xmlElement_LDAP_AD);

                xmlElement_LDAP_User.AppendChild(xmlText_LDAP_User);
                tXmlDocuments.DocumentElement.AppendChild(xmlElement_LDAP_User);

                tXmlDocuments.Save(Directory.GetCurrentDirectory().ToString() + "\\Config.xml");

                //if (!File.Exists(Directory.GetCurrentDirectory().ToString() + "\\Config.xml"))
                //{
                //    tXmlDocuments.CreateNode(XmlNodeType.Element, "LDAP_AD", xLDAPAD);
                //    tXmlDocuments.CreateNode(XmlNodeType.Element, "LDAP_UserUri", xLDAPUser);

                //    tXmlDocuments.Save(Directory.GetCurrentDirectory().ToString() + "\\Config.xml");

                //    //File.Create(Directory.GetCurrentDirectory().ToString() + "\\Config.xml");
                //}
                //else
                //{
                //    tXmlDocuments.LoadXml(Directory.GetCurrentDirectory().ToString() + "\\Config.xml");

                //}


            }
        }
    }

    public class ReadConfig
    {
        public static void GetConfig()
        {
            xInfoConfig newConfig;
            newConfig = new xInfoConfig("AD", "US");
        }
    }

   

}
