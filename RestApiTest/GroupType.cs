using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestApiTest
{
        public enum GroupType
        {
            PublicOpen = "PublicOpen",
            PublicClosed = "PublicClosed",
            PrivateListed = "PrivateListed",
            PrivateUnlisted = "PrivateUnlisted",
            Joinless = "Joinless",
        }

        public static class GroupHelper
        {
            public static GroupType ValueOf(string value)
            {
                if (value == "PublicOpen")
                    return GroupType.PublicOpen;
                else if (value == "PublicClosed")
                    return GroupType.PublicClosed;
                else if (value == "PrivateListed")
                    return GroupType.PrivateListed;
                else if (value == "PrivateUnlisted")
                    return GroupType.PrivateUnlisted;
                else
                    return GroupType.Joinless;
            }
        }

}
