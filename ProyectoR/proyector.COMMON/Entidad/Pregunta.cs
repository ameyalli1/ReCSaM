using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace proyector.COMMON.Entidad
{
   public  class Pregunta:BaseDTO
    {
        public ObjectId IdEncuesta { get; set; }
        public string Text { get; set; }
        public List<ClaseGenera> Respuestas { get; set; }
        public string ValorMinimo { get; set; }
        public string ValorMaximo { get; set; }
        public override string ToString()
        {
            return Respuestas + "\n";
        }
    }
}
