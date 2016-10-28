using DeAutos.Automation.Framework.DTO;
using DeAutos.Automation.Framework.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using static DeAutos.Automation.Framework.Resolver.FormData;
using static OpenQA.Selenium.Support.UI.ExpectedConditions;
using static System.TimeSpan;

namespace DeAutos.Automation.Integration.Pages.Campaign
{
    public class CampaignPage : BasePage
    {
        public CampaignPage(IWebDriver driver)
            : base(driver)
        {
        }

        public bool AskPrice()
        {
            IDictionary<string, InputDto> formElements = new Dictionary<string, InputDto>();
            formElements.Add("//*[@id='name']", new InputDto { Function = By.XPath, Value = Name });
            formElements.Add("//*[@id='email']", new InputDto { Function = By.XPath, Value = ValidEmail });
            formElements.Add("//*[@id='telephone']", new InputDto { Function = By.XPath, Value = PhoneNumber });
            formElements.Add("//*[@id='message']", new InputDto { Function = By.XPath, Value = Comment });
            Assert.IsTrue(driver.FillForm(formElements));

            new SelectElement(driver.FindElement(By.XPath("//*[@id='location']"))).SelectByIndex(1);

            driver.FindElement(By.XPath("//*[@id='submitLandingCampaignForm']/span")).Click();

            IWebElement success = driver.FindElement(By.XPath("//*[@id='genericSuccessModal']/div/div"));

            driver.Until(ElementIsVisible(By.XPath("//*[@id='genericSuccessModal']/div/div")), FromSeconds(15));

            return (success.Displayed && success.Text == "¡Te has contactado con éxito!");
        }
    }
}