using DeAutos.Automation.Framework.Conditions;
using DeAutos.Automation.Framework.DTO;
using DeAutos.Automation.Framework.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace DeAutos.Automation.Integration.Pages.Common
{
    public class CaptchaService
    {
        private IWebDriver driver;

        public CaptchaService(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool FormAndCaptcha(string contactMail, string contactName, string contactPhone, string msgText)
        {
            driver.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='contactModal']//*[@class='header']")), TimeSpan.FromSeconds(15));
            IDictionary<string, InputDto> formElements = new Dictionary<string, InputDto>();
            formElements.Add("//*[@id='contactModal']//*[@id='contactMail']", new InputDto { Function = By.XPath, Value = contactMail });
            formElements.Add("//*[@id='contactModal']//*[@id='contactName']", new InputDto { Function = By.XPath, Value = contactName });
            formElements.Add("//*[@id='contactModal']//*[@id='contactPhone']", new InputDto { Function = By.XPath, Value = contactPhone });
            formElements.Add("//*[@id='contactModal']//*[@id='msgText']", new InputDto { Function = By.XPath, Value = msgText });
            Assert.IsTrue(driver.FillForm(formElements));

            driver.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='contactLocations']/option[2]")), TimeSpan.FromSeconds(15));
            new SelectElement(driver.FindElement(By.XPath("//*[@id='contactLocations']"))).SelectByIndex(2);
            driver.FindElement(By.XPath("//*[contains(@class,'submit-button')]")).Click();
            return IsCaptchaValid(By.XPath("//*[@id='genericSuccessModal']"));
        }

        public bool IsCaptchaValid(By elementSuccess, By elementCaptcha = null)
        {
            if (elementCaptcha == null) { elementCaptcha = By.XPath("//*[@id='captchaModal']/div[1]/div"); }
            var captcha = driver.FindElement(elementCaptcha);
            var success = driver.FindElement(elementSuccess);

            if (driver.IsElementPresent(By.XPath("//*[@id='contactModal']")))
            {
                driver.Until(
                driver.IsElementPresent(By.XPath("//*[@id='contactModal']"))
                    ? ExpectedConditionsCustom.ElementIsNotVisible(By.XPath("//*[@id='carouselContactModal']"))
                    : ExpectedConditionsCustom.ElementIsNotVisible(By.XPath("//*[@id='contactModal']")),
                TimeSpan.FromSeconds(20));
            }
            else
            {
                driver.IsElementPresent(By.XPath("//*[@id='modal']/div/div"));
            }

            return success.Displayed || captcha.Displayed;
        }
    }
}