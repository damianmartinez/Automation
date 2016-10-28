using DeAutos.Automation.Framework.Resolver;
using DeAutos.Automation.Integration.Integration;
using DeAutos.Automation.Integration.Pages.Auth;
using DeAutos.Automation.Integration.Pages.BackOffice.Catalog;
using DeAutos.Automation.Integration.Pages.Catalogue;
using DeAutos.Automation.Integration.Pages.Common;
using DeAutos.Automation.Integration.Pages.Header;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace DeAutos.Automation.Integration.Catalogue
{
    [TestClass]
    public class CatalogueTest : BaseIntegrationTest
    {

        public void HeaderSearchCatalogue()
        {
            var login = new AuthPage(driver);
            var import = new CatalogPage(driver);
            var catalogue = new HeaderPage(driver);

            driver.Url = Url.Deautos.Views.Catalog.Main;
            IsTrue(catalogue.HeaderSearch(new CatalogueSearchStrategy(), "Ford"));
        }


        public void InvalidHeaderSearchCatalogue()
        {
            driver.Url = Url.Deautos.Views.Catalog.Main;
            var catalogue = new HeaderPage(driver);
            IsTrue(catalogue.HeaderSearch(new InvalidCatalogueSearchStrategy(), "invalid"));
        }

        [TestMethod, TestCategory("Contact")]
        public void ContactCarrousel()
        {
            var catalogue = new CataloguePage(driver);

            driver.Url = Url.Deautos.Views.Catalog.Main;
            catalogue.ContactCarrouselHome();
        }

        [TestMethod, TestCategory("Others")]
        public void GoToVipFromCarrousel()
        {
            driver.Url = Url.Deautos.Views.Catalog.Main;
            var catalogue = new CataloguePage(driver);
            catalogue.GoToVipFromCarrousel();
        }
    }
}