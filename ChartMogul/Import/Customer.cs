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
        CustomerModel AddCustomer(CustomerModel customerModel);
        List<CustomerModel> GetCustomers();
        void DeleteCustomer();
        APIRequest ApiRequest { get; set; }
    }



    public class Customer : ICustomer
    {

        public APIRequest ApiRequest { get; set; }
        private IChartMogulCore _icharmogulCore;

        Customer( IChartMogulCore ichartMogulcore)
        {
            _icharmogulCore = ichartMogulcore;
        }

        public CustomerModel AddCustomer(CustomerModel customerModel)
        {
            throw new NotImplementedException();
        }

        public void DeleteCustomer()
        {
            throw new NotImplementedException();
        }

        public List<CustomerModel> GetCustomers()
        {
            throw new NotImplementedException();
           // _icharmogulCore.CallApi()
        }
       

    }
}
