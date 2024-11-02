using AnalisisDeDatosBetekTienda.Models;
using AnalisisDeDatosBetekTienda.ViewModels.Venta;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnalisisDeDatosBetekTienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {

        private readonly tiendaContext _DBContext;

        public VentaController(tiendaContext context)
        {
            _DBContext = context;
        }


        //Save

        [HttpPost]
        [Route("SaveVenta")]
        public async Task<IActionResult> SaveVenta([FromBody] SaveVentaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var venta = new Ventum
            {
                Id = model.Id,
                ClienteId = model.ClienteId,
                EmpleadoId = model.EmpleadoId,
                Fecha = model.Fecha
            };

            _DBContext.Venta.Add(venta);
            await _DBContext.SaveChangesAsync();

            return Ok(new { message = "Venta guardada exitosamente" });
        }


        //GetAll



        [HttpGet]
        [Route("GetAllVentas")]
        public async Task<IActionResult> GetAllVentas()
        {
            var ventas = await _DBContext.Venta
                .Select(v => new
                {
                    v.Id,
                    v.ClienteId,
                    v.EmpleadoId,
                    v.Fecha
                })
                .ToListAsync();

            return Ok(ventas);
        }









    }
}
