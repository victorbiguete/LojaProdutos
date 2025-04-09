﻿// <auto-generated />
using LojaProdutos.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LojaProdutos.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.3");

            modelBuilder.Entity("LojaProdutos.Models.CategoriaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categorias");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Tenis"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Botas"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Chinelos"
                        },
                        new
                        {
                            Id = 4,
                            Nome = "Sandalia"
                        },
                        new
                        {
                            Id = 5,
                            Nome = "Sapatos"
                        });
                });

            modelBuilder.Entity("LojaProdutos.Models.ProdutoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoriaModelId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("QuantidadeEstoque")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Valor")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaModelId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("LojaProdutos.Models.ProdutoModel", b =>
                {
                    b.HasOne("LojaProdutos.Models.CategoriaModel", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });
#pragma warning restore 612, 618
        }
    }
}
