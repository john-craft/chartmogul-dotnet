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
        private readonly string _baseUrl;
        public Plan( Http http) : base(http)
        {
            _baseUrl = Configuration.BaseUrl;
        }
        public PlanModel CreatePlan(PlanModel plan,APIRequest apiRequest)
        {
            var response = Http.Post<PlanModel, PlanModel>(String.Format("{0}/import/plans", _baseUrl), plan, apiRequest);
            return response;
        }

        public List<PlanModel> GetPlans(APIRequest apiRequest)
        {
           var response = Http.Get<PlanResponseDataModel>(String.Format("{0}/import/plans", _baseUrl), apiRequest);
            return response.plans;
        }

    }
}
