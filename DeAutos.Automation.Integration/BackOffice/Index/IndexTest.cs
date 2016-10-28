using DeAutos.Automation.Framework.Resolver;
using DeAutos.Automation.Integration.Integration;
using DeAutos.Automation.Integration.Pages.Auth;
using DeAutos.Automation.Integration.Pages.BackOffice;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace DeAutos.Automation.Integration.BackOffice.Index
{
    [TestClass]
    public class IndexTest : BaseIntegrationTest
    {
        [TestMethod, TestCategory("Backoffice")]
        public void NavigationCheck()
        {
            var login = new AuthPage(driver);
            var index = new BackOfficeIndexPage(driver);

            driver.Url = Url.Deautos.Views.Backoffice.Main;
            login.BackOfficeLogin();
            IsTrue(index.NavigationCheck());
        }
    }
}