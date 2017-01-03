using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartMogul.API.Models.Metrics
{
    public class MetricsQueryParamsModel
    {    
       public string StartDate {get;set;}
       public string EndDate { get; set; }
       public string Interval { get; set; }
       public string Geo { get; set; }
       public string Plans { get; set; }
    }
}
