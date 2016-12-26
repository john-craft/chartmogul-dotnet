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

namespace TestChartMogul.Import
{
    [TestClass]
  public  class CustomerTest:ParentTest
    {
         private Customer _customer;
        private Mock<IGetResponse> _getResponse;

        [TestInitialize]
        public void TestInitialize()
        {
            _getResponse = new Mock<IGetResponse>();
            _customer = new Customer(new Http(_getResponse.Object));                
        }

        public void MockHttpResponse<T>(T data)
        {
            string serializedData = JsonConvert.SerializeObject(data);
            var expectedBytes = Encoding.UTF8.GetBytes(serializedData);
            var responseStream = new MemoryStream();
            responseStream.Write(expectedBytes, 0, expectedBytes.Length);
            responseStream.Seek(0, SeekOrigin.Begin);
            var request = new Mock<WebResponse>();
            var response = new Mock<HttpWebRequest>();
            request.Setup(c => c.GetResponseStream()).Returns(responseStream);
            // request.Setup(c => c.GetResponseStream()).Throws(new WebException() );
            request.Setup(c => c.GetResponseStream()).Throws(new WebException("tset", new Exception(), (WebExceptionStatus)400,request.Object)); 
            response.Setup(c => c.GetResponse()).Returns(request.Object);
            _getResponse.Setup(x => x.GetResponseFromServer(It.IsAny<HttpWebRequest>())).Returns(request.Object);           
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
            MockHttpResponse<CustomerModel>(GetCustomerModel());
            var response = _customer.GetCustomers(new APIRequest());
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void GivenCalling_AddCustomers_AddCustomerAndReturnResponse()
        {    
            var response = _customer.AddCustomer(GetCustomerModel(),new APIRequest());
            Assert.IsNotNull(response);
        }

        [TestMethod]
        [ExpectedException(typeof(UnAuthorizedUserException))]
        public void GivenCalling_GetCustomers_WhenUserIsNotAuthorizedThenThrowsException()
        {      
            var response = _customer.GetCustomers(new APIRequest());    
        }

        [TestMethod]
        [ExpectedException(typeof(SchemaInvalidException))]
        public void GivenCalling_PostCustomers_WhenSchemaIsInvalidThenThrowsException()
        {           
            var response = _customer.AddCustomer(new CustomerModel(),new APIRequest());
        }

        [TestMethod]
        [ExpectedException(typeof(UnAuthorizedUserException))]
        public void GivenCalling_PostCustomers_WhenUserIsNotAuthorizedThenThrowsException()
        {          
            var response = _customer.AddCustomer(new CustomerModel(), new APIRequest());
        }

        [TestMethod]
        [ExpectedException(typeof(ChartMogulException))]
        public void GivenCalling_PostCustomers_WhenCustomerExternalUUIDAlreadyExistThenThrowsException()
        {        
            var response = _customer.AddCustomer(new CustomerModel(), new APIRequest());
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void GivenCalling_PostCustomers_WhenUrlIsNotThenThrowsNotFoundException()
        {         
            var response = _customer.AddCustomer(new CustomerModel(), new APIRequest());
        }

        [TestMethod]
        [ExpectedException(typeof(RequestFailedException))]
        public void GivenCalling_PostCustomers_RequestFailsThenThrowException()
        {          
            var response = _customer.AddCustomer(new CustomerModel(), new APIRequest());
        }

        [TestMethod]
        [ExpectedException(typeof(ForbiddenException))]
        public void GivenCalling_PostCustomers_ThrowsForbiddenExceptionWhen()
        {          
            var response = _customer.AddCustomer(new CustomerModel(), new APIRequest());
        }

    }
}
