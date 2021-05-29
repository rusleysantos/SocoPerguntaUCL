using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class Adiciona_Categoria_Partida : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idCategoria",
                table: "PARTIDAS",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PARTIDAS_idCategoria",
                table: "PARTIDAS",
                column: "idCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_PARTIDAS_CATEGORIAS_idCategoria",
                table: "PARTIDAS",
                column: "idCategoria",
                principalTable: "CATEGORIAS",
                principalColumn: "ID_CATEGORIA",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PARTIDAS_CATEGORIAS_idCategoria",
                table: "PARTIDAS");

            migrationBuilder.DropIndex(
                name: "IX_PARTIDAS_idCategoria",
                table: "PARTIDAS");

            migrationBuilder.DropColumn(
                name: "idCategoria",
                table: "PARTIDAS");
        }
    }
}
