using System.Threading;
using DeAutos.Automation.Framework.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using static DeAutos.Automation.Framework.Resolver.FormData;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using static OpenQA.Selenium.Support.UI.ExpectedConditions;
using static System.TimeSpan;

namespace DeAutos.Automation.Integration.Pages.Vip
{
    public class VipPage : BasePage
    {
        public VipPage(IWebDriver driver)
            : base(driver)
        {
        }

        public void PrincipalForm(string mail)
        {
            driver.FindElement(By.Id("email-embeded")).Clear();
            driver.FindElement(By.Id("email-embeded")).SendKeys(mail);
            driver.FindElement(By.Id("name-embeded")).Clear();
            driver.FindElement(By.Id("name-embeded")).SendKeys(Name);
            driver.FindElement(By.Id("phone-embeded")).Clear();
            driver.FindElement(By.Id("phone-embeded")).SendKeys(PhoneNumber);
            driver.FindElement(By.Id("message-embeded")).Clear();
            driver.FindElement(By.Id("message-embeded")).SendKeys(Comment);
            driver.FindElement(By.XPath("(//button[@type='button'])[4]")).Click();
            CheckOkAndCaptcha();
        }

        public void OfferUsed(string primary)
        {
            if (primary.Equals("Primary"))
            {
                driver.Until(ElementIsVisible(By.LinkText("Pagá con tu usado")), FromSeconds(15));
                driver.FindElement(By.LinkText("Pagá con tu usado")).Click();

            }
            else
            {
                driver.Until(ElementIsVisible(By.XPath("//div[@id='mainContent']/div/div[2]/div[2]/div/div[2]/div/a/span")),
                    FromSeconds(15));
                driver.FindElement(By.XPath("//div[@id='mainContent']/div/div[2]/div[2]/div/div[2]/div/a/span")).Click();
            }

            new SelectElement(driver.FindElement(By.Id("brand"))).SelectByText("Acura");
            new SelectElement(driver.FindElement(By.Id("model"))).SelectByText("Integra");
            new SelectElement(driver.FindElement(By.Id("version"))).SelectByText("LS SM");
            new SelectElement(driver.FindElement(By.Id("year"))).SelectByText("1971");
            driver.FindElement(By.Id("email-offer-used")).Clear();
            driver.FindElement(By.Id("email-offer-used")).SendKeys(ValidEmail);
            driver.FindElement(By.Id("name-offer-used")).Clear();
            driver.FindElement(By.Id("name-offer-used")).SendKeys(Name);
            driver.FindElement(By.Id("phone-offer-used")).Clear();
            driver.FindElement(By.Id("phone-offer-used")).SendKeys(PhoneNumber);
            driver.FindElement(By.XPath("(//button[@type='button'])[6]")).Click();

            CheckOkAndCaptcha();
        }

        public void Financing()
        {
            driver.Until(ElementIsVisible(By.CssSelector("#trigger-financing-type > span")), FromSeconds(15));
            driver.FindElement(By.CssSelector("#trigger-financing-type > span")).Click();
            new SelectElement(driver.FindElement(By.Id("type"))).SelectByText("Totalmente");
            driver.FindElement(By.Id("amount")).Clear();
            driver.FindElement(By.Id("amount")).SendKeys("5000");
            driver.FindElement(By.Id("monthly")).Clear();
            driver.FindElement(By.Id("monthly")).SendKeys("1500");
            driver.FindElement(By.Id("check-payCar")).Click();
            driver.FindElement(By.Id("email-financing-type")).Clear();
            driver.FindElement(By.Id("email-financing-type")).SendKeys(ValidEmail);
            driver.FindElement(By.Id("name-financing-type")).Clear();
            driver.FindElement(By.Id("name-financing-type")).SendKeys(Name);
            driver.FindElement(By.Id("phone-financing-type")).Clear();
            driver.FindElement(By.Id("phone-financing-type")).SendKeys(PhoneNumber);
            driver.FindElement(By.Id("message-financing-type")).Clear();
            driver.FindElement(By.Id("message-financing-type")).SendKeys(Comment);
            driver.FindElement(By.XPath("(//button[@type='submit'])[11]")).Click();
            CheckOkAndCaptcha();
        }

