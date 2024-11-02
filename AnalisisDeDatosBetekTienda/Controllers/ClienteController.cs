using AnalisisDeDatosBetekTienda.Models;
using AnalisisDeDatosBetekTienda.ViewModels.Cliente;
using AnalisisDeDatosBetekTienda.ViewModels.Cliente.AnalisisDeDatosBetekTienda.ViewModels.Cliente;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnalisisDeDatosBetekTienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly tiendaContext _DBContext;

        public ClienteController(tiendaContext context)
        {
            _DBContext = context;
        }


        //Save


        [HttpPost]
        [Route("SaveCliente")]
        public async Task<IActionResult> SaveCliente([FromBody] SaveClienteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cliente = new Cliente
            {
                Id = Guid.NewGuid(),
                Nombre = model.Nombre,
                Apellido = model.Apellido,
                Email = model.Email,
                Telefono = model.Telefono
            };

            _DBContext.Clientes.Add(cliente);
            await _DBContext.SaveChangesAsync();

            return Ok(new { message = "Cliente guardado exitosamente" });
        }

        //GetAll

        [HttpGet]
        [Route("GetAllClientes")]
        public async Task<IActionResult> GetAllClientes()
        {
            var clientes = await _DBContext.Clientes
                .Select(c => new GetAllClienteViewModel
                {
                    Id = c.Id,
                    Nombre = c.Nombre,
                    Apellido = c.Apellido,
                    Email = c.Email,
                    Telefono = c.Telefono
                })
                .ToListAsync();

            return Ok(clientes);
        }










    }
}
