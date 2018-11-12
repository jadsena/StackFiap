using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StackFiap.Core.Migrations
{
    public partial class StackFiap2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Respostas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Texto = table.Column<string>(nullable: true),
                    AutorId = table.Column<int>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    Aberto = table.Column<bool>(nullable: false),
                    PerguntaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Respostas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Respostas_Perguntas_PerguntaId",
                        column: x => x.PerguntaId,
                        principalTable: "Perguntas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Perguntas_MelhorRespostaId",
                table: "Perguntas",
                column: "MelhorRespostaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Respostas_PerguntaId",
                table: "Respostas",
                column: "PerguntaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Perguntas_Respostas_MelhorRespostaId",
                table: "Perguntas",
                column: "MelhorRespostaId",
                principalTable: "Respostas",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Perguntas_Respostas_MelhorRespostaId",
                table: "Perguntas");

            migrationBuilder.DropTable(
                name: "Respostas");

            migrationBuilder.DropIndex(
                name: "IX_Perguntas_MelhorRespostaId",
                table: "Perguntas");
        }
    }
}
