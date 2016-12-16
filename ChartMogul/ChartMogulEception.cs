using ChartMogul.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartMogul.API
{
   public class ChartMogulException : Exception
    {
        /// <summary>
        /// Details of the API error
        /// </summary>
        public ApiError apiError { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public ChartMogulException(string message) : this(null, message)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public ChartMogulException(ApiError error, string message) : base(message)
        {
            apiError = error;
        }
    }
}
