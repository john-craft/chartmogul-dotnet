using System.Net;

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
