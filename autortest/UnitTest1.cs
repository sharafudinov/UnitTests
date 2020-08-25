using System;
using PojectGANkurs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace autortest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            PojectGANkurs.MainWindow page = new MainWindow();
            Assert.IsTrue(page.autorizat("test", "test"));
        }
    }
}