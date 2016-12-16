using System;
using System.Runtime.Serialization;

namespace ChartMogul.API.Models
{
    [DataContract, Serializable]
    public class ApiError
    {
        [DataMember]
        public int httpStatusCode { get; set; }

        [DataMember]
        public string customCode { get; set; }

        [DataMember]
        public string message { get; set; }

        [DataMember]
        public string description { get; set; }

        [DataMember]
        public string errorHelpUrl { get; set; }

        [DataMember]
        public string originalRequest { get; set; }
    }
}
