using DeAutos.Automation.Framework.Resolver;
using DeAutos.Automation.Integration.Integration;
using DeAutos.Automation.Integration.Pages.Auth;
using DeAutos.Automation.Integration.Pages.BackOffice.Discount;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DeAutos.Automation.Integration.BackOffice.Discount
{
    [TestClass]
    public class DiscountTest : BaseIntegrationTest
    {
        [TestMethod, TestCategory("Backoffice")]
        public void CreateDiscountCoupon()
        {
            var login = new AuthPage(driver);
            var discount = new DiscountPage(driver);

            driver.Url = string.Concat(Url.Deautos.Views.Backoffice.Main, "discount");
            login.BackOfficeLogin();
            discount.CreateDiscountCoupon();
        }
    }
}