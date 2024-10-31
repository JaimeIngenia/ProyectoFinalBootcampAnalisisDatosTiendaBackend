using AnalisisDeDatosBetekTienda.Models;
using AnalisisDeDatosBetekTienda.ViewModels.Puesto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnalisisDeDatosBetekTienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PuestoController : ControllerBase
    {

        private readonly tiendaContext _DBContext;

        public PuestoController(tiendaContext context)
        {
            _DBContext = context;
        }

        // Método para guardar un puesto
        [HttpPost]
        [Route("SavePuesto")]
        public async Task<IActionResult> SavePuesto([FromBody] SavePuestoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var puesto = new Puesto
            {
                Nombre = model.Nombre
            };

            _DBContext.Puestos.Add(puesto);
            await _DBContext.SaveChangesAsync();

            return Ok(new { message = "Puesto guardado exitosamente", puesto.Id });
        }

        // Método para obtener todos los puestos
        [HttpGet]
        [Route("GetAllPuestos")]
        public async Task<IActionResult> GetAllPuestos()
        {
            var puestos = await _DBContext.Puestos
                .Select(p => new GetAllPuestosViewModel
                {
                    Id = p.Id,
                    Nombre = p.Nombre
                })
                .ToListAsync();

            return Ok(puestos);
        }



    }
}
