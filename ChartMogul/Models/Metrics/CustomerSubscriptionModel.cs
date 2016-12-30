using ChartMogul.API.Models.Metrics;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartMogul.API.Models.Metrics
{

    public class CustomerSubscriptionEntry
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "plan")]
        public string Plan { get; set; }

        [JsonProperty(PropertyName = "quantity")]
        public string Quantity { get; set; }

        [JsonProperty(PropertyName = "mrr")]
        public string Mrr { get; set; }

        [JsonProperty(PropertyName = "arr")]
        public string Arr { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "billing-cycle")]
        public string BillingCycle { get; set; }

        [JsonProperty(PropertyName = "billing-cycle-count")]
        public string BillingCycleCount { get; set; }

        [JsonProperty(PropertyName = "start-date")]
        public string StartDate { get; set; }

        [JsonProperty(PropertyName = "end-date")]
        public string EndDate { get; set; }

        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }

        [JsonProperty(PropertyName = "currency-sign")]
        public string CurrencySign { get; set; }
    }

    public class CustomerSubscriptionModel
    {
        [JsonProperty(PropertyName = "entries")]
        public List<CustomerSubscriptionEntry> Entries { get; set; }

        [JsonProperty(PropertyName = "has_more")]
        public string HasMore { get; set; }

        [JsonProperty(PropertyName = "per_page")]
        public string PerPage { get; set; }

        [JsonProperty(PropertyName = "page")]
        public string Page { get; set; }
    }
}
