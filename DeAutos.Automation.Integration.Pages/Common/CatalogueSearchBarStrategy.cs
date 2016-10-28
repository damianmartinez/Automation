using DeAutos.Automation.Framework.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace DeAutos.Automation.Integration.Pages.Common
{
    public class CatalogueSearchStrategy : SearchBarStrategy<bool>
    {
        public override bool Search(IWebDriver driver, string searchable)
        {
            driver.FindElement(By.XPath("//input[@type='text']")).SendKeys(searchable);

            driver.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class='predictiveBox']//*[@class='ui-menu-item']")),
                TimeSpan.FromSeconds(15));

            string searched = driver.FindElement(By.XPath("//*[@class='predictiveBox']//*[@class='ui-menu-item']/a")).Text;
            Console.WriteLine("Se buscó: '" + searched + "'.");

            driver.FindElement(By.XPath("//*[@class='predictiveBox']//*[@class='ui-menu-item']")).Click();

            //Si está en un listado de Modelos de una Marca, ve sea el listado de la Marca buscada.
            if (searchable.Equals(driver.FindElement(By.CssSelector("h1")).Text))
            {
                Console.WriteLine("Se llegó al selector de Modelos de " + "'" + searchable + "' en Catálogo.");
                return true;
            }
            //Sino, si llegó a una ficha, que el título de la misma (el Modelo sería), sea igual a la parte del modelo del string buscado.
            else
            {
                Console.WriteLine("Se llegó a una ficha de Catálogo.");

                IWebElement sectionTitle = driver.FindElement(By.XPath("//span[@class='section-title']"));

                Console.WriteLine("Se va a comparar: '" + sectionTitle.Text + "' y '" + searched.Replace(searchable, "").TrimStart() + "'.");

                Assert.IsTrue(sectionTitle.Text.Equals(searched.Replace(searchable, "").TrimStart()));

                return true;
            }
        }
    }
}