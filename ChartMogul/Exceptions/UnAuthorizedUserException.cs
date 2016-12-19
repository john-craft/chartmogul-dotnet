using System.Net;

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
