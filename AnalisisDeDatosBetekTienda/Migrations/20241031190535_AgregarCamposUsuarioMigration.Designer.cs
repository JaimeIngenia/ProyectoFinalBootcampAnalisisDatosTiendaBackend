﻿// <auto-generated />
using System;
using AnalisisDeDatosBetekTienda.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AnalisisDeDatosBetekTienda.Migrations
{
    [DbContext(typeof(tiendaContext))]
    [Migration("20241031190535_AgregarCamposUsuarioMigration")]
    partial class AgregarCamposUsuarioMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AnalisisDeDatosBetekTienda.Models.Categorium", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)")
                        .HasColumnName("nombre");

                    b.HasKey("Id");

                    b.ToTable("categoria", (string)null);
                });

            modelBuilder.Entity("AnalisisDeDatosBetekTienda.Models.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)")
                        .HasColumnName("apellido");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)")
                        .HasColumnName("email");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)")
                        .HasColumnName("nombre");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)")
                        .HasColumnName("telefono");

                    b.HasKey("Id");

                    b.ToTable("cliente", (string)null);
                });

            modelBuilder.Entity("AnalisisDeDatosBetekTienda.Models.DetalleVentum", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int")
                        .HasColumnName("cantidad");

                    b.Property<Guid>("ProductoId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("productoId");

                    b.Property<Guid>("VentaId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ventaId");

                    b.HasKey("Id");

                    b.HasIndex("ProductoId");

                    b.HasIndex("VentaId");

                    b.ToTable("detalleVenta", (string)null);
                });

            modelBuilder.Entity("AnalisisDeDatosBetekTienda.Models.Empleado", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)")
                        .HasColumnName("apellido");

                    b.Property<Guid>("HorarioId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("horarioId");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)")
                        .HasColumnName("nombre");

                    b.Property<Guid>("PuestoId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("puestoId");

                    b.HasKey("Id");

                    b.HasIndex("HorarioId");

                    b.HasIndex("PuestoId");

                    b.ToTable("empleado", (string)null);
                });

            modelBuilder.Entity("AnalisisDeDatosBetekTienda.Models.Fidelizacion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("clienteId");

                    b.Property<Guid>("MembresiaId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("membresiaId");

                    b.Property<int>("Puntos")
                        .HasColumnType("int")
                        .HasColumnName("puntos");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("MembresiaId");

                    b.ToTable("fidelizacion", (string)null);
                });

            modelBuilder.Entity("AnalisisDeDatosBetekTienda.Models.Horario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<int>("DiaSemana")
                        .HasColumnType("int")
                        .HasColumnName("diaSemana");

                    b.Property<TimeSpan>("HoraFin")
                        .HasColumnType("time")
                        .HasColumnName("horaFin");

                    b.Property<TimeSpan>("HoraInicio")
                        .HasColumnType("time")
                        .HasColumnName("horaInicio");

                    b.HasKey("Id");

                    b.ToTable("horario", (string)null);
                });

            modelBuilder.Entity("AnalisisDeDatosBetekTienda.Models.Membresium", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)")
                        .HasColumnName("nombre");

                    b.HasKey("Id");

                    b.ToTable("membresia", (string)null);
                });

            modelBuilder.Entity("AnalisisDeDatosBetekTienda.Models.MovimientoInventario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int")
                        .HasColumnName("cantidad");

                    b.Property<Guid>("EmpleadoId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("empleadoId");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("date")
                        .HasColumnName("fecha");

                    b.Property<Guid>("ProductoId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("productoId");

                    b.Property<Guid>("Tipomovimientoid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("tipomovimientoid");

                    b.HasKey("Id");

                    b.HasIndex("EmpleadoId");

                    b.HasIndex("ProductoId");

                    b.HasIndex("Tipomovimientoid");

                    b.ToTable("movimientoInventario", (string)null);
                });

            modelBuilder.Entity("AnalisisDeDatosBetekTienda.Models.Producto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("CategoriaId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("categoriaId");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("descripcion");

                    b.Property<string>("Imagen")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasColumnName("imagen");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Precio")
                        .HasColumnType("int")
                        .HasColumnName("precio");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("producto", (string)null);
                });

            modelBuilder.Entity("AnalisisDeDatosBetekTienda.Models.Puesto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)")
                        .HasColumnName("nombre");

                    b.HasKey("Id");

                    b.ToTable("puesto", (string)null);
                });

            modelBuilder.Entity("AnalisisDeDatosBetekTienda.Models.Rol", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)")
                        .HasColumnName("nombre");

                    b.HasKey("Id");

                    b.ToTable("rol", (string)null);
                });

            modelBuilder.Entity("AnalisisDeDatosBetekTienda.Models.Sucursal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)")
                        .HasColumnName("direccion");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("sucursal", (string)null);
                });

            modelBuilder.Entity("AnalisisDeDatosBetekTienda.Models.TipoMovimiento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)")
                        .HasColumnName("nombre");

                    b.HasKey("Id");

                    b.ToTable("tipoMovimiento", (string)null);
                });

            modelBuilder.Entity("AnalisisDeDatosBetekTienda.Models.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("contrasena");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("correo");

                    b.Property<Guid>("EmpleadoId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("empleadoId");

                    b.Property<string>("Imagen")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("imagen");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("nombre");

                    b.Property<Guid>("RolId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("rolId");

                    b.Property<Guid>("SucursalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<TimeSpan>("TiempoSesionActivo")
                        .HasColumnType("time")
                        .HasColumnName("tiempoSesionActivo");

                    b.Property<bool>("ValidationLogin")
                        .HasColumnType("bit")
                        .HasColumnName("validationLogin");

                    b.HasKey("Id");

                    b.HasIndex("EmpleadoId");

                    b.HasIndex("RolId");

                    b.HasIndex("SucursalId");

                    b.ToTable("usuario", (string)null);
                });

            modelBuilder.Entity("AnalisisDeDatosBetekTienda.Models.Ventum", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("clienteId");

                    b.Property<Guid>("EmpleadoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("date")
                        .HasColumnName("fecha");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("EmpleadoId");

                    b.ToTable("venta", (string)null);
                });

            modelBuilder.Entity("AnalisisDeDatosBetekTienda.Models.DetalleVentum", b =>
                {
                    b.HasOne("AnalisisDeDatosBetekTienda.Models.Producto", "Producto")
                        .WithMany("DetalleVenta")
                        .HasForeignKey("ProductoId")
                        .IsRequired()
                        .HasConstraintName("FK__detalleVe__produ__36B12243");

                    b.HasOne("AnalisisDeDatosBetekTienda.Models.Ventum", "Venta")
                        .WithMany("DetalleVenta")
                        .HasForeignKey("VentaId")
                        .IsRequired()
                        .HasConstraintName("FK__detalleVe__venta__37A5467C");

                    b.Navigation("Producto");

                    b.Navigation("Venta");
                });

            modelBuilder.Entity("AnalisisDeDatosBetekTienda.Models.Empleado", b =>
                {
                    b.HasOne("AnalisisDeDatosBetekTienda.Models.Horario", "Horario")
                        .WithMany("Empleados")
                        .HasForeignKey("HorarioId")
                        .IsRequired()
                        .HasConstraintName("FK__empleado__horari__2F10007B");

                    b.HasOne("AnalisisDeDatosBetekTienda.Models.Puesto", "Puesto")
                        .WithMany("Empleados")
                        .HasForeignKey("PuestoId")
                        .IsRequired()
                        .HasConstraintName("FK__empleado__puesto__300424B4");

                    b.Navigation("Horario");

                    b.Navigation("Puesto");
                });

            modelBuilder.Entity("AnalisisDeDatosBetekTienda.Models.Fidelizacion", b =>
                {
                    b.HasOne("AnalisisDeDatosBetekTienda.Models.Cliente", "Cliente")
                        .WithMany("Fidelizacions")
                        .HasForeignKey("ClienteId")
                        .IsRequired()
                        .HasConstraintName("FK__fidelizac__clien__3C69FB99");

                    b.HasOne("AnalisisDeDatosBetekTienda.Models.Membresium", "Membresia")
                        .WithMany("Fidelizacions")
                        .HasForeignKey("MembresiaId")
                        .IsRequired()
                        .HasConstraintName("FK__fidelizac__membr__3D5E1FD2");

                    b.Navigation("Cliente");

                    b.Navigation("Membresia");
                });

            modelBuilder.Entity("AnalisisDeDatosBetekTienda.Models.MovimientoInventario", b =>
                {
                    b.HasOne("AnalisisDeDatosBetekTienda.Models.Empleado", "Empleado")
                        .WithMany("MovimientoInventarios")
                        .HasForeignKey("EmpleadoId")
                        .IsRequired()
                        .HasConstraintName("FK__movimient__emple__4BAC3F29");

                    b.HasOne("AnalisisDeDatosBetekTienda.Models.Producto", "Producto")
                        .WithMany("MovimientoInventarios")
                        .HasForeignKey("ProductoId")
                        .IsRequired()
                        .HasConstraintName("FK__movimient__produ__4AB81AF0");

                    b.HasOne("AnalisisDeDatosBetekTienda.Models.TipoMovimiento", "Tipomovimiento")
                        .WithMany("MovimientoInventarios")
                        .HasForeignKey("Tipomovimientoid")
                        .IsRequired()
                        .HasConstraintName("FK__movimient__tipom__4CA06362");

                    b.Navigation("Empleado");

                    b.Navigation("Producto");

                    b.Navigation("Tipomovimiento");
                });

            modelBuilder.Entity("AnalisisDeDatosBetekTienda.Models.Producto", b =>
                {
                    b.HasOne("AnalisisDeDatosBetekTienda.Models.Categorium", "Categoria")
                        .WithMany("Productos")
                        .HasForeignKey("CategoriaId")
                        .IsRequired()
                        .HasConstraintName("FK__producto__catego__33D4B598");

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("AnalisisDeDatosBetekTienda.Models.Usuario", b =>
                {
                    b.HasOne("AnalisisDeDatosBetekTienda.Models.Empleado", "Empleado")
                        .WithMany("Usuarios")
                        .HasForeignKey("EmpleadoId")
                        .IsRequired()
                        .HasConstraintName("FK__usuario__emplead__38996AB5");

                    b.HasOne("AnalisisDeDatosBetekTienda.Models.Rol", "Rol")
                        .WithMany("Usuarios")
                        .HasForeignKey("RolId")
                        .IsRequired()
                        .HasConstraintName("FK__usuario__rolId__398D8EEE");

                    b.HasOne("AnalisisDeDatosBetekTienda.Models.Sucursal", "Sucursal")
                        .WithMany("Usuarios")
                        .HasForeignKey("SucursalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empleado");

                    b.Navigation("Rol");

                    b.Navigation("Sucursal");
                });

            modelBuilder.Entity("AnalisisDeDatosBetekTienda.Models.Ventum", b =>
                {
                    b.HasOne("AnalisisDeDatosBetekTienda.Models.Cliente", "Cliente")
                        .WithMany("Venta")
                        .HasForeignKey("ClienteId")
                        .IsRequired()
                        .HasConstraintName("FK__venta__clienteId__31EC6D26");

                    b.HasOne("AnalisisDeDatosBetekTienda.Models.Empleado", "Empleado")
                        .WithMany("Venta")
                        .HasForeignKey("EmpleadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Empleado");
                });

            modelBuilder.Entity("AnalisisDeDatosBetekTienda.Models.Categorium", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("AnalisisDeDatosBetekTienda.Models.Cliente", b =>
                {
                    b.Navigation("Fidelizacions");

                    b.Navigation("Venta");
                });

            modelBuilder.Entity("AnalisisDeDatosBetekTienda.Models.Empleado", b =>
                {
                    b.Navigation("MovimientoInventarios");

                    b.Navigation("Usuarios");

                    b.Navigation("Venta");
                });

            modelBuilder.Entity("AnalisisDeDatosBetekTienda.Models.Horario", b =>
                {
                    b.Navigation("Empleados");
                });

            modelBuilder.Entity("AnalisisDeDatosBetekTienda.Models.Membresium", b =>
                {
                    b.Navigation("Fidelizacions");
                });

            modelBuilder.Entity("AnalisisDeDatosBetekTienda.Models.Producto", b =>
                {
                    b.Navigation("DetalleVenta");

                    b.Navigation("MovimientoInventarios");
                });

            modelBuilder.Entity("AnalisisDeDatosBetekTienda.Models.Puesto", b =>
                {
                    b.Navigation("Empleados");
                });

            modelBuilder.Entity("AnalisisDeDatosBetekTienda.Models.Rol", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("AnalisisDeDatosBetekTienda.Models.Sucursal", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("AnalisisDeDatosBetekTienda.Models.TipoMovimiento", b =>
                {
                    b.Navigation("MovimientoInventarios");
                });

            modelBuilder.Entity("AnalisisDeDatosBetekTienda.Models.Ventum", b =>
                {
                    b.Navigation("DetalleVenta");
                });
#pragma warning restore 612, 618
        }
    }
}