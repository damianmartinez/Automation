using DeAutos.Automation.Framework.Extensions;
using OpenQA.Selenium;

namespace DeAutos.Automation.Integration.Pages.BackOffice.BlackList
{
    public class BlackListPage : BasePage
    {
        public BlackListPage(IWebDriver driver)
            : base(driver)
        {
        }

        public bool CreateBlacklistUser()
        {
            driver.FindElement(By.XPath("//*[@class='create']")).Click();
            driver.FindElement(By.XPath("//*[@type='email']")).SendKeys("BlacklistUser".GenerateEmail());
            driver.FindElement(By.XPath("//*[@type='submit']//*[@class='icon-ok icon-white']")).Click();
            return driver.FindElement(By.XPath("//*[@class='alert alert-block alert-info']//*[contains(text(),'creado')]")).Displayed;
        }

        public bool EditBlackListUser()
        {
            driver.FindElement(By.XPath("//*/tr[1]//*[@class='btn btn-small']")).Click();
            driver.FindElement(By.XPath("//*/div[2]/form/div/a")).Click();

            driver.FindElement(By.XPath("//*[@type='email']")).Clear();
            driver.FindElement(By.XPath("//*[@type='email']")).SendKeys("BlacklistUser".GenerateEmail());
            driver.FindElement(By.XPath("//*[@type='submit']//*[@class='icon-ok icon-white']")).Click();
            return driver.FindElement(By.XPath("//*[@class='alert alert-block alert-info']//*[contains(text(),'actualizado')]")).Displayed;
        }

        public bool DeleteBlackListUser()
        {
            driver.FindElement(By.XPath("//*/tr[1]//*[@class='btn btn-small']")).Click();
            driver.FindElement(By.XPath("//*[@class='btn btn-danger']")).Click();

            return driver.FindElement(By.XPath("//*[@class='alert alert-block alert-info']//*[contains(text(),'eliminado')]")).Displayed;
        }
    }
}