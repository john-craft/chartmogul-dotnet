using Newtonsoft.Json;
using System.Collections.Generic;

namespace ChartMogul.API.Models.Enrichment
{
    public class CustomerResponseModel
    {
        [JsonProperty(PropertyName = "entries")]
        public List<CustomerModel> Entries { get; set; }

        [JsonProperty(PropertyName = "has_more")]    
        public bool HasMore { get; set; }

        [JsonProperty(PropertyName = "per_page")]
        public int PerPage { get; set; }

        [JsonProperty(PropertyName = "page")]
        public int Page { get; set; }
    }
}
