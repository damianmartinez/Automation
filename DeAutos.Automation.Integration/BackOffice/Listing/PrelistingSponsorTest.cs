using DeAutos.Automation.Framework.Resolver;
using DeAutos.Automation.Integration.Integration;
using DeAutos.Automation.Integration.Pages.Auth;
using DeAutos.Automation.Integration.Pages.BackOffice.Listing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace DeAutos.Automation.Integration.BackOffice.Listing
{
    [TestClass]
    public class PrelistinSponsorTest : BaseIntegrationTest
    {
        [TestMethod, TestCategory("Backoffice")]
        public void CreateEditRemovePrelistingSponsor()
        {
            var login = new AuthPage(driver);
            var prelisting = new PrelistingSponsorPage(driver);

            driver.Url = string.Concat(Url.Deautos.Views.Backoffice.Main, "prelisting");
            login.BackOfficeLogin();
            IsTrue(prelisting.CreatePrelistingSponsor());
            IsTrue(prelisting.EditPrelistingSponsor());
            IsTrue(prelisting.DeletePrelistingSponsor());
        }
    }
}