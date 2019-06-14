using Microsoft.VisualStudio.TestTools.UnitTesting;
using RBS.Authentication;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest_Models
    {
        [TestMethod]
        public void CreateAdminAccount()
        {
            AuthenticationSystem AuthenticationSystemObject = new AuthenticationSystem
            {
                FullName = "dilip",
                MasterPassword = "dilip",
                EmployeeID = "dilip",
                EmailID = "dilipn6@gmail.com",
                AdminAccountStatus = true,
                ActivationStatus = true
            };
            AuthenticationSystemObject.CreateAdminAccount();
        }

        [TestMethod]
        public void GetAdminAccount()
        {
            AuthenticationSystem AuthenticationSystemObject = new AuthenticationSystem();
            AuthenticationSystemObject.InitialiseAuthenticationResources();
            AuthenticationSystemObject.GetAdminAccount();
            Assert.AreEqual("dilip", AuthenticationSystemObject.FullName);
            Assert.AreEqual("dilip", AuthenticationSystemObject.MasterPassword);
            Assert.AreEqual("dilip", AuthenticationSystemObject.EmployeeID);
            Assert.AreEqual("dilipn6@gmail.com", AuthenticationSystemObject.EmailID);
            Assert.AreEqual(true, AuthenticationSystemObject.AdminAccountStatus);
            Assert.AreEqual(true, AuthenticationSystemObject.ActivationStatus);
        }   
    }
}
