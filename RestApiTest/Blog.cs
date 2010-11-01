using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestApiTest
{
    public class Blog
    {
        public string Title;
        public string Description;
        public string Key;

        public Blog()
        {
            Title = String.Empty;
            Description = String.Empty;
            Key = String.Empty;
        }
    }
}
