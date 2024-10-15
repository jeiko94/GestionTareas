using GestionTareas.Modelos;
using GestionTareas.Negocio;
using System.Collections.Generic;
using System.Linq;


namespace GestionTareas.Negocio
{
    //Implementa las operaciones para gestionar tareas
    public class TareaServicio : ITareaServicio
    {
        //Lista estatica para simular una base de datos en memoria
        private static List<Tarea> tareas = new List<Tarea>();
        private static int contadorId = 1;

        public void Crear(Tarea tarea)
        {
            tarea.Id = contadorId++;
            tareas.Add(tarea);
        }

        public void Actualizar(Tarea tarea)
        {
            var tareaExistente = ObtenerPorId(tarea.Id);
            if (tareaExistente != null)
            {
                tareaExistente.Titulo = tarea.Titulo;
                tareaExistente.Completada = tarea.Completada;
            }
        }

        public void Eliminar(int id)
        {
            var tarea = ObtenerPorId(id);
            if (tarea != null)
            {
                tareas.Remove(tarea);
            }
        }

        public List<Tarea> ObtenerTodas()
        {
            return tareas;
        }

        public Tarea ObtenerPorId(int id)
        {
            return tareas.FirstOrDefault(t => t.Id == id);
        }
    }
}
