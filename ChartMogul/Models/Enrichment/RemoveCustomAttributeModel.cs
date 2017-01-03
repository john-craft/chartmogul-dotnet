using Newtonsoft.Json;

namespace ChartMogul.API.Models.Enrichment
{
    public class RemoveCustomAttributeModel
    {
        [JsonProperty(PropertyName ="custom")]
        public string[] Custom { get; set; }
    }
}
