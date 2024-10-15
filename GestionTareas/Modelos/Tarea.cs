namespace GestionTareas.Modelos
{
    //Representa una tarea en el sistema
    public class Tarea
    {
        //Identificador unico de la tarea
        public int Id { get; set; }
        //titulo o descripción de la tarea
        public string Titulo { get; set; }
        //Indica si la tarea ha sido completada
        public bool Completada { get; set; }
    }
}
