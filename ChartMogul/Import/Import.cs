using ChartMogul.API.Models.Core;
using ChartMogul.API.Models.Import;
using System.Collections.Generic;

namespace ChartMogul.API.Import
{
    public interface IImport
    {
        CustomerModel AddCustomer(CustomerModel customerModel);
        DataSourceModel AddDataSource(DataSourceModel datasourcemodal);
        void DeleteCustomer(CustomerModel customerModel);
        void DeleteDataSource(DataSourceModel dataSourcemodel);
        List<CustomerModel> GetCustomers();
        List<DataSourceModel> GetDataSources();
        PlanModel CreatePlan(PlanModel plan);
        List<PlanModel> GetPlans();
        List<InvoiceModel> GetInvoices(CustomerModel customerModel);
        List<InvoiceModel> AddInvoice(CustomerModel customerModel, InvoiceResponseDataModel invoiceModellist);
        TransactionModel AddTransaction(InvoiceModel invoicemodel, TransactionModel transactionmodel);
        List<SubscriptionModel> GetSubscriptions(CustomerModel customermodel);
        SubscriptionModel CancelSubscription(SubscriptionModel subscriptionModel);
    }

    public class Import : IImport
    {
        private ICustomer _iCustomer;
        private IDataSource _iDataSource;
        private IPlan _iPlan;
        private IInvoice _iInvoice;
        private ITransaction _iTransaction;
        private ISubscription _iSubscription;
        public APIRequest ApiRequest { get; set; }
        public Import(ICustomer iCustomer, IDataSource iDataSource, IPlan iPlan, IInvoice iInvoice, ITransaction iTransaction, ISubscription iSubscription)
        {
            _iCustomer = iCustomer;
            _iDataSource = iDataSource;
            _iPlan = iPlan;
            _iInvoice = iInvoice;
            _iTransaction = iTransaction;
            _iSubscription = iSubscription;
        }

        public CustomerModel AddCustomer(CustomerModel customerModel)
        {
            return _iCustomer.AddCustomer(customerModel, ApiRequest);
        }

        public DataSourceModel AddDataSource(DataSourceModel datasourcemodal)
        {
            return _iDataSource.AddDataSource(datasourcemodal, ApiRequest);
        }

        public void DeleteCustomer(CustomerModel customerModel)
        {
            _iCustomer.DeleteCustomer(customerModel, ApiRequest);

        }

        public void DeleteDataSource(DataSourceModel dataSourcemodel)
        {
            _iDataSource.DeleteDataSource(dataSourcemodel, ApiRequest);
        }

        public List<CustomerModel> GetCustomers()
        {
            return _iCustomer.GetCustomers(ApiRequest);
        }

        public List<DataSourceModel> GetDataSources()
        {
            return _iDataSource.GetDataSources(ApiRequest);
        }

        public PlanModel CreatePlan(PlanModel plan)
        {
            return _iPlan.CreatePlan(plan, ApiRequest);
        }

        public List<PlanModel> GetPlans()
        {
            return _iPlan.GetPlans(ApiRequest);
        }

        public List<InvoiceModel> GetInvoices(CustomerModel customerModel)
        {
            return _iInvoice.GetInvoices(customerModel, ApiRequest);
        }

        public List<InvoiceModel> AddInvoice(CustomerModel customerModel, InvoiceResponseDataModel invoiceModellist)
        {
            return _iInvoice.AddInvoice(customerModel, ApiRequest, invoiceModellist);
        }

        public TransactionModel AddTransaction(InvoiceModel invoicemodel, TransactionModel transactionmodel)
        {
            return _iTransaction.AddTransaction(invoicemodel, transactionmodel, ApiRequest);
        }

        public List<SubscriptionModel> GetSubscriptions(CustomerModel customermodel)
        {
            return _iSubscription.GetSubscriptions(customermodel, ApiRequest);
        }

        public SubscriptionModel CancelSubscription(SubscriptionModel subscriptionModel)
        {
            return _iSubscription.CancelSubscription(subscriptionModel, ApiRequest);
        }
    }
}
