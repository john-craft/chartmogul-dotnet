using System.Collections.Generic;
using ChartMogul.API.Models.Core;
using ChartMogul.API.Models.Import;

namespace ChartMogul.API.Import
{
    public interface ICustomer
    {
        CustomerModel AddCustomer(CustomerModel customerModel, APIRequest apiRequest);
        List<CustomerModel> GetCustomers(APIRequest apirequest);
        void DeleteCustomer(CustomerModel customerModel, APIRequest apiRequest);
    }

    public class Customer : ICustomer
    {
        public Dictionary<string, string> headers;
        private IHttp _iHttp;
        private const string url = "import/customers{0}";
        public Customer(IHttp iHttp)
        {
            _iHttp = iHttp;
        }
        public CustomerModel AddCustomer(CustomerModel customerModel, APIRequest apiRequest)
        {
            apiRequest.RouteName = string.Format(url,"");
            _iHttp.ApiRequest = apiRequest;
            var response = _iHttp.Post<CustomerModel, CustomerModel>(customerModel);
            return response;
        }

        public void DeleteCustomer(CustomerModel customerModel, APIRequest apiRequest)
        {
            apiRequest.RouteName = string.Format(url,string.Concat("/",customerModel.Uuid));
            _iHttp.ApiRequest = apiRequest;
            _iHttp.Delete();
        }

        public List<CustomerModel> GetCustomers(APIRequest apiRequest)
        {
            apiRequest.RouteName = string.Format(url,"");
            _iHttp.ApiRequest = apiRequest;
            var response = _iHttp.Get<CustomerResponseDataModel>();
            return response.Customers;
        }
    }
}
