using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StackFiap.Core.Migrations
{
    public partial class StackFiap5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "Autores",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 11, 2, 23, 32, 8, 234, DateTimeKind.Local).AddTicks(1685));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "Autores",
                nullable: false,
                defaultValue: new DateTime(2018, 11, 2, 23, 32, 8, 234, DateTimeKind.Local).AddTicks(1685),
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getdate()");
        }
    }
}
