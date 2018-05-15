using System;
using System.Collections.Generic;
using System.Text;

namespace proyector.COMMON.Entidad
{
 public   class ClaseGenera
    {
        public string Datos { get; set; }
        public override string ToString()
        {
            return Datos + "\n";
        }
    }
}
