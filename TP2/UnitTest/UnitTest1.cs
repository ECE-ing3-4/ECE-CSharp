using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP2;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void testScalaire2D()
        {
            Vector2D vec2D = new Vector2D(2, 1, 2);
            Assert.AreEqual(4, vec2D.Scalar(), 0, "Erreur scalaire vecteur 2D");
        }
        [TestMethod]
        public void testScalaire3D()
        {
            Vector3D vec3D = new Vector3D(3, 2, 3, 4);
            Assert.AreEqual(72, vec3D.Scalar(), 0, "Erreur scalaire vecteur 3D");
        }
    }
}
