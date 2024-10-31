using AnalisisDeDatosBetekTienda.Models;
using AnalisisDeDatosBetekTienda.ViewModels.Sucrusal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnalisisDeDatosBetekTienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalController : ControllerBase
    {
        private readonly tiendaContext _DBContext;

        public SucursalController(tiendaContext context)
        {
            _DBContext = context;
        }




        // Método para obtener todas las sucursales
        [HttpGet]
        [Route("GetAllSucursales")]
        public async Task<IActionResult> GetAllSucursales()
        {
            var sucursales = await _DBContext.Sucursals
                .Select(s => new GetAllSucursalViewModel
                {
                    Id = s.Id,
                    Region = s.Region,
                    Direccion = s.Direccion,
                    Telefono = s.Telefono,
                    Ciudad = s.Ciudad
                })
                .ToListAsync();

            return Ok(sucursales);
        }

        // Método para guardar una nueva sucursal
        [HttpPost]
            [Route("SaveSucursal")]
            public async Task<IActionResult> SaveSucursal([FromBody] SaveSucursalViewModel model)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Crear un nuevo objeto Sucursal y asignar un nuevo GUID
                var sucursal = new Sucursal
                {
                    Id = Guid.NewGuid(), // Generar un nuevo GUID para la sucursal
                    Region = model.Region,
                    Direccion = model.Direccion,
                    Telefono = model.Telefono,
                    Ciudad = model.Ciudad
                };

                _DBContext.Sucursals.Add(sucursal);
                await _DBContext.SaveChangesAsync();

                return Ok(new { message = "Sucursal guardada exitosamente", sucursal.Id });
            }


    }
}
