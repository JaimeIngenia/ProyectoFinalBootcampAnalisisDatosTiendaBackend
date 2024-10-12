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

        public virtual Empleado Empleado { get; set; } = null!;
        public virtual Rol Rol { get; set; } = null!;
        public virtual Sucursal Sucursal { get; set; } = null!;
    }
}