        public void BestOffer()
        {
            driver.Until(ElementIsVisible(By.CssSelector("#trigger-best-offer > span")), FromSeconds(15));
            driver.FindElement(By.CssSelector("#trigger-best-offer > span")).Click();
            driver.FindElement(By.Name("AmountOffered")).Clear();
            driver.FindElement(By.Name("AmountOffered")).SendKeys("5000");
            driver.FindElement(By.Id("email-best-offer")).Clear();
            driver.FindElement(By.Id("email-best-offer")).SendKeys(ValidEmail);
            driver.FindElement(By.Id("name-best-offer")).Clear();
            driver.FindElement(By.Id("name-best-offer")).SendKeys(Name);
            driver.FindElement(By.Id("phone-best-offer")).Clear();
            driver.FindElement(By.Id("phone-best-offer")).SendKeys(PhoneNumber);
            driver.FindElement(By.Id("message-best-offer")).Clear();
            driver.FindElement(By.Id("message-best-offer")).SendKeys(Comment);
            driver.FindElement(By.XPath("(//button[@type='button'])[4]")).Click();
            CheckOkAndCaptcha();
        }

        public void SecundaryForm()
        {
            driver.Until(ElementIsVisible(By.XPath("//div[@id='mainContent']/div/div[2]/div[2]/div/div[3]/div/a")), FromSeconds(15));
            driver.FindElement(By.XPath("//div[@id='mainContent']/div/div[2]/div[2]/div/div[3]/div/a")).Click();
            driver.Until(ElementIsVisible(By.Id("email-consult-form")), FromSeconds(15));
            driver.FindElement(By.Id("name-consult-form")).Clear();
            driver.FindElement(By.Id("name-consult-form")).SendKeys(Name);
            driver.FindElement(By.Id("phone-consult-form")).Clear();
            driver.FindElement(By.Id("phone-consult-form")).SendKeys(PhoneNumber);
            driver.FindElement(By.Id("message-consult-form")).Clear();
            driver.FindElement(By.Id("email-consult-form")).Clear();
            driver.FindElement(By.Id("email-consult-form")).SendKeys(ValidEmail);
            driver.FindElement(By.Id("message-consult-form")).SendKeys(Comment);
            driver.FindElement(By.XPath("(//button[@type='button'])[6]")).Click();
            CheckOkAndCaptcha();

        }

        public void SimilarOne()
        {
            var action = new Actions(driver);
            IWebElement ad =
                driver.FindElement(
                    By.XPath(
                        "//*[@id='agency-carousel-SP']//*[@class='carousel-inner']//*[@class='active item publication-item']//*[@class='col-sm-6 col-md-3 col-lg-3 col-xs-6 car-item'][1]"));
            action.MoveToElement(ad).Click(ad).Build().Perform();
            driver.Until(ElementIsVisible(By.XPath("//div[@id='agency-carousel-SP']/div/div/div/div/div[3]/a")),
                FromSeconds(15));
            driver.FindElement(By.XPath("//div[@id='agency-carousel-SP']/div/div/div/div/div[3]/a")).Click();

            driver.Until(ElementIsVisible(By.Id("email-consult-form")), FromSeconds(15));
            driver.FindElement(By.Id("email-consult-form")).Clear();
            driver.FindElement(By.Id("email-consult-form")).SendKeys(ValidEmail);
            driver.FindElement(By.XPath("(//button[@type='button'])[6]")).Click();
            CheckOkAndCaptcha();
        }

        public void SimilarAll()
        {
            driver.Until(ElementIsVisible(By.Id("slide-contact-all")), FromSeconds(15));
            driver.FindElement(By.Id("slide-contact-all")).Click();
            driver.FindElement(By.Id("email-all-consult-form")).Clear();
            driver.FindElement(By.Id("email-all-consult-form")).SendKeys(ValidEmail);
            driver.FindElement(By.Id("name-all-consult-form")).Clear();
            driver.FindElement(By.Id("name-all-consult-form")).SendKeys(Name);
            driver.FindElement(By.Id("message-all-consult-form")).Clear();
            driver.FindElement(By.Id("message-all-consult-form")).SendKeys(Comment);
            driver.FindElement(By.Id("phone-all-consult-form")).Clear();
            driver.FindElement(By.Id("phone-all-consult-form")).SendKeys(PhoneNumber);
            driver.FindElement(By.XPath("(//button[@type='button'])[6]")).Click();
            CheckOkAndCaptcha();
        }

