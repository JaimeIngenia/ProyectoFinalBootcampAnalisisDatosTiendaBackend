namespace AnalisisDeDatosBetekTienda.ViewModels.DetalleVenta.PruebaGetAll
{
    public class PruebaGetAll
    {
    }
    public class CategoriaViewModelVersionOne
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
    }

    public class ProductoViewModelVersionOne
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public CategoriaViewModelVersionOne Categoria { get; set; }
    }

    public class ClienteViewModelVersionOne
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
    }

    public class EmpleadoViewModelVersionOne
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Puesto { get; set; } // Supongo que "puesto" es un campo importante en el JSON
        public Guid HorarioId { get; set; }
    }

    public class VentaViewModelVersionOne
    {
        public Guid Id { get; set; }
        public DateTime Fecha { get; set; }
        public ClienteViewModelVersionOne Cliente { get; set; }
        public EmpleadoViewModelVersionOne Empleado { get; set; }
    }

    public class GetAllDetalleVentaViewModelVersionOne
    {
        public Guid Id { get; set; }
        public int Cantidad { get; set; }
        public ProductoViewModelVersionOne Producto { get; set; }
        public VentaViewModelVersionOne Venta { get; set; }
        public DateTime Fecha { get; set; }
    }

}
