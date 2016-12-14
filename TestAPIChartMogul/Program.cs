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
           var temp= Objclient.GetPlans();

            Objclient.AddCustomer(new OConnors.ChartMogul.API.Models.CustomerModel
            {
                DataSource = "ds_fef05d54-47b4-431b-aed2-eb6b9e545430",
                ExternalId = "cus_0001",
                Name = "Adam Smith",
                Email = "adam@smith.com",
                Country = "US",
                City = "New York"
            });
        }
    }
}
