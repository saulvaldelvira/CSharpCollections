using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Colecciones;
namespace Test
{
    [TestClass]
    public class TestLinq
    {
        [TestMethod]
        public void FirstOrDefaultTest()
        {
            Lista<string> lS = new Lista<string>();
            lS.Añadir("Hola");
            lS.Añadir("Caracola");
            lS.Añadir("asdf");
            Assert.AreEqual("Hola", lS.FirstOrDefault());
        }
    }
}
