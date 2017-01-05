using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace ChartMogul.API.Models.Metrics
{
    public class CustomerLTVEntry
    {
        [JsonProperty(PropertyName = "date")]
        public DateTime Date { get; set; }

        [JsonProperty(PropertyName = "ltv")]
        public decimal LTV { get; set; }
    }

    public class CustomerLTVModel
    {
        [JsonProperty(PropertyName = "entries")]
        public List<CustomerLTVEntry> Entries { get; set; }

        [JsonProperty(PropertyName = "summary")]
        public SummaryModel Summary { get; set; }
    }
}
