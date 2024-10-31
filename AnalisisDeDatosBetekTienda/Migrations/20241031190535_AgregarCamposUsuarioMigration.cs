using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnalisisDeDatosBetekTienda.Migrations
{
    public partial class AgregarCamposUsuarioMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categoria",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    nombre = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoria", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    nombre = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    email = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "horario",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    horaInicio = table.Column<TimeSpan>(type: "time", nullable: false),
                    horaFin = table.Column<TimeSpan>(type: "time", nullable: false),
                    diaSemana = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_horario", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "membresia",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    nombre = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_membresia", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "puesto",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    nombre = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_puesto", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "rol",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    nombre = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rol", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sucursal",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sucursal", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tipoMovimiento",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    nombre = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoMovimiento", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "producto",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    precio = table.Column<int>(type: "int", nullable: false),
                    categoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    imagen = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_producto", x => x.id);
                    table.ForeignKey(
                        name: "FK__producto__catego__33D4B598",
                        column: x => x.categoriaId,
                        principalTable: "categoria",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "fidelizacion",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    puntos = table.Column<int>(type: "int", nullable: false),
                    clienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    membresiaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fidelizacion", x => x.id);
                    table.ForeignKey(
                        name: "FK__fidelizac__clien__3C69FB99",
                        column: x => x.clienteId,
                        principalTable: "cliente",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__fidelizac__membr__3D5E1FD2",
                        column: x => x.membresiaId,
                        principalTable: "membresia",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "empleado",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    nombre = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    horarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    puestoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empleado", x => x.id);
                    table.ForeignKey(
                        name: "FK__empleado__horari__2F10007B",
                        column: x => x.horarioId,
                        principalTable: "horario",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__empleado__puesto__300424B4",
                        column: x => x.puestoId,
                        principalTable: "puesto",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "movimientoInventario",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    productoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    empleadoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tipomovimientoid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fecha = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movimientoInventario", x => x.id);
                    table.ForeignKey(
                        name: "FK__movimient__emple__4BAC3F29",
                        column: x => x.empleadoId,
                        principalTable: "empleado",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__movimient__produ__4AB81AF0",
                        column: x => x.productoId,
                        principalTable: "producto",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__movimient__tipom__4CA06362",
                        column: x => x.tipomovimientoid,
                        principalTable: "tipoMovimiento",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    empleadoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    rolId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SucursalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    validationLogin = table.Column<bool>(type: "bit", nullable: false),
                    tiempoSesionActivo = table.Column<TimeSpan>(type: "time", nullable: false),
                    imagen = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.id);
                    table.ForeignKey(
                        name: "FK__usuario__emplead__38996AB5",
                        column: x => x.empleadoId,
                        principalTable: "empleado",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__usuario__rolId__398D8EEE",
                        column: x => x.rolId,
                        principalTable: "rol",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_usuario_sucursal_SucursalId",
                        column: x => x.SucursalId,
                        principalTable: "sucursal",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "venta",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    fecha = table.Column<DateTime>(type: "date", nullable: false),
                    clienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmpleadoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_venta", x => x.id);
                    table.ForeignKey(
                        name: "FK__venta__clienteId__31EC6D26",
                        column: x => x.clienteId,
                        principalTable: "cliente",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_venta_empleado_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "empleado",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "detalleVenta",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    productoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ventaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalleVenta", x => x.id);
                    table.ForeignKey(
                        name: "FK__detalleVe__produ__36B12243",
                        column: x => x.productoId,
                        principalTable: "producto",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__detalleVe__venta__37A5467C",
                        column: x => x.ventaId,
                        principalTable: "venta",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_detalleVenta_productoId",
                table: "detalleVenta",
                column: "productoId");

            migrationBuilder.CreateIndex(
                name: "IX_detalleVenta_ventaId",
                table: "detalleVenta",
                column: "ventaId");

            migrationBuilder.CreateIndex(
                name: "IX_empleado_horarioId",
                table: "empleado",
                column: "horarioId");

            migrationBuilder.CreateIndex(
                name: "IX_empleado_puestoId",
                table: "empleado",
                column: "puestoId");

            migrationBuilder.CreateIndex(
                name: "IX_fidelizacion_clienteId",
                table: "fidelizacion",
                column: "clienteId");

            migrationBuilder.CreateIndex(
                name: "IX_fidelizacion_membresiaId",
                table: "fidelizacion",
                column: "membresiaId");

            migrationBuilder.CreateIndex(
                name: "IX_movimientoInventario_empleadoId",
                table: "movimientoInventario",
                column: "empleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_movimientoInventario_productoId",
                table: "movimientoInventario",
                column: "productoId");

            migrationBuilder.CreateIndex(
                name: "IX_movimientoInventario_tipomovimientoid",
                table: "movimientoInventario",
                column: "tipomovimientoid");

            migrationBuilder.CreateIndex(
                name: "IX_producto_categoriaId",
                table: "producto",
                column: "categoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_empleadoId",
                table: "usuario",
                column: "empleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_rolId",
                table: "usuario",
                column: "rolId");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_SucursalId",
                table: "usuario",
                column: "SucursalId");

            migrationBuilder.CreateIndex(
                name: "IX_venta_clienteId",
                table: "venta",
                column: "clienteId");

            migrationBuilder.CreateIndex(
                name: "IX_venta_EmpleadoId",
                table: "venta",
                column: "EmpleadoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detalleVenta");

            migrationBuilder.DropTable(
                name: "fidelizacion");

            migrationBuilder.DropTable(
                name: "movimientoInventario");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "venta");

            migrationBuilder.DropTable(
                name: "membresia");

            migrationBuilder.DropTable(
                name: "producto");

            migrationBuilder.DropTable(
                name: "tipoMovimiento");

            migrationBuilder.DropTable(
                name: "rol");

            migrationBuilder.DropTable(
                name: "sucursal");

            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "empleado");

            migrationBuilder.DropTable(
                name: "categoria");

            migrationBuilder.DropTable(
                name: "horario");

            migrationBuilder.DropTable(
                name: "puesto");
        }
    }
}
