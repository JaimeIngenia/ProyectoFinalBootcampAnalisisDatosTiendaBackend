using AnalisisDeDatosBetekTienda.Models;
using AnalisisDeDatosBetekTienda.ViewModels.Horario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnalisisDeDatosBetekTienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorarioController : ControllerBase
    {

        private readonly tiendaContext _DBContext;

        public HorarioController(tiendaContext context)
        {
            _DBContext = context;
        }

        // SaveHorario

        [HttpPost]
        [Route("SaveHorario")]
        public async Task<IActionResult> SaveHorario([FromBody] SaveHorarioViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var horario = new Horario
            {
                HoraInicio = model.HoraInicio,
                HoraFin = model.HoraFin,
                DiaSemana = model.DiaSemana
            };

            _DBContext.Horarios.Add(horario);
            await _DBContext.SaveChangesAsync();

            return Ok(new { message = "Horario guardado exitosamente" });
        }



        //GetAllHorario

        [HttpGet]
        [Route("GetAllHorarios")]
        public async Task<IActionResult> GetAllHorarios()
        {
            var horarios = await _DBContext.Horarios
                .Select(h => new GetAllHorariosViewModel
                {
                    Id = h.Id,
                    HoraInicio = h.HoraInicio,
                    HoraFin = h.HoraFin,
                    DiaSemana = h.DiaSemana
                })
                .ToListAsync();

            return Ok(horarios);
        }





    }
}
