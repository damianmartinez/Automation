using DeAutos.Automation.Framework.Extensions;
using OpenQA.Selenium;
using static DeAutos.Automation.Framework.Resolver.FormData;

namespace DeAutos.Automation.Integration.Pages.BackOffice.Admin
{
    public class BackOfficeUserPage : BasePage
    {
        public BackOfficeUserPage(IWebDriver driver)
            : base(driver)
        {
        }

        public bool CreateBackOfficeUser()
        {
            driver.FindElement(By.XPath("//*[@class='create']")).Click();

            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys("BackOfficeUser".GenerateEmail());
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys(EndUserPassword);
            driver.FindElement(By.XPath("//*[@type='submit']")).Click();
            return driver.FindElement(By.XPath("//*[@class='alert alert-block alert-info']//*[contains(text(),'creado')]")).Displayed;
        }

        public bool DeleteBackOfficeUser()
        {
            driver.FindElement(By.XPath("//*[@class='btn btn-danger']")).Click();
            return driver.FindElement(By.XPath("//*[@class='alert alert-block alert-info']//*[contains(text(),'eliminado')]")).Displayed;
        }
    }
}