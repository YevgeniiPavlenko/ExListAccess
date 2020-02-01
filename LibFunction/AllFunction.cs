using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices;

namespace LibFunction
{
    class AllFunction
    {
        
    }

    public class GetAtrUsersReads
    {
        string t_displayName = "";
        string t_sAMAccountName = "";
        string t_department = "";
        string t_title = "";
        string t_LDAP = "";
               
        /// <summary>
        /// Class constructions
        /// </summary>
        #region Constraction
        /// <summary>
        /// Сlass constructor without arguments
        /// </summary>
        public GetAtrUsersReads()
        {
            t_displayName = "";
            t_sAMAccountName = "";
            t_department = "";
            t_title = "";
            t_LDAP = "";
        }
        /// <summary>
        /// class constructor with all arguments
        /// </summary>
        /// <param name="constr_displayName">System.String constr_displayNameparam>
        /// <param name="constr_sAMAccountName">System.String constr_sAMAccountName</param>
        /// <param name="constr_department">System.String constr_department</param>
        /// <param name="constr_title">System.Stringconstr_titleparam>
        /// <param name="constr_LDAP">System.Stringconstr_LDAP</param>
        public GetAtrUsersReads(string constr_displayName, string constr_sAMAccountName, string constr_department, string constr_title, string constr_LDAP)
        {
            t_displayName = constr_displayName;
            t_sAMAccountName = constr_sAMAccountName;
            t_department = constr_displayName;
            t_title = constr_title;
            t_LDAP = constr_LDAP;
        }

        /// <summary>
        /// class constructor indicating all prom arguments t_ldap
        /// </summary>
        /// <param name="constr_displayName">System.String constr_displayName</param>
        /// <param name="constr_sAMAccountName">System.String constr_sAMAccountName</param>
        /// <param name="constr_department">System.String constr_department</param>
        /// <param name="constr_title">System.String constr_title</param>
        public GetAtrUsersReads(string constr_displayName, string constr_sAMAccountName, string constr_department, string constr_title)
        {
            t_displayName = constr_displayName;
            t_sAMAccountName = constr_sAMAccountName;
            t_department = constr_displayName;
            t_title = constr_title;
            t_LDAP = "";
        }

        #endregion

        /// <summary>
        /// Class Properties
        /// </summary>
        #region Properties
        /// <summary>
        /// Set ot Get String Properties t_displayName
        /// </summary>
        /// <param name="t_displayName">System.String displayName</param>
        public string displayName
        {
            get => t_department;
            set { t_department = value; }
        }
        /// <summary>
        /// Set ot Get String Properties t_sAMAccountName
        /// </summary>
        /// <param name="t_sAMAccountName">System.String sAMAccountName</param>
        public string sAMAccountName
        {
            get => t_sAMAccountName;
            set { t_sAMAccountName = value; }
        }
        /// <summary>
        /// Set ot Get String Properties t_department
        /// </summary>
        /// <param name="t_department">System.String department</param>
        public string department
        {
            get => t_department;
            set { t_department = value; }
        }
        /// <summary>
        /// Set ot Get String Properties t_title
        /// </summary>
        /// <param name="t_title">System.String title</param>
        public string title
        {
            get => t_title;
            set { t_title = value; }
        }
        /// <summary>
        /// Set ot Get String Properties t_LDAP
        /// </summary>
        /// <param name="t_LDAP">System.String LDAP</param>
        public string LDAP
        {
            get => t_LDAP;
            set { t_LDAP = value; }
        }

        /// <summary>
        /// Group filling of values. A string array is given as an argument with the following sequence of arguments, namely tring 
        /// t_displayName, t_sAMAccountName, t_department, t_title, t_LDAP. 
        /// If an array of a different depth is passed as an argument, it will not be filled.
        /// </summary>
        public string[] Set
        {
            set
            {
                if (value.Length == 5)
                {
                    t_displayName = value[0];
                    t_sAMAccountName = value[1];
                    t_department = value[2];
                    t_title = value[3];
                    t_LDAP = value[4];
                }
            }
        }
        #endregion

    }

