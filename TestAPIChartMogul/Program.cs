using ChartMogul.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace TestAPIChartMogul
{
    class Program
    {
        static void Main(string[] args)
        {
            string accountToken = ConfigurationManager.AppSettings["AccountToken"].ToString();
            string secretKey = ConfigurationManager.AppSettings["SecretKey"].ToString();
            ChartMogulClient Objclient = new ChartMogulClient(new ChartMogul.API.Models.Core.Config {AccountToken= accountToken, SecretKey = secretKey });
           var temp= Objclient.GetCustomers();
        }
    }
}
