using DeAutos.Automation.Framework.DTO;
using DeAutos.Automation.Framework.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using static DeAutos.Automation.Framework.Conditions.ExpectedConditionsCustom;
using static DeAutos.Automation.Framework.Resolver.FormData;
using static OpenQA.Selenium.Support.UI.ExpectedConditions;
using static System.TimeSpan;

namespace DeAutos.Automation.Integration.Pages.Catalogue
{
    public class ComparatorPage : BasePage
    {
        public ComparatorPage(IWebDriver driver)
            : base(driver)
        {
        }

        public bool AddVehicle()
        {
            driver.Until(ElementCssValueEquals(By.XPath("//*[@id='comparator-loading']"), "opacity", "0"), FromSeconds(7));
            driver.Until(ElementExists(By.XPath("//*[contains(@class,'vehicle-item')][2]//*[@class='dropdown-brands']/option[2]")), FromSeconds(7));

            new SelectElement(driver.FindElement(By.XPath("//*[contains(@class,'vehicle-item')][2]//*[@class='dropdown-brands']"))).SelectByIndex(1);
            driver.Until(ElementExists(By.XPath("//*[contains(@class,'vehicle-item')][2]//*[@class='dropdown-models']/option[2]")), FromSeconds(7));
            new SelectElement(driver.FindElement(By.XPath("//*[contains(@class,'vehicle-item')][2]//*[@class='dropdown-models']"))).SelectByIndex(1);
            driver.Until(ElementExists(By.XPath("//*[contains(@class,'vehicle-item')][2]//*[@class='dropdown-versions']/option[2]")), FromSeconds(7));
            new SelectElement(driver.FindElement(By.XPath("//*[contains(@class,'vehicle-item')][2]//*[@class='dropdown-versions']"))).SelectByIndex(1);

            driver.FindElement(By.XPath("//*[contains(@class,'vehicle-item')][2]//*[contains(@class,'btn-add-version')]")).Click();
            driver.Until(ElementCssValueEquals(By.XPath("//*[@id='comparator-loading']"), "opacity", "0"), FromSeconds(7));
            driver.Until(ElementIsVisible(By.XPath("//*[contains(@class,'vehicle-item')][2]//*[contains(@class,'btn-ask-cotization')]")), FromSeconds(7));
            return true;
        }

        public bool EditVehicle()
        {
            driver.Until(ElementCssValueEquals(By.XPath("//*[@id='comparator-loading']"), "opacity", "0"), FromSeconds(7));

            driver.FindElement(By.XPath("//*[contains(@class,'vehicle-item')][2]//*[contains(@class,'btn-edit')]")).Click();

            driver.ExecuteJavascript("window.scrollBy(" + "0" + "," + "-300" + ");");

            driver.Until(ElementExists(By.XPath("//*[contains(@class,'vehicle-item')][2]//*[@class='dropdown-brands']/option[3]")), FromSeconds(7));
            new SelectElement(driver.FindElement(By.XPath("//*[contains(@class,'vehicle-item')][2]//*[@class='dropdown-brands']"))).SelectByIndex(2);
            driver.ExecuteJavascript("window.scrollBy(" + "0" + "," + "-300" + ");");

            driver.Until(ElementExists(By.XPath("//*[contains(@class,'vehicle-item')][2]//*[@class='dropdown-models']/option[4]")), FromSeconds(7));
            new SelectElement(driver.FindElement(By.XPath("//*[contains(@class,'vehicle-item')][2]//*[@class='dropdown-models']"))).SelectByIndex(2);
            driver.ExecuteJavascript("window.scrollBy(" + "0" + "," + "-300" + ");");

            driver.Until(ElementExists(By.XPath("//*[contains(@class,'vehicle-item')][2]//*[@class='dropdown-versions']/option[2]")), FromSeconds(7));
            new SelectElement(driver.FindElement(By.XPath("//*[contains(@class,'vehicle-item')][2]//*[@class='dropdown-versions']"))).SelectByIndex(1);
            driver.ExecuteJavascript("window.scrollBy(" + "0" + "," + "-300" + ");");

            driver.FindElement(By.XPath("//*[contains(@class,'vehicle-item')][2]//*[contains(@class,'btn-add-version')]")).Click();
            driver.Until(ElementCssValueEquals(By.XPath("//*[@id='comparator-loading']"), "opacity", "0"), FromSeconds(7));
            driver.Until(ElementIsVisible(By.XPath("//*[contains(@class,'vehicle-item')][2]//*[contains(@class,'btn-ask-cotization')]")), FromSeconds(7));
            return true;
        }

