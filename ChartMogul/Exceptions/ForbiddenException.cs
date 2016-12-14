using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChartMogul.API.Exceptions
{
   public class ForbiddenException
    {
        public ForbiddenException()
        {
            throw new WebException("request error has occurred.", (WebExceptionStatus)403);
        }
    }
}
