using System;
using System.Collections.Generic;
using System.Text;

namespace proyector.COMMON.Entidad
{
    public class Encuesta:BaseDTO
    {
        public string Nombre { get; set; }
        public string Duenio { get; set; }
        public string Objetivo { get; set; }
        public bool MostrarPreguntasAleatoriamente { get; set; }
    }
}
