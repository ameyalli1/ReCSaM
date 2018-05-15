using MongoDB.Bson;
using MongoDB.Driver;
using proyector.COMMON.Entidad;
using proyector.COMMON.Interfaz;
using System;
using System.Collections.Generic;
using System.Text;

namespace proyecto.DAL
{
    public class RepositorioGenerico<T> : IRepositorio<T> where T : BaseDTO
    {
        private MongoClient client;
        private IMongoDatabase db;

        public RepositorioGenerico()
        {
            client = new MongoClient(new MongoUrl("mongodb://proyecto:proyectoisc@ds245337.mlab.com:45337/proyecto"));
            db = client.GetDatabase("proyecto");
        }


        private IMongoCollection<T> Collection()
        {
            return db.GetCollection<T>(typeof(T).Name);
        }




        public List<T> Lista => Collection().AsQueryable().ToList();

        public bool Crear(T entidad)
        {
            try
            {
                Collection().InsertOne(entidad);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Editar(T entidad)
        {
            try 
            {
                return Collection().ReplaceOne(p => p.Id == entidad.Id,entidad).ModifiedCount == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Eliminar(ObjectId id)
        {
            try
            {
               return Collection().DeleteOne(p => p.Id==id).DeletedCount==1;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
