using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartMogul.API.Models.Enrichment
{
    public class MergeCustomers
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

