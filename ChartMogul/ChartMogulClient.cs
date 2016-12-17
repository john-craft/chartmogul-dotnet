using ChartMogul.API.Import;
using OConnors.ChartMogul.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;
using ChartMogul.API.Models.Core;
using ChartMogul.API.Common;
using Newtonsoft.Json;

namespace ChartMogul.API
{

    public interface IChartMogulClient
    {
        CustomerModel AddCustomer(CustomerModel customerModel);
        List<CustomerModel> GetCustomers();
        void DeleteCustomer();
        List<DataSourceModel> GetDataSources();
        DataSourceModel AddDataSource(DataSourceModel dataSource);
        void DeleteDataSource();
        PlanModel CreatePlan(PlanModel plan);
        List<PlanModel> GetPlans();
    }

    public class ChartMogulClient : IChartMogulClient
    {
        private ICustomer _iCustomer;
        private IDataSource _iDataSource;
        private IPlan _iPlan;
        private string _credentials;
        private APIRequest _apiRequest= new APIRequest();

        public ChartMogulClient(ICustomer iCustomer, IDataSource iDataSource, IPlan iPlan)
        {    
            _iCustomer = iCustomer;
            _iDataSource = iDataSource;
            _iPlan = iPlan;         
        }

        public ChartMogulClient(Config config)
        {  
            configureDependencies();
            SetupDataForAPI(config);
            
        }

        private void SetupDataForAPI(Config config)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(config.AccountToken + ":" + config.SecretKey);
            _credentials = Convert.ToBase64String(plainTextBytes);
            _apiRequest.Header.Add("Authorization", "Basic " + _credentials);
        }

        public void AddHeaders(Dictionary<string, string> dictHeaders)
        {
            foreach (KeyValuePair<string, string> entry in dictHeaders)
            {
                _apiRequest.Header.Add(entry.Key, entry.Value);
            }
        }


        private void configureDependencies()
        {
            //StructureMap Still require some work
            var container = Container.For<MyRegistry>();
            _iCustomer = container.GetInstance<ICustomer>();
            _iDataSource = container.GetInstance<IDataSource>();
            _iPlan = container.GetInstance<IPlan>();
        }

        public CustomerModel AddCustomer(CustomerModel customerModel)
        {          
           var serializeData = JsonConvert.SerializeObject(customerModel);         
            _apiRequest.JsonData = serializeData;
            _apiRequest.URLPath = "import/customers";
            _apiRequest.HttpMethod = "POST";
            _iCustomer.AddCustomer(customerModel);
            return null;
        }

        public DataSourceModel AddDataSource(DataSourceModel dataSource)
        {
            throw new NotImplementedException();
        }

        public void DeleteCustomer()
        {
            // _iCustomer.ApiRequest.URLPath = string.Empty;

            _iCustomer.DeleteCustomer();

        }

        public void DeleteDataSource()
        {
            throw new NotImplementedException();
        }

        public List<CustomerModel> GetCustomers()
        {
        //    _apiRequest = new APIRequest<Customer>();
            return _iCustomer.GetCustomers(_apiRequest);
        }

        public List<DataSourceModel> GetDataSources()
        {
            throw new NotImplementedException();
        }

        public PlanModel CreatePlan(PlanModel plan)
        {
            return _iPlan.CreatePlan(plan);
        }

        public List<PlanModel> GetPlans()
        {
        //    _apiRequest = new APIRequest<PlanModel>();
            return _iPlan.GetPlans(_apiRequest);
        }
    }
}
