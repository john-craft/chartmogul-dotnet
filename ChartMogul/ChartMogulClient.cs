using ChartMogul.API.Import;
using OConnors.ChartMogul.API.Models;
using System;
using System.Collections.Generic;
using StructureMap;
using ChartMogul.API.Models.Core;
using System.Text;
using System.IO;
using ChartMogul.API.Enrichment;
namespace ChartMogul.API
{

    public interface IChartMogulClient
    {
        CustomerModel AddCustomer(CustomerModel customerModel);
        List<CustomerModel> GetCustomers();
        void DeleteCustomer(CustomerModel customerModel);
        List<DataSourceModel> GetDataSources();
        DataSourceModel AddDataSource(DataSourceModel datasourcemodal);
        void DeleteDataSource(DataSourceModel dataSourcemodel);
        PlanModel CreatePlan(PlanModel plan);
        List<PlanModel> GetPlans();
        List<InvoiceModel> GetInvoices(CustomerModel customerModel);
        List<InvoiceModel> AddInvoice(CustomerModel customerModel, List<InvoiceModel> invoiceModellist);
        TransactionModel AddTransaction(InvoiceModel invoicemodel, TransactionModel transactionmodel);
        List<SubscriptionModel> GetSubscriptions(CustomerModel customermodelequest);
        SubscriptionModel CancelSubscription(SubscriptionModel subscriptionModel);
    }


    /// <summary>
    /// Master client for interacting with ChartMogulClient services
    /// </summary>
    public class ChartMogulClient : IChartMogulClient
    {
        private Import.ICustomer _iCustomer;
        private IDataSource _iDataSource;
        private IPlan _iPlan;
        private IInvoice _iInvoice;
        private ITransaction _iTransaction;
        private ISubscription _iSubscription;
        private APIRequest _apiRequest = new APIRequest();
        public Enrichment.Enrichment Enrichment{ get
            {
                var container = Container.For<MyRegistry>();
                var enrichmentObject = container.GetInstance<Enrichment.Enrichment>();
                enrichmentObject.ApiRequest = _apiRequest;
                return enrichmentObject;
            }
            set { }
        }


        public ChartMogulClient(Import.ICustomer iCustomer, IDataSource iDataSource, IPlan iPlan, IInvoice iInvoice, ITransaction iTransaction, ISubscription iSubscription)
        {
            _iCustomer = iCustomer;
            _iDataSource = iDataSource;
            _iPlan = iPlan;
            _iInvoice = iInvoice;
            _iTransaction = iTransaction;
            _iSubscription = iSubscription;
        }


        public ChartMogulClient(string accountKey, string secretKey)
        {
            if (string.IsNullOrEmpty(accountKey))
            {
                throw new InvalidDataException("AccountToken cannot be null");
            }

            if (string.IsNullOrEmpty(secretKey))
            {
                throw new InvalidDataException("SecretKey cannot be null");
            }
            Configuration config = new Configuration(accountKey, secretKey);
            configureDependencies();
        }



        /// <summary>
        /// The Headers provided by the client to add to the service
        /// </summary>
        public void AddHeaders(Dictionary<string, string> dictHeaders)
        {
            foreach (KeyValuePair<string, string> entry in dictHeaders)
            {
                _apiRequest.SetHeader(entry.Key, entry.Value);
            }
        }


        private void configureDependencies()
        {
            //StructureMap Still require some work
            var container = Container.For<MyRegistry>();
            _iCustomer = container.GetInstance<Import.ICustomer>();
            _iDataSource = container.GetInstance<IDataSource>();
            _iPlan = container.GetInstance<IPlan>();
            _iInvoice = container.GetInstance<IInvoice>();
            _iTransaction = container.GetInstance<ITransaction>();
            _iSubscription = container.GetInstance<ISubscription>();
        }

        public CustomerModel AddCustomer(CustomerModel customerModel)
        {
            return _iCustomer.AddCustomer(customerModel, _apiRequest);
        }

        public DataSourceModel AddDataSource(DataSourceModel datasourcemodal)
        {
            //dataSourceName
            return _iDataSource.AddDataSource(datasourcemodal, _apiRequest);
        }

        public void DeleteCustomer(CustomerModel customerModel)
        {
            _iCustomer.DeleteCustomer(customerModel, _apiRequest);

        }

        public void DeleteDataSource(DataSourceModel dataSourcemodel)
        {
            _iDataSource.DeleteDataSource(dataSourcemodel, _apiRequest);
        }

        public List<CustomerModel> GetCustomers()
        {
            return _iCustomer.GetCustomers(_apiRequest);
        }

        public List<DataSourceModel> GetDataSources()
        {
            return _iDataSource.GetDataSources(_apiRequest);
        }

        public PlanModel CreatePlan(PlanModel plan)
        {
            return _iPlan.CreatePlan(plan, _apiRequest);
        }

        public List<PlanModel> GetPlans()
        {
            return _iPlan.GetPlans(_apiRequest);
        }

        public List<InvoiceModel> GetInvoices(CustomerModel customerModel)
        {
            return _iInvoice.GetInvoices(customerModel, _apiRequest);
        }

        public List<InvoiceModel> AddInvoice(CustomerModel customerModel, List<InvoiceModel> invoiceModellist)
        {
            return _iInvoice.AddInvoice(customerModel, _apiRequest, invoiceModellist);
        }

        public TransactionModel AddTransaction(InvoiceModel invoicemodel, TransactionModel transactionmodel)
        {
            return _iTransaction.AddTransaction(invoicemodel, transactionmodel, _apiRequest);
        }

        public List<SubscriptionModel> GetSubscriptions(CustomerModel customermodel)
        {
            return _iSubscription.GetSubscriptions(customermodel, _apiRequest);
        }

        public SubscriptionModel CancelSubscription(SubscriptionModel subscriptionModel)
        {
            return _iSubscription.CancelSubscription(subscriptionModel, _apiRequest);
        }

    }
}   
