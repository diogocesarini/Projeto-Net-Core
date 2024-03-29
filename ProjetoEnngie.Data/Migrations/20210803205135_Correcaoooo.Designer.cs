﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoEnngie.Data.Context;

namespace ProjetoEnngie.Data.Migrations
{
    [DbContext(typeof(MeuDBContext))]
    [Migration("20210803205135_Correcaoooo")]
    partial class Correcaoooo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjetoEnngie.Business.Models.Fornecedor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Fornecedores");
                });

            modelBuilder.Entity("ProjetoEnngie.Business.Models.Usina", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<Guid?>("FornecedorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FornecedorId");

                    b.ToTable("Usinas");
                });

            modelBuilder.Entity("ProjetoEnngie.Business.Models.Usina", b =>
                {
                    b.HasOne("ProjetoEnngie.Business.Models.Fornecedor", "Fornecedor")
                        .WithMany("Fornecedores")
                        .HasForeignKey("FornecedorId");

                    b.Navigation("Fornecedor");
                });

            modelBuilder.Entity("ProjetoEnngie.Business.Models.Fornecedor", b =>
                {
                    b.Navigation("Fornecedores");
                });
#pragma warning restore 612, 618
        }
    }
}
