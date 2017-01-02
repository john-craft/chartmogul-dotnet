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
using System.Net;
using ChartMogul.API.Exceptions;
using System.IO;

namespace TestChartMogul.Metrics
{
    [TestClass]
    public class CustomAttributeTest : ParentTest
    {
        private ChartMogul.API.Metrics.Metrics _metrics;
        private string customerUUID;
        private MetricsQueryParams _queryParam;      

        [TestInitialize]
        public void TestInitialize()
        {
            _getResponse = new Mock<IGetResponse>();
            _metrics = new ChartMogul.API.Metrics.Metrics(new Http(_getResponse.Object));
            _metrics.ApiRequest = new ChartMogul.API.Models.Core.APIRequest();
            customerUUID = "cus_de305d54-75b4-431b-adb2-eb6b9e546012";
            _queryParam = new MetricsQueryParams() { StartDate = "2015-11-05", EndDate = "2015-12-30" };
        }

        private KeyMetricsModel GetKeyMetricModel()
        {
            return new KeyMetricsModel
            {
                Entries = new List<Entry> { new Entry { Arpa = 11, Date = DateTime.Parse("2015-11-06"), Arr = 254000, Asp = 22, Mrr = 21166, Ltv = (decimal)1250.3, Customers = 331 } }                           
            };
        }

        private ARPAModel GetARPAModel()
        {
            return new ARPAModel
            {
                Entries = new List<ARPAEntry> { new ARPAEntry { Arpa = 10, Date = DateTime.Parse("2015-11-06") } },
                Summary = new Summary
                {
                    Current = 980568,
                    Previous = 980568,
                    PercentageChange = (decimal)0.0
                }
            };
        }

        private ARRModel GetArrModel()
        {
            return new ARRModel
            {
                Entries = new List<ARREntry> { new ARREntry { Arr = 23, Date = DateTime.Parse("2015-11-06") } },
                Summary = new Summary
                {
                    Current = 23,
                    Previous = 23,
                    PercentageChange = (decimal)0.0
                }
            };
        }


        private ASPModel GetASPModel()
        {
            return new ASPModel
            {
                Entries = new List<ASPEntry> { new ASPEntry { ASP = 45, Date = DateTime.Parse("2015-11-06") } },
                Summary = new Summary
                {
                    Current = 45,
                    Previous = 45,
                    PercentageChange = (decimal)0.0
                }
            };
        }

        private CustomerChurnRateModel GetCustomerChurnRateModel()
        {
            return new CustomerChurnRateModel
            {
                Entries = new List<CustomerChurnRateEntry> { new CustomerChurnRateEntry { CustomerChurnRate = 23, Date = DateTime.Parse("2015-11-06") } },
                Summary = new Summary
                {
                    Current = 23,
                    Previous = 23,
                    PercentageChange = (decimal)0.0
                }
            };
        }

        private CustomerCountModel GetCustomerCountModel()
        {
            return new CustomerCountModel
            {
                Entries = new List<CustomerCountEntry> { new CustomerCountEntry { Customers = 67, Date = DateTime.Parse("2015-11-06") } },
                Summary = new Summary
                {
                    Current = 67,
                    Previous = 67,
                    PercentageChange = (decimal)0.0
                }
            };
        }

        private CustomerLTVModel GetCustomerLTVModel()
        {
            return new CustomerLTVModel
            {
                Entries = new List<CustomerLTVEntry> { new CustomerLTVEntry { LTV = 16, Date = DateTime.Parse("2015-11-06") } },
                Summary = new Summary
                {
                    Current = 16,
                    Previous = 16,
                    PercentageChange = (decimal)0.0
                }
            };
        }


        private MRRChurnRateModel GetMrrChurnRateModel()
        {
            return new MRRChurnRateModel
            {
                Entries = new List<MRRChurnRateEntry> { new MRRChurnRateEntry {  MRRChurnRate= 16, Date = DateTime.Parse("2015-11-06") } },
                Summary = new Summary
                {
                    Current = 16,
                    Previous = 16,
                    PercentageChange = (decimal)0.0
                }
            };
        }

        private MRRModel GetMRRModel()
        {
            return new MRRModel
            {
                Entries = new List<MRREntry> { new MRREntry { MRR = 30000, Date = DateTime.Parse("2015-11-06"),MrrNewBusiness=10000,MrrExpansion=15000,MrrContraction=0,MrrChurn=0,MrrReactivation=0 }},
                Summary = new Summary
                {
                    Current = 30000,
                    Previous = 30000,
                    PercentageChange = (decimal)0.0
                }
            };
        }

