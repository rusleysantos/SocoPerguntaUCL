﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository.Models;

namespace Repository.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Repository.Models.Categoria", b =>
                {
                    b.Property<int>("idCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_CATEGORIA")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnName("DESCRICAO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnName("NOME")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idCategoria");

                    b.ToTable("CATEGORIAS");
                });

            modelBuilder.Entity("Repository.Models.Enunciado", b =>
                {
                    b.Property<int>("idEnunciado")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_ENUNCIADO")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnName("DESCRICAO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PalavraChave")
                        .HasColumnName("PALAVRA_CHAVE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("idCategoria")
                        .HasColumnType("int");

                    b.Property<int?>("idOpcao")
                        .HasColumnType("int");

                    b.Property<int?>("idSubCategoria")
                        .HasColumnType("int");

                    b.HasKey("idEnunciado");

                    b.HasIndex("idCategoria");

                    b.HasIndex("idOpcao");

                    b.HasIndex("idSubCategoria");

                    b.ToTable("ENUNCIADOS");
                });

            modelBuilder.Entity("Repository.Models.Opcao", b =>
                {
                    b.Property<int>("idOpcao")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_OPCAO")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnName("DESCRICAO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("idCategoria")
                        .HasColumnType("int");

                    b.Property<int?>("idSubCategoria")
                        .HasColumnType("int");

                    b.HasKey("idOpcao");

                    b.HasIndex("idCategoria");

                    b.HasIndex("idSubCategoria");

                    b.ToTable("OPCOES");
                });

            modelBuilder.Entity("Repository.Models.Partida", b =>
                {
                    b.Property<int>("idPartida")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_PARTIDA")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataHoraFim")
                        .HasColumnName("DATA_HORA_FIM")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataHoraInicio")
                        .HasColumnName("DATA_HORA_INICIO")
                        .HasColumnType("datetime2");

                    b.Property<int?>("idCategoria")
                        .HasColumnType("int");

                    b.HasKey("idPartida");

                    b.HasIndex("idCategoria");

                    b.ToTable("PARTIDAS");
                });

            modelBuilder.Entity("Repository.Models.Pergunta", b =>
                {
                    b.Property<int>("idPergunta")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_PERGUNTA")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("idEnunciado")
                        .HasColumnType("int");

                    b.Property<int?>("idOpcao")
                        .HasColumnType("int");

                    b.HasKey("idPergunta");

                    b.HasIndex("idEnunciado");

                    b.HasIndex("idOpcao");

                    b.ToTable("PERGUNTAS");
                });

            modelBuilder.Entity("Repository.Models.Placar", b =>
                {
                    b.Property<int>("idPlacar")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_PLACAR")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Porntuacao")
                        .HasColumnName("PONTUACAO")
                        .HasColumnType("int");

                    b.Property<int>("QtdTapaDado")
                        .HasColumnName("QTD_TAPA_DADO")
                        .HasColumnType("int");

                    b.Property<int>("QtdTapaRecebido")
                        .HasColumnName("QTD_TAPA_RECEBIDO")
                        .HasColumnType("int");

                    b.Property<int?>("idUsuario")
                        .HasColumnType("int");

                    b.HasKey("idPlacar");

                    b.HasIndex("idUsuario");

                    b.ToTable("PLACARES");
                });

            modelBuilder.Entity("Repository.Models.Rodada", b =>
                {
                    b.Property<int>("idRodada")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_RODADA")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("idPartida")
                        .HasColumnType("int");

                    b.Property<int?>("idPergunta")
                        .HasColumnType("int");

                    b.HasKey("idRodada");

                    b.HasIndex("idPartida");

                    b.HasIndex("idPergunta");

                    b.ToTable("RODADAS");
                });

            modelBuilder.Entity("Repository.Models.Sessao", b =>
                {
                    b.Property<int>("idSessao")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_SESSAO")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("idPartida")
                        .HasColumnType("int");

                    b.Property<int?>("idStatus")
                        .HasColumnType("int");

                    b.Property<int?>("idUsuario")
                        .HasColumnType("int");

                    b.HasKey("idSessao");

                    b.HasIndex("idPartida");

                    b.HasIndex("idStatus");

                    b.HasIndex("idUsuario");

                    b.ToTable("SESSOES");
                });

            modelBuilder.Entity("Repository.Models.Status", b =>
                {
                    b.Property<int>("idStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_STATUS")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativa")
                        .HasColumnName("ATIVA")
                        .HasColumnType("bit");

                    b.Property<bool>("VezResponder")
                        .HasColumnName("VEZ_RESPONDER")
                        .HasColumnType("bit");

                    b.Property<int?>("idPlacar")
                        .HasColumnType("int");

                    b.HasKey("idStatus");

                    b.HasIndex("idPlacar");

                    b.ToTable("STATUS");
                });

            modelBuilder.Entity("Repository.Models.SubCategoria", b =>
                {
                    b.Property<int>("idSubCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_SUB_CATEGORIA")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnName("DESCRICAO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnName("NOME")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idSubCategoria");

                    b.ToTable("SUB_CATEGORIAS");
                });

            modelBuilder.Entity("Repository.Models.Usuario", b =>
                {
                    b.Property<int>("idUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_USUARIO")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnName("NOME")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .HasColumnName("SENHA")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idUsuario");

                    b.ToTable("USUARIOS");
                });

            modelBuilder.Entity("Repository.Models.Enunciado", b =>
                {
                    b.HasOne("Repository.Models.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("idCategoria");

                    b.HasOne("Repository.Models.Opcao", "Opcao")
                        .WithMany()
                        .HasForeignKey("idOpcao");

                    b.HasOne("Repository.Models.SubCategoria", "SubCategoria")
                        .WithMany()
                        .HasForeignKey("idSubCategoria");
                });

            modelBuilder.Entity("Repository.Models.Opcao", b =>
                {
                    b.HasOne("Repository.Models.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("idCategoria");

                    b.HasOne("Repository.Models.SubCategoria", "SubCategoria")
                        .WithMany()
                        .HasForeignKey("idSubCategoria");
                });

            modelBuilder.Entity("Repository.Models.Partida", b =>
                {
                    b.HasOne("Repository.Models.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("idCategoria");
                });

            modelBuilder.Entity("Repository.Models.Pergunta", b =>
                {
                    b.HasOne("Repository.Models.Enunciado", "Enunciado")
                        .WithMany()
                        .HasForeignKey("idEnunciado");

                    b.HasOne("Repository.Models.Opcao", "Opcao")
                        .WithMany()
                        .HasForeignKey("idOpcao");
                });

            modelBuilder.Entity("Repository.Models.Placar", b =>
                {
                    b.HasOne("Repository.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("idUsuario");
                });

            modelBuilder.Entity("Repository.Models.Rodada", b =>
                {
                    b.HasOne("Repository.Models.Partida", "Partida")
                        .WithMany()
                        .HasForeignKey("idPartida");

                    b.HasOne("Repository.Models.Pergunta", "Pergunta")
                        .WithMany()
                        .HasForeignKey("idPergunta");
                });

            modelBuilder.Entity("Repository.Models.Sessao", b =>
                {
                    b.HasOne("Repository.Models.Partida", "Partida")
                        .WithMany()
                        .HasForeignKey("idPartida");

                    b.HasOne("Repository.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("idStatus");

                    b.HasOne("Repository.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("idUsuario");
                });

            modelBuilder.Entity("Repository.Models.Status", b =>
                {
                    b.HasOne("Repository.Models.Placar", "Placar")
                        .WithMany()
                        .HasForeignKey("idPlacar");
                });
#pragma warning restore 612, 618
        }
    }
}
