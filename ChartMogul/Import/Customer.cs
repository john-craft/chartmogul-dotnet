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

    public class Customer: AbstractService,ICustomer
    {
        private IChartMogulCore _chartMogulCore;
        public Customer(IChartMogulCore chartMogulCore, Http http):base(http)
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
        //    apiRequest.URLPath = "import/customers";
        //apiRequest.HttpMethod = "get";
           // var temp = _chartMogulCore.CallApi(apiRequest);
            return Http.Get<List<CustomerModel>>(String.Format("{0}/import/customers", "https://api.chartmogul.com/v1"));

            return null;
        }
    }
}
