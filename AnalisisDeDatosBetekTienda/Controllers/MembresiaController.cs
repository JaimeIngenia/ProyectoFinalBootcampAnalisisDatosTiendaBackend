using AnalisisDeDatosBetekTienda.Models;
using AnalisisDeDatosBetekTienda.ViewModels.Membresia;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnalisisDeDatosBetekTienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembresiaController : ControllerBase
    {

        private readonly tiendaContext _DBContext;

        public MembresiaController(tiendaContext context)
        {
            _DBContext = context;
        }



        // Método para guardar una nueva membresía
        [HttpPost]
        [Route("SaveMembresia")]
        public async Task<IActionResult> SaveMembresia([FromBody] SaveMembresiaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var membresia = new Membresium
            {
                Id = Guid.NewGuid(),
                Nombre = model.Nombre
            };

            _DBContext.Membresia.Add(membresia);
            await _DBContext.SaveChangesAsync();

            return Ok(new { message = "Membresía guardada exitosamente" });
        }

        // Método para obtener todas las membresías
        [HttpGet]
        [Route("GetAllMembresias")]
        public async Task<IActionResult> GetAllMembresias()
        {
            var membresias = await _DBContext.Membresia
                .Select(m => new GetAllMembresiaViewModel
                {
                    Id = m.Id,
                    Nombre = m.Nombre
                })
                .ToListAsync();

            return Ok(membresias);
        }












    }
}
