using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChartMogul.API.Metrics;
using ChartMogul.API;
using Moq;
using ChartMogul.API.Models.Metrics;

namespace TestChartMogul.Metrics
{
    [TestClass]
    public class CustomAttributeTest : ParentTest
    {
        private ChartMogul.API.Metrics.Metrics _metrics;
        private string customerUUID;
        private MetricsQueryParams _queryParam;
        // private Mock<IGetResponse> _getResponse;

        [TestInitialize]
        public void TestInitialize()
        {
            _getResponse = new Mock<IGetResponse>();
            _metrics = new ChartMogul.API.Metrics.Metrics(new Http(_getResponse.Object));
            customerUUID = "cus_de305d54-75b4-431b-adb2-eb6b9e546012";
            _queryParam = new MetricsQueryParams() { StartDate = "2015-11-05", EndDate = "2015-12-30" };
        }

        //private KeyMetricsModel GetKeyMetricModel()
        //{
        //    return new KeyMetricsModel
        //    {
        //        Entries = new List<Entry> { new Entry { Arpa = 11, Date = "2015-11-06", Arr = "254000", Asp = "22", Mrr = "21166", Ltv = "1250.3", Customers = "331" } }
        //    };
        //}

        //    [TestMethod]
        //    public void GivenCalling_GetAllKeyMetrics_ReturnsAllKeyMetricsOfCustomer()
        //    {
        //        MockHttpResponse<CustomModel>(GetCustomModel());
        //        var response = _metrics.GetAllKeyMetrics(_queryParam);
        //        Assert.IsNotNull(response);
        //    }

        //    [TestMethod]
        //    [ExpectedException(typeof(UnAuthorizedUserException))]
        //    public void GivenCalling_AddCustomAttribute_WhenUserIsNotAuthorizedThenThrowsException()
        //    {
        //        MockHttpErrorResponse(HttpStatusCode.Unauthorized, "The remote server returned an error: (401) Unauthorized.");
        //        var response = _customAttribute.AddCustomAttribute(customerUUID, new APIRequest(), GetCustomAttributeToBeAdded());
        //    }


        //    [TestMethod]
        //    [ExpectedException(typeof(ChartMogulException))]
        //    public void GivenCalling_AddCustomAttribute_WhenServerIsNotRespondingThenThrowsException()
        //    {
        //        MockHttpErrorResponse(HttpStatusCode.GatewayTimeout, "The remote server returned an error: (504)");
        //        var response = _customAttribute.AddCustomAttribute(customerUUID, new APIRequest(), GetCustomAttributeToBeAdded());
        //    }



        //    [TestMethod]
        //    [ExpectedException(typeof(NotFoundException))]
        //    public void GivenCalling_AddCustomAttribute_ThrowsNotFoundException_WhenCustomerUUIDIsNotFound()
        //    {
        //        MockHttpErrorResponse(HttpStatusCode.NotFound, "Customer UUID not found");
        //        var response = _customAttribute.AddCustomAttribute("cus_23423Test", new APIRequest(), GetCustomAttributeToBeAdded());
        //    }
        //}
    }
}
