namespace AnalisisDeDatosBetekTienda.Models
{
    public class Precio
    {
        public Precio()
        {
            DetalleVenta = new HashSet<DetalleVentum>();
            DetalleCompras = new HashSet<DetalleCompra>();
        }
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ProductoId { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public decimal? PrecioCompra { get; set; }
        public decimal? PrecioVenta { get; set; }

        public virtual Producto Producto { get; set; } = null!;

        public virtual ICollection<DetalleVentum> DetalleVenta { get; set; }
        public virtual ICollection<DetalleCompra> DetalleCompras { get; set; }
    }
}
