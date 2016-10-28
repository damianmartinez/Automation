using System;
using System.Linq;
using DeAutos.Automation.Framework.Extensions;
using DeAutos.Automation.Framework.Resolver;
using OpenQA.Selenium;
using static DeAutos.Automation.Framework.Resolver.FormData;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using static OpenQA.Selenium.Support.UI.ExpectedConditions;
using static System.TimeSpan;

namespace DeAutos.Automation.Integration.Pages.MyAccount
{
    public class MyAccountPage : BasePage
    {
        public MyAccountPage(IWebDriver driver)
            : base(driver)
        {
        }

        public void NavigateSummary()
        {
            driver.Until(ElementIsVisible(By.CssSelector("h5.subtitle.ng-binding")), FromSeconds(15));
            AreEqual("Publicaciones activas", driver.FindElement(By.CssSelector("h5.subtitle.ng-binding")).Text);
            AreEqual("Créditos para publicar", driver.FindElement(By.XPath("//div[3]/div/h5")).Text);
            driver.FindElement(By.CssSelector("h1.title.ng-binding")).Click();
            driver.Until(ElementIsVisible(By.CssSelector("h1.section-title.ng-binding")), FromSeconds(7));
            AreEqual("Mis Publicaciones", driver.FindElement(By.CssSelector("h1.section-title.ng-binding")).Text);
            driver.Navigate().Back();

            driver.FindElement(By.LinkText("Packs")).Click();
            driver.Until(ElementIsVisible(By.CssSelector("h1.section-title.ng-binding")), FromSeconds(7));
            AreEqual("Packs", driver.FindElement(By.CssSelector("h1.section-title.ng-binding")).Text);
            driver.Navigate().Back();

            driver.FindElement(By.LinkText("Ver campañas en curso")).Click();
            driver.Until(ElementIsVisible(By.CssSelector("h1.section-title.ng-binding")), FromSeconds(7));
            AreEqual("Campañas", driver.FindElement(By.CssSelector("h1.section-title.ng-binding")).Text);
            driver.Navigate().Back();
        }

        public void ModifyClientUser()
        {
            driver.FindElement(By.LinkText("Datos de la Cuenta")).Click();
            driver.FindElement(By.LinkText("Editar")).Click();
            driver.Until(ElementIsVisible(By.Name("name")), FromSeconds(15));
            driver.FindElement(By.Name("name")).Clear();
            driver.FindElement(By.Name("name")).SendKeys("qa selenium 2");
            driver.FindElement(By.XPath("//button[@id='']")).Click();

            driver.Until(ElementIsVisible(By.CssSelector("h4.data-title.ng-binding")), FromSeconds(15));
            AreEqual("qa selenium 2 Editar", driver.FindElement(By.CssSelector("td.value.ng-binding")).Text);

        }

        public void ModifyContactData()
        {
            driver.FindElement(By.LinkText("Datos de la Cuenta")).Click();
            driver.FindElement(By.XPath("(//a[contains(text(),'Editar')])[4]")).Click();
            driver.Until(ElementIsVisible(By.Name("lastName")), FromSeconds(15));
            driver.FindElement(By.Name("lastName")).Clear();
            driver.FindElement(By.Name("lastName")).SendKeys("Automationl");
            driver.FindElement(By.Name("firstName")).Clear();
            driver.FindElement(By.Name("firstName")).SendKeys("Automationl");

            driver.FindElement(By.XPath("//button[@id='']")).Click();
            driver.Until(ElementIsVisible(By.CssSelector("h4.data-title.ng-binding")), FromSeconds(15));
            AreEqual("Automationl Automationl Editar", driver.FindElement(By.XPath("//div[@id='wrapper']/div/div/section/div/div/div[3]/div/table/tbody/tr/td[2]")).Text);
        }

