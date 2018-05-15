using MongoDB.Bson;
using proyector.COMMON.Entidad;
using proyector.COMMON.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace proyector.BIZ
{
    public class ManejadorRespu : IManejadorRespu
    {

        IRepositorio<Respu> respu;

        public ManejadorRespu(IRepositorio<Respu> respu)
        {
            this.respu = respu;
        }


        public List<Respu> Lista => respu.Lista.OrderBy(p => p.Id).ToList();

        public bool Agregar(Respu entidad)
        {
            return respu.Crear(entidad);
        }

        public Respu Buscador(ObjectId Id)
        {
            return Lista.Where(e => e.Id == Id).SingleOrDefault();
        }

        public bool Eliminar(ObjectId id)
        {
            return respu.Eliminar(id);
        }

        public bool Modificar(Respu entidad)
        {
            return respu.Editar(entidad);
        }
    }
}
