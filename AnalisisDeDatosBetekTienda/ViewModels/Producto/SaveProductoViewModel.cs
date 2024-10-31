namespace AnalisisDeDatosBetekTienda.ViewModels.Producto
{
    public class SaveProductoViewModel
    {

        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public Guid CategoriaId { get; set; }
        public string? Imagen { get; set; }
    }
}
