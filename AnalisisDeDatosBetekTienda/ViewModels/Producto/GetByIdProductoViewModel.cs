using AnalisisDeDatosBetekTienda.ViewModels.Categoria;

namespace AnalisisDeDatosBetekTienda.ViewModels.Producto
{
    public class GetByIdProductoViewModel
    {

   
            public Guid Id { get; set; }
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
            public int Precio { get; set; }
            public GetAllCategoriaViewModel Categoria { get; set; }  // Reutilizando GetAllCategoriaViewModel
            public string? Imagen { get; set; }

    }
}
