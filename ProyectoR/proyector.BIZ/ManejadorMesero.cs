using MongoDB.Bson;
using proyector.COMMON.Entidad;
using proyector.COMMON.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace proyector.BIZ
{
  public   class ManejadorMesero : IManejadorMesero
    {

        IRepositorio<Mesero> mesero;

        public ManejadorMesero(IRepositorio<Mesero> mesero)
        {
            this.mesero = mesero;
        }

        public List<Mesero> Lista => mesero.Lista.OrderBy(p => p.Nombres).ToList();

        public bool Agregar(Mesero entidad)
        {
            return mesero.Crear(entidad);
        }

        public Mesero Buscador(ObjectId Id)
        {
            return Lista.Where(e => e.Id == Id).SingleOrDefault();
        }

        public bool BuscarUsuario(ObjectId Id, string password)
        {
            foreach (var item in mesero.Lista)
            {
                if (item.Id == Id && item.Password == password)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public bool Eliminar(ObjectId id)
        {
            return mesero.Eliminar(id);
        }

        public bool Modificar(Mesero entidad)
        {
            return mesero.Editar(entidad);
        }
    }
}
