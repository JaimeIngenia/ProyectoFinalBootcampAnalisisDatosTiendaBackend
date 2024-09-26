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

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public int Precio { get; set; }
        public int CategoriaId { get; set; }

        public virtual Categorium Categoria { get; set; } = null!;
        public virtual ICollection<DetalleVentum> DetalleVenta { get; set; }
        public virtual ICollection<MovimientoInventario> MovimientoInventarios { get; set; }
    }
}
