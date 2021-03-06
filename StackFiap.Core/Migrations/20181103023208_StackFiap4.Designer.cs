﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StackFiap.Core.Data;

namespace StackFiap.Core.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20181103023208_StackFiap4")]
    partial class StackFiap4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-preview3-35497")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StackFiap.Models.Autor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCriacao")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2018, 11, 2, 23, 32, 8, 234, DateTimeKind.Local).AddTicks(1685));

                    b.Property<string>("Email");

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Autores");
                });

            modelBuilder.Entity("StackFiap.Models.Pergunta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Aberto");

                    b.Property<int>("AutorId");

                    b.Property<DateTime>("DataCriacao");

                    b.Property<int>("MelhorRespostaId");

                    b.Property<string>("Texto");

                    b.HasKey("Id");

                    b.HasIndex("AutorId")
                        .IsUnique();

                    b.HasIndex("MelhorRespostaId")
                        .IsUnique();

                    b.ToTable("Perguntas");
                });

            modelBuilder.Entity("StackFiap.Models.Resposta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Aberto");

                    b.Property<int>("AutorId");

                    b.Property<DateTime>("DataCriacao");

                    b.Property<int>("PerguntaId");

                    b.Property<string>("Texto");

                    b.HasKey("Id");

                    b.HasIndex("AutorId")
                        .IsUnique();

                    b.HasIndex("PerguntaId");

                    b.ToTable("Respostas");
                });

            modelBuilder.Entity("StackFiap.Models.Pergunta", b =>
                {
                    b.HasOne("StackFiap.Models.Autor", "Autor")
                        .WithOne()
                        .HasForeignKey("StackFiap.Models.Pergunta", "AutorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("StackFiap.Models.Resposta", "MelhorResposta")
                        .WithOne("Pergunta")
                        .HasForeignKey("StackFiap.Models.Pergunta", "MelhorRespostaId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("StackFiap.Models.Resposta", b =>
                {
                    b.HasOne("StackFiap.Models.Autor", "Autor")
                        .WithOne()
                        .HasForeignKey("StackFiap.Models.Resposta", "AutorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("StackFiap.Models.Pergunta")
                        .WithMany("Respostas")
                        .HasForeignKey("PerguntaId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
