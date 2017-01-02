using ChartMogul.API.Models.Core;
using ChartMogul.API.Models.Metrics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartMogul.API.Metrics
{
    public interface IMetrics
    {
        KeyMetricsModel GetAllKeyMetrics(MetricsQueryParams queryParams);
        MRRModel GetMrrForSpecifiedTimePeriod(MetricsQueryParams queryParams);
        ARRModel GetArrForSpecifiedTimePeriod(MetricsQueryParams queryParams);
        ARPAModel GetArpaForSpecifiedTimePeriod(MetricsQueryParams queryParams);
        ASPModel GetASPForSpecifiedTimePeriod(MetricsQueryParams queryParams);
        CustomerCountModel GetCustomerCount(MetricsQueryParams queryParams);
        CustomerChurnRateModel GetCustomerChurnRate(MetricsQueryParams queryParams);
        CustomerLTVModel GetLTV(MetricsQueryParams queryParams);
        CustomerSubscriptionModel GetCustomerSubscriptionDetails(string customerUUID);
        CustomerActivityModel GetCustomerActivities(string customerUUID);
        MRRChurnRateModel GetMRRChurnRate(MetricsQueryParams queryParams);
    }
    public class Metrics:IMetrics
    {      
        IHttp _iHttp;
        public APIRequest ApiRequest { get; set; }
        public Metrics(IHttp iHttp)
        {
            _iHttp = iHttp;
        }

        public KeyMetricsModel GetAllKeyMetrics(MetricsQueryParams queryParams)
        {
            var queryString = GenerateQuery(queryParams);
            ApiRequest.RouteName = string.Concat("metrics/all", queryString);
            _iHttp.ApiRequest = ApiRequest;     
            var response = _iHttp.Get<KeyMetricsModel>();
            return response;
        }

        public MRRModel GetMrrForSpecifiedTimePeriod(MetricsQueryParams queryParams)
        {
            var queryString = GenerateQuery(queryParams);
            ApiRequest.RouteName = string.Concat("metrics/mrr", queryString);
            _iHttp.ApiRequest = ApiRequest;
            var response = _iHttp.Get<MRRModel>();
            return response;
        }

        public ARRModel GetArrForSpecifiedTimePeriod(MetricsQueryParams queryParams)
        {
            var queryString = GenerateQuery(queryParams);
            ApiRequest.RouteName = string.Concat("metrics/arr", queryString);
            _iHttp.ApiRequest = ApiRequest;
            var response = _iHttp.Get<ARRModel>();
            return response;
        }

        public ARPAModel GetArpaForSpecifiedTimePeriod(MetricsQueryParams queryParams)
        {
            var queryString = GenerateQuery(queryParams);
            ApiRequest.RouteName = string.Concat("metrics/arpa", queryString);
            _iHttp.ApiRequest = ApiRequest;
            var response = _iHttp.Get<ARPAModel>();
            return response;
        }

        public ASPModel GetASPForSpecifiedTimePeriod(MetricsQueryParams queryParams)
        {
            var queryString = GenerateQuery(queryParams);
            ApiRequest.RouteName = string.Concat("metrics/asp", queryString);
            _iHttp.ApiRequest = ApiRequest;
            var response = _iHttp.Get<ASPModel>();
            return response;
        }

        public CustomerCountModel GetCustomerCount(MetricsQueryParams queryParams)
        {
            var queryString = GenerateQuery(queryParams);
            ApiRequest.RouteName = string.Concat("metrics/customer-count", queryString);
            _iHttp.ApiRequest = ApiRequest;
            var response = _iHttp.Get<CustomerCountModel>();
            return response;
        }

        public CustomerChurnRateModel GetCustomerChurnRate(MetricsQueryParams queryParams)
        {
            var queryString = GenerateQuery(queryParams);
            ApiRequest.RouteName = string.Concat("metrics/customer-churn-rate", queryString);
            _iHttp.ApiRequest = ApiRequest;
            var response = _iHttp.Get<CustomerChurnRateModel>();
            return response;
        }

        public MRRChurnRateModel GetMRRChurnRate(MetricsQueryParams queryParams)
        {
            var queryString = GenerateQuery(queryParams);
            ApiRequest.RouteName = string.Concat("metrics/mrr-churn-rate", queryString);
            _iHttp.ApiRequest = ApiRequest;
            var response = _iHttp.Get<MRRChurnRateModel>();
            return response;
        }

        public CustomerLTVModel GetLTV(MetricsQueryParams queryParams)
        {
            var queryString = GenerateQuery(queryParams);
            ApiRequest.RouteName = string.Concat("metrics/ltv", queryString);
            _iHttp.ApiRequest = ApiRequest;
            var response = _iHttp.Get<CustomerLTVModel>();
            return response;
        }

        public CustomerSubscriptionModel GetCustomerSubscriptionDetails(string customerUUID)
        {
            ApiRequest.RouteName = string.Concat("customers/",customerUUID, "/subscriptions");
            _iHttp.ApiRequest = ApiRequest;
            var response = _iHttp.Get<CustomerSubscriptionModel>();
            return response;
        }

        public CustomerActivityModel GetCustomerActivities(string customerUUID)
        {
            ApiRequest.RouteName = string.Concat("customers/", customerUUID, "/activities");
            _iHttp.ApiRequest = ApiRequest;
            var response = _iHttp.Get<CustomerActivityModel>();
            return response;
        }

        private string GenerateQuery(MetricsQueryParams queryParams)
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
