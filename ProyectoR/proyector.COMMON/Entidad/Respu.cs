using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace proyector.COMMON.Entidad
{
  public   class Respu : BaseDTO
    {
        public string IdEncuesta { get; set; }
        public string IdPregunta { get; set; }
        public int Respuestas { get; set; }
        public string IdMesero { get; set; }
    }
}
