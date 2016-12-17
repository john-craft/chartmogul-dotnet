using ChartMogul.API.Common;
using ChartMogul.API.Models.Core;
using OConnors.ChartMogul.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChartMogul.API.Models;

namespace ChartMogul.API.Import
{
    public interface IPlan
    {
        PlanModel CreatePlan(PlanModel plan);
        List<PlanModel> GetPlans(APIRequest apiRequest);
    }

    public class Plan : AbstractService,IPlan
    {
        private IChartMogulCore _chartMogulCore;
        private readonly string _baseUrl;
        public Plan(IChartMogulCore chartMogulCore, Http http) : base(http)
        {
            _chartMogulCore = chartMogulCore;
            _baseUrl = Configuration.BaseUrl;
        }
        public PlanModel CreatePlan(PlanModel plan)
        {
            var response = Http.Post<PlanModel, PlanModel>(String.Format("{0}/import/plans", _baseUrl), plan);
            return response;
        }

        public List<PlanModel> GetPlans(APIRequest apiRequest)
        {
            //apiRequest.URLPath = "import/plans";
            //apiRequest.HttpMethod = "get";
            var response = Http.Get<PlanResponseDataModel>(String.Format("{0}/import/plans", _baseUrl));
            return response.plans;
        }

    }
}
