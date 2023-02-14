﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using crudSimples.Infrastruture;

#nullable disable

namespace crudSimples.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230214212839_umParaMuitos")]
    partial class umParaMuitos
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("crudSimples.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("crudSimples.Models.Compra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("crudSimples.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Enderecos", (string)null);
                });

            modelBuilder.Entity("crudSimples.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CompraId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Preco")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CompraId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("crudSimples.Models.Endereco", b =>
                {
                    b.HasOne("crudSimples.Models.Cliente", null)
                        .WithOne("Endereco")
                        .HasForeignKey("crudSimples.Models.Endereco", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("crudSimples.Models.Produto", b =>
                {
                    b.HasOne("crudSimples.Models.Compra", null)
                        .WithMany("Produtos")
                        .HasForeignKey("CompraId");
                });

            modelBuilder.Entity("crudSimples.Models.Cliente", b =>
                {
                    b.Navigation("Endereco")
                        .IsRequired();
                });

            modelBuilder.Entity("crudSimples.Models.Compra", b =>
                {
                    b.Navigation("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}