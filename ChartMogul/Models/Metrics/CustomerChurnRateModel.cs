using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartMogul.API.Models.Metrics
{
    public class CustomerChurnRateEntry
    {
        [JsonProperty(PropertyName = "date")]
        public string Date { get; set; }

        [JsonProperty(PropertyName = "customer-churn-rate")]
        public string CustomerChurnRate { get; set; }
    }

    public class CustomerChurnRateModel
    {
        [JsonProperty(PropertyName = "entries")]
        public List<CustomerChurnRateEntry> Entries { get; set; }

        [JsonProperty(PropertyName = "summary")]
        public Summary Summary { get; set; }
    }
}
