using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class Adiciona_Data_Hora_Fim_Partida : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DATA_HORA",
                table: "PARTIDAS");

            migrationBuilder.RenameColumn(
                name: "ID_PROJECT_USER",
                table: "PARTIDAS",
                newName: "ID_PARTIDA");

            migrationBuilder.AddColumn<DateTime>(
                name: "DATA_HORA_FIM",
                table: "PARTIDAS",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DATA_HORA_INICIO",
                table: "PARTIDAS",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DATA_HORA_FIM",
                table: "PARTIDAS");

            migrationBuilder.DropColumn(
                name: "DATA_HORA_INICIO",
                table: "PARTIDAS");

            migrationBuilder.RenameColumn(
                name: "ID_PARTIDA",
                table: "PARTIDAS",
                newName: "ID_PROJECT_USER");

            migrationBuilder.AddColumn<DateTime>(
                name: "DATA_HORA",
                table: "PARTIDAS",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
