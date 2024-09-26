using System;
using System.Collections.Generic;

namespace AnalisisDeDatosBetekTienda.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Fidelizacions = new HashSet<Fidelizacion>();
            Venta = new HashSet<Ventum>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Telefono { get; set; } = null!;

        public virtual ICollection<Fidelizacion> Fidelizacions { get; set; }
        public virtual ICollection<Ventum> Venta { get; set; }
    }
}
