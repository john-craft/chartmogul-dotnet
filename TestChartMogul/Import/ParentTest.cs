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

        public Mock<IDataSource> _dataSource;  

      public  ParentTest()
        {     
            _dataSource = new Mock<IDataSource>();
        }
 
    }
}
