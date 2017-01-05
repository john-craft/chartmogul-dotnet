using Newtonsoft.Json;
using System.Collections.Generic;

namespace ChartMogul.API.Models.Enrichment
{
    public class AttributeModel
    {
        [JsonProperty(PropertyName = "tags")]
        public string[] Tags { get; set; }

        [JsonProperty(PropertyName = "custom")]
        public Dictionary<string,string> Custom { get; set; }

        [JsonProperty(PropertyName = "stripe")]
        public StripeModel Stripe { get; set; }

        [JsonProperty(PropertyName = "clearbit")]
        public ClearbitModel Clearbit { get; set; }

    }
}
