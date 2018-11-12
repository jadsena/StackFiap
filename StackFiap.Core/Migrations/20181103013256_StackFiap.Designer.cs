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
    [Migration("20181103013256_StackFiap")]
    partial class StackFiap
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-preview3-35497")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.ToTable("Perguntas");
                });
#pragma warning restore 612, 618
        }
    }
}