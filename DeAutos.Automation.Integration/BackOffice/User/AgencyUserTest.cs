using DeAutos.Automation.Framework.Resolver;
using DeAutos.Automation.Integration.Integration;
using DeAutos.Automation.Integration.Pages.Auth;
using DeAutos.Automation.Integration.Pages.BackOffice.User;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static DeAutos.Automation.Framework.Resolver.FormData;

namespace DeAutos.Automation.Integration.BackOffice.User
{
    [TestClass]
    public class AgencyUserTest : BaseIntegrationTest
    {
        [TestMethod, TestCategory("Backoffice")]
        public void DisableAndCreateSubscription()
        {
            var login = new AuthPage(driver);
            driver.Url = Url.Deautos.Views.Backoffice.Main;
            var agencyUser = new AgencyUserPage(driver);

            login.BackOfficeLogin();
            agencyUser.DisableSubscription(SubscriptionUser);
            agencyUser.CreateSubscription(SubscriptionUser);
        }
    }
}