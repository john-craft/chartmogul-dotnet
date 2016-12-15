using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChartMogul.API.Exceptions
{
    public class NotFoundException
    {
        public NotFoundException(string errorDetails)
        {
            throw new WebException(string.Concat("The requested could not be found.", (!string.IsNullOrEmpty(errorDetails) ? string.Concat("ErrorDetails are:",errorDetails) : "")), (WebExceptionStatus)404);
        }
    }
}
