using System;
using System.Collections.Generic;

namespace AnalisisDeDatosBetekTienda.Models
{
    public partial class Empleado
    {
        public Empleado()
        {
            MovimientoInventarios = new HashSet<MovimientoInventario>();
            Usuarios = new HashSet<Usuario>();
            Venta = new HashSet<Ventum>();
        }
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public Guid HorarioId { get; set; }
        public Guid PuestoId { get; set; }

        public virtual Horario Horario { get; set; } = null!;
        public virtual Puesto Puesto { get; set; } = null!;
        public virtual ICollection<MovimientoInventario> MovimientoInventarios { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
        public virtual ICollection<Ventum> Venta { get; set; }
    }
}
