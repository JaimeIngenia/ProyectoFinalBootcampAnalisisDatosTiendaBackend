﻿using AnalisisDeDatosBetekTienda.Models;
using AnalisisDeDatosBetekTienda.ViewModels.Usuario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnalisisDeDatosBetekTienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly tiendaContext _DBContext;

        public UsuarioController(tiendaContext context)
        {
            _DBContext = context;
        }

        // Save Product

        [HttpPost]
        [Route("SaveUsuario")]
        public async Task<IActionResult> SaveUsuario([FromBody] SaveUsuarioViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Verificar si el empleado existe usando GUID
            var empleado = await _DBContext.Empleados.FindAsync(model.EmpleadoId);
            if (empleado == null)
            {
                return NotFound(new { message = "Empleado no encontrado" });
            }

            // Verificar si el rol existe usando GUID
            var rol = await _DBContext.Rols.FindAsync(model.RolId);
            if (rol == null)
            {
                return NotFound(new { message = "Rol no encontrado" });
            }

            // Verificar si la sucursal existe usando GUID
            var sucursal = await _DBContext.Sucursals.FindAsync(model.SucursalId);
            if (sucursal == null)
            {
                return NotFound(new { message = "Sucursal no encontrada" });
            }

            var usuario = new Usuario
            {
                Id = Guid.NewGuid(), // Generar un nuevo GUID para el usuario
                Nombre = model.Nombre,
                Contrasena = model.Contrasena, // Asegúrate de manejar la contraseña de forma segura
                EmpleadoId = model.EmpleadoId,
                RolId = model.RolId,
                SucursalId = model.SucursalId,
                Correo = model.Correo,
                ValidationLogin = model.ValidationLogin,
                TiempoSesionActivo = model.TiempoSesionActivo,
                Imagen = model.Imagen
            };

            _DBContext.Usuarios.Add(usuario);
            await _DBContext.SaveChangesAsync();

            return Ok(new { message = "Usuario guardado exitosamente" });
        }


        // GetAllProduct

        // Método para obtener todos los usuarios
        [HttpGet]
        [Route("GetAllUsuarios")]
        public async Task<IActionResult> GetAllUsuarios()
        {
            var usuarios = await _DBContext.Usuarios
                .Include(u => u.Empleado) // Incluir la relación con el empleado si es necesario
                .Include(u => u.Rol) // Incluir la relación con el rol si es necesario
                .Include(u => u.Sucursal) // Incluir la relación con la sucursal si es necesario
                .Select(u => new GetAllUsuarioViewModel
                {
                    Id = u.Id,
                    Nombre = u.Nombre,
                    Correo = u.Correo,
                    EmpleadoId = u.EmpleadoId,
                    RolId = u.RolId,
                    SucursalId = u.SucursalId,
                    Imagen = u.Imagen // Opcional
                })
                .ToListAsync();

            return Ok(usuarios);
        }


        //GetByIdSimple

        // Método para obtener un usuario por su ID de forma simplificada
        [HttpGet]
        [Route("GetByIdSimple/{id}")]
        public async Task<IActionResult> GetByIdSimple(Guid id)
        {
            // Buscar el usuario en la base de datos por su ID
            var usuario = await _DBContext.Usuarios
                .Where(u => u.Id == id)
                .Select(u => new GetUsuarioSimpleViewModel
                {
                    Id = u.Id,
                    Nombre = u.Nombre,
                    Correo = u.Correo,
                    ValidationLogin = u.ValidationLogin,
                    Imagen = u.Imagen // Opcional
                })
                .FirstOrDefaultAsync();

            // Verificar si el usuario existe
            if (usuario == null)
            {
                return NotFound(new { message = "Usuario no encontrado" });
            }

            return Ok(usuario);
        }





















    }
}
