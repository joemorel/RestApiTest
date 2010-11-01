using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestApiTest
{
    public class User
    {
        public int userID;
        public string avatarUrl;
        public string displayName;
        public string userName;

        public User(int _userID, string _avatarUrl, string _userName, string _displayName)
        {
            userID = _userID;
            avatarUrl = _avatarUrl;
            displayName = _displayName;
            userName = _userName;
        }

        public User(int _userID, string _avatarUrl, string _userName)
        {
            userID = _userID;
            avatarUrl = _avatarUrl;
            userName = _userName;
            displayName = String.Empty;
        }

        public User()
        {
            userID = 0;
            avatarUrl = String.Empty;
            userName = String.Empty;
            displayName = String.Empty;
        }


    }
}
