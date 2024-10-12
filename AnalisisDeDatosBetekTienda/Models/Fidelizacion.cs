using System;
using System.Collections.Generic;

namespace AnalisisDeDatosBetekTienda.Models
{
    public partial class Fidelizacion
    {
        //public int Id { get; set; }
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Puntos { get; set; }
        public Guid ClienteId { get; set; }
        public Guid MembresiaId { get; set; }

        public virtual Cliente Cliente { get; set; } = null!;
        public virtual Membresium Membresia { get; set; } = null!;
    }
}
