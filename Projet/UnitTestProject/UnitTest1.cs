using System;
using System.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using Projet;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void testGetProducts()
        {
            //Projet.MainWindow;
            MainWindow a = new MainWindow();
            const string url = "https://ssl-api.openfoodfacts.org/api/v0/product/3124480182708";
            JToken tok = a.getProducts(url);
            tok = tok["product"]["product_name"];
            //MessageBox.Show((string)tok);
            string name = (string)tok;

            Assert.Equals("Tropical", name);
        }
    }
}
