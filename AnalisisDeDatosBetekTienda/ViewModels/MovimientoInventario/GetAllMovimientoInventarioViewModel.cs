namespace AnalisisDeDatosBetekTienda.ViewModels.MovimientoInventario
{
    public class GetAllMovimientoInventarioViewModel
    {
        public Guid Id { get; set; }
        public Guid ProductoId { get; set; }
        public string ProductoNombre { get; set; } = null!;
        public int Cantidad { get; set; }
        public Guid EmpleadoId { get; set; }
        public string EmpleadoNombre { get; set; } = null!;
        public Guid TipoMovimientoId { get; set; }
        public string TipoMovimientoNombre { get; set; } = null!;
        public DateTime Fecha { get; set; }
    }
}
