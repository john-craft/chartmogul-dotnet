﻿using Newtonsoft.Json;

namespace ChartMogul.API.Models.Enrichment
{
    public class AttributeResponseModel
    {
        [JsonProperty(PropertyName= "attributes")]
        public AttributeModel Attributes { get; set; }
    }
}
