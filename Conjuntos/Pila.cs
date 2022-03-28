using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colecciones
{
    public class Pila{
        public uint MaxElementos { get; private set; }
        private Lista _lista;
        public Pila(uint max)
        {
            MaxElementos = max;
            _lista = new Lista();
        }

        public bool Push(Object o)
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

        public Object Pop()
        {
#if DEBUG
            int n = _lista.NumeroElementos;
#endif
            Object o = _lista.GetUltimoElemento();
            _lista.Borrar(o);
#if DEBUG 
            if (n == _lista.NumeroElementos)
                return null;
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
