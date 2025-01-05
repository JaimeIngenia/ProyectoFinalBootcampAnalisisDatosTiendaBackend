namespace AnalisisDeDatosBetekTienda.ViewModels.Precio
{
    public class SavePrecioViewModel
    {
        public Guid Id { get; set; }
        public Guid ProductoId { get; set; }
        public DateTime? FechaInicio { get; set; }
        public decimal? PrecioVenta { get; set; }
    }
}
