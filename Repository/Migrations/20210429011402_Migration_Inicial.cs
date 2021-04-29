using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class Migration_Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CATEGORIAS",
                columns: table => new
                {
                    ID_CATEGORIA = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(nullable: true),
                    DESCRICAO = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORIAS", x => x.ID_CATEGORIA);
                });

            migrationBuilder.CreateTable(
                name: "USUARIOS",
                columns: table => new
                {
                    ID_USUARIO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(nullable: true),
                    SENHA = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIOS", x => x.ID_USUARIO);
                });

            migrationBuilder.CreateTable(
                name: "OPCOES",
                columns: table => new
                {
                    ID_OPCAO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRICAO = table.Column<string>(nullable: true),
                    idCategoria = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OPCOES", x => x.ID_OPCAO);
                    table.ForeignKey(
                        name: "FK_OPCOES_CATEGORIAS_idCategoria",
                        column: x => x.idCategoria,
                        principalTable: "CATEGORIAS",
                        principalColumn: "ID_CATEGORIA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PLACARES",
                columns: table => new
                {
                    ID_PLACAR = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PONTUACAO = table.Column<int>(nullable: false),
                    QTD_TAPA_RECEBIDO = table.Column<int>(nullable: false),
                    QTD_TAPA_DADO = table.Column<int>(nullable: false),
                    idUsuario = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLACARES", x => x.ID_PLACAR);
                    table.ForeignKey(
                        name: "FK_PLACARES_USUARIOS_idUsuario",
                        column: x => x.idUsuario,
                        principalTable: "USUARIOS",
                        principalColumn: "ID_USUARIO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ENUNCIADOS",
                columns: table => new
                {
                    ID_ENUNCIADO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRICAO = table.Column<string>(nullable: true),
                    idCategoria = table.Column<int>(nullable: true),
                    idOpcao = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENUNCIADOS", x => x.ID_ENUNCIADO);
                    table.ForeignKey(
                        name: "FK_ENUNCIADOS_CATEGORIAS_idCategoria",
                        column: x => x.idCategoria,
                        principalTable: "CATEGORIAS",
                        principalColumn: "ID_CATEGORIA",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ENUNCIADOS_OPCOES_idOpcao",
                        column: x => x.idOpcao,
                        principalTable: "OPCOES",
                        principalColumn: "ID_OPCAO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "STATUS",
                columns: table => new
                {
                    ID_STATUS = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ATIVA = table.Column<bool>(nullable: false),
                    idPlacar = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STATUS", x => x.ID_STATUS);
                    table.ForeignKey(
                        name: "FK_STATUS_PLACARES_idPlacar",
                        column: x => x.idPlacar,
                        principalTable: "PLACARES",
                        principalColumn: "ID_PLACAR",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PERGUNTAS",
                columns: table => new
                {
                    ID_PERGUNTA = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idEnunciado = table.Column<int>(nullable: true),
                    idOpcao = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERGUNTAS", x => x.ID_PERGUNTA);
                    table.ForeignKey(
                        name: "FK_PERGUNTAS_ENUNCIADOS_idEnunciado",
                        column: x => x.idEnunciado,
                        principalTable: "ENUNCIADOS",
                        principalColumn: "ID_ENUNCIADO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PERGUNTAS_OPCOES_idOpcao",
                        column: x => x.idOpcao,
                        principalTable: "OPCOES",
                        principalColumn: "ID_OPCAO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PARTIDAS",
                columns: table => new
                {
                    ID_PROJECT_USER = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DATA_HORA = table.Column<DateTime>(nullable: false),
                    idStatus = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PARTIDAS", x => x.ID_PROJECT_USER);
                    table.ForeignKey(
                        name: "FK_PARTIDAS_STATUS_idStatus",
                        column: x => x.idStatus,
                        principalTable: "STATUS",
                        principalColumn: "ID_STATUS",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RODADAS",
                columns: table => new
                {
                    ID_RODADA = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idPartida = table.Column<int>(nullable: true),
                    idPergunta = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RODADAS", x => x.ID_RODADA);
                    table.ForeignKey(
                        name: "FK_RODADAS_PARTIDAS_idPartida",
                        column: x => x.idPartida,
                        principalTable: "PARTIDAS",
                        principalColumn: "ID_PROJECT_USER",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RODADAS_PERGUNTAS_idPergunta",
                        column: x => x.idPergunta,
                        principalTable: "PERGUNTAS",
                        principalColumn: "ID_PERGUNTA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SESSOES",
                columns: table => new
                {
                    ID_SESSAO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idPartida = table.Column<int>(nullable: true),
                    idUsuario = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SESSOES", x => x.ID_SESSAO);
                    table.ForeignKey(
                        name: "FK_SESSOES_PARTIDAS_idPartida",
                        column: x => x.idPartida,
                        principalTable: "PARTIDAS",
                        principalColumn: "ID_PROJECT_USER",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SESSOES_USUARIOS_idUsuario",
                        column: x => x.idUsuario,
                        principalTable: "USUARIOS",
                        principalColumn: "ID_USUARIO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ENUNCIADOS_idCategoria",
                table: "ENUNCIADOS",
                column: "idCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_ENUNCIADOS_idOpcao",
                table: "ENUNCIADOS",
                column: "idOpcao");

            migrationBuilder.CreateIndex(
                name: "IX_OPCOES_idCategoria",
                table: "OPCOES",
                column: "idCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_PARTIDAS_idStatus",
                table: "PARTIDAS",
                column: "idStatus");

            migrationBuilder.CreateIndex(
                name: "IX_PERGUNTAS_idEnunciado",
                table: "PERGUNTAS",
                column: "idEnunciado");

            migrationBuilder.CreateIndex(
                name: "IX_PERGUNTAS_idOpcao",
                table: "PERGUNTAS",
                column: "idOpcao");

            migrationBuilder.CreateIndex(
                name: "IX_PLACARES_idUsuario",
                table: "PLACARES",
                column: "idUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_RODADAS_idPartida",
                table: "RODADAS",
                column: "idPartida");

            migrationBuilder.CreateIndex(
                name: "IX_RODADAS_idPergunta",
                table: "RODADAS",
                column: "idPergunta");

            migrationBuilder.CreateIndex(
                name: "IX_SESSOES_idPartida",
                table: "SESSOES",
                column: "idPartida");

            migrationBuilder.CreateIndex(
                name: "IX_SESSOES_idUsuario",
                table: "SESSOES",
                column: "idUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_STATUS_idPlacar",
                table: "STATUS",
                column: "idPlacar");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RODADAS");

            migrationBuilder.DropTable(
                name: "SESSOES");

            migrationBuilder.DropTable(
                name: "PERGUNTAS");

            migrationBuilder.DropTable(
                name: "PARTIDAS");

            migrationBuilder.DropTable(
                name: "ENUNCIADOS");

            migrationBuilder.DropTable(
                name: "STATUS");

            migrationBuilder.DropTable(
                name: "OPCOES");

            migrationBuilder.DropTable(
                name: "PLACARES");

            migrationBuilder.DropTable(
                name: "CATEGORIAS");

            migrationBuilder.DropTable(
                name: "USUARIOS");
        }
    }
}
