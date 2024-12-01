using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCCV2.Migrations
{
    /// <inheritdoc />
    public partial class Migracion3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profesores_Materias_MateriasId",
                table: "Profesores");

            migrationBuilder.RenameColumn(
                name: "MateriasId",
                table: "Profesores",
                newName: "MateriaId");

            migrationBuilder.RenameIndex(
                name: "IX_Profesores_MateriasId",
                table: "Profesores",
                newName: "IX_Profesores_MateriaId");

            migrationBuilder.CreateTable(
                name: "MateriaProfesores",
                columns: table => new
                {
                    ProfesorId = table.Column<int>(type: "int", nullable: false),
                    MateriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MateriaProfesores", x => new { x.ProfesorId, x.MateriaId });
                    table.ForeignKey(
                        name: "FK_MateriaProfesores_Materias_ProfesorId",
                        column: x => x.ProfesorId,
                        principalTable: "Materias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MateriaProfesores_Profesores_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "Profesores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MateriaProfesores_MateriaId",
                table: "MateriaProfesores",
                column: "MateriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profesores_Materias_MateriaId",
                table: "Profesores",
                column: "MateriaId",
                principalTable: "Materias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profesores_Materias_MateriaId",
                table: "Profesores");

            migrationBuilder.DropTable(
                name: "MateriaProfesores");

            migrationBuilder.RenameColumn(
                name: "MateriaId",
                table: "Profesores",
                newName: "MateriasId");

            migrationBuilder.RenameIndex(
                name: "IX_Profesores_MateriaId",
                table: "Profesores",
                newName: "IX_Profesores_MateriasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profesores_Materias_MateriasId",
                table: "Profesores",
                column: "MateriasId",
                principalTable: "Materias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
