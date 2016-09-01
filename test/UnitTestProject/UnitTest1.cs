using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1, 1,"erreur");

        }
    }
}
