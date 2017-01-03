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
        public DateTime Date { get; set; }

        [JsonProperty(PropertyName = "customers")]
        public int Customers { get; set; }
    }

    public class CustomerCountModel
    {
        [JsonProperty(PropertyName = "entries")]
        public List<CustomerCountEntry> Entries { get; set; }

        [JsonProperty(PropertyName = "summary")]
        public SummaryModel Summary { get; set; }
    }
}
