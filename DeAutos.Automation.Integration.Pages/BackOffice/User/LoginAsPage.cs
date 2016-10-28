using DeAutos.Automation.Framework.Extensions;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using static OpenQA.Selenium.Support.UI.ExpectedConditions;
using static System.TimeSpan;

namespace DeAutos.Automation.Integration.Pages.BackOffice.User
{
    public class LoginAsPage : BasePage
    {
        public LoginAsPage(IWebDriver driver)
            : base(driver)
        {
        }

        public void LoginAsUser(string email)
        {
            string oldWindow = driver.CurrentWindowHandle;

            driver.FindElement(By.XPath("//*[@type='email']")).SendKeys(email);
            driver.FindElement(By.XPath("//*[@type='submit']")).Click();

            var window = new ReadOnlyCollection<string>(driver.WindowHandles);

            IEnumerator<string> iteration = window.GetEnumerator();

            while (iteration.MoveNext() && iteration.Current == oldWindow)
            {
            }

            if (iteration.Current != default(string))
            {
                driver.SwitchTo().Window(iteration.Current);
            }

            driver.Until(ElementIsVisible(By.CssSelector("h1.account-name.ng-binding")), FromSeconds(120));
            AreEqual("Mi Cuenta", driver.FindElement(By.CssSelector("h1.account-name.ng-binding")).Text);

        }
    }
}