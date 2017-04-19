using Newtonsoft.Json;
using System;

namespace ChartMogul.API.Models.Import
{
    public class LineItemModel
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "subscription_external_id")]
        public string SubscriptionExternalId { get; set; }

        [JsonProperty(PropertyName = "plan_uuid")]
        public string PlanId { get; set; }

        [JsonProperty(PropertyName = "service_period_start")]
        public DateTime SubscriptionStart { get; set; }

        [JsonProperty(PropertyName = "service_period_end")]
        public DateTime SubscriptionEnd { get; set; }

        [JsonProperty(PropertyName = "amount_in_cents")]
        public int Amount { get; set; }

        [JsonProperty(PropertyName = "cancelled_at")]
        public DateTime? CancellationDate { get; set; }

        [JsonProperty(PropertyName = "prorated")]
        public bool ProRated { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "quantity")]
        public int Quantity { get; set; }

        [JsonProperty(PropertyName = "discount_code")]
        public string DiscountCode { get; set; }

        [JsonProperty(PropertyName = "discount_amount_in_cents")]
        public int DiscountAmount { get; set; }

        [JsonProperty(PropertyName = "tax_amount_in_cents")]
        public int TaxAmount { get; set; }

        [JsonProperty(PropertyName = "external_id")]
        public string ExternalId { get; set; }
    }
}
