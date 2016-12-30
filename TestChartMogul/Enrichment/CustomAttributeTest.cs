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
    public class CustomAttributeTest : ParentTest
    {
        private CustomAttribute _customAttribute;
        private string customerUUID;
        // private Mock<IGetResponse> _getResponse;

        [TestInitialize]
        public void TestInitialize()
        {
            _getResponse = new Mock<IGetResponse>();
            _customAttribute = new CustomAttribute(new Http(_getResponse.Object));
            customerUUID = "cus_de305d54-75b4-431b-adb2-eb6b9e546012";
        }

        public Custom GetCustomModelToBeAdded()
        {
            return new Custom()
            {
                Key= "channel",
                Value="facebook",
                Type="String"
            };
        }

        public CustomModel GetCustomModel()
        {
            var tags = new Dictionary<string,string>();
            tags.Add("channel", "facebook");
            tags.Add("age", "8");
            return new CustomModel()
            {
                Custom = tags
            };
        }

        public CustomerModel GetCustomerModel()
        {
            return new CustomerModel()
            {
                Id = "25647",
                Uuid = customerUUID,
                ExternalId = "34916129",
                Name = "Example Company",
                Email = "bob@examplecompany.com",
                Status = "Active",
                CustomerSince = "2015-06-09T13:16:00-04:00"
            };
        }

        public RemoveCustomAttributeModel GetCustomAttributeToBeRemoved()
        {
            return new RemoveCustomAttributeModel()
            {
                Custom = new string[2] { "utmCampaign", "channel" }
            };
        }

        public CustomerResponseModel GetCustomerResponseModel()
        {
            return new CustomerResponseModel()
            {
                Entries = new List<CustomerModel> { GetCustomerModel() }
            };
        }

        public AddCustomAttributeModel GetCustomAttributeToBeAdded()
        {
            return new AddCustomAttributeModel()
            {
                Custom = new List<Custom>() { GetCustomModelToBeAdded() },
                Email = "customer@test.com"
            };
        }

        [TestMethod]
        public void GivenCalling_AddCustomAttribute_ReturnsListOfCustomAttributes()
        {
            MockHttpResponse<CustomModel>(GetCustomModel());
            var response = _customAttribute.AddCustomAttribute(customerUUID,new APIRequest(), GetCustomAttributeToBeAdded());
            Assert.IsNotNull(response);
        }

        [TestMethod]
        [ExpectedException(typeof(UnAuthorizedUserException))]
        public void GivenCalling_AddCustomAttribute_WhenUserIsNotAuthorizedThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.Unauthorized, "The remote server returned an error: (401) Unauthorized.");
            var response = _customAttribute.AddCustomAttribute(customerUUID, new APIRequest(), GetCustomAttributeToBeAdded());
        }


        [TestMethod]
        [ExpectedException(typeof(ChartMogulException))]
        public void GivenCalling_AddCustomAttribute_WhenServerIsNotRespondingThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.GatewayTimeout, "The remote server returned an error: (504)");
            var response = _customAttribute.AddCustomAttribute(customerUUID, new APIRequest(), GetCustomAttributeToBeAdded());
        }



        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void GivenCalling_AddCustomAttribute_ThrowsNotFoundException_WhenCustomerUUIDIsNotFound()
        {
            MockHttpErrorResponse(HttpStatusCode.NotFound, "Customer UUID not found");
            var response = _customAttribute.AddCustomAttribute("cus_23423Test", new APIRequest(), GetCustomAttributeToBeAdded());
        }

        [TestMethod]
        public void GivenCalling_AddCustomAttributeToCustomerWithEmail_ReturnsListOfCustomAttributes()
        {
            MockHttpResponse<CustomerResponseModel>(GetCustomerResponseModel());
            var response = _customAttribute.AddCustomAttributeToCustomerWithEmail("customer@test.com", new APIRequest(), GetCustomAttributeToBeAdded());
            Assert.IsNotNull(response);
        }

        [TestMethod]
        [ExpectedException(typeof(UnAuthorizedUserException))]
        public void GivenCalling_AddCustomAttributeToCustomerWithEmail_WhenUserIsNotAuthorizedThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.Unauthorized, "The remote server returned an error: (401) Unauthorized.");
            var response = _customAttribute.AddCustomAttributeToCustomerWithEmail("customer@test.com", new APIRequest(), GetCustomAttributeToBeAdded());
        }


        [TestMethod]
        [ExpectedException(typeof(ChartMogulException))]
        public void GivenCalling_AddCustomAttributeToCustomerWithEmail_WhenServerIsNotRespondingThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.GatewayTimeout, "The remote server returned an error: (504)");
            var response = _customAttribute.AddCustomAttributeToCustomerWithEmail("customer@test.com", new APIRequest(), GetCustomAttributeToBeAdded());
        }



        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void GivenCalling_AddCustomAttributeToCustomerWithEmail_ThrowsNotFoundException_WhenCustomerUUIDIsNotFound()
        {
            MockHttpErrorResponse(HttpStatusCode.NotFound, "Customer with specified email id not found");
            var response = _customAttribute.AddCustomAttribute("customernotfound@test.com", new APIRequest(), GetCustomAttributeToBeAdded());
        }

        [TestMethod]
        public void GivenCalling_UpdateCustomAttributesOfCustomer_ReturnsCustomModelWithChanges()
        {
            MockHttpResponse<CustomerResponseModel>(GetCustomerResponseModel());
            var response = _customAttribute.UpdateCustomAttributesOfCustomer(customerUUID, new APIRequest(), GetCustomModel());
            Assert.IsNotNull(response);
        }

        [TestMethod]
        [ExpectedException(typeof(UnAuthorizedUserException))]
        public void GivenCalling_UpdateCustomAttributesOfCustomer_WhenUserIsNotAuthorizedThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.Unauthorized, "The remote server returned an error: (401) Unauthorized.");
            var response = _customAttribute.UpdateCustomAttributesOfCustomer(customerUUID, new APIRequest(), GetCustomModel());
        }


        [TestMethod]
        [ExpectedException(typeof(ChartMogulException))]
        public void GivenCalling_UpdateCustomAttributesOfCustomer_WhenServerIsNotRespondingThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.GatewayTimeout, "The remote server returned an error: (504)");
            var response = _customAttribute.UpdateCustomAttributesOfCustomer(customerUUID, new APIRequest(), GetCustomModel());
        }



        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void GivenCalling_UpdateCustomAttributesOfCustomer_ThrowsNotFoundException_WhenCustomerUUIDIsNotFound()
        {
            MockHttpErrorResponse(HttpStatusCode.NotFound, "Customer uuid not found");
            var response = _customAttribute.UpdateCustomAttributesOfCustomer("cus_1223_test", new APIRequest(), GetCustomModel());
        }


        [TestMethod]
        public void GivenCalling_RemoveCustomAttributeFromCustomer_ReturnsCustomModelWithChanges()
        {
            MockHttpResponse<CustomerResponseModel>(GetCustomerResponseModel());
            var response = _customAttribute.RemoveCustomAttributeFromCustomer(customerUUID, new APIRequest(), GetCustomAttributeToBeRemoved());
            Assert.IsNotNull(response);
        }

        [TestMethod]
        [ExpectedException(typeof(UnAuthorizedUserException))]
        public void GivenCalling_RemoveCustomAttributeFromCustomer_WhenUserIsNotAuthorizedThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.Unauthorized, "The remote server returned an error: (401) Unauthorized.");
            var response = _customAttribute.RemoveCustomAttributeFromCustomer(customerUUID, new APIRequest(), GetCustomAttributeToBeRemoved());
        }


        [TestMethod]
        [ExpectedException(typeof(ChartMogulException))]
        public void GivenCalling_RemoveCustomAttributeFromCustomer_WhenServerIsNotRespondingThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.GatewayTimeout, "The remote server returned an error: (504)");
            var response = _customAttribute.RemoveCustomAttributeFromCustomer(customerUUID, new APIRequest(), GetCustomAttributeToBeRemoved());
        }



        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void GivenCalling_RemoveCustomAttributeFromCustomer_ThrowsNotFoundException_WhenCustomerUUIDIsNotFound()
        {
            MockHttpErrorResponse(HttpStatusCode.NotFound, "Customer uuid not found");
            var response = _customAttribute.RemoveCustomAttributeFromCustomer("cus_234234", new APIRequest(), GetCustomAttributeToBeRemoved());
        }
      
    }
}
