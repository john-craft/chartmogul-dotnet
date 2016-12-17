using OConnors.ChartMogul.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartMogul.API.Models
{
    public class PlanResponseDataModel
    {
        public List<PlanModel> plans { get; set; }
        public int current_page { get; set; }
        public int total_pages { get; set; }
    }
}
