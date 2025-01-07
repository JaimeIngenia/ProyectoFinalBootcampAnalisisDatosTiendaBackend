namespace AnalisisDeDatosBetekTienda.ViewModels.DetalleVenta
{
    public class SaveDetalleVentaViewModel
    {
        public int Cantidad { get; set; }
        public Guid ProductoId { get; set; }
        public Guid VentaId { get; set; }
        //public Guid PrecioId { get; set; } // Nuevo campo
    }

}
