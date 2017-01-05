using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace ChartMogul.API.Models.Metrics
{
    public class KeyMetricsModel
    {
        [JsonProperty(PropertyName="entries")]
        public List<Entry> Entries { get; set; }
    }

    public class Entry
    {
        [JsonProperty(PropertyName = "date")]
        public DateTime Date { get; set; }

        [JsonProperty(PropertyName = "customer-churn-rate")]
        public decimal CustomerChurnRate { get; set; }

        [JsonProperty(PropertyName = "mrr-churn-rate")]
        public decimal MRRChurnRate { get; set; }

        [JsonProperty(PropertyName = "ltv")]
        public decimal Ltv { get; set; }

        [JsonProperty(PropertyName = "customers")]
        public int Customers { get; set; }

        [JsonProperty(PropertyName = "asp")]
        public int Asp { get; set; }

        [JsonProperty(PropertyName = "arpa")]
        public int Arpa { get; set; }

        [JsonProperty(PropertyName = "arr")]
        public int Arr { get; set; }

        [JsonProperty(PropertyName = "mrr")]
        public int Mrr { get; set; }
    }

}
