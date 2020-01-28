using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP1;

namespace test1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSomme()
        {
            Assert.AreEqual(0, Program.calculSomme(-5), 0, "La fonction bug :(");
            Assert.AreEqual(0, Program.calculSomme(0), 0, "La fonction bug :(");
            Assert.AreEqual(6, Program.calculSomme(3), 0, "La fonction bug :(");
            Assert.AreEqual(125250, Program.calculSomme(500), 0, "La fonction bug :(");
        }
    }
}
