using System;
using System.Collections.Generic;

namespace AnalisisDeDatosBetekTienda.Models
{
    public partial class Producto
    {
        public Producto()
        {
            DetalleVenta = new HashSet<DetalleVentum>();
            MovimientoInventarios = new HashSet<MovimientoInventario>();
        }

        //public int Id { get; set; }
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public int Precio { get; set; }
        //public int CategoriaId { get; set; }
        public Guid CategoriaId { get; set; }
        public string? Imagen { get; set; }

        public int? StockActual { get; set; } // Nueva propiedad

        public decimal? PorcentajeGanancia { get; set; } // Nueva propiedad

        public virtual Categorium Categoria { get; set; } = null!;
        public virtual ICollection<DetalleVentum> DetalleVenta { get; set; }

        public virtual ICollection<DetalleCompra> DetalleCompras { get; set; }
        public virtual ICollection<MovimientoInventario> MovimientoInventarios { get; set; }
    }
}
