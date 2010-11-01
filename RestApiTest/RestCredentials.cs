using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestApiTest
{
    public class RestCredentials
    {
        private string _username;
        private string _apiKey;
        private string _baseUri;

        public string username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
            }
        }

        public string apiKey
        {
            get
            {
                return _apiKey;
            }
            set
            {
                _apiKey = value;
            }
        }

        public string baseUri
        {
            get
            {
                return _baseUri;
            }
            set
            {
                _baseUri = value;
            }
        }

        public string HeaderToken()
        {
            if (_username == null || _apiKey == null || _baseUri == null)
                return null;

            else
            {
                string adminKey = String.Format("{0}:{1}", _username, _apiKey);
                adminKey = Convert.ToBase64String(Encoding.UTF8.GetBytes(adminKey));
                return adminKey;
            }
        }
    }
}
