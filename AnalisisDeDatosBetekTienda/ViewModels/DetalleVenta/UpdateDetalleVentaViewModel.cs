namespace AnalisisDeDatosBetekTienda.ViewModels.DetalleVenta
{
    public class UpdateDetalleVentaViewModel
    {
        public int Cantidad { get; set; }
        public Guid ProductoId { get; set; }
        public Guid VentaId { get; set; }
    }
}
