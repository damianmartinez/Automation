using DeAutos.Automation.Framework.Extensions;
using DeAutos.Automation.Framework.Resolver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using static DeAutos.Automation.Framework.Resolver.FormData;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using static System.String;

namespace DeAutos.Automation.Integration.Pages.BackOffice.User
{
    public class AgencyUserPage : BackOfficeIndexPage
    {
        public AgencyUserPage(IWebDriver driver)
            : base(driver)
        {
        }

        public void ActivateAgencyUser(string agencyUserEmail)
        {
            var random = new Random();

            driver.FindElement(By.Name("email")).SendKeys(agencyUserEmail);
            driver.FindElement(By.XPath("//*[@type='submit']")).Click();
            driver.FindElement(By.XPath("(//*[@id='list-peopleContactData']//*/td[8]/a)[1]")).Click();

            driver.FindElement(By.Id("siteSapAdvertiserCode")).Clear();
            driver.FindElement(By.Id("siteSapAdvertiserCode")).SendKeys(random.Next(1000, 9999).ToString());

            driver.FindElement(By.Id("sapBillingCode")).Clear();
            driver.FindElement(By.Id("sapBillingCode")).SendKeys(random.Next(1000, 9999).ToString());

            driver.FindElement(By.Id("taxName")).Clear();
            driver.FindElement(By.Id("taxName")).SendKeys(CompanyName);

            driver.FindElement(By.Id("cuit")).Clear();
            driver.FindElement(By.Id("cuit")).SendKeys("30707001735");

            driver.FindElement(By.Id("taxStreetNumber")).Clear();
            driver.FindElement(By.Id("taxStreetNumber")).SendKeys("100");

            driver.FindElement(By.Id("taxZipCode")).Clear();
            driver.FindElement(By.Id("taxZipCode")).SendKeys("1139");

            driver.FindElement(By.Id("clientPhoneArea")).Clear();
            driver.FindElement(By.Id("clientPhoneArea")).SendKeys(AreaPhoneNumber);

            driver.FindElement(By.Id("clientPhoneNumber")).Clear();
            driver.FindElement(By.Id("clientPhoneNumber")).SendKeys(PhoneNumber);

            driver.FindElement(By.Id("siteStreetNumber")).Clear();
            driver.FindElement(By.Id("siteStreetNumber")).SendKeys("1000");

            driver.FindElement(By.Id("siteZipCode")).Clear();
            driver.FindElement(By.Id("siteZipCode")).SendKeys("1139");

            driver.FindElement(By.XPath("//*[@class='span8']//*[@id='update']")).Click();

            IsTrue(driver.FindElement(By.XPath("//*[@id='update']/div[3]/div/div[1]/div/div[2]/strong/em")).Text.Contains("Activo"));
        }

        public void DisableSubscription(string agencyUserEmail)
        {
            driver.Url = Concat(Url.Deautos.Views.Backoffice.Main, "agencyUserCms");

            driver.FindElement(By.XPath("//*[@name='email']")).SendKeys(agencyUserEmail);
            driver.FindElement(By.XPath("//*[@type='submit']")).Click();
            driver.FindElement(By.XPath("(//*[@id='list-peopleContactData']//*/td[8]/a)[1]")).Click();
            driver.FindElement(By.XPath("//*[@class='btn btn-warning']")).Click();

            driver.GoToLastPage();

            var xpathState = "//*[@id='list-peopleContactData']/table//*[contains(text(), '{0}')]";

            if (driver.IsElementPresent(By.XPath(Format(xpathState, "Pendiente"))))
            {
                driver.FindElement(By.XPath(Format(xpathState, "Cancelar abono"))).Click();
            }
            else
            {
                if (driver.IsElementPresent(By.XPath(Format(xpathState, "Activo"))))
                {
                    driver.FindElement(By.XPath(Format(xpathState, "Finalizar Abono"))).Click();
                }
            }
        }

        public void CreateSubscription(string agencyUserEmail)
        {
            driver.Url = Concat(Url.Deautos.Views.Backoffice.Main, "agencyUserCms");

            driver.FindElement(By.XPath("//*[@name='email']")).SendKeys(agencyUserEmail);
            driver.FindElement(By.XPath("//*[@type='submit']")).Click();

            IsTrue(driver.IsElementPresent(By.XPath("(//*[@id='list-peopleContactData']//*/td[8]/a)[1]")));

            driver.FindElement(By.XPath("(//*[@id='list-peopleContactData']//*/td[8]/a)[1]")).Click();
            driver.FindElement(By.XPath("//*[@class='btn btn-warning']")).Click();
            driver.FindElement(By.XPath("//*[@name='_action_createSuscription']")).Click();
            driver.FindElement(By.XPath("//*[@id='name']")).SendKeys(Name);
            driver.FindElement(By.XPath("//*[@id='duration']")).SendKeys("1");
            driver.FindElement(By.XPath("//*[@id='qty']")).SendKeys("1");

            if (agencyUserEmail.Contains("Multibrand"))
            {
                new SelectElement(driver.FindElement(By.Id("productSelected"))).SelectByText("AB10_MOK");
                driver.FindElement(By.XPath("//*[@id='btnAddSuscriptionItem']")).Click();

                new SelectElement(driver.FindElement(By.Id("productSelected"))).SelectByText("APLM150");
                driver.FindElement(By.XPath("//*[@id='btnAddSuscriptionItem']")).Click();

                new SelectElement(driver.FindElement(By.Id("productSelected"))).SelectByText("AB 22 M 2011");
                driver.FindElement(By.XPath("//*[@id='btnAddSuscriptionItem']")).Click();
            }
            else
            {
                if (agencyUserEmail.Contains("Official"))
                {
                    new SelectElement(driver.FindElement(By.Id("productSelected"))).SelectByText("AB1 _OK_11");
                    driver.FindElement(By.XPath("//*[@id='btnAddSuscriptionItem']")).Click();

                    new SelectElement(driver.FindElement(By.Id("productSelected"))).SelectByText("ABO_10_0K");
                    driver.FindElement(By.XPath("//*[@id='btnAddSuscriptionItem']")).Click();

                    new SelectElement(driver.FindElement(By.Id("productSelected"))).SelectByText("Pack SP 20");
                    driver.FindElement(By.XPath("//*[@id='btnAddSuscriptionItem']")).Click();

                    new SelectElement(driver.FindElement(By.Id("productSelected"))).SelectByText("ABPLO150");
                    driver.FindElement(By.XPath("//*[@id='btnAddSuscriptionItem']")).Click();
                }
                else
                {
                    driver.FindElement(By.XPath("//*[@id='btnAddSuscriptionItem']")).Click();
                }
            }

            driver.FindElement(By.XPath("//*[@name='save']")).Click();

            driver.GoToLastPage();

            var xpathState = "//*[@id='list-peopleContactData']/table//*[contains(text(), '{0}')]";
            driver.FindElement(By.XPath(Format(xpathState, "Activar"))).Click();

            driver.GoToLastPage();

            IsTrue(driver.IsElementPresent(By.XPath(Format(xpathState, "Activo"))));
        }
    }
}