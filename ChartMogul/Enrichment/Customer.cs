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
        List<CustomerModel> GetAllCustomers(APIRequest apiRequest);
        List<CustomerModel> SearchForCustomer(APIRequest apiRequest, string email);
        void MergeCustomers(APIRequest apiRequest, MergeCustomers mergeCustomers);
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


        public List<CustomerModel> GetAllCustomers(APIRequest apiRequest)
        {
            apiRequest.RouteName = "customers";
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


    }
}
