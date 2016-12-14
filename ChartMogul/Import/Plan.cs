using ChartMogul.API.Common;
using ChartMogul.API.Models.Core;
using OConnors.ChartMogul.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartMogul.API.Import
{
    public interface IPlan
    {
        PlanModel CreatePlan(PlanModel plan);
        List<PlanModel> GetPlans();
    }

    public class Plan : ChartMogulCore, IPlan
    {
  
        public PlanModel CreatePlan(PlanModel plan)
        {
            throw new NotImplementedException();
        }

       
        public List<PlanModel> GetPlans()
        {
            throw new NotImplementedException();
        }
    }
}
