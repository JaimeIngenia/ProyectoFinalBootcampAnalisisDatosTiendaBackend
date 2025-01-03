using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AnalisisDeDatosBetekTienda.Models
{
    public partial class tiendaContext : DbContext
    {
        public tiendaContext()
        {
        }

        public tiendaContext(DbContextOptions<tiendaContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        public virtual DbSet<Categorium> Categoria { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<DetalleVentum> DetalleVenta { get; set; } = null!;
        public virtual DbSet<Empleado> Empleados { get; set; } = null!;
        public virtual DbSet<Fidelizacion> Fidelizacions { get; set; } = null!;
        public virtual DbSet<Horario> Horarios { get; set; } = null!;
        public virtual DbSet<Membresium> Membresia { get; set; } = null!;
        public virtual DbSet<MovimientoInventario> MovimientoInventarios { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Puesto> Puestos { get; set; } = null!;
        public virtual DbSet<Rol> Rols { get; set; } = null!;
        public virtual DbSet<Sucursal> Sucursals { get; set; } = null!;
        public virtual DbSet<TipoMovimiento> TipoMovimientos { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<Ventum> Venta { get; set; } = null!;
        public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; } = null!;
        public virtual DbSet<Proveedor> Proveedores { get; set; } = null!;
        public virtual DbSet<Compra> Compras { get; set; } = null!;
        public virtual DbSet<DetalleCompra> DetalleCompras { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Opciones de configuración del contexto
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.ToTable("categoria");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("NEWID()") // Usar GUID
                    .HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(45)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("cliente");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("NEWID()") // Usar GUID
                    .HasColumnName("id");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(45)
                    .HasColumnName("apellido");

                entity.Property(e => e.Email)
                    .HasMaxLength(45)
                    .HasColumnName("email");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(45)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(45)
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<DetalleVentum>(entity =>
            {
                entity.ToTable("detalleVenta");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("NEWID()") // Usar GUID
                    .HasColumnName("id");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.ProductoId).HasColumnName("productoId");

                entity.Property(e => e.VentaId).HasColumnName("ventaId");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.DetalleVenta)
                    .HasForeignKey(d => d.ProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__detalleVe__produ__36B12243");

                entity.HasOne(d => d.Venta)
                    .WithMany(p => p.DetalleVenta)
                    .HasForeignKey(d => d.VentaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__detalleVe__venta__37A5467C");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.ToTable("empleado");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("NEWID()") // Usar GUID
                    .HasColumnName("id");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(45)
                    .HasColumnName("apellido");

                entity.Property(e => e.HorarioId).HasColumnName("horarioId");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(45)
                    .HasColumnName("nombre");

                entity.Property(e => e.PuestoId).HasColumnName("puestoId");

                entity.HasOne(d => d.Horario)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.HorarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__empleado__horari__2F10007B");

                entity.HasOne(d => d.Puesto)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.PuestoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__empleado__puesto__300424B4");
            });

            modelBuilder.Entity<Fidelizacion>(entity =>
            {
                entity.ToTable("fidelizacion");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("NEWID()") // Usar GUID
                    .HasColumnName("id");

                entity.Property(e => e.ClienteId).HasColumnName("clienteId");

                entity.Property(e => e.MembresiaId).HasColumnName("membresiaId");

                entity.Property(e => e.Puntos).HasColumnName("puntos");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Fidelizacions)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__fidelizac__clien__3C69FB99");

                entity.HasOne(d => d.Membresia)
                    .WithMany(p => p.Fidelizacions)
                    .HasForeignKey(d => d.MembresiaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__fidelizac__membr__3D5E1FD2");
            });

            modelBuilder.Entity<Horario>(entity =>
            {
                entity.ToTable("horario");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("NEWID()") // Usar GUID
                    .HasColumnName("id");

                entity.Property(e => e.DiaSemana).HasColumnName("diaSemana");

                entity.Property(e => e.HoraFin).HasColumnName("horaFin");

                entity.Property(e => e.HoraInicio).HasColumnName("horaInicio");
            });

            modelBuilder.Entity<Membresium>(entity =>
            {
                entity.ToTable("membresia");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("NEWID()") // Usar GUID
                    .HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(45)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<MovimientoInventario>(entity =>
            {
                entity.ToTable("movimientoInventario");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("NEWID()") // Usar GUID
                    .HasColumnName("id");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.EmpleadoId).HasColumnName("empleadoId");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.ProductoId).HasColumnName("productoId");

                entity.Property(e => e.Tipomovimientoid).HasColumnName("tipomovimientoid");

                entity.HasOne(d => d.Empleado)
                    .WithMany(p => p.MovimientoInventarios)
                    .HasForeignKey(d => d.EmpleadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__movimient__emple__4BAC3F29");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.MovimientoInventarios)
                    .HasForeignKey(d => d.ProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__movimient__produ__4AB81AF0");

                entity.HasOne(d => d.Tipomovimiento)
                    .WithMany(p => p.MovimientoInventarios)
                    .HasForeignKey(d => d.Tipomovimientoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__movimient__tipom__4CA06362");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("producto");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("NEWID()") // Usar GUID
                    .HasColumnName("id");

                entity.Property(e => e.CategoriaId).HasColumnName("categoriaId");

                entity.Property(e => e.Nombre)
                 .HasMaxLength(45)
                 .HasColumnName("nombre");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Precio).HasColumnName("precio");

                entity.Property(e => e.Imagen) // Mapea la columna imagen
                    .HasMaxLength(1000)
                    .HasColumnName("imagen");

                entity.Property(e => e.StockActual) // Nueva propiedad
                    .HasColumnName("stockActual");

                 entity.Property(e => e.PorcentajeGanancia)
                    .IsRequired(false) // Campo opcional
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("porcentajeGanancia");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.CategoriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__producto__catego__33D4B598");
            });

            modelBuilder.Entity<Puesto>(entity =>
            {
                entity.ToTable("puesto");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("NEWID()") // Usar GUID
                    .HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(45)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.ToTable("rol");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("NEWID()") // Usar GUID
                    .HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(45)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Sucursal>(entity =>
            {
                entity.ToTable("sucursal");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("NEWID()") // Usar GUID
                    .HasColumnName("id");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(45)
                    .HasColumnName("direccion");

                //entity.Property(e => e.Nombre)
                //    .HasMaxLength(45)
                //    .HasColumnName("nombre");
            });

            modelBuilder.Entity<TipoMovimiento>(entity =>
            {
                entity.ToTable("tipoMovimiento");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("NEWID()") // Usar GUID
                    .HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(45)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuario");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("NEWID()") // Usar GUID
                    .HasColumnName("id");

                // Configuración de otros campos
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100) // Asegúrate de que la longitud sea adecuada
                    .HasColumnName("nombre");

                entity.Property(e => e.Contrasena)
                    .IsRequired()
                    .HasColumnName("contrasena"); // Cambia el nombre de columna si es necesario

                //entity.Property(e => e.EmpleadoId)
                //    .HasColumnName("empleadoId");
                entity.Property(e => e.EmpleadoId)
                    .IsRequired(false) // Cambiado a nullable
                    .HasColumnName("empleadoId");

                //entity.Property(e => e.RolId)
                //    .HasColumnName("rolId");
                entity.Property(e => e.RolId)
                    .IsRequired(false) // Cambiado a nullable
                    .HasColumnName("rolId");

                entity.Property(e => e.SucursalId)
                   .IsRequired(false) // Cambiado a nullable
                   .HasColumnName("sucursalId");

                // Nuevo campo obligatorio para el correo
                entity.Property(e => e.Correo)
                    .IsRequired() // Hacerlo obligatorio
                    .HasColumnName("correo"); // Asegúrate de que el nombre de columna sea correcto

                // Nuevo campo booleano para validación de inicio de sesión
                entity.Property(e => e.ValidationLogin)
                     .IsRequired(false)
                    .HasColumnName("validationLogin");

                // Nuevo campo para mantener el tiempo de sesión activa
                entity.Property(e => e.TiempoSesionActivo)
                    .IsRequired(false)
                    .HasColumnName("tiempoSesionActivo");

                // Nuevo campo opcional para la imagen del usuario
                entity.Property(e => e.Imagen)
                    .IsRequired(false) // Campo opcional
                    .HasColumnName("imagen");

                //entity.HasOne(d => d.Empleado)
                //    .WithMany(p => p.Usuarios)
                //    .HasForeignKey(d => d.EmpleadoId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK__usuario__emplead__38996AB5");

                //entity.HasOne(d => d.Rol)
                //    .WithMany(p => p.Usuarios)
                //    .HasForeignKey(d => d.RolId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK__usuario__rolId__398D8EEE");
                entity.HasOne(d => d.Empleado)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.EmpleadoId)
                    .OnDelete(DeleteBehavior.SetNull) // Cambiado a SetNull
                    .HasConstraintName("FK__usuario__emplead__38996AB5");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.RolId)
                    .OnDelete(DeleteBehavior.SetNull) // Cambiado a SetNull
                    .HasConstraintName("FK__usuario__rolId__398D8EEE");

                entity.HasOne(d => d.Sucursal)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.SucursalId)
                    .OnDelete(DeleteBehavior.SetNull) // Cambiado a SetNull
                    .HasConstraintName("FK__usuario__sucurs__3A81B327");
            });

            modelBuilder.Entity<Ventum>(entity =>
            {
                entity.ToTable("venta");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("NEWID()") // Usar GUID
                    .HasColumnName("id");

                entity.Property(e => e.ClienteId).HasColumnName("clienteId");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__venta__clienteId__31EC6D26");
            });

            modelBuilder.Entity<TipoDocumento>(entity =>
            {
                entity.ToTable("tipoDocumento");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("NEWID()") // Usar GUID
                    .HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(45)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.ToTable("proveedor");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("NEWID()") // Usar GUID
                    .HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(45)
                    .HasColumnName("nombre");

                entity.Property(e => e.TipoDocumentoId).HasColumnName("tipoDocumentoId");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(45)
                    .HasColumnName("telefono");

                entity.Property(e => e.Correo)
                    .HasMaxLength(45)
                    .HasColumnName("correo");

                entity.HasOne(d => d.TipoDocumento)
                    .WithMany(p => p.Proveedores)
                    .HasForeignKey(d => d.TipoDocumentoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__proveedor__tipoDo__4D94879B");
            });

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.ToTable("compra");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("NEWID()") // Usar GUID
                    .HasColumnName("id");

                entity.Property(e => e.ProveedorId).HasColumnName("proveedorId");

                //entity.Property(e => e.Iva)
                //    .HasColumnType("decimal(10, 2)")
                //    .HasColumnName("iva");

                //entity.Property(e => e.PrecioNeto)
                //    .HasColumnType("decimal(10, 2)")
                //    .HasColumnName("precioNeto");

                entity.Property(e => e.Imagen)
                    .HasMaxLength(1000)
                    .HasColumnName("imagen");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha"); // Nueva configuración

                entity.HasOne(d => d.Proveedor)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.ProveedorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__compra__proveedor__4E88ABD4");
            });

            modelBuilder.Entity<DetalleCompra>(entity =>
            {
                entity.ToTable("detalleCompra");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("NEWID()") // Usar GUID
                    .HasColumnName("id");

                entity.Property(e => e.CompraId).HasColumnName("compraId");

                entity.Property(e => e.ProductoId).HasColumnName("productoId");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.PrecioNeto)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("precioNeto");

                entity.Property(e => e.Iva)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("iva");

                entity.HasOne(d => d.Compra)
                    .WithMany(p => p.DetalleCompras)
                    .HasForeignKey(d => d.CompraId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__detalleCom__compra__4F7CD00D");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.DetalleCompras)
                    .HasForeignKey(d => d.ProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__detalleCom__produ__5070F446");
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
