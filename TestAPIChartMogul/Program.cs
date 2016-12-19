using ChartMogul.API;
using System;
using System.Collections.Generic;

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
            //var result = Objclient.AddCustomer(new OConnors.ChartMogul.API.Models.CustomerModel
            // {
            //     Data_Source_Uuid = "ds_fa1e14c8-c1fb-11e6-a9ee-47d77bcf3ed5",
            //     External_Id = Guid.NewGuid().ToString(),
            //     Name = "Adam Smith",
            //     Email = "adam@smith.com",
            //     Country = "US",
            //     City = "New York"
            // });
            //Uncomment this code for get customer
               var getCustomers= Objclient.GetCustomers();


            //Uncomment this code for get plans
            //  var getPlans = Objclient.GetPlans();

            //Uncomment this code to create plan
            //var result = Objclient.CreatePlan(new OConnors.ChartMogul.API.Models.PlanModel
            //{
            //    DataSource = "ds_fa1e14c8-c1fb-11e6-a9ee-47d77bcf3ed5",
            //    ExternalId = Guid.NewGuid().ToString(),
            //    IntervalCount = 1,
            //    InvervalUnit = "month",
            //    Name = "Bronze Plan",
            //});




        }
    }
}
