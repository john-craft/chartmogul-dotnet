using ChartMogul.API.Import;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TestChartMogul.Import
{
    [TestClass]
    public class ParentTest
    {

        public Mock<IDataSource> _dataSource;  

      public  ParentTest()
        {     
            _dataSource = new Mock<IDataSource>();
        }
 
    }
}
