using System;
using System.Collections.Generic;

namespace AnalisisDeDatosBetekTienda.Models
{
    public partial class MovimientoInventario
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public int EmpleadoId { get; set; }
        public int Tipomovimientoid { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Empleado Empleado { get; set; } = null!;
        public virtual Producto Producto { get; set; } = null!;
        public virtual TipoMovimiento Tipomovimiento { get; set; } = null!;
    }
}
