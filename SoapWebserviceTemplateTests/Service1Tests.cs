using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoapWebserviceTemplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoapWebserviceTemplate.Tests
{
    [TestClass()]
    public class Service1Tests
    {
        [TestMethod()]
        public void GetValue1Test()
        {
            //Arrange

            IService1 service = new Service1();

            //Act

            //service.GetValue1(2, 2, 2);

            //Assert

            Assert.AreEqual(8, service.GetValue1(2, 2, 2));
        }

        [TestMethod()]
        public void GetValue2Test()
        {
            //Arrange

            IService1 service = new Service1();

            //Act

            //service.GetSide(8,2,2);

            //Assert

            Assert.AreEqual(2, service.GetValue2(8, 2, 2));
        }
    }
}