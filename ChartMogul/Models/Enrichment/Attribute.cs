using Newtonsoft.Json;
using System.Collections.Generic;

namespace ChartMogul.API.Models.Enrichment
{
    public class Attribute
    {
        [JsonProperty(PropertyName = "tags")]
        public string[] Tags { get; set; }

        [JsonProperty(PropertyName = "custom")]
        public Dictionary<string,string> Custom { get; set; }

        [JsonProperty(PropertyName = "stripe")]
        public Stripe Stripe { get; set; }

        [JsonProperty(PropertyName = "clearbit")]
        public Clearbit Clearbit { get; set; }

    }
}
