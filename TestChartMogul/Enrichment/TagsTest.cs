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
    public class TagsTest : ParentTest
    {
        private Tags _custom;
        private string customerUUID;
        // private Mock<IGetResponse> _getResponse;

        [TestInitialize]
        public void TestInitialize()
        {
            _getResponse = new Mock<IGetResponse>();
            _custom = new Tags(new Http(_getResponse.Object));
            customerUUID = "cus_de305d54-75b4-431b-adb2-eb6b9e546012";
        }

        public CustomerTag GetCustomerTags()
        {
            return new CustomerTag()
            {
                Email="customer@test.com",
                Tags= new string[4] { "convertedAt", "pro", "channel","test" }               
            };
        }

        public CustomerTag GetCustomerTagsAfterRemovingATag()
        {
            return new CustomerTag()
            {
                Email = "customer@test.com",
                Tags = new string[3] { "convertedAt", "pro", "channel" }
            };
        }

        public CustomerResponseModel GetCustomerResponseModel()
        {
            return new CustomerResponseModel()
            {
                Entries = new List<CustomerModel> { GetCustomerModel() }
            };
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

        [TestMethod]
        public void GivenCalling_AddTags_ReturnsTags()
        {
            MockHttpResponse<CustomerTag>(GetCustomerTags());
            var response = _custom.AddTagsToCustomer(customerUUID, new APIRequest(), new string[1] { "important" });
            Assert.IsNotNull(response);
        }

        [TestMethod]
        [ExpectedException(typeof(UnAuthorizedUserException))]
        public void GivenCalling_AddTags_WhenUserIsNotAuthorizedThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.Unauthorized, "The remote server returned an error: (401) Unauthorized.");
            var response = _custom.AddTagsToCustomer(customerUUID, new APIRequest(), new string[1] { "important" });
        }


        [TestMethod]
        [ExpectedException(typeof(ChartMogulException))]
        public void GivenCalling_AddTags_WhenServerIsNotRespondingThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.GatewayTimeout, "The remote server returned an error: (504)");
            var response = _custom.AddTagsToCustomer(customerUUID, new APIRequest(), new string[1] { "important" });
        }



        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void GivenCalling_AddTags_ThrowsNotFoundException_WhenCustomerUUIDIsNotFound()
        {
            MockHttpErrorResponse(HttpStatusCode.NotFound, "Customer UUID not found");
            var response = _custom.AddTagsToCustomer("cus_23423Test", new APIRequest(), new string[1] { "important" });
        }

        [TestMethod]
        public void GivenCalling_AddTagsToCustomerWithEmail_ReturnsTags()
        {
            MockHttpResponse<CustomerResponseModel>(GetCustomerResponseModel());           
            var response = _custom.AddTagsToCustomerWithEmail("customer@test.com", new APIRequest(), GetCustomerTags());
            Assert.IsNotNull(response);
        }

        [TestMethod]
        [ExpectedException(typeof(UnAuthorizedUserException))]
        public void GivenCalling_AddTagsToCustomerWithEmail_WhenUserIsNotAuthorizedThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.Unauthorized, "The remote server returned an error: (401) Unauthorized.");
            var response = _custom.AddTagsToCustomerWithEmail("customer@test.com", new APIRequest(), GetCustomerTags());
        }


        [TestMethod]
        [ExpectedException(typeof(ChartMogulException))]
        public void GivenCalling_AddTagsToCustomerWithEmail_WhenServerIsNotRespondingThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.GatewayTimeout, "The remote server returned an error: (504)");
            var response = _custom.AddTagsToCustomerWithEmail("customer@test.com", new APIRequest(), GetCustomerTags());
        }



        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void GivenCalling_AddTagsToCustomerWithEmail_ThrowsNotFoundException_WhenCustomerUUIDIsNotFound()
        {
            MockHttpErrorResponse(HttpStatusCode.NotFound, "Customer with specified email id not found");
            var response = _custom.AddTagsToCustomerWithEmail("customernotfound@test.com", new APIRequest(), GetCustomerTags());
        }

        [TestMethod]
        public void GivenCalling_RemoveTagsFromCustomer_ReturnsTagsWithChanges()
        {                
            MockHttpResponse<CustomerTag>(GetCustomerTagsAfterRemovingATag());
            var response = _custom.RemoveTagsFromCustomer(customerUUID, new APIRequest(), new string[] { "test"});
            Assert.IsNotNull(response);
        }

        [TestMethod]
        [ExpectedException(typeof(UnAuthorizedUserException))]
        public void GivenCalling_RemoveTagsFromCustomer_WhenUserIsNotAuthorizedThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.Unauthorized, "The remote server returned an error: (401) Unauthorized.");
            var response = _custom.RemoveTagsFromCustomer(customerUUID, new APIRequest(), new string[] { "test" });
        }


        [TestMethod]
        [ExpectedException(typeof(ChartMogulException))]
        public void GivenCalling_RemoveTagsFromCustomer_WhenServerIsNotRespondingThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.GatewayTimeout, "The remote server returned an error: (504)");
            var response = _custom.RemoveTagsFromCustomer(customerUUID, new APIRequest(), new string[] { "test" });
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void GivenCalling_RemoveTagsFromCustomer_ThrowsNotFoundException_WhenCustomerUUIDIsNotFound()
        {
            MockHttpErrorResponse(HttpStatusCode.NotFound, "Customer uuid not found");
            var response = _custom.RemoveTagsFromCustomer("cus_32434Test", new APIRequest(), new string[] { "test" });
        }
        
    }
}
