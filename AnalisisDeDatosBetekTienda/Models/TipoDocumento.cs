namespace AnalisisDeDatosBetekTienda.Models
{
    public class TipoDocumento
    {
        public TipoDocumento()
        {
            Proveedores = new HashSet<Proveedor>();
        }

        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Proveedor> Proveedores { get; set; }
    }
}
