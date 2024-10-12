using System;
using System.Collections.Generic;

namespace AnalisisDeDatosBetekTienda.Models
{
    public partial class TipoMovimiento
    {
        public TipoMovimiento()
        {
            MovimientoInventarios = new HashSet<MovimientoInventario>();
        }

        //public int Id { get; set; }
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nombre { get; set; } = null!;

        public virtual ICollection<MovimientoInventario> MovimientoInventarios { get; set; }
    }
}
