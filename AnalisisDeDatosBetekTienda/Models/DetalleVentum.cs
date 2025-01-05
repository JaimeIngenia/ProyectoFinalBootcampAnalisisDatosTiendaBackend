using System;
using System.Collections.Generic;

namespace AnalisisDeDatosBetekTienda.Models
{
    //public partial class DetalleVentum
    //{
    //    public Guid Id { get; set; } = Guid.NewGuid();
    //    public int Cantidad { get; set; }
    //    public Guid ProductoId { get; set; }
    //    public Guid VentaId { get; set; }

    //    public virtual Producto Producto { get; set; } = null!;
    //    public virtual Ventum Venta { get; set; } = null!;
    //}

    public partial class DetalleVentum
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Cantidad { get; set; }
        public Guid ProductoId { get; set; }
        public Guid VentaId { get; set; }
        public Guid PrecioId { get; set; } // Nuevo campo
        public decimal? PrecioUnitario { get; set; } // Nuevo campo

        public virtual Producto Producto { get; set; } = null!;
        public virtual Ventum Venta { get; set; } = null!;
        public virtual Precio Precio { get; set; } = null!; // Nueva relación
    }

}
