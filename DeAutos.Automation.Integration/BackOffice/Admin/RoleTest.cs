using DeAutos.Automation.Framework.Resolver;
using DeAutos.Automation.Integration.Integration;
using DeAutos.Automation.Integration.Pages.Auth;
using DeAutos.Automation.Integration.Pages.BackOffice.Admin;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace DeAutos.Automation.Integration.BackOffice.Admin
{
    [TestClass]
    public class RoleTest : BaseIntegrationTest
    {
        [TestMethod, TestCategory("Backoffice")]
        public void AddRole()
        {
            var login = new AuthPage(driver);
            var role = new RolePage(driver);

            driver.Url = string.Concat(Url.Deautos.Views.Backoffice.Main, "roleAssociation");
            login.BackOfficeLogin();
            IsTrue(role.AddRole());
        }
    }
}