using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChartMogul.API.Common
{
    public interface IWebCall
    {
        WebResponse DownloadResponse(HttpWebRequest request);
    }
    public class WebCall : IWebCall
    {
        public WebResponse DownloadResponse(HttpWebRequest request)
        {
            return request.GetResponse();
        }
    }
}
