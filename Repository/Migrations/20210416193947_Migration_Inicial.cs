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
                name: "ENUNCIADOS",
                columns: table => new
                {
                    ID_ENUNCIADO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRICAO = table.Column<string>(nullable: true),
                    ID_CATEGORIA = table.Column<int>(nullable: false),
                    CategoriaidCategoria = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENUNCIADOS", x => x.ID_ENUNCIADO);
                    table.ForeignKey(
                        name: "FK_ENUNCIADOS_CATEGORIAS_CategoriaidCategoria",
                        column: x => x.CategoriaidCategoria,
                        principalTable: "CATEGORIAS",
                        principalColumn: "ID_CATEGORIA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OPCOES",
                columns: table => new
                {
                    ID_OPCAO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRICAO = table.Column<string>(nullable: true),
                    ID_CATEGORIA = table.Column<int>(nullable: false),
                    CategoriaidCategoria = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OPCOES", x => x.ID_OPCAO);
                    table.ForeignKey(
                        name: "FK_OPCOES_CATEGORIAS_CategoriaidCategoria",
                        column: x => x.CategoriaidCategoria,
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
                    ID_USUARIO = table.Column<int>(nullable: false),
                    UsuarioidUsuario = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLACARES", x => x.ID_PLACAR);
                    table.ForeignKey(
                        name: "FK_PLACARES_USUARIOS_UsuarioidUsuario",
                        column: x => x.UsuarioidUsuario,
                        principalTable: "USUARIOS",
                        principalColumn: "ID_USUARIO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PERGUNTAS",
                columns: table => new
                {
                    ID_PERGUNTA = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_ENUNCIADO = table.Column<int>(nullable: false),
                    EnunciadoidEnunciado = table.Column<int>(nullable: true),
                    ID_OPCAO = table.Column<int>(nullable: false),
                    OpcaoidOpcao = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERGUNTAS", x => x.ID_PERGUNTA);
                    table.ForeignKey(
                        name: "FK_PERGUNTAS_ENUNCIADOS_EnunciadoidEnunciado",
                        column: x => x.EnunciadoidEnunciado,
                        principalTable: "ENUNCIADOS",
                        principalColumn: "ID_ENUNCIADO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PERGUNTAS_OPCOES_OpcaoidOpcao",
                        column: x => x.OpcaoidOpcao,
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
                    ID_PLACAR = table.Column<int>(nullable: false),
                    PlacaridPlacar = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STATUS", x => x.ID_STATUS);
                    table.ForeignKey(
                        name: "FK_STATUS_PLACARES_PlacaridPlacar",
                        column: x => x.PlacaridPlacar,
                        principalTable: "PLACARES",
                        principalColumn: "ID_PLACAR",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PARTIDAS",
                columns: table => new
                {
                    ID_PROJECT_USER = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DATA_HORA = table.Column<DateTime>(nullable: false),
                    ID_STATUS = table.Column<int>(nullable: false),
                    StatusidStatus = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PARTIDAS", x => x.ID_PROJECT_USER);
                    table.ForeignKey(
                        name: "FK_PARTIDAS_STATUS_StatusidStatus",
                        column: x => x.StatusidStatus,
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
                    ID_PARTIDA = table.Column<int>(nullable: false),
                    PartidaidPartida = table.Column<int>(nullable: true),
                    ID_PERGUNTA = table.Column<int>(nullable: false),
                    PerguntaidPergunta = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RODADAS", x => x.ID_RODADA);
                    table.ForeignKey(
                        name: "FK_RODADAS_PARTIDAS_PartidaidPartida",
                        column: x => x.PartidaidPartida,
                        principalTable: "PARTIDAS",
                        principalColumn: "ID_PROJECT_USER",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RODADAS_PERGUNTAS_PerguntaidPergunta",
                        column: x => x.PerguntaidPergunta,
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
                    ID_PARTIDA = table.Column<int>(nullable: false),
                    PartidaidPartida = table.Column<int>(nullable: true),
                    ID_USUARIO = table.Column<int>(nullable: false),
                    UsuarioidUsuario = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SESSOES", x => x.ID_SESSAO);
                    table.ForeignKey(
                        name: "FK_SESSOES_PARTIDAS_PartidaidPartida",
                        column: x => x.PartidaidPartida,
                        principalTable: "PARTIDAS",
                        principalColumn: "ID_PROJECT_USER",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SESSOES_USUARIOS_UsuarioidUsuario",
                        column: x => x.UsuarioidUsuario,
                        principalTable: "USUARIOS",
                        principalColumn: "ID_USUARIO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ENUNCIADOS_CategoriaidCategoria",
                table: "ENUNCIADOS",
                column: "CategoriaidCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_OPCOES_CategoriaidCategoria",
                table: "OPCOES",
                column: "CategoriaidCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_PARTIDAS_StatusidStatus",
                table: "PARTIDAS",
                column: "StatusidStatus");

            migrationBuilder.CreateIndex(
                name: "IX_PERGUNTAS_EnunciadoidEnunciado",
                table: "PERGUNTAS",
                column: "EnunciadoidEnunciado");

            migrationBuilder.CreateIndex(
                name: "IX_PERGUNTAS_OpcaoidOpcao",
                table: "PERGUNTAS",
                column: "OpcaoidOpcao");

            migrationBuilder.CreateIndex(
                name: "IX_PLACARES_UsuarioidUsuario",
                table: "PLACARES",
                column: "UsuarioidUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_RODADAS_PartidaidPartida",
                table: "RODADAS",
                column: "PartidaidPartida");

            migrationBuilder.CreateIndex(
                name: "IX_RODADAS_PerguntaidPergunta",
                table: "RODADAS",
                column: "PerguntaidPergunta");

            migrationBuilder.CreateIndex(
                name: "IX_SESSOES_PartidaidPartida",
                table: "SESSOES",
                column: "PartidaidPartida");

            migrationBuilder.CreateIndex(
                name: "IX_SESSOES_UsuarioidUsuario",
                table: "SESSOES",
                column: "UsuarioidUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_STATUS_PlacaridPlacar",
                table: "STATUS",
                column: "PlacaridPlacar");
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
                name: "OPCOES");

            migrationBuilder.DropTable(
                name: "STATUS");

            migrationBuilder.DropTable(
                name: "CATEGORIAS");

            migrationBuilder.DropTable(
                name: "PLACARES");

            migrationBuilder.DropTable(
                name: "USUARIOS");
        }
    }
}
