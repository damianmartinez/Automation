using DeAutos.Automation.Framework.Resolver;
using DeAutos.Automation.Integration.Integration;
using DeAutos.Automation.Integration.Pages.Campaign;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace DeAutos.Automation.Integration.Campaign
{
    [TestClass]
    public class CampaignTest : BaseIntegrationTest
    {
        [TestMethod, TestCategory("Contact")]
        public void AskPriceCampaign()
        {
            driver.Url = Url.Deautos.Views.Catalog.Campaign;
            var campaign = new CampaignPage(driver);
            IsTrue(campaign.AskPrice());
        }
    }
}