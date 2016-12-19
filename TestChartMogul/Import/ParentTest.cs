using ChartMogul.API;
using ChartMogul.API.Import;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TestChartMogul.Import
{
    [TestClass]
    public class ParentTest
    {

        public Mock<IDataSource> _dataSource;
        public Mock<IHttp> _http;


        public  ParentTest()
        {     
            _dataSource = new Mock<IDataSource>();
            _http = new Mock<IHttp>();
        }
 
    }
}
