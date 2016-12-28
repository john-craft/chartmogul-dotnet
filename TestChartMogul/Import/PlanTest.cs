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
    public class PlanTest : ParentTest
    {
        private Plan _plan;
        // private Mock<IGetResponse> _getResponse;

        [TestInitialize]
        public void TestInitialize()
        {
            _getResponse = new Mock<IGetResponse>();
            _plan = new Plan(new Http(_getResponse.Object));
        }

        public PlanModel GetPlanModel()
        {
            return new PlanModel()
            {
                DataSource= "ds_fef05d54-47b4-431b-aed2-eb6b9e545430",
                ExternalId= "plan_0001",
                IntervalCount=1,
                InvervalUnit= "month",
                Name= "Bronze Plan",
                Uuid= "li_d72e6843-5793-41d0-bfdf-0269514c9c56"
            };
        }

        public PlanResponseDataModel GetPlanResponseDataModel()
        {
            return new PlanResponseDataModel()
            {
                Plans = new List<PlanModel>() { GetPlanModel() }

            };
        }

        [TestMethod]
        public void GivenCalling_GetPlans_ReturnsListOfPlans()
        {
            MockHttpResponse<PlanResponseDataModel>(GetPlanResponseDataModel());
            var response = _plan.GetPlans(new APIRequest());
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void GivenCalling_AddPlans_AddPlanAndReturnResponse()
        {
            MockHttpResponse<PlanModel>(GetPlanModel());
            var response = _plan.CreatePlan(GetPlanModel(), new APIRequest());
            Assert.IsNotNull(response);
        }

        [TestMethod]
        [ExpectedException(typeof(UnAuthorizedUserException))]
        public void GivenCalling_GetPlans_WhenUserIsNotAuthorizedThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.Unauthorized, "The remote server returned an error: (401) Unauthorized.");
            var response = _plan.GetPlans(new APIRequest());
        }

        [TestMethod]
        [ExpectedException(typeof(SchemaInvalidException))]
        public void GivenCalling_AddPlans_WhenSchemaIsInvalidThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.BadRequest, "Scheme is invalid. Required parameter external id is missing");
            var response = _plan.CreatePlan(new PlanModel(), new APIRequest());
        }

        [TestMethod]
        [ExpectedException(typeof(UnAuthorizedUserException))]
        public void GivenCalling_AddPlans_WhenUserIsNotAuthorizedThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.Unauthorized, "The remote server returned an error: (401) Unauthorized.");
            var response = _plan.CreatePlan(new PlanModel(), new APIRequest());
        }

        [TestMethod]
        [ExpectedException(typeof(ChartMogulException))]
        public void GivenCalling_AddPlans_WhenPlanExternalUUIDAlreadyExistThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.NotAcceptable, "External Id already exist");
            var response = _plan.CreatePlan(new PlanModel(), new APIRequest());
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void GivenCalling_AddPlans_WhenUrlIsNotThenThrowsNotFoundException()
        {
            MockHttpErrorResponse(HttpStatusCode.NotFound, "Requested method not found");
            var response = _plan.CreatePlan(new PlanModel(), new APIRequest());
        }

        [TestMethod]
        [ExpectedException(typeof(RequestFailedException))]
        public void GivenCalling_AddPlans_RequestFailsThenThrowException()
        {
            MockHttpErrorResponse(HttpStatusCode.PaymentRequired, "Request failed");
            var response = _plan.CreatePlan(new PlanModel(), new APIRequest());
        }

        [TestMethod]
        [ExpectedException(typeof(ForbiddenException))]
        public void GivenCalling_AddPlans_ThrowsForbiddenExceptionWhen()
        {
            MockHttpErrorResponse(HttpStatusCode.Forbidden, "Request forbidden");
            var response = _plan.CreatePlan(new PlanModel(), new APIRequest());
        }   
    }
}
