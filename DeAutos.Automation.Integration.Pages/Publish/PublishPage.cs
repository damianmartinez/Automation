using DeAutos.Automation.Framework.Extensions;
using DeAutos.Automation.Framework.Resolver;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using static DeAutos.Automation.Framework.Resolver.FormData;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using static OpenQA.Selenium.Support.UI.ExpectedConditions;
using static System.TimeSpan;

namespace DeAutos.Automation.Integration.Pages.Publish
{
    public class PublishPage : BasePage
    {
        public PublishPage(IWebDriver driver)
            : base(driver)
        {
        }

        public void PublishEndUser(string userType, string newUsedPlan)
        {
            driver.FindElement(By.LinkText("Vender")).Click();

            if (driver.IsElementPresent(By.XPath("//li/div/span")))
            {
                driver.FindElement(By.XPath("//li/div/span")).Click();
            }

            Mmvselector();
            Config(userType, newUsedPlan);
            LoginEndUser(EndUser, EndUserPassword);
            OfferingselectEndUser();
        }

        public void PublishAgencyUser(string angencyType, string newUsedPlan)
        {
            driver.FindElement(By.LinkText("Vender")).Click();

            if (driver.IsElementPresent(By.XPath("//li[2]/div/span")))
            {
                driver.FindElement(By.XPath("//li[2]/div/span")).Click();
                LoginClientUser(angencyType);
            }

            Mmvselector();
            Config(angencyType, newUsedPlan);
            OfferingSelectClientUser(angencyType, newUsedPlan, "Publish");
        }

        private void Mmvselector()
        {
            driver.Until(ElementIsVisible(By.XPath("//div[2]/div/div/div/ul/li[2]")), FromSeconds(7));

            driver.FindElement(By.XPath("//div/div[2]/div/div/div/ul/li")).Click();
            driver.FindElement(By.XPath("//div[2]/div/div[2]/div/ul/li[2]")).Click();
            driver.FindElement(By.XPath("//div[3]/div/ul/li")).Click();

            driver.FindElement(By.XPath("(//button[@id=''])[3]")).Click();
        }

        private void LoginEndUser(string username, string password)
        {
            if (driver.IsElementPresent(By.CssSelector("h4.modal-title.ng-binding")))
            {
                AreEqual("Ingresar", driver.FindElement(By.CssSelector("h4.modal-title.ng-binding")).Text);

                driver.FindElement(By.XPath("(//input[@name='username'])[2]")).Clear();
                driver.FindElement(By.XPath("(//input[@name='username'])[2]")).SendKeys(username);
                driver.FindElement(By.XPath("(//input[@name='password'])[2]")).Clear();
                driver.FindElement(By.XPath("(//input[@name='password'])[2]")).SendKeys(password);
                driver.FindElement(By.XPath("(//button[@type='submit'])[3]")).Click();
            }
        }

        private void LoginClientUser(string agencyType)
        {
            string username = OfficialUser;
            string password = OfficialUserPassword;

            if (agencyType.Equals("Multibrand"))
            {
                username = MultibrandUser;
                password = MultibrandUserPassword;
            }
            else
            {
                if (agencyType.Equals("Official"))
                {
                    username = OfficialUser;
                    password = OfficialUserPassword;
                }
            }

            driver.FindElement(By.XPath("(//input[@name='username'])[2]")).Clear();
            driver.FindElement(By.XPath("(//input[@name='username'])[2]")).SendKeys(username);
            driver.FindElement(By.XPath("(//input[@name='password'])[2]")).Clear();
            driver.FindElement(By.XPath("(//input[@name='password'])[2]")).SendKeys(password);
            driver.FindElement(By.XPath("(//button[@type='submit'])[3]")).Click();

            driver.Until(ElementIsVisible(By.CssSelector("h1.account-name.ng-binding")), FromSeconds(120));
            AreEqual("Mi Cuenta", driver.FindElement(By.CssSelector("h1.account-name.ng-binding")).Text);
        }

        private void OfferingselectEndUser()
        {
            driver.FindElement(By.XPath("//ul[2]/li[2]/div")).Click();
            driver.FindElement(By.XPath("//img[@title='VISA']")).Click();
            driver.FindElement(By.XPath("(//button[@id=''])[5]")).Click();
        }

