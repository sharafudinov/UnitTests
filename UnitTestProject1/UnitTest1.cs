using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PojectGANkurs;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            PojectGANkurs.windowfolder.RegistrationWindow page = new PojectGANkurs.windowfolder.RegistrationWindow();
            Assert.IsTrue(page.registration("testuser1", "testuser1", "testuser1", "testuser1", "testuser1", "testuser1"));
            Assert.IsTrue(page.registration("testuser2", "testuser2", "testuser2", "testuser2", "testuser2", "testuser2"));
            Assert.IsTrue(page.registration("testuser3", "testuser3", "testuser3", "testuser3", "testuser3", "testuser3"));
            Assert.IsFalse(page.registration("testuser", "testuser", "testuser", "testuser", "testuser", "testuser"));
            Assert.IsFalse(page.registration("test1", "test1", "test1", "test1", "test1", "test1"));
            Assert.IsFalse(page.registration("test2", "test2", "test2", "test2", "test2", "test2"));
        }
    }
}
