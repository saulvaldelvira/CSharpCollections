using System;
namespace Colecciones {
    public class Conjunto {
        private Lista l;
        public int NumeroElementos { get; private set; }

        public Conjunto() {
            l = new Lista();
        }
        public int Añadir(Object obj) {
            if (!l.Contiene(obj)) {
                l.Añadir(obj);
                NumeroElementos++;
                return 0;
            } else return -1;
        }
        public int Borrar(Object obj) {
            int r = l.Borrar(obj);
            if (r == 0) NumeroElementos--;
            return r;
        }
        public Object GetElemento(int pos) {
            return l.GetElemento(pos);
        }
        public bool Contiene(Object obj) {
            return l.Contiene(obj);
        }
        public override string ToString() {
            return l.ToString();
        }

        //SOBRECARGA DE OPERADORES
        //SUMA
        public static Conjunto operator +(Conjunto c1, Object o) {
            Conjunto result = c1;
            result.Añadir(o);
            return result;
        }
        public static Conjunto operator +(Conjunto c1, Conjunto c2) {
            Conjunto result = c1;
            for (int i = 0; i < c2.NumeroElementos; i++) {
                result.Añadir(c2.GetElemento(i));
            }
            return result;
        }
        //RESTA
        public static Conjunto operator -(Conjunto c1, Object o) {
            Conjunto result = c1;
            c1.Borrar(o);
            return result;
        }
        public static Conjunto operator -(Conjunto c1, Conjunto c2) {
            Conjunto result = c1;
            for (int i = 0; i < c2.NumeroElementos; i++) {
                result.Borrar(c2.GetElemento(i));
            }
            return result;
        }
        //INDIZADOR
        public Object this[int index]{
            get => l.GetElemento(index);
        }
        //UNIÓN
        //Funciona igual que el operador Conjunto + Conjunto
        public static Conjunto operator |(Conjunto c1, Conjunto c2) {
            Conjunto result = c1;
            for (int i = 0; i < c2.NumeroElementos; i++) {
                result.Añadir(c2.GetElemento(i));
            }
            return result;
        }
        //INTERSECCIÓN
        public static Conjunto operator &(Conjunto c1, Conjunto c2) {
            Conjunto result = new Conjunto();
            Object o;
            for (int i=0; i<c2.NumeroElementos; i++) {
                o = c2.GetElemento(i);
                if (c2.Contiene(o))
                    result.Añadir(o);
            }
            return result;
        }
        //CONTIENE
        public static bool operator ^(Conjunto c, Object o) {
            return c.Contiene(o);
        }
    }
}
