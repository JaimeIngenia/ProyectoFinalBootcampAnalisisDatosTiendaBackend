using System;
using System.Collections.Generic;

namespace AnalisisDeDatosBetekTienda.Models
{
    public partial class Usuario
    {
        //public int Id { get; set; }
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nombre { get; set; } = null!;
        public string Contrasena { get; set; } = null!;
        public Guid EmpleadoId { get; set; }
        public Guid RolId { get; set; }
        public Guid SucursalId { get; set; }

        // Campos adicionales
        public string Correo { get; set; } = null!; // Campo obligatorio
        public bool? ValidationLogin { get; set; } // Campo booleano para validación
        public TimeSpan? TiempoSesionActivo { get; set; } // Tiempo de sesión activa
        public string? Imagen { get; set; } // Campo opcional para la imagen

        public virtual Empleado Empleado { get; set; } = null!;
        public virtual Rol Rol { get; set; } = null!;
        public virtual Sucursal Sucursal { get; set; } = null!;
    }
}
