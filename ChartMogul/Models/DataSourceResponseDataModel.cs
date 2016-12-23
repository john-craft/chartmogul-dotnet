using Newtonsoft.Json;
using OConnors.ChartMogul.API.Models;
using System;
using System.Collections.Generic;


namespace ChartMogul.API.Models
{
  public class DataSourceResponseDataModel
    {
        [JsonProperty(PropertyName = "data_sources")]
        public List<DataSourceModel> DataSources { get; set; }
    }
}
