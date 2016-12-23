using System.Net;

namespace ChartMogul.API.Exceptions
{
    public class UnAuthorizedUserException : WebException
    {
        public UnAuthorizedUserException(string errorDetails) : base(string.Concat("Unauthorized.", (!string.IsNullOrEmpty(errorDetails) ? string.Concat("ErrorDetails are:", errorDetails) : "")), (WebExceptionStatus)401)
        {
        }
    }
}
