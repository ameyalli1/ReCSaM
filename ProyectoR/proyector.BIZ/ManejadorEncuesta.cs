using MongoDB.Bson;
using proyector.COMMON.Entidad;
using proyector.COMMON.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace proyector.BIZ
{
    public class ManejadorEncuesta : IManejadorEncuesta
    {

        IRepositorio<Encuesta> encuesta;

        public ManejadorEncuesta(IRepositorio<Encuesta> encuesta)
        {
            this.encuesta = encuesta;
        }


        public List<Encuesta> Lista => encuesta.Lista.OrderBy(p => p.FechaHora).ToList();

        public bool Agregar(Encuesta entidad)
        {
            return encuesta.Crear(entidad);
        }

        public Encuesta Buscador(ObjectId Id)
        {
            return Lista.Where(e => e.Id == Id).SingleOrDefault();//falta checar si si son los datos a tomar
        }

        public bool Eliminar(ObjectId id)
        {
            return encuesta.Eliminar(id);
        }

        public bool Modificar(Encuesta entidad)
        {
            return encuesta.Editar(entidad);
        }
    }
}
