using System;

namespace Colecciones
{
    public class Pila<T> {
        public uint MaxElementos { get; private set; }
        private Lista<T> _lista;
        public Pila(uint max)
        {
            MaxElementos = max;
            _lista = new Lista<T>();
        }

        public bool Push(T o)
        {
#if DEBUG
            int n = _lista.NumeroElementos;
#endif
            if (_lista.NumeroElementos == MaxElementos)
                return false;
            _lista.Añadir(o);
#if DEBUG
            if (n == _lista.NumeroElementos)
                return false;
            if (!_lista.GetUltimoElemento().Equals(o))
                return false;
#endif
            return true;
        }

        public T Pop()
        {
#if DEBUG
            int n = _lista.NumeroElementos;
#endif
            T o = _lista.GetUltimoElemento();
            _lista.Borrar(o);
#if DEBUG 
            if (n == _lista.NumeroElementos)
                throw new IndexOutOfRangeException("La pila está llena");
#endif
            return o;
        }

        public bool EstaVacia()
        {
            return _lista.NumeroElementos == 0;
        }

        public bool EstaLLena()
        {
            return _lista.NumeroElementos == MaxElementos;
        }
    }
}
