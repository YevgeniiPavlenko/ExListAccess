"# ExListAccess" 
=====================================================

Released February 03, 2020

Fixed a bug in the constructor of the GetAtrUsersReads class.

Added to function
public static void GetInfoAdCrit (string LDAP_Path = "", string xDirectorySearcher_Filter = "", bool xISeeResult = false),
filter for user selection and also added a piece of code to display the selected information.

Fixed a bug in the properties of the GetAtrUsersReads class.

Several procedures have been done with several combinations of parameters:
	- public static void GetInfoAdCrit (string xDirectorySearcher_Filter = "")
	- public static void GetInfoAdCrit (string LDAP_Path = "", string xDirectorySearcher_Filter = "")
	- public static void GetInfoAdCrit (string LDAP_Path = "", string xDirectorySearcher_Filter = "", bool xISeeResult = false)

GetInfoAdCrit procedures renamed to InfoAdCrit. The GetInfoAdCrit function has been created, with parameters: string LDAP_Path = "", string xDirectorySearcher_Filter = "", which returns List <GetAtrUsersReads>, for further work with this data.

Improved filter in InfoAdCrit procedures and GetInfoAdCrit functions.

It is planned:
- Develop a CML configuration in which information will be stored about which groups will need to be provided to the employee having the necessary department and, accordingly, position.
- develop a mechanism that will read information from the configuration file and then present it in the form of a list, but not sure about the list yet, and then, by criteria / filters, compare subordinates from the domain controller and check the groups that already exist with those that should be at this moment according to the instructions of the employee.
- Further in the future, develop based on the above paragraph, a mechanism that will make changes to the domain controller.
- Further complete the preservation of information about the work done by the program.
- make an application, a separate window in which it will be possible to watch, edit the information of the configuration file according to the criteria for providing information.
=====================================================

Released February 02, 2020

Made by:
Added a separate library for functions that require .Net Freymvork 4.7.2. Functions for receiving parameters with AD are written. Written a separate class for storing user information.

Planning:
To develop a mechanism for determining information about groups of a domain controller.

=====================================================