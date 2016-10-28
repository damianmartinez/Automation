using DeAutos.Automation.Framework.Extensions;
using OpenQA.Selenium;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace DeAutos.Automation.Integration.Pages.Promotions
{
    public class PromotionsPage : BasePage
    {
        public PromotionsPage(IWebDriver driver)
            : base(driver)
        {
        }

        public void NavigateMobile()
        {
            string oldWindow = driver.CurrentWindowHandle;

            driver.FindElement(By.CssSelector("img[alt=\"Get it on Google Play\"]")).Click();
            IsTrue(driver.Url.Equals("https://play.google.com/store/apps/details?id=com.agea.deautos"));
            driver.Navigate().Back();
            driver.FindElement(By.CssSelector("img[alt=\"Download on the App Store\"]")).Click();
            driver.SwitchTab(oldWindow);
        }
    }
}