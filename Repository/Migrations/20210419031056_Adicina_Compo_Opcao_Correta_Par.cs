using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class Adicina_Compo_Opcao_Correta_Par : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OPCAO_VERDADEIRA_PARA",
                table: "OPCOES",
                nullable: true,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OPCAO_VERDADEIRA_PARA",
                table: "OPCOES");
        }
    }
}
