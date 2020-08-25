using System;
using PojectGANkurs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutorizationTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            MainWindow window = new MainWindow();
            Assert.IsTrue(window.autorizat("test", "test"));
            Assert.IsFalse(window.autorizat("notest", "contest"));
            Assert.IsFalse(window.autorizat("notest", "test"));
            Assert.IsFalse(window.autorizat("test", "contest"));
        }
    }
}
