﻿// <auto-generated />
using System;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(CatalogContext))]
    [Migration("20220508203430_Seed")]
    partial class Seed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.CatalogBrands.CatalogBrand", b =>
                {
                    b.Property<Guid>("CatalogBrandId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("CatalogBrandId");

                    b.ToTable("CatalogBrand", (string)null);

                    b.HasData(
                        new
                        {
                            CatalogBrandId = new Guid("3005f178-7201-46f9-8d8a-b10098190941"),
                            Brand = "Samsung"
                        },
                        new
                        {
                            CatalogBrandId = new Guid("36820a2a-d221-4f36-9978-d6316680dc08"),
                            Brand = "HP"
                        },
                        new
                        {
                            CatalogBrandId = new Guid("a6550e74-5abc-473d-9e4c-e344045e4906"),
                            Brand = "EPSON"
                        },
                        new
                        {
                            CatalogBrandId = new Guid("9335a45a-48ec-4c6e-accc-8810a5f34355"),
                            Brand = "Acer"
                        },
                        new
                        {
                            CatalogBrandId = new Guid("d32ca6f8-6369-4347-952c-5c51d3925fd4"),
                            Brand = "Dell"
                        },
                        new
                        {
                            CatalogBrandId = new Guid("72f6b938-d8c1-4810-bd89-ce09a384b51c"),
                            Brand = "LG"
                        },
                        new
                        {
                            CatalogBrandId = new Guid("c3860e8a-0d9f-4d27-a3b1-374abbeb892c"),
                            Brand = "Philips"
                        });
                });

            modelBuilder.Entity("Domain.CatalogItems.CatalogItem", b =>
                {
                    b.Property<Guid>("CatalogItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AvailableStock")
                        .HasColumnType("int");

                    b.Property<Guid>("CatalogBrandId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CatalogTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(3072)
                        .HasColumnType("nvarchar(3072)");

                    b.Property<int>("MaxStockThreshold")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<bool>("OnReorder")
                        .HasColumnType("bit");

                    b.Property<string>("PictureName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("PictureUri")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<int>("RestockThreshold")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("CatalogItemId");

                    b.HasIndex("CatalogBrandId")
                        .IsUnique();

                    b.HasIndex("CatalogTypeId")
                        .IsUnique();

                    b.ToTable("CatalogItem", (string)null);
                });

            modelBuilder.Entity("Domain.CatalogTypes.CatalogType", b =>
                {
                    b.Property<Guid>("CatalogTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("CatalogTypeId");

                    b.ToTable("CatalogType", (string)null);

                    b.HasData(
                        new
                        {
                            CatalogTypeId = new Guid("31481818-7842-4c3e-829c-62ce7e52bed7"),
                            Type = "Acessórios"
                        },
                        new
                        {
                            CatalogTypeId = new Guid("09409bfc-6239-4387-bab0-dcfa7edbf117"),
                            Type = "Peças e Componentes"
                        },
                        new
                        {
                            CatalogTypeId = new Guid("645b0d9c-3b0d-4296-a545-31580dd2ddb2"),
                            Type = "Notebooks"
                        },
                        new
                        {
                            CatalogTypeId = new Guid("02e67b19-81e9-497e-bdf3-6a482a0d9130"),
                            Type = "Monitores"
                        },
                        new
                        {
                            CatalogTypeId = new Guid("cebbd28c-16b2-4835-bc8a-4209c5905a3e"),
                            Type = "Impressoras e Acessórios"
                        },
                        new
                        {
                            CatalogTypeId = new Guid("54b39369-4af5-46f3-91b1-93936822a78b"),
                            Type = "Tablets"
                        },
                        new
                        {
                            CatalogTypeId = new Guid("c0f7edc8-042c-4fac-a68b-18ce8df9cc79"),
                            Type = "Smart phones"
                        },
                        new
                        {
                            CatalogTypeId = new Guid("fdbe0bbe-1319-4b78-8882-376a483d5a42"),
                            Type = "Memória e Armazenamento de Dados"
                        });
                });

            modelBuilder.Entity("Domain.CatalogItems.CatalogItem", b =>
                {
                    b.HasOne("Domain.CatalogBrands.CatalogBrand", "CatalogBrand")
                        .WithOne()
                        .HasForeignKey("Domain.CatalogItems.CatalogItem", "CatalogBrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.CatalogTypes.CatalogType", "CatalogType")
                        .WithOne()
                        .HasForeignKey("Domain.CatalogItems.CatalogItem", "CatalogTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CatalogBrand");

                    b.Navigation("CatalogType");
                });
#pragma warning restore 612, 618
        }
    }
}
