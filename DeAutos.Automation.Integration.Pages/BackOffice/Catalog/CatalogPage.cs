using DeAutos.Automation.Framework.Extensions;
using OpenQA.Selenium;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using static OpenQA.Selenium.Support.UI.ExpectedConditions;
using static System.TimeSpan;

namespace DeAutos.Automation.Integration.Pages.BackOffice.Catalog
{
    public class CatalogPage : BasePage
    {
        public CatalogPage(IWebDriver driver)
            : base(driver)
        {
        }

        public void SearchImport()
        {
            driver.FindElement(By.Id("btnPredictiveSearchImport")).Click();
            driver.Until(ElementIsVisible(By.XPath("//div[@id='alertSolrOK']/div[3]/label")), FromSeconds(60));
            AreEqual("Mensaje:", driver.FindElement(By.XPath("//div[@id='alertSolrOK']/div[3]/label")).Text);
        }
    }
}