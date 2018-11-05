using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StackFiap.Migrations
{
    public partial class StackFiap3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Perguntas_Respostas_MelhorRespostaId",
                table: "Perguntas");

            migrationBuilder.DropForeignKey(
                name: "FK_Respostas_Perguntas_PerguntaId",
                table: "Respostas");

            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Respostas_AutorId",
                table: "Respostas",
                column: "AutorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Perguntas_AutorId",
                table: "Perguntas",
                column: "AutorId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Perguntas_Autores_AutorId",
                table: "Perguntas",
                column: "AutorId",
                principalTable: "Autores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Perguntas_Respostas_MelhorRespostaId",
                table: "Perguntas",
                column: "MelhorRespostaId",
                principalTable: "Respostas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Respostas_Autores_AutorId",
                table: "Respostas",
                column: "AutorId",
                principalTable: "Autores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Respostas_Perguntas_PerguntaId",
                table: "Respostas",
                column: "PerguntaId",
                principalTable: "Perguntas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Perguntas_Autores_AutorId",
                table: "Perguntas");

            migrationBuilder.DropForeignKey(
                name: "FK_Perguntas_Respostas_MelhorRespostaId",
                table: "Perguntas");

            migrationBuilder.DropForeignKey(
                name: "FK_Respostas_Autores_AutorId",
                table: "Respostas");

            migrationBuilder.DropForeignKey(
                name: "FK_Respostas_Perguntas_PerguntaId",
                table: "Respostas");

            migrationBuilder.DropTable(
                name: "Autores");

            migrationBuilder.DropIndex(
                name: "IX_Respostas_AutorId",
                table: "Respostas");

            migrationBuilder.DropIndex(
                name: "IX_Perguntas_AutorId",
                table: "Perguntas");

            migrationBuilder.AddForeignKey(
                name: "FK_Perguntas_Respostas_MelhorRespostaId",
                table: "Perguntas",
                column: "MelhorRespostaId",
                principalTable: "Respostas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Respostas_Perguntas_PerguntaId",
                table: "Respostas",
                column: "PerguntaId",
                principalTable: "Perguntas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
