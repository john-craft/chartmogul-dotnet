using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartMogul.API.Models.Enrichment
{
  public class CustomModel
    {

        public int CAC { get; set; }
        public string UTMCompaign { get; set; }
        public DateTime ConvertedAt { get; set; }
        public bool Pro { get; set; }
        public string SalesRep { get; set; }

    }
}
