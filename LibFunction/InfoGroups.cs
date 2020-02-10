using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibFunction
{
    class XGroup
    {
        string x__department = "";
        string x__title = "";
        string x__company = "";

        /// <summary>
        /// Description All Constructor in the "XGroup" Class
        /// </summary>
        #region XGroup__Constructors
        public XGroup()
        {
            x__company = "";
            x__department = "";
            x__title = "";
        }

        public XGroup(string xcompany, string xdepartment, string xtitle)
        {
            x__company = xcompany;
            x__department = xdepartment;
            x__title = xtitle;
        }
        #endregion

        /// <summary>
        /// Description All Property in the "XGroup" Class
        /// </summary>
        #region Properties
        /// <summary>
        /// Set Or Get Properties "x__departmet"
        /// </summary>
        public string  p_department {
            get 
            {
                return x__department;
            }
            set 
            {
                x__department = value;
            }
        }
        
        /// <summary>
        /// Set Or Get Properties "x__title"
        /// </summary>
        public string p_title
        {
            get
            {
                return x__title;
            }
            set
            {
                x__title = value;
            }
        }

        /// <summary>
        /// Set Or Get Properties "x__company"
        /// </summary>
        public string p_company
        {
            get
            {
                return x__company;
            }
            set
            {
                x__company = value;
            }
        }
        #endregion

    }

    class InfoXGroups
    {
        const string x__NameXMLConfigConst = "InfXGroups.xml";

        List <XGroup> x__groupList = new List<XGroup> ();
        string x__PachXMLConfig;
        string x__NameXMLConfig;

        /// <summary>
        /// Description All Constructor in the "InfoXGroups" Class
        /// </summary>
        #region InfoXGroups_Constructors
        public InfoXGroups()
        {
            x__PachXMLConfig = Environment.CurrentDirectory;
            x__NameXMLConfig = x__NameXMLConfigConst;
        }

        public InfoXGroups(string p_CurrentDirectory)
        {
            if ((p_CurrentDirectory == null) || (p_CurrentDirectory == ""))
            {
                x__PachXMLConfig = Environment.CurrentDirectory;
            } 
            else
            {
                if (System.IO.Directory.Exists(p_CurrentDirectory))
                {
                    x__PachXMLConfig = p_CurrentDirectory;
                }
                else
                {
                    try
                    {
                        System.IO.Directory.CreateDirectory(p_CurrentDirectory);
                        x__PachXMLConfig = p_CurrentDirectory;
                    }
                    catch
                    {
                        x__PachXMLConfig = Environment.CurrentDirectory;
                    }
                }
            }

            x__NameXMLConfig = x__NameXMLConfigConst;
        }

        public InfoXGroups (string p_CurrentDirectory = "", string p_NameXMLConfig = "")
        {
            if ((p_CurrentDirectory == null) || (p_CurrentDirectory == ""))
            {
                x__PachXMLConfig = Environment.CurrentDirectory;
            }
            else
            {
                if (System.IO.Directory.Exists(p_CurrentDirectory))
                {
                    x__PachXMLConfig = p_CurrentDirectory;
                }
                else
                {
                    try
                    {
                        System.IO.Directory.CreateDirectory(p_CurrentDirectory);
                        if (System.IO.Directory.Exists(p_CurrentDirectory)) { x__PachXMLConfig = p_CurrentDirectory; }
                    }
                    catch
                    {
                        x__PachXMLConfig = Environment.CurrentDirectory;
                    }
                }
            }

            if ((p_NameXMLConfig == "") || (p_NameXMLConfig == null))
            {
                x__NameXMLConfig = x__NameXMLConfigConst;
            }
            else
            {
                if (System.IO.File.Exists(System.IO.Path.Combine(x__PachXMLConfig, p_NameXMLConfig)))
                {
                    x__NameXMLConfig = p_NameXMLConfig;
                }
                else
                {
                    try
                    {
                        System.IO.File.CreateText(System.IO.Path.Combine(x__PachXMLConfig, p_NameXMLConfig));
                        
                    }
                    catch
                    {
                        x__NameXMLConfig = x__NameXMLConfigConst;
                    }
                }
            }
            
        }
        #endregion


    }
}
