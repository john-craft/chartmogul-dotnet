using System.Collections.Generic;
using ChartMogul.API.Models.Enrichment;
using ChartMogul.API.Models.Core;

namespace ChartMogul.API.Enrichment
{
    public interface ICustomer
    {
        CustomerModel UpdateCustomer(CustomerPatchModel customerPatchModel, APIRequest apiRequest, string customerUUID);
        CustomerModel GetCustomerDetails(APIRequest apiRequest, string customerUUID);
        List<CustomerModel> SearchForCustomer(APIRequest apiRequest, string email);
        void MergeCustomers(APIRequest apiRequest, MergeCustomersModel mergeCustomers);
        List<CustomerModel> GetAllCustomers(APIRequest apiRequest, CustomerQueryParamsModel queryParams);
    }

    public class Customer : ICustomer
    {
        private IHttp _iHttp;
        private const string mergeCustomerUrl = "customers/merges";
        private const string searchCustomerUrl = "customers/search?email=";
        private const string customerUrl = "customers";
        public Customer(IHttp iHttp)
        {
            _iHttp = iHttp;
        }

        public CustomerModel UpdateCustomer(CustomerPatchModel customerPatchModel, APIRequest apiRequest, string customerUUID)
        {
            apiRequest.RouteName = string.Concat(customerUrl, "/", customerUUID);
            _iHttp.ApiRequest = apiRequest;
            var response = _iHttp.Patch<CustomerPatchModel, CustomerModel>(customerPatchModel);
            return response;
        }

        public CustomerModel GetCustomerDetails(APIRequest apiRequest, string customerUUID)
        {
            apiRequest.RouteName = string.Concat(customerUrl, "/", customerUUID);
            _iHttp.ApiRequest = apiRequest;
            var response = _iHttp.Get<CustomerModel>();
            return response;
        }

        public List<CustomerModel> GetAllCustomers(APIRequest apiRequest, CustomerQueryParamsModel queryParams)
        {
            var queryString = GenerateQuery(queryParams);
            apiRequest.RouteName = string.Concat(customerUrl, queryString);
            _iHttp.ApiRequest = apiRequest;
            var response = _iHttp.Get<CustomerResponseModel>();
            return response.Entries;
        }

        public List<CustomerModel> SearchForCustomer(APIRequest apiRequest, string email)
        {
            apiRequest.RouteName = string.Concat(searchCustomerUrl, email);
            _iHttp.ApiRequest = apiRequest;
            var response = _iHttp.Get<CustomerResponseModel>();
            return response.Entries;
        }

        public void MergeCustomers(APIRequest apiRequest, MergeCustomersModel mergeCustomers)
        {
            apiRequest.RouteName = string.Concat(mergeCustomerUrl);
            _iHttp.ApiRequest = apiRequest;
            var response = _iHttp.Post<MergeCustomersModel, MergeCustomersModel>(mergeCustomers);
        }

        private string GenerateQuery(CustomerQueryParamsModel queryParams)
        {
            string queryString = string.Empty;
            if (queryParams != null)
            {
                if (!string.IsNullOrEmpty(queryParams.DataSourceUUID))
                {
                    queryString = string.Concat(FormatQueryString(queryString), "data_source_uuid=", queryParams.DataSourceUUID);
                }
                if (!string.IsNullOrEmpty(queryParams.Status))
                    queryString = string.Concat(queryString, FormatQueryString(queryString), queryParams.Status);
                if (!string.IsNullOrEmpty(queryParams.System))
                    queryString = string.Concat(queryString, FormatQueryString(queryString), "system=", queryParams.System);
                if (!string.IsNullOrEmpty(queryParams.PerPage))
                    queryString = string.Concat(queryString, FormatQueryString(queryString), "perpage=", queryParams.PerPage);
                if (!string.IsNullOrEmpty(queryParams.Page))
                    queryString = string.Concat(queryString, FormatQueryString(queryString), "page=", queryParams.Page);
                if (!string.IsNullOrEmpty(queryParams.ExternalId))
                    queryString = string.Concat(queryString, FormatQueryString(queryString), "external_id=", queryParams.ExternalId);
            }
            return queryString;
        }

        public string FormatQueryString(string queryString)
        {
            return queryString.Contains("?") ? "&" : "?";
        }
    }
}
