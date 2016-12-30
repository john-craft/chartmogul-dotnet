using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChartMogul.API.Models.Enrichment;
using ChartMogul.API.Models.Core;
namespace ChartMogul.API.Enrichment
{
    public interface ICustomer
    {
        CustomerModel UpdateCustomer(CustomerPatchModel customerPatchModel, APIRequest apiRequest, string customerUUID);
        CustomerModel GetCustomerDetails(APIRequest apiRequest, string customerUUID);       
        List<CustomerModel> SearchForCustomer(APIRequest apiRequest, string email);
        void MergeCustomers(APIRequest apiRequest, MergeCustomers mergeCustomers);
        List<CustomerModel> GetAllCustomers(APIRequest apiRequest, CustomerQueryParams queryParams);
    }

    public class Customer : ICustomer
    {
       private IHttp _iHttp;
        public Customer(IHttp iHttp)
        {
            _iHttp = iHttp;
        }
        public CustomerModel UpdateCustomer(CustomerPatchModel customerPatchModel, APIRequest apiRequest,string customerUUID)
        {
            apiRequest.RouteName = string.Concat("customers/",customerUUID);
            _iHttp.ApiRequest = apiRequest;
            var response = _iHttp.Patch<CustomerPatchModel, CustomerModel>(customerPatchModel);
            return response;
        }      

        public CustomerModel GetCustomerDetails(APIRequest apiRequest,string customerUUID)
        {
            apiRequest.RouteName = string.Concat("customers/",customerUUID);
            _iHttp.ApiRequest = apiRequest;
            var response = _iHttp.Get<CustomerModel>();
            return response;
        }


        public List<CustomerModel> GetAllCustomers(APIRequest apiRequest, CustomerQueryParams queryParams)
        {
            var queryString = GenerateQuery(queryParams);
            apiRequest.RouteName = string.Concat("customers", queryString);
            _iHttp.ApiRequest = apiRequest;
            var response = _iHttp.Get<CustomerResponseModel>();
            return response.Entries;
        }

        public List<CustomerModel> SearchForCustomer(APIRequest apiRequest, string email)
        {
            apiRequest.RouteName = string.Concat("customers/search?email="+email);
            _iHttp.ApiRequest = apiRequest;
            var response = _iHttp.Get<CustomerResponseModel>();
            return response.Entries;
        }

        public void MergeCustomers(APIRequest apiRequest, MergeCustomers mergeCustomers)
        {
            apiRequest.RouteName = string.Concat("customers/merges");
            _iHttp.ApiRequest = apiRequest;
            var response = _iHttp.Post<MergeCustomers, MergeCustomers>(mergeCustomers);         
        }

        private string GenerateQuery(CustomerQueryParams queryParams)
        {
            string queryString = string.Empty;           
            if (queryParams != null)
            {             
                if (!string.IsNullOrEmpty(queryParams.DataSourceUUID))
                {                   
                   queryString = string.Concat(queryString.Contains("?")?"&":"?","data_source_uuid=", queryParams.DataSourceUUID);                    
                }
                if (!string.IsNullOrEmpty(queryParams.Status))
                    queryString = string.Concat(queryString, queryString.Contains("?") ? "&" : "?", "status=", queryParams.Status);
                if (!string.IsNullOrEmpty(queryParams.System))
                    queryString = string.Concat(queryString, queryString.Contains("?") ? "&" : "?", "system=", queryParams.System);
                if (!string.IsNullOrEmpty(queryParams.PerPage))
                    queryString = string.Concat(queryString, queryString.Contains("?") ? "&" : "?", "perpage=", queryParams.PerPage);
                if (!string.IsNullOrEmpty(queryParams.Page))
                    queryString = string.Concat(queryString, queryString.Contains("?") ? "&" : "?", "page=", queryParams.Page);
                if (!string.IsNullOrEmpty(queryParams.ExternalId))
                    queryString = string.Concat(queryString, queryString.Contains("?") ? "&" : "?", "external_id=", queryParams.ExternalId);
            }
            return queryString;
        }

    }
}
