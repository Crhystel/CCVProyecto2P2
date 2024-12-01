using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCCV2.Migrations
{
    /// <inheritdoc />
    public partial class Migracion6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profesores_Materias_MateriaId",
                table: "Profesores");

            migrationBuilder.DropIndex(
                name: "IX_Profesores_MateriaId",
                table: "Profesores");

            migrationBuilder.AddColumn<int>(
                name: "Materias",
                table: "Profesores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Estudiantes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Grado",
                value: 2);

            migrationBuilder.InsertData(
                table: "Profesores",
                columns: new[] { "Id", "Cedula", "Contrasenia", "Edad", "MateriaId", "Materias", "Nombre", "NombreUsuario", "Rol" },
                values: new object[] { 1, "0111111122", "yuli", 19, 0, 4, "Yuliana", "yuli", 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Profesores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Materias",
                table: "Profesores");

            migrationBuilder.UpdateData(
                table: "Estudiantes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Grado",
                value: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Profesores_MateriaId",
                table: "Profesores",
                column: "MateriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profesores_Materias_MateriaId",
                table: "Profesores",
                column: "MateriaId",
                principalTable: "Materias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
