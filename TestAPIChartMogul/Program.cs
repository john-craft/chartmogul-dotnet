using ChartMogul.API;
using ChartMogul.API.Models.Enrichment;
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
            //Configuration config = new Configuration();
            ChartMogulClient Objclient = new ChartMogulClient("","");
            var test = new Dictionary<string, string>();
            test.Add("test", "value");
            Objclient.AddHeaders(test);
            //var temp= Objclient.GetPlans();

            try
            {

                // Uncomment this code for post
                //var result = Objclient.Import.AddCustomer(new OConnors.ChartMogul.API.Models.CustomerModel
                //{
                //    Data_Source_Uuid = "ds_fa1e14c8-c1fb-11e6-a9ee-47d77bcf3ed5",
                //    External_Id = Guid.NewGuid().ToString(),
                //    Name = "Adam Smith",
                //    Email = "adam@smith.com",
                //    Country = "US",
                //    City = "New York"
                //});


             //   Uncomment this code for get customer
              //    var getCustomers = Objclient.Import.GetCustomers();

                //To Create a data Source
                //  var datasource = Objclient.Import.AddDataSource(new OConnors.ChartMogul.API.Models.DataSourceModel { Name = "ashish bill details1" });


                //To delete a customer
                // Objclient.Import.DeleteCustomer(new OConnors.ChartMogul.API.Models.CustomerModel { Uuid = "cus_34995d84-f1db-4fde-a9cd-29ce6959cf10"});

                //To Get DataSources
                //   var datasources = Objclient.Import.GetDataSources();

                //To Delete a DataSource
                // Objclient.Import.DeleteDataSource(new OConnors.ChartMogul.API.Models.DataSourceModel { Uuid= "ds_7ab8ff74-c820-11e6-bb5a-eb95a5d49c22"});

                //Uncomment this code for get plans
                //  var getPlans = Objclient.Import.GetPlans();




                //Uncomment this code to create plan
                //var result = Objclient.Import.CreatePlan(new OConnors.ChartMogul.API.Models.PlanModel
                //{
                //    DataSource = "ds_fa1e14c8-c1fb-11e6-a9ee-47d77bcf3ed5",
                //    ExternalId = Guid.NewGuid().ToString(),
                //    IntervalCount = 1,
                //    InvervalUnit = "month",
                //    Name = "Bronze Plan",
                //});

                //Get Invoices
                //  var invoices = Objclient.Import.GetInvoices(new OConnors.ChartMogul.API.Models.CustomerModel { Uuid = "cus_635608cb-9b6d-4a59-a03d-15f00fa0e408" });


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

                //var Invoice = Objclient.Import.AddInvoice(new OConnors.ChartMogul.API.Models.CustomerModel
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



                //GetSubscription
                //var SubscriptionList = Objclient.Import.GetSubscriptions(new CustomerModel { Uuid = "cus_635608cb-9b6d-4a59-a03d-15f00fa0e408"});


                //Cancel Subscription
                //DateTime[] canceldate = new DateTime[1];
                //canceldate[0] = DateTime.Now;
                //var cancelSubscription = Objclient.Import.CancelSubscription(new SubscriptionModel { Uuid = "sub_f4f97eb2-e5f4-4b41-ad22-e5ebc4d3a665", CancellationDates = canceldate });

                //To get Enrichment customers              
                //   var getAllCustomer  = Objclient.Import.Enrichment.GetAllCustomers();

                //To get Enrichment customer details
                //   var getCustomerDetails = Objclient.Import.Enrichment.GetCustomerDetails("cus_635608cb-9b6d-4a59-a03d-15f00fa0e408");

                // To Search by email in enrichment Customer
                //var customer = Objclient.Import.Enrichment.SearchForCustomer("adam@smith.com");

                //To merge Customers
                //Objclient.Enrichment.MergeCustomers(new ChartMogul.API.Models.Enrichment.MergeCustomers { Into = new ChartMogul.API.Models.Enrichment.Into{ CustomerUUID = "cus_635608cb-9b6d-4a59-a03d-15f00fa0e408" },From = new ChartMogul.API.Models.Enrichment.From { CustomerUUID = "cus_abf4f640-c129-11e6-be7f-bb6e00c5cf48"
                //}
                //});

                //TO update customer in enrichment
                //var customer = Objclient.Enrichment.UpdateCustomer(new ChartMogul.API.Models.Enrichment.CustomerPatchModel { City = "Gurgaon", Country = "US" }, "cus_635608cb-9b6d-4a59-a03d-15f00fa0e408");

                //To Retrieve customer attributes
                // var response = Objclient.Enrichment.GetCustomerAttribute("cus_635608cb-9b6d-4a59-a03d-15f00fa0e408");

                //To add tags to customer
                //var response = Objclient.Enrichment.AddTagsToCustomer("cus_635608cb-9b6d-4a59-a03d-15f00fa0e408", new string[3] { "test", "test", "test"});

                //To add tags to customer with specified email
                // var response = Objclient.Enrichment.AddTagsToCustomerWithEmail("cus_635608cb-9b6d-4a59-a03d-15f00fa0e408", new CustomerTag { Tags = new string[3] { "test1", "test2", "test3" },Email = "adam@smith.com" });

                //To remove tags from customer
                // var response = Objclient.Enrichment.RemoveTagsFromCustomer("cus_635608cb-9b6d-4a59-a03d-15f00fa0e408", new string[1] { "test" });

                //To add custom attribute
                //var response = Objclient.Enrichment.AddCustomAttribute("cus_635608cb-9b6d-4a59-a03d-15f00fa0e408", new AddCustomAttributeModel { Custom = new List<Custom> { new Custom { Key = "testKey", Value = "testValue", Type = "String" } } });

                //To add custom attribute to customer with email
                //   var response = Objclient.Enrichment.AddCustomAttributeToCustomerWithEmail("cus_635608cb-9b6d-4a59-a03d-15f00fa0e408", new AddCustomAttributeModel { Email = "adam@smith.com", Custom = new List<Custom> { new Custom { Key = "testKey", Value = "testValue", Type = "String" } } });

                //To Update Custom Attributes of a Customer
                //var dictionary = new Dictionary<string, string>();
                //dictionary.Add("testKey", "value");
                //var response = Objclient.Enrichment.UpdateCustomAttributesOfCustomer("cus_635608cb-9b6d-4a59-a03d-15f00fa0e408", new CustomModel { Custom = dictionary });

                //To remove custom attributes from a customer
                //  var response = Objclient.Enrichment.RemoveCustomAttributeFromCustomer("cus_635608cb-9b6d-4a59-a03d-15f00fa0e408", new RemoveCustomAttributeModel { Custom = new string[1] { "testKey" } });

            }
            catch (Exception ex)
            {

            }
        }
    }
}
