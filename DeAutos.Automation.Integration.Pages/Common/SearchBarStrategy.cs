using OpenQA.Selenium;

namespace DeAutos.Automation.Integration.Pages.Common
{
    public abstract class SearchBarStrategy<T>
    {
        public abstract T Search(IWebDriver driver, string searchable);
    }
}