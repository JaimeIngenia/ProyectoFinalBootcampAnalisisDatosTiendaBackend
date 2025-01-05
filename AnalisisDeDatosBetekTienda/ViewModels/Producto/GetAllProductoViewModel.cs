namespace AnalisisDeDatosBetekTienda.ViewModels.Producto
{
    public class GetAllProductoViewModel
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal? Precio { get; set; }
        public string CategoriaNombre { get; set; }
        public string? Imagen { get; set; }
    }
}
