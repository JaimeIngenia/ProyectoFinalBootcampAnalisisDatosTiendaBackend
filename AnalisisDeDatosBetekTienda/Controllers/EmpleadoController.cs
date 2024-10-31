using AnalisisDeDatosBetekTienda.Models;
using AnalisisDeDatosBetekTienda.ViewModels.Empleado;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnalisisDeDatosBetekTienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {

        private readonly tiendaContext _DBContext;

        public EmpleadoController(tiendaContext context)
        {
            _DBContext = context;
        }


        //Save Empleado
        [HttpPost]
        [Route("SaveEmpleado")]
        public async Task<IActionResult> SaveEmpleado([FromBody] SaveEmpleadoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Verificar si el horario existe
            var horario = await _DBContext.Horarios.FindAsync(model.HorarioId);
            if (horario == null)
            {
                return NotFound(new { message = "Horario no encontrado" });
            }

            // Verificar si el puesto existe
            var puesto = await _DBContext.Puestos.FindAsync(model.PuestoId);
            if (puesto == null)
            {
                return NotFound(new { message = "Puesto no encontrado" });
            }

            var empleado = new Empleado
            {
                Nombre = model.Nombre,
                Apellido = model.Apellido,
                HorarioId = model.HorarioId,
                PuestoId = model.PuestoId
            };

            _DBContext.Empleados.Add(empleado);
            await _DBContext.SaveChangesAsync();

            return Ok(new { message = "Empleado guardado exitosamente" });
        }


        // GetAllEmpleado

        [HttpGet]
        [Route("GetAllEmpleados")]
        public async Task<IActionResult> GetAllEmpleados()
        {
            var empleados = await _DBContext.Empleados
                .Select(e => new GetAllEmpleadosViewModel
                {
                    Id = e.Id,
                    Nombre = e.Nombre,
                    Apellido = e.Apellido,
                    HorarioId = e.HorarioId,
                    PuestoId = e.PuestoId
                })
                .ToListAsync();

            return Ok(empleados);
        }




    }
}
