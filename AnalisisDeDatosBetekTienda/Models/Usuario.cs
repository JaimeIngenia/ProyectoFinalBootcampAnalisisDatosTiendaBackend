using System;
using System.Collections.Generic;

namespace AnalisisDeDatosBetekTienda.Models
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Contrasena { get; set; } = null!;
        public int EmpleadoId { get; set; }
        public int RolId { get; set; }
        public int SucursalId { get; set; }

        public virtual Empleado Empleado { get; set; } = null!;
        public virtual Rol Rol { get; set; } = null!;
        public virtual Sucursal Sucursal { get; set; } = null!;
    }
}
