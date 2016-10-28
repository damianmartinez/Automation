using DeAutos.Automation.Framework.Resolver;
using DeAutos.Automation.Integration.Integration;
using DeAutos.Automation.Integration.Pages.Auth;
using DeAutos.Automation.Integration.Pages.BackOffice.User;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static DeAutos.Automation.Framework.Resolver.FormData;

namespace DeAutos.Automation.Integration.Auth
{
    [TestClass]
    public class RegistrationTest : BaseIntegrationTest
    {
        [TestMethod, TestCategory("Login"), TestCategory("Auth"), TestCategory("CriticalDev")]
        public void SecondaryLogin()
        {
            var auth = new AuthPage(driver);

            driver.Url = Url.Deautos.Views.Login.Auth;
            auth.SecondaryLogin(EndUser, EndUserPassword);
        }

        [TestMethod, TestCategory("Login"), TestCategory("Auth")]
        public void GoogleLogin()
        {
            var auth = new AuthPage(driver);

            driver.Url = Url.Deautos.Views.Login.Auth;
            auth.SocialLogin("Google", ValidOfficialUser, ValidOfficialUserPassword);
        }

        // no es parte de la regresion, hasta que la virtual se pueda conectar a facebook
        public void FacebookLogin()
        {
            var auth = new AuthPage(driver);

            driver.Url = Url.Deautos.Views.Login.Auth;
            auth.SocialLogin("Facebook", ValidOfficialUser, ValidOfficialUserPassword);
        }

        [TestMethod, TestCategory("Auth")]
        public void ResetPassword()
        {
            var auth = new AuthPage(driver);

            driver.Url = Url.Deautos.Views.Registers.ResetPassword;
            auth.ResetPassword(EndUser);
        }

        [TestMethod, TestCategory("Auth"), TestCategory("Register"), TestCategory("CriticalDev")]
        public void EndUserRegister()
        {
            var auth = new AuthPage(driver);

            driver.Url = Url.Deautos.Views.Registers.Register;
            auth.RegisterEndUser("Enduser");
        }

        [TestMethod, TestCategory("Auth"), TestCategory("Register"), TestCategory("CriticalDev")]
        public void OfficialUserRegister()
        {
            var auth = new AuthPage(driver);
            var agencyUser = new AgencyUserPage(driver);

            driver.Url = Url.Deautos.Views.Registers.RegisterUserTypeTwo;
            string email = auth.RegisterClientUser("Official");
            driver.Navigate().GoToUrl(string.Concat(Url.Deautos.Views.Backoffice.Main, "agencyUserCms"));
            auth.BackOfficeLogin();
            agencyUser.ActivateAgencyUser(email);
        }

        [TestMethod, TestCategory("Auth"), TestCategory("Register"), TestCategory("CriticalDev")]
        public void MultibrandUserRegister()
        {
            var auth = new AuthPage(driver);
            var agencyUser = new AgencyUserPage(driver);

            driver.Url = Url.Deautos.Views.Registers.RegisterUserTypeTwo;
            string email = auth.RegisterClientUser("Multibrand");
            driver.Navigate().GoToUrl(string.Concat(Url.Deautos.Views.Backoffice.Main, "agencyUserCms"));
            auth.BackOfficeLogin();
            agencyUser.ActivateAgencyUser(email);
        }

        [TestMethod, TestCategory("Auth"), TestCategory("Register")]
        public void RegisterAndAddSubscriptionOfficial()
        {
            var authPage = new AuthPage(driver);
            authPage.RegisterAndAddSubscription("Official", OfficialUserPassword);
        }

        [TestMethod, TestCategory("Auth"), TestCategory("Register")]
        public void RegisterAndAddSubscriptionMultibrand()
        {
            var authPage = new AuthPage(driver);
            authPage.RegisterAndAddSubscription("Multibrand", MultibrandUserPassword);
        }
    }
}