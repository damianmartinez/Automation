using DeAutos.Automation.Framework.Resolver;
using DeAutos.Automation.Integration.Integration;
using DeAutos.Automation.Integration.Pages.Auth;
using DeAutos.Automation.Integration.Pages.BackOffice.User;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DeAutos.Automation.Integration.BackOffice.User
{
    [TestClass]
    public class LoginAsTest : BaseIntegrationTest
    {
        [TestMethod, TestCategory("Backoffice"), TestCategory("CriticalDev")]
        public void LoginAsEndUser()
        {
            var login = new AuthPage(driver);
            var loginAs = new LoginAsPage(driver);

            driver.Url = string.Concat(Url.Deautos.Views.Backoffice.Main, "loginAsCms");
            login.BackOfficeLogin();
            loginAs.LoginAsUser(FormData.EndUser);
        }

        [TestMethod, TestCategory("Backoffice"), TestCategory("CriticalDev")]
        public void LoginAsAgencyUser()
        {
            var login = new AuthPage(driver);
            var loginAs = new LoginAsPage(driver);

            driver.Url = string.Concat(Url.Deautos.Views.Backoffice.Main, "loginAsCms");
            login.BackOfficeLogin();
            loginAs.LoginAsUser(FormData.MultibrandUser);
        }
    }
}