using AnalisisDeDatosBetekTienda.Models;
using AnalisisDeDatosBetekTienda.ViewModels.Precio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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



        // Método para actualizar un precio


        [HttpPut]
        [Route("UpdatePrecio/{id}")]
        public async Task<IActionResult> UpdatePrecio(Guid id, [FromBody] UpdatePrecioViewModel model)
        {
            // Verificar si el modelo es válido
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Buscar el precio en la base de datos por su ID
            var precio = await _DBContext.Precios.FindAsync(id);

            // Verificar si el precio existe
            if (precio == null)
            {
                return NotFound(new { message = "Precio no encontrado" });
            }

            // Actualizar las propiedades del precio
            precio.PrecioVenta = model.PrecioVenta;

            // Guardar los cambios en la base de datos
            await _DBContext.SaveChangesAsync();

            return Ok(new { message = "Precio actualizado exitosamente" });
        }



        // Método para Obtener el Precio por ProductoId



        [HttpGet]
        [Route("GetPrecioByProductId/{productoId}")]
        public async Task<IActionResult> GetPrecioByProductId(Guid productoId)
        {
            var precio = await _DBContext.Precios
                .Where(p => p.ProductoId == productoId )
                .Select(p => new GetPrecioViewModelByProductId
                {
                    Id = p.Id,
                    PrecioVenta = p.PrecioVenta
                })
                .FirstOrDefaultAsync();
            //.FirstOrDefaultAsync(p => p.Id == productoId);

            if (precio == null)
            {
                return NotFound(new { message = "Precio no encontrado" });
            }

            return Ok(precio);
        }





    }
}
