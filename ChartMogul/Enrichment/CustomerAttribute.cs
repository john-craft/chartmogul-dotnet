using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartMogul.API.Enrichment
{
    public interface ICustomerAttribute
    {  
    }
    public class CustomerAttribute: ICustomerAttribute
    {
        private IHttp _iHttp;
        public CustomerAttribute(IHttp iHttp)
        {
            _iHttp = iHttp;
        }


    }
}
