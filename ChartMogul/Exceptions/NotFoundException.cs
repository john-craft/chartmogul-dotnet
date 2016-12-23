using System.Net;

namespace ChartMogul.API.Exceptions
{
    public class NotFoundException : WebException
    {
        public NotFoundException(string errorDetails):base(string.Concat("The requested could not be found.", (!string.IsNullOrEmpty(errorDetails) ? string.Concat("ErrorDetails are:", errorDetails) : "")), (WebExceptionStatus)404)
        {
        }
    }
}
