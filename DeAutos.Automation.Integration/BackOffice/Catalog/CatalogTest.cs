using DeAutos.Automation.Framework.Resolver;
using DeAutos.Automation.Integration.Integration;
using DeAutos.Automation.Integration.Pages.Auth;
using DeAutos.Automation.Integration.Pages.BackOffice.Catalog;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DeAutos.Automation.Integration.BackOffice.Catalog
{
    [TestClass]
    public class CatalogTest : BaseIntegrationTest
    {
        [TestMethod, TestCategory("Backoffice")]
        public void PredictiveSearch()
        {
            var backOfficeLogin = new AuthPage(driver);
            var import = new CatalogPage(driver);

            driver.Url = string.Concat(Url.Backoffice, "solr/index");
            backOfficeLogin.BackOfficeLogin();
            import.SearchImport();
        }
    }
}
