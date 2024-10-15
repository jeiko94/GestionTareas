using GestionTareas.Modelos;
using GestionTareas.Negocio;
using Microsoft.AspNetCore.Mvc;

namespace GestionTareas.Controllers
{
    //Controlador para gestionar las tareas
    [ApiController]
    [Route("api/[controller]")]
    public class TareasController : ControllerBase
    {
        private readonly ITareaServicio _tareaServicio;

        //Constructor
        public TareasController(ITareaServicio tareaServicio)
        {
            //Inyeccion de dependencias del servicio de tareas
            _tareaServicio = tareaServicio;
        }

        //Obtiene todas las tareas
        [HttpGet]
        public ActionResult<IEnumerable<Tarea>> ObtenerTareas()
        {
            var tareas = _tareaServicio.ObtenerTodas();
            return Ok(tareas);
        }

        //Obtener una tarea por su ID
        [HttpGet("{id}")]
        public ActionResult<Tarea> ObtenerTareaPorId(int id)
        {
            var tarea = _tareaServicio.ObtenerPorId(id);
            if (tarea == null)
            {
                return NotFound();
            }
            return Ok(tarea);
        }

        //Crear una nueva tarea
        [HttpPost]
        public ActionResult<Tarea> CrearTarea([FromBody] Tarea nuevaTarea)
        {
            _tareaServicio.Crear(nuevaTarea);
            return CreatedAtAction(nameof(ObtenerTareaPorId), new { id = nuevaTarea.Id }, nuevaTarea);
        }

        //Actualizar una tarea existente.
        [HttpPut("{id}")]
        public ActionResult ActualizarTarea(int id, [FromBody] Tarea tareaActualizada)
        {
            if (id != tareaActualizada.Id)
            {
                return BadRequest("El ID de la URL no conincide con el ID de la tarea.");
            }

            var tareaExistente = _tareaServicio.ObtenerPorId(id);
            if (tareaExistente == null)
            {
                return NotFound();
            }

            _tareaServicio.Actualizar(tareaExistente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult EliminarTarea(int id)
        {
            var tareaExistente = _tareaServicio.ObtenerPorId(id);
            if (tareaExistente == null)
            {
                return NotFound();
            }
            _tareaServicio.Eliminar(id);
            return NoContent();
        }


    }
}
