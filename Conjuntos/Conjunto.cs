using System;
namespace Colecciones {
    public class Conjunto<T> {
        private Lista<T> l;
        public int NumeroElementos { get; private set; }

        public Conjunto() {
            l = new Lista<T>();
        }
        public int Añadir(T obj) {
            if (!l.Contiene(obj)) {
                l.Añadir(obj);
                NumeroElementos++;
                return 0;
            } else return -1;
        }
        public int Borrar(T obj) {
            int r = l.Borrar(obj);
            if (r == 0) NumeroElementos--;
            return r;
        }
        public T GetElemento(int pos) {
            return l.GetElemento(pos);
        }
        public bool Contiene(T obj) {
            return l.Contiene(obj);
        }
        public override string ToString() {
            return l.ToString();
        }

        //SOBRECARGA DE OPERADORES
        //SUMA
        public static Conjunto<T> operator +(Conjunto<T> c1, T o) {
            Conjunto<T> result = c1;
            result.Añadir(o);
            return result;
        }
        public static Conjunto<T> operator +(Conjunto<T> c1, Conjunto<T> c2) {
            Conjunto<T> result = c1;
            for (int i = 0; i < c2.NumeroElementos; i++) {
                result.Añadir(c2.GetElemento(i));
            }
            return result;
        }
        //RESTA
        public static Conjunto<T> operator -(Conjunto<T> c1, T o) {
            Conjunto<T> result = c1;
            c1.Borrar(o);
            return result;
        }
        public static Conjunto<T> operator -(Conjunto<T> c1, Conjunto<T> c2) {
            Conjunto<T> result = c1;
            for (int i = 0; i < c2.NumeroElementos; i++) {
                result.Borrar(c2.GetElemento(i));
            }
            return result;
        }
        //INDIZADOR
        public T this[int index]{
            get => l.GetElemento(index);
        }
        //UNIÓN
        //Funciona igual que el operador Conjunto + Conjunto
        public static Conjunto<T> operator |(Conjunto<T> c1, Conjunto<T> c2) {
            Conjunto<T> result = c1;
            for (int i = 0; i < c2.NumeroElementos; i++) {
                result.Añadir(c2.GetElemento(i));
            }
            return result;
        }
        //INTERSECCIÓN
        public static Conjunto<T> operator &(Conjunto<T> c1, Conjunto<T> c2) {
            Conjunto<T> result = new Conjunto<T>();
            T o;
            for (int i=0; i<c2.NumeroElementos; i++) {
                o = c2.GetElemento(i);
                if (c2.Contiene(o))
                    result.Añadir(o);
            }
            return result;
        }
        //CONTIENE
        public static bool operator ^(Conjunto<T> c, T o) {
            return c.Contiene(o);
        }
    }
}
