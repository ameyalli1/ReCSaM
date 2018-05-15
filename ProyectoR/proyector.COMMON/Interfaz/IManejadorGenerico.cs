using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace proyector.COMMON.Interfaz
{
   public  interface IManejadorGenerico <T>
    {
        bool Agregar(T entidad);
        List<T> Lista { get; }
        bool Eliminar(ObjectId id);
        bool Modificar(T entidad);
        T Buscador(ObjectId Id);
    }
}
