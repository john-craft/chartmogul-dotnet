using ChartMogul.API.Models.Core;
using ChartMogul.API.Models.Enrichment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartMogul.API.Enrichment
{
    public interface ICustomerAttribute
    {
        CustomerTag GetCustomerAttribute(string customerUUID, APIRequest apiRequest);
    }
    public class CustomerAttribute: ICustomerAttribute
    {
        private IHttp _iHttp;
        public CustomerAttribute(IHttp iHttp)
        {
            _iHttp = iHttp;
        }

        public CustomerTag GetCustomerAttribute(string customerUUID, APIRequest apiRequest)
        {
            apiRequest.RouteName = string.Concat("customers/",customerUUID,"/attributes");
            _iHttp.ApiRequest = apiRequest;
            var response = _iHttp.Get<CustomerTag>();
            return response;
        }
    }
}
