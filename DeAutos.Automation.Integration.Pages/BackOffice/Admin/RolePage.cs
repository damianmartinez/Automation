using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DeAutos.Automation.Integration.Pages.BackOffice.Admin
{
    public class RolePage : BasePage
    {
        public RolePage(IWebDriver driver)
            : base(driver)
        {
        }

        public bool AddRole()
        {
            new SelectElement(driver.FindElement(By.XPath("//*[@name='userSelect']"))).SelectByValue("20");
            driver.FindElement(By.XPath("//*[@class='btn removeall']")).Click();

            new SelectElement(driver.FindElement(By.XPath("//*[@name='duallistbox_helper1']"))).SelectByValue("8");
            driver.FindElement(By.XPath("//*[@type='submit']")).Click();
            return driver.FindElement(By.XPath("//*[@class='alert alert-success']")).Displayed;
        }
    }
}