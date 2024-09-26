using System;
using System.Collections.Generic;

namespace AnalisisDeDatosBetekTienda.Models
{
    public partial class Horario
    {
        public Horario()
        {
            Empleados = new HashSet<Empleado>();
        }

        public int Id { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public int DiaSemana { get; set; }

        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
