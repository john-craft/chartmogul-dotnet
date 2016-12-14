using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChartMogul.API.Exceptions
{
  public  class ChartMogulException
    {
        public ChartMogulException()
        {
            throw new WebException("request error has occurred.", (WebExceptionStatus)400);
        }
    }
}
