using System;

namespace Colecciones
{
    public class Persona {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        private int _edad;
        public int Edad {
            get {
                return _edad;
            }
            set {
                if(value >= 0)
                    _edad = value;
            } 
        }
        public Persona(string n="Desconocido", string a="Desconocido", int e=0) {
            Edad = e;
            Nombre = n;
            Apellidos = a;
        }

        public override bool Equals(object obj) {
            if (obj == null) return false;
            Persona other = obj as Persona;
            if(other == null) return false;
            if(Edad != other.Edad) return false;
            if (!Nombre.Equals(other.Nombre)) return false;
            if (!Apellidos.Equals(other.Apellidos)) return false;
            return true;
        }
    }
}
