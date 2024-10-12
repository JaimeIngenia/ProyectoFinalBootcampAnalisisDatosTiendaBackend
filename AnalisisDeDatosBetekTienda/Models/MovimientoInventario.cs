using System;
using System.Collections.Generic;

namespace AnalisisDeDatosBetekTienda.Models
{
    public partial class MovimientoInventario
    {
        //public int Id { get; set; }
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ProductoId { get; set; }
        public int Cantidad { get; set; }
        public Guid EmpleadoId { get; set; }
        public Guid Tipomovimientoid { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Empleado Empleado { get; set; } = null!;
        public virtual Producto Producto { get; set; } = null!;
        public virtual TipoMovimiento Tipomovimiento { get; set; } = null!;
    }
}
