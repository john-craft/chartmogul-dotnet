using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChartMogul.API.Exceptions
{
    public class SchemaInvalidException
    {
        public SchemaInvalidException(string errorDetails)
        {
            throw new WebException(string.Concat("request error has occurred.", (!string.IsNullOrEmpty(errorDetails) ? string.Concat("ErrorDetails are:", errorDetails) : ""), (WebExceptionStatus)400));
        }
    }
}
