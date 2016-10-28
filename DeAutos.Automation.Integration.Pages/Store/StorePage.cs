using DeAutos.Automation.Framework.DTO;
using DeAutos.Automation.Framework.Extensions;
using DeAutos.Automation.Integration.Pages.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.Threading;
using static DeAutos.Automation.Framework.Resolver.FormData;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using static OpenQA.Selenium.Support.UI.ExpectedConditions;
using static System.TimeSpan;

namespace DeAutos.Automation.Integration.Pages.Store
{
    public class StorePage : BasePage
    {

        public StorePage(IWebDriver driver)
            : base(driver)
        {

        }

        public void ContactConcessionary()
        {
            driver.FindElement(By.XPath("//div[@id='mainContent']/div/div/div/div[2]/div[2]/div[4]/button")).Click();
            DataCaptchaStore();
        }

        public void ContactConcessionaryAd()
        {
            var action = new Actions(driver);

            IWebElement ad = driver.FindElement(By.XPath("//div[@id='publications']/ul/li[1]/div[2]/div[2]"));
            action.Click(ad).MoveToElement(ad).Click(ad).Build().Perform();
            driver.FindElement(By.XPath("//div[@id='publications']/ul/li/div[3]/button")).Click();
            DataCaptchaStore();
        }

        private void DataCaptchaStore()
        {
            driver.FindElement(By.Id("email-consult-form")).Clear();
            driver.FindElement(By.Id("email-consult-form")).SendKeys("asdadasa@asdad.com");
            driver.FindElement(By.Id("name-consult-form")).Clear();
            driver.FindElement(By.Id("name-consult-form")).SendKeys("asdsad");
            driver.FindElement(By.Id("phone-consult-form")).Clear();
            driver.FindElement(By.Id("phone-consult-form")).SendKeys("4564665");
            driver.FindElement(By.Id("message-consult-form")).Clear();
            driver.FindElement(By.Id("message-consult-form")).SendKeys("asdasdasdjkasjdkladlaksd");
            driver.FindElement(By.XPath("(//button[@type='button'])[7]")).Click();

            Thread.Sleep(2000);
            var title = driver.FindElement(By.Id("contactModalLabel")).Text;

            if (!title.Equals("Código de verificación"))
            {
                AreEqual("¡Tu Consulta se envió con éxito!", driver.FindElement(By.Id("contactModalLabel")).Text);
            }
        }

        public bool InformationPresence()
        {
            IWebElement agencyName = driver.FindElement(By.CssSelector("h1.agency-name.pull-left"));
            IsTrue(agencyName.Displayed && agencyName.Text.Length > 0);

            IWebElement streetAddress = driver.FindElement(By.CssSelector("div.contact > span"));
            IsTrue(streetAddress.Displayed && streetAddress.Text.Length > 0);

            IWebElement telephone = driver.FindElement(By.CssSelector("span.telephone"));
            IsTrue(telephone.Displayed && telephone.Text.Length > 0);

            IWebElement description = driver.FindElement(By.CssSelector("div.col-lg-12.description > span"));

            return description.Displayed && description.Text.Length > 0;
        }

        public void Map()
        {
            driver.FindElement(By.XPath("(//button[@type='button'])[4]")).Click();
            AreEqual("Ubicación", driver.FindElement(By.Id("contactModalLabel")).Text);
        }
    }
}