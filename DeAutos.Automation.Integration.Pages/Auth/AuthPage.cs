using DeAutos.Automation.Framework.DTO;
using DeAutos.Automation.Framework.Extensions;
using DeAutos.Automation.Framework.Resolver;
using DeAutos.Automation.Integration.Pages.BackOffice.User;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using static DeAutos.Automation.Framework.Resolver.FormData;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using static OpenQA.Selenium.Support.UI.ExpectedConditions;
using static System.TimeSpan;

namespace DeAutos.Automation.Integration.Pages.Auth
{
    public class AuthPage : BasePage
    {
        public AuthPage(IWebDriver driver)
            : base(driver)
        {
        }

        public bool Login(string userName = null, string pass = null)
        {
            driver.FindElement(By.XPath("//div[@id='wrapper']/header/nav/div[2]/div[4]/div[4]/div/ul/li/div/a/span")).Click();

            if ((string.IsNullOrEmpty(userName)) && (string.IsNullOrEmpty(pass)))
            {
                userName = OfficialUser;
                pass = OfficialUserPassword;
            }

            driver.Until(ElementIsVisible(By.XPath("(//input[@name='username'])[2]")), TimeSpan.FromSeconds(7));

            driver.FindElement(By.XPath("(//input[@name='username'])[2]")).Clear();
            driver.FindElement(By.XPath("(//input[@name='username'])[2]")).SendKeys(userName);
            driver.FindElement(By.XPath("(//input[@name='password'])[2]")).Clear();
            driver.FindElement(By.XPath("(//input[@name='password'])[2]")).SendKeys(pass);
            driver.FindElement(By.XPath("(//button[@type='submit'])[4]")).Click();

            driver.Until(ElementIsVisible(By.Id("btn-user-menu")), TimeSpan.FromSeconds(15));

            return userName == driver.FindElement(By.Id("btn-user-menu")).Text;
        }

        public void SecondaryLogin(string userName = null, string pass = null)
        {
            if ((string.IsNullOrEmpty(userName)) && (string.IsNullOrEmpty(pass)))
            {
                userName = OfficialUser;
                pass = OfficialUserPassword;
            }

            driver.FindElement(By.XPath("(//input[@id='username'])[2]")).Clear();
            driver.FindElement(By.XPath("(//input[@id='username'])[2]")).SendKeys(userName);
            driver.FindElement(By.XPath("(//input[@id='password'])[2]")).Clear();
            driver.FindElement(By.XPath("(//input[@id='password'])[2]")).SendKeys(pass);
            driver.FindElement(By.XPath("(//button[@type='submit'])[3]")).Click();

            driver.Until(ElementIsVisible(By.CssSelector("h1.account-name.ng-binding")), FromSeconds(120));
            AreEqual("Mi Cuenta", driver.FindElement(By.CssSelector("h1.account-name.ng-binding")).Text);
        }

        public void SocialLogin(string provider, string username, string password)
        {
            string currentWindowHandle = driver.CurrentWindowHandle;

            driver.FindElement(By.XPath($"(//*[@class='btn btn-lg btn-auth btn-{provider}'])[2]")).Click();

            string windowHandle = driver.WindowHandles.FirstOrDefault(window => window != currentWindowHandle);

            if (windowHandle != null)
            {
                driver.SwitchTo().Window(windowHandle);

                if (provider.Equals("Facebook"))
                {
                    driver.FindElement(By.Id("email")).Clear();
                    driver.FindElement(By.Id("email")).SendKeys(username);

                    driver.FindElement(By.Id("pass")).Clear();
                    driver.FindElement(By.Id("pass")).SendKeys(password);

                    driver.FindElement(By.Id("u_0_2")).Click();
                }
                else
                {
                    if (provider.Equals("Google"))
                    {
                        driver.FindElement(By.Id("Email")).Clear();
                        driver.FindElement(By.Id("Email")).SendKeys(username);
                        driver.FindElement(By.Id("next")).Click();
                        driver.FindElement(By.Id("Passwd")).Clear();
                        driver.FindElement(By.Id("Passwd")).SendKeys(password);
                        driver.FindElement(By.Id("signIn")).Click();
                    }
                }

                driver.SwitchTo().Window(currentWindowHandle);
            }
            driver.Until(ElementIsVisible(By.CssSelector("h1.account-name.ng-binding")), FromSeconds(120));
            AreEqual("Mi Cuenta", driver.FindElement(By.CssSelector("h1.account-name.ng-binding")).Text);
        }

