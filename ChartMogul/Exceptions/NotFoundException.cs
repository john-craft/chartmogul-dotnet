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
        public NotFoundException()
        {
            throw new WebException("The requested could not be found.", (WebExceptionStatus)404);
        }
    }
}
