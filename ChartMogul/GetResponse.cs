using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChartMogul.API
{
    public interface IGetResponse
    {
        WebResponse GetResponseFromServer(HttpWebRequest request);    
    }
    public class GetResponse : IGetResponse
    {        
        public WebResponse GetResponseFromServer(HttpWebRequest request)
        {
            return request.GetResponse();    
        }
    }
}
