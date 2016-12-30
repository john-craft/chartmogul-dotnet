using ChartMogul.API.Models.Metrics;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartMogul.API.Models.Metrics
{
    public class CustomerActivityModelEntry
    {
        [JsonProperty(PropertyName = "activity-arr")]
        public string ActivityArr { get; set; }
        [JsonProperty(PropertyName = "activity-mrr")]
        public string ActivityMrr { get; set; }
        [JsonProperty(PropertyName = "activity-mrr-movement")]
        public string ActivityMrrMovement { get; set; }
        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }
        [JsonProperty(PropertyName = "currency-sign")]
        public string CurrencySign { get; set; }
        [JsonProperty(PropertyName = "date")]
        public string Date { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
    }

    public class CustomerActivityModel
    {
        [JsonProperty(PropertyName = "entries")]
        public List<CustomerActivityModelEntry> Entries { get; set; }
        [JsonProperty(PropertyName = "has_more")]
        public string HasMore { get; set; }
        [JsonProperty(PropertyName = "per_page")]
        public string PerPage { get; set; }
        [JsonProperty(PropertyName = "page")]
        public string Page { get; set; }
    }
}
