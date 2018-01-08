using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib.Tests
{
    [TestClass()]
    public class ClassModelTests
    {
        [TestMethod()]

        [ExpectedException(typeof(NullReferenceException))]
        public void GetX3NotNull()
        {
            //Arrange 

            var xx = new ClassModel("Test", 2, 4, 0, 5);

            //Act

            double model = xx.GetX3();

        }
    }
}