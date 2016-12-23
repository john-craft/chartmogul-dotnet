using Newtonsoft.Json;
using OConnors.ChartMogul.API.Models;
using System.Collections.Generic;


namespace ChartMogul.API.Models
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
