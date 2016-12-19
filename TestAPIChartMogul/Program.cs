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
            ChartMogulClient Objclient = new ChartMogulClient();
            var test = new Dictionary<string, string>();
            test.Add("test", "value");
            Objclient.AddHeaders(test);
            //var temp= Objclient.GetPlans();
      //Uncomment this code for post
            //Objclient.AddCustomer(new OConnors.ChartMogul.API.Models.CustomerModel
            //{
            //    data_source_uuid = "ds_fa1e14c8-c1fb-11e6-a9ee-47d77bcf3ed5",
            //    external_id = "cus_0049",
            //    name = "Adam Smith",
            //    email = "adam@smith.com",
            //    country = "US",
            //    city = "New York"
            //});
      //Uncomment this code for get customer
            //   var getCustomers= Objclient.GetCustomers();


      //Uncomment this code for get plans
            var getPlans = Objclient.GetPlans();

      //Uncomment this code to create plan
           //Objclient.CreatePlan(new OConnors.ChartMogul.API.Models.PlanModel
           //{               
           //    DataSource = "ds_fa1e14c8-c1fb-11e6-a9ee-47d77bcf3ed5",
           //    ExternalId = "cus_0049",
           //    IntervalCount = 1,
           //    InvervalUnit = "month",
           //    Name = "Bronze Plan",     
           //});




        }
    }
}
