using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChartMogul.API.Exceptions
{
   public class UnAuthorizedUserException
    {
        public UnAuthorizedUserException(string errorDetails)
        {
            throw new WebException(string.Concat("Unauthorized.", (!string.IsNullOrEmpty(errorDetails) ? string.Concat("ErrorDetails are:" , errorDetails) : "")), (WebExceptionStatus)401);
        }
    }
}
