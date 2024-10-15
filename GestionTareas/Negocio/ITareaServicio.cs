using GestionTareas.Modelos;

namespace GestionTareas.Negocio
{
    //Define las operaciones para gestionar tareas.
    public interface ITareaServicio
    {
        //Obtiene todas las tareas
        List<Tarea> ObtenerTodas();
        //Obtiene una tarea por su ID
        Tarea ObtenerPorId(int id);
        //Crear una nueva tarea
        void Crear(Tarea tarea);
        //Actualizar una tarea existente
        void Actualizar(Tarea tarea);
        //Elimina una tarea por su ID
        void Eliminar(int id);
    }
}
