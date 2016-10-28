using DeAutos.Automation.Framework.DTO;
using DeAutos.Automation.Framework.Extensions;
using DeAutos.Automation.Integration.Pages.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Collections.Generic;
using static DeAutos.Automation.Framework.Resolver.FormData;
using static OpenQA.Selenium.Support.UI.ExpectedConditions;
using static System.TimeSpan;

namespace DeAutos.Automation.Integration.Pages.Catalogue
{
    public class CataloguePage : BasePage
    {
        private CaptchaService captchaService;

        public CataloguePage(IWebDriver driver)
            : base(driver)
        {
            captchaService = new CaptchaService(driver);
        }

        public void GoToVipFromCarrousel()
        {
            string oldWindow = driver.CurrentWindowHandle;

            IList<IWebElement> publication = driver.FindElements(By.XPath("//*[@class='car-image-container']/a"));
            int c = 1;
            int maxFromCarrousel = 25;

            while (publication[c].Displayed != true && c <= maxFromCarrousel)
                c++;

            publication[c].GetAttribute("href");

            publication[c].Click();

            driver.SwitchTab(oldWindow);
        }

        public bool ContactCarrouselHome()
        {
            IList<IWebElement> consult = driver.FindElements(By.XPath("//*[@id='Carousel']//*[@class='sendBtn']"));
            int count = 1;
            int maxFromCarrousel = 25;
            while (consult[count].Displayed != true && count <= maxFromCarrousel) { count++; }
            consult[count].Click();

            driver.Until(ElementIsVisible(By.XPath("//*[@id='carouselContactModal']//*[@class='modalHeaderText']")), FromSeconds(15));
            IDictionary<string, InputDto> formElements = new Dictionary<string, InputDto>();
            formElements.Add("//*[@id='contactMail']", new InputDto { Function = By.XPath, Value = ValidEmail });
            formElements.Add("//*[@id='contactName']", new InputDto { Function = By.XPath, Value = Name });
            formElements.Add("//*[@id='contactPhone']", new InputDto { Function = By.XPath, Value = PhoneNumber });
            formElements.Add("//*[@id='msgText']", new InputDto { Function = By.XPath, Value = Comment });
            Assert.IsTrue(driver.FillForm(formElements));

            IWebElement checkbox = driver.FindElement(By.XPath("//*[@id='contactCheck']"));

            if (!checkbox.Selected)
                checkbox.Click();

            driver.FindElement(By.XPath("//*[@id='carouselContactModal']//*[@class='modalBtntext']")).Click();
            captchaService.IsCaptchaValid(By.XPath("//*[@id='sentModal']/div[1]/div"));
            return true;
        }
    }
}