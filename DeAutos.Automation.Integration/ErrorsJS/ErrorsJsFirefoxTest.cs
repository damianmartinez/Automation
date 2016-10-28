using DeAutos.Automation.Framework.Extensions;
using DeAutos.Automation.Framework.Resolver;
using DeAutos.Automation.Integration.Integration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace DeAutos.Automation.Integration.ErrorsJS
{
    [TestClass]
    public class ErrorsJsFirefoxTest : BaseIntegrationTest
    {
        public void AllVerifyScriptErrors()
        {
            var urls = new List<string>();
            for (int i = 0; i < Url.PresentationUrls.Count; i++)
            {
                urls.Add(Url.PresentationUrls[i]);
            }

            bool existJavaScriptErrors = false;

            foreach (var url in urls)
            {
                if (driver.CheckJavaScriptError(url))
                    existJavaScriptErrors = true;
            }

            IsFalse(existJavaScriptErrors, "There are JavaScript errors!");
        }

        public void VerifScriptErrorsHome()
        {
            var url = Url.Deautos.Views.Home.Main;

            IsFalse(driver.CheckJavaScriptError(url), "There are JavaScript errors!");
        }

        public void VerifScriptErrorsListing()
        {
            var url = Url.Deautos.Views.Listing.Main;
            IsFalse(driver.CheckJavaScriptError(url), "There are JavaScript errors!");
        }

        public void VerifScriptErrorsCatalogueHome()
        {
            var url = Url.Deautos.Views.Catalog.Main;
            IsFalse(driver.CheckJavaScriptError(url), "There are JavaScript errors!");
        }

        public void VerifScriptErrorsComparator()
        {
            var url = Url.Deautos.Views.Catalog.Comparator;
            IsFalse(driver.CheckJavaScriptError(url), "There are JavaScript errors!");
        }

        public void VerifScriptErrorsCatalogueVip()
        {
            var url = Url.Deautos.Views.Catalog.Sheet;
            IsFalse(driver.CheckJavaScriptError(url), "There are JavaScript errors!");
        }

        public void VerifScriptErrorsCatalogueSponsoredVip()
        {
            var url = Url.Deautos.Views.Catalog.Sponsored;
            IsFalse(driver.CheckJavaScriptError(url), "There are JavaScript errors!");
        }

        public void VerifScriptErrorsCampaign()
        {
            var url = Url.Deautos.Views.Catalog.Campaign;
            IsFalse(driver.CheckJavaScriptError(url), "There are JavaScript errors!");
        }

        public void VerifScriptErrorsVip()
        {
            var url = Url.Deautos.Views.Vip.Sheet;
            IsFalse(driver.CheckJavaScriptError(url), "There are JavaScript errors!");
        }

        public void VerifScriptErrorsStore()
        {
            var url = Url.Deautos.Views.Store.Main;
            IsFalse(driver.CheckJavaScriptError(url), "There are JavaScript errors!");
        }

        public void VerifScriptErrorsMyAccount()
        {
            var url = Url.Deautos.Views.MyAccount.Summary;
            IsFalse(driver.CheckJavaScriptError(url), "There are JavaScript errors!");
        }

    
        public void VerifScriptErrorsWidgets()
        {
            var url = Url.Deautos.Views.Landings.Widgets;
            IsFalse(driver.CheckJavaScriptError(url), "There are JavaScript errors!");
        }
    }
}