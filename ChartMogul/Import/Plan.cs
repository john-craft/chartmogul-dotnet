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
        List<PlanModel> GetPlans(APIRequest apiRequest);
    }

    public class Plan : IPlan
    {
        private IChartMogulCore _chartMogulCore;
        public Plan(IChartMogulCore chartMogulCore)
        {
            _chartMogulCore = chartMogulCore;
        }
        public PlanModel CreatePlan(PlanModel plan)
        {
            throw new NotImplementedException();
        }

        public List<PlanModel> GetPlans(APIRequest apiRequest)
        {
            apiRequest.URLPath = "import/plans";
            apiRequest.HttpMethod = "get";
            var temp = _chartMogulCore.CallApi(apiRequest);
            return null;
        }

    }
}
