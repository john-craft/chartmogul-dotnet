using ChartMogul.API.Models.Core;
using OConnors.ChartMogul.API.Models;
using System.Collections.Generic;
using ChartMogul.API.Models;

namespace ChartMogul.API.Import
{
    public interface IPlan
    {
        PlanModel CreatePlan(PlanModel plan,APIRequest apiRequest);
        List<PlanModel> GetPlans(APIRequest apiRequest);
    }

    public class Plan : IPlan
    {
        private IHttp _ihttp;
        public Plan(IHttp ihttp)
        {
            _ihttp = ihttp;
        }
        public PlanModel CreatePlan(PlanModel plan,APIRequest apiRequest)
        {
            apiRequest.RouteName ="import/plans";
            _ihttp.ApiRequest = apiRequest;
            var response = _ihttp.Post<PlanModel, PlanModel>(plan);
            return response;
        }

        public List<PlanModel> GetPlans(APIRequest apiRequest)
        {
            apiRequest.RouteName = "import/plans";
            _ihttp.ApiRequest = apiRequest;
            var response = _ihttp.Get<PlanResponseDataModel>();
            return response.Plans;
        }

    }
}
