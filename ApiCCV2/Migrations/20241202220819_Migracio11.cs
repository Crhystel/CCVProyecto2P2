using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCCV2.Migrations
{
    /// <inheritdoc />
    public partial class Migracio11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actividades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaEntrega = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actividades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Administrador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cedula = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NombreUsuario = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Contrasenia = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Rol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NombreUsuario = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Contrasenia = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Rol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profesores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Materia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NombreUsuario = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Contrasenia = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Rol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClaseActividades",
                columns: table => new
                {
                    ClaseId = table.Column<int>(type: "int", nullable: false),
                    ActividadId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaseActividades", x => new { x.ActividadId, x.ClaseId });
                    table.ForeignKey(
                        name: "FK_ClaseActividades_Actividades_ActividadId",
                        column: x => x.ActividadId,
                        principalTable: "Actividades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClaseActividades_Clases_ClaseId",
                        column: x => x.ClaseId,
                        principalTable: "Clases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActividadEstudiantes",
                columns: table => new
                {
                    EstudianteId = table.Column<int>(type: "int", nullable: false),
                    ActividadId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActividadEstudiantes", x => new { x.ActividadId, x.EstudianteId });
                    table.ForeignKey(
                        name: "FK_ActividadEstudiantes_Actividades_ActividadId",
                        column: x => x.ActividadId,
                        principalTable: "Actividades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActividadEstudiantes_Estudiantes_EstudianteId",
                        column: x => x.EstudianteId,
                        principalTable: "Estudiantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClaseEstudiantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaseId = table.Column<int>(type: "int", nullable: false),
                    EstudianteId = table.Column<int>(type: "int", nullable: false),
                    Grado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaseEstudiantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClaseEstudiantes_Clases_ClaseId",
                        column: x => x.ClaseId,
                        principalTable: "Clases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClaseEstudiantes_Estudiantes_EstudianteId",
                        column: x => x.EstudianteId,
                        principalTable: "Estudiantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActividadProfesores",
                columns: table => new
                {
                    ProfesorId = table.Column<int>(type: "int", nullable: false),
                    ActividadId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActividadProfesores", x => new { x.ActividadId, x.ProfesorId });
                    table.ForeignKey(
                        name: "FK_ActividadProfesores_Actividades_ActividadId",
                        column: x => x.ActividadId,
                        principalTable: "Actividades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActividadProfesores_Profesores_ProfesorId",
                        column: x => x.ProfesorId,
                        principalTable: "Profesores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClaseProfesores",
                columns: table => new
                {
                    ClasePId = table.Column<int>(type: "int", nullable: false),
                    ProfesorId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Materia = table.Column<int>(type: "int", nullable: false),
                    EstudianteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaseProfesores", x => new { x.ProfesorId, x.ClasePId });
                    table.ForeignKey(
                        name: "FK_ClaseProfesores_Clases_ClasePId",
                        column: x => x.ClasePId,
                        principalTable: "Clases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClaseProfesores_Estudiantes_EstudianteId",
                        column: x => x.EstudianteId,
                        principalTable: "Estudiantes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClaseProfesores_Profesores_ProfesorId",
                        column: x => x.ProfesorId,
                        principalTable: "Profesores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Administrador",
                columns: new[] { "Id", "Cedula", "Contrasenia", "Edad", "Nombre", "NombreUsuario", "Rol" },
                values: new object[] { 1, "1234567890", "admin", 30, "Roberto", "admin", 0 });

            migrationBuilder.InsertData(
                table: "Estudiantes",
                columns: new[] { "Id", "Cedula", "Contrasenia", "Edad", "Grado", "Nombre", "NombreUsuario", "Rol" },
                values: new object[] { 1, "0111111111", "crhys", 19, "Primer_Bachillerato_BGU", "Crhystel", "crhys", 1 });

            migrationBuilder.InsertData(
                table: "Profesores",
                columns: new[] { "Id", "Cedula", "Contrasenia", "Edad", "Materia", "Nombre", "NombreUsuario", "Rol" },
                values: new object[] { 1, "0111111122", "yuli", 19, "Biologia", "Yuliana", "yuli", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_ActividadEstudiantes_EstudianteId",
                table: "ActividadEstudiantes",
                column: "EstudianteId");

            migrationBuilder.CreateIndex(
                name: "IX_ActividadProfesores_ProfesorId",
                table: "ActividadProfesores",
                column: "ProfesorId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaseActividades_ClaseId",
                table: "ClaseActividades",
                column: "ClaseId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaseEstudiantes_ClaseId",
                table: "ClaseEstudiantes",
                column: "ClaseId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaseEstudiantes_EstudianteId",
                table: "ClaseEstudiantes",
                column: "EstudianteId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaseProfesores_ClasePId",
                table: "ClaseProfesores",
                column: "ClasePId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaseProfesores_EstudianteId",
                table: "ClaseProfesores",
                column: "EstudianteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActividadEstudiantes");

            migrationBuilder.DropTable(
                name: "ActividadProfesores");

            migrationBuilder.DropTable(
                name: "Administrador");

            migrationBuilder.DropTable(
                name: "ClaseActividades");

            migrationBuilder.DropTable(
                name: "ClaseEstudiantes");

            migrationBuilder.DropTable(
                name: "ClaseProfesores");

            migrationBuilder.DropTable(
                name: "Grados");

            migrationBuilder.DropTable(
                name: "Materias");

            migrationBuilder.DropTable(
                name: "Actividades");

            migrationBuilder.DropTable(
                name: "Clases");

            migrationBuilder.DropTable(
                name: "Estudiantes");

            migrationBuilder.DropTable(
                name: "Profesores");
        }
    }
}
