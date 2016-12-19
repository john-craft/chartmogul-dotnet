using ChartMogul.API;
using ChartMogul.API.Import;
using ChartMogul.API.Models;
using ChartMogul.API.Models.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OConnors.ChartMogul.API.Models;
using System.IO;
using System.Net;
using System.Text;

namespace TestChartMogul.Import
{
    [TestClass]
  public  class CustomerTest:ParentTest
    {
         private Customer _customer;
         private Mock<IHttp> _http;           

        [TestInitialize]
        public  void TestInitialize()
        {
            _http = new Mock<IHttp>();
           _customer = new Customer( _http.Object);
        }
  
            [TestMethod]
            public void GivenCalling_GetCustomers_ReturnsListOfCustomers()
            { 
            _http.Setup(x => x.Get<CustomerResponseDataModel>()).Returns(new CustomerResponseDataModel() { Customers = new System.Collections.Generic.List<CustomerModel> { new CustomerModel() { City = "test",Company="test"} } });
            var response = _customer.GetCustomers(new APIRequest());
            Assert.IsNotNull(response);        
            }               
    }
}
