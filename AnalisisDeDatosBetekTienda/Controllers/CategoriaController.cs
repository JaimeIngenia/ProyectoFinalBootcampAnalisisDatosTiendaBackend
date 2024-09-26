using AnalisisDeDatosBetekTienda.Models;
using AnalisisDeDatosBetekTienda.ViewModels.Categoria;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnalisisDeDatosBetekTienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly tiendaContext _DBContext;

        public CategoriaController(tiendaContext context)
        {
            _DBContext = context;
        }

        // Método para guardar una nueva categoría
        [HttpPost]
        [Route("SaveCategoria")]
        public async Task<IActionResult> SaveCategoria([FromBody] SaveCategoriaViewModel saveCategoriaViewModel)
        {
            if (ModelState.IsValid)
            {
                var categoria = new Categorium
                {
                    Nombre = saveCategoriaViewModel.Nombre
                };

                _DBContext.Categoria.Add(categoria);
                await _DBContext.SaveChangesAsync();
                return Ok(new { message = "Categoría guardada exitosamente" });

               
            }
            return BadRequest(ModelState);

        }

        // Método para obtener todas las categorías
        [HttpGet]
        [Route("GetAllCategoria")]
        public async Task<IActionResult> GetAllCategoria()
        {
            var categorias = await _DBContext.Categoria
                .Select(c => new GetAllCategoriaViewModel
                {
                    Id = c.Id,
                    Nombre = c.Nombre
                })
                .ToListAsync();

            return Ok(categorias);
        }
    }


}
