using DeAutos.Automation.Framework.Extensions;
using DeAutos.Automation.Framework.Resolver;
using DeAutos.Automation.Integration.Pages.Listing;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace DeAutos.Automation.Integration.Pages.Common
{
    public class ListingSearchStrategy : SearchBarStrategy<ListingPage>
    {
        public override ListingPage Search(IWebDriver driver, string searchable)
        {
            if (driver.Url.Equals(Url.Deautos.Views.Home.Main))
            {
                driver.FindElement(By.XPath("//div[@id='mainContent']/div/div/div/div[6]/div[2]/div/div/h3")).Click();
            }

            driver.FindElement(By.XPath("//input[@type='text']")).SendKeys(searchable);

            driver.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class='predictiveBox']//*[@class='ui-menu-item']")),
                TimeSpan.FromSeconds(15));

            driver.FindElement(By.XPath("//*[@class='predictiveBox']//*[@class='ui-menu-item']")).Click();
            return new ListingPage(driver);
        }
    }
}