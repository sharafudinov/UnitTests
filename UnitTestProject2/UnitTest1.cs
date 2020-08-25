using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PojectGANkurs;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            PojectGANkurs.windowfolder.patienswindow page = new PojectGANkurs.windowfolder.patienswindow();
            Assert.IsTrue(page.search("test1", "test1"));
            Assert.IsTrue(page.search("test2", "test2"));
            Assert.IsTrue(page.search("test221", "test221"));
            Assert.IsFalse(page.search("test1", "test2"));
            Assert.IsFalse(page.search("test2", "test1"));
            Assert.IsFalse(page.search("test1", "test221"));
        }
    }
}
