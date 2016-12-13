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
        APIRequest ApiRequest { get; set; }

    }

    public class Plan : IPlan
    {
        public APIRequest ApiRequest { get; set; }
        private IChartMogulCore _icharmogulCore;

        Plan (IChartMogulCore ichartMogulcore)
        {
            _icharmogulCore = ichartMogulcore;
        }


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
