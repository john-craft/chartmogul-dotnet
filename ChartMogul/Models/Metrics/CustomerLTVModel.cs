using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartMogul.API.Models.Metrics
{
    public class CustomerLTVEntry
    {
        [JsonProperty(PropertyName = "date")]
        public string Date { get; set; }

        [JsonProperty(PropertyName = "ltv")]
        public string LTV { get; set; }
    }

    public class CustomerLTVModel
    {
        [JsonProperty(PropertyName = "entries")]
        public List<CustomerLTVEntry> Entries { get; set; }

        [JsonProperty(PropertyName = "summary")]
        public Summary Summary { get; set; }
    }
}
