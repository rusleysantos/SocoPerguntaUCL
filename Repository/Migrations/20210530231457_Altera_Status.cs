using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class Altera_Status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PARTIDAS_STATUS_idStatus",
                table: "PARTIDAS");

            migrationBuilder.DropIndex(
                name: "IX_PARTIDAS_idStatus",
                table: "PARTIDAS");

            migrationBuilder.DropColumn(
                name: "idStatus",
                table: "PARTIDAS");

            migrationBuilder.AddColumn<int>(
                name: "idStatus",
                table: "SESSOES",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SESSOES_idStatus",
                table: "SESSOES",
                column: "idStatus");

            migrationBuilder.AddForeignKey(
                name: "FK_SESSOES_STATUS_idStatus",
                table: "SESSOES",
                column: "idStatus",
                principalTable: "STATUS",
                principalColumn: "ID_STATUS",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SESSOES_STATUS_idStatus",
                table: "SESSOES");

            migrationBuilder.DropIndex(
                name: "IX_SESSOES_idStatus",
                table: "SESSOES");

            migrationBuilder.DropColumn(
                name: "idStatus",
                table: "SESSOES");

            migrationBuilder.AddColumn<int>(
                name: "idStatus",
                table: "PARTIDAS",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PARTIDAS_idStatus",
                table: "PARTIDAS",
                column: "idStatus");

            migrationBuilder.AddForeignKey(
                name: "FK_PARTIDAS_STATUS_idStatus",
                table: "PARTIDAS",
                column: "idStatus",
                principalTable: "STATUS",
                principalColumn: "ID_STATUS",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
