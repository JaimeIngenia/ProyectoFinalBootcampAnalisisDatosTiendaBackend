using AnalisisDeDatosBetekTienda.Models;
using AnalisisDeDatosBetekTienda.ViewModels.Producto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnalisisDeDatosBetekTienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        private readonly tiendaContext _DBContext;

        public ProductoController(tiendaContext context)
        {
            _DBContext = context;
        }


        //// Método para guardar un nuevo producto
        //[HttpPost]
        //[Route("SaveProducto")]
        //public async Task<IActionResult> SaveProducto([FromBody] SaveProductoViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    // Verificar si la categoría existe
        //    var categoria = await _DBContext.Categoria.FindAsync(model.CategoriaId);
        //    if (categoria == null)
        //    {
        //        return NotFound(new { message = "Categoría no encontrada" });
        //    }

        //    var producto = new Producto
        //    {
        //        Nombre = model.Nombre,
        //        Descripcion = model.Descripcion,
        //        Precio = model.Precio,
        //        CategoriaId = model.CategoriaId
        //    };

        //    _DBContext.Productos.Add(producto);
        //    await _DBContext.SaveChangesAsync();

        //    return Ok(new { message = "Producto guardado exitosamente" });
        //}

        //// Método para obtener todos los productos
        //[HttpGet]
        //[Route("GetAllProductos")]
        //public async Task<IActionResult> GetAllProductos()
        //{
        //    var productos = await _DBContext.Productos
        //        .Include(p => p.Categoria)  // Incluir la relación con la categoría
        //        .Select(p => new GetAllProductoViewModel
        //        {
        //            Id = p.Id,
        //            Nombre = p.Nombre,
        //            Descripcion = p.Descripcion,
        //            Precio = p.Precio,
        //            CategoriaNombre = p.Categoria.Nombre  // Obtener el nombre de la categoría
        //        })
        //        .ToListAsync();

        //    return Ok(productos);
        //}

        // Método para guardar un nuevo producto
        [HttpPost]
        [Route("SaveProducto")]
        public async Task<IActionResult> SaveProducto([FromBody] SaveProductoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Verificar si la categoría existe usando GUID
            var categoria = await _DBContext.Categoria.FindAsync(model.CategoriaId);
            if (categoria == null)
            {
                return NotFound(new { message = "Categoría no encontrada" });
            }

            var producto = new Producto
            {
                Id = Guid.NewGuid(), // Generar un nuevo GUID para el producto
                Nombre = model.Nombre,
                Descripcion = model.Descripcion,
                Precio = model.Precio,
                CategoriaId = model.CategoriaId
            };

            _DBContext.Productos.Add(producto);
            await _DBContext.SaveChangesAsync();

            return Ok(new { message = "Producto guardado exitosamente" });
        }

        // Método para obtener todos los productos
        [HttpGet]
        [Route("GetAllProductos")]
        public async Task<IActionResult> GetAllProductos()
        {
            var productos = await _DBContext.Productos
                .Include(p => p.Categoria) // Incluir la relación con la categoría
                .Select(p => new GetAllProductoViewModel
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    Descripcion = p.Descripcion,
                    Precio = p.Precio,
                    CategoriaNombre = p.Categoria.Nombre // Obtener el nombre de la categoría
                })
                .ToListAsync();

            return Ok(productos);
        }

    }
}
