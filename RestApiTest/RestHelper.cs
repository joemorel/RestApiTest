using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Collections.Specialized;
using System.Xml.Linq;

namespace RestApiTest
{
    public class RestHelper
    {
        private static RestCredentials creds;

        public RestHelper(RestCredentials _creds)
        {
            creds = _creds;
        }

        public static Blog[] GetBlogs()
        {
            WebClient client = new WebClient();
            string endpointURL = creds.baseUri + "blogs.xml";
            client.Headers.Add("Rest-User-Token", Convert.ToBase64String(Encoding.UTF8.GetBytes(String.Format("{0}:{1}", creds.apiKey, creds.username))));
            var response = (string)client.DownloadString(endpointURL);
            Console.WriteLine(response);
            return null;
        }

        public static User[] GetUsers()
        {
            WebClient client = new WebClient();
            string endpointURL = creds.baseUri + "users.xml";
            client.Headers.Add("Rest-User-Token", Convert.ToBase64String(Encoding.UTF8.GetBytes(String.Format("{0}:{1}", creds.apiKey, creds.username))));
            var response = (string)client.DownloadString(endpointURL);
            XElement XUsers = XElement.Parse(response);

            var users = from e in XUsers.Descendants()
                        where e.Name.LocalName == "User"
                        select new User
                        {
                            userID = int.Parse(e.Element("Id").Value),
                            userName = e.Element("Username").Value,
                            avatarUrl = e.Element("AvatarUrl").Value,
                            displayName = e.Element("DisplayName").Value
                        };

            return users.ToArray();
        }


        public static Group[] GetGroups()
        {

                WebClient client = new WebClient();
                string endpointURL = creds.baseUri + "groups.xml";
                client.Headers.Add("Rest-User-Token", Convert.ToBase64String(Encoding.UTF8.GetBytes(String.Format("{0}:{1}", creds.apiKey, creds.username))));
                var response = (string)client.DownloadString(endpointURL);
                XElement XGroups = XElement.Parse(response);

                var groups = from e in XGroups.Descendants()
                             where e.Name.LocalName == "Group"
                             select new Group
                             {
                                 GroupID = int.Parse(e.Element("Id").Value),
                                 GroupName = e.Element("Name").Value,
                                 GroupKey = e.Element("Key").Value,
                                 Description = e.Element("Description").Value,
                                 GroupType = e.Element("GroupType").Value
                             };

                return groups.ToArray();
        }

        public static void CreateGroup(string GroupName, string Key, string Description, string Type, int ParentGroupID)
        {
            WebClient client = new WebClient();
            client.Headers.Add("Rest-User-Token", Convert.ToBase64String(Encoding.UTF8.GetBytes(String.Format("{0}:{1}", creds.apiKey, creds.username))));
            var endpointURL = creds.baseUri + "groups.xml";
            NameValueCollection data = new NameValueCollection();
            Description = WebUtility.HtmlEncode(Description);
            data.Add("Name", GroupName);
            data.Add("Key", Key);
            data.Add("Description", Description);
            data.Add("GroupType", Type);
            data.Add("ParentGroupId", ParentGroupID.ToString());
            byte[] response = client.UploadValues(endpointURL, "POST", data);
            Console.Write(Encoding.ASCII.GetString(response));
        }

        public static void DeleteGroup(int GroupID)
        {
            WebClient client = new WebClient();
            client.Headers.Add("Rest-User-Token", Convert.ToBase64String(Encoding.UTF8.GetBytes(String.Format("{0}:{1}", creds.apiKey, creds.username))));
            client.Headers.Add("Rest-Method", "DELETE");
            var endpointURL = creds.baseUri + "groups/" + GroupID.ToString() + ".xml";
            byte[] response = client.UploadData(endpointURL, "POST", Encoding.ASCII.GetBytes("$data"));
            Console.Write(Encoding.ASCII.GetString(response));
        }

        public static void UpdateGroup(string GroupName, string Key, string Description, string Type, int GroupID)
        {
            WebClient client = new WebClient();
            client.Headers.Add("Rest-User-Token", Convert.ToBase64String(Encoding.UTF8.GetBytes(String.Format("{0}:{1}", creds.apiKey, creds.username))));
            client.Headers.Add("Rest-Method", "PUT");
            var endpointURL = creds.baseUri + "groups/" + GroupID.ToString() + ".xml";
            NameValueCollection data = new NameValueCollection();
            data.Add("Name", GroupName);
            if (Key != String.Empty)
                data.Add("Key", Key);
            if (Description != String.Empty)
                data.Add("Description", Description);
            if (Type != String.Empty)
                data.Add("GroupType", Type);
            byte[] response = client.UploadValues(endpointURL, "POST", data);
            Console.Write(Encoding.ASCII.GetString(response));

        }

        public static Group GetGroup(int GroupID)
        {
            WebClient client = new WebClient();
            client.Headers.Add("Rest-User-Token", Convert.ToBase64String(Encoding.UTF8.GetBytes(String.Format("{0}:{1}", creds.apiKey, creds.username))));
            client.Headers.Add("Rest-Method", "PUT");
            var endpointURL = creds.baseUri + "groups/" + GroupID.ToString() + ".xml";
            var response = client.DownloadString(endpointURL) as string;
            XElement XGroup = XElement.Parse(response);
            var group = from e in XGroup.Descendants()
                        where e.Name.LocalName == "Group"
                        select new Group
                        {
                            GroupID = int.Parse(e.Element("Id").Value),
                            GroupKey = e.Element("Key").Value,
                            GroupName = e.Element("Name").Value,
                            GroupType = e.Element("GroupType").Value,
                            Description = e.Element("Description").Value
                        };

            return group.First<Group>();
        }

    }
}
