using System.Collections.Generic;


namespace ChartMogul.API.Models.Core
{
    public class APIRequest
    {    
        public string Url { get; set; }
       public Dictionary<string, string> Header = new Dictionary<string, string>();

        public void SetHeader(string key, string value)
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

        public string GetHeader(string key)
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
