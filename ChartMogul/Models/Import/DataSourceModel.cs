﻿using Newtonsoft.Json;
using System;

namespace ChartMogul.API.Models.Import
{
    public class DataSourceModel
    {
        [JsonProperty(PropertyName = "uuid")]
        public string Uuid { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "created_at")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    }
}
