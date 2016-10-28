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

namespace DeAutos.Automation.Integration.MyAccount
{
    [TestClass]
    public class MyAccountTest : BaseIntegrationTest
    {

        [TestMethod, TestCategory("MyAccount")]
        public void Company()
        {
            var auth = new AuthPage(driver);
            var myAccount = new MyAccountPage(driver);

            driver.Url = Url.Deautos.Views.Login.Auth;
            auth.SecondaryLogin();
            myAccount.ModifyClientUser();
        }

        [TestMethod, TestCategory("MyAccount")]
        public void DataContact()
        {
            var auth = new AuthPage(driver);
            var myAccount = new MyAccountPage(driver);

            driver.Url = Url.Deautos.Views.Login.Auth;
            auth.SecondaryLogin();
            myAccount.ModifyContactData();
        }

        [TestMethod, TestCategory("MyAccount"), TestCategory("CriticalDev")]
        public void YChangePasswordContactData()
        {
            var auth = new AuthPage(driver);
            var myAccount = new MyAccountPage(driver);

            driver.Url = Url.Deautos.Views.Login.Auth;
            auth.SecondaryLogin();
            myAccount.ChangePasswordData();
        }

        [TestMethod, TestCategory("MyAccount"), TestCategory("CriticalDev")]
        public void FinalizeItemClientUser()
        {
            var auth = new AuthPage(driver);
            var myAccount = new MyAccountPage(driver);
            var republish = new PublishPage(driver);

            driver.Url = Url.Deautos.Views.Login.Auth;
            auth.SecondaryLogin(OfficialUser, OfficialUserPassword);
            if (myAccount.EndPublication().Equals(false))
            {
                if (republish.RepublishClientUser("Oficial").Equals(false))
                {
                    republish.PublishAgencyUser("Oficial", "Plan");
                }
                IsTrue(myAccount.EndPublication());
            }
        }

        [TestMethod, TestCategory("MyAccount")]
        public void Conversation()
        {
            var auth = new AuthPage(driver);
            var dialog = new MyAccountPage(driver);

            driver.Navigate().GoToUrl(Url.Deautos.Views.Login.Auth);
            auth.SecondaryLogin(OfficialUser, OfficialUserPassword);
            dialog.Consult("Answer");
            auth.LogOut();
            driver.Navigate().GoToUrl(Url.Deautos.Views.Login.Auth);
            auth.SecondaryLogin(MultibrandUser, MultibrandUserPassword);
            dialog.Consult("Reply");
        }

        [TestMethod, TestCategory("MyAccount")]
        public void ConversationOportunitie()
        {
            var auth = new AuthPage(driver);
            var conversation = new MyAccountPage(driver);

            driver.Url = Url.Deautos.Views.Login.Auth;
            auth.SecondaryLogin(OfficialUser, OfficialUserPassword);
            conversation.Consult("Oportunitie");
        }
    }
}