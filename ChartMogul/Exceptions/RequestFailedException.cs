using System.Net;

namespace ChartMogul.API.Exceptions
{
    public class RequestFailedException
    {
      
       public RequestFailedException(string errorDetails)
        {
            throw new WebException(string.Concat("The requested could not be found.", (!string.IsNullOrEmpty(errorDetails) ? string.Concat("ErrorDetails are:",errorDetails):"")), (WebExceptionStatus)404);
        }    
    }
}