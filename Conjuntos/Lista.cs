using System;
using System.Collections;
using System.Collections.Generic;
namespace Colecciones{
    public class Lista<T>: IEnumerable<T> {
        private Node<T> Raiz { get; set; }
        public int NumeroElementos { get; private set; }
        public Lista() {
            Raiz = null;
            NumeroElementos = 0;
        }
        /**
         * Añade el elemento pasado como parámetro 
         * a la lista, en la última posición.
         * */
        public void Añadir(T clave) {
            if (Raiz == null)
                Raiz = new Node<T>(clave);
            else {
                Node<T> aux = Raiz;
                while (aux.Next != null)
                    aux = aux.Next;
                aux.Next = new Node<T>(clave);
            }
            NumeroElementos++;
        }
        /**
         * Borra el elemento pasado como parámetro de la lista
         * Si la raiz es nula, devuelve -2
         * Si el elemento no se encuentra en la lista, devuelve -1
         * Si el elemento se elimina correctamente, devuelve 0
         * */
        public int Borrar(T clave) {
            if (Raiz == null) return -2;
            else if (Raiz.Info.Equals(clave))
                Raiz = Raiz.Next;
            else {
                Node<T> aux = Raiz;
                while (aux.Next != null) {
                    if (aux.Next.Info.Equals(clave)) {
                        aux.Next = aux.Next.Next;
                        NumeroElementos--;
                        return 0;
                    }
                    aux = aux.Next;
                }
            }
            return -1;
        }
        /**
         * Devuelve el elemento en la posición dada como parámetro.
         * Si la raíz es nula, devuelve -2
         * Si la posición está fuera de los límites [0, NumeroElementos), devuelve -1
         * */
        public T GetElemento(int pos) {
            if (Raiz == null || pos < 0 || pos >= NumeroElementos)
                throw new IndexOutOfRangeException();
            Node<T> aux = Raiz;
            for(int i=0; i<pos; i++){
                aux = aux.Next;
            }
            return aux.Info;
        }
        public T GetUltimoElemento()
        {
            Node<T> aux = Raiz;
            while (aux.Next != null)
                aux = aux.Next;
            return aux.Info;
        }
        public bool Contiene(T clave) {
            Node<T> aux = Raiz;
            while (aux != null) {
                if(aux.Info.Equals(clave))  return true;
                aux = aux.Next;
            }
            return false;
        }
        public override string ToString() {
            string result = "[";
            if (Raiz == null) result += "Lista Vacía";
            Node<T> aux = Raiz;
            while (aux != null) {
                result+=aux.Info;
                result += aux.Next == null ? "" : " -> ";
                aux = aux.Next;
            }
            result += "]";
            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new EnumeradorLista<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new EnumeradorLista<T>(this);
        }
    }

    public static class Extensores
    {
        public static T Buscar<T>(IEnumerable<T> l, Predicate<T> p)
        {
            foreach (T t in l)
                if (p(t))
                    return t;
            Console.WriteLine("No se ha encontrado un elemento que cumpla la condición, se devuelve el elemento por defecto");
            return default;
        }

        public static IList<T> Filtrar<T>(IEnumerable<T> l, Predicate<T> p)
        {
            IList<T> result = new List<T>();
            foreach (T t in l)
                if (p(t))
                    result.Add(t);
            return result;
        }

        public static K Reducir<T, K>(IEnumerable<T> l, Func<K, T, K> f)
        {
            K result = default(K);
            foreach (T t in l)
                result = f(result, t);
            return result;
        }

        /// <summary>
        /// Método extensor de IEnumerable
        /// Transforma una colección de tipo T en una colección de tipo Q
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="Q"></typeparam>
        /// <param name="coleccion"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static IEnumerable<Q> Map<T, Q>(this IEnumerable<T> coleccion, Func<T, Q> func)
        {
            IList<Q> lista = new List<Q>();
            foreach (T actual in coleccion)
                lista.Add(func(actual));
            return lista;

        }


        static internal void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (T item in enumerable)
            {
                action(item);
            }
        }
    }

    internal class EnumeradorLista<T>: IEnumerator<T>
    {
        public T Current
        {
            get
            {
                return _list.GetElemento(_contador);
            }
        }

        object IEnumerator.Current => throw new NotImplementedException();
        Lista<T> _list;
        int _contador;

        public EnumeradorLista(Lista<T> l)
        {
            _list = l;
            Reset();
        }

        public void Dispose()
        {
            
        }

        public bool MoveNext()
        {
            return _contador++ != _list.NumeroElementos;
        }

        public void Reset()
        {
            _contador = -1;
        }
    }

    internal class Node<T> {
        internal T Info { get; set; }
        internal Node<T> Next { get; set; }
        public Node(T i) {
            Info = i;
            Next = null;
        }
    }
}
