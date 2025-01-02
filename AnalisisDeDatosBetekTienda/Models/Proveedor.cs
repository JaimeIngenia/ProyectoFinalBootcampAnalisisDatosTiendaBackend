namespace AnalisisDeDatosBetekTienda.Models
{
    public class Proveedor
    {
        public Proveedor()
        {
            Compras = new HashSet<Compra>();
        }

        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nombre { get; set; } = null!;
        public Guid TipoDocumentoId { get; set; }
        public string Telefono { get; set; } = null!;
        public string Correo { get; set; } = null!;

        public virtual TipoDocumento TipoDocumento { get; set; } = null!;
        public virtual ICollection<Compra> Compras { get; set; }
    }
}
