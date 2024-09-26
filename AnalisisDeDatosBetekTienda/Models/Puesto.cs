using System;
using System.Collections.Generic;

namespace AnalisisDeDatosBetekTienda.Models
{
    public partial class Puesto
    {
        public Puesto()
        {
            Empleados = new HashSet<Empleado>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
