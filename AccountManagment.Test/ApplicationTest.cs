using _0_Framework.Application;
using AccountManagment.Application.Contract.Account;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AccountManagment.Test
{
    [TestClass]
    public class ApplicationTest
    {
        private readonly IAccountApplication _accountApplication;

        public ApplicationTest(IAccountApplication accountApplication)
        {
            _accountApplication = accountApplication;
        }

        [TestMethod]
        private void CanCreateAccount()
        {

            var user = new CreateAccount {
                FullName = "Hussein beygi",
                Mobile = "0912020056",
                Password = "test",
                ProfilePhoto = "testprofile.jpg",
                RoleId = 1,
                UserName = "husseinbeygi"
            };

            var result = _accountApplication.Create(user);
            var SucessfulTest = new OperationResult();
            Assert.Equals(result,SucessfulTest.IsSucceeded);

        }

    }
}
