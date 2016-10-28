using DeAutos.Automation.Framework.Resolver;
using DeAutos.Automation.Integration.Integration;
using DeAutos.Automation.Integration.Pages.Promotions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DeAutos.Automation.Integration.Promotions
{
    [TestClass]
    public class PromotionTest : BaseIntegrationTest
    {
        [TestMethod, TestCategory("SocialAndLanding")]
        public void Mobile()
        {
            driver.Url = Url.Deautos.Views.Landings.Promo + "/mobile";
            var promotion = new PromotionsPage(driver);
            promotion.NavigateMobile();
        }
    }
}