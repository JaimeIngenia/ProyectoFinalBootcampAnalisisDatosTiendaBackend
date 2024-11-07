using AnalisisDeDatosBetekTienda.Models;
using AnalisisDeDatosBetekTienda.ViewModels.MovimientoInventario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnalisisDeDatosBetekTienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientoInventarioController : ControllerBase
    {
        private readonly tiendaContext _DBContext;

        public MovimientoInventarioController(tiendaContext context)
        {
            _DBContext = context;
        }





        // Método para guardar un nuevo MovimientoInventario
        [HttpPost]
        [Route("SaveMovimientoInventario")]
        public async Task<IActionResult> SaveMovimientoInventario([FromBody] SaveMovimientoInventarioViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Verificar si Producto, Empleado y TipoMovimiento existen usando sus GUIDs
            var producto = await _DBContext.Productos.FindAsync(model.ProductoId);
            if (producto == null) return NotFound(new { message = "Producto no encontrado" });

            var empleado = await _DBContext.Empleados.FindAsync(model.EmpleadoId);
            if (empleado == null) return NotFound(new { message = "Empleado no encontrado" });

            var tipoMovimiento = await _DBContext.TipoMovimientos.FindAsync(model.TipoMovimientoId);
            if (tipoMovimiento == null) return NotFound(new { message = "Tipo de movimiento no encontrado" });

            var movimientoInventario = new MovimientoInventario
            {
                Id = Guid.NewGuid(),
                ProductoId = model.ProductoId,
                Cantidad = model.Cantidad,
                EmpleadoId = model.EmpleadoId,
                Tipomovimientoid = model.TipoMovimientoId,
                Fecha = model.Fecha
            };

            _DBContext.MovimientoInventarios.Add(movimientoInventario);
            await _DBContext.SaveChangesAsync();

            return Ok(new { message = "Movimiento de inventario guardado exitosamente" });
        }

        // Método para obtener todos los MovimientosInventario
        [HttpGet]
        [Route("GetAllMovimientoInventario")]
        public async Task<IActionResult> GetAllMovimientoInventario()
        {
            var movimientosInventario = await _DBContext.MovimientoInventarios
                .Include(mi => mi.Producto)
                .Include(mi => mi.Empleado)
                .Include(mi => mi.Tipomovimiento)
                .Select(mi => new GetAllMovimientoInventarioViewModel
                {
                    Id = mi.Id,
                    ProductoId = mi.ProductoId,
                    ProductoNombre = mi.Producto.Nombre,
                    Cantidad = mi.Cantidad,
                    EmpleadoId = mi.EmpleadoId,
                    EmpleadoNombre = mi.Empleado.Nombre,
                    TipoMovimientoId = mi.Tipomovimientoid,
                    TipoMovimientoNombre = mi.Tipomovimiento.Nombre,
                    Fecha = mi.Fecha
                })
                .ToListAsync();

            return Ok(movimientosInventario);
        }





    }
}
