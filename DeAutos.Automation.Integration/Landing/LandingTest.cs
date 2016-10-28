using DeAutos.Automation.Framework.Resolver;
using DeAutos.Automation.Integration.Integration;
using DeAutos.Automation.Integration.Pages.Landing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DeAutos.Automation.Integration.Landing
{
    [TestClass]
    public class HomeTest : BaseIntegrationTest
    {
        [TestMethod, TestCategory("Contact")]
        public void ContactLanding()
        {
            driver.Url = Url.Deautos.Views.Landings.Landing;
            var landing = new LandingPage(driver);
            landing.ContactLanding();
        }
    }
}