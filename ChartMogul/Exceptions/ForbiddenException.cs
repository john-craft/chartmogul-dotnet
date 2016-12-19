using System.Net;

namespace ChartMogul.API.Exceptions
{
   public class ForbiddenException
    {
        public ForbiddenException(string errorDetails)
        {
            throw new WebException(string.Concat("Request error has occurred.",(!string.IsNullOrEmpty(errorDetails) ? string.Concat("ErrorDetails are:", errorDetails) : "")), (WebExceptionStatus)403);
        }
    }
}
