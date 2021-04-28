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

                    b.Property<int?>("ID_CATEGORIA")
                        .HasColumnType("int");

                    b.Property<int?>("ID_OPCAO")
                        .HasColumnType("int");

                    b.HasKey("idEnunciado");

                    b.HasIndex("ID_CATEGORIA");

                    b.HasIndex("ID_OPCAO");

                    b.ToTable("ENUNCIADOS");
                });

            modelBuilder.Entity("Repository.Models.Opcao", b =>
                {
                    b.Property<int>("idOpcao")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_OPCAO")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoriaidCategoria")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasColumnName("DESCRICAO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("idCategoria")
                        .HasColumnName("ID_CATEGORIA")
                        .HasColumnType("int");

                    b.HasKey("idOpcao");

                    b.HasIndex("CategoriaidCategoria");

                    b.ToTable("OPCOES");
                });

            modelBuilder.Entity("Repository.Models.Partida", b =>
                {
                    b.Property<int>("idPartida")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_PROJECT_USER")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataHora")
                        .HasColumnName("DATA_HORA")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ID_STATUS")
                        .HasColumnType("int");

                    b.HasKey("idPartida");

                    b.HasIndex("ID_STATUS");

                    b.ToTable("PARTIDAS");
                });

            modelBuilder.Entity("Repository.Models.Pergunta", b =>
                {
                    b.Property<int>("idPergunta")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_PERGUNTA")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ID_ENUNCIADO")
                        .HasColumnType("int");

                    b.Property<int?>("ID_OPCAO")
                        .HasColumnType("int");

                    b.HasKey("idPergunta");

                    b.HasIndex("ID_ENUNCIADO");

                    b.HasIndex("ID_OPCAO");

                    b.ToTable("PERGUNTAS");
                });

            modelBuilder.Entity("Repository.Models.Placar", b =>
                {
                    b.Property<int>("idPlacar")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_PLACAR")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ID_USUARIO")
                        .HasColumnType("int");

                    b.Property<int>("Porntuacao")
                        .HasColumnName("PONTUACAO")
                        .HasColumnType("int");

                    b.Property<int>("QtdTapaDado")
                        .HasColumnName("QTD_TAPA_DADO")
                        .HasColumnType("int");

                    b.Property<int>("QtdTapaRecebido")
                        .HasColumnName("QTD_TAPA_RECEBIDO")
                        .HasColumnType("int");

                    b.HasKey("idPlacar");

                    b.HasIndex("ID_USUARIO");

                    b.ToTable("PLACARES");
                });

            modelBuilder.Entity("Repository.Models.Rodada", b =>
                {
                    b.Property<int>("idRodada")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_RODADA")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ID_PARTIDA")
                        .HasColumnType("int");

                    b.Property<int?>("ID_PERGUNTA")
                        .HasColumnType("int");

                    b.HasKey("idRodada");

                    b.HasIndex("ID_PARTIDA");

                    b.HasIndex("ID_PERGUNTA");

                    b.ToTable("RODADAS");
                });

            modelBuilder.Entity("Repository.Models.Sessao", b =>
                {
                    b.Property<int>("idSessao")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_SESSAO")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ID_PARTIDA")
                        .HasColumnType("int");

                    b.Property<int?>("ID_USUARIO")
                        .HasColumnType("int");

                    b.HasKey("idSessao");

                    b.HasIndex("ID_PARTIDA");

                    b.HasIndex("ID_USUARIO");

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

                    b.Property<int?>("ID_PLACAR")
                        .HasColumnType("int");

                    b.HasKey("idStatus");

                    b.HasIndex("ID_PLACAR");

                    b.ToTable("STATUS");
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
                        .HasForeignKey("ID_CATEGORIA");

                    b.HasOne("Repository.Models.Opcao", "Opcao")
                        .WithMany()
                        .HasForeignKey("ID_OPCAO");
                });

            modelBuilder.Entity("Repository.Models.Opcao", b =>
                {
                    b.HasOne("Repository.Models.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaidCategoria");
                });

            modelBuilder.Entity("Repository.Models.Partida", b =>
                {
                    b.HasOne("Repository.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("ID_STATUS");
                });

            modelBuilder.Entity("Repository.Models.Pergunta", b =>
                {
                    b.HasOne("Repository.Models.Enunciado", "Enunciado")
                        .WithMany()
                        .HasForeignKey("ID_ENUNCIADO");

                    b.HasOne("Repository.Models.Opcao", "Opcao")
                        .WithMany()
                        .HasForeignKey("ID_OPCAO");
                });

            modelBuilder.Entity("Repository.Models.Placar", b =>
                {
                    b.HasOne("Repository.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("ID_USUARIO");
                });

            modelBuilder.Entity("Repository.Models.Rodada", b =>
                {
                    b.HasOne("Repository.Models.Partida", "Partida")
                        .WithMany()
                        .HasForeignKey("ID_PARTIDA");

                    b.HasOne("Repository.Models.Pergunta", "Pergunta")
                        .WithMany()
                        .HasForeignKey("ID_PERGUNTA");
                });

            modelBuilder.Entity("Repository.Models.Sessao", b =>
                {
                    b.HasOne("Repository.Models.Partida", "Partida")
                        .WithMany()
                        .HasForeignKey("ID_PARTIDA");

                    b.HasOne("Repository.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("ID_USUARIO");
                });

            modelBuilder.Entity("Repository.Models.Status", b =>
                {
                    b.HasOne("Repository.Models.Placar", "Placar")
                        .WithMany()
                        .HasForeignKey("ID_PLACAR");
                });
#pragma warning restore 612, 618
        }
    }
}
