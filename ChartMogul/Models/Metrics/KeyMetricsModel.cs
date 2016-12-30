using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string Date { get; set; }

        [JsonProperty(PropertyName = "customer-churn-rate")]
        public string CustomerChurnRate { get; set; }

        [JsonProperty(PropertyName = "mrr-churn-rate")]
        public string MRRChurnRate { get; set; }

        [JsonProperty(PropertyName = "ltv")]
        public string Ltv { get; set; }

        [JsonProperty(PropertyName = "customers")]
        public string Customers { get; set; }

        [JsonProperty(PropertyName = "asp")]
        public string Asp { get; set; }

        [JsonProperty(PropertyName = "arpa")]
        public string Arpa { get; set; }

        [JsonProperty(PropertyName = "arr")]
        public string Arr { get; set; }

        [JsonProperty(PropertyName = "mrr")]
        public string Mrr { get; set; }
    }

}
