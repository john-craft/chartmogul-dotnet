using System.Collections.Generic;


namespace ChartMogul.API.Models.Core
{
    public class APIRequest
    {
        public string URLPath { get; set; }
        public string HttpMethod { get; set; }
        public string JsonData { get; set; }
        public Dictionary<string, string> Header = new Dictionary<string, string>();
        public string Credentials { get; set; }

        public void Set(string key, string value)
        {
            if (Header.ContainsKey(key))
            {
                Header[key] = value;
            }
            else
            {
                Header.Add(key, value);
            }
        }

        public string Get(string key)
        {
            string result = null;

            if (Header.ContainsKey(key))
            {
                result = Header[key];
            }

            return result;
        }

    }
}
