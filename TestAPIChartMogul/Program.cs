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
            //var temp= Objclient.GetPlans();
            //Uncomment this code for post
            Objclient.AddCustomer(new OConnors.ChartMogul.API.Models.CustomerModel
            {
                data_source_uuid = "ds_fa1e14c8-c1fb-11e6-a9ee-47d77bcf3ed8",
                external_id = "cus_0009",
                name = "Adam Smith",
                email = "adam@smith.com",
                country = "US",
                city = "New York"
            });
            //Uncomment this code for get
            //       var getCustomers= Objclient.GetCustomers();


        }
    }
}
