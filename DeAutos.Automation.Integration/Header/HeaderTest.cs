using DeAutos.Automation.Framework.Resolver;
using DeAutos.Automation.Integration.Integration;
using DeAutos.Automation.Integration.Pages.Auth;
using DeAutos.Automation.Integration.Pages.Header;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace DeAutos.Automation.Integration.Header
{
    [TestClass]
    public class HeaderTest : BaseIntegrationTest
    {
        [TestMethod, TestCategory("Others"), TestCategory("CriticalDev")]
        public void Logo()
        {
            driver.Url = Url.Deautos.Views.Home.Main;
            var header = new HeaderPage(driver);
            header.ClickLogo();
            IsTrue(string.Equals(driver.Url, Url.Deautos.Views.Home.Main));
        }

        [TestMethod, TestCategory("Login"), TestCategory("Auth"), TestCategory("CriticalDev")]
        public void Login()
        {
            driver.Url = Url.Deautos.Views.Home.Main;
            var header = new AuthPage(driver);
            header.Login();
        }
    }
}