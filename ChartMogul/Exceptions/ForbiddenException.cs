using System.Net;

namespace ChartMogul.API.Exceptions
{
    public class ForbiddenException : WebException
    {
        public ForbiddenException(string errorDetails) : base(string.Concat("Request error has occurred.", (!string.IsNullOrEmpty(errorDetails) ? string.Concat("ErrorDetails are:", errorDetails) : "")), (WebExceptionStatus)403)
        {
        }
    }
}
