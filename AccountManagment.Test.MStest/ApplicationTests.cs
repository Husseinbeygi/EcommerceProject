using _0_Framework.Application;
using AccountManagment.Application;
using AccountManagment.Application.Contract.Account;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AccountManagment.Test.MStest
{
    [TestClass]
    public class ApplicationTests
    {
        private readonly IAccountApplication _accountApplication;

        public ApplicationTests()
        {
        }

        public ApplicationTests(IAccountApplication accountApplication)
        {
            _accountApplication = accountApplication;
        }

        [TestMethod]
        public void CanCreateAccount()
        {
            var acc = new AccountApplication();
            var user = new CreateAccount {
                FullName = "Hussein beygi",
                Mobile = "0912020056",
                Password = "test",
                ProfilePhoto = "testprofile.jpg",
                RoleId = 1,
                UserName = "husseinbeygi"
            };

            var result = acc.Create(user);
            var SucessfulTest = new OperationResult();
            Assert.Equals(result, SucessfulTest.IsSucceeded);


        }
    }
}
