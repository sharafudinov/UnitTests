using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PojectGANkurs;

namespace UnitTestProject6
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            PojectGANkurs.windowfolder.Raspisanie page = new PojectGANkurs.windowfolder.Raspisanie();
            Assert.IsTrue(page.takeall("Понедельник", "test1", "test1"));
            Assert.IsTrue(page.takeall("Вторник", "test", "test"));
            Assert.IsTrue(page.takeall("Четверг", "test1", "test1"));
            Assert.IsFalse(page.takeall("Среда", "test", "test"));
            Assert.IsFalse(page.takeall("Суббота", "test", "test"));
            Assert.IsFalse(page.takeall("Воскресенье", "test", "test"));
            Assert.IsTrue(page.takeday("Понедельник"));
            Assert.IsTrue(page.takeday("Вторник"));
            Assert.IsTrue(page.takeday("Четверг"));
            Assert.IsFalse(page.takeday("Среда"));
            Assert.IsFalse(page.takeday("Воскресенье"));
            Assert.IsFalse(page.takeday("Суббота"));
            Assert.IsTrue(page.takedoc("test", "test"));
            Assert.IsTrue(page.takedoc("test1", "test1"));
            Assert.IsTrue(page.takedoc("test2", "test2"));
            Assert.IsFalse(page.takedoc("tester", "tester"));
            Assert.IsFalse(page.takedoc("tester1", "tester1"));
            Assert.IsFalse(page.takedoc("tester1", "tester1"));



        }
    }
}
