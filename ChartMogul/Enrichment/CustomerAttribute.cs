using ChartMogul.API.Models.Core;
using ChartMogul.API.Models.Enrichment;

namespace ChartMogul.API.Enrichment
{
    public interface ICustomerAttribute
    {
        CustomerTagModel GetCustomerAttribute(string customerUUID, APIRequest apiRequest);
    }

    public class CustomerAttribute : ICustomerAttribute
    {
        private IHttp _iHttp;
        private string customerAttributeUrl = "customers/{0}/attributes";
        public CustomerAttribute(IHttp iHttp)
        {
            _iHttp = iHttp;
        }

        public CustomerTagModel GetCustomerAttribute(string customerUUID, APIRequest apiRequest)
        {
            apiRequest.RouteName = string.Format(customerAttributeUrl, customerUUID);
            _iHttp.ApiRequest = apiRequest;
            var response = _iHttp.Get<CustomerTagModel>();
            return response;
        }
    }
}
