using ChartMogul.API.Common;
using ChartMogul.API.Import;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestChartMogul.Import
{
    [TestClass]
    public class ParentTest
    {

        public ChartMogulCore _chartMogulCore;
        public Mock<IDataSource> _dataSource;
        public Mock<IWebCall> _webCall;

      public  ParentTest()
        {
            _webCall = new Mock<IWebCall>();
            _chartMogulCore = new ChartMogulCore(_webCall.Object);
            _dataSource = new Mock<IDataSource>();
        }
 
    }
}
