using Microsoft.VisualStudio.TestTools.UnitTesting;
using Colecciones;

namespace TestConjuntos {
    [TestClass]
    public class TestConjuntos {
        private Conjunto c;

        [TestInitialize]
        public void Init() {
            c = new Conjunto();
        }

        [TestMethod]
        public void TestC() {
            Assert.AreEqual(0, c.NumeroElementos);
            c = c + 2;
            Assert.AreEqual(1, c.NumeroElementos);
            c = c + 5;
            Assert.AreEqual(2, c.NumeroElementos);
            Assert.AreEqual(2, c[0]);
            Assert.AreEqual(5, c[1]);
            c = c - 2;
            Assert.AreEqual(5, c[0]);
            Conjunto aux = new Conjunto();
            aux = aux + 12;
            aux = aux + 13;
            aux = aux + 14;
            c = c + aux;
            Assert.AreEqual(12, c[1]);
            Assert.AreEqual(13, c[2]);
            Assert.AreEqual(14, c[3]);
            Conjunto p = c & aux;
            Assert.AreEqual(12, p[0]);
            Assert.AreEqual(13, p[1]);
            Assert.AreEqual(14, p[2]);
            Assert.AreEqual(3, p.NumeroElementos);
            p = c | aux;
            Assert.AreEqual(5, p[0]);
            Assert.AreEqual(12, p[1]);
            Assert.AreEqual(13, p[2]);
            Assert.AreEqual(14, p[3]);
            Assert.IsTrue(c ^ 12);
            Assert.IsFalse(c ^ 78);
            Assert.AreEqual("[5 -> 12 -> 13 -> 14]", p.ToString());
        }
    }
}
