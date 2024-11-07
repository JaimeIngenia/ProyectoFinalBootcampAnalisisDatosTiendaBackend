using AnalisisDeDatosBetekTienda.Models;
using AnalisisDeDatosBetekTienda.ViewModels.TipoMovimiento;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnalisisDeDatosBetekTienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoMovimientoController : ControllerBase
    {

        private readonly tiendaContext _DBContext;

        public TipoMovimientoController(tiendaContext context)
        {
            _DBContext = context;
        }

        // Método para guardar un nuevo TipoMovimiento
        [HttpPost]
        [Route("SaveTipoMovimiento")]
        public async Task<IActionResult> SaveTipoMovimiento([FromBody] SaveTipoMovimientoViewModel saveTipoMovimientoViewModel)
        {
            if (ModelState.IsValid)
            {
                var tipoMovimiento = new TipoMovimiento
                {
                    Id = Guid.NewGuid(),
                    Nombre = saveTipoMovimientoViewModel.Nombre
                };

                _DBContext.TipoMovimientos.Add(tipoMovimiento);
                await _DBContext.SaveChangesAsync();
                return Ok(new { message = "Tipo de movimiento guardado exitosamente" });
            }
            return BadRequest(ModelState);
        }

        // Método para obtener todos los TipoMovimiento
        [HttpGet]
        [Route("GetAllTipoMovimiento")]
        public async Task<IActionResult> GetAllTipoMovimiento()
        {
            var tipoMovimientos = await _DBContext.TipoMovimientos
                .Select(tm => new GetAllTipoMovimientoViewModel
                {
                    Id = tm.Id,
                    Nombre = tm.Nombre
                })
                .ToListAsync();

            return Ok(tipoMovimientos);
        }







    }
}
