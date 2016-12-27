using Newtonsoft.Json;

namespace ChartMogul.API.Models.Enrichment
{
    public class CustomerPatchModel
    {
        public CustomerPatchModel()
        {
            LeadCreatedAt =  string.Empty;
            FreeTrialStartedAt = string.Empty;
            City = string.Empty;
            Country = string.Empty;
            State = string.Empty;           
        }             
        [JsonProperty(PropertyName = "lead_created_at")]
        public string LeadCreatedAt { get; set; }

        [JsonProperty(PropertyName = "free_trial_started_at")]
        public string FreeTrialStartedAt { get; set; }

        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }

        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }
        
        [JsonProperty(PropertyName = "attributes")]
        public Attribute Attributes { get; set; }                   
}
}
