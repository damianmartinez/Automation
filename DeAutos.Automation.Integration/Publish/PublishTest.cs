using DeAutos.Automation.Framework.Resolver;
using DeAutos.Automation.Integration.Integration;
using DeAutos.Automation.Integration.Pages.Auth;
using DeAutos.Automation.Integration.Pages.MyAccount;
using DeAutos.Automation.Integration.Pages.Publish;
using DeAutos.Automation.Integration.Pages.Vip;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using static DeAutos.Automation.Framework.Resolver.FormData;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace DeAutos.Automation.Integration.Publish
{
    [TestClass]
    public class PublishTest : BaseIntegrationTest
    {
        [TestMethod, TestCategory("Publish"), TestCategory("CriticalDev")]
        public void EndUserLogOut()
        {
            driver.Url = Url.Deautos.Views.MyAccount.Publish;
            var publish = new PublishPage(driver);
            publish.PublishEndUser("EndUser", "Used");
        }

        [TestMethod, TestCategory("Publish"), TestCategory("CriticalDev")]
        public void OficialNew()
        {
            driver.Url = Url.Deautos.Views.MyAccount.Publish;
            var publish = new PublishPage(driver);
            publish.PublishAgencyUser("Oficial", "New");
        }

        [TestMethod, TestCategory("Publish"), TestCategory("CriticalDev")]
        public void OficialPlan()
        {
            driver.Url = Url.Deautos.Views.MyAccount.Publish;
            var publish = new PublishPage(driver);
            publish.PublishAgencyUser("Oficial", "Plan");
        }

        [TestMethod, TestCategory("Publish"), TestCategory("CriticalDev")]
        public void MultibrandUsed()
        {
            driver.Url = Url.Deautos.Views.MyAccount.Publish;
            var login = new AuthPage(driver);
            var publish = new PublishPage(driver);
            publish.PublishAgencyUser("Multibrand", "Used");
        }

        [TestMethod, TestCategory("Publish")]
        public void ModifyItemClientUser()
        {
            var auth = new AuthPage(driver);
            var myAccount = new PublishPage(driver);

            driver.Url = Url.Deautos.Views.Login.Auth;
            auth.SecondaryLogin(OfficialUser, OfficialUserPassword);
            if (myAccount.ModifyItem().Equals(false))
            {
                if (myAccount.RepublishClientUser("Oficial").Equals(false))
                {
                    myAccount.PublishAgencyUser("Oficial", "Plan");
                }
                IsTrue(myAccount.ModifyItem());
            }
        }

        [TestMethod, TestCategory("Publish"), TestCategory("CriticalDev")]
        public void RepublishClientUser()
        {
            var auth = new AuthPage(driver);
            var republish = new PublishPage(driver);
            var myAccount = new MyAccountPage(driver);

            driver.Url = Url.Deautos.Views.Login.Auth;
            auth.SecondaryLogin(OfficialUser, OfficialUserPassword);
            if (republish.RepublishClientUser("Oficial").Equals(false))
            {
                if (myAccount.EndPublication().Equals(false))
                {
                    republish.PublishAgencyUser("Oficial", "Plan");
                    IsTrue(myAccount.EndPublication());
                }
                IsTrue(republish.RepublishClientUser("Oficial"));
            }
        }

        [TestMethod, TestCategory("Publish")]
        public void CopyItemClientUser()
        {
            var auth = new AuthPage(driver);
            var myAccount = new PublishPage(driver);

            driver.Url = Url.Deautos.Views.Login.Auth;
            auth.SecondaryLogin(OfficialUser, OfficialUserPassword);
            if (myAccount.CopyItem().Equals(false))
            {
                if (myAccount.RepublishClientUser("Oficial").Equals(false))
                {
                    myAccount.PublishAgencyUser("Oficial", "Plan");
                }
                IsTrue(myAccount.CopyItem());
            }
        }
    }
}

/*
MULTIMARCA

2.500	AB10_MOK
2.500	APLM150
2.500	AB 22 M 2011

OFICIAL

2.500	AB1 _OK_11
2.500	ABO_10_0K
2.500	Pack SP 20
2.500	ABPLO150
*/
