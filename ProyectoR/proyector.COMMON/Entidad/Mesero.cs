using System;
using System.Collections.Generic;
using System.Text;

namespace proyector.COMMON.Entidad
{
  public  class Mesero:Usuario
    {
        public string Horario { get; set; }
        public string Turno { get; set; }
        public override string ToString()
        {
            return Nombres + " " + Apellidos;
        }
    }
}
