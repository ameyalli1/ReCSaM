using MongoDB.Bson;
using proyector.COMMON.Entidad;
using System;
using System.Collections.Generic;
using System.Text;

namespace proyector.COMMON.Interfaz
{
   public  interface IManejadorPregunta : IManejadorGenerico<Pregunta>
    {
        bool VerificarSiEsNumero(string cadena);
        int ContarPosicion(string datos, ObjectId ID);
        //  void ContarPosicion(List<ClaseGeneral> respuestas, string id);

    }
}
