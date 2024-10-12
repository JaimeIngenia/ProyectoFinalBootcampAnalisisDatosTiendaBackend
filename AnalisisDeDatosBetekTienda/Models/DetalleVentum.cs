using System;
using System.Collections.Generic;

namespace AnalisisDeDatosBetekTienda.Models
{
    public partial class DetalleVentum
    {
        //public int Id { get; set; }
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Cantidad { get; set; }
        public Guid ProductoId { get; set; }
        public Guid VentaId { get; set; }

        public virtual Producto Producto { get; set; } = null!;
        public virtual Ventum Venta { get; set; } = null!;
    }
}
