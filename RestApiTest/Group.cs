using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestApiTest
{
    public class Group
    {
        public int GroupID;
        public string GroupName;
        public string GroupType;
        public string GroupKey;
        public string Description;

        public Group()
        {
            GroupID = -1;
            GroupName = String.Empty;
            GroupType = "Joinless";
            GroupKey = String.Empty;
            Description = String.Empty;
        }
    }
}
