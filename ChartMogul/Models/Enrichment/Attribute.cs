using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
