using AnalisisDeDatosBetekTienda.ViewModels.DetalleVenta.PruebaGetAll;

namespace AnalisisDeDatosBetekTienda.ViewModels.DetalleVenta
{
    public class GetByIdDetalleVentaViewModel
    {
        public Guid Id { get; set; }
        public int Cantidad { get; set; }
        public ProductoViewModelVersionOne Producto { get; set; }
        public VentaViewModelVersionOne Venta { get; set; }
        public DateTime Fecha { get; set; }
    }
}
