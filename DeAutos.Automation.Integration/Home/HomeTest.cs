using DeAutos.Automation.Framework.Extensions;
using DeAutos.Automation.Framework.Resolver;
using DeAutos.Automation.Integration.Integration;
using DeAutos.Automation.Integration.Pages.Auth;
using DeAutos.Automation.Integration.Pages.BackOffice.Catalog;
using DeAutos.Automation.Integration.Pages.Common;
using DeAutos.Automation.Integration.Pages.Header;
using DeAutos.Automation.Integration.Pages.Home;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using static OpenQA.Selenium.Support.UI.ExpectedConditions;
using static System.TimeSpan;

namespace DeAutos.Automation.Integration.Home
{
    [TestClass]
    public class HomeTest : BaseIntegrationTest
    {
        [TestMethod, TestCategory("Search")]
        public void HeaderSearchHome()
        {
            var login = new AuthPage(driver);
            var import = new CatalogPage(driver);
            var home = new HeaderPage(driver);

            driver.Url = Url.Deautos.Views.Backoffice.Main;
            login.BackOfficeLogin();
            driver.Navigate().GoToUrl(string.Concat(Url.Deautos.Views.Backoffice.Main, "solr/index"));
            import.SearchImport();
            driver.Navigate().GoToUrl(Url.Deautos.Views.Home.Main);
            home.HeaderSearch(new ListingSearchStrategy(), "Fiat");
            AreEqual("Fiat", driver.FindElement(By.XPath("//div[@id='mainContent']/div/div/div/div[3]/div/div/div/div[2]/div[2]/a/span")).Text);
        }

        [TestMethod, TestCategory("Search")]
        public void FastSearch()
        {
            driver.Url = Url.Deautos.Views.Home.Main;
            var home = new HomePage(driver);

            home.FastSearchAll("news");
            Assert.AreEqual("Nuevos", driver.FindElement(By.CssSelector("a.facet-description.pull-left")).Text);
            driver.Navigate().Back();

            home.FastSearchAll("olds");
            Assert.AreEqual("Usados", driver.FindElement(By.CssSelector("a.facet-description.pull-left")).Text);

            driver.Navigate().Back();

            home.FastSearchAll("plans");
            Assert.AreEqual("Planes de ahorro", driver.FindElement(By.CssSelector("a.facet-description.pull-left")).Text);

            driver.Navigate().Back();

        }

        [TestMethod, TestCategory("SocialAndLanding")]
        public void DeAutosFacebook()
        {
            driver.Url = Url.Deautos.Views.Home.Main;
            var home = new HomePage(driver);
            IsTrue(home.ClickDeAutosFacebook().Contains("https://www.facebook.com/deautos"));
        }

        [TestMethod, TestCategory("SocialAndLanding")]
        public void DeAutosTwitter()
        {
            driver.Url = Url.Deautos.Views.Home.Main;
            var home = new HomePage(driver);
            IsTrue(home.ClickDeAutosTwitter().Contains("https://twitter.com/deautos"));
        }

        [TestMethod, TestCategory("SocialAndLanding")]
        public void DeAutosGooglePlus()
        {
            driver.Url = Url.Deautos.Views.Home.Main;
            var home = new HomePage(driver);
            IsTrue(home.ClickDeAutosGooglePlus().Contains("https://plus.google.com/+deautos"));
        }

        [TestMethod, TestCategory("SocialAndLanding")]
        public void DeAutosYouTube()
        {
            driver.Url = Url.Deautos.Views.Home.Main;
            var home = new HomePage(driver);
            IsTrue(home.ClickDeAutosYouTube().Contains("https://www.youtube.com/user/deautos"));
        }


        [TestMethod, TestCategory("Others")]
        public void ClickComercialContact()
        {
            driver.Url = Url.Deautos.Views.Home.Main;
            var home = new HomePage(driver);
            IsTrue(home.ClickComercialContact());
        }
    }
}