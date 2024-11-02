namespace AnalisisDeDatosBetekTienda.ViewModels.Usuario
{
    public class GetUsuarioSimpleViewModel
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public bool? ValidationLogin { get; set; }
        public string Imagen { get; set; } // Opcional
    }

}