    /// <summary>
    /// Выборка и занесение информации в AD
    /// </summary>
    public class GetInfoADFromUsers
    {
        public static void ConsoleInfoWhitchAD()
        {
            //GetInfoAdCrit(@"OU=Users,OU=_ZTGAZ,DC=ent,DC=ukrgas,DC=com,DC=ua");
        }

        public static void GetInfoAdCrit(string LDAP_Path = "")
        {
            DirectoryEntry CurrentDomain;
            DirectorySearcher tCurrent_DirectorySearcher;
            SearchResultCollection tCurrent_ResultCollection;
            List <GetAtrUsersReads> t_getAtrUsersReads = new List<GetAtrUsersReads> ();

            try
            {
                //Init Connection from Controler of Domain

                if ((LDAP_Path == "") || (LDAP_Path == null))
                {
                    CurrentDomain = new DirectoryEntry();
                }
                else
                {
                    CurrentDomain = new DirectoryEntry(LDAP_Path);
                }
                //Console.WriteLine("{0} - {1}", CurrentDomain.Name, CurrentDomain.Site.Name.ToString());

                //Read All User here
                CurrentDomain.Path = "LDAP://OU=Users,OU=_ZTGAZ,DC=ent,DC=ukrgas,DC=com,DC=ua";

                tCurrent_DirectorySearcher = new DirectorySearcher(CurrentDomain);
                tCurrent_DirectorySearcher.Filter = "(&(objectcategory=user))";
                tCurrent_DirectorySearcher.SizeLimit = 0;
                tCurrent_DirectorySearcher.PageSize = 1;

                tCurrent_DirectorySearcher.PropertiesToLoad.Add("displayName");
                tCurrent_DirectorySearcher.PropertiesToLoad.Add("sAMAccountName");
                tCurrent_DirectorySearcher.PropertiesToLoad.Add("department");
                tCurrent_DirectorySearcher.PropertiesToLoad.Add("title");

                Console.Write($"Find All Date from Active Directory with {CurrentDomain.Path.ToString()}\n");

                tCurrent_ResultCollection = tCurrent_DirectorySearcher.FindAll();
                Console.Write($"Find {tCurrent_ResultCollection.Count.ToString()} result...\n");

                int x_processWorks = 1;
                int x_Count_tCurrent_ResultCollection = tCurrent_ResultCollection.Count;
                foreach (SearchResult xSearchResult in tCurrent_ResultCollection)
                {
                    Console.Write($"Process... {x_processWorks.ToString()} in {x_Count_tCurrent_ResultCollection.ToString()}\r");
                    //Console.WriteLine("{0},\t{1},\t{2},\t{3}",
                    //    xSearchResult.GetDirectoryEntry().Properties["displayName"].Value.ToString(), xSearchResult.GetDirectoryEntry().Properties["sAMAccountName"].Value.ToString(),
                    //    xSearchResult.GetDirectoryEntry().Properties["department"].Value.ToString(), xSearchResult.GetDirectoryEntry().Properties["title"].Value.ToString());

                    t_getAtrUsersReads.Add(new GetAtrUsersReads(xSearchResult.GetDirectoryEntry().Properties["displayName"].Value.ToString(), xSearchResult.GetDirectoryEntry().Properties["sAMAccountName"].Value.ToString(),
                        xSearchResult.GetDirectoryEntry().Properties["department"].Value.ToString(), xSearchResult.GetDirectoryEntry().Properties["title"].Value.ToString()));
                    
                    x_processWorks++;
                }
                Console.Write($"\n");
                Console.WriteLine($"Count - {tCurrent_ResultCollection.Count.ToString()}, LDAP - {tCurrent_DirectorySearcher.SearchRoot.Path.ToString()}, Count - {tCurrent_DirectorySearcher.SizeLimit.ToString()} \n");
                Console.WriteLine($"Count Array  - {t_getAtrUsersReads.Count.ToString()}");
            }
            catch
            {
                Console.WriteLine("Error 01 form void GetInfoAdCrit()");
            }
        }
    }
}
