using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PojectGANkurs;

namespace UnitTestProject5
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            PojectGANkurs.windowfolder.update page = new PojectGANkurs.windowfolder.update();
            Assert.IsTrue(page.thisupdate("change1", "change1", "change1", "change1", "change1", "change1", 20));
            Assert.IsTrue(page.thisupdate("change2", "change2", "change2", "change2", "change2", "change2", 21));
            Assert.IsTrue(page.thisupdate("change3", "change3", "change3", "change3", "change3", "change3", 22));
            Assert.IsFalse(page.thisupdate("change33", "change33", "change33", "change33", "change33", "change33", 150));
            Assert.IsFalse(page.thisupdate("change33", "change33", "change33", "change33", "change33", "change33", 151));
            Assert.IsFalse(page.thisupdate("change33", "change33", "change33", "change33", "change33", "change33", 152));
        }
    }
}
