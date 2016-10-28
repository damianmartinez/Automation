using DeAutos.Automation.Framework.Resolver;
using DeAutos.Automation.Integration.Integration;
using DeAutos.Automation.Integration.Pages.Catalogue;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace DeAutos.Automation.Integration.Catalogue
{
    [TestClass]
    public class CatalogueVipTest : BaseIntegrationTest
    {
        [TestMethod, TestCategory("Contact")]
        public void AskPriceCatalogueVip()
        {
            driver.Url = Url.Deautos.Views.Catalog.Sheet;
            var cataloguevip = new CatalogueVipPage(driver);
            IsTrue(cataloguevip.AskPriceCatalogueVip());
        }

        [TestMethod, TestCategory("Others")]
        public void ImageGallery()
        {
            driver.Url = Url.Deautos.Views.Catalog.Sheet;
            var catalogueVip = new CatalogueVipPage(driver);
            catalogueVip.ImageGalleryCheck();
        }

        [TestMethod, TestCategory("Contact")]
        public void AskPriceCatalogueVipVersions()
        {
            driver.Url = Url.Deautos.Views.Catalog.Sheet;
            var catalogueVip = new CatalogueVipPage(driver);
            IsTrue(catalogueVip.AskPriceCatalogueVipVersions());
        }

        [TestMethod, TestCategory("Contact")]
        public void ContactCarrouselCatalogueVip()
        {
            driver.Url = Url.Deautos.Views.Catalog.Sheet;
            var catalogueVip = new CatalogueVipPage(driver);
            IsTrue(catalogueVip.ContactCarrouselCatalogueVip());
        }

        [TestMethod, TestCategory("Comparator")]
        public void AddVersionsToComparator()
        {
            driver.Url = Url.Deautos.Views.Catalog.Sheet;
            var catalogueVip = new CatalogueVipPage(driver);
            IsTrue(catalogueVip.AddVersionsToComparator());
        }
    }
}