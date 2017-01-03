using Newtonsoft.Json;
using System;

namespace ChartMogul.API.Models.Import
{
    public class TransactionModel
    {
        [JsonProperty(PropertyName = "date")]
        public DateTime Date { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "result")]
        public string Result { get; set; }

        [JsonProperty(PropertyName = "external_id")]
        public string ExternalId { get; set; }
    }
}
