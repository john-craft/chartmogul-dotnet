using System.Configuration;

namespace ChartMogul.API
{
    public class Configuration
    {
        public Configuration(string accountToken,string secretKey)
            {
            AccountToken = accountToken;
            SecretKey = secretKey;
            }
        public static string AccountToken
        {            
            get;
            set;
        }

        public static string SecretKey
        {         
            get;
            set;
        }
    }
}
