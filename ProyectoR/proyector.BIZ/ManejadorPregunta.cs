using MongoDB.Bson;
using proyector.COMMON.Entidad;
using proyector.COMMON.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace proyector.BIZ
{
    public class ManejadorPregunta : IManejadorPregunta
    {
        IRepositorio<Pregunta> pregunta;

        public ManejadorPregunta(IRepositorio<Pregunta> pregunta)
        {
            this.pregunta = pregunta;
        }

        public List<Pregunta> Lista => pregunta.Lista.OrderBy(p => p.FechaHora).ToList();

        public bool Agregar(Pregunta entidad)
        {
            return pregunta.Crear(entidad);
        }

        public Pregunta Buscador(ObjectId Id)
        {
            return Lista.Where(e => e.Id == Id).SingleOrDefault();
        }

        public int ContarPosicion(string datos, ObjectId ID)
        {
            int contador = 0;
            int puntuacion = 0;
            // int puntacionFinal = 0;
            int limites = 0;
            foreach (var item in pregunta.Lista)
            {
                if (item.Id == ID)
                {
                    int NumRespuestas = item.Respuestas.Count;//contador de Respuestas//
                    limites = (int.Parse(item.ValorMaximo) - int.Parse(item.ValorMinimo)) / NumRespuestas;
                    foreach (var item2 in item.Respuestas)
                    {
                        contador++;
                        if (item2.Datos == datos)
                        {
                            puntuacion = contador;
                        }
                    }
                }
            }
            return limites * puntuacion;
        }

       

        public bool Eliminar(ObjectId id)
        {
            return pregunta.Eliminar(id);
        }

        public bool Modificar(Pregunta entidad)
        {
            return pregunta.Editar(entidad);
        }

        public bool VerificarSiEsNumero(string cadena)
        {
            foreach (var item in cadena)
            {
                if (!(char.IsNumber(item)))
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
    }
}
