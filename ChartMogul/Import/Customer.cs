using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private readonly string _baseUrl;
        public Dictionary<string, string> headers;
        public Customer(Http http):base(http)
        {
            _baseUrl = Configuration.BaseUrl;              
        }
        public CustomerModel AddCustomer(CustomerModel customerModel,APIRequest apiRequest)
        {            
            var response =  Http.Post<CustomerModel,CustomerModel>(String.Format("{0}/import/customers", _baseUrl), customerModel, apiRequest);
            return response;
        }

        public void DeleteCustomer()
        {
            throw new NotImplementedException();
        }

        public List<CustomerModel> GetCustomers(APIRequest apiRequest)
        {
            var response = Http.Get<CustomerResponseDataModel>(String.Format("{0}/import/customers", _baseUrl), apiRequest);
            return response.customers;
        }
    }
}
