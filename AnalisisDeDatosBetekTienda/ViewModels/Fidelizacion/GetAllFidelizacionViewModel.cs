namespace AnalisisDeDatosBetekTienda.ViewModels.Fidelizacion
{
    public class GetAllFidelizacionViewModel
    {

        public Guid Id { get; set; }
        public int Puntos { get; set; }
        public string ClienteNombre { get; set; } = null!;
        public string MembresiaNombre { get; set; } = null!;
    }
}
