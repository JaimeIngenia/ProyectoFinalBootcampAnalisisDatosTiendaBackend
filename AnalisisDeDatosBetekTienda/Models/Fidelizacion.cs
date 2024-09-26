using System;
using System.Collections.Generic;

namespace AnalisisDeDatosBetekTienda.Models
{
    public partial class Fidelizacion
    {
        public int Id { get; set; }
        public int Puntos { get; set; }
        public int ClienteId { get; set; }
        public int MembresiaId { get; set; }

        public virtual Cliente Cliente { get; set; } = null!;
        public virtual Membresium Membresia { get; set; } = null!;
    }
}
