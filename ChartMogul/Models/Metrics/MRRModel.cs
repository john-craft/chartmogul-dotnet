using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartMogul.API.Models.Metrics
{
    public class MRREntry
    {
        [JsonProperty(PropertyName = "date")]
        public string Date { get; set; }

        [JsonProperty(PropertyName = "mrr")]
        public string MRR { get; set; }

        [JsonProperty(PropertyName = "mrr-new-business")]
        public string MrrNewBusiness { get; set; }

        [JsonProperty(PropertyName = "mrr-expansion")]
        public string MrrExpansion { get; set; }

        [JsonProperty(PropertyName = "mrr-contraction")]
        public string MrrContraction { get; set; }

        [JsonProperty(PropertyName = "mrr-churn")]
        public string MrrChurn { get; set; }

        [JsonProperty(PropertyName = "mrr-reactivation")]
        public string MrrReactivation { get; set; }
    }

    public class MRRModel
    {
        [JsonProperty(PropertyName = "entries")]
        public List<MRREntry> Entries { get; set; }

        [JsonProperty(PropertyName = "summary")]
        public Summary Summary { get; set; }
    }
}
