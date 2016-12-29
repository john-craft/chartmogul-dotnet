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
    public class TransactionTest : ParentTest
    {
        private Transaction _transaction;
        // private Mock<IGetResponse> _getResponse;

        [TestInitialize]
        public void TestInitialize()
        {
            _getResponse = new Mock<IGetResponse>();
            _transaction = new Transaction(new Http(_getResponse.Object));
        }

        public TransactionModel GetTransactionModel()
        {
            return new TransactionModel()
            {
                Date= DateTime.Now,
                ExternalId = null,
                Type ="refund",
                Result="successful"
            };
        }

        public InvoiceModel GetInvoiceModel()
        {
            return new InvoiceModel()
            {
                Currency = "USD",
                Date = DateTime.Now,
                Items = new List<LineItemModel> { GetLineItemModel() },
                Transactions = new List<TransactionModel> { GetTransactionModel() },
                DueDate = DateTime.Now.AddDays(3).ToString(),
                Uuid = "",
                ExternalId = ""
            };
        }

        public LineItemModel GetLineItemModel()
        {
            return new LineItemModel { Amount = 100 };
        }
     

        [TestMethod]
        public void GivenCalling_AddTransactions_AddTransactionAndReturnResponse()
        {
            MockHttpResponse<TransactionModel>(GetTransactionModel());
            var response = _transaction.AddTransaction(GetInvoiceModel(),GetTransactionModel(), new APIRequest());
            Assert.IsNotNull(response);
        }

        [TestMethod]
        [ExpectedException(typeof(UnAuthorizedUserException))]
        public void GivenCalling_AddTransactions_WhenUserIsNotAuthorizedThrowsAnException()
        {
            MockHttpErrorResponse(HttpStatusCode.Unauthorized, "The remote server returned an error: (401) Unauthorized.");
            var response = _transaction.AddTransaction(GetInvoiceModel(), GetTransactionModel(), new APIRequest());
        }

        [TestMethod]
        [ExpectedException(typeof(ChartMogulException))]
        public void GivenCalling_AddTransactions_WhenServerIsNotRespondingThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.GatewayTimeout, "The remote server returned an error: (504)");
            var response = _transaction.AddTransaction(GetInvoiceModel(), GetTransactionModel(), new APIRequest());
        }

        [TestMethod]
        [ExpectedException(typeof(SchemaInvalidException))]
        public void GivenCalling_AddTransactions_WhenSchemaIsInvalidThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.BadRequest, "Scheme is invalid. Required parameter external id is missing");
            var response = _transaction.AddTransaction(GetInvoiceModel(),new TransactionModel(), new APIRequest());
        }

        [TestMethod]
        [ExpectedException(typeof(UnAuthorizedUserException))]
        public void GivenCalling_AddTransactions_WhenUserIsNotAuthorizedThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.Unauthorized, "The remote server returned an error: (401) Unauthorized.");
            var response = _transaction.AddTransaction(GetInvoiceModel(), new TransactionModel(), new APIRequest());
        }

        [TestMethod]
        [ExpectedException(typeof(ChartMogulException))]
        public void GivenCalling_AddTransactions_WhenTransactionExternalUUIDAlreadyExistThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.NotAcceptable, "External Id already exist");
            var response = _transaction.AddTransaction(GetInvoiceModel(), new TransactionModel(), new APIRequest());
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void GivenCalling_AddTransactions_WhenUrlIsNotThenThrowsNotFoundException()
        {
            MockHttpErrorResponse(HttpStatusCode.NotFound, "Requested method not found");
            var response = _transaction.AddTransaction(GetInvoiceModel(), new TransactionModel(), new APIRequest());
        }

        [TestMethod]
        [ExpectedException(typeof(RequestFailedException))]
        public void GivenCalling_AddTransactions_RequestFailsThenThrowException()
        {
            MockHttpErrorResponse(HttpStatusCode.PaymentRequired, "Request failed");
            var response = _transaction.AddTransaction(GetInvoiceModel(), new TransactionModel(), new APIRequest());
        }

        [TestMethod]
        [ExpectedException(typeof(ForbiddenException))]
        public void GivenCalling_AddTransactions_ThrowsForbiddenExceptionWhen()
        {
            MockHttpErrorResponse(HttpStatusCode.Forbidden, "Request forbidden");
            var response = _transaction.AddTransaction(GetInvoiceModel(), new TransactionModel(), new APIRequest());
        }
    }
}
