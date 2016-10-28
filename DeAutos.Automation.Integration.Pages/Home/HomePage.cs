using DeAutos.Automation.Framework.Extensions;
using DeAutos.Automation.Integration.Pages.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace DeAutos.Automation.Integration.Pages.Home
{
    public class HomePage : BasePage
    {
        private CaptchaService captchaService;

        public HomePage(IWebDriver driver)
            : base(driver)
        {
            captchaService = new CaptchaService(driver);
        }

        public void ClickSearch()
        {
            IWebElement listing = driver.FindElement(By.XPath("//div[@class='sort-container']"));
            driver.FindElement(By.XPath("//*[contains(@class,'btn-submit-search')]")).Click();
            IsTrue(listing.Displayed);
        }

        public void AssistedSearch()
        {
            driver.FindElement(By.LinkText("Búsqueda Avanzada")).Click();

            new SelectElement(driver.FindElement(By.XPath("//select[@id='brand-search-field']"))).SelectByText("Aleko");
            driver.FindElement(By.XPath("//input[@id='input-km-from-field']")).Clear();
            driver.FindElement(By.XPath("//input[@id='input-km-from-field']")).SendKeys("50");
            driver.FindElement(By.XPath("//input[@id='input-km-to-field']")).Clear();
            driver.FindElement(By.XPath("//input[@id='input-km-to-field']")).SendKeys("20000");
            driver.FindElement(By.XPath("//input[@id='input-year-from-field']")).Clear();
            driver.FindElement(By.XPath("//input[@id='input-year-from-field']")).SendKeys("1995");
            driver.FindElement(By.XPath("//input[@id='input-year-to-field']")).Clear();
            driver.FindElement(By.XPath("//input[@id='input-year-to-field']")).SendKeys("2014");
            driver.FindElement(By.XPath("//input[@id='input-price-from-field']")).Clear();
            driver.FindElement(By.XPath("//input[@id='input-price-from-field']")).SendKeys("20000");
            driver.FindElement(By.XPath("//input[@id='input-price-to-field']")).Clear();
            driver.FindElement(By.XPath("//input[@id='input-price-to-field']")).SendKeys("250000");
            new SelectElement(driver.FindElement(By.XPath("//select[@id='provincia-search-field']"))).SelectByText("Buenos Aires");
            driver.FindElement(By.XPath("(//button[@type='submit'])[3]")).Click();
        }

        public void FastSearchAll(string typeBotton)
        {
           driver.FindElement(By.CssSelector("a.link-foot-"+ typeBotton + "")).Click();
          

        }

        public string ClickDeAutosFacebook()
        {
            IWebElement facebook = driver.FindElement(By.CssSelector("span.icon-facebook-circle"));

            string oldWindow = driver.CurrentWindowHandle;
            IsTrue(facebook.Displayed);
            facebook.Click();
            driver.SwitchTab(oldWindow);
            return driver.Url;
        }

        public string ClickDeAutosTwitter()
        {
            IWebElement twitter = driver.FindElement(By.CssSelector("span.icon-twitter-circle"));
            ;
            string oldWindow = driver.CurrentWindowHandle;
            IsTrue(twitter.Displayed);
            twitter.Click();
            driver.SwitchTab(oldWindow);
            return driver.Url;
        }

        public string ClickDeAutosGooglePlus()
        {
            IWebElement googlePlus = driver.FindElement(By.CssSelector("span.icon-googleplus-circle"));
            ;
            string oldWindow = driver.CurrentWindowHandle;
            IsTrue(googlePlus.Displayed);
            googlePlus.Click();
            driver.SwitchTab(oldWindow);
            return driver.Url;
        }

        public string ClickDeAutosYouTube()
        {
            IWebElement youTube = driver.FindElement(By.CssSelector("span.icon-youtube-circle"));

            string oldWindow = driver.CurrentWindowHandle;
            IsTrue(youTube.Displayed);
            youTube.Click();
            driver.SwitchTab(oldWindow);
            return driver.Url;
        }

       
        public void VisitCatalogue()
        {
            string oldWindow = driver.CurrentWindowHandle;

            var action = new Actions(driver);
            IWebElement visitCatalogue = driver.FindElement(By.XPath("//*[contains(text(),'Visitá el Catálogo')]/.."));
            action.MoveToElement(visitCatalogue).MoveByOffset(0, -200).Build().Perform();
            visitCatalogue.Click();
            driver.SwitchTab(oldWindow, "Catálogo de autos", titlePartialMatch: true);
        }

        public bool VisitCatalogueVip()
        {
            string firstCarouselElement = "(//*[@id='catalog-container']//*[@class='jcarousel']//li)[1]/a";
            string link = driver.FindElement(By.XPath(firstCarouselElement)).GetAttribute("href");
            driver.Navigate().GoToUrl(link);
            return link == driver.Url;
        }

        public bool VisitCatalogueBrand()
        {
            string firstBrandXPath = "//*[@id='catalog-container']//*[@class='brand-list-container']//*[@class='item'][1]";
            IWebElement firstBrand = driver.FindElement(By.XPath(firstBrandXPath));
            string link = driver.FindElement(By.XPath(String.Concat(firstBrandXPath, "/a"))).GetAttribute("href");
            var action = new Actions(driver);
            action.MoveToElement(firstBrand).MoveByOffset(0, -200).Build().Perform();
            firstBrand.Click();
            return link == driver.Url;
        }

        public bool ClickComercialContact()
        {
            driver.FindElement(By.XPath("//div[@id='mainContent']/div/div/div/div[6]/div[3]/div/div/button")).Click();
            return driver.IsElementPresent(By.XPath("//div[@id='comercialInfoModal']/div/div/div/h4"));
        }
    }
}