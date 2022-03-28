using System;
using Colecciones;
namespace APP {
    internal class Program {
        static void Main(string[] args) {
            Lista<int> l = new Lista<int>();
            Console.WriteLine("(GetElemento) Si la raíz es nula, devuelve -2?: " + (l.GetElemento(0) == null));
            Console.WriteLine("ToString de la lista vacía: \n\t" + l.ToString());
            l.Añadir(1);
            Console.WriteLine("Añadimos un 1\n\t" + l.ToString());
            l.Añadir(3);
            Console.WriteLine("Añadimos un 3\n\t" + l.ToString());
            l.Añadir(2);
            Console.WriteLine("Añadimos un 2\n\t" + l.ToString());
            l.Borrar(3);
            Console.WriteLine("Borramos el 3\n\t" + l.ToString());
            l.Borrar(2);
            Console.WriteLine("Borramos el 2\n\t" + l.ToString());
            l.Añadir(2);
            Console.WriteLine("(GetElemento) Si la posición es mayor que el " +
                "numero de elementos, devuelve null?: " + (l.GetElemento(52) == null));
            Console.WriteLine("(GetElemento) Si la posición es menor que el " +
                "numero de elementos, devuelve -1?: " + (l.GetElemento(-1) == null));
            Console.WriteLine("(GetElemento) Si se especifica una posicion válida, devuelve el valor " +
                "en esa posición?: " + (l.GetElemento(1).Equals(2) && l.GetElemento(0).Equals(1)));
        }
    }
}
