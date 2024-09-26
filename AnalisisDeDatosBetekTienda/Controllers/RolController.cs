using AnalisisDeDatosBetekTienda.Models;
using AnalisisDeDatosBetekTienda.ViewModels.Rol;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnalisisDeDatosBetekTienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly tiendaContext _DBContext;

        public  RolController(tiendaContext context)
        {
            _DBContext = context;
        }


        //// Método para guardar un nuevo rol
        //[HttpPost("guardarRol")]
        //public IActionResult guardarRol([FromBody] Rol rol)
        //{
        //    try
        //    {
        //        if (rol == null)
        //        {
        //            return BadRequest("Datos de rol inválidos.");
        //        }

        //        // Agregar el nuevo rol al contexto
        //        _DBContext.Rols.Add(rol);

        //        // Guardar cambios en la base de datos
        //        _DBContext.SaveChanges();

        //        return Ok("Rol guardado exitosamente.");
        //    }
        //    catch (Exception ex)
        //    {
        //        // Manejo de excepciones
        //        return StatusCode(StatusCodes.Status500InternalServerError, $"Error guardando el rol: {ex.Message}");
        //    }
        //}

        [HttpPost]
        [Route("GuardarRol")]
        public async Task<IActionResult> GuardarRol([FromBody] RolViewModel rolViewModel)
        {
            if (ModelState.IsValid)
            {
                var rol = new Rol
                {
                    Nombre = rolViewModel.Nombre
                };

                _DBContext.Rols.Add(rol);
                await _DBContext.SaveChangesAsync();
                return Ok(new { message = "Rol guardado exitosamente" });
            }
            return BadRequest(ModelState);
        }

        // Método para Traer todos los roles
        //[HttpGet]
        //[Route("GetAllRoles")]
        //public async Task<IActionResult> GetAllRoles()
        //{
        //    var roles = await _DBContext.Rols.ToListAsync();
        //    return Ok(roles);
        //}

        [HttpGet]
        [Route("GetAllRoles")]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _DBContext.Rols
                .Select(r => new RolViewModelGetAll
                {
                    Id = r.Id,
                    Nombre = r.Nombre
                })
                .ToListAsync();

            return Ok(roles);
        }






    }
}
