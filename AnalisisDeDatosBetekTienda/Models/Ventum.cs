using System;
using System.Collections.Generic;

namespace AnalisisDeDatosBetekTienda.Models
{
    public partial class Ventum
    {
        public Ventum()
        {
            DetalleVenta = new HashSet<DetalleVentum>();
        }

        //public int Id { get; set; }
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime Fecha { get; set; }
        public Guid ClienteId { get; set; }
        public Guid EmpleadoId { get; set; }

        public virtual Cliente Cliente { get; set; } = null!;
        public virtual Empleado Empleado { get; set; } = null!;
        public virtual ICollection<DetalleVentum> DetalleVenta { get; set; }
    }
}
