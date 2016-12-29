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
    public class DataSourceTest : ParentTest
    {
        private DataSource _dataSource;
        // private Mock<IGetResponse> _getResponse;

        [TestInitialize]
        public void TestInitialize()
        {
            _getResponse = new Mock<IGetResponse>();
            _dataSource = new DataSource(new Http(_getResponse.Object));
        }

        public DataSourceModel GetDataSourceModel()
        {
            return new DataSourceModel()
            {
                CreatedDate = DateTime.Now,
                Name = "DummyDataSource",
                Status = "Idle",
                Uuid = "ds_b98bb0da-c81a-11e6-adf5-4b8f870d3c"
            };
        }

        public DataSourceResponseDataModel GetDataResponseDataModel()
        {
            return new DataSourceResponseDataModel()
            {
                DataSources = new List<DataSourceModel>() { GetDataSourceModel() }                

            };
        }

        [TestMethod]
        public void GivenCalling_GetDataSources_ReturnsListOfDataSources()
        {
            MockHttpResponse<DataSourceResponseDataModel>(GetDataResponseDataModel());
            var response = _dataSource.GetDataSources(new APIRequest());
            Assert.IsNotNull(response);
        }

        [TestMethod]
        [ExpectedException(typeof(ChartMogulException))]
        public void GivenCalling_GetDataSources_WhenServerIsNotRespondingThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.GatewayTimeout, "The remote server returned an error: (504)");
            var response = _dataSource.GetDataSources(new APIRequest());
        }


        [TestMethod]
        [ExpectedException(typeof(UnAuthorizedUserException))]
        public void GivenCalling_GetDataSources_WhenUserIsNotAuthorizedThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.Unauthorized, "The remote server returned an error: (401) Unauthorized.");
            var response = _dataSource.GetDataSources(new APIRequest());
        }

        [TestMethod]
        public void GivenCalling_AddDataSources_AddDataSourceAndReturnResponse()
        {
            MockHttpResponse<DataSourceModel>(GetDataSourceModel());
            var response = _dataSource.AddDataSource(GetDataSourceModel(), new APIRequest());
            Assert.IsNotNull(response);
        }

        [TestMethod]
        [ExpectedException(typeof(SchemaInvalidException))]
        public void GivenCalling_AddDataSources_WhenSchemaIsInvalidThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.BadRequest, "Scheme is invalid. Required parameter external id is missing");
            var response = _dataSource.AddDataSource(new DataSourceModel(), new APIRequest());
        }

        [TestMethod]
        [ExpectedException(typeof(UnAuthorizedUserException))]
        public void GivenCalling_AddDataSources_WhenUserIsNotAuthorizedThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.Unauthorized, "The remote server returned an error: (401) Unauthorized.");
            var response = _dataSource.AddDataSource(new DataSourceModel(), new APIRequest());
        }

        [TestMethod]
        [ExpectedException(typeof(ChartMogulException))]
        public void GivenCalling_AddDataSources_WhenDataSourceExternalUUIDAlreadyExistThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.NotAcceptable, "External Id already exist");
            var response = _dataSource.AddDataSource(GetDataSourceModel(), new APIRequest());
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void GivenCalling_AddDataSources_WhenUrlIsNotThenThrowsNotFoundException()
        {
            MockHttpErrorResponse(HttpStatusCode.NotFound, "Requested method not found");
            var response = _dataSource.AddDataSource(new DataSourceModel(), new APIRequest());
        }

        [TestMethod]
        [ExpectedException(typeof(RequestFailedException))]
        public void GivenCalling_AddDataSources_RequestFailsThenThrowException()
        {
            MockHttpErrorResponse(HttpStatusCode.PaymentRequired, "Request failed");
            var response = _dataSource.AddDataSource(new DataSourceModel(), new APIRequest());
        }

        [TestMethod]
        [ExpectedException(typeof(ForbiddenException))]
        public void GivenCalling_AddDataSources_ThrowsForbiddenException()
        {
            MockHttpErrorResponse(HttpStatusCode.Forbidden, "Request forbidden");
            var response = _dataSource.AddDataSource(new DataSourceModel(), new APIRequest());
        }

        [TestMethod]
        public void GivenCalling_DeleteDataSource_ThrowsNoExceptionIfSuccess()
        {          
            _dataSource.DeleteDataSource(new DataSourceModel(), new APIRequest());
        }

        [TestMethod]
        [ExpectedException(typeof(ChartMogulException))]
        public void GivenCalling_DeleteDataSource_ThrowsExceptionWhenServerIsNotResponding()
        {
            MockHttpErrorResponse(HttpStatusCode.GatewayTimeout, "The remote server returned an error: (504)");
            _dataSource.DeleteDataSource(new DataSourceModel(), new APIRequest());
        }

        [TestMethod]
        [ExpectedException(typeof(UnAuthorizedUserException))]
        public void GivenCalling_DeleteDataSource_ThrowsUserUnAuthorizedException()
        {
            MockHttpErrorResponse(HttpStatusCode.Unauthorized, "The remote server returned an error: (401) Unauthorized.");
            _dataSource.DeleteDataSource(new DataSourceModel(), new APIRequest());
        }

    }
}
