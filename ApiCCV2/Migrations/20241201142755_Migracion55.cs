using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCCV2.Migrations
{
    /// <inheritdoc />
    public partial class Migracion55 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MateriaId",
                table: "Profesores");

            migrationBuilder.DropColumn(
                name: "Materias",
                table: "Profesores");

            migrationBuilder.DropColumn(
                name: "Grado",
                table: "Estudiantes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MateriaId",
                table: "Profesores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Materias",
                table: "Profesores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Grado",
                table: "Estudiantes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Estudiantes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Grado",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Profesores",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "MateriaId", "Materias" },
                values: new object[] { 0, 4 });
        }
    }
}