        public void ChangePasswordData()
        {
            driver.FindElement(By.LinkText("Datos de la Cuenta")).Click();
            driver.FindElement(By.XPath("(//a[contains(text(),'Editar')])[9]")).Click();
            driver.Until(ElementIsVisible(By.CssSelector("div.row > div.form-group > div.input-group > input[name=\"password\"]")), FromSeconds(15));
            driver.FindElement(By.CssSelector("div.row > div.form-group > div.input-group > input[name=\"password\"]")).Clear();
            driver.FindElement(By.CssSelector("div.row > div.form-group > div.input-group > input[name=\"password\"]")).SendKeys("Deautos1");
            driver.FindElement(By.Name("newPassword")).Clear();
            driver.FindElement(By.Name("newPassword")).SendKeys("Deautos2");
            driver.FindElement(By.Name("reNewPassword")).Clear();
            driver.FindElement(By.Name("reNewPassword")).SendKeys("Deautos2");
            driver.FindElement(By.XPath("//div[2]/div/button[2]")).Click();
            driver.FindElement(By.XPath("//div[2]/button")).Click();


            driver.FindElement(By.CssSelector("div.section-content > div.login-main-container > div.login-form-viewport > form[name=\"userForm\"] > fieldset > div.form-group > #username")).Clear();
            driver.FindElement(By.CssSelector("div.section-content > div.login-main-container > div.login-form-viewport > form[name=\"userForm\"] > fieldset > div.form-group > #username")).SendKeys("robot@oficial.com");
            driver.FindElement(By.CssSelector("div.section-content > div.login-main-container > div.login-form-viewport > form[name=\"userForm\"] > fieldset > div.form-group > div.input-group > #password")).Clear();
            driver.FindElement(By.CssSelector("div.section-content > div.login-main-container > div.login-form-viewport > form[name=\"userForm\"] > fieldset > div.form-group > div.input-group > #password")).SendKeys("Deautos2");
            driver.FindElement(By.XPath("(//button[@type='submit'])[3]")).Click();
            driver.FindElement(By.LinkText("Datos de la Cuenta")).Click();
            driver.FindElement(By.XPath("(//a[contains(text(),'Editar')])[9]")).Click();
            driver.FindElement(By.CssSelector("div.row > div.form-group > div.input-group > input[name=\"password\"]")).Clear();
            driver.FindElement(By.CssSelector("div.row > div.form-group > div.input-group > input[name=\"password\"]")).SendKeys("Deautos2");
            driver.FindElement(By.Name("newPassword")).Clear();
            driver.FindElement(By.Name("newPassword")).SendKeys("Deautos1");
            driver.FindElement(By.Name("reNewPassword")).Clear();
            driver.FindElement(By.Name("reNewPassword")).SendKeys("Deautos1");
            driver.FindElement(By.XPath("//button[@id='']")).Click();
            driver.FindElement(By.XPath("//div[2]/button")).Click();

        }

        public bool EndPublication()
        {
            var elemt = By.CssSelector("span.icon-close2");

            if (driver.IsElementPresent(elemt))
            {
                driver.FindElement(elemt).Click();
                driver.FindElement(By.XPath("//div[2]/button[2]")).Click();
                return true;
            }
            return false;
        }

        public void Consult(string type)
        {
            string url = Url.Deautos.Views.MyAccount.Summary;
            string seller = $"//a[contains(@href, '{url}/#/conversations/list/seller/all')]";
            string buyer = $"//a[contains(@href, '{url}/#/conversations/list/buyer/all')]";
            string oportunitie = $"//a[contains(@href, '{url}/#/conversations/list/other/all')]";

            driver.Until(ElementIsVisible(By.LinkText("Resumen")), FromSeconds(15));
            driver.FindElement(By.XPath(seller)).Click();

            if (type.Equals("Answer"))
            {
                driver.FindElement(By.XPath(seller)).Click();
            }
            else
            {
                if (type.Equals("Reply"))
                {
                    driver.FindElement(By.XPath(buyer)).Click();
                }
                else
                {
                    if (type.Equals("Oportunitie"))
                    {
                        driver.FindElement(By.XPath(oportunitie)).Click();
                    }
                }
            }

            driver.FindElement(By.XPath("//conversations-dtv[@id='top']/div/div/div/div[2]/table/tbody/tr/td/p")).Click();
            driver.FindElement(By.XPath("(//input[@type='text'])[2]")).Clear();
            driver.FindElement(By.XPath("(//input[@type='text'])[2]")).SendKeys("Estoy probando oportunidades");
            driver.FindElement(By.CssSelector("div.input-group > button.btn.btn-da-orange")).Click();
        }
    }
}