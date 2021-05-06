using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class Adiciona_Sub_Categorias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idSubCategoria",
                table: "OPCOES",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PALAVRA_CHAVE",
                table: "ENUNCIADOS",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "idSubCategoria",
                table: "ENUNCIADOS",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SUB_CATEGORIAS",
                columns: table => new
                {
                    ID_SUB_CATEGORIA = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(nullable: true),
                    DESCRICAO = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUB_CATEGORIAS", x => x.ID_SUB_CATEGORIA);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OPCOES_idSubCategoria",
                table: "OPCOES",
                column: "idSubCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_ENUNCIADOS_idSubCategoria",
                table: "ENUNCIADOS",
                column: "idSubCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_ENUNCIADOS_SUB_CATEGORIAS_idSubCategoria",
                table: "ENUNCIADOS",
                column: "idSubCategoria",
                principalTable: "SUB_CATEGORIAS",
                principalColumn: "ID_SUB_CATEGORIA",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OPCOES_SUB_CATEGORIAS_idSubCategoria",
                table: "OPCOES",
                column: "idSubCategoria",
                principalTable: "SUB_CATEGORIAS",
                principalColumn: "ID_SUB_CATEGORIA",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ENUNCIADOS_SUB_CATEGORIAS_idSubCategoria",
                table: "ENUNCIADOS");

            migrationBuilder.DropForeignKey(
                name: "FK_OPCOES_SUB_CATEGORIAS_idSubCategoria",
                table: "OPCOES");

            migrationBuilder.DropTable(
                name: "SUB_CATEGORIAS");

            migrationBuilder.DropIndex(
                name: "IX_OPCOES_idSubCategoria",
                table: "OPCOES");

            migrationBuilder.DropIndex(
                name: "IX_ENUNCIADOS_idSubCategoria",
                table: "ENUNCIADOS");

            migrationBuilder.DropColumn(
                name: "idSubCategoria",
                table: "OPCOES");

            migrationBuilder.DropColumn(
                name: "PALAVRA_CHAVE",
                table: "ENUNCIADOS");

            migrationBuilder.DropColumn(
                name: "idSubCategoria",
                table: "ENUNCIADOS");
        }
    }
}
