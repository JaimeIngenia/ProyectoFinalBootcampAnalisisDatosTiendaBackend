using AnalisisDeDatosBetekTienda.Models;
using AnalisisDeDatosBetekTienda.ViewModels.Fidelizacion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnalisisDeDatosBetekTienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FidelizacionController : ControllerBase
    {
        private readonly tiendaContext _DBContext;

        public FidelizacionController(tiendaContext context)
        {
            _DBContext = context;
        }


        // Método para guardar una nueva fidelización
        [HttpPost]
        [Route("SaveFidelizacion")]
        public async Task<IActionResult> SaveFidelizacion([FromBody] SaveFidelizacionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Verificar si el cliente y la membresía existen
            var cliente = await _DBContext.Clientes.FindAsync(model.ClienteId);
            var membresia = await _DBContext.Membresia.FindAsync(model.MembresiaId);

            if (cliente == null)
            {
                return NotFound(new { message = "Cliente no encontrado" });
            }

            if (membresia == null)
            {
                return NotFound(new { message = "Membresía no encontrada" });
            }

            var fidelizacion = new Fidelizacion
            {
                Id = Guid.NewGuid(),
                Puntos = model.Puntos,
                ClienteId = model.ClienteId,
                MembresiaId = model.MembresiaId
            };

            _DBContext.Fidelizacions.Add(fidelizacion);
            await _DBContext.SaveChangesAsync();

            return Ok(new { message = "Fidelización guardada exitosamente" });
        }

        // Método para obtener todas las fidelizaciones
        [HttpGet]
        [Route("GetAllFidelizaciones")]
        public async Task<IActionResult> GetAllFidelizaciones()
        {
            var fidelizaciones = await _DBContext.Fidelizacions
                .Include(f => f.Cliente)
                .Include(f => f.Membresia)
                .Select(f => new GetAllFidelizacionViewModel
                {
                    Id = f.Id,
                    Puntos = f.Puntos,
                    ClienteNombre = f.Cliente.Nombre,    // Asumiendo que el cliente tiene un campo 'Nombre'
                    MembresiaNombre = f.Membresia.Nombre // Asumiendo que la membresía tiene un campo 'Nombre'
                })
                .ToListAsync();

            return Ok(fidelizaciones);
        }





    }
}
