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
        public DateTime Date { get; set; }

        [JsonProperty(PropertyName = "mrr")]
        public int MRR { get; set; }

        [JsonProperty(PropertyName = "mrr-new-business")]
        public int MrrNewBusiness { get; set; }

        [JsonProperty(PropertyName = "mrr-expansion")]
        public int MrrExpansion { get; set; }

        [JsonProperty(PropertyName = "mrr-contraction")]
        public int MrrContraction { get; set; }

        [JsonProperty(PropertyName = "mrr-churn")]
        public int MrrChurn { get; set; }

        [JsonProperty(PropertyName = "mrr-reactivation")]
        public int MrrReactivation { get; set; }
    }

    public class MRRModel
    {
        [JsonProperty(PropertyName = "entries")]
        public List<MRREntry> Entries { get; set; }

        [JsonProperty(PropertyName = "summary")]
        public Summary Summary { get; set; }
    }
}
