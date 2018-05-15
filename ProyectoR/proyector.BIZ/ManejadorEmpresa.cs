using MongoDB.Bson;
using proyector.COMMON.Entidad;
using proyector.COMMON.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace proyector.BIZ
{
    public class ManejadorEmpresa : IManejadorEmpresa
    {

        IRepositorio<Empresa> empresa;

        public ManejadorEmpresa(IRepositorio<Empresa> empresa)
        {
            this.empresa = empresa;
        }


        public List<Empresa> Lista => empresa.Lista.OrderBy(p => p.Nombre).ToList();

        public bool Agregar(Empresa entidad)
        {
            return empresa.Crear(entidad);
        }

        public Empresa Buscador(ObjectId Id)
        {
            return Lista.Where(e => e.Id == Id).SingleOrDefault();
        }

        public bool Eliminar(ObjectId id)
        {
            return empresa.Eliminar(id);
        }

        public bool Modificar(Empresa entidad)
        {
            return empresa.Editar(entidad);
        }
    }
}
