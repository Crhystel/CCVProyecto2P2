using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCCV2.Migrations
{
    /// <inheritdoc />
    public partial class Migracion77 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "MateriaProfesores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "GradoEstudiantes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ClaseProfesores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ClaseEstudiantes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ActividadProfesores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ActividadEstudiantes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "MateriaProfesores");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "GradoEstudiantes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ClaseProfesores");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ClaseEstudiantes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ActividadProfesores");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ActividadEstudiantes");
        }
    }
}
