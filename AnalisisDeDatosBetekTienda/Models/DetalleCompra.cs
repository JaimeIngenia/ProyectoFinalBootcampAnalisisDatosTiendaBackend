namespace AnalisisDeDatosBetekTienda.Models
{
    public class DetalleCompra
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid CompraId { get; set; }
        public Guid ProductoId { get; set; }
        public Guid? PrecioId { get; set; } // Nuevo campo
        public int Cantidad { get; set; }
        public decimal? PrecioUnitario { get; set; }
        public decimal? Iva { get; set; }

        public virtual Compra Compra { get; set; } = null!;
        public virtual Producto Producto { get; set; } = null!;
        public virtual Precio Precio { get; set; } = null!; // Nueva relación
    }
}
