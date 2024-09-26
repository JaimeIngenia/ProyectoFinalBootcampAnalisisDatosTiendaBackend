using System;
using System.Collections.Generic;

namespace AnalisisDeDatosBetekTienda.Models
{
    public partial class Membresium
    {
        public Membresium()
        {
            Fidelizacions = new HashSet<Fidelizacion>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Fidelizacion> Fidelizacions { get; set; }
    }
}
