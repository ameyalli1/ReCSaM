using MongoDB.Bson;
using proyector.COMMON.Entidad;
using proyector.COMMON.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace proyector.BIZ
{
    public class ManejadorDatosFotografia : IManejadorFotografia
    {
        IRepositorio<DatosFotografia> datosFotografia;

        public ManejadorDatosFotografia(IRepositorio<DatosFotografia> datosFotografia)
        {
            this.datosFotografia = datosFotografia;
        }
        public List<DatosFotografia> Lista => datosFotografia.Lista;

        public bool Agregar(DatosFotografia entidad)
        {
            return datosFotografia.Crear(entidad);
        }

        public DatosFotografia Buscador(ObjectId Id)
        {
            return Lista.Where(e => e.Id == Id).SingleOrDefault();//falta checar si si son los datos a tomar
        }

        public bool Eliminar(ObjectId id)
        {
            return datosFotografia.Eliminar(id);
        }

        public bool Modificar(DatosFotografia entidad)
        {
            return datosFotografia.Editar(entidad);
        }
    }
}
