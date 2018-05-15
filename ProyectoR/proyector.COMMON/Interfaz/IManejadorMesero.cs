using MongoDB.Bson;
using proyector.COMMON.Entidad;
using System;
using System.Collections.Generic;
using System.Text;

namespace proyector.COMMON.Interfaz
{
  public   interface IManejadorMesero : IManejadorGenerico<Mesero>
    {
        bool BuscarUsuario(ObjectId ID, string password);
    }
}
