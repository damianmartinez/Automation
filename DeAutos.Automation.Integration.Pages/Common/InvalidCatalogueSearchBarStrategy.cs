using DeAutos.Automation.Framework.Resolver;
using OpenQA.Selenium;

namespace DeAutos.Automation.Integration.Pages.Common
{
    public class InvalidCatalogueSearchStrategy : SearchBarStrategy<bool>
    {
        public override bool Search(IWebDriver driver, string unsearchable)
        {
            driver.FindElement(By.XPath("//div[@id='wrapper']/header/nav/div[2]/div[3]/div/form/div/input")).SendKeys(unsearchable);
            driver.FindElement(By.XPath("//div[@id='wrapper']/header/nav/div[2]/div[3]/div/form/div/button")).Click();

            return string.Equals(driver.Url, Url.Deautos.Views.Catalog.Main);
        }
    }
}