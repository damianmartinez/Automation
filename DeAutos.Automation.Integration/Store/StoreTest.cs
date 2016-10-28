using DeAutos.Automation.Framework.Resolver;
using DeAutos.Automation.Integration.Integration;
using DeAutos.Automation.Integration.Pages.Store;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace DeAutos.Automation.Integration.Store
{
    [TestClass]
    public class StoreTest : BaseIntegrationTest
    {
        [TestMethod, TestCategory("Contact"), TestCategory("CriticalDev")]
        public void ContactConcessionary()
        {
            driver.Url = Url.Deautos.Views.Store.Main;
            var store = new StorePage(driver);
            store.ContactConcessionary();
        }

        [TestMethod, TestCategory("Contact"), TestCategory("CriticalDev")]
        public void ContactConcessionaryAd()
        {
            driver.Url = Url.Deautos.Views.Store.Main;
            var store = new StorePage(driver);
            store.ContactConcessionaryAd();
        }

        [TestMethod, TestCategory("Store")]
        public void StoreInformationPresence()
        {
            driver.Url = Url.Deautos.Views.Store.Main;
            var store = new StorePage(driver);
            IsTrue(store.InformationPresence());
        }

        [TestMethod, TestCategory("Store")]
        public void StoreMap()
        {
            driver.Url = Url.Deautos.Views.Store.Main;
            var store = new StorePage(driver);
            store.Map();
        }
    }
}