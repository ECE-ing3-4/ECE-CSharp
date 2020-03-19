using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using Projet;

namespace UnitTestProject1
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
            JToken tok = a.GetProducts(url);
            tok = tok["product"]["product_name"];
            //MessageBox.Show((string)tok);
            string name = (string)tok;

            Assert.AreEqual("Tropical", name);
        }
    }
}
