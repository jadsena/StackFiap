using Microsoft.EntityFrameworkCore.Migrations;

namespace StackFiap.Core.Migrations
{
    public partial class StackFiap9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Perguntas_MelhorRespostaId",
                table: "Perguntas");

            migrationBuilder.AlterColumn<int>(
                name: "MelhorRespostaId",
                table: "Perguntas",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Perguntas_MelhorRespostaId",
                table: "Perguntas",
                column: "MelhorRespostaId",
                unique: true,
                filter: "[MelhorRespostaId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Perguntas_MelhorRespostaId",
                table: "Perguntas");

            migrationBuilder.AlterColumn<int>(
                name: "MelhorRespostaId",
                table: "Perguntas",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Perguntas_MelhorRespostaId",
                table: "Perguntas",
                column: "MelhorRespostaId",
                unique: true);
        }
    }
}
