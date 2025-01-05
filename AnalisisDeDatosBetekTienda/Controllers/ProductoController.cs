using AnalisisDeDatosBetekTienda.Models;
using AnalisisDeDatosBetekTienda.ViewModels.Categoria;
using AnalisisDeDatosBetekTienda.ViewModels.Cliente;
using AnalisisDeDatosBetekTienda.ViewModels.Producto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

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
                //Precio = model.Precio,
                CategoriaId = model.CategoriaId,
                Imagen = model.Imagen
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
                    //Precio = p.Precio,
                    CategoriaNombre = p.Categoria.Nombre,
                    Imagen = p.Imagen
                })
                .ToListAsync();

            return Ok(productos);
        }



        // Método para eliminar un producto por su ID
        [HttpDelete]
        [Route("DeleteProducto/{id}")]
        public async Task<IActionResult> DeleteProducto(Guid id)
        {
            // Buscar el producto en la base de datos por su ID
            var producto = await _DBContext.Productos.FindAsync(id);

            // Verificar si el producto existe
            if (producto == null)
            {
                return NotFound(new { message = "Producto no encontrado" });
            }

            // Eliminar el producto
            _DBContext.Productos.Remove(producto);
            await _DBContext.SaveChangesAsync();

            return Ok(new { message = "Producto eliminado exitosamente" });
        }

        // Método para actualizar un producto por su ID
        [HttpPut]
        [Route("UpdateProducto/{id}")]
        public async Task<IActionResult> UpdateProducto(Guid id, [FromBody] SaveProductoViewModel model)
        {
            // Verificar si el modelo es válido
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

            // Buscar el producto en la base de datos por su ID
            var producto = await _DBContext.Productos.FindAsync(id);

            // Verificar si el producto existe
            if (producto == null)
            {
                return NotFound(new { message = "Producto no encontrado" });
            }

            // Actualizar las propiedades del producto
            producto.Nombre = model.Nombre;
            producto.Descripcion = model.Descripcion;
            //producto.
            //    Precio = model.Precio;
            producto.CategoriaId = model.CategoriaId;
            producto.Imagen = model.Imagen;

            // Guardar los cambios en la base de datos
            await _DBContext.SaveChangesAsync();

            return Ok(new { message = "Producto actualizado exitosamente" });
        }



    
        [HttpGet]
        [Route("GetProductById/{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            // Buscar el producto en la base de datos por su ID
            var producto = await _DBContext.Productos
                .Include(p => p.Categoria) // Incluir la relación con la categoría
                .Select(p => new GetByIdProductoViewModel // Usar el nuevo ViewModel
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    Descripcion = p.Descripcion,
                    //Precio = p.Precio,
                    Categoria = new GetAllCategoriaViewModel
                    {
                        Id = p.Categoria.Id,
                        Nombre = p.Categoria.Nombre
                    },
                    Imagen = p.Imagen
                })
                .FirstOrDefaultAsync(p => p.Id == id);

            // Verificar si el producto existe
            if (producto == null)
            {
                return NotFound(new { message = "Producto no encontrado" });
            }

            return Ok(producto);
        }


        // Método para obtener un producto por su ID
        //[HttpGet]
        //[Route("GetProductById/{id}")]
        //public async Task<IActionResult> GetProductById(Guid id)
        //{
        //    // Buscar el producto en la base de datos por su ID
        //    var producto = await _DBContext.Productos
        //        .Include(p => p.Categoria) // Incluir la relación con la categoría
        //        .Select(p => new GetAllProductoViewModel // Puedes usar GetAllProductoViewModel o crear uno nuevo si lo prefieres
        //        {
        //            Id = p.Id,
        //            Nombre = p.Nombre,
        //            Descripcion = p.Descripcion,
        //            Precio = p.Precio,
        //            CategoriaNombre = p.Categoria.Nombre // Obtener el nombre de la categoría
        //        })
        //        .FirstOrDefaultAsync(p => p.Id == id);

        //    // Verificar si el producto existe
        //    if (producto == null)
        //    {
        //        return NotFound(new { message = "Producto no encontrado" });
        //    }

        //    return Ok(producto);
        //}









    }
}
