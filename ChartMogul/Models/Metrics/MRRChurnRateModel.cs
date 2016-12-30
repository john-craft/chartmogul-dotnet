using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartMogul.API.Models.Metrics
{   
    public class MRRChurnRateEntry
    {
        [JsonProperty(PropertyName = "date")]
        public string Date { get; set; }

        [JsonProperty(PropertyName = "mrr-churn-rate")]
        public string MRRChurnRate { get; set; }
    }

    public class MRRChurnRateModel
    {
        [JsonProperty(PropertyName = "entries")]
        public List<MRRChurnRateEntry> Entries { get; set; }

        [JsonProperty(PropertyName = "summary")]
        public Summary Summary { get; set; }
    }

}
