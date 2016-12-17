using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OConnors.ChartMogul.API.Models;
using ChartMogul.API.Common;
using ChartMogul.API.Models.Core;
using ChartMogul.API.Models;

namespace ChartMogul.API.Import
{

    public interface ICustomer
    {
        CustomerModel AddCustomer(CustomerModel customerModel);
        List<CustomerModel> GetCustomers(APIRequest apirequest);
        void DeleteCustomer();
      
    }

    public class Customer: AbstractService,ICustomer
    {
        private IChartMogulCore _chartMogulCore;
        private readonly string _baseUrl;
        public Customer(IChartMogulCore chartMogulCore, Http http):base(http)
        {
            _chartMogulCore = chartMogulCore;
            _baseUrl = Configuration.BaseUrl;
        }
        public CustomerModel AddCustomer(CustomerModel customerModel)
        {            
            var response =  Http.Post<CustomerModel,CustomerModel>(String.Format("{0}/import/customers", _baseUrl), customerModel);
          //  var temp = _chartMogulCore.CallApi(customerModel);
            return response;
        }

        public void DeleteCustomer()
        {
            throw new NotImplementedException();
        }

        public List<CustomerModel> GetCustomers(APIRequest apiRequest)
        {
        //    apiRequest.URLPath = "import/customers";
        //apiRequest.HttpMethod = "get";
           // var temp = _chartMogulCore.CallApi(apiRequest);
            var response = Http.Get<CustomerResponseDataModel>(String.Format("{0}/import/customers", _baseUrl));
            return response.customers;
        }
    }
}
