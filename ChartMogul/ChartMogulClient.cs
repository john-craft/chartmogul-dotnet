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
      //  private APIRequest _apiRequest;
        private IChartMogulCore _iChartMogulCore;
        private string _credentials;

       public  ChartMogulClient(ICustomer iCustomer, IDataSource iDataSource, IPlan iPlan, IChartMogulCore iChartMogulCore )
        {
            _iChartMogulCore = iChartMogulCore;
            _iCustomer = iCustomer;
            _iDataSource = iDataSource;
            _iPlan = iPlan;
           


        }

       public  ChartMogulClient(Config config)
        {
            configureDependencies();
            
            var plainTextBytes = Encoding.UTF8.GetBytes(config.AccountToken + ":" + config.SecretKey);
            _credentials = Convert.ToBase64String(plainTextBytes);
            SetupDataForAPI();

        }

        private void SetupDataForAPI()
        {
            _iChartMogulCore.ApiRequest.HttpMethod = "get";
            _iChartMogulCore.ApiRequest.Header.Add("Authorization", "Basic " + _credentials);

        }



        public void AddHeaders(Dictionary<string, string> dictHeaders)
        {
            foreach (KeyValuePair<string, string> entry in dictHeaders)
            {
                _iChartMogulCore.ApiRequest.Header.Add(entry.Key,entry.Value);
            }

           
        }


        private void configureDependencies()
        {
            //StructureMap Still require some work
            var container = Container.For<MyRegistry>();
            _iChartMogulCore = container.GetInstance<IChartMogulCore>();
            _iCustomer = container.GetInstance<ICustomer>();

            _iDataSource = container.GetInstance<IDataSource>();
            _iPlan = container.GetInstance<IPlan>();
           
        }
        
        public CustomerModel AddCustomer(CustomerModel customerModel)
        {
            throw new NotImplementedException();
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
           return _iCustomer.GetCustomers(_iChartMogulCore.ApiRequest);
        }

        public List<DataSourceModel> GetDataSources()
        {
            throw new NotImplementedException();
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
