using System.Net;

namespace ChartMogul.API.Exceptions
{
  public  class ChartMogulException
    {
        public ChartMogulException(string errorDetails)
        {
            throw new WebException(string.Concat("Request error has occurred.",(!string.IsNullOrEmpty(errorDetails) ? string.Concat("ErrorDetails are:", errorDetails) : ""), (WebExceptionStatus)400));
        }
    }
}
