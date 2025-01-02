using AnalisisDeDatosBetekTienda.ViewModels.Producto;

namespace AnalisisDeDatosBetekTienda.ViewModels.DetalleVenta
{
    public class DetalleVentaSpecialViewModel
    {
        public Guid Id { get; set; }
        public Guid VentaId { get; set; }
        public int Cantidad { get; set; }
        public ProductoSpecialViewModel Producto { get; set; } = null!;
    }
}
