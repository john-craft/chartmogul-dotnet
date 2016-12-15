using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OConnors.ChartMogul.API.Models;
using ChartMogul.API.Common;
using ChartMogul.API.Models.Core;

namespace ChartMogul.API.Import
{

    public interface ICustomer
    {
        CustomerModel AddCustomer(APIRequest customerModel);
        List<CustomerModel> GetCustomers(APIRequest apirequest);
        void DeleteCustomer();
      
    }

    public class Customer: ICustomer
    {
        private IChartMogulCore _chartMogulCore;
        public Customer(IChartMogulCore chartMogulCore)
        {
            _chartMogulCore = chartMogulCore;
        }
        public CustomerModel AddCustomer(APIRequest customerModel)
        {     
            var temp = _chartMogulCore.CallApi(customerModel);
            return new CustomerModel();
        }

        public void DeleteCustomer()
        {
            throw new NotImplementedException();
        }

        public List<CustomerModel> GetCustomers(APIRequest apiRequest)
        {
            apiRequest.URLPath = "import/customers";
            apiRequest.HttpMethod = "get";
            var temp = _chartMogulCore.CallApi(apiRequest);
            return null;
        }
    }
}
