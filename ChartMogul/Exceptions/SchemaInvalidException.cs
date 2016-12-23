using System.Net;

namespace ChartMogul.API.Exceptions
{
    public class SchemaInvalidException : WebException
    {
        public SchemaInvalidException(string errorDetails) : base(string.Concat("Request error has occurred.", (!string.IsNullOrEmpty(errorDetails) ? string.Concat("ErrorDetails are:", errorDetails) : ""), (WebExceptionStatus)422))
        {
        }
    }
}
