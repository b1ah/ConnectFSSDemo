using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConnectFSS_Demo.Controllers;

namespace ConnectFSS_Demo_UnitTests
{
    [TestClass]
    public class AccountControllerTest
    {
        [TestMethod]
        public void TestIndexGet()
        {
            var ac = new AccountsController();
            var result = ac.Index();
            Assert.IsNotNull(result);
        }
    }
}
