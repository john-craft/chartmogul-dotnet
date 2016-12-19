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

    public class Plan : AbstractService,IPlan
    { 
        public Plan( Http http) : base(http)
        {
        }
        public PlanModel CreatePlan(PlanModel plan,APIRequest apiRequest)
        {
            apiRequest.RouteName ="import/plans";
            Http.ApiRequest = apiRequest;
            var response = Http.Post<PlanModel, PlanModel>(plan);
            return response;
        }

        public List<PlanModel> GetPlans(APIRequest apiRequest)
        {
            apiRequest.RouteName = "import/plans";
            Http.ApiRequest = apiRequest;
            var response = Http.Get<PlanResponseDataModel>();
            return response.Plans;
        }

    }
}
