namespace AnalisisDeDatosBetekTienda.ViewModels.Usuario
{
    public class SaveUsuarioViewModel
    {
        public string Nombre { get; set; } = null!;
        public string Contrasena { get; set; } = null!;
        public Guid EmpleadoId { get; set; }
        public Guid RolId { get; set; }
        public Guid SucursalId { get; set; }
        public string Correo { get; set; } = null!; // Campo obligatorio

        // Campos opcionales
        public bool? ValidationLogin { get; set; }
        public TimeSpan? TiempoSesionActivo { get; set; }
        public string? Imagen { get; set; }
    }

}
