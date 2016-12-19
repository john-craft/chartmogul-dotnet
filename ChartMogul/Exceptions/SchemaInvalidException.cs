using System.Net;

namespace ChartMogul.API.Exceptions
{
    public class SchemaInvalidException
    {
        public SchemaInvalidException(string errorDetails)
        {
            throw new WebException(string.Concat("Request error has occurred.", (!string.IsNullOrEmpty(errorDetails) ? string.Concat("ErrorDetails are:", errorDetails) : ""), (WebExceptionStatus)422));
        }
    }
}
