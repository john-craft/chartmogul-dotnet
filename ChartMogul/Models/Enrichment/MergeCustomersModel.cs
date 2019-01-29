using Newtonsoft.Json;

namespace ChartMogul.API.Models.Enrichment
{
    public class MergeCustomersModel
    {
        [JsonProperty(PropertyName ="from")]
        public From From { get; set; }

        [JsonProperty(PropertyName = "into")]
        public Into Into { get; set; }
    }

    public class From
    {
        [JsonProperty(PropertyName = "customer_uuid")]
        public string CustomerUUID { get; set; }
    }

    public class Into
    {
        [JsonProperty(PropertyName = "customer_uuid")]
        public string CustomerUUID { get; set; }
    }
}

