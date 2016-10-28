using DeAutos.Automation.Framework.Resolver;
using DeAutos.Automation.Integration.Integration;
using DeAutos.Automation.Integration.Pages.Auth;
using DeAutos.Automation.Integration.Pages.BackOffice.Listing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace DeAutos.Automation.Integration.BackOffice.Listing
{
    [TestClass]
    public class ListingTest : BaseIntegrationTest
    {
        [TestMethod, TestCategory("Backoffice")]
        public void CreateDefaultAutoPublication()
        {
            var login = new AuthPage(driver);
            var defaultAutoPublication = new DefaultAutoPublicationPage(driver);

            driver.Url = string.Concat(Url.Deautos.Views.Backoffice.Main, "defaultAutoPublication");
            login.BackOfficeLogin();
            IsTrue(defaultAutoPublication.CreateDefaultAutoPublication());
        }

        [TestMethod, TestCategory("Backoffice")]
        public void EditDefaultAutoPublication()
        {
            var login = new AuthPage(driver);
            var defaultAutoPublication = new DefaultAutoPublicationPage(driver);

            driver.Url = string.Concat(Url.Deautos.Views.Backoffice.Main, "defaultAutoPublication");
            login.BackOfficeLogin();
            IsTrue(defaultAutoPublication.EditDefaultAutoPublication());
        }

        [TestMethod, TestCategory("Backoffice")]
        public void DeleteDefaultAutoPublication()
        {
            var login = new AuthPage(driver);
            var defaultAutoPublication = new DefaultAutoPublicationPage(driver);

            driver.Url = string.Concat(Url.Deautos.Views.Backoffice.Main, "defaultAutoPublication");
            login.BackOfficeLogin();
            IsTrue(defaultAutoPublication.DeleteDefaultAutoPublication());
        }
    }
}