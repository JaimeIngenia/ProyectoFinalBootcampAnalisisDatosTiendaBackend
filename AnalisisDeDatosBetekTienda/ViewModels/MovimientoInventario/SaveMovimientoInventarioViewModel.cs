namespace AnalisisDeDatosBetekTienda.ViewModels.MovimientoInventario
{
    public class SaveMovimientoInventarioViewModel
    {
        public Guid ProductoId { get; set; }
        public int Cantidad { get; set; }
        public Guid EmpleadoId { get; set; }
        public Guid TipoMovimientoId { get; set; }
        public DateTime Fecha { get; set; }
    }
}
