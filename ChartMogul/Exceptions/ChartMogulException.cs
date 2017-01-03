using System.Net;

namespace ChartMogul.API.Exceptions
{
    public class ChartMogulException : WebException
    {
        public ChartMogulException(string errorDetails) : base(string.Concat("Request error has occurred.", (!string.IsNullOrEmpty(errorDetails) ? string.Concat("ErrorDetails are:", errorDetails) : string.Empty), (WebExceptionStatus)400))
        {
        }
    }
}
