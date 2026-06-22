using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiMovil.Migrations
{
    /// <inheritdoc />
    public partial class AgregarSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    IdEmpleado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DNI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.IdEmpleado);
                });

            migrationBuilder.CreateTable(
                name: "Horarios",
                columns: table => new
                {
                    IdHorario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreHorario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HoraEntrada = table.Column<TimeSpan>(type: "time", nullable: false),
                    HoraSalida = table.Column<TimeSpan>(type: "time", nullable: false),
                    HoraRefrigerio = table.Column<TimeSpan>(type: "time", nullable: true),
                    HoraFinRefrigerio = table.Column<TimeSpan>(type: "time", nullable: true),
                    ToleranciaMinutos = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horarios", x => x.IdHorario);
                });

            migrationBuilder.CreateTable(
                name: "Marcaciones",
                columns: table => new
                {
                    IdMarcacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEmpleado = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "date", nullable: false),
                    HoraEntrada = table.Column<TimeSpan>(type: "time", nullable: true),
                    HoraSalida = table.Column<TimeSpan>(type: "time", nullable: true),
                    InicioDescanso = table.Column<TimeSpan>(type: "time", nullable: true),
                    FinDescanso = table.Column<TimeSpan>(type: "time", nullable: true),
                    Latitud = table.Column<decimal>(type: "decimal(18,7)", nullable: true),
                    Longitud = table.Column<decimal>(type: "decimal(18,7)", nullable: true),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcaciones", x => x.IdMarcacion);
                    table.ForeignKey(
                        name: "FK_Marcaciones_Empleados_IdEmpleado",
                        column: x => x.IdEmpleado,
                        principalTable: "Empleados",
                        principalColumn: "IdEmpleado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Clave = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdEmpleado = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Empleados_IdEmpleado",
                        column: x => x.IdEmpleado,
                        principalTable: "Empleados",
                        principalColumn: "IdEmpleado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Turnos",
                columns: table => new
                {
                    IdTurno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTurno = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdHorarioLunes = table.Column<int>(type: "int", nullable: true),
                    IdHorarioMartes = table.Column<int>(type: "int", nullable: true),
                    IdHorarioMiercoles = table.Column<int>(type: "int", nullable: true),
                    IdHorarioJueves = table.Column<int>(type: "int", nullable: true),
                    IdHorarioViernes = table.Column<int>(type: "int", nullable: true),
                    IdHorarioSabado = table.Column<int>(type: "int", nullable: true),
                    IdHorarioDomingo = table.Column<int>(type: "int", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turnos", x => x.IdTurno);
                    table.ForeignKey(
                        name: "FK_Turnos_Horarios_IdHorarioDomingo",
                        column: x => x.IdHorarioDomingo,
                        principalTable: "Horarios",
                        principalColumn: "IdHorario");
                    table.ForeignKey(
                        name: "FK_Turnos_Horarios_IdHorarioJueves",
                        column: x => x.IdHorarioJueves,
                        principalTable: "Horarios",
                        principalColumn: "IdHorario");
                    table.ForeignKey(
                        name: "FK_Turnos_Horarios_IdHorarioLunes",
                        column: x => x.IdHorarioLunes,
                        principalTable: "Horarios",
                        principalColumn: "IdHorario");
                    table.ForeignKey(
                        name: "FK_Turnos_Horarios_IdHorarioMartes",
                        column: x => x.IdHorarioMartes,
                        principalTable: "Horarios",
                        principalColumn: "IdHorario");
                    table.ForeignKey(
                        name: "FK_Turnos_Horarios_IdHorarioMiercoles",
                        column: x => x.IdHorarioMiercoles,
                        principalTable: "Horarios",
                        principalColumn: "IdHorario");
                    table.ForeignKey(
                        name: "FK_Turnos_Horarios_IdHorarioSabado",
                        column: x => x.IdHorarioSabado,
                        principalTable: "Horarios",
                        principalColumn: "IdHorario");
                    table.ForeignKey(
                        name: "FK_Turnos_Horarios_IdHorarioViernes",
                        column: x => x.IdHorarioViernes,
                        principalTable: "Horarios",
                        principalColumn: "IdHorario");
                });

            migrationBuilder.CreateTable(
                name: "Planificaciones",
                columns: table => new
                {
                    IdPlanificacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEmpleado = table.Column<int>(type: "int", nullable: false),
                    IdTurno = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planificaciones", x => x.IdPlanificacion);
                    table.ForeignKey(
                        name: "FK_Planificaciones_Empleados_IdEmpleado",
                        column: x => x.IdEmpleado,
                        principalTable: "Empleados",
                        principalColumn: "IdEmpleado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Planificaciones_Turnos_IdTurno",
                        column: x => x.IdTurno,
                        principalTable: "Turnos",
                        principalColumn: "IdTurno",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Empleados",
                columns: new[] { "IdEmpleado", "Apellidos", "Correo", "DNI", "Estado", "Nombres", "Telefono" },
                values: new object[] { 1, "Admin", "misael@cibertec.com", "12345678", true, "Misael", "999888777" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "IdUsuario", "Clave", "Estado", "IdEmpleado", "Rol", "Usuario" },
                values: new object[] { 1, "123456", true, 1, "Administrador", "misael@cibertec.com" });

            migrationBuilder.CreateIndex(
                name: "IX_Marcaciones_IdEmpleado",
                table: "Marcaciones",
                column: "IdEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_Planificaciones_IdEmpleado",
                table: "Planificaciones",
                column: "IdEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_Planificaciones_IdTurno",
                table: "Planificaciones",
                column: "IdTurno");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_IdHorarioDomingo",
                table: "Turnos",
                column: "IdHorarioDomingo");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_IdHorarioJueves",
                table: "Turnos",
                column: "IdHorarioJueves");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_IdHorarioLunes",
                table: "Turnos",
                column: "IdHorarioLunes");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_IdHorarioMartes",
                table: "Turnos",
                column: "IdHorarioMartes");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_IdHorarioMiercoles",
                table: "Turnos",
                column: "IdHorarioMiercoles");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_IdHorarioSabado",
                table: "Turnos",
                column: "IdHorarioSabado");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_IdHorarioViernes",
                table: "Turnos",
                column: "IdHorarioViernes");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdEmpleado",
                table: "Usuarios",
                column: "IdEmpleado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Marcaciones");

            migrationBuilder.DropTable(
                name: "Planificaciones");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Turnos");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Horarios");
        }
    }
}
