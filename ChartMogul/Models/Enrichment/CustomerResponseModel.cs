using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartMogul.API.Models.Enrichment
{
    public class CustomerResponseModel
    {
        [JsonProperty(PropertyName = "entries")]
        public List<CustomerModel> Entries { get; set; }

        [JsonProperty(PropertyName = "has_more")]    
        public string HasMore { get; set; }

        [JsonProperty(PropertyName = "per_page")]
        public string PerPage { get; set; }

        [JsonProperty(PropertyName = "page")]
        public string Page { get; set; }
    }
}
