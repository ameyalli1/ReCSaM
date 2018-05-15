using System;
using System.Collections.Generic;
using System.Text;

namespace proyector.COMMON.Entidad
{
  public   class Usuario:BaseDTO
    {
        public string Correo { get; set; }
        public string Password { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Empresa { get; set; }
    }
}
