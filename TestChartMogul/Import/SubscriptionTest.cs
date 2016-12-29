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
    public class SubscriptionTest : ParentTest
    {
        private Subscription _subscription;
        // private Mock<IGetResponse> _getResponse;

        [TestInitialize]
        public void TestInitialize()
        {
            _getResponse = new Mock<IGetResponse>();
            _subscription = new Subscription(new Http(_getResponse.Object));
        }

        public SubscriptionModel GetSubscriptionModel()
        {
            return new SubscriptionModel()
            {                               
                ExternalId = Guid.NewGuid().ToString(),
                CancellationDates = new DateTime[3],
                CustomerId = Guid.NewGuid().ToString(),
                PlanId = "pl_eed05d54-75b4-431b-adb2-eb6b9e543206"
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

        public SubscriptionResponseDataModel GetSubscriptionResponseDataModel()
        {
            return new SubscriptionResponseDataModel()
            {
                Subscriptions = new List<SubscriptionModel>() { GetSubscriptionModel() }

            };
        }

        [TestMethod]
        public void GivenCalling_GetSubscriptions_ReturnsListOfSubscriptions()
        {
            MockHttpResponse<SubscriptionResponseDataModel>(GetSubscriptionResponseDataModel());
            var response = _subscription.GetSubscriptions(GetCustomerModel(),new APIRequest());
            Assert.IsNotNull(response);
        }

        [TestMethod]
        [ExpectedException(typeof(UnAuthorizedUserException))]
        public void GivenCalling_GetSubscriptions_WhenUserIsNotAuthorizedThrowsAnException()
        {
            MockHttpErrorResponse(HttpStatusCode.Unauthorized, "The remote server returned an error: (401) Unauthorized.");
            var response = _subscription.GetSubscriptions(GetCustomerModel(), new APIRequest());
        }

        [TestMethod]
        [ExpectedException(typeof(ChartMogulException))]
        public void GivenCalling_GetSubscriptions_WhenServerIsNotRespondingThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.GatewayTimeout, "The remote server returned an error: (504)");
            var response = _subscription.GetSubscriptions(GetCustomerModel(), new APIRequest());
        }

        [TestMethod]
        public void GivenCalling_CancelSubscriptions_CancelSubscriptionAndReturnResponse()
        {
            MockHttpResponse<SubscriptionModel>(GetSubscriptionModel());
            var response = _subscription.CancelSubscription(GetSubscriptionModel(), new APIRequest());
            Assert.IsNotNull(response);
        }

        [TestMethod]
        [ExpectedException(typeof(UnAuthorizedUserException))]
        public void GivenCalling_CancelSubscriptions_WhenUserIsNotAuthorizedThrowsAnException()
        {
            MockHttpErrorResponse(HttpStatusCode.Unauthorized, "The remote server returned an error: (401) Unauthorized.");
            var response = _subscription.CancelSubscription(GetSubscriptionModel(), new APIRequest());
        }

        [TestMethod]
        [ExpectedException(typeof(ChartMogulException))]
        public void GivenCalling_CancelSubscriptions_WhenServerIsNotRespondingThrowsAnException()
        {
            MockHttpErrorResponse(HttpStatusCode.GatewayTimeout, "The remote server returned an error: (504)");
            var response = _subscription.CancelSubscription(GetSubscriptionModel(), new APIRequest());
        }

    }
}
