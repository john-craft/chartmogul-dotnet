using ChartMogul.API.Models.Core;
using ChartMogul.API.Models.Enrichment;

namespace ChartMogul.API.Enrichment
{
    public interface ITags
    {
        string[] AddTagsToCustomer(string customerUUID, APIRequest apiRequest, string[] tags);
        CustomerResponseModel AddTagsToCustomerWithEmail(string customerUUID, APIRequest apiRequest, CustomerTagModel customerTagDetails);
        string[] RemoveTagsFromCustomer(string customerUUID, APIRequest apiRequest, string[] tags);
    }

    public class Tags : ITags
    {
        private IHttp _iHttp;
        private const string url = "customers{0}/attributes/tags";
        public Tags(IHttp iHttp)
        {
            _iHttp = iHttp;
        }

        public string[] AddTagsToCustomer(string customerUUID, APIRequest apiRequest, string[] tags)
        {
            apiRequest.RouteName = string.Format(url, string.Concat("/", customerUUID));
            _iHttp.ApiRequest = apiRequest;
            var customerTagDetails = new CustomerTagModel();
            customerTagDetails.Tags = tags;
            var response = _iHttp.Post<CustomerTagModel, CustomerTagModel>(customerTagDetails);
            return response.Tags;
        }

        public CustomerResponseModel AddTagsToCustomerWithEmail(string customerUUID, APIRequest apiRequest, CustomerTagModel customerTagDetails)
        {
            apiRequest.RouteName = string.Format(url, "");
            _iHttp.ApiRequest = apiRequest;
            var response = _iHttp.Post<CustomerTagModel, CustomerResponseModel>(customerTagDetails);
            return response;
        }

        public string[] RemoveTagsFromCustomer(string customerUUID, APIRequest apiRequest, string[] tags)
        {
            apiRequest.RouteName = string.Format(url, string.Concat("/", customerUUID));
            _iHttp.ApiRequest = apiRequest;
            var customerTagDetails = new CustomerTagModel();
            customerTagDetails.Tags = tags;
            var response = _iHttp.Delete<CustomerTagModel, CustomerTagModel>(customerTagDetails);
            return response.Tags;
        }
    }
}
