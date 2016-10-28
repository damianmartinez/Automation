using DeAutos.Automation.Framework.Extensions;
using DeAutos.Automation.Framework.Resolver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using static OpenQA.Selenium.Support.UI.ExpectedConditions;
using static System.TimeSpan;

namespace DeAutos.Automation.Integration.Pages.BackOffice.Discount
{
    public class DiscountPage : BasePage
    {
        public DiscountPage(IWebDriver driver)
            : base(driver)
        {
        }

        public void CreateDiscountCoupon()
        {
            driver.FindElement(By.LinkText("Generar cupón")).Click();

            new SelectElement(driver.FindElement(By.Id("discountSelected"))).SelectByText("Seguidores Twitter 50%");

            driver.FindElement(By.Id("quantity")).Clear();
            driver.FindElement(By.Id("quantity")).SendKeys("1");
            driver.FindElement(By.Id("user")).Clear();
            driver.FindElement(By.Id("user")).SendKeys(FormData.EndUser);

            driver.FindElement(By.LinkText("Verificar")).Click();
            driver.Until(ElementIsVisible(By.XPath("//*[@id='valid']")), FromSeconds(15));

            driver.FindElement(By.Name("_action_generate")).Click();

            AreEqual("Se ha enviado correctamente el Cupón de descuento al usuario", driver.FindElement(By.CssSelector("p")).Text);
        }
    }
}