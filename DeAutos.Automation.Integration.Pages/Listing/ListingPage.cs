using DeAutos.Automation.Framework.Extensions;
using DeAutos.Automation.Integration.Pages.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;
using static DeAutos.Automation.Framework.Resolver.FormData;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using static System.Int32;


namespace DeAutos.Automation.Integration.Pages.Listing
{
    public class ListingPage : BasePage
    {
        private CaptchaService captchaService;

        public ListingPage(IWebDriver driver)
            : base(driver)
        {
            captchaService = new CaptchaService(driver);
        }

        public void ParticularFilter()
        {
            IWebElement particular = driver.FindElement(By.PartialLinkText("Particular"));
            IsTrue(particular.Displayed);
            particular.Click();
        }

        public void GoToVip()
        {
            IWebElement vipLink = driver.FindElement(By.XPath("(//*[@class='text-overflow']//section)[1]"));
            IsTrue(vipLink.Displayed);
            vipLink.Click();
        }

        public void Contact()
        {

            driver.FindElement(By.XPath("//div[@id='mainContent']/div/div/div/div[3]/div[2]/div/div/ul/li/div[3]/button"))
                .Click();

            driver.FindElement(By.Id("email-consult-form")).Clear();
            driver.FindElement(By.Id("email-consult-form")).SendKeys(ValidEmail);
            driver.FindElement(By.Id("name-consult-form")).Clear();
            driver.FindElement(By.Id("name-consult-form")).SendKeys(Name);
            driver.FindElement(By.Id("phone-consult-form")).Clear();
            driver.FindElement(By.Id("phone-consult-form")).SendKeys(PhoneNumber);
            driver.FindElement(By.Id("message-consult-form")).Clear();
            driver.FindElement(By.Id("message-consult-form")).SendKeys(Comment);
            driver.FindElement(By.XPath("(//button[@type='button'])[6]")).Click();
  
            Thread.Sleep(2000);
            var title = driver.FindElement(By.Id("contactModalLabel")).Text;

            if (!title.Equals("Código de verificación"))
            {

            driver.FindElement(By.Id("contactModalLabel")).Text.Contains("Te contactaste con el vendedor");

            }
        }

        public bool ApplyBrandFilter()
        {

            IWebElement brand = driver.FindElement(By.XPath("//div[@id='mainContent']/div/div/div/div[3]/div/div/div/div[3]/ul/li/a"));
            string brandName = brand.Text;
            brand.Click();

            if (!driver.FindElement(By.XPath("//*[@class='facet']//*[contains(text(), '" + brandName + "')]")).Displayed)
            {
                Console.WriteLine("No aparece el facetado de: " + brandName);
                return false;
            }

            driver.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class='container']//*[contains(@class,'publication-list')]")), TimeSpan.FromSeconds(10));
            IList<IWebElement> facetedPublications = driver.FindElements(By.XPath("//*[@class='publication-list']//*[@class='model-brand']//span"));
            foreach (IWebElement publication in facetedPublications)
            {
                if (!publication.Text.Contains(brandName))
                {
                    Console.WriteLine("Aparece una publicación que no es de: " + brandName);
                    Console.WriteLine("En esa publicación se ve el siguiente texto: " + publication.Text);
                    return false;
                }
            }
            return true;
        }

        public bool ApplyZoneFilter()
        {
            var zone = driver.FindElement(By.XPath("//div[@id='mainContent']/div/div/div/div[3]/div/div/div/div[9]/ul/li/a"));
            string zoneName = zone.Text;

            var action = new Actions(driver);
            action.MoveToElement(zone).MoveByOffset(0, -200).Build().Perform();
            zone.Click();

            if (!driver.FindElement(By.XPath("//*[@class='facet']//*[contains(text(), '" + zoneName + "')]")).Displayed)
            {
                Console.WriteLine("No aparece el facetado de la zona: " + zoneName);
                return false;
            }

            IList<IWebElement> facetedPublications = driver.FindElements(By.XPath("//*[@class='listContainer']//*[@class='location-info']//span[2]"));
            foreach (IWebElement publication in facetedPublications)
            {
                if (!publication.GetAttribute("textContent").Contains(zoneName))
                {
                    Console.WriteLine("Aparece una publicación que no es de la zona: " + zoneName);
                    Console.WriteLine("En esa publicación se ve el siguiente texto: " + publication.GetAttribute("textContent"));
                    return false;
                }
            }

            return true;
        }

