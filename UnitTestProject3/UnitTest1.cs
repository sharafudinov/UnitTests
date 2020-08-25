using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PojectGANkurs;

namespace UnitTestProject3
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            PojectGANkurs.windowfolder.patienswindow page = new PojectGANkurs.windowfolder.patienswindow();
            Assert.IsTrue(page.delete(17));
            Assert.IsTrue(page.delete(18));
            Assert.IsTrue(page.delete(19));
            Assert.IsFalse(page.delete(10550));
            Assert.IsFalse(page.delete(10551));
            Assert.IsFalse(page.delete(10552));

        }
    }
}
