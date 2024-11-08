namespace AnalisisDeDatosBetekTienda.ViewModels.Cliente
{
    public class GetByIdClienteViewModel
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Telefono { get; set; } = null!;
    }
}
