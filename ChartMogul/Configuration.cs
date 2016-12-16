using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartMogul.API
{
    class Configuration
    {
        public static string AccountToken
        {
            get { return ConfigurationManager.AppSettings["AccountToken"]; }
        }
        public static string BaseUrl
        {
            get { return ConfigurationManager.AppSettings["BaseUrl"]; }
        }
        public static string SecretKey
        {
            get { return ConfigurationManager.AppSettings["SecretKey"]; }
        }
    }
}
