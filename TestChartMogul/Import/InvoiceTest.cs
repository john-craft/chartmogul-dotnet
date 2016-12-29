using ChartMogul.API;
using ChartMogul.API.Exceptions;
using ChartMogul.API.Import;
using ChartMogul.API.Models;
using ChartMogul.API.Models.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OConnors.ChartMogul.API.Models;
using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using OConnors.ChartMogul.API.Models.Import;
using ChartMogul.API.Models.Import;
using System.Collections.Generic;

namespace TestChartMogul.Import
{
    [TestClass]
    public class InvoiceTest : ParentTest
    {
        private Invoice _invoice;
        // private Mock<IGetResponse> _getResponse;

        [TestInitialize]
        public void TestInitialize()
        {
            _getResponse = new Mock<IGetResponse>();
            _invoice = new Invoice(new Http(_getResponse.Object));
        }

        public InvoiceModel GetInvoiceModel()
        {
            return new InvoiceModel()
            {
              Currency = "USD",
              Date = DateTime.Now,
              Items =new List<LineItemModel> { GetLineItemModel() },
              Transactions= new List<TransactionModel> { GetTransactionModel() },
              DueDate= DateTime.Now.AddDays(3).ToString(),
              Uuid = "",
              ExternalId = ""
            };
        }

        public TransactionModel GetTransactionModel()
        {
            return new TransactionModel
            {
                Date = DateTime.Now,
                Type = "payment",
                Result = "successful"
            };
        }

        public LineItemModel GetLineItemModel()
        {
            return new LineItemModel
            {
                Type = "subscription",
                SubscriptionId = "sub_0001",
                Uuid = "pl_eed05d54-75b4-431b-adb2-eb6b9e543206",
                SubscriptionStart = DateTime.Now,
                SubscriptionEnd = DateTime.Now,
                Amount = 5000,
            };
        }

        public CustomerModel GetCustomerModel()
        {
            return new CustomerModel()
            {
                External_Id = Guid.NewGuid().ToString(),
                City = "Test",
                Data_Source_Uuid = Guid.NewGuid().ToString()
            };
        }

        public InvoiceResponseDataModel GetInvoiceResponseDataModel()
        {
            return new InvoiceResponseDataModel()
            {
                Invoices = new List<InvoiceModel>() { GetInvoiceModel() }

            };
        }

       

        [TestMethod]
        public void GivenCalling_GetInvoices_ReturnsListOfInvoices()
        {
            MockHttpResponse<InvoiceResponseDataModel>(GetInvoiceResponseDataModel());
            var response = _invoice.GetInvoices(GetCustomerModel(),new APIRequest());
            Assert.IsNotNull(response);
        }

        [TestMethod]
        [ExpectedException(typeof(UnAuthorizedUserException))]
        public void GivenCalling_GetInvoices_WhenUserIsNotAuthorizedThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.Unauthorized, "The remote server returned an error: (401) Unauthorized.");
            var response = _invoice.GetInvoices(new CustomerModel(), new APIRequest());
        }

        [TestMethod]
        [ExpectedException(typeof(ChartMogulException))]
        public void GivenCalling_GetInvoices_WhenServerIsNotRespondingThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.GatewayTimeout, "The remote server returned an error: (504)");
            var response = _invoice.GetInvoices(new CustomerModel(), new APIRequest());
        }

        [TestMethod]
        public void GivenCalling_AddInvoices_AddInvoiceAndReturnResponse()
        {
            MockHttpResponse<InvoiceResponseDataModel>(GetInvoiceResponseDataModel());
            var response = _invoice.AddInvoice(GetCustomerModel(), new APIRequest(),new List<InvoiceModel>() { GetInvoiceModel() });
            Assert.IsNotNull(response);
        }

        [TestMethod]
        [ExpectedException(typeof(SchemaInvalidException))]
        public void GivenCalling_AddInvoices_WhenSchemaIsInvalidThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.BadRequest, "Scheme is invalid. Required parameter external id is missing");
            var response = _invoice.AddInvoice(new CustomerModel(), new APIRequest(),new List<InvoiceModel> { new InvoiceModel()});
        }

        [TestMethod]
        [ExpectedException(typeof(UnAuthorizedUserException))]
        public void GivenCalling_AddInvoices_WhenUserIsNotAuthorizedThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.Unauthorized, "The remote server returned an error: (401) Unauthorized.");
            var response = _invoice.AddInvoice(new CustomerModel(), new APIRequest(),new List<InvoiceModel>() { new InvoiceModel() });
        }

        [TestMethod]
        [ExpectedException(typeof(ChartMogulException))]
        public void GivenCalling_AddInvoices_WhenInvoiceCurrencyIsInvalidThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.NotAcceptable, "Currency code is invalid");
            var response = _invoice.AddInvoice(GetCustomerModel(), new APIRequest(), new List<InvoiceModel>());
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void GivenCalling_AddInvoices_WhenUrlIsNotThenThrowsNotFoundException()
        {
            MockHttpErrorResponse(HttpStatusCode.NotFound, "Requested method not found");
            var response = _invoice.AddInvoice(new CustomerModel(),new APIRequest(), new List<InvoiceModel>());
        }

        [TestMethod]
        [ExpectedException(typeof(RequestFailedException))]
        public void GivenCalling_AddInvoices_RequestFailsThenThrowException()
        {
            MockHttpErrorResponse(HttpStatusCode.PaymentRequired, "Request failed");
            var response = _invoice.AddInvoice(new CustomerModel(), new APIRequest(), new List<InvoiceModel>());
        }

        [TestMethod]
        [ExpectedException(typeof(ForbiddenException))]
        public void GivenCalling_AddInvoices_ThrowsForbiddenException()
        {
            MockHttpErrorResponse(HttpStatusCode.Forbidden, "Request forbidden");
            var response = _invoice.AddInvoice(new CustomerModel(), new APIRequest(), new List<InvoiceModel>());
        }

    }
}
