using Newtonsoft.Json;
using System;

namespace ChartMogul.API.Models.Import
{
    public class SubscriptionModel
    {
        [JsonProperty(PropertyName = "uuid")]
        public string Uuid { get; set; }

        [JsonProperty(PropertyName = "external_id")]
        public string ExternalId { get; set; }

        [JsonProperty(PropertyName = "customer_uuid")]
        public string CustomerId { get; set; }

        [JsonProperty(PropertyName = "plan_uuid")]
        public string PlanId { get; set; }

        [JsonProperty(PropertyName = "data_source_uuid")]
        public string DataSource { get; set; }

        [JsonProperty(PropertyName = "cancellation_dates")]
        public DateTime[] CancellationDates { get; set; }
    }
}
