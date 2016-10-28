using DeAutos.Automation.Framework.Extensions;
using DeAutos.Automation.Framework.Resolver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace DeAutos.Automation.Integration.Pages.Landing
{
    public class LandingPage : BasePage
    {
        public LandingPage(IWebDriver driver)
            : base(driver)
        {
        }

        public void ContactLanding()
        {
            driver.FindElement(By.XPath("//*[@id='mainWrapper']/div/div[2]/div[1]/a/div/span")).Click();

            driver.FindElement(By.Id("name")).SendKeys(FormData.Name);
            driver.FindElement(By.Id("email")).SendKeys(FormData.ValidEmail);
            driver.FindElement(By.Id("phone")).SendKeys(FormData.PhoneNumber);

            new SelectElement(driver.FindElement(By.Id("location"))).SelectByIndex(2);
            new SelectElement(driver.FindElement(By.Id("modelId"))).SelectByIndex(2);

            driver.FindElement(By.Id("comment")).SendKeys(FormData.Comment);

            driver.FindElement(By.Id("submitForm")).Click();

            driver.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div.subtituloContainer > p")), TimeSpan.FromSeconds(10));

            AreEqual("Listado de Agencias", driver.FindElement(By.CssSelector("div.backbar > span")).Text);
        }
    }
}