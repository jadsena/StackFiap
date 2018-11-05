using Microsoft.EntityFrameworkCore.Migrations;

namespace StackFiap.Migrations
{
    public partial class StackFiap8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Perguntas_Respostas_MelhorRespostaId",
                table: "Perguntas");

            migrationBuilder.AddForeignKey(
                name: "FK_Perguntas_Respostas_MelhorRespostaId",
                table: "Perguntas",
                column: "MelhorRespostaId",
                principalTable: "Respostas",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Perguntas_Respostas_MelhorRespostaId",
                table: "Perguntas");

            migrationBuilder.AddForeignKey(
                name: "FK_Perguntas_Respostas_MelhorRespostaId",
                table: "Perguntas",
                column: "MelhorRespostaId",
                principalTable: "Respostas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
