using ChartMogul.API;
using ChartMogul.API.Import;
using ChartMogul.API.Models.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OConnors.ChartMogul.API;
using OConnors.ChartMogul.API.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestChartMogul.Import
{
    [TestClass]
  public  class CustomerTest:ParentTest
    {
         private Customer _customer;
        private Http _http;
        
    

        [TestInitialize]
        public  void TestInitialize()
        {
            _http = new Http();
           _customer = new Customer( _http);
        }

        public CustomerModel TestCustomerModel()
        {
            return new CustomerModel() { };
        }

            [TestMethod]
            public void TestMethod1()
            {
            var expected = "response content";
            var expectedBytes = Encoding.UTF8.GetBytes(expected);
            var responseStream = new MemoryStream();
            responseStream.Write(expectedBytes, 0, expectedBytes.Length);
            responseStream.Seek(0, SeekOrigin.Begin);
            var response = new Mock<HttpWebResponse>();
            response.Setup(c => c.GetResponseStream()).Returns(responseStream);
            //_webCall.Setup(x => x.DownloadResponse(It.IsAny<HttpWebRequest>())).Returns(response.Object);
            _customer.AddCustomer(new CustomerModel { city="test" },new APIRequest());
            }               
    }
}
