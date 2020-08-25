using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PojectGANkurs;

namespace UnitTestProject7
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            PojectGANkurs.windowfolder.windowifin page = new PojectGANkurs.windowfolder.windowifin();
            Assert.IsTrue(page.rsad(5, 3));
            Assert.IsFalse(page.rsad(0, 3));
            Assert.IsFalse(page.rsad(5, 0));
        }
    }
}
