using Newtonsoft.Json;

namespace ChartMogul.API.Models.Enrichment
{
    public class StripeModel
    {
        [JsonProperty(PropertyName = "uid")]
        public string UID { get; set; }

        [JsonProperty(PropertyName = "coupon")]
        public string Coupon { get; set; }
    }
}