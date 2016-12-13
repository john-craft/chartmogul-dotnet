using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartMogul.API.Models.Core
{
    public class APIRequest
    {

        public string URLPath { get; set; }
        public string HttpMethod { get; set; }
        public string JsonData { get; set; }
        public Dictionary<string, string> Header { get { return Header; } set { } }
        public APIRequest() { Header = new Dictionary<string, string>(); }
        public string Credentials { get; set;}

    }
}
