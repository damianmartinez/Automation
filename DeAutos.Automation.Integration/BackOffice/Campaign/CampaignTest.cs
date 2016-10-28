using DeAutos.Automation.Framework.Resolver;
using DeAutos.Automation.Integration.Integration;
using DeAutos.Automation.Integration.Pages.Auth;
using DeAutos.Automation.Integration.Pages.BackOffice.Campaign;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace DeAutos.Automation.Integration.BackOffice.Campaign
{
    [TestClass]
    public class DiscountTest : BaseIntegrationTest
    {
        [TestMethod, TestCategory("Backoffice")]
        public void CreateEditRemoveCampaign()
        {
            var login = new AuthPage(driver);
            var campaign = new CampaignPage(driver);

            driver.Url = string.Concat(Url.Deautos.Views.Backoffice.Main, "campaign");
            login.BackOfficeLogin();
            IsTrue(campaign.CreateCampaign());
            IsTrue(campaign.EditCampaign());
            IsTrue(campaign.DeleteCampaign());
        }
    }
}