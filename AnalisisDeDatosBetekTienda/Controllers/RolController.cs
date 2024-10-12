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

        //[HttpPost]
        //[Route("GuardarRol")]
        //public async Task<IActionResult> GuardarRol([FromBody] RolViewModel rolViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var rol = new Rol
        //        {
        //            Nombre = rolViewModel.Nombre
        //        };

        //        _DBContext.Rols.Add(rol);
        //        await _DBContext.SaveChangesAsync();
        //        return Ok(new { message = "Rol guardado exitosamente" });
        //    }
        //    return BadRequest(ModelState);
        //}



        //[HttpGet]
        //[Route("GetAllRoles")]
        //public async Task<IActionResult> GetAllRoles()
        //{
        //    var roles = await _DBContext.Rols
        //        .Select(r => new RolViewModelGetAll
        //        {
        //            Id = r.Id,
        //            Nombre = r.Nombre
        //        })
        //        .ToListAsync();

        //    return Ok(roles);
        //}

        // Método para guardar un nuevo rol
        [HttpPost]
        [Route("GuardarRol")]
        public async Task<IActionResult> GuardarRol([FromBody] RolViewModel rolViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var rol = new Rol
            {
                Id = Guid.NewGuid(), // Generar un nuevo GUID para el rol
                Nombre = rolViewModel.Nombre
            };

            _DBContext.Rols.Add(rol);
            await _DBContext.SaveChangesAsync();
            return Ok(new { message = "Rol guardado exitosamente" });
        }

        // Método para obtener todos los roles
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
