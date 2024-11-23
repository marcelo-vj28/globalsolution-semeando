﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;
using Semeando.Infrastructure.Data.AppData;

#nullable disable

namespace Semeando.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241122234526_PrimeiraMigration")]
    partial class PrimeiraMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Semeando.Domain.Entities.LevelEntity", b =>
                {
                    b.Property<int>("IdLevel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_level");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdLevel"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("descricao");

                    b.Property<string>("Dificuldade")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("dificuldade");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("titulo");

                    b.HasKey("IdLevel");

                    b.ToTable("tb_Level", (string)null);
                });

            modelBuilder.Entity("Semeando.Domain.Entities.OpcaoEntity", b =>
                {
                    b.Property<int>("IdOpcao")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_opcao");

                    b.Property<int>("IdPergunta")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_pergunta");

                    b.Property<string>("OpcaoCorreta")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("op_correta");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("texto");

                    b.HasKey("IdOpcao", "IdPergunta");

                    b.HasIndex("IdPergunta");

                    b.ToTable("tb_Opcao", (string)null);
                });

            modelBuilder.Entity("Semeando.Domain.Entities.PerguntaEntity", b =>
                {
                    b.Property<int>("IdPergunta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_pergunta");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPergunta"));

                    b.Property<int>("IdLevel")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_level");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("texto");

                    b.Property<string>("TipoPergunta")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("tipo_pergunta");

                    b.HasKey("IdPergunta");

                    b.HasIndex("IdLevel");

                    b.ToTable("tb_Pergunta", (string)null);
                });

            modelBuilder.Entity("Semeando.Domain.Entities.RespostaEntity", b =>
                {
                    b.Property<int>("IdResposta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_resposta");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdResposta"));

                    b.Property<int>("IdPergunta")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_pergunta");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_usuario");

                    b.Property<int>("OpcaoEscolhida")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("op_escolhida");

                    b.HasKey("IdResposta");

                    b.HasIndex("IdUsuario");

                    b.HasIndex("IdPergunta", "OpcaoEscolhida");

                    b.ToTable("tb_Resposta", (string)null);
                });

            modelBuilder.Entity("Semeando.Domain.Entities.UsuarioEntity", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_usuario");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("nome_usuario");

                    b.Property<string>("Ranking")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("ranking");

                    b.HasKey("IdUsuario");

                    b.ToTable("tb_Usuario", (string)null);
                });

            modelBuilder.Entity("Semeando.Domain.Entities.OpcaoEntity", b =>
                {
                    b.HasOne("Semeando.Domain.Entities.PerguntaEntity", "Pergunta")
                        .WithMany("Opcoes")
                        .HasForeignKey("IdPergunta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pergunta");
                });

            modelBuilder.Entity("Semeando.Domain.Entities.PerguntaEntity", b =>
                {
                    b.HasOne("Semeando.Domain.Entities.LevelEntity", "Level")
                        .WithMany("Perguntas")
                        .HasForeignKey("IdLevel")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Level");
                });

            modelBuilder.Entity("Semeando.Domain.Entities.RespostaEntity", b =>
                {
                    b.HasOne("Semeando.Domain.Entities.PerguntaEntity", "Pergunta")
                        .WithMany("Respostas")
                        .HasForeignKey("IdPergunta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Semeando.Domain.Entities.UsuarioEntity", "Usuario")
                        .WithMany("Respostas")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Semeando.Domain.Entities.OpcaoEntity", "Opcao")
                        .WithMany()
                        .HasForeignKey("IdPergunta", "OpcaoEscolhida")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Opcao");

                    b.Navigation("Pergunta");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Semeando.Domain.Entities.LevelEntity", b =>
                {
                    b.Navigation("Perguntas");
                });

            modelBuilder.Entity("Semeando.Domain.Entities.PerguntaEntity", b =>
                {
                    b.Navigation("Opcoes");

                    b.Navigation("Respostas");
                });

            modelBuilder.Entity("Semeando.Domain.Entities.UsuarioEntity", b =>
                {
                    b.Navigation("Respostas");
                });
#pragma warning restore 612, 618
        }
    }
}
