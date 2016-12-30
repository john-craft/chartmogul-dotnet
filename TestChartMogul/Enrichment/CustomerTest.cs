using ChartMogul.API;
using ChartMogul.API.Exceptions;
using ChartMogul.API.Models.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OConnors.ChartMogul.API.Models;
using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using ChartMogul.API.Models.Enrichment;
using System.Collections.Generic;
using ChartMogul.API.Enrichment;

namespace TestChartMogul.Enrichment
{
    [TestClass]
    public class CustomerTest : ParentTest
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
                Id = "25647",
                Uuid = "cus_de305d54-75b4-431b-adb2-eb6b9e546012",
                ExternalId = "34916129",
                Name = "Example Company",
                Email = "bob@examplecompany.com",
                Status = "Active",
                CustomerSince = "2015-06-09T13:16:00-04:00"
            };
        }

        public CustomerPatchModel GetCustomerPatchModel()
        {
            return new CustomerPatchModel
            {
                City= "Nowhereville",
                Country= "US",
                FreeTrialStartedAt= "2015-06-13 15:45:13",
                LeadCreatedAt= "2015-01-01 00:00:00",
                State= "Alaska"
            };
        }

        public CustomerResponseModel GetCustomerResponseDataModel()
        {
            return new CustomerResponseModel {
                Entries = new List<CustomerModel>() { GetCustomerModel() }
            } ;
      
        }

        public MergeCustomers GetCustomerMergeDataModel()
        {
            return new MergeCustomers
            {
                From = new From { CustomerUUID = "cus_de305d54-75b4-431b-adb2-eb6b9e546012" },
                Into = new Into { CustomerUUID = "cus_de305d54-75b4-431b-adb2-eb6b9e546013" }
            };
        }

        [TestMethod]
        public void GivenCalling_GetCustomers_ReturnsListOfCustomers()
        {
            MockHttpResponse<CustomerResponseModel>(GetCustomerResponseDataModel());
            var response = _customer.GetAllCustomers(new APIRequest());
            Assert.IsNotNull(response);
        }

        [TestMethod]
        [ExpectedException(typeof(UnAuthorizedUserException))]
        public void GivenCalling_GetCustomers_WhenUserIsNotAuthorizedThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.Unauthorized, "The remote server returned an error: (401) Unauthorized.");
            var response = _customer.GetAllCustomers(new APIRequest());
        }


        [TestMethod]
        [ExpectedException(typeof(ChartMogulException))]
        public void GivenCalling_GetCustomers_WhenServerIsNotRespondingThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.GatewayTimeout, "The remote server returned an error: (504)");
            var response = _customer.GetAllCustomers(new APIRequest());
        }

        [TestMethod]
        public void GivenCalling_GetCustomerDetails_ReturnsCustomerDetailsFromUUID()
        {
            MockHttpResponse<CustomerModel>(GetCustomerModel());
            var response = _customer.GetCustomerDetails( new APIRequest(), "cus_de305d54-75b4-431b-adb2-eb6b9e546012");
            Assert.IsNotNull(response);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void GivenCalling_GetCustomerDetails_ThrowsNotFoundExceptionWhenCustomerUUIdIsNull()
        {
            MockHttpErrorResponse(HttpStatusCode.NotFound, "Customer UUID not found");
            var response = _customer.GetCustomerDetails(new APIRequest(), null); 
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void GivenCalling_GetCustomerDetails_ThrowsNotFoundExceptionWhenCustomerUUIdIsNotFound()
        {
            MockHttpErrorResponse(HttpStatusCode.NotFound, "Customer UUID not found");
            var response = _customer.GetCustomerDetails(new APIRequest(), "cus_de305d54-75b4-431b-adb2-eb6b9e546043");    
        }

        [TestMethod]
        public void GivenCalling_UpdateCustomer_ReturnSuccessMessage()
        {
            MockHttpResponse<CustomerModel>(GetCustomerModel());
            var response = _customer.UpdateCustomer(GetCustomerPatchModel(), new APIRequest(), "cus_de305d54-75b4-431b-adb2-eb6b9e546012");
            Assert.IsNotNull(response);
        }

        [TestMethod]
        [ExpectedException(typeof(SchemaInvalidException))]
        public void GivenCalling_UpdateCustomer_WhenSchemaIsInvalidThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.BadRequest, "Scheme is invalid. Required parameter external id is missing");
            var response = _customer.UpdateCustomer(new CustomerPatchModel(), new APIRequest(), "cus_de305d54-75b4-431b-adb2-eb6b9e5443");
        }

        [TestMethod]
        [ExpectedException(typeof(UnAuthorizedUserException))]
        public void GivenCalling_UpdateCustomer_WhenUserIsNotAuthorizedThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.Unauthorized, "The remote server returned an error: (401) Unauthorized.");
            var response = _customer.UpdateCustomer(GetCustomerPatchModel(), new APIRequest(), "cus_de305d54-75b4-431b-adb2-eb6b9e5443");
        }

        [TestMethod]
        [ExpectedException(typeof(ChartMogulException))]
        public void GivenCalling_UpdateCustomer_WhenCountryIdIsInvalid()
        {
            MockHttpErrorResponse(HttpStatusCode.NotAcceptable, "Invalid Country Id.");
            var response = _customer.UpdateCustomer(GetCustomerPatchModel(), new APIRequest(), "cus_de305d54-75b4-431b-adb2-eb6b9e5443");
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void GivenCalling_UpdateCustomer_WhenUrlIsNotValidThenThrowsNotFoundException()
        {
            MockHttpErrorResponse(HttpStatusCode.NotFound, "Requested method not found");
            var response = _customer.UpdateCustomer(GetCustomerPatchModel(), new APIRequest(), "cus_de305d54-75b4-431b-adb2-eb6b9e5443");
        }

        [TestMethod]
        [ExpectedException(typeof(RequestFailedException))]
        public void GivenCalling_UpdateCustomer_RequestFailsThenThrowException()
        {
            MockHttpErrorResponse(HttpStatusCode.PaymentRequired, "Request failed");
            var response = _customer.UpdateCustomer(GetCustomerPatchModel(), new APIRequest(), "cus_de305d54-75b4-431b-adb2-eb6b9e5443");
        }

        [TestMethod]
        [ExpectedException(typeof(ForbiddenException))]
        public void GivenCalling_AddCustomers_ThrowsForbiddenException()
        {
            MockHttpErrorResponse(HttpStatusCode.Forbidden, "Request forbidden");
            var response = _customer.UpdateCustomer(GetCustomerPatchModel(), new APIRequest(), "cus_de305d54-75b4-431b-adb2-eb6b9e5443");
        }

        [TestMethod]
        public void GivenCalling_SearchCustomer_ReturnSuccessStatus()
        {
            MockHttpResponse<CustomerResponseModel>(GetCustomerResponseDataModel());        
                var response = _customer.SearchForCustomer(new APIRequest(), "test@testcustomer.com");
                Assert.IsNotNull(response);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void GivenCalling_SearchCustomer_ThrowsNotFoundExceptionWhenEmailIdIsNotFound()
        {
            MockHttpErrorResponse(HttpStatusCode.NotFound, "Customer email not found");
            var response = _customer.SearchForCustomer(new APIRequest(), "test@testcustom.com");
        }

        [TestMethod]
        [ExpectedException(typeof(UnAuthorizedUserException))]
        public void GivenCalling_SearchCustomer_WhenUserIsNotAuthorizedThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.Unauthorized, "The remote server returned an error: (401) Unauthorized.");
            var response = _customer.SearchForCustomer(new APIRequest(), "test@testcustom.com");
        }

        [TestMethod]
        public void GivenCalling_MergeCustomer_ReturnsSuccess()
        {   
                    
            try
            {
                MockHttpResponse<CustomerModel>(new CustomerModel());
                _customer.MergeCustomers(new APIRequest(), GetCustomerMergeDataModel());
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }   
        }

        [TestMethod]
        [ExpectedException(typeof(UnAuthorizedUserException))]
        public void GivenCalling_MergeCustomer_ThrowsUnAuthorizedUserException_WhenUserIsNotAuthorized()
        {
            MockHttpErrorResponse(HttpStatusCode.Unauthorized, "The remote server returned an error: (401) Unauthorized.");       
           _customer.MergeCustomers(new APIRequest(), GetCustomerMergeDataModel());     
       
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void GivenCalling_MergeCustomer_ThrowsNotFoundException_WhenCustomerUUIDISNotFound()
        {
            MockHttpErrorResponse(HttpStatusCode.NotFound, "Customer UUID Not Found");
            _customer.MergeCustomers(new APIRequest(), new MergeCustomers());

        }
    }
}
