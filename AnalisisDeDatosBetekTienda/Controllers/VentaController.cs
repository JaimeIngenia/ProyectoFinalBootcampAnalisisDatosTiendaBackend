using AnalisisDeDatosBetekTienda.Models;
using AnalisisDeDatosBetekTienda.ViewModels.Cliente;
using AnalisisDeDatosBetekTienda.ViewModels.Empleado;
using AnalisisDeDatosBetekTienda.ViewModels.Venta;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnalisisDeDatosBetekTienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {

        private readonly tiendaContext _DBContext;

        public VentaController(tiendaContext context)
        {
            _DBContext = context;
        }


        //Save

        [HttpPost]
        [Route("SaveVenta")]
        public async Task<IActionResult> SaveVenta([FromBody] SaveVentaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var venta = new Ventum
            {
                Id = model.Id,
                ClienteId = model.ClienteId,
                EmpleadoId = model.EmpleadoId,
                Fecha = model.Fecha
            };

            _DBContext.Venta.Add(venta);
            await _DBContext.SaveChangesAsync();

            return Ok(new { message = "Venta guardada exitosamente" });
        }


        //GetAll



        [HttpGet]
        [Route("GetAllVentas")]
        public async Task<IActionResult> GetAllVentas()
        {
            var ventas = await _DBContext.Venta
                .Select(v => new
                {
                    v.Id,
                    v.ClienteId,
                    v.EmpleadoId,
                    v.Fecha
                })
                .ToListAsync();

            return Ok(ventas);
        }

        //GetAllSimplyfy

        [HttpGet("GetAllSimplify")]
        public async Task<ActionResult<IEnumerable<VentaSimplifyViewModel>>> GetAllSimplify()
        {
            var ventas = await _DBContext.Venta
                .Include(v => v.Cliente)
                .Include(v => v.Empleado)
                .Select(v => new VentaSimplifyViewModel
                {
                    Id = v.Id,
                    Fecha = v.Fecha,
                    Cliente = new ClienteConsultaVentaViewModel
                    {
                        Id = v.Cliente.Id,
                        Nombre = v.Cliente.Nombre,
                        Apellido = v.Cliente.Apellido
                    },
                    Empleado = new EmpleadoConsultaVentaViewModel
                    {
                        Id = v.Empleado.Id,
                        Nombre = v.Empleado.Nombre,
                        Apellido = v.Empleado.Apellido
                    }
                })
                .ToListAsync();

            return Ok(ventas);
        }





        // GET: api/Venta/GetById/{id}
        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<GetVentaByIdViewModel>> GetById(Guid id)
        {
            // Busca la venta por su Id incluyendo el cliente y empleado relacionados
            var venta = await _DBContext.Venta
                .Where(v => v.Id == id)
                .Select(v => new GetVentaByIdViewModel
                {
                    Id = v.Id,
                    ClienteId = v.ClienteId,
                    EmpleadoId = v.EmpleadoId,
                    Fecha = v.Fecha
                })
                .FirstOrDefaultAsync();

            // Si no encuentra la venta, retorna un error 404
            if (venta == null)
            {
                return NotFound();
            }

            return Ok(venta);
        }




        // Update venta

        [HttpPut]
        [Route("UpdateVenta/{id}")]
        public async Task<IActionResult> UpdateVenta(Guid id, [FromBody] UpdateVentaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var venta = await _DBContext.Venta.FindAsync(id);
            if (venta == null)
            {
                return NotFound(new { message = "Venta no encontrada" });
            }

            // Actualizar los valores
            venta.ClienteId = model.ClienteId;
            venta.EmpleadoId = model.EmpleadoId;
            venta.Fecha = model.Fecha;

            await _DBContext.SaveChangesAsync();
            return Ok(new { message = "Venta actualizada exitosamente" });
        }



        //  Delete VENTA


        [HttpDelete]
        [Route("DeleteVenta/{id}")]
        public async Task<IActionResult> DeleteVenta(Guid id)
        {
            var venta = await _DBContext.Venta.FindAsync(id);
            if (venta == null)
            {
                return NotFound(new { message = "Venta no encontrada" });
            }

            _DBContext.Venta.Remove(venta);
            await _DBContext.SaveChangesAsync();

            return Ok(new { message = "Venta eliminada exitosamente" });
        }






    }
}
