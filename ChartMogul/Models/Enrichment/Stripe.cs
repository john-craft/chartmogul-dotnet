using Newtonsoft.Json;

namespace ChartMogul.API.Models.Enrichment
{
    public class Stripe
    {
        [JsonProperty(PropertyName = "uid")]
        public string UID { get; set; }

        [JsonProperty(PropertyName = "coupon")]
        public string Coupon { get; set; }
    }
}