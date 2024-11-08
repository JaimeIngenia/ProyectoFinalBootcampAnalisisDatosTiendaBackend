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


        // GetClientByID

        [HttpGet]
        [Route("GetClientById/{id}")]
        public async Task<IActionResult> GetClientById(Guid id)
        {
            // Buscar el cliente en la base de datos por su ID
            var cliente = await _DBContext.Clientes
                .Select(c => new GetByIdClienteViewModel
                {
                    Id = c.Id,
                    Nombre = c.Nombre,
                    Apellido = c.Apellido,
                    Email = c.Email,
                    Telefono = c.Telefono,
                })
                .FirstOrDefaultAsync(c => c.Id == id);

            // Verificar si el cliente existe
            if (cliente == null)
            {
                return NotFound(new { message = "Cliente no encontrado" });
            }

            return Ok(cliente);
        }


        // Update Client


        // Controllers/ClienteController.cs

        [HttpPut]
        [Route("UpdateCliente/{id}")]
        public async Task<IActionResult> UpdateCliente(Guid id, [FromBody] SaveClienteViewModel model)
        {
            // Verificar si el modelo es válido
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Buscar el cliente en la base de datos por su ID
            var cliente = await _DBContext.Clientes.FindAsync(id);

            // Verificar si el cliente existe
            if (cliente == null)
            {
                return NotFound(new { message = "Cliente no encontrado" });
            }

            // Actualizar las propiedades del cliente
            cliente.Nombre = model.Nombre;
            cliente.Apellido = model.Apellido;
            cliente.Email = model.Email;
            cliente.Telefono = model.Telefono;

            // Guardar los cambios en la base de datos
            await _DBContext.SaveChangesAsync();

            return Ok(new { message = "Cliente actualizado exitosamente" });
        }




        // Método para eliminar un cliente
        [HttpDelete]
        [Route("DeleteClient/{id}")]
        public async Task<IActionResult> DeleteClient(Guid id)
        {
            // Buscar el cliente en la base de datos por su ID
            var cliente = await _DBContext.Clientes.FindAsync(id);

            // Verificar si el cliente existe
            if (cliente == null)
            {
                return NotFound(new { message = "Cliente no encontrado" });
            }

            // Eliminar el cliente de la base de datos
            _DBContext.Clientes.Remove(cliente);
            await _DBContext.SaveChangesAsync();

            return Ok(new { message = "Cliente eliminado exitosamente" });
        }











    }
}
