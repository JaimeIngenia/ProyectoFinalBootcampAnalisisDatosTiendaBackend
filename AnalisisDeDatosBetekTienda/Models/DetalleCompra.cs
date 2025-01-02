namespace AnalisisDeDatosBetekTienda.Models
{
    public class DetalleCompra
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid CompraId { get; set; }
        public Guid ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioNeto { get; set; }
        public decimal Iva { get; set; }

        public virtual Compra Compra { get; set; } = null!;
        public virtual Producto Producto { get; set; } = null!;
    }
}