        private void OfferingSelectClientUser(string angencyType, string newUsedPlan, string typePublish)
        {
            if (angencyType.Equals("Oficial"))
            {
                if (newUsedPlan.Equals("New"))
                {
                    driver.FindElement(By.CssSelector("div.title-container")).Click();
                }
                else
                {
                    if (newUsedPlan.Equals("Used"))
                    {
                        driver.FindElement(By.CssSelector("li.col-md-6.choose-ad-item > div.description-container")).Click();
                    }
                    else
                    {
                        if (newUsedPlan.Equals("Plan"))
                        {
                            driver.FindElement(By.CssSelector("li.col-md-12.choose-ad-item > div.description-container")).Click();
                        }
                    }
                }
            }
            else
            {
                if (angencyType.Equals("Multibrand"))
                {
                    if (newUsedPlan.Equals("New"))
                    {
                        driver.FindElement(By.CssSelector("div.title-container")).Click();
                    }
                    else
                    {
                        if (newUsedPlan.Equals("Used"))
                        {
                            driver.FindElement(By.XPath("//li/div[2]/p")).Click();
                        }
                        else
                        {
                            if (newUsedPlan.Equals("Plan"))
                            {
                                driver.FindElement(By.XPath("//ng-include/div/div/ul/li/div")).Click();
                            }
                        }
                    }
                }
            }

            if (typePublish.Equals("Republish"))
            {
                AreEqual("Republicación exitosa", driver.FindElement(By.XPath("//div[3]/h1")).Text);
            }
            else
            {
                if (typePublish.Equals("Publish"))
                {
                    AreEqual("¡Publicaste tu vehículo!", driver.FindElement(By.CssSelector("h1.title.ng-binding")).Text);
                }
            }
        }

        private void Config(string userType, string newUsedPlan)
        {
            if (userType.Equals("AgencyUser"))
            {

                if (driver.FindElement(By.CssSelector("h3.ng-binding")).Text == "Autocompletar características de fábrica")
                {
                    driver.FindElement(By.XPath("//div[7]/div/div/div[2]/button")).Click();
                    driver.FindElement(By.XPath("//div[6]/div/div/div[2]/button")).Click();

                }
            }

            if (newUsedPlan.Equals("Used"))
            {
                driver.FindElement(By.XPath("//label[2]")).Click();
                driver.FindElement(By.Id("Price")).Clear();
                driver.FindElement(By.Id("Price")).SendKeys("33333");

                if (userType.Equals("EndUser"))
                {
                    driver.FindElement(By.Name("location")).SendKeys("bu");
                    driver.FindElement(By.LinkText("Palermo, Ciudad Autónoma de Buenos Aires, Capital Federal")).Click();
                }

                new SelectElement(driver.FindElement(By.Id("PaymentOptionId"))).SelectByText("A Convenir");
                new SelectElement(driver.FindElement(By.Id("Year"))).SelectByText("2001");
                driver.FindElement(By.Id("Km")).Clear();
                driver.FindElement(By.Id("Km")).SendKeys("1000");
                driver.FindElement(By.Id("Plate")).Clear();
                driver.FindElement(By.Id("Plate")).SendKeys("asd156");
                new SelectElement(driver.FindElement(By.Id("Fuel"))).SelectByText("ND");
                new SelectElement(driver.FindElement(By.Id("Color"))).SelectByText("A elección del cliente");
            }
            else
            {
                if (newUsedPlan.Equals("Plan"))
                {
                    driver.FindElement(By.XPath("//label/img")).Click();
                    driver.FindElement(By.Id("Price")).Clear();
                    driver.FindElement(By.Id("Price")).SendKeys("100023");
                    new SelectElement(driver.FindElement(By.Id("PaymentOptionId"))).SelectByText("A Convenir");
                    new SelectElement(driver.FindElement(By.Id("SavingPlanType"))).SelectByText("Nuevo");
                    new SelectElement(driver.FindElement(By.Id("FinancingType"))).SelectByText("70/30");
                    if (userType.Equals("EndUser"))
                    {
                        driver.FindElement(By.Name("location")).SendKeys("bu");
                        driver.FindElement(By.LinkText("Burzaco, Almirante Brown, Gran Buenos Aires")).Click();
                    }
                    driver.FindElement(By.Id("PureFee")).Clear();
                    driver.FindElement(By.Id("PureFee")).SendKeys("10");
                    driver.FindElement(By.Id("AverageFeeValue")).Clear();
                    driver.FindElement(By.Id("AverageFeeValue")).SendKeys("10");
                    driver.FindElement(By.Id("AgreedDeliveryFee")).Clear();
                    driver.FindElement(By.Id("AgreedDeliveryFee")).SendKeys("10");
                    driver.FindElement(By.Id("FeesNumber")).Clear();
                    driver.FindElement(By.Id("FeesNumber")).SendKeys("10");
                    new SelectElement(driver.FindElement(By.Id("Fuel"))).SelectByText("Diesel");
                }
                else
                {
                    if (newUsedPlan.Equals("New"))
                    {
                        driver.FindElement(By.XPath("//label[3]/img")).Click();
                        driver.FindElement(By.Id("Price")).Clear();
                        driver.FindElement(By.Id("Price")).SendKeys("123132");
                        new SelectElement(driver.FindElement(By.Id("PaymentOptionId"))).SelectByText("Contado");
                        new SelectElement(driver.FindElement(By.Id("Year"))).SelectByText("2015");
                        driver.FindElement(By.Id("AdvancePayment")).Clear();
                        driver.FindElement(By.Id("AdvancePayment")).SendKeys("10");
                        driver.FindElement(By.Id("RetireFromFee")).Clear();
                        driver.FindElement(By.Id("RetireFromFee")).SendKeys("10");
                        driver.FindElement(By.Id("RegistrationFee")).Clear();
                        driver.FindElement(By.Id("RegistrationFee")).SendKeys("10");
                        new SelectElement(driver.FindElement(By.Id("Fuel"))).SelectByText("GNC");
                    }
                }
            }

            new SelectElement(driver.FindElement(By.Id("Fuel"))).SelectByText("Diesel");

            //  AddImages();

            driver.FindElement(By.Id("Comment")).Clear();
            driver.FindElement(By.Id("Comment")).SendKeys(Comment);
            driver.FindElement(By.XPath("(//button[@id=''])[4]")).Click();
        }

