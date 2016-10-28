using DeAutos.Automation.Framework.DTO;
using DeAutos.Automation.Framework.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using static DeAutos.Automation.Framework.Resolver.FormData;
using static OpenQA.Selenium.Support.UI.ExpectedConditions;
using static System.TimeSpan;

namespace DeAutos.Automation.Integration.Pages.BackOffice.Listing
{
    public class ListingSponsorPage : BasePage
    {
        public ListingSponsorPage(IWebDriver driver)
            : base(driver)
        {
        }

        public bool CreateListingSponsor(SponsoringType sponsorType)
        {
            driver.FindElement(By.XPath("//*[@class='create']")).Click();

            new SelectElement(driver.FindElement(By.XPath("//*[@id='type']"))).SelectByIndex((int)sponsorType);

            driver.FindElement(By.XPath("//*[@id='txName']")).SendKeys("qaDeautos" + DateTime.Now.ToString("ddhhmmss"));

            var actions = new Actions(driver);
            actions.DoubleClick(driver.FindElement(By.XPath("//*[contains(text(),'Elige un usuario...')]"))).Build().Perform();

            driver.FindElement(By.XPath($"(//*[@id='mailSelector']//*[contains(text(),'{MultibrandUser}')])[2]")).Click();

            driver.Until(ElementIsVisible(By.XPath("//*[contains(text(),'Elige una publicación...')]")), FromSeconds(60));

            actions.DoubleClick(driver.FindElement(By.XPath("//*[contains(text(),'Elige una publicación...')]"))).Build().Perform();

            driver.FindElement(By.XPath("//*[@id='publicationSelector']//li[1]")).Click();
            driver.FindElement(By.XPath("//*[@id='locationSelector']//*[@class='jqtree-toggler btn-tree-expand']")).Click();
            driver.FindElement(By.XPath("(//*[@id='locationSelector']//*[@class='jqtree-title jqtree_common'])[1]")).Click();
            driver.FindElement(By.XPath("//*[@type='checkbox']")).Click();

            actions.Click(driver.FindElement(By.XPath($"//*//div[@id='{sponsorType.ToString().ToLower()}sAssociation']//*//input"))).SendKeys(Keys.Enter)
                   .Build().Perform();

            driver.FindElement(By.XPath("//*[@type='submit']")).Click();

            return driver.FindElement(By.XPath("//*[@class='alert alert-block alert-info']//*[contains(text(),'creado')]")).Displayed;
        }

        public bool EditListingSponsor()
        {
            driver.FindElement(By.XPath("//*/div[2]/form/div/a")).Click();

            driver.FindElement(By.XPath("//*[@id='txName']")).Clear();
            driver.FindElement(By.XPath("//*[@id='txName']")).SendKeys("qaDeautos" + DateTime.Now.ToString("ddhhmmss"));

            var actions = new Actions(driver);
            actions.Click(driver.FindElement(By.XPath("//*[@id='brandsAssociation']/div/ul/li/input"))).SendKeys(Keys.Enter).Build().Perform();

            driver.FindElement(By.XPath("//*[@type='submit']")).Click();

            return driver.FindElement(By.XPath("//*[@class='alert alert-block alert-info']//*[contains(text(),'actualizado')]")).Displayed;
        }

        public bool DeleteListingSponsor()
        {
            driver.FindElement(By.XPath("//*[@class='btn btn-danger']")).Click();

            return driver.FindElement(By.XPath("//*[@class='alert alert-block alert-info']//*[contains(text(),'eliminado')]")).Displayed;
        }
    }
}