using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class Adiciona_Chat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CHAT",
                columns: table => new
                {
                    ID_CHAT = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MENSAGEM = table.Column<string>(nullable: true),
                    DESTINATARIO = table.Column<bool>(nullable: false),
                    REMETENTE = table.Column<bool>(nullable: false),
                    idPartida = table.Column<int>(nullable: true),
                    idUsuario = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CHAT", x => x.ID_CHAT);
                    table.ForeignKey(
                        name: "FK_CHAT_PARTIDAS_idPartida",
                        column: x => x.idPartida,
                        principalTable: "PARTIDAS",
                        principalColumn: "ID_PARTIDA",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CHAT_USUARIOS_idUsuario",
                        column: x => x.idUsuario,
                        principalTable: "USUARIOS",
                        principalColumn: "ID_USUARIO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LOG_PARTIDA",
                columns: table => new
                {
                    ID_LOG_PARTIDA = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRICAO = table.Column<string>(nullable: true),
                    idPartida = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOG_PARTIDA", x => x.ID_LOG_PARTIDA);
                    table.ForeignKey(
                        name: "FK_LOG_PARTIDA_PARTIDAS_idPartida",
                        column: x => x.idPartida,
                        principalTable: "PARTIDAS",
                        principalColumn: "ID_PARTIDA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CHAT_idPartida",
                table: "CHAT",
                column: "idPartida");

            migrationBuilder.CreateIndex(
                name: "IX_CHAT_idUsuario",
                table: "CHAT",
                column: "idUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_LOG_PARTIDA_idPartida",
                table: "LOG_PARTIDA",
                column: "idPartida");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CHAT");

            migrationBuilder.DropTable(
                name: "LOG_PARTIDA");
        }
    }
}
