using DeAutos.Automation.Integration.Pages.Common;
using OpenQA.Selenium;

namespace DeAutos.Automation.Integration.Pages.Header
{
    public class HeaderPage : BasePage
    {
        public HeaderPage(IWebDriver driver)
            : base(driver)
        {
        }

        public void ClickLogo()
        {
            driver.FindElement(By.CssSelector("h1.logo-da-autos")).Click();
        }

        public T HeaderSearch<T>(SearchBarStrategy<T> strategy, string searchable)
        {
            return strategy.Search(driver, searchable);
        }
    }
}