using DeAutos.Automation.Framework.DTO;
using DeAutos.Automation.Framework.Resolver;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace DeAutos.Automation.Integration.Pages.BackOffice.Listing
{
    public class StrategicAutoPublicationPage : BasePage
    {
        public StrategicAutoPublicationPage(IWebDriver driver)
            : base(driver)
        {
        }

        public bool CreateStrategicAutoPublication(SponsoringType sponsorType, string brandOrModelToCreate = null)
        {
            driver.FindElement(By.XPath("//*[@class='create']")).Click();
            driver.FindElement(By.XPath("//*[@id='nameTxtArea']")).SendKeys("qaDeautos" + DateTime.Now.ToString("ddhhmmss"));

            new SelectElement(driver.FindElement(By.XPath("//*[@id='type']"))).SelectByIndex((int)sponsorType);

            driver.FindElement(By.Id("inputPic")).SendKeys(Env.ImagesSponsor);

            driver.FindElement(By.XPath("//*[@id='urlTxtArea']")).SendKeys(Url.Deautos.Views.Home.Main);
            driver.FindElement(By.XPath("//*[@id='textTxtArea']")).SendKeys(FormData.Comment);

            driver.FindElement(By.Id("enabled")).Click();

            string brandOrModelAssociation = $"//*//div[@id='{sponsorType.ToString().ToLower()}sAssociation']//*//input";

            driver.FindElement(By.XPath(brandOrModelAssociation)).Click();

            if (brandOrModelToCreate != null)
            {
                driver.FindElement(By.XPath(brandOrModelAssociation)).SendKeys(brandOrModelToCreate);
            }

            driver.FindElement(By.XPath(brandOrModelAssociation)).SendKeys(Keys.Enter);

            driver.FindElement(By.XPath("//*[@type='submit']")).Click();

            return driver.FindElement(By.XPath("//*[@class='alert alert-block alert-info']//*[contains(text(),'creado')]")).Displayed;
        }


        public bool EditStrategicAutoPublication()
        {
            driver.FindElement(By.XPath("//*/div[2]/form/div/a")).Click();

            driver.FindElement(By.XPath("//*[@id='nameTxtArea']")).Clear();
            driver.FindElement(By.XPath("//*[@id='nameTxtArea']")).SendKeys("qaDeautos" + DateTime.Now.ToString("ddhhmmss"));

            driver.FindElement(By.XPath("//*[@id='urlTxtArea']")).Clear();
            driver.FindElement(By.XPath("//*[@id='urlTxtArea']")).SendKeys(Url.Deautos.Views.Home.Main);

            driver.FindElement(By.XPath("//*[@id='textTxtArea']")).Clear();
            driver.FindElement(By.XPath("//*[@id='textTxtArea']")).SendKeys(FormData.Comment);

            driver.FindElement(By.Id("enabled")).Click();
            driver.FindElement(By.CssSelector("b.jqtree-toggler.btn-tree-expand")).Click();
            driver.FindElement(By.XPath("//div[@id='locations']/ul/li/ul/li/div")).Click();

            var actions = new Actions(driver);

            actions.Click(driver.FindElement(By.XPath("//*//div[@id='brandsAssociation']//*//input")))
                .SendKeys(Keys.Enter)
                .Build()
                .Perform();

            driver.FindElement(By.XPath("//*[@type='submit']")).Click();

            return driver.FindElement(By.XPath("//*[@class='alert alert-block alert-info']//*[contains(text(),'actualizado')]"))
                .Displayed;
        }

        public bool DeleteStrategicAutoPublication()
        {
            driver.FindElement(By.XPath("//*[@class='btn btn-danger']")).Click();

            return driver.FindElement(By.XPath("//*[@class='alert alert-block alert-info']//*[contains(text(),'eliminado')]"))
                .Displayed;
        }
    }
}