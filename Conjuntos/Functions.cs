using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colecciones
{
    public static class Functions
    {
        public static T Buscar<T>(IEnumerable<T> l, Predicate<T> p)
        {
            foreach (T t in l)
                if (p(t))
                    return t;
            Console.WriteLine("No se ha encontrado un elemento que cumpla la condición, se devuelve el elemento por defecto");
            return default;
        }

        public static List<T> Filtrar<T>(IEnumerable<T> l, Predicate<T> p)
        {
            List<T> result = new List<T>();
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
}
