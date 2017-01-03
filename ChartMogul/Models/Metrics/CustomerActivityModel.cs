using Newtonsoft.Json;
using System.Collections.Generic;


namespace ChartMogul.API.Models.Metrics
{
    public class CustomerActivityModelEntry
    {
        [JsonProperty(PropertyName = "activity-arr")]
        public int ActivityArr { get; set; }
        [JsonProperty(PropertyName = "activity-mrr")]
        public int ActivityMrr { get; set; }
        [JsonProperty(PropertyName = "activity-mrr-movement")]
        public int ActivityMrrMovement { get; set; }
        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }
        [JsonProperty(PropertyName = "currency-sign")]
        public string CurrencySign { get; set; }
        [JsonProperty(PropertyName = "date")]
        public string Date { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
    }

    public class CustomerActivityModel
    {
        [JsonProperty(PropertyName = "entries")]
        public List<CustomerActivityModelEntry> Entries { get; set; }
        [JsonProperty(PropertyName = "has_more")]
        public bool HasMore { get; set; }
        [JsonProperty(PropertyName = "per_page")]
        public int PerPage { get; set; }
        [JsonProperty(PropertyName = "page")]
        public int Page { get; set; }
    }
}
