namespace AnalisisDeDatosBetekTienda.ViewModels.Horario
{
    public class GetAllHorariosViewModel
    {
        public Guid Id { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public int DiaSemana { get; set; }
    }

}
