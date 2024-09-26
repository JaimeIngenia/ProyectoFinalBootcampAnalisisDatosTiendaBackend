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

        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }
        public int EmpleadoId { get; set; }

        public virtual Cliente Cliente { get; set; } = null!;
        public virtual Empleado Empleado { get; set; } = null!;
        public virtual ICollection<DetalleVentum> DetalleVenta { get; set; }
    }
}
