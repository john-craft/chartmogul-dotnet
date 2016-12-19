using System.Configuration;

namespace ChartMogul.API
{
    class Configuration
    {
        public static string AccountToken
        {
            get { return ConfigurationManager.AppSettings["AccountToken"]; }
        }
        public static string SecretKey
        {
            get { return ConfigurationManager.AppSettings["SecretKey"]; }
        }
    }
}
