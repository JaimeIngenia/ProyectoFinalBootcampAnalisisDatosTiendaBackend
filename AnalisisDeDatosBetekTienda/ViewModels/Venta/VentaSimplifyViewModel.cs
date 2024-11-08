using AnalisisDeDatosBetekTienda.ViewModels.Cliente;
using AnalisisDeDatosBetekTienda.ViewModels.Empleado;

namespace AnalisisDeDatosBetekTienda.ViewModels.Venta
{
    public class VentaSimplifyViewModel
    {
        public Guid Id { get; set; }
        public DateTime Fecha { get; set; }
        public ClienteConsultaVentaViewModel Cliente { get; set; } = null!;
        public EmpleadoConsultaVentaViewModel Empleado { get; set; } = null!;
    }
}
