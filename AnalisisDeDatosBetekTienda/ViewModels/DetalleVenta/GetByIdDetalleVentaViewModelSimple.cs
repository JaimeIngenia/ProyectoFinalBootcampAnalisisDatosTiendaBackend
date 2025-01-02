namespace AnalisisDeDatosBetekTienda.ViewModels.DetalleVenta
{
    public class GetByIdDetalleVentaViewModelSimple
    {
        public Guid Id { get; set; }
        public int Cantidad { get; set; }
        public Guid ProductoId { get; set; }
        public Guid VentaId { get; set; }
    }
}
