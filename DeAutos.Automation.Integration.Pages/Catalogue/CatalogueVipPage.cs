using DeAutos.Automation.Framework.Extensions;
using DeAutos.Automation.Integration.Pages.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using static DeAutos.Automation.Framework.Resolver.FormData;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace DeAutos.Automation.Integration.Pages.Catalogue
{
    public class CatalogueVipPage : BasePage
    {
        private CaptchaService captchaService;

        public CatalogueVipPage(IWebDriver driver)
            : base(driver)
        {
            captchaService = new CaptchaService(driver);
        }

        public bool AskPriceCatalogueVip()
        {
            driver.FindElement(By.XPath("//*[@class='ask-price front']")).Click();

            return captchaService.FormAndCaptcha(ValidEmail, Name, PhoneNumber, Comment);
        }

        public bool AskPriceCatalogueVipVersions()
        {
            driver.FindElement(By.CssSelector("li.btn-menu-versions > span")).Click();
            driver.FindElement(By.CssSelector("li > button.ask-price")).Click();

            return captchaService.FormAndCaptcha(ValidEmail, Name, PhoneNumber, Comment);
        }

        public bool ContactCarrouselCatalogueVip()
        {
            driver.FindElement(By.CssSelector("button.ask-price.front")).Click();

            driver.FindElement(By.Name("Email")).Clear();
            driver.FindElement(By.Name("Email")).SendKeys(ValidEmail);
            driver.FindElement(By.Name("Name")).Clear();
            driver.FindElement(By.Name("Name")).SendKeys(Name);
            driver.FindElement(By.Name("Number")).Clear();
            driver.FindElement(By.Name("Number")).SendKeys(PhoneNumber);
            new SelectElement(driver.FindElement(By.Id("contactLocations"))).SelectByText("La Pampa");
            driver.FindElement(By.CssSelector("div.form-group > #msgText")).Clear();
            driver.FindElement(By.CssSelector("div.form-group > #msgText")).SendKeys(Comment);
            driver.FindElement(By.CssSelector("div.submit-button.bg-button-gradient")).Click();
            driver.FindElement(By.CssSelector("button.ask-price.front")).Click();
            return true;
        }

        public void ImageGalleryCheck()
        {
            IWebElement gallery = driver.FindElement(By.XPath("//*[@class='btn-menu-gallery']"));
            IsTrue(gallery.Displayed);
            gallery.Click();

            IWebElement image = driver.FindElement(By.XPath("//*[@class='fancybox-image']"));
            IsTrue(image.Displayed && !image.Size.IsEmpty);

            IWebElement next = driver.FindElement(By.XPath("//*[@title='Next']"));
            IsTrue(next.Displayed && !next.Size.IsEmpty);
            next.Click();

            IWebElement previous = driver.FindElement(By.XPath("//*[@title='Previous']"));
            IsTrue(previous.Displayed && !previous.Size.IsEmpty);
            previous.Click();

            IWebElement close = driver.FindElement(By.XPath("//*[@class='fancybox-item fancybox-close']"));
            IsTrue(close.Displayed && !close.Size.IsEmpty);
            close.Click();
        }

        public bool AddVersionsToComparator()
        {
            driver.FindElement(By.XPath("//*[@class='btn-menu-versions']")).Click();
            driver.FindElement(By.XPath("(//*[@class='compare-button'])[1]")).Click();
            driver.FindElement(By.XPath("(//*[@class='compare-button'])[2]")).Click();

            driver.Navigate().Refresh();

            driver.FindElement(By.XPath("//*[@class='items-counter expand-button expand']")).Click();

            IWebElement versionsList = driver.FindElement(By.XPath("//*[@style='display: list-item;']"));

            return versionsList != null;
        }
    }
}