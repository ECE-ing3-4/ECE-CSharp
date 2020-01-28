using System;
using System.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using Projet;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void testGetProducts()
        {
            //Projet.MainWindow;
            MainWindow a = new MainWindow();
            const string url = "https://fr.openfoodfacts.org/categorie/pains.json";
            JToken tok = a.getProducts(url);
            tok = tok["product"]["product_name"];
            MessageBox.Show((string)tok);
            Assert.Equals("je", (string)tok);
        }
    }
}
