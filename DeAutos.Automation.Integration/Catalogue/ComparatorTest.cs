using DeAutos.Automation.Framework.Resolver;
using DeAutos.Automation.Integration.Integration;
using DeAutos.Automation.Integration.Pages.Catalogue;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace DeAutos.Automation.Integration.Catalogue
{
    [TestClass]
    public class ComparatorTest : BaseIntegrationTest
    {
        [TestMethod, TestCategory("Comparator"), TestCategory("CriticalDev")]
        public void AddEditDeleteVehicle()
        {
            driver.Url = Url.Deautos.Views.Catalog.Comparator;
            var comparator = new ComparatorPage(driver);
            IsTrue(comparator.AddVehicle());
            IsTrue(comparator.EditVehicle());
            IsTrue(comparator.DeleteVehicle());
        }

        [TestMethod, TestCategory("Contact")]
        public void AskPriceComparator()
        {
            driver.Url = Url.Deautos.Views.Catalog.Comparator;
            var comparator = new ComparatorPage(driver);
            IsTrue(comparator.AddVehicle());
            IsTrue(comparator.AskPrice());
        }
    }
}