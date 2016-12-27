using ChartMogul.API.Models.Core;
using ChartMogul.API.Models.Enrichment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartMogul.API.Enrichment
{
    public interface ITags
    {
        string[] AddTagsToCustomer(string customerUUID, APIRequest apiRequest, string[] tags);
        CustomerResponseModel AddTagsToCustomerWithEmail(string customerUUID, APIRequest apiRequest, CustomerTag customerTagDetails);
        string[] RemoveTagsFromCustomer(string customerUUID, APIRequest apiRequest, string[] tags);
    }

    public class Tags: ITags
    {
        private IHttp _iHttp;
        public Tags(IHttp iHttp)
        {
            _iHttp = iHttp;
        }

       public string[] AddTagsToCustomer(string customerUUID, APIRequest apiRequest,string[] tags)
        {  
            apiRequest.RouteName = string.Concat("customers/", customerUUID, "/attributes/tags");
            _iHttp.ApiRequest = apiRequest;
            var customerTagDetails = new CustomerTag();
            customerTagDetails.Tags = tags;
            var response = _iHttp.Post<CustomerTag,CustomerTag>(customerTagDetails);
            return response.Tags;        
      }

       public CustomerResponseModel AddTagsToCustomerWithEmail(string customerUUID, APIRequest apiRequest, CustomerTag customerTagDetails)
        {
            apiRequest.RouteName = "customers/attributes/tags";
            _iHttp.ApiRequest = apiRequest;      
            var response = _iHttp.Post<CustomerTag, CustomerResponseModel>(customerTagDetails);
            return response;
        }

        public string[] RemoveTagsFromCustomer(string customerUUID, APIRequest apiRequest, string[] tags)
        {
            apiRequest.RouteName = string.Concat("customers/", customerUUID, "/attributes/tags");
            _iHttp.ApiRequest = apiRequest;
            var customerTagDetails = new CustomerTag();
            customerTagDetails.Tags = tags;
            var response = _iHttp.Delete<CustomerTag, CustomerTag>(customerTagDetails);
            return response.Tags;
        }
    }
}
