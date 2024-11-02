namespace AnalisisDeDatosBetekTienda.ViewModels.Venta
{
    public class SaveVentaViewModel
    {
        public Guid Id { get; set; }
        public Guid ClienteId { get; set; }
        public Guid EmpleadoId { get; set; }
        public DateTime Fecha { get; set; }
    }
}