        public bool DeleteVehicle()
        {
            driver.Until(ElementCssValueEquals(By.XPath("//*[@id='comparator-loading']"), "opacity", "0"), FromSeconds(7));

            driver.ExecuteJavascript("window.scrollBy(" + "0" + "," + "-300" + ");");

            driver.FindElement(By.XPath("//*[contains(@class,'vehicle-item')][2]//*[contains(@class,'btn-remove')]")).Click();
            driver.Until(ElementCssValueEquals(By.XPath("//*[@id='comparator-loading']"), "opacity", "0"), FromSeconds(7));

            driver.Until(ElementIsVisible(By.XPath("//*[contains(@class,'vehicle-item')][2]//*[@class='dropdown-brands']")), FromSeconds(7));
            driver.Until(ElementIsVisible(By.XPath("//*[contains(@class,'vehicle-item')][2]//*[@class='dropdown-models']")), FromSeconds(7));
            driver.Until(ElementIsVisible(By.XPath("//*[contains(@class,'vehicle-item')][2]//*[@class='dropdown-versions']")), FromSeconds(7));
            driver.Until(ElementIsVisible(By.XPath("//*[contains(@class,'vehicle-item')][2]//*[contains(@class,'btn-add-version')]")), FromSeconds(7));
            return true;
        }

        public bool AskPrice()
        {
            Console.WriteLine("se va a esperar al botón de cotización");

            driver.Until(ElementIsVisible(By.XPath("//*[contains(@class,'vehicle-item')][2]//*[contains(@class,'btn-ask-cotization')]")), FromSeconds(15));
            Console.WriteLine("se va a clickear cotización");

            driver.FindElement(By.XPath("//*[contains(@class,'vehicle-item')][2]//*[contains(@class,'btn-ask-cotization')]")).Click();
            Console.WriteLine("se clickeó cotización y ahora se espera al modal de contacto");

            driver.Until(ElementIsVisible(By.XPath("//*[@id='contactModal']//*[@class='header']")),
                FromSeconds(15));

            IDictionary<string, InputDto> formElements = new Dictionary<string, InputDto>();
            formElements.Add("//*[@id='contactModal']//*[@id='contactMail']", new InputDto { Function = By.XPath, Value = ValidEmail });
            formElements.Add("//*[@id='contactModal']//*[@id='contactName']", new InputDto { Function = By.XPath, Value = Name });
            formElements.Add("//*[@id='contactModal']//*[@id='contactPhone']", new InputDto { Function = By.XPath, Value = PhoneNumber });
            formElements.Add("//*[@id='contactModal']//*[@id='msgText']", new InputDto { Function = By.XPath, Value = Comment });
            Assert.IsTrue(driver.FillForm(formElements));

            driver.Until(ElementIsVisible(By.XPath("//*[@id='contactLocations']/option[2]")), FromSeconds(15));

            new SelectElement(driver.FindElement(By.XPath("//*[@id='contactLocations']"))).SelectByIndex(2);

            driver.FindElement(By.XPath("//*[contains(@class,'submit-button')]")).Click();

            driver.Until(ElementIsVisible(By.XPath("//*[@class='fancybox-outer']//*[@class='fancybox-inner']/div[1]")), FromSeconds(15));
            IWebElement successOrCaptcha = driver.FindElement(By.XPath("//*[@class='fancybox-outer']//*[@class='fancybox-inner']/div[1]//*[@class='modalHeaderText']"));
            if (successOrCaptcha.Displayed && successOrCaptcha.Text == "Tu pedido fue realizado con éxito")
            {
                return true;
            }
            else if (successOrCaptcha.Displayed && successOrCaptcha.Text == "Código de Verificación")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}