using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartMogul.API.Models.Enrichment
{
  public class CustomModel
    {   
        public int CAC { get; set; }

        [JsonProperty(PropertyName = "utmCompaign")]
        public string UTMCompaign { get; set; }

        [JsonProperty(PropertyName = "convertedAt")]
        public DateTime ConvertedAt { get; set; }

        [JsonProperty(PropertyName = "pro")]
        public bool Pro { get; set; }
    
        [JsonProperty(PropertyName = "salesRep")]
        public string SalesRep { get; set; }

    }
}
