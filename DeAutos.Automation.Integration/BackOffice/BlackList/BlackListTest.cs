using DeAutos.Automation.Framework.Resolver;
using DeAutos.Automation.Integration.Integration;
using DeAutos.Automation.Integration.Pages.Auth;
using DeAutos.Automation.Integration.Pages.BackOffice.BlackList;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace DeAutos.Automation.Integration.BackOffice.BlackList
{
    [TestClass]
    public class BlackListTest : BaseIntegrationTest
    {
        [TestMethod, TestCategory("Backoffice")]
        public void CreateBlacklistUser()
        {
            var login = new AuthPage(driver);
            var blackList = new BlackListPage(driver);

            driver.Url = string.Concat(Url.Deautos.Views.Backoffice.Main, "blackListMails");
            login.BackOfficeLogin();
            IsTrue(blackList.CreateBlacklistUser());
        }

        [TestMethod, TestCategory("Backoffice")]
        public void EditBlackListUser()
        {
            var login = new AuthPage(driver);
            var blackList = new BlackListPage(driver);

            driver.Url = string.Concat(Url.Deautos.Views.Backoffice.Main, "blackListMails");
            login.BackOfficeLogin();
            IsTrue(blackList.EditBlackListUser());
        }

        [TestMethod, TestCategory("Backoffice")]
        public void DeleteBlackListUser()
        {
            var login = new AuthPage(driver);
            var blackList = new BlackListPage(driver);

            driver.Url = string.Concat(Url.Deautos.Views.Backoffice.Main, "blackListMails");
            login.BackOfficeLogin();
            IsTrue(blackList.DeleteBlackListUser());
        }
    }
}