        public void ApplyYearFilter(string fromYear = null, string toYear = null)
        {
            if (fromYear == null && toYear == null)
            {
                fromYear = "1950";
                toYear = "2010";
            }

            driver.FindElement(By.XPath("(//input[@type='text'])[3]")).Clear();
            driver.FindElement(By.XPath("(//input[@type='text'])[3]")).SendKeys(fromYear);
            driver.FindElement(By.XPath("(//input[@type='text'])[4]")).Clear();
            driver.FindElement(By.XPath("(//input[@type='text'])[4]")).SendKeys(toYear);
            driver.FindElement(By.XPath("//div[4]/div/div/div/div/button")).Click();

            AreEqual("Año 1950 - 2010", driver.FindElement(By.XPath("//div[@id='mainContent']/div/div/div/div[3]/div/div/div/div[2]/div[2]/a/span")).Text);

        }

        public bool ApplyPriceFilter(string minimumPrice = null, string maximumPrice = null)
        {
            if (minimumPrice == null && maximumPrice == null)
            {
                minimumPrice = "50000";
                maximumPrice = "250000";
            }

            driver.FindElement(By.XPath("(//input[@type='text'])[5]")).Clear();
            driver.FindElement(By.XPath("(//input[@type='text'])[5]")).SendKeys(minimumPrice);
            driver.FindElement(By.XPath("(//input[@type='text'])[6]")).Clear();
            driver.FindElement(By.XPath("(//input[@type='text'])[6]")).SendKeys(maximumPrice);
            driver.FindElement(By.XPath("//div[5]/div/div/div/div/button")).Click();

            string minimumPriceThousandsSeparator = $"{(minimumPrice):n0}";
            string maximumPriceThousandsSeparator = $"{Parse(maximumPrice):n0}";

            if (!driver.FindElement(By.XPath("//div[@id='mainContent']/div/div/div/div[3]/div/div/div/div[2]/div[2]/a/span")).Displayed)
            {
                Console.WriteLine(string.Concat("No aparece el facetado del rango de precio entre: ", minimumPrice, " y ", maximumPrice));
                return false;
            }

            driver.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("ul.publication-list")), TimeSpan.FromSeconds(10));
            IList<IWebElement> facetedPublications = driver.FindElements(By.XPath("//*[@class='listContainer']//*[@class='price text-overflow']/span"));
            foreach (IWebElement publication in facetedPublications)
            {
                int publicationPrice = Parse(Regex.Replace(publication.Text, @"[^0-9]+", string.Empty));

                if (publicationPrice < Parse(minimumPrice) || publicationPrice > Parse(maximumPrice))
                {
                    Console.WriteLine(string.Concat(
                    "Aparece una publicación con un precio por fuera del rango entre ", minimumPrice, " y ", maximumPrice, "\n",
                    "El precio de esa publicación es de: ", publicationPrice.ToString()
                    ));
                    return false;
                }
            }
            return true;
        }

        public void ApplyKilometersFilter(string minimumKilometers = null, string maximumKilometers = null)
        {
            if (minimumKilometers == null && maximumKilometers == null)
            {
                minimumKilometers = "5000";
                maximumKilometers = "250000";
            }

            driver.FindElement(By.XPath("(//input[@type='text'])[9]")).Clear();
            driver.FindElement(By.XPath("(//input[@type='text'])[9]")).SendKeys(minimumKilometers);
            driver.FindElement(By.XPath("(//input[@type='text'])[10]")).Clear();
            driver.FindElement(By.XPath("(//input[@type='text'])[10]")).SendKeys(maximumKilometers);
            driver.FindElement(By.XPath("//div[7]/div/div/div/div/button")).Click();

            CultureInfo culture = new CultureInfo("es-AR");

            string minimumKilometersThousandsSeparator = Parse(minimumKilometers).ToString("N0", culture);
            string maximumKilometersThousandsSeparator = Parse(maximumKilometers).ToString("N0", culture);
            AreEqual(string.Concat("Km ", minimumKilometersThousandsSeparator, " - ", maximumKilometersThousandsSeparator), driver.FindElement(By.XPath("//div[@id='mainContent']/div/div/div/div[3]/div/div/div/div[2]/div[2]/a/span")).Text);
        }

        public bool GetNumberItems()
        {
            int count = Parse(driver.FindElement(By.CssSelector("strong")).Text.Replace(".", ""));

            return count > 0;
        }

        public bool CheckStrategicAutoPublication(string brandToCheck)
        {
            driver.FindElement(By.XPath("//*[@class='form-control top-search-txt ui-autocomplete-input']")).SendKeys(brandToCheck);
            driver.FindElement(By.XPath("//*[@class='btn btn-da-orange autos-search-btn']")).Click();

            return (driver.IsElementPresent(By.XPath("//*[@class='publication-item sponser big-sponsor']")));
        }
    }
}