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
        List<CustomerModel> GetCustomers(APIRequest apirequest);
        void DeleteCustomer();
        APIRequest ApiRequest { get; set; }
     }



    public class Customer : ChartMogulCore,ICustomer
    {

      
        public CustomerModel AddCustomer(CustomerModel customerModel)
        {
            throw new NotImplementedException();
        }

        public void DeleteCustomer()
        {
            throw new NotImplementedException();
        }

        public List<CustomerModel> GetCustomers(APIRequest apiRequest)
        {
            apiRequest.URLPath = "import/customers";
            var temp= CallApi(apiRequest);
            return null;

        }
       

    }
}
