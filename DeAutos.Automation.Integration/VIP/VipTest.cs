using DeAutos.Automation.Framework.Resolver;
using DeAutos.Automation.Integration.Integration;
using DeAutos.Automation.Integration.Pages.Vip;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DeAutos.Automation.Integration.Vip
{
    [TestClass]
    public class VipTest : BaseIntegrationTest
    {
        [TestMethod, TestCategory("Contact"), TestCategory("CriticalDev")]
        public void SendConsult()
        {
            driver.Url = Url.Deautos.Views.Vip.Sheet;
            var consult = new VipPage(driver);
            consult.PrincipalForm(FormData.ValidEmail);
        }

        [TestMethod, TestCategory("Contact"), TestCategory("CriticalDev")]
        public void PayWithUsed()
        {
            driver.Url = Url.Deautos.Views.Vip.Sheet;
            var consult = new VipPage(driver);
            consult.OfferUsed("Primary");
        }

        [TestMethod, TestCategory("Contact")]
        public void ConsultOfferUsed()
        {
            driver.Url = Url.Deautos.Views.Vip.Sheet;
            var consult = new VipPage(driver);
            consult.OfferUsed("Secondary");
        }

        [TestMethod, TestCategory("Contact"), TestCategory("CriticalDev")]
        public void ConsultSecundaryForm()
        {
            driver.Url = Url.Deautos.Views.Vip.Sheet;
            var consult = new VipPage(driver);
            consult.SecundaryForm();
        }

        [TestMethod, TestCategory("Contact")]
        public void YConsultSimilarOne()
        {
            driver.Url = Url.Deautos.Views.Vip.Sheet;
            var consult = new VipPage(driver);
            consult.SimilarOne();
        }

        [TestMethod, TestCategory("Contact")]
        public void ReportPublication()
        {
            driver.Url = Url.Deautos.Views.Vip.Sheet;
            var consult = new VipPage(driver);
            consult.ReportPublication();
        }

        [TestMethod, TestCategory("Contact")]
        public void SendFriendMail()
        {
            driver.Url = Url.Deautos.Views.Vip.Sheet;
            var consult = new VipPage(driver);
            consult.SendFriendMail();
        }

        [TestMethod, TestCategory("Contact")]
        public void ConsultSimilarAll()
        {
            driver.Url = Url.Deautos.Views.Vip.Sheet;
            var consult = new VipPage(driver);
            consult.SimilarAll();
        }
    }
}