using Newtonsoft.Json;
using OConnors.ChartMogul.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartMogul.API.Models
{
    public class ResponseDataModel<T>
    {
        [JsonProperty(PropertyName = "customers")]
        public T customers { get; set; }
        public T Response { get; set; }
        public int current_page { get; set; }
        public int total_pages { get; set; }
    

    }
}
