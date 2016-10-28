using DeAutos.Automation.Framework.DTO;
using DeAutos.Automation.Framework.Resolver;
using DeAutos.Automation.Integration.Integration;
using DeAutos.Automation.Integration.Pages.Auth;
using DeAutos.Automation.Integration.Pages.BackOffice.Listing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace DeAutos.Automation.Integration.BackOffice.Listing
{
    [TestClass]
    public class ListingSponsorTest : BaseIntegrationTest
    {
        [TestMethod, TestCategory("Backoffice"), TestCategory("CriticalDev")]
        public void CreateEditRemoveListingSponsor()
        {
            var login = new AuthPage(driver);
            var sponsor = new ListingSponsorPage(driver);

            driver.Url = string.Concat(Url.Deautos.Views.Backoffice.Main, "listingSponsor");
            login.BackOfficeLogin();
            IsTrue(sponsor.CreateListingSponsor(SponsoringType.Brand));
            IsTrue(sponsor.EditListingSponsor());
            IsTrue(sponsor.DeleteListingSponsor());
        }
    }
}