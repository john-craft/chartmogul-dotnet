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

namespace TestChartMogul.Import
{
    [TestClass]
  public  class CustomerTest:ParentTest
    {
         private Customer _customer;


        [TestInitialize]
        public void TestInitialize()
        {
            _customer = new Customer(_http.Object);
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

        [TestMethod]
        public void GivenCalling_GetCustomers_ReturnsListOfCustomers()
        {
            _http.Setup(x => x.Get<CustomerResponseDataModel>()).Returns(new CustomerResponseDataModel() { Customers = new System.Collections.Generic.List<CustomerModel> { new CustomerModel() { City = "test", Company = "test" } } });
            var response = _customer.GetCustomers(new APIRequest());
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void GivenCalling_AddCustomers_AddCustomerAndReturnResponse()
        {
            _http.Setup(x => x.Post<CustomerModel, CustomerModel>(It.IsAny<CustomerModel>())).Returns(GetCustomerModel());
            var response = _customer.AddCustomer(GetCustomerModel(),new APIRequest());
            Assert.IsNotNull(response);
        }

        [TestMethod]
        [ExpectedException(typeof(UnAuthorizedUserException))]
        public void GivenCalling_GetCustomers_WhenUserIsNotAuthorizedThenThrowsException()
        {
           _http.Setup(x => x.Get<CustomerResponseDataModel>()).Throws(new UnAuthorizedUserException("User is not authorized"));
            var response = _customer.GetCustomers(new APIRequest());    
        }

        [TestMethod]
        [ExpectedException(typeof(SchemaInvalidException))]
        public void GivenCalling_PostCustomers_WhenSchemaIsInvalidThenThrowsException()
        {
            _http.Setup(x => x.Post<CustomerModel,CustomerModel>(It.IsAny<CustomerModel>())).Throws(new SchemaInvalidException("Unprocessable Entity (Your request has semantic errors)"));
            var response = _customer.AddCustomer(new CustomerModel(),new APIRequest());
        }

        [TestMethod]
        [ExpectedException(typeof(UnAuthorizedUserException))]
        public void GivenCalling_PostCustomers_WhenUserIsNotAuthorizedThenThrowsException()
        {
            _http.Setup(x => x.Post<CustomerModel, CustomerModel>(It.IsAny<CustomerModel>())).Throws(new UnAuthorizedUserException("User is not authorized"));
            var response = _customer.AddCustomer(new CustomerModel(), new APIRequest());
        }

        [TestMethod]
        [ExpectedException(typeof(ChartMogulException))]
        public void GivenCalling_PostCustomers_WhenCustomerExternalUUIDAlreadyExistThenThrowsException()
        {
            _http.Setup(x => x.Post<CustomerModel, CustomerModel>(It.IsAny<CustomerModel>())).Throws(new ChartMogulException("Customer with same external uuid already exist"));
            var response = _customer.AddCustomer(new CustomerModel(), new APIRequest());
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void GivenCalling_PostCustomers_WhenUrlIsNotThenThrowsNotFoundException()
        {
            _http.Setup(x => x.Post<CustomerModel, CustomerModel>(It.IsAny<CustomerModel>())).Throws(new NotFoundException("Server not found"));
            var response = _customer.AddCustomer(new CustomerModel(), new APIRequest());
        }

        [TestMethod]
        [ExpectedException(typeof(RequestFailedException))]
        public void GivenCalling_PostCustomers_RequestFailsThenThrowException()
        {
            _http.Setup(x => x.Post<CustomerModel, CustomerModel>(It.IsAny<CustomerModel>())).Throws(new RequestFailedException("Request failed with status code 402"));
            var response = _customer.AddCustomer(new CustomerModel(), new APIRequest());
        }

        [TestMethod]
        [ExpectedException(typeof(ForbiddenException))]
        public void GivenCalling_PostCustomers_ThrowsForbiddenExceptionWhen()
        {
            _http.Setup(x => x.Post<CustomerModel, CustomerModel>(It.IsAny<CustomerModel>())).Throws(new ForbiddenException("The requested action is forbidden."));
            var response = _customer.AddCustomer(new CustomerModel(), new APIRequest());
        }

    }
}
