using OpenQA.Selenium;
using System;
using System.Drawing;

namespace DeAutos.Automation.Integration.Pages.BackOffice
{
    public class BackOfficeIndexPage : BasePage
    {
        public BackOfficeIndexPage(IWebDriver driver)
            : base(driver)
        {
        }

        public bool NavigationCheck()
        {
            string navigationXPath = "(//*[@class='nav']//a)[contains(@href,'/')]";
            int amount = driver.FindElements(By.XPath(navigationXPath)).Count;

            driver.Manage().Window.Size = new Size(900, 3000);

            for (int nav = 1; nav <= amount; nav++)
            {
                string navigationButtonXPath = navigationXPath + "[" + nav + "]";

                driver.FindElement(By.XPath("//*[contains(@class,'btn btn-navbar')]")).Click();

                IWebElement navigationButton = driver.FindElement(By.XPath(navigationButtonXPath));
                string destinationUrl = navigationButton.GetAttribute("href");

                navigationButton.Click();

                if (!driver.Url.Contains(destinationUrl))
                {
                    Console.WriteLine(string.Concat("El botón '", navigationButton.GetAttribute("textContent"), "'\nque debía dirigir al usuario a ", destinationUrl, "\n, lo llevó a ", driver.Url, "\n"));
                    return false;
                }
            }

            return true;
        }
    }
}