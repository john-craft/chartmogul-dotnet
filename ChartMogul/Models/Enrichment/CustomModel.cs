using Newtonsoft.Json;
using System.Collections.Generic;

namespace ChartMogul.API.Models.Enrichment
{
  public class CustomModel
    {
        [JsonProperty(PropertyName = "custom")]
        public Dictionary<string, string> Custom { get; set; }

    }
}
