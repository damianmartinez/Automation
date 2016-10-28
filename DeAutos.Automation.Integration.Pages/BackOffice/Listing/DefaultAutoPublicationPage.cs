using DeAutos.Automation.Framework.Resolver;
using OpenQA.Selenium;
using System;

namespace DeAutos.Automation.Integration.Pages.BackOffice.Listing
{
    public class DefaultAutoPublicationPage : BasePage
    {
        public DefaultAutoPublicationPage(IWebDriver driver)
            : base(driver)
        {
        }

        public bool CreateDefaultAutoPublication()
        {
            driver.FindElement(By.XPath("//*[@class='create']")).Click();
            driver.FindElement(By.XPath("//*[@id='nameTxtArea']")).SendKeys("qaDeautos" + DateTime.Now.ToString("ddhhmmss"));
            driver.FindElement(By.XPath("//*[@id='urlTxtArea']")).SendKeys(Url.Deautos.Views.Home.Main);
            driver.FindElement(By.XPath("//*[@id='textTxtArea']")).SendKeys(FormData.Comment);
            driver.FindElement(By.XPath("//*[@type='submit']")).Click();

            return driver.FindElement(By.XPath("//*[@class='alert alert-block alert-info']//*[contains(text(),'creado')]"))
                .Displayed;
        }

        public bool EditDefaultAutoPublication()
        {
            driver.FindElement(By.XPath("//*/tr[1]//*[@class='btn btn-small']")).Click();
            driver.FindElement(By.XPath("//*/div[2]/form/div/a")).Click();

            driver.FindElement(By.XPath("//*[@id='nameTxtArea']")).Clear();
            driver.FindElement(By.XPath("//*[@id='nameTxtArea']")).SendKeys("qaDeautos" + DateTime.Now.ToString("ddhhmmss"));

            driver.FindElement(By.XPath("//*[@id='urlTxtArea']")).Clear();
            driver.FindElement(By.XPath("//*[@id='urlTxtArea']")).SendKeys(Url.Deautos.Views.Home.Main);

            driver.FindElement(By.XPath("//*[@id='textTxtArea']")).Clear();
            driver.FindElement(By.XPath("//*[@id='textTxtArea']")).SendKeys(FormData.Comment);
            driver.FindElement(By.XPath("//*[@type='submit'][1]")).Click();

            return driver.FindElement(By.XPath("//*[@class='alert alert-block alert-info']//*[contains(text(),'actualizado')]"))
                .Displayed;
        }

        public bool DeleteDefaultAutoPublication()
        {
            driver.FindElement(By.XPath("//*/tr[1]//*[@class='btn btn-small']")).Click();
            driver.FindElement(By.XPath("//*[@class='btn btn-danger']")).Click();

            return driver.FindElement(By.XPath("//*[@class='alert alert-block alert-info']//*[contains(text(),'eliminado')]"))
                .Displayed;
        }
    }
}