using ChartMogul.API.Models.Core;
using System.Collections.Generic;
using ChartMogul.API.Models.Import;

namespace ChartMogul.API.Import
{
    public interface IPlan
    {
        PlanModel CreatePlan(PlanModel plan, APIRequest apiRequest);
        List<PlanModel> GetPlans(APIRequest apiRequest);
    }

    public class Plan : IPlan
    {
        private IHttp _ihttp;
        private string url = "import/plans";
        public Plan(IHttp ihttp)
        {
            _ihttp = ihttp;
        }
        public PlanModel CreatePlan(PlanModel plan, APIRequest apiRequest)
        {
            apiRequest.RouteName = url;
            _ihttp.ApiRequest = apiRequest;
            var response = _ihttp.Post<PlanModel, PlanModel>(plan);
            return response;
        }

        public List<PlanModel> GetPlans(APIRequest apiRequest)
        {
            apiRequest.RouteName = url;
            _ihttp.ApiRequest = apiRequest;
            var response = _ihttp.Get<PlanResponseDataModel>();
            return response.Plans;
        }

    }
}
