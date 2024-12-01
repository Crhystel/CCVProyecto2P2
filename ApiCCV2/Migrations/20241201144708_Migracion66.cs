using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCCV2.Migrations
{
    /// <inheritdoc />
    public partial class Migracion66 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clases_Grados_GradoId",
                table: "Clases");

            migrationBuilder.DropForeignKey(
                name: "FK_Clases_Materias_MateriaId",
                table: "Clases");

            migrationBuilder.DropIndex(
                name: "IX_Clases_GradoId",
                table: "Clases");

            migrationBuilder.DropIndex(
                name: "IX_Clases_MateriaId",
                table: "Clases");

            migrationBuilder.DropColumn(
                name: "GradoId",
                table: "Clases");

            migrationBuilder.DropColumn(
                name: "MateriaId",
                table: "Clases");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GradoId",
                table: "Clases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MateriaId",
                table: "Clases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Clases_GradoId",
                table: "Clases",
                column: "GradoId");

            migrationBuilder.CreateIndex(
                name: "IX_Clases_MateriaId",
                table: "Clases",
                column: "MateriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clases_Grados_GradoId",
                table: "Clases",
                column: "GradoId",
                principalTable: "Grados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clases_Materias_MateriaId",
                table: "Clases",
                column: "MateriaId",
                principalTable: "Materias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
