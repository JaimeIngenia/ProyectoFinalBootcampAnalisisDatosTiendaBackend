namespace AnalisisDeDatosBetekTienda.ViewModels.Producto
{
    public class SaveProductoViewModel
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        //public int Precio { get; set; }
        public Guid CategoriaId { get; set; }
        public string? Imagen { get; set; }
        public int? StockActual { get; set; }
        public decimal? PorcentajeGanancia { get; set; }
    }
}