        public void BackOfficeLogin(string userName = null, string pass = null)
        {
            if ((string.IsNullOrEmpty(userName)) && (string.IsNullOrEmpty(pass)))
            {
                userName = BackofficeUser;
                pass = BackofficeUserPassword;
            }

            IDictionary<string, InputDto> formElements = new Dictionary<string, InputDto>();
            formElements.Add("//*[@id='username']", new InputDto { Function = By.XPath, Value = userName });
            formElements.Add("//*[@id='password']", new InputDto { Function = By.XPath, Value = pass });
            IsTrue(driver.FillForm(formElements));

            driver.FindElement(By.XPath("//*[@id='submit']")).Click();
        }

        public void ResetPassword(string userName = null)
        {

            if (string.IsNullOrEmpty(userName)) { userName = MultibrandUser; }

            driver.FindElement(By.Name("email")).SendKeys(userName);
            driver.FindElement(By.XPath("(//button[@type='submit'])[3]")).Click();

            driver.Until(ElementIsVisible(By.CssSelector("p.ng-scope")), TimeSpan.FromSeconds(10));
            AreEqual("Te envíamos un mensaje a " + userName + " con el cambio solicitado", driver.FindElement(By.CssSelector("p.ng-scope")).Text);
        }

        public void LogOut()
        {
            driver.FindElement(By.XPath("//button[@type='button']")).Click();
            driver.FindElement(By.LinkText("Cerrar Sesión")).Click();
        }

        public string RegisterClientUser(string userType)
        {
            string email = userType.GenerateEmail();

            driver.FindElement(By.Name("commercialName")).SendKeys(RegisterCompanyNamer);
            driver.FindElement(By.Name("businessName")).Clear();
            driver.FindElement(By.Name("businessName")).SendKeys(RegisterCompanyNamer);

            if (userType.Equals("Multibrand"))
            {
                //             driver.FindElement(By.Id("site")).Click();
                //             driver.FindElement(By.CssSelector("option[value=\"2\"]")).Click();
                var tipo = driver.FindElement(By.CssSelector("option[value=\"2\"]")).Text;

                driver.FindElement(By.Id("site")).FindElement(By.CssSelector("option[value=\"2\"]")).Click();

                Console.WriteLine(tipo);


            }
            else if (userType.Equals("Official"))
            {
                new SelectElement(driver.FindElement(By.Id("site"))).SelectByText("Concesionaria Oficial");
                driver.FindElement(By.CssSelector("option[value=\"1\"]")).Click();
                driver.FindElement(By.Name("criteria")).SendKeys("for");
                driver.FindElement(By.CssSelector("span.value.ng-binding")).Click();

            }

            driver.FindElement(By.Name("cuit")).SendKeys(RegisterCuit);
            driver.FindElement(By.Name("streetHolder")).SendKeys(RegisterStreetHolder);
            driver.FindElement(By.Name("streetNumber")).SendKeys(RegisterStreetNumber);
            driver.FindElement(By.CssSelector("input[name=\"location\"]")).Clear();
            driver.FindElement(By.CssSelector("input[name=\"location\"]")).SendKeys("bue");
            driver.FindElement(By.LinkText("Palermo, Ciudad Autónoma de Buenos Aires, Capital Federal")).Click();


            driver.FindElement(By.Name("Floor")).SendKeys(RegisterFloor);
            driver.FindElement(By.Name("Department")).SendKeys(RegisterDepartment);
            driver.FindElement(By.Name("postalCode")).SendKeys(RegisterPostalCode);




            driver.FindElement(By.XPath("//div[@id='wrapper']/div/div/section/div/div/div/form/div/div[6]/div/select/option[2]")).Click();


            driver.FindElement(By.XPath("//select[@id='site']/option[3]")).Click();
            driver.FindElement(By.Name("firstname")).SendKeys(RegisterFirstname);
            driver.FindElement(By.Name("lastname")).SendKeys(RegisterLastname);

            driver.FindElement(By.Name("email")).SendKeys(email);
            driver.FindElement(By.Name("emailConfirmation")).SendKeys(email);

            driver.FindElement(By.CssSelector("#password-group > div.form-group > div.input-group > input[name=\"password\"]")).Clear();
            driver.FindElement(By.CssSelector("#password-group > div.form-group > div.input-group > input[name=\"password\"]")).SendKeys(RegisterPassword);
            driver.FindElement(By.Name("passwordConfirmation")).Clear();
            driver.FindElement(By.Name("passwordConfirmation")).SendKeys(RegisterPassword);
            driver.FindElement(By.Name("primaryPhoneArea")).Clear();
            driver.FindElement(By.Name("primaryPhoneArea")).SendKeys(RegisterPrimaryPhoneArea);
            driver.FindElement(By.Name("primaryPhoneNumber")).Clear();
            driver.FindElement(By.Name("primaryPhoneNumber")).SendKeys(RegisterPrimaryPhoneNumber);
            driver.FindElement(By.Name("primaryPhoneNumber")).SendKeys(Keys.Tab);
            driver.FindElement(By.XPath("//button[@id='']")).Click();


            /*
                        if (userType.Equals("Multibrand"))
                        {
                            driver.FindElement(By.Name("commercialName")).SendKeys(CompanyName);

                            new SelectElement(driver.FindElement(By.Id("site"))).SelectByText("Multimarca");
                        }
                        else if (userType.Equals("Official"))
                        {
                            driver.FindElement(By.Name("commercialName")).SendKeys(CompanyName);
                            new SelectElement(driver.FindElement(By.Id("site"))).SelectByText("Concesionaria Oficial");
                            driver.FindElement(By.Name("criteria")).SendKeys("for");
                            driver.FindElement(By.CssSelector("span.value.ng-binding")).Click();
                        }

                        driver.FindElement(By.Name("location")).Clear();
                        driver.FindElement(By.Name("location")).SendKeys("bu");
                        driver.FindElement(By.LinkText("Constitución, Ciudad Autónoma de Buenos Aires, Capital Federal")).Click();

                        driver.FindElement(By.XPath("//button[@id='']")).Click();*/

            driver.Until(ElementIsVisible(By.CssSelector("#subject > h1.ng-binding")), TimeSpan.FromSeconds(25));
            AreEqual("Alta en proceso de activación", driver.FindElement(By.CssSelector("#subject > h1.ng-binding")).Text);
            Console.WriteLine(email);
            return email;
        }

