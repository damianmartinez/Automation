using OpenQA.Selenium;
using System;
using static DeAutos.Automation.Framework.Resolver.FormData;

namespace DeAutos.Automation.Integration.Pages.BackOffice.Campaign
{
    public class CampaignPage : BasePage
    {
        public CampaignPage(IWebDriver driver)
            : base(driver)
        {
        }

        private readonly string _dateTime = DateTime.Now.ToString("ddhhmmss");

        public bool CreateCampaign()
        {
            driver.FindElement(By.XPath("//*[@class='create']")).Click();

            driver.FindElement(By.XPath("//*[@name='name']")).SendKeys("qaDeautos" + _dateTime);
            driver.FindElement(By.XPath("//*[@name='urlSuffix']")).SendKeys("qaDeautos" + _dateTime);

            driver.FindElement(By.XPath("//*[@id='dueDatePicker']")).Click();
            driver.FindElement(By.CssSelector("span.ui-icon.ui-icon-circle-triangle-e")).Click();
            driver.FindElement(By.XPath("//div[@id='ui-datepicker-div']/table/tbody/tr/td[3]/a")).Click();

            driver.FindElement(By.XPath("//*[@value='Elige mails...']")).Click();
            driver.FindElement(By.XPath("//*[@value='Elige mails...']")).SendKeys(MultibrandUser);

            driver.FindElement(By.XPath("//*[@id='mailsAssociation']/div/div/ul/li/em")).Click();
            driver.FindElement(By.XPath("//*[@type='submit']")).Click();
            return driver.FindElement(By.XPath("//*[@class='alert alert-block alert-info']//*[contains(text(),'creado')]")).Displayed;
        }

        public bool EditCampaign()
        {
            driver.FindElement(By.XPath("//*/div[2]/form/div/a")).Click();

            driver.FindElement(By.XPath("//*[@name='name']")).Clear();
            driver.FindElement(By.XPath("//*[@name='name']")).SendKeys("qaDeautos" + _dateTime);

            driver.FindElement(By.XPath("//*[@name='urlSuffix']")).Clear();
            driver.FindElement(By.XPath("//*[@name='urlSuffix']")).SendKeys("qaDeautos" + _dateTime);

            driver.FindElement(By.XPath("//*[@id='dueDatePicker']")).Click();
            driver.FindElement(By.CssSelector("span.ui-icon.ui-icon-circle-triangle-e")).Click();
            driver.FindElement(By.XPath("//div[@id='ui-datepicker-div']/table/tbody/tr/td[3]/a")).Click();

            driver.FindElement(By.XPath("//*[@value='Elige mails...']")).Click();
            driver.FindElement(By.XPath("//*[@value='Elige mails...']")).SendKeys(MultibrandUser);

            driver.FindElement(By.XPath("//*[@id='mailsAssociation']/div/div/ul/li/em")).Click();
            driver.FindElement(By.XPath("//*[@type='submit']")).Click();
            return driver.FindElement(By.XPath("//*[@class='alert alert-block alert-info']//*[contains(text(),'actualizado')]")).Displayed;
        }

        public bool DeleteCampaign()
        {
            driver.FindElement(By.XPath("//*[@class='icon-trash icon-white']")).Click();
            return driver.FindElement(By.XPath("//*[@class='alert alert-block alert-info']//*[contains(text(),'eliminado')]")).Displayed;
        }
    }
}