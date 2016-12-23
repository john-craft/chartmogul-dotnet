using System;
using System.Collections.Generic;
using OConnors.ChartMogul.API.Models;
using ChartMogul.API.Models.Core;
using ChartMogul.API.Models;

namespace ChartMogul.API.Import
{

    public interface ICustomer
    {
        CustomerModel AddCustomer(CustomerModel customerModel,APIRequest apiRequest);
        List<CustomerModel> GetCustomers(APIRequest apirequest);
        void DeleteCustomer(CustomerModel customerModel, APIRequest apiRequest);


    }

    public class Customer: ICustomer
    {   
        public Dictionary<string, string> headers;
        private IHttp _iHttp;
        public Customer(IHttp iHttp)
        {
            _iHttp = iHttp;       
        }
        public CustomerModel AddCustomer(CustomerModel customerModel,APIRequest apiRequest)
        {
            apiRequest.RouteName = "import/customers";
            _iHttp.ApiRequest = apiRequest;
            var response = _iHttp.Post<CustomerModel,CustomerModel>(customerModel);
            return response;
        }

        public void DeleteCustomer(CustomerModel customerModel, APIRequest apiRequest)
        {
            apiRequest.RouteName = "import/customers/" + customerModel.Uuid;
            _iHttp.ApiRequest = apiRequest;
            _iHttp.Delete();
        }

        public List<CustomerModel> GetCustomers(APIRequest apiRequest)
        {            
            apiRequest.RouteName = "import/customers";
            _iHttp.ApiRequest = apiRequest;
            var response = _iHttp.Get<CustomerResponseDataModel>();
            return response.Customers;
        }
    }
}
