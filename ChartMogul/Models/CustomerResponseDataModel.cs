using Newtonsoft.Json;
using OConnors.ChartMogul.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartMogul.API.Models
{
    public class CustomerResponseDataModel
    {             
        public List<CustomerModel> customers { get; set; }
        public int current_page { get; set; }
        public int total_pages { get; set; }        
    }
}
