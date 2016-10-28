using DeAutos.Automation.Framework.Resolver;
using DeAutos.Automation.Integration.Integration;
using DeAutos.Automation.Integration.Pages.Auth;
using DeAutos.Automation.Integration.Pages.BackOffice.Admin;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace DeAutos.Automation.Integration.BackOffice.Admin
{
    [TestClass]
    public class BackOfficeUserTest : BaseIntegrationTest
    {
        [TestMethod, TestCategory("Backoffice")]
        public void CreateAndDeleteBackOfficeUser()
        {
            var login = new AuthPage(driver);
            var user = new BackOfficeUserPage(driver);

            driver.Url = string.Concat(Url.Deautos.Views.Backoffice.Main, "secUser");
            login.BackOfficeLogin();
            IsTrue(user.CreateBackOfficeUser());
            IsTrue(user.DeleteBackOfficeUser());
        }
    }
}