        private CustomerActivityModel GetCustomerActivityModel()
        {
            return new CustomerActivityModel
            {
                Entries = new List<CustomerActivityModelEntry> { new CustomerActivityModelEntry
                    {
                      ActivityArr= 24000,
                      ActivityMrr =2000,
                      ActivityMrrMovement =2000,
                      Currency = "USD",
                      CurrencySign = "$",
                      Date = "2015-06-09T13:16:00-04:00",
                      Description = "purchased the Silver Monthly plan (1)",
                      Id = 48730,
                      Type = "new_biz"
                    }
                }
            };
        }


        [TestMethod]
        public void GivenCalling_GetAllKeyMetrics_ReturnsAllKeyMetricsOfCustomer()
        {
            MockHttpResponse<KeyMetricsModel>(GetKeyMetricModel());
            var response = _metrics.GetAllKeyMetrics(_queryParam);
            Assert.IsNotNull(response);
        }



        [TestMethod]
        [ExpectedException(typeof(UnAuthorizedUserException))]
        public void GivenCalling_GetAllKeyMetrics_WhenUserIsNotAuthorizedThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.Unauthorized, "The remote server returned an error: (401) Unauthorized.");
            var response = _metrics.GetAllKeyMetrics(_queryParam);
        }


        [TestMethod]
        [ExpectedException(typeof(ChartMogulException))]
        public void GivenCalling_GetAllKeyMetrics_WhenServerIsNotRespondingThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.GatewayTimeout, "The remote server returned an error: (504)");
            var response = _metrics.GetAllKeyMetrics(_queryParam);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void GivenCalling_GetAllKeyMetrics_ThrowsInvalidDataException_WhenStartTimeIsNullInQueryParams()
        {
            var queryParams = new MetricsQueryParams() { StartDate = null, EndDate = "2015-12-30" };
            var response = _metrics.GetAllKeyMetrics(queryParams);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void GivenCalling_GetAllKeyMetrics_ThrowsInvalidDataException_WhenEndDateIsNullInQueryParams()
        {
            var queryParams = new MetricsQueryParams() { StartDate = "2015-12-30", EndDate = null };
            var response = _metrics.GetAllKeyMetrics(queryParams);          
        }


        [TestMethod]
        public void GivenCalling_GetArpaForSpecifiedTimePeriod_ReturnsArpaDetails()
        {
            MockHttpResponse<ARPAModel>(GetARPAModel());
            var response = _metrics.GetArpaForSpecifiedTimePeriod(_queryParam);
            Assert.IsNotNull(response);
        }


        [TestMethod]
        [ExpectedException(typeof(UnAuthorizedUserException))]
        public void GivenCalling_GetArpaForSpecifiedTimePeriod_WhenUserIsNotAuthorizedThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.Unauthorized, "The remote server returned an error: (401) Unauthorized.");
            var response = _metrics.GetArpaForSpecifiedTimePeriod(_queryParam);
        }


        [TestMethod]
        [ExpectedException(typeof(ChartMogulException))]
        public void GivenCalling_GetArpaForSpecifiedTimePeriod_WhenServerIsNotRespondingThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.GatewayTimeout, "The remote server returned an error: (504)");
            var response = _metrics.GetArpaForSpecifiedTimePeriod(_queryParam);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void GivenCalling_GetArpaForSpecifiedTimePeriod_ThrowsInvalidDataException_WhenStartTimeIsNullInQueryParams()
        {
            var queryParams = new MetricsQueryParams() { StartDate = null, EndDate = "2015-12-30" };
            var response = _metrics.GetArpaForSpecifiedTimePeriod(queryParams);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void GivenCalling_GetArpaForSpecifiedTimePeriod_ThrowsInvalidDataException_WhenEndDateIsNullInQueryParams()
        {
            var queryParams = new MetricsQueryParams() { StartDate = "2015-12-30", EndDate = null };
            var response = _metrics.GetArpaForSpecifiedTimePeriod(queryParams);
        }

        [TestMethod]
        public void GivenCalling_GetArrForSpecifiedTimePeriod_ReturnsArrDetails()
        {
            MockHttpResponse<ARRModel>(GetArrModel());
            var response = _metrics.GetArrForSpecifiedTimePeriod(_queryParam);
            Assert.IsNotNull(response);
        }
       

        [TestMethod]
        [ExpectedException(typeof(UnAuthorizedUserException))]
        public void GivenCalling_GetArrForSpecifiedTimePeriod_WhenUserIsNotAuthorizedThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.Unauthorized, "The remote server returned an error: (401) Unauthorized.");
            var response = _metrics.GetArrForSpecifiedTimePeriod(_queryParam);
        }

        [TestMethod]
        [ExpectedException(typeof(ChartMogulException))]
        public void GivenCalling_GetArrForSpecifiedTimePeriod_WhenServerIsNotRespondingThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.GatewayTimeout, "The remote server returned an error: (504)");
            var response = _metrics.GetArrForSpecifiedTimePeriod(_queryParam);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void GivenCalling_GetArrForSpecifiedTimePeriod_ThrowsInvalidDataException_WhenStartTimeIsNullInQueryParams()
        {
            var queryParams = new MetricsQueryParams() { StartDate = null, EndDate = "2015-12-30" };
            var response = _metrics.GetArrForSpecifiedTimePeriod(queryParams);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void GivenCalling_GetArrForSpecifiedTimePeriod_ThrowsInvalidDataException_WhenEndDateIsNullInQueryParams()
        {
            var queryParams = new MetricsQueryParams() { StartDate = "2015-12-30", EndDate = null };
            var response = _metrics.GetArrForSpecifiedTimePeriod(queryParams);
        }

        [TestMethod]
        public void GivenCalling_GetASPForSpecifiedTimePeriod_ReturnsArrDetails()
        {
            MockHttpResponse<ASPModel>(GetASPModel());
            var response = _metrics.GetASPForSpecifiedTimePeriod(_queryParam);
            Assert.IsNotNull(response);
        }

        [TestMethod]
        [ExpectedException(typeof(UnAuthorizedUserException))]
        public void GivenCalling_GetASPForSpecifiedTimePeriod_WhenUserIsNotAuthorizedThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.Unauthorized, "The remote server returned an error: (401) Unauthorized.");
            var response = _metrics.GetASPForSpecifiedTimePeriod(_queryParam);
        }


        [TestMethod]
        [ExpectedException(typeof(ChartMogulException))]
        public void GivenCalling_GetASPForSpecifiedTimePeriod_WhenServerIsNotRespondingThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.GatewayTimeout, "The remote server returned an error: (504)");
            var response = _metrics.GetASPForSpecifiedTimePeriod(_queryParam);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void GivenCalling_GetASPForSpecifiedTimePeriod_ThrowsInvalidDataException_WhenStartTimeIsNullInQueryParams()
        {
            var queryParams = new MetricsQueryParams() { StartDate = null, EndDate = "2015-12-30" };
            var response = _metrics.GetASPForSpecifiedTimePeriod(queryParams);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void GivenCalling_GetASPForSpecifiedTimePeriod_ThrowsInvalidDataException_WhenEndDateIsNullInQueryParams()
        {
            var queryParams = new MetricsQueryParams() { StartDate = "2015-12-30", EndDate = null };
            var response = _metrics.GetASPForSpecifiedTimePeriod(queryParams);         
        }


        [TestMethod]
        public void GivenCalling_GetCustomerChurnRate_ReturnsChurnRateDetails()
        {
            MockHttpResponse<CustomerChurnRateModel>(GetCustomerChurnRateModel());
            var response = _metrics.GetCustomerChurnRate(_queryParam);
            Assert.IsNotNull(response);
        }
       

        [TestMethod]
        [ExpectedException(typeof(UnAuthorizedUserException))]
        public void GivenCalling_GetCustomerChurnRate_WhenUserIsNotAuthorizedThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.Unauthorized, "The remote server returned an error: (401) Unauthorized.");
            var response = _metrics.GetCustomerChurnRate(_queryParam);
        }


        [TestMethod]
        [ExpectedException(typeof(ChartMogulException))]
        public void GivenCalling_GetCustomerChurnRate_WhenServerIsNotRespondingThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.GatewayTimeout, "The remote server returned an error: (504)");
            var response = _metrics.GetCustomerChurnRate(_queryParam);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void GivenCalling_GetCustomerChurnRate_ThrowsInvalidDataException_WhenStartTimeIsNullInQueryParams()
        {
            var queryParams = new MetricsQueryParams() { StartDate = null, EndDate = "2015-12-30" };
            var response = _metrics.GetCustomerChurnRate(queryParams);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void GivenCalling_GetCustomerChurnRate_ThrowsInvalidDataException_WhenEndDateIsNullInQueryParams()
        {
            var queryParams = new MetricsQueryParams() { StartDate = "2015-12-30", EndDate = null };
            var response = _metrics.GetCustomerChurnRate(queryParams);
        }

        [TestMethod]
        public void GivenCalling_GetCustomerCount_ReturnsCustomerCount()
        {
            MockHttpResponse<CustomerCountModel>(GetCustomerCountModel());
            var response = _metrics.GetCustomerCount(_queryParam);
            Assert.IsNotNull(response);
        }
       

        [TestMethod]
        [ExpectedException(typeof(UnAuthorizedUserException))]
        public void GivenCalling_GetCustomerCount_WhenUserIsNotAuthorizedThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.Unauthorized, "The remote server returned an error: (401) Unauthorized.");
            var response = _metrics.GetCustomerCount(_queryParam);
        }


        [TestMethod]
        [ExpectedException(typeof(ChartMogulException))]
        public void GivenCalling_GetCustomerCount_WhenServerIsNotRespondingThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.GatewayTimeout, "The remote server returned an error: (504)");
            var response = _metrics.GetCustomerCount(_queryParam);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void GivenCalling_GetCustomerCount_ThrowsInvalidDataException_WhenStartTimeIsNullInQueryParams()
        {
            var queryParams = new MetricsQueryParams() { StartDate = null, EndDate = "2015-12-30" };
            var response = _metrics.GetCustomerCount(queryParams);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void GivenCalling_GetCustomerCount_ThrowsInvalidDataException_WhenEndDateIsNullInQueryParams()
        {
            var queryParams = new MetricsQueryParams() { StartDate = "2015-12-30", EndDate = null };
            var response = _metrics.GetCustomerCount(queryParams);
        }

        [TestMethod]
        public void GivenCalling_GetLTV_ReturnsLTVDetails()
        {
            MockHttpResponse<CustomerLTVModel>(GetCustomerLTVModel());
            var response = _metrics.GetLTV(_queryParam);
            Assert.IsNotNull(response);
        }
       

        [TestMethod]
        [ExpectedException(typeof(UnAuthorizedUserException))]
        public void GivenCalling_GetLTV_WhenUserIsNotAuthorizedThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.Unauthorized, "The remote server returned an error: (401) Unauthorized.");
            var response = _metrics.GetLTV(_queryParam);
        }


        [TestMethod]
        [ExpectedException(typeof(ChartMogulException))]
        public void GivenCalling_GetLTV_WhenServerIsNotRespondingThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.GatewayTimeout, "The remote server returned an error: (504)");
            var response = _metrics.GetLTV(_queryParam);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void GivenCalling_GetLTV_ThrowsInvalidDataException_WhenStartTimeIsNullInQueryParams()
        {
            var queryParams = new MetricsQueryParams() { StartDate = null, EndDate = "2015-12-30" };
            var response = _metrics.GetLTV(queryParams);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void GivenCalling_GetLTV_ThrowsInvalidDataException_WhenEndDateIsNullInQueryParams()
        {
            var queryParams = new MetricsQueryParams() { StartDate = "2015-12-30", EndDate = null };
            var response = _metrics.GetLTV(queryParams);
        }

        [TestMethod]
        public void GivenCalling_GetMRRChurnRate_ReturnsMRRChurnDetails()
        {
            MockHttpResponse<MRRChurnRateModel>(GetMrrChurnRateModel());
            var response = _metrics.GetMRRChurnRate(_queryParam);
            Assert.IsNotNull(response);
        }

        [TestMethod]
        [ExpectedException(typeof(UnAuthorizedUserException))]
        public void GivenCalling_GetMRRChurnRate_WhenUserIsNotAuthorizedThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.Unauthorized, "The remote server returned an error: (401) Unauthorized.");
            var response = _metrics.GetMRRChurnRate(_queryParam);
        }


        [TestMethod]
        [ExpectedException(typeof(ChartMogulException))]
        public void GivenCalling_GetMRRChurnRate_WhenServerIsNotRespondingThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.GatewayTimeout, "The remote server returned an error: (504)");
            var response = _metrics.GetMRRChurnRate(_queryParam);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void GivenCalling_GetMRRChurnRate_ThrowsInvalidDataException_WhenStartTimeIsNullInQueryParams()
        {
            var queryParams = new MetricsQueryParams() { StartDate = null, EndDate = "2015-12-30" };
            var response = _metrics.GetMRRChurnRate(queryParams);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void GivenCalling_GetMRRChurnRate_ThrowsInvalidDataException_WhenEndDateIsNullInQueryParams()
        {
            var queryParams = new MetricsQueryParams() { StartDate = "2015-12-30", EndDate = null };
            var response = _metrics.GetMRRChurnRate(queryParams);
        }

        [TestMethod]
        public void GivenCalling_GetMrrForSpecifiedTimePeriod_ReturnsMRRDetails()
        {
            MockHttpResponse<MRRModel>(GetMRRModel());
            var response = _metrics.GetMrrForSpecifiedTimePeriod(_queryParam);
            Assert.IsNotNull(response);
        }       

        [TestMethod]
        [ExpectedException(typeof(UnAuthorizedUserException))]
        public void GivenCalling_GetMrrForSpecifiedTimePeriod_WhenUserIsNotAuthorizedThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.Unauthorized, "The remote server returned an error: (401) Unauthorized.");
            var response = _metrics.GetMrrForSpecifiedTimePeriod(_queryParam);
        }


        [TestMethod]
        [ExpectedException(typeof(ChartMogulException))]
        public void GivenCalling_GetMrrForSpecifiedTimePeriod_WhenServerIsNotRespondingThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.GatewayTimeout, "The remote server returned an error: (504)");
            var response = _metrics.GetMrrForSpecifiedTimePeriod(_queryParam);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void GivenCalling_GetMrrForSpecifiedTimePeriod_ThrowsInvalidDataException_WhenStartTimeIsNullInQueryParams()
        {
            var queryParams = new MetricsQueryParams() { StartDate = null, EndDate = "2015-12-30" };
            var response = _metrics.GetMrrForSpecifiedTimePeriod(queryParams);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void GivenCalling_GetMrrForSpecifiedTimePeriod_ThrowsInvalidDataException_WhenEndDateIsNullInQueryParams()
        {
            var queryParams = new MetricsQueryParams() { StartDate = "2015-12-30", EndDate = null };
            var response = _metrics.GetMrrForSpecifiedTimePeriod(queryParams);
        }

        [TestMethod]
        public void GivenCalling_GetCustomerActivities_ReturnsCustomerActivityDetails()
        {
            MockHttpResponse<CustomerActivityModel>(GetCustomerActivityModel());
            var response = _metrics.GetCustomerActivities(customerUUID);
            Assert.IsNotNull(response);
        }      

        [TestMethod]
        [ExpectedException(typeof(UnAuthorizedUserException))]
        public void GivenCalling_GetCustomerActivities_WhenUserIsNotAuthorizedThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.Unauthorized, "The remote server returned an error: (401) Unauthorized.");
            var response = _metrics.GetCustomerActivities(customerUUID);
        }


        [TestMethod]
        [ExpectedException(typeof(ChartMogulException))]
        public void GivenCalling_GetCustomerActivities_WhenServerIsNotRespondingThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.GatewayTimeout, "The remote server returned an error: (504)");
            var response = _metrics.GetCustomerActivities(customerUUID);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void GivenCalling_GetCustomerActivities_ThrowsNotFoundException_WhenCustomerUUIDIsNotFound()
        {
            MockHttpErrorResponse(HttpStatusCode.NotFound, "Customer UUID Not Found");
            var response = _metrics.GetCustomerActivities("cus_12023");
        }


        [TestMethod]
        public void GivenCalling_GetCustomerSubscriptionDetails_ReturnsCustomerSubscriptionDetails()
        {
            MockHttpResponse<CustomerActivityModel>(GetCustomerActivityModel());
            var response = _metrics.GetCustomerSubscriptionDetails(customerUUID);
            Assert.IsNotNull(response);
        }

        [TestMethod]
        [ExpectedException(typeof(UnAuthorizedUserException))]
        public void GivenCalling_GetCustomerSubscriptionDetails_WhenUserIsNotAuthorizedThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.Unauthorized, "The remote server returned an error: (401) Unauthorized.");
            var response = _metrics.GetCustomerSubscriptionDetails(customerUUID);
        }


        [TestMethod]
        [ExpectedException(typeof(ChartMogulException))]
        public void GivenCalling_GetCustomerSubscriptionDetails_WhenServerIsNotRespondingThenThrowsException()
        {
            MockHttpErrorResponse(HttpStatusCode.GatewayTimeout, "The remote server returned an error: (504)");
            var response = _metrics.GetCustomerSubscriptionDetails(customerUUID);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void GivenCalling_GetCustomerSubscriptionDetails_ThrowsNotFoundException_WhenCustomerUUIDIsNotFound()
        {
            MockHttpErrorResponse(HttpStatusCode.NotFound, "Customer UUID Not Found");
            var response = _metrics.GetCustomerSubscriptionDetails("cus_12023");
        }
    }
}
