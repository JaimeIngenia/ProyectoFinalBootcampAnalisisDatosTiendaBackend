using System;
using System.Collections.Generic;

namespace AnalisisDeDatosBetekTienda.Models
{
    public partial class Sucursal
    {
        public Sucursal()
        {
            Usuarios = new HashSet<Usuario>();
        }

        //public int Id { get; set; }
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Region { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Ciudad { get; set; } = null!;

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
