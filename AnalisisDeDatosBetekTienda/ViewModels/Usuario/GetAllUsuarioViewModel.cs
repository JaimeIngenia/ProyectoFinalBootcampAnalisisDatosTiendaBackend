namespace AnalisisDeDatosBetekTienda.ViewModels.Usuario
{
    public class GetAllUsuarioViewModel
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public Guid EmpleadoId { get; set; }
        public Guid RolId { get; set; }
        public Guid SucursalId { get; set; }

        // Agrega propiedades adicionales si es necesario
        public string? Imagen { get; set; } // Campo opcional para la imagen
    }

}
