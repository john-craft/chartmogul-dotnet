using Newtonsoft.Json;

namespace ChartMogul.API.Models.Enrichment
{
    public class CustomerModel
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "uuid")]
        public string Uuid { get; set; }

        [JsonProperty(PropertyName = "external_id")]
        public string ExternalId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "customer-since")]
        public string CustomerSince { get; set; }

        [JsonProperty(PropertyName = "attributes")]
        public AttributeModel Attributes { get; set; }

        [JsonProperty(PropertyName = "address")]
        public CustomerAddressModel Address { get; set; }

        [JsonProperty(PropertyName = "mrr")]
        public int MRR { get; set; }

        [JsonProperty(PropertyName = "arr")]
        public int ARR { get; set; }

        [JsonProperty(PropertyName = "billing-system-url")]
        public string BillingSystemUrl { get; set; }

        [JsonProperty(PropertyName = "chartmogul-url")]
        public string ChartMogulUrl { get; set; }

        [JsonProperty(PropertyName = "billing-system-type")]
        public string BillingSystemType { get; set; }

        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }

        [JsonProperty(PropertyName = "currency-sign")]
        public string CurrencySign { get; set; }


    }
}
