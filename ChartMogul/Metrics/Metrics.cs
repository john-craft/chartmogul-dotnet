using ChartMogul.API.Models.Core;
using ChartMogul.API.Models.Metrics;
using System.IO;

namespace ChartMogul.API.Metrics
{
    public interface IMetrics
    {
        KeyMetricsModel GetAllKeyMetrics(MetricsQueryParamsModel queryParams);
        MRRModel GetMrrForSpecifiedTimePeriod(MetricsQueryParamsModel queryParams);
        ARRModel GetArrForSpecifiedTimePeriod(MetricsQueryParamsModel queryParams);
        ARPAModel GetArpaForSpecifiedTimePeriod(MetricsQueryParamsModel queryParams);
        ASPModel GetASPForSpecifiedTimePeriod(MetricsQueryParamsModel queryParams);
        CustomerCountModel GetCustomerCount(MetricsQueryParamsModel queryParams);
        CustomerChurnRateModel GetCustomerChurnRate(MetricsQueryParamsModel queryParams);
        CustomerLTVModel GetLTV(MetricsQueryParamsModel queryParams);
        CustomerSubscriptionModel GetCustomerSubscriptionDetails(string customerUUID);
        CustomerActivityModel GetCustomerActivities(string customerUUID);
        MRRChurnRateModel GetMRRChurnRate(MetricsQueryParamsModel queryParams);
    }
    public class Metrics:IMetrics
    {      
        IHttp _iHttp;
        public APIRequest ApiRequest { get; set; }
        private const string metricsUrl = "metrics/all";
        private const string mrrMetricsUrl = "metrics/mrr";
        private const string arrMetricsUrl = "metrics/arr";
        private const string arpaMetricsUrl = "metrics/arpa";
        private const string aspMetricsUrl = "metrics/asp";
        private const string customerCountMetricsUrl = "metrics/customer-count";
        private const string customerChurnRateMetricsUrl= "metrics/customer-churn-rate";
        private const string mrrChurnRateMetricsUrl= "metrics/mrr-churn-rate";
        private const string ltvMetricsUrl = "metrics/ltv";
        private const string customerSubscriptionMetricsUrl = "customers/{0}/subscriptions";
        private const string customerActivityMetricsUrl = "customers/{0}/activities";
        public Metrics(IHttp iHttp)
        {
            _iHttp = iHttp;
        }

        public KeyMetricsModel GetAllKeyMetrics(MetricsQueryParamsModel queryParams)
        {
            var queryString = GenerateQuery(queryParams);
            ApiRequest.RouteName = string.Concat(metricsUrl, queryString);
            _iHttp.ApiRequest = ApiRequest;     
            var response = _iHttp.Get<KeyMetricsModel>();
            return response;
        }

        public MRRModel GetMrrForSpecifiedTimePeriod(MetricsQueryParamsModel queryParams)
        {
            var queryString = GenerateQuery(queryParams);
            ApiRequest.RouteName = string.Concat(mrrMetricsUrl, queryString);
            _iHttp.ApiRequest = ApiRequest;
            var response = _iHttp.Get<MRRModel>();
            return response;
        }

        public ARRModel GetArrForSpecifiedTimePeriod(MetricsQueryParamsModel queryParams)
        {
            var queryString = GenerateQuery(queryParams);
            ApiRequest.RouteName = string.Concat(arrMetricsUrl, queryString);
            _iHttp.ApiRequest = ApiRequest;
            var response = _iHttp.Get<ARRModel>();
            return response;
        }

        public ARPAModel GetArpaForSpecifiedTimePeriod(MetricsQueryParamsModel queryParams)
        {
            var queryString = GenerateQuery(queryParams);
            ApiRequest.RouteName = string.Concat(arpaMetricsUrl, queryString);
            _iHttp.ApiRequest = ApiRequest;
            var response = _iHttp.Get<ARPAModel>();
            return response;
        }

        public ASPModel GetASPForSpecifiedTimePeriod(MetricsQueryParamsModel queryParams)
        {
            var queryString = GenerateQuery(queryParams);
            ApiRequest.RouteName = string.Concat(aspMetricsUrl, queryString);
            _iHttp.ApiRequest = ApiRequest;
            var response = _iHttp.Get<ASPModel>();
            return response;
        }

        public CustomerCountModel GetCustomerCount(MetricsQueryParamsModel queryParams)
        {
            var queryString = GenerateQuery(queryParams);
            ApiRequest.RouteName = string.Concat(customerCountMetricsUrl, queryString);
            _iHttp.ApiRequest = ApiRequest;
            var response = _iHttp.Get<CustomerCountModel>();
            return response;
        }

        public CustomerChurnRateModel GetCustomerChurnRate(MetricsQueryParamsModel queryParams)
        {
            var queryString = GenerateQuery(queryParams);
            ApiRequest.RouteName = string.Concat(customerChurnRateMetricsUrl, queryString);
            _iHttp.ApiRequest = ApiRequest;
            var response = _iHttp.Get<CustomerChurnRateModel>();
            return response;
        }

        public MRRChurnRateModel GetMRRChurnRate(MetricsQueryParamsModel queryParams)
        {
            var queryString = GenerateQuery(queryParams);
            ApiRequest.RouteName = string.Concat(mrrChurnRateMetricsUrl, queryString);
            _iHttp.ApiRequest = ApiRequest;
            var response = _iHttp.Get<MRRChurnRateModel>();
            return response;
        }

        public CustomerLTVModel GetLTV(MetricsQueryParamsModel queryParams)
        {
            var queryString = GenerateQuery(queryParams);
            ApiRequest.RouteName = string.Concat(ltvMetricsUrl, queryString);
            _iHttp.ApiRequest = ApiRequest;
            var response = _iHttp.Get<CustomerLTVModel>();
            return response;
        }

        public CustomerSubscriptionModel GetCustomerSubscriptionDetails(string customerUUID)
        {
            ApiRequest.RouteName = string.Format(customerSubscriptionMetricsUrl, customerUUID);
            _iHttp.ApiRequest = ApiRequest;
            var response = _iHttp.Get<CustomerSubscriptionModel>();
            return response;
        }

        public CustomerActivityModel GetCustomerActivities(string customerUUID)
        {
            ApiRequest.RouteName = string.Format(customerActivityMetricsUrl, customerUUID);
            _iHttp.ApiRequest = ApiRequest;
            var response = _iHttp.Get<CustomerActivityModel>();
            return response;
        }

        private string GenerateQuery(MetricsQueryParamsModel queryParams)
        {
            if (string.IsNullOrEmpty(queryParams.StartDate) )
            {
                throw new InvalidDataException("Start date is required. It cannot be null");
            }
            if (string.IsNullOrEmpty(queryParams.EndDate))
            {
                throw new InvalidDataException("End date is required. It cannot be null");
            }
            string queryString = string.Concat("?start-date=", queryParams.StartDate, "&end-date=", queryParams.EndDate);
            if (!string.IsNullOrEmpty(queryParams.Plans))
                queryString = string.Concat(queryString, "&plans=", queryParams.Plans);
            if (!string.IsNullOrEmpty(queryParams.Geo))
                queryString = string.Concat(queryString, "&geo=", queryParams.Geo);
            if (!string.IsNullOrEmpty(queryParams.Interval))
                queryString = string.Concat(queryString, "&interval=", queryParams.Interval);
            return queryString;            
        }
    }
}
