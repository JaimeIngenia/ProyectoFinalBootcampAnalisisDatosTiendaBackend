using AnalisisDeDatosBetekTienda.Models;
using AnalisisDeDatosBetekTienda.ViewModels.DetalleVenta;
using AnalisisDeDatosBetekTienda.ViewModels.DetalleVenta.PruebaGetAll;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnalisisDeDatosBetekTienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleVentaController : ControllerBase
    {


        private readonly tiendaContext _DBContext;

        public DetalleVentaController(tiendaContext context)
        {
            _DBContext = context;
        }

        //Save

        [HttpPost]
        [Route("SaveDetalleVenta")]
        public async Task<IActionResult> SaveDetalleVenta([FromBody] SaveDetalleVentaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Verificar si el Producto existe
            var producto = await _DBContext.Productos.FindAsync(model.ProductoId);
            if (producto == null)
            {
                return NotFound(new { message = "Producto no encontrado" });
            }

            // Verificar si la Venta existe
            var venta = await _DBContext.Venta.FindAsync(model.VentaId);
            if (venta == null)
            {
                return NotFound(new { message = "Venta no encontrada" });
            }

            var detalleVenta = new DetalleVentum
            {
                Id = Guid.NewGuid(),
                Cantidad = model.Cantidad,
                ProductoId = model.ProductoId,
                VentaId = model.VentaId
            };

            _DBContext.DetalleVenta.Add(detalleVenta);
            await _DBContext.SaveChangesAsync();

            return Ok(new { message = "Detalle de venta guardado exitosamente" });
        }

        //GetAll

        [HttpGet]
        [Route("GetAllDetalleVentas")]
        public async Task<IActionResult> GetAllDetalleVentas()
        {
            var detalleVentas = await _DBContext.DetalleVenta
                .Include(d => d.Producto)
                    .ThenInclude(p => p.Categoria) // Incluir la relación con Categoria
                .Include(d => d.Venta)
                    .ThenInclude(v => v.Cliente)   // Incluir la relación con Cliente
                .Include(d => d.Venta)
                    .ThenInclude(v => v.Empleado)  // Incluir la relación con Empleado
                    .ThenInclude(e => e.Puesto)    // Incluir la relación con Puesto (si existe esta relación)
                .Select(d => new GetAllDetalleVentaViewModelVersionOne
                {
                    Id = d.Id,
                    Cantidad = d.Cantidad,
                    Fecha = d.Venta.Fecha,
                    Producto = new ProductoViewModelVersionOne
                    {
                        Id = d.Producto.Id,
                        Nombre = d.Producto.Nombre,
                        Descripcion = d.Producto.Descripcion,
                        Precio = d.Producto.Precio,
                        Categoria = new CategoriaViewModelVersionOne
                        {
                            Id = d.Producto.Categoria.Id,
                            Nombre = d.Producto.Categoria.Nombre
                        }
                    },
                    Venta = new VentaViewModelVersionOne
                    {
                        Id = d.Venta.Id,
                        Fecha = d.Venta.Fecha,
                        Cliente = new ClienteViewModelVersionOne
                        {
                            Id = d.Venta.Cliente.Id,
                            Nombre = d.Venta.Cliente.Nombre,
                            Apellido = d.Venta.Cliente.Apellido,
                            Telefono = d.Venta.Cliente.Telefono,
                            Email = d.Venta.Cliente.Email
                        },
                        Empleado = new EmpleadoViewModelVersionOne
                        {
                            Id = d.Venta.Empleado.Id,
                            Nombre = d.Venta.Empleado.Nombre,
                            Apellido = d.Venta.Empleado.Apellido,
                            HorarioId = d.Venta.Empleado.HorarioId,
                            Puesto = d.Venta.Empleado.Puesto.Nombre // Asumiendo que `Puesto` tiene un campo `Nombre`
                        }
                    }
                })
                .ToListAsync();

            return Ok(detalleVentas);
        }











    }
}
