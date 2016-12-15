using ChartMogul.API;
using ChartMogul.API.Common;
using ChartMogul.API.Import;
using ChartMogul.API.Models.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OConnors.ChartMogul.API;
using OConnors.ChartMogul.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestChartMogul.Import
{
    [TestClass]
  public  class CustomerTest
    {
        private Mock<IChartMogulCore> _chartMogulCore;
        private ChartMogulClient _chartMogulClient;
        private Customer _customer;
        private Mock<IDataSource> _dataSource;
        private Mock<IPlan> _plan;
        [TestInitialize]
        public void TestInitialize()
        {
            _chartMogulCore = new Mock<IChartMogulCore>();         
            _plan = new Mock<IPlan>();
            _dataSource = new Mock<IDataSource>();
            _customer = new Customer(_chartMogulCore.Object);
          //  _chartMogulClient = new ChartMogulClient(_customer.Object,_dataSource.Object,_plan.Object);           
        }

        public CustomerModel TestCustomerModel()
        {
            return new CustomerModel() { };
        }

            [TestMethod]
            public void TestMethod1()
            {
            _chartMogulCore.Setup(x => x.CallApi(It.IsAny<APIRequest>())).Returns(new ApiResponse() { Json = "test"});
            _customer.AddCustomer(new APIRequest() { URLPath ="test"});
            }
   }    
    }
