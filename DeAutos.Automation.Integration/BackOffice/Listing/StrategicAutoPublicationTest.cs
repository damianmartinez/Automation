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
    public class StrategicAutoPublicationTest : BaseIntegrationTest
    {
        [TestMethod, TestCategory("Backoffice")]
        public void CreateStrategicAutoPublicationModel()
        {
            var login = new AuthPage(driver);
            var strategicAutoPublication = new StrategicAutoPublicationPage(driver);

            driver.Url = string.Concat(Url.Deautos.Views.Backoffice.Main, "strategicAutoPublication");
            login.BackOfficeLogin();
            IsTrue(strategicAutoPublication.CreateStrategicAutoPublication(SponsoringType.Model));
        }

        [TestMethod, TestCategory("Backoffice"), TestCategory("CriticalDev")]
        public void CreateEditRemoveStrategicAutoPublicationBrand()
        {
            var login = new AuthPage(driver);
            var strategicAutoPublication = new StrategicAutoPublicationPage(driver);

            driver.Url = string.Concat(Url.Deautos.Views.Backoffice.Main, "strategicAutoPublication");
            login.BackOfficeLogin();
            IsTrue(strategicAutoPublication.CreateStrategicAutoPublication(SponsoringType.Brand));
            IsTrue(strategicAutoPublication.EditStrategicAutoPublication());
            IsTrue(strategicAutoPublication.DeleteStrategicAutoPublication());
        }
    }
}