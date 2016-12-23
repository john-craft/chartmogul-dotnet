using ChartMogul.API;
using OConnors.ChartMogul.API;
using OConnors.ChartMogul.API.Models;
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

            try
            {

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
                //  var getCustomers= Objclient.GetCustomers();


                //To Create a data Source
                //  var datasource = Objclient.AddDataSource(new OConnors.ChartMogul.API.Models.DataSourceModel { Name = "ashish bill details1" });


                //To delete a customer
                // Objclient.DeleteCustomer(new OConnors.ChartMogul.API.Models.CustomerModel { Uuid = "cus_34995d84-f1db-4fde-a9cd-29ce6959cf10"});

                //To Get DataSources
                //var datasources = Objclient.GetDataSources();

                //To Delete a DataSource
                // Objclient.DeleteDataSource(new OConnors.ChartMogul.API.Models.DataSourceModel { Uuid= "ds_7ab8ff74-c820-11e6-bb5a-eb95a5d49c22"});

                //Uncomment this code for get plans
                var getPlans = Objclient.GetPlans();




                //Uncomment this code to create plan
                //var result = Objclient.CreatePlan(new OConnors.ChartMogul.API.Models.PlanModel
                //{
                //    DataSource = "ds_fa1e14c8-c1fb-11e6-a9ee-47d77bcf3ed5",
                //    ExternalId = Guid.NewGuid().ToString(),
                //    IntervalCount = 1,
                //    InvervalUnit = "month",
                //    Name = "Bronze Plan",
                //});

                //Get Invoices
                var invoices = Objclient.GetInvoices(new OConnors.ChartMogul.API.Models.CustomerModel { Uuid = "cus_635608cb-9b6d-4a59-a03d-15f00fa0e408" });


                //Import Invoices
                //LineItemModel item = new LineItemModel
                //{
                //    Type = "subscription",
                //    SubscriptionId = "guid",
                //    Amount = 100,
                //    SubscriptionStart = DateTime.Now,
                //    SubscriptionEnd = DateTime.Now.AddDays(10),
                //    Description = "first Invoice",
                //    Uuid = "pl_6a49b560-4256-4f45-a213-2dafc7a4740c",
                //    Quantity = 1,
                //    CancellationDate=DateTime.Now
                //};

                //var transac = new Transaction
                //{
                //    Date = DateTime.Now,
                //    Type = "payment",
                //    Result = "successful",    
                //};

                //InvoiceModel inv = new OConnors.ChartMogul.API.Models.InvoiceModel
                //{
                //    Date = DateTime.Now,
                //    Currency = "USD",
                //    DueDate = DateTime.Now.ToString(),
                //    ExternalId = "ashishguid",
                //    Items = new List<LineItemModel> { item },
                //    Transactions = new List<Transaction> { transac }
                //};

                //var Invoice = Objclient.AddInvoice(new OConnors.ChartMogul.API.Models.CustomerModel
                //{ Uuid = "cus_635608cb-9b6d-4a59-a03d-15f00fa0e408" }, inv);




                //Add Transaction
                //InvoiceModel inv = new InvoiceModel { Uuid = "inv_09fa95d0-80ef-41d1-b556-07d927b9a8da" };
                //Objclient.AddTransaction(inv,
                //    new TransactionModel
                //    {
                //        Type= "refund",
                //        Date=DateTime.Now,
                //        Result= "successful"

                //    }
                //);






            }
            catch (Exception ex)
            {

            }


















        }
    }
}