        public void AddImages()
        {
            driver.FindElement(By.XPath("//button[@id='']")).Click();
            driver.FindElement(By.CssSelector("input.file-field.ng-isolate-scope")).Clear();
            driver.FindElement(By.CssSelector("input.file-field.ng-isolate-scope")).SendKeys(Env.ImagesPublish);

            var action = new Actions(driver);
            action.MoveToElement(driver.FindElement(By.CssSelector("span.icon.icon-garbage2")));
            driver.FindElement(By.CssSelector("span.icon.icon-garbage2")).Click();
            driver.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div/div/div[2]/button[2]")), TimeSpan.FromSeconds(10));
            driver.FindElement(By.XPath("//div/div/div[2]/button[2]")).Click();
            driver.FindElement(By.CssSelector("input.file-field.ng-isolate-scope")).SendKeys(Env.ImagesPublish);
            driver.FindElement(By.XPath("(//button[@id=''])[8]")).Click();
            driver.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div/div/div[2]/button[2]")), TimeSpan.FromSeconds(10));
            driver.FindElement(By.XPath("//div/div/div[2]/button[2]")).Click();
        }

        public bool RepublishClientUser(string angencyType)
        {

            driver.FindElement(By.XPath("//div[@id='wrapper']/div/div/section/div/div[2]/div/div[2]/a/label")).Click();
            driver.FindElement(By.CssSelector("option[value=\"3\"]")).Click();


            var element = By.CssSelector("span.icon.icon-timer2");

            if (!driver.IsElementPresent(element)) return false;
            driver.Until(ElementIsVisible(element), FromSeconds(7));
            driver.FindElement(element).Click();
            //AddImages();
            driver.FindElement(By.Id("Comment")).Clear();
            driver.FindElement(By.Id("Comment")).SendKeys(Comment);
            driver.FindElement(By.XPath("(//button[@id=''])[4]")).Click();
            OfferingSelectClientUser(angencyType, "Plan", "Republish");
            return true;
        }

        public bool ModifyItem()
        {
            driver.FindElement(By.LinkText("Publicaciones")).Click();

            var result = By.CssSelector("span.icon-pencil2");

            if (driver.IsElementPresent(result))
            {
                driver.FindElement(By.CssSelector("span.icon-pencil2")).Click();
                new SelectElement(driver.FindElement(By.Id("Fuel"))).SelectByText("GNC");
                driver.FindElement(By.CssSelector("#Fuel > option[value=\"3\"]")).Click();
                // AddImages();
                driver.FindElement(By.Id("Comment")).Clear();
                driver.FindElement(By.Id("Comment")).SendKeys(Comment);
                driver.FindElement(By.XPath("(//button[@id=''])[4]")).Click();
                driver.Until(ElementIsVisible(By.XPath("//div[contains(@class,'resume-container section-container ng-scope')]")), FromSeconds(30));
                AreEqual("Publicación actualizada exitosamente", driver.FindElement(By.XPath("//div[2]/h1")).Text);

                return true;
            }
            return false;
        }

        public bool CopyItem()
        {

            var result = By.CssSelector("span.icon-pencil2");

            if (driver.IsElementPresent(result))
            {
              
                driver.FindElement(By.CssSelector("span.icon-copy2")).Click();

                //  AddImages();
                driver.FindElement(By.Id("Comment")).Clear();
                driver.FindElement(By.Id("Comment")).SendKeys(Comment);
                driver.FindElement(By.XPath("(//button[@id=''])[4]")).Click();
                driver.FindElement(By.XPath("//div[@id='wrapper']/div/div/section/div/div[2]/ng-include/div/div/div/ul/li/div[3]/button")).Click();
                driver.Until(ElementIsVisible(By.XPath("//div[contains(@class,'resume-container section-container ng-scope')]")), FromSeconds(30));
                AreEqual("¡Publicaste tu vehículo!", driver.FindElement(By.CssSelector("h1.title.ng-binding")).Text);
                return true;
            }
            return false;
        }
    }
}