        public string RegisterEndUser(string userType)
        {
            string email = userType.GenerateEmail();

            driver.FindElement(By.XPath("//div[2]/div/div/div/div")).Click();

            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(Name);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(LastName);
            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("email")).SendKeys(email);
            driver.FindElement(By.Name("emailConfirmation")).Clear();
            driver.FindElement(By.Name("emailConfirmation")).SendKeys(email);
            driver.FindElement(By.CssSelector("#password-group > div.form-group > div.input-group > input[name=\"password\"]")).Clear();
            driver.FindElement(By.CssSelector("#password-group > div.form-group > div.input-group > input[name=\"password\"]")).SendKeys(OfficialUserPassword);
            driver.FindElement(By.Name("passwordConfirmation")).Clear();
            driver.FindElement(By.Name("passwordConfirmation")).SendKeys(OfficialUserPassword);
            driver.FindElement(By.Name("emailConfirmation")).Clear();
            driver.FindElement(By.Name("emailConfirmation")).SendKeys(email);

            driver.FindElement(By.XPath("//button[@id='']")).Click();

            driver.Until(ElementIsVisible(By.XPath("//div[2]/div/p[2]")), TimeSpan.FromSeconds(25));
            AreEqual("Por favor, revisa tu correo electrónico y confirmá el registro.", driver.FindElement(By.XPath("//div[2]/div/p[2]")).Text);
            Console.WriteLine(email);
            return email;
        }

        public void RegisterAndAddSubscription(string UserType, string UserTypePassword)
        {
            var agencyUser = new AgencyUserPage(driver);

            driver.Url = Url.Deautos.Views.Login.Auth;
            string email = RegisterClientUser(UserType);

            driver.Navigate().GoToUrl(string.Concat(Url.Deautos.Views.Backoffice.Main, "agencyUserCms"));

            BackOfficeLogin();

            agencyUser.ActivateAgencyUser(email);
            agencyUser.DisableSubscription(email);
            agencyUser.CreateSubscription(email);

            Console.WriteLine($"automation has generated< the user: {email} with password: {UserTypePassword}");
        }
    }
}