using Newtonsoft.Json;
using System.Collections.Generic;


namespace ChartMogul.API.Models.Import
{
    public class CustomerResponseDataModel
    {
        [JsonProperty(PropertyName = "customers")]
        public List<CustomerModel> Customers { get; set; }

        [JsonProperty(PropertyName = "current_page")]
        public int Current_Page { get; set; }

        [JsonProperty(PropertyName = "total_pages")]
        public int Total_Pages { get; set; }
    }
}
