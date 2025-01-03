namespace AnalisisDeDatosBetekTienda.Models
{
    public class Compra
    {
        public Compra()
        {
            DetalleCompras = new HashSet<DetalleCompra>();
        }

        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ProveedorId { get; set; }
        //public decimal Iva { get; set; }
        //public decimal PrecioNeto { get; set; }
        public string Imagen { get; set; } = null!;
        public DateTime Fecha { get; set; } // Nueva propiedad

        public virtual Proveedor Proveedor { get; set; } = null!;
        public virtual ICollection<DetalleCompra> DetalleCompras { get; set; }
    }
}
