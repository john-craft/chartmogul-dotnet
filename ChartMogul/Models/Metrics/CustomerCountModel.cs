using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartMogul.API.Models.Metrics
{
    public class CustomerCountEntry
    {
        [JsonProperty(PropertyName = "date")]
        public string Date { get; set; }

        [JsonProperty(PropertyName = "customers")]
        public string Customers { get; set; }
    }

    public class CustomerCountModel
    {
        [JsonProperty(PropertyName = "entries")]
        public List<CustomerCountEntry> Entries { get; set; }

        [JsonProperty(PropertyName = "summary")]
        public Summary Summary { get; set; }
    }
}
