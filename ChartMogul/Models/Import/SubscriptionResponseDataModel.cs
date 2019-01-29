using Newtonsoft.Json;
using System.Collections.Generic;

namespace ChartMogul.API.Models.Import
{
    public class SubscriptionResponseDataModel
    {
        [JsonProperty(PropertyName = "subscriptions")]
        public List<SubscriptionModel> Subscriptions { get; set; }

        [JsonProperty(PropertyName = "current_page")]
        public int Current_Page { get; set; }

        [JsonProperty(PropertyName = "total_pages")]
        public int Total_Pages { get; set; }
    }
}