        public void ReportPublication()
        {
            driver.FindElement(By.LinkText("Denunciar Publicación")).Click();
            driver.FindElement(By.Id("mail")).Clear();
            driver.FindElement(By.Id("mail")).SendKeys(ValidEmail);
            driver.FindElement(By.Name("Comments")).Clear();
            driver.FindElement(By.Name("Comments")).SendKeys(Comment);

            driver.FindElement(By.XPath("(//button[@type='button'])[6]")).Click();
            CheckOkAndCaptcha(true);
        }

        public void SendFriendMail()
        {
            driver.FindElement(By.XPath("//div[@id='mainContent']/div/div[2]/div/div/div/div/div[5]/ul/li[6]/a/i")).Click();

            driver.FindElement(By.Id("SenderName")).Clear();
            driver.FindElement(By.Id("SenderName")).SendKeys(Name);
            driver.FindElement(By.Id("SenderEmail")).Clear();
            driver.FindElement(By.Id("SenderEmail")).SendKeys(ValidEmail);
            driver.FindElement(By.Id("RecipientName")).Clear();
            driver.FindElement(By.Id("RecipientName")).SendKeys(Name);
            driver.FindElement(By.Id("RecipientEmail")).Clear();
            driver.FindElement(By.Id("RecipientEmail")).SendKeys(ValidEmail);
            driver.FindElement(By.Id("Comments")).Clear();
            driver.FindElement(By.Id("Comments")).SendKeys(Comment);
            driver.FindElement(By.XPath("(//button[@type='button'])[6]")).Click();
            CheckOkAndCaptcha(true);
        }

        private void Contact()
        {
            driver.Until(ElementIsVisible(By.Id("email-consult-form")), FromSeconds(15));
            driver.FindElement(By.Id("name-consult-form")).Clear();
            driver.FindElement(By.Id("name-consult-form")).SendKeys(Name);
            driver.FindElement(By.Id("phone-consult-form")).Clear();
            driver.FindElement(By.Id("phone-consult-form")).SendKeys(PhoneNumber);
            driver.FindElement(By.Id("message-consult-form")).Clear();
            driver.FindElement(By.Id("email-consult-form")).Clear();
            driver.FindElement(By.Id("email-consult-form")).SendKeys(ValidEmail);
            driver.FindElement(By.Id("message-consult-form")).SendKeys(Comment);
            driver.FindElement(By.XPath("(//button[@type='button'])[4]")).Click();
            CheckOkAndCaptcha();
        }

        private void CheckOkAndCaptcha(bool reportAndSend = false)
        {
            Thread.Sleep(2000);
            var title = driver.FindElement(By.Id("contactModalLabel")).Text;

            if (!title.Equals("Código de verificación"))
            {
                if (reportAndSend.Equals(true))
                {
                    if (title.Equals("Denuncia Publicación"))
                    {
                        AreEqual("¡Tu denuncia se envío con éxito!", driver.FindElement(By.CssSelector("h3.generic-message")).Text);

                    }
                    else
                    {
                        AreEqual("¡La publicación se envío éxitosamente!", driver.FindElement(By.CssSelector("div.success-send-friend > h3")).Text);
                    }
                }
                else
                {
                    if (title.Equals("Consultar Similares"))
                    {
                        AreEqual("¡Tu consulta se envío éxitosamente!", driver.FindElement(By.CssSelector("div.success-send-friend > h3")).Text);

                    }
                    else
                    {
                        AreEqual("¡Tu Consulta se envió con éxito!", driver.FindElement(By.Id("contactModalLabel")).Text);

                    }
                }
            }
        }
    }
}