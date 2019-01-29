﻿using ChartMogul.API;
using ChartMogul.API.Models.Enrichment;
using ChartMogul.API.Models.Metrics;
using ChartMogul.API.Models.Import;
using System;
using System.Collections.Generic;

namespace TestAPIChartMogul
{
    class Program
    {
        static void Main(string[] args)
        {
            //Configuration config = new Configuration();
            ChartMogulClient Objclient = new ChartMogulClient("", "");
            var test = new Dictionary<string, string>();
            test.Add("test", "value");
            Objclient.AddHeaders(test);
            //var temp= Objclient.GetPlans();

            try
            {

                //Uncomment this code for post
                //var result = Objclient.Import.AddCustomer(new ChartMogul.API.Models.Import.CustomerModel
                //{
                //    Data_Source_Uuid = "ds_fa1e14c8-c1fb-11e6-a9ee-47d77bcf3ed5",
                //    External_Id = Guid.NewGuid().ToString(),
                //    Name = "Adam Smith",
                //    Email = "adam@smith.com",
                //    Country = "US",
                //    City = "New York"
                //});


                //   Uncomment this code for get customer
                //  var getCustomers = Objclient.Import.GetCustomers();

                //To Create a data Source
                //var datasource = Objclient.Import.AddDataSource(new ChartMogul.API.Models.Import.DataSourceModel { Name = "ashish bill details1" });


                //To delete a customer
                //Objclient.Import.DeleteCustomer(new ChartMogul.API.Models.Import.CustomerModel { Uuid = "cus_34995d84-f1db-4fde-a9cd-29ce6959cf10" });

                //To Get DataSources
                // var datasources = Objclient.Import.GetDataSources();

                //To Delete a DataSource
                // Objclient.Import.DeleteDataSource(new ChartMogul.API.Models.Import.DataSourceModel { Uuid = "ds_7ab8ff74-c820-11e6-bb5a-eb95a5d49c22" });

                //Uncomment this code for get plans
                //var getPlans = Objclient.Import.GetPlans();




                //Uncomment this code to create plan
                //var result = Objclient.Import.CreatePlan(new ChartMogul.API.Models.Import.PlanModel
                //{
                //    DataSource = "ds_fa1e14c8-c1fb-11e6-a9ee-47d77bcf3ed5",
                //    ExternalId = Guid.NewGuid().ToString(),
                //    IntervalCount = 1,
                //    InvervalUnit = "month",
                //    Name = "Bronze Plan",
                //});

                //Get Invoices
                //var invoices = Objclient.Import.GetInvoices(new ChartMogul.API.Models.Import.CustomerModel { Uuid = "cus_635608cb-9b6d-4a59-a03d-15f00fa0e408" });


                //Import Invoices
                //var item = new ChartMogul.API.Models.Import.LineItemModel
                //{
                //    Type = "subscription",
                //    SubscriptionId = "guid",
                //    Amount = 100,
                //    SubscriptionStart = DateTime.Now,
                //    SubscriptionEnd = DateTime.Now.AddDays(10),
                //    Description = "first Invoice",
                //    Uuid = "pl_6a49b560-4256-4f45-a213-2dafc7a4740c",
                //    Quantity = 1,
                //    CancellationDate = DateTime.Now
                //};

                //var transac = new ChartMogul.API.Models.Import.TransactionModel
                //{
                //    Date = DateTime.Now,
                //    Type = "payment",
                //    Result = "successful",
                //};

                //var inv = new ChartMogul.API.Models.Import.InvoiceResponseDataModel
                //{
                //    Invoices = new List<InvoiceModel>()
                //    {
                //        new InvoiceModel {
                //        Date = DateTime.Now,
                //        Currency = "USD",
                //        DueDate = DateTime.Now.ToString(),
                //        ExternalId = "ashishguid45",
                //        Items = new List<ChartMogul.API.Models.Import.LineItemModel> { item },
                //        Transactions = new List<ChartMogul.API.Models.Import.TransactionModel> { transac }
                //    }
                //  }
                //};

                //var Invoice = Objclient.Import.AddInvoice(new ChartMogul.API.Models.Import.CustomerModel
                //{ Uuid = "cus_635608cb-9b6d-4a59-a03d-15f00fa0e408" }, inv);




                //Add Transaction
                //var inv = new ChartMogul.API.Models.Import.InvoiceModel { Uuid = "inv_09fa95d0-80ef-41d1-b556-07d927b9a8da" };
                //Objclient.Import.AddTransaction(inv,
                //    new ChartMogul.API.Models.Import.TransactionModel
                //    {
                //        Type = "refund",
                //        Date = DateTime.Now,
                //        Result = "successful"

                //    }
                //);



                //GetSubscription
                //var SubscriptionList = Objclient.Import.GetSubscriptions(new ChartMogul.API.Models.Import.CustomerModel { Uuid = "cus_635608cb-9b6d-4a59-a03d-15f00fa0e408"});


                //Cancel Subscription
                //DateTime[] canceldate = new DateTime[1];
                //canceldate[0] = DateTime.Now;
                //var cancelSubscription = Objclient.Import.CancelSubscription(new SubscriptionModel { Uuid = "sub_f4f97eb2-e5f4-4b41-ad22-e5ebc4d3a665", CancellationDates = canceldate });

                //To get Enrichment customers    
                //var queryParams = new CustomerQueryParamsModel();
                //queryParams.Page = "1";
                //queryParams.PerPage = "5";
                //queryParams.ExternalId = "cus_0049";
                //var getAllCustomer = Objclient.Enrichment.GetAllCustomers(queryParams);

                //To get Enrichment customer details
                //var getCustomerDetails = Objclient.Enrichment.GetCustomerDetails("cus_635608cb-9b6d-4a59-a03d-15f00fa0e408");

                // To Search by email in enrichment Customer
                //var customer = Objclient.Enrichment.SearchForCustomer("adam@smith.com");

                //To merge Customers
                //Objclient.Enrichment.MergeCustomers(new ChartMogul.API.Models.Enrichment.MergeCustomersModel
                //{
                //    Into = new ChartMogul.API.Models.Enrichment.Into { CustomerUUID = "cus_635608cb-9b6d-4a59-a03d-15f00fa0e408" },
                //    From = new ChartMogul.API.Models.Enrichment.From
                //    {
                //        CustomerUUID = "cus_abf4f640-c129-11e6-be7f-bb6e00c5cf48"
                //    }
                //});

                //TO update customer in enrichment
                // var customer = Objclient.Enrichment.UpdateCustomer(new ChartMogul.API.Models.Enrichment.CustomerPatchModel { City = "Gurgaon", Country = "US" }, "cus_635608cb-9b6d-4a59-a03d-15f00fa0e408");

                //To Retrieve customer attributes
                // var response = Objclient.Enrichment.GetCustomerAttribute("cus_635608cb-9b6d-4a59-a03d-15f00fa0e408");

                //To add tags to customer
                //var response = Objclient.Enrichment.AddTagsToCustomer("cus_635608cb-9b6d-4a59-a03d-15f00fa0e408", new string[3] { "test", "test", "test"});

                //To add tags to customer with specified email
                //var response = Objclient.Enrichment.AddTagsToCustomerWithEmail("cus_635608cb-9b6d-4a59-a03d-15f00fa0e408", new CustomerTagModel { Tags = new string[3] { "test1", "test2", "test3" },Email = "adam@smith.com" });

                //To remove tags from customer
                //var response = Objclient.Enrichment.RemoveTagsFromCustomer("cus_635608cb-9b6d-4a59-a03d-15f00fa0e408", new string[1] { "test" });

                //To add custom attribute
                //var response = Objclient.Enrichment.AddCustomAttribute("cus_635608cb-9b6d-4a59-a03d-15f00fa0e408", new AddCustomAttributeModel { Custom = new List<Custom> { new Custom { Key = "testKey", Value = "testValue", Type = "String" } } });

                //To add custom attribute to customer with email
                //var response = Objclient.Enrichment.AddCustomAttributeToCustomerWithEmail(new AddCustomAttributeModel { Email = "adam@smith.com", Custom = new List<Custom> { new Custom { Key = "testKey", Value = "testValue", Type = "String" } } });

                //To Update Custom Attributes of a Customer
                //var dictionary = new Dictionary<string, string>();
                //dictionary.Add("testKey", "value");
                //var response = Objclient.Enrichment.UpdateCustomAttributesOfCustomer("cus_635608cb-9b6d-4a59-a03d-15f00fa0e408", new CustomModel { Custom = dictionary });

                //To remove custom attributes from a customer
                // var response = Objclient.Enrichment.RemoveCustomAttributeFromCustomer("cus_635608cb-9b6d-4a59-a03d-15f00fa0e408", new RemoveCustomAttributeModel { Custom = new string[1] { "testKey" } });

                //To get all metrics
                //var queryParams = new MetricsQueryParamsModel();
                //queryParams.StartDate = "2016-05-11";
                //queryParams.EndDate = "2016-12-30";
                //queryParams.Geo = "US";
                //queryParams.Interval = "month";
                //var response3 = Objclient.Metrics.GetAllKeyMetrics(queryParams);

                //Retrieve Average Revenue Per Account (ARPA)
                //var queryParams = new MetricsQueryParamsModel();
                //queryParams.StartDate = "2016-05-11";
                //queryParams.EndDate = "2016-12-30";
                //var response = Objclient.Metrics.GetArpaForSpecifiedTimePeriod(queryParams);

                //Retrieves the Annualized Run Rate (ARR), for the specified time period.
                //var queryParams = new MetricsQueryParamsModel();
                //queryParams.StartDate = "2016-05-11";
                //queryParams.EndDate = "2016-12-30";
                //var response = Objclient.Metrics.GetArrForSpecifiedTimePeriod(queryParams);


                //Retrieves the Average Sale Price (ASP), for the specified time period.

                //var queryParams = new MetricsQueryParamsModel();
                //queryParams.StartDate = "2016-05-11";
                //queryParams.EndDate = "2016-12-30";
                //var response = Objclient.Metrics.GetASPForSpecifiedTimePeriod(queryParams);


                //Returns a list of activities for a given customer.
                // var response = Objclient.Metrics.GetCustomerActivities("cus_635608cb-9b6d-4a59-a03d-15f00fa0e408");


                //   Retrieves the Customer Churn Rate, for the specified time period.       
                //var queryParams = new MetricsQueryParamsModel();
                //queryParams.StartDate = "2016-05-11";
                //queryParams.EndDate = "2016-12-30";
                //var response = Objclient.Metrics.GetCustomerChurnRate(queryParams);

                //Retrieves the number of active customers, for the specified time period.
                //var queryParams = new MetricsQueryParamsModel();
                //queryParams.StartDate = "2016-05-11";
                //queryParams.EndDate = "2016-12-30";
                //var response = Objclient.Metrics.GetCustomerCount(queryParams);

                //Retrieves the Customer Lifetime Value (LTV), for the specified time period.
                //var queryParams = new MetricsQueryParamsModel();
                //queryParams.StartDate = "2016-05-11";
                //queryParams.EndDate = "2016-12-30";
                //var response = Objclient.Metrics.GetLTV(queryParams);

                //Retrives a list of subscriptions for a given customer..
                // var response = Objclient.Metrics.GetCustomerSubscriptionDetails("cus_635608cb-9b6d-4a59-a03d-15f00fa0e408");

                //Retrieves the Net MRR Churn Rate, for the specified time period.
                //var queryParams = new MetricsQueryParamsModel();
                //queryParams.StartDate = "2016-05-11";
                //queryParams.EndDate = "2016-12-30";
                //var response = Objclient.Metrics.GetMRRChurnRate(queryParams);

                //Retrieves the Monthly Recurring Revenue (MRR), for the specified time period.
                //var queryParams = new MetricsQueryParamsModel();
                //queryParams.StartDate = "2016-05-11";
                //queryParams.EndDate = "2016-12-30";
                //var response = Objclient.Metrics.GetMrrForSpecifiedTimePeriod(queryParams);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
