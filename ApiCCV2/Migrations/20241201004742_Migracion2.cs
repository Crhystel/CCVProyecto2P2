using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCCV2.Migrations
{
    /// <inheritdoc />
    public partial class Migracion2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Estudiantes",
                columns: new[] { "Id", "Cedula", "Contrasenia", "Edad", "Grado", "Nombre", "NombreUsuario", "Rol" },
                values: new object[] { 1, "0111111111", "crhys", 19, 0, "Crhystel", "crhys", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Estudiantes",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
