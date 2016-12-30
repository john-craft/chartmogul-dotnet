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
    public class CustomerAttributeTest : ParentTest
    {
        private CustomerAttribute _customerAttribute;
        string customerUUID;
        // private Mock<IGetResponse> _getResponse;

        [TestInitialize]
        public void TestInitialize()
        {
            customerUUID = "cus_de305d54-75b4-431b-adb2-eb6b9e546012";
            _getResponse = new Mock<IGetResponse>();
            _customerAttribute = new CustomerAttribute(new Http(_getResponse.Object));
        }

        public CustomerTag GetCustomerTag()
        {
            return new CustomerTag
            {
                Email = "customer@test.com",
                Tags = new string[3] { "engage", "unit loss", "discountable" }
            };
        }

        [TestMethod]
        public void GivenCalling_GetCustomerAttributes_ReturnsListOfCustomerAttributes()
        {
            MockHttpResponse<CustomerTag>(GetCustomerTag());
            var response = _customerAttribute.GetCustomerAttribute(customerUUID, new APIRequest());
            Assert.IsNotNull(response);
        }

        [TestMethod]
        [ExpectedException(typeof(UnAuthorizedUserException))]
        public void GivenCalling_GetCustomerAttributes_WhenUserIsNotAuthorizedThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.Unauthorized, "The remote server returned an error: (401) Unauthorized.");
            var response = _customerAttribute.GetCustomerAttribute(customerUUID, new APIRequest());
        }


        [TestMethod]
        [ExpectedException(typeof(ChartMogulException))]
        public void GivenCalling_GetCustomerAttributes_WhenServerIsNotRespondingThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.GatewayTimeout, "The remote server returned an error: (504)");
            var response = _customerAttribute.GetCustomerAttribute(customerUUID, new APIRequest());
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void GivenCalling_GetCustomerAttribute_ThrowsNotFoundExceptionWhenCustomerAttributeUUIdIsNotFound()
        {
            MockHttpErrorResponse(HttpStatusCode.NotFound, "Customer UUID not found");
            var response = _customerAttribute.GetCustomerAttribute("Cus_tste4456546456", new APIRequest());
        }

    }
}
