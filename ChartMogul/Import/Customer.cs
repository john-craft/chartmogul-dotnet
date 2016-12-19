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
        void DeleteCustomer();
      
    }

    public class Customer: AbstractService,ICustomer
    {   
        public Dictionary<string, string> headers;
        public Customer(Http http):base(http)
        {           
        }
        public CustomerModel AddCustomer(CustomerModel customerModel,APIRequest apiRequest)
        {
            apiRequest.RouteName = "import/customers";
            Http.ApiRequest = apiRequest;
            var response =  Http.Post<CustomerModel,CustomerModel>(customerModel);
            return response;
        }

        public void DeleteCustomer()
        {
            throw new NotImplementedException();
        }

        public List<CustomerModel> GetCustomers(APIRequest apiRequest)
        {            
            apiRequest.RouteName = "import/customers";
            Http.ApiRequest = apiRequest;
            var response = Http.Get<CustomerResponseDataModel>();
            return response.Customers;
        }
    }
}
