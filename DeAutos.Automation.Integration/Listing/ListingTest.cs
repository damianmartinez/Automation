using DeAutos.Automation.Framework.DTO;
using DeAutos.Automation.Framework.Resolver;
using DeAutos.Automation.Integration.Integration;
using DeAutos.Automation.Integration.Pages.Auth;
using DeAutos.Automation.Integration.Pages.BackOffice.Listing;
using DeAutos.Automation.Integration.Pages.Listing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace DeAutos.Automation.Integration.Listing
{
    [TestClass]
    public class ListingTest : BaseIntegrationTest
    {
        [TestMethod, TestCategory("Contact")]
        public void ContactListing()
        {
            driver.Url = Url.Deautos.Views.Listing.Main;
            var listing = new ListingPage(driver);
            listing.Contact();
        }

        [TestMethod, TestCategory("Listing")]
        public void ApplyBrandFilter()
        {
            driver.Url = Url.Deautos.Views.Listing.Main;
            var listing = new ListingPage(driver);
            IsTrue(listing.ApplyBrandFilter());
        }

        [TestMethod, TestCategory("Listing")]
        public void ApplyZoneFilter()
        {
            driver.Url = Url.Deautos.Views.Listing.Main;
            var listing = new ListingPage(driver);
            IsTrue(listing.ApplyZoneFilter());
        }

        [TestMethod, TestCategory("Listing")]
        public void ApplyYearFilter()
        {
            driver.Url = Url.Deautos.Views.Listing.Main;
            var listing = new ListingPage(driver);
            listing.ApplyYearFilter();
        }

        [TestMethod, TestCategory("Listing")]
        public void ApplyPriceFilter()
        {
            driver.Url = Url.Deautos.Views.Listing.Main;
            var listing = new ListingPage(driver);
            IsTrue(listing.ApplyPriceFilter());
        }

        [TestMethod, TestCategory("Listing")]
        public void ApplyKilometersFilter()
        {
            driver.Url = Url.Deautos.Views.Listing.Main;
            var listing = new ListingPage(driver);
            listing.ApplyKilometersFilter();
        }

        [TestMethod, TestCategory("Listing"), TestCategory("CriticalDev")]
        public void CountListing()
        {
            driver.Url = Url.Deautos.Views.Listing.Main;
            var listing = new ListingPage(driver);
            IsTrue(listing.GetNumberItems());
        }

    }
}
