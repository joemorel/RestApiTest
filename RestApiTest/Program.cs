using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Web;
using System.Web.Util;
using System.Xml.Linq;
using System.Collections.Specialized;

namespace RestApiTest
{
    class Program
    {
        private static RestCredentials creds = new RestCredentials();

        static void Main(string[] args)
        {
            Console.WriteLine("Use default credentials? (y/n)");
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.KeyChar == 'y')
            {
                creds.apiKey = "2wvowa3u5x";
                //creds.apiKey = "3lyilg165ul9bab2h3p2rf5p85y1";
                creds.baseUri = "http://localhost/api.ashx/v2/";
                creds.username = "admin";
            }

            else
            {
                Console.WriteLine("Username:");
                creds.username = Console.ReadLine();
                Console.WriteLine("API Key:");
                creds.apiKey = Console.ReadLine();
                Console.WriteLine("Base Uri (ex: 'http://localhost/api.ashx/v2/'):");
                creds.baseUri = Console.ReadLine();
            }

            RestHelper RestHelper = new RestHelper(creds);
            RestHelper.GetBlogs();
            Console.ReadKey();

            //Group[] groups = RestHelper.GetGroups();
            //Console.WriteLine(String.Format("There are {0} groups in the system...", groups.Count().ToString()));
            //foreach (Group g in groups)
            //    Console.WriteLine(g.GroupID.ToString() + ":  " + g.GroupName);
            //Console.WriteLine(String.Empty);
            //Console.Write("Enter a parent group ID: ");
            //int ParentGroupID = Convert.ToInt32(Console.ReadLine());

            //Console.Write("Group Name: ");
            //string GroupName = Console.ReadLine();
            //Console.Write("Key: ");
            //string Key = Console.ReadLine();
            //Console.Write("Description: ");
            //string Description = Console.ReadLine();
            //Console.Write("Group Type: ");
            //string GroupType = Console.ReadLine();
            //RestHelper.CreateGroup(GroupName, Key, Description, GroupType, ParentGroupID);

            //groups = RestHelper.GetGroups();
            //Console.WriteLine(String.Format("There are {0} groups in the system...", groups.Count().ToString()));
            //foreach (Group g in groups)
            //    Console.WriteLine(g.GroupID.ToString() + ":  "+ g.GroupName);
            //Console.WriteLine(String.Empty);

            ///*int DeleteGroupID;
            //Console.Write("Enter Group ID to delete: ");
            //DeleteGroupID = Convert.ToInt32(Console.ReadLine());
            //RestHelper.DeleteGroup(DeleteGroupID); */

            //int UpdateGroupID;
            //Console.Write("Enter Group ID to update: ");
            //UpdateGroupID = Convert.ToInt32(Console.ReadLine());
            //Group UpdateGroup = RestHelper.GetGroup(UpdateGroupID);

            //Console.WriteLine("1.) Group Name: " + UpdateGroup.GroupName);
            //Console.WriteLine("2.) Group Description: " + UpdateGroup.Description);
            //Console.WriteLine("3.) Group Type: " + UpdateGroup.GroupType);
            //Console.WriteLine("4.) Group URL Key: " + UpdateGroup.GroupKey);
            //Console.WriteLine(string.Empty);
            //Console.Write("Choose a number (1-4) for the data you would like to update: ");
            //int selection = Convert.ToInt32(Console.ReadLine());
            //string update;

            //switch (selection)
            //{
            //    case 1:
            //        Console.Write("Enter new Group Name: ");
            //        update = Console.ReadLine();
            //        RestHelper.UpdateGroup(update, UpdateGroup.GroupKey, UpdateGroup.Description, UpdateGroup.GroupType, UpdateGroup.GroupID);
            //        break;

            //    case 2:
            //        Console.Write("Enter new Group Description: ");
            //        update = Console.ReadLine();
            //        RestHelper.UpdateGroup(UpdateGroup.GroupName, UpdateGroup.GroupKey, update, UpdateGroup.GroupType, UpdateGroup.GroupID);
            //        break;

            //    case 3:
            //        Console.Write("Enter new Group Type: ");
            //        update = Console.ReadLine();
            //        RestHelper.UpdateGroup(UpdateGroup.GroupName, UpdateGroup.GroupKey, UpdateGroup.Description, update, UpdateGroup.GroupID);
            //        break;

            //    case 4:
            //        Console.Write("Enter new Group URL Key: ");
            //        update = Console.ReadLine();
            //        RestHelper.UpdateGroup(UpdateGroup.GroupName, update, UpdateGroup.Description, UpdateGroup.GroupType, UpdateGroup.GroupID);
            //        break;

            //    default:
            //        break;
            //}

            //groups = RestHelper.GetGroups();
            //Console.WriteLine(String.Format("There are {0} groups in the system...", groups.Count().ToString()));
            //foreach (Group g in groups)
            //    Console.WriteLine(g.GroupID.ToString() + ":  " + g.GroupName);
            //Console.ReadKey(true);
            
        }
    }
}
