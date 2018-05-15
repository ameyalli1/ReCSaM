using MongoDB.Bson;
using proyector.COMMON.Entidad;
using System;
using System.Collections.Generic;
using System.Text;

namespace proyector.COMMON.Interfaz
{
  public   interface IRepositorio<T> where T : BaseDTO
    {
        bool Crear(T entidad);
        bool Editar(T entidad);
        bool Eliminar(ObjectId id);
        List<T> Lista { get; }
    }
}
