using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PojectGANkurs;

namespace UnitTestProject4
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            PojectGANkurs.windowfolder.regiin page = new PojectGANkurs.windowfolder.regiin();
            Assert.IsTrue(page.regup("test1", "test1", "12:00:00", "test1", "2019-12-20", 1, 5, 1));
            Assert.IsTrue(page.regup("test2", "test2", "13:00:00", "test2", "2019 - 12 - 17", 2, 2, 1));
            Assert.IsTrue(page.regup("testuser", "testuser", "14:00:00", "testuser", "2019-12-18", 3, 7, 1));
            Assert.IsFalse(page.regup("ntestuser", "wtestuser", "14:00:00", "no", "2019-12-18", 3, 7, 1));
            Assert.IsFalse(page.regup("vtestuser", "etestuser", "14:00:00", "test", "2019-12-18", 3, 7, 1));
            Assert.IsFalse(page.regup("atestuser", "ttestuser", "14:00:00", "test", "2019-12-18", 3, 7, 1));
        }
    }
}
