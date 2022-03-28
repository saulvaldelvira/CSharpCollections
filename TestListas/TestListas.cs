using Microsoft.VisualStudio.TestTools.UnitTesting;
using Colecciones;
using System;

namespace TestListas {
    [TestClass]
    public class TestListas {
        private Lista<string> lS ;
        private Lista<int> lI;
        private Lista<Persona> lP;
        private Lista<double> lD;

        [TestMethod]
        public void TestString() {
            lS = new Lista<string>();
            Assert.ThrowsException<IndexOutOfRangeException>(() => lS.GetElemento(3));
            Assert.IsTrue(-2 == lS.Borrar("dssad"));
            //A�ado 3 strings a la lista
            lS.A�adir("Hola");
            lS.A�adir("Caracola");
            lS.A�adir("asdf");
            //Compruebo que se han a�adido y que el num de elementos es 3
            Assert.IsTrue("Hola".Equals(lS.GetElemento(0)));
            Assert.IsTrue("Caracola".Equals(lS.GetElemento(1)));
            Assert.IsTrue("asdf".Equals(lS.GetElemento(2)));
            Assert.IsTrue(3 == lS.NumeroElementos);
            //Borro un elemento
            Assert.IsTrue(0 == lS.Borrar("Caracola"));
            Assert.IsTrue(-1 == lS.Borrar("hgas"));
            Assert.IsTrue("Hola".Equals(lS.GetElemento(0)));
            Assert.IsTrue("asdf".Equals(lS.GetElemento(1)));
            Assert.IsTrue(2 == lS.NumeroElementos);
            //Pruebo el m�todo Contiene
            Assert.IsTrue(lS.Contiene("Hola"));
            Assert.IsFalse(lS.Contiene("..."));
            //Pruebo el m�todo GetElemento
            Assert.ThrowsException<IndexOutOfRangeException>(() => lS.GetElemento(5));
            Assert.ThrowsException<IndexOutOfRangeException>(() => lS.GetElemento(-2));
        }

        [TestMethod]
        public void TestPersona() {
            lP = new Lista<Persona>();
            Assert.ThrowsException<IndexOutOfRangeException>(() => lP.GetElemento(3));
            //A�ado 3 strings a la lista
            lP.A�adir(new Persona("Sa�l", "Vald", 18));
            lP.A�adir(new Persona("Hola", "caracola", 45));
            lP.A�adir(new Persona("a", "b", 0));
            //Compruebo que se han a�adido y que el num de elementos es 3
            Assert.IsTrue(new Persona("Sa�l", "Vald", 18).Equals(lP.GetElemento(0)));
            Assert.IsTrue(new Persona("Hola", "caracola", 45).Equals(lP.GetElemento(1)));
            Assert.IsTrue(new Persona("a", "b", 0).Equals(lP.GetElemento(2)));
            Assert.IsTrue(3 == lP.NumeroElementos);
            //Borro un elemento
            Assert.IsTrue(0 == lP.Borrar(new Persona("Hola", "caracola", 45)));
            Assert.IsTrue(new Persona("Sa�l", "Vald", 18).Equals(lP.GetElemento(0)));
            Assert.IsTrue(new Persona("a", "b", 0).Equals(lP.GetElemento(1)));
            Assert.IsTrue(2 == lP.NumeroElementos);
            //Pruebo el m�todo Contiene
            Assert.IsTrue(lP.Contiene(new Persona("a", "b", 0)));
            Assert.IsFalse(lP.Contiene(new Persona("sadasd", "sdad", 88)));
            //Pruebo el m�todo GetElemento
            Assert.ThrowsException<IndexOutOfRangeException>(() => lP.GetElemento(5));
            Assert.ThrowsException<IndexOutOfRangeException>(() => lP.GetElemento(-2));
        }

        [TestMethod]
        public void TestInt() {
            lI = new Lista<int>();
            Assert.ThrowsException<IndexOutOfRangeException>(() => lI.GetElemento(3));
            //A�ado 3 strings a la lista
            lI.A�adir(12);
            lI.A�adir(24);
            lI.A�adir(48);
            //Compruebo que se han a�adido y que el num de elementos es 3
            Assert.IsTrue(12.Equals(lI.GetElemento(0)));
            Assert.IsTrue(24.Equals(lI.GetElemento(1)));
            Assert.IsTrue(48.Equals(lI.GetElemento(2)));
            Assert.IsTrue(3 == lI.NumeroElementos);
            //Borro un elemento
            Assert.IsTrue(0 == lI.Borrar(48));
            Assert.IsTrue(12.Equals(lI.GetElemento(0)));
            Assert.IsTrue(24.Equals(lI.GetElemento(1)));
            Assert.IsTrue(2 == lI.NumeroElementos);
            //Pruebo el m�todo Contiene
            Assert.IsTrue(lI.Contiene(24));
            Assert.IsFalse(lI.Contiene(78));
            //Pruebo el m�todo GetElemento
            Assert.ThrowsException<IndexOutOfRangeException>(() => lI.GetElemento(5));
            Assert.ThrowsException<IndexOutOfRangeException>(() => lI.GetElemento(-2));
        }

        [TestMethod]
        public void TestDouble() {
            lD = new Lista<double>();
            Assert.ThrowsException<IndexOutOfRangeException>(() => lD.GetElemento(3));
            //A�ado 3 strings a la lista
            lD.A�adir(45.5);
            lD.A�adir(1.21);
            lD.A�adir(78.85);
            //Compruebo que se han a�adido y que el num de elementos es 3
            Assert.IsTrue(45.5.Equals(lD.GetElemento(0)));
            Assert.IsTrue(1.21.Equals(lD.GetElemento(1)));
            Assert.IsTrue(78.85.Equals(lD.GetElemento(2)));
            Assert.IsTrue(3 == lD.NumeroElementos);
            //Borro un elemento
            Assert.IsTrue(0 == lD.Borrar(78.85));
            Assert.IsTrue(45.5.Equals(lD.GetElemento(0)));
            Assert.IsTrue(1.21.Equals(lD.GetElemento(1)));
            Assert.IsTrue(2 == lD.NumeroElementos);
            //Pruebo el m�todo Contiene
            Assert.IsTrue(lD.Contiene(45.5));
            Assert.IsFalse(lD.Contiene(78));
            //Pruebo el m�todo GetElemento
            Assert.ThrowsException<IndexOutOfRangeException>(() => lD.GetElemento(5));
            Assert.ThrowsException<IndexOutOfRangeException>(() => lD.GetElemento(-2));
        }
    }
}
