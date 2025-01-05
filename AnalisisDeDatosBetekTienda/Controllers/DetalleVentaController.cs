using AnalisisDeDatosBetekTienda.Models;
using AnalisisDeDatosBetekTienda.ViewModels.DetalleVenta;
using AnalisisDeDatosBetekTienda.ViewModels.DetalleVenta.PruebaGetAll;
using AnalisisDeDatosBetekTienda.ViewModels.Producto;
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
                        //Precio = d.Producto.Precio,
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


        //GetById

        [HttpGet]
        [Route("GetDetalleVentaById/{id}")]
        public async Task<IActionResult> GetDetalleVentaById(Guid id)
        {
            var detalleVenta = await _DBContext.DetalleVenta
                .Include(d => d.Producto)
                .ThenInclude(p => p.Categoria)
                .Include(d => d.Venta)
                .ThenInclude(v => v.Cliente)
                .Include(d => d.Venta)
                .ThenInclude(v => v.Empleado)
                .ThenInclude(e => e.Puesto)
                .Select(d => new GetByIdDetalleVentaViewModel
                {
                    Id = d.Id,
                    Cantidad = d.Cantidad,
                    Fecha = d.Venta.Fecha,
                    Producto = new ProductoViewModelVersionOne
                    {
                        Id = d.Producto.Id,
                        Nombre = d.Producto.Nombre,
                        Descripcion = d.Producto.Descripcion,
                        //Precio = d.Producto.Precio,
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
                            Puesto = d.Venta.Empleado.Puesto.Nombre
                        }
                    }
                })
                .FirstOrDefaultAsync(d => d.Id == id);

            if (detalleVenta == null)
            {
                return NotFound(new { message = "Detalle de venta no encontrado" });
            }

            return Ok(detalleVenta);
        }


        //Update

        [HttpPut]
        [Route("UpdateDetalleVenta/{id}")]
        public async Task<IActionResult> UpdateDetalleVenta(Guid id, [FromBody] UpdateDetalleVentaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var detalleVenta = await _DBContext.DetalleVenta.FindAsync(id);
            if (detalleVenta == null)
            {
                return NotFound(new { message = "Detalle de venta no encontrado" });
            }

            // Actualizar los valores
            detalleVenta.Cantidad = model.Cantidad;
            detalleVenta.ProductoId = model.ProductoId;
            detalleVenta.VentaId = model.VentaId;

            await _DBContext.SaveChangesAsync();
            return Ok(new { message = "Detalle de venta actualizado exitosamente" });
        }



        // Delete


        [HttpDelete]
        [Route("DeleteDetalleVenta/{id}")]
        public async Task<IActionResult> DeleteDetalleVenta(Guid id)
        {
            var detalleVenta = await _DBContext.DetalleVenta.FindAsync(id);
            if (detalleVenta == null)
            {
                return NotFound(new { message = "Detalle de venta no encontrado" });
            }

            _DBContext.DetalleVenta.Remove(detalleVenta);
            await _DBContext.SaveChangesAsync();

            return Ok(new { message = "Detalle de venta eliminado exitosamente" });
        }



        // GetById Simple


        // Método para obtener un detalle de venta por ID con información simplificada
        [HttpGet]
        [Route("GetDetalleVentaByIdSimple/{id}")]
        public async Task<IActionResult> GetDetalleVentaByIdSimple(Guid id)
        {
            // Buscar el detalle de venta en la base de datos por su ID
            var detalleVenta = await _DBContext.DetalleVenta
                .Where(d => d.Id == id)
                .Select(d => new GetByIdDetalleVentaViewModelSimple
                {
                    Id = d.Id,
                    Cantidad = d.Cantidad,
                    ProductoId = d.ProductoId,
                    VentaId = d.VentaId
                })
                .FirstOrDefaultAsync();

            // Verificar si el detalle de venta existe
            if (detalleVenta == null)
            {
                return NotFound(new { message = "Detalle de venta no encontrado" });
            }

            return Ok(detalleVenta);
        }


         

        // DetalleVenta Special GetAll
        [HttpGet]
        [Route("GetAllVentumSpecial")]
        public async Task<IActionResult> GetAllVentumSpecial()
        {
            // Obtener todos los DetalleVentum y proyectar los datos necesarios
            var detallesVenta = await _DBContext.DetalleVenta
                .Select(d => new DetalleVentaSpecialViewModel
                {
                    Id = d.Id,
                    VentaId = d.VentaId,
                    Cantidad = d.Cantidad,
                    Producto = new ProductoSpecialViewModel
                    {
                        //Precio = d.Producto.Precio,
                        Nombre = d.Producto.Nombre
                    }
                })
                .ToListAsync();

            return Ok(detallesVenta);
        }


        // Special Get All Byid

        // DetalleVentaController.cs
        [HttpGet]
        [Route("GetAllDetalleVentaSpecialById/{ventaId}")]
        public async Task<IActionResult> GetAllDetalleVentaSpecialById(Guid ventaId)
        {
            // Filtrar los detalles de venta que coincidan con el ventaId proporcionado
            var detallesVenta = await _DBContext.DetalleVenta
                .Where(d => d.VentaId == ventaId)
                .Select(d => new DetalleVentaSpecialViewModel
                {
                    Id = d.Id,
                    VentaId = d.VentaId,
                    Cantidad = d.Cantidad,
                    Producto = new ProductoSpecialViewModel
                    {
                        //Precio = d.Producto.Precio,
                        Nombre = d.Producto.Nombre
                    }
                })
                .ToListAsync();

            // Verificar si se encontraron resultados
            if (detallesVenta == null || !detallesVenta.Any())
            {
                return NotFound(new { message = "No se encontraron detalles de venta para el ventaId proporcionado" });
            }

            return Ok(detallesVenta);
        }




    }
}
