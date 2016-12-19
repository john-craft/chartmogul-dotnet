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
            apiRequest.Url ="{0}/import/plans";
            var response = Http.Post<PlanModel, PlanModel>(plan, apiRequest);
            return response;
        }

        public List<PlanModel> GetPlans(APIRequest apiRequest)
        {
            apiRequest.Url = "{0}/import/plans";
            var response = Http.Get<PlanResponseDataModel>(apiRequest);
            return response.plans;
        }

    }
}
