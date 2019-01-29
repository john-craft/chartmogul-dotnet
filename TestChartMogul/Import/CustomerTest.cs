﻿using ChartMogul.API;
using ChartMogul.API.Exceptions;
using ChartMogul.API.Import;
using ChartMogul.API.Models;
using ChartMogul.API.Models.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Net;
using ChartMogul.API.Models.Import;
using System.Collections.Generic;

namespace TestChartMogul.Import
{
    [TestClass]
  public  class CustomerTest:ParentTest
    {
         private Customer _customer;
       // private Mock<IGetResponse> _getResponse;

        [TestInitialize]
        public void TestInitialize()
        {
            _getResponse = new Mock<IGetResponse>();
            _customer = new Customer(new Http(_getResponse.Object));                
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

        public CustomerResponseDataModel GetCustomerResponseDataModel()
        {
            return new CustomerResponseDataModel()
            {
                Customers = new List<CustomerModel>() { GetCustomerModel() }

            };
        }

        [TestMethod]
        public void GivenCalling_GetCustomers_ReturnsListOfCustomers()
        {
            MockHttpResponse<CustomerResponseDataModel>(GetCustomerResponseDataModel());
            var response = _customer.GetCustomers(new APIRequest());
            Assert.IsNotNull(response);
        }

        [TestMethod]
        [ExpectedException(typeof(UnAuthorizedUserException))]
        public void GivenCalling_GetCustomers_WhenUserIsNotAuthorizedThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.Unauthorized, "The remote server returned an error: (401) Unauthorized.");
            var response = _customer.GetCustomers(new APIRequest());
        }


        [TestMethod]
        [ExpectedException(typeof(ChartMogulException))]
        public void GivenCalling_GetCustomers_WhenServerIsNotRespondingThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.GatewayTimeout, "The remote server returned an error: (504)");
            var response = _customer.GetCustomers(new APIRequest());
        }

        [TestMethod]
        public void GivenCalling_AddCustomers_AddCustomerAndReturnResponse()
        {
            MockHttpResponse<CustomerModel>(GetCustomerModel());
            var response = _customer.AddCustomer(GetCustomerModel(),new APIRequest());
            Assert.IsNotNull(response);
        }      

        [TestMethod]
        [ExpectedException(typeof(SchemaInvalidException))]
        public void GivenCalling_AddCustomers_WhenSchemaIsInvalidThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.BadRequest, "Scheme is invalid. Required parameter external id is missing");
            var response = _customer.AddCustomer(new CustomerModel(),new APIRequest());
        }

        [TestMethod]
        [ExpectedException(typeof(UnAuthorizedUserException))]
        public void GivenCalling_AddCustomers_WhenUserIsNotAuthorizedThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.Unauthorized, "The remote server returned an error: (401) Unauthorized.");
            var response = _customer.AddCustomer(new CustomerModel(), new APIRequest());
        }

        [TestMethod]
        [ExpectedException(typeof(ChartMogulException))]
        public void GivenCalling_AddCustomers_WhenCustomerExternalUUIDAlreadyExistThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.NotAcceptable, "External Id already exist");
            var response = _customer.AddCustomer(GetCustomerModel(), new APIRequest());
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void GivenCalling_AddCustomers_WhenUrlIsNotValidThenThrowsNotFoundException()
        {
            MockHttpErrorResponse(HttpStatusCode.NotFound, "Requested method not found");
            var response = _customer.AddCustomer(new CustomerModel(), new APIRequest());
        }

        [TestMethod]
        [ExpectedException(typeof(RequestFailedException))]
        public void GivenCalling_AddCustomers_RequestFailsThenThrowException()
        {
            MockHttpErrorResponse(HttpStatusCode.PaymentRequired, "Request failed");
            var response = _customer.AddCustomer(new CustomerModel(), new APIRequest());
        }

        [TestMethod]
        [ExpectedException(typeof(ForbiddenException))]
        public void GivenCalling_AddCustomers_ThrowsForbiddenException()
        {
            MockHttpErrorResponse(HttpStatusCode.Forbidden, "Request forbidden");
            var response = _customer.AddCustomer(new CustomerModel(), new APIRequest());
        }

        [TestMethod]
        public void GivenCalling_DeleteCustomer_ThrowsNoExceptionIfSuccess()
        {         
          _customer.DeleteCustomer(new CustomerModel(), new APIRequest());
        }


        [TestMethod]
        [ExpectedException(typeof(UnAuthorizedUserException))]
        public void GivenCalling_DeleteCustomer_ThrowsUserUnAuthorizedException()
        {
            MockHttpErrorResponse(HttpStatusCode.Unauthorized, "The remote server returned an error: (401) Unauthorized.");          
            _customer.DeleteCustomer(new CustomerModel(), new APIRequest());
        }

        [TestMethod]
        [ExpectedException(typeof(ChartMogulException))]
        public void GivenCalling_DeleteCustomer_ThrowsExceptionWhenServerIsNotResponding()
        {
            MockHttpErrorResponse(HttpStatusCode.GatewayTimeout, "The remote server returned an error: (504)");
            _customer.DeleteCustomer(new CustomerModel(), new APIRequest());
        }

    }
}
