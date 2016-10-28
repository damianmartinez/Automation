using DeAutos.Automation.Framework.Resolver;
using OpenQA.Selenium;

namespace DeAutos.Automation.Integration.Pages.BackOffice.Listing
{
    public class PrelistingSponsorPage : BasePage
    {
        public PrelistingSponsorPage(IWebDriver driver)
            : base(driver)
        {
        }

        public bool CreatePrelistingSponsor()
        {
            driver.FindElement(By.XPath("//*[@class='create']")).Click();

            driver.FindElement(By.XPath("//*[@id='colorTxtArea']")).SendKeys(FormData.BackofficeListingSponsorTextColorHexa);
            driver.FindElement(By.XPath("//*[@id='txColorTxtArea']")).SendKeys(FormData.BackofficeListingSponsorColorHexa);
            driver.FindElement(By.XPath("//*[@name='seconds']")).SendKeys("10");
            driver.FindElement(By.XPath("//*[@type='checkbox']")).Click();
            driver.FindElement(By.XPath("//*[@class='search-field']")).Click();
            driver.FindElement(By.XPath("//*[@id='brandsAssociation']//*[@class='chosen-results']/li[1]")).Click();
            driver.FindElement(By.XPath("//*[@type='submit']")).Click();

            return driver.FindElement(By.XPath("//*[@class='alert alert-block alert-info']//*[contains(text(),'creado')]"))
                .Displayed;
        }

        public bool EditPrelistingSponsor()
        {
            driver.FindElement(By.XPath("//*/div[2]/form/div/a")).Click();

            driver.FindElement(By.XPath("//*[@id='colorTxtArea']")).Clear();
            driver.FindElement(By.XPath("//*[@id='colorTxtArea']")).SendKeys(FormData.BackofficeListingSponsorTextColorHexa);

            driver.FindElement(By.XPath("//*[@id='txColorTxtArea']")).Clear();
            driver.FindElement(By.XPath("//*[@id='txColorTxtArea']")).SendKeys(FormData.BackofficeListingSponsorColorHexa);

            driver.FindElement(By.XPath("//*[@name='seconds']")).Clear();
            driver.FindElement(By.XPath("//*[@name='seconds']")).SendKeys("10");

            driver.FindElement(By.XPath("//*[@type='checkbox']")).Click();

            driver.FindElement(By.XPath("//*[@class='search-choice-close']")).Click();
            driver.FindElement(By.XPath("//*[@class='search-field']")).Click();
            driver.FindElement(By.XPath("//*[@id='brandsAssociation']//*[@class='chosen-results']/li[1]")).Click();
            driver.FindElement(By.XPath("//*[@type='submit']")).Click();

            return driver.FindElement(By.XPath("//*[@class='alert alert-block alert-info']//*[contains(text(),'actualizado')]"))
                .Displayed;
        }

        public bool DeletePrelistingSponsor()
        {
            driver.FindElement(By.XPath("//*[@class='btn btn-danger']")).Click();

            return driver.FindElement(By.XPath("//*[@class='alert alert-block alert-info']//*[contains(text(),'eliminado')]"))
                .Displayed;
        }
    }
}