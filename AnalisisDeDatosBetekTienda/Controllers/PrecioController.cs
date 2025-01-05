using AnalisisDeDatosBetekTienda.Models;
using AnalisisDeDatosBetekTienda.ViewModels.Precio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnalisisDeDatosBetekTienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrecioController : ControllerBase
    {
        private readonly tiendaContext _DBContext;

        public PrecioController(tiendaContext context)
        {
            _DBContext = context;
        }

        // Método para guardar un nuevo precio
        [HttpPost]
        [Route("SavePrecio")]
        public async Task<IActionResult> SavePrecio([FromBody] SavePrecioViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Verificar si el producto existe usando GUID
            var producto = await _DBContext.Productos.FindAsync(model.ProductoId);
            if (producto == null)
            {
                return NotFound(new { message = "Producto no encontrado" });
            }

            var precio = new Precio
            {
                Id = model.Id, // Usar el GUID generado en el frontend
                ProductoId = model.ProductoId,
                FechaInicio = model.FechaInicio,
                PrecioVenta = model.PrecioVenta
            };

            _DBContext.Precios.Add(precio);
            await _DBContext.SaveChangesAsync();

            return Ok(new { message = "Precio guardado exitosamente" });
        }
    }
}
