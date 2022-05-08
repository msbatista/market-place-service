using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CatalogBrand",
                columns: new[] { "CatalogBrandId", "Brand" },
                values: new object[,]
                {
                    { new Guid("3005f178-7201-46f9-8d8a-b10098190941"), "Samsung" },
                    { new Guid("36820a2a-d221-4f36-9978-d6316680dc08"), "HP" },
                    { new Guid("72f6b938-d8c1-4810-bd89-ce09a384b51c"), "LG" },
                    { new Guid("9335a45a-48ec-4c6e-accc-8810a5f34355"), "Acer" },
                    { new Guid("a6550e74-5abc-473d-9e4c-e344045e4906"), "EPSON" },
                    { new Guid("c3860e8a-0d9f-4d27-a3b1-374abbeb892c"), "Philips" },
                    { new Guid("d32ca6f8-6369-4347-952c-5c51d3925fd4"), "Dell" }
                });

            migrationBuilder.InsertData(
                table: "CatalogType",
                columns: new[] { "CatalogTypeId", "Type" },
                values: new object[,]
                {
                    { new Guid("02e67b19-81e9-497e-bdf3-6a482a0d9130"), "Monitores" },
                    { new Guid("09409bfc-6239-4387-bab0-dcfa7edbf117"), "Peças e Componentes" },
                    { new Guid("31481818-7842-4c3e-829c-62ce7e52bed7"), "Acessórios" },
                    { new Guid("54b39369-4af5-46f3-91b1-93936822a78b"), "Tablets" },
                    { new Guid("645b0d9c-3b0d-4296-a545-31580dd2ddb2"), "Notebooks" },
                    { new Guid("c0f7edc8-042c-4fac-a68b-18ce8df9cc79"), "Smart phones" },
                    { new Guid("cebbd28c-16b2-4835-bc8a-4209c5905a3e"), "Impressoras e Acessórios" },
                    { new Guid("fdbe0bbe-1319-4b78-8882-376a483d5a42"), "Memória e Armazenamento de Dados" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CatalogBrand",
                keyColumn: "CatalogBrandId",
                keyValue: new Guid("3005f178-7201-46f9-8d8a-b10098190941"));

            migrationBuilder.DeleteData(
                table: "CatalogBrand",
                keyColumn: "CatalogBrandId",
                keyValue: new Guid("36820a2a-d221-4f36-9978-d6316680dc08"));

            migrationBuilder.DeleteData(
                table: "CatalogBrand",
                keyColumn: "CatalogBrandId",
                keyValue: new Guid("72f6b938-d8c1-4810-bd89-ce09a384b51c"));

            migrationBuilder.DeleteData(
                table: "CatalogBrand",
                keyColumn: "CatalogBrandId",
                keyValue: new Guid("9335a45a-48ec-4c6e-accc-8810a5f34355"));

            migrationBuilder.DeleteData(
                table: "CatalogBrand",
                keyColumn: "CatalogBrandId",
                keyValue: new Guid("a6550e74-5abc-473d-9e4c-e344045e4906"));

            migrationBuilder.DeleteData(
                table: "CatalogBrand",
                keyColumn: "CatalogBrandId",
                keyValue: new Guid("c3860e8a-0d9f-4d27-a3b1-374abbeb892c"));

            migrationBuilder.DeleteData(
                table: "CatalogBrand",
                keyColumn: "CatalogBrandId",
                keyValue: new Guid("d32ca6f8-6369-4347-952c-5c51d3925fd4"));

            migrationBuilder.DeleteData(
                table: "CatalogType",
                keyColumn: "CatalogTypeId",
                keyValue: new Guid("02e67b19-81e9-497e-bdf3-6a482a0d9130"));

            migrationBuilder.DeleteData(
                table: "CatalogType",
                keyColumn: "CatalogTypeId",
                keyValue: new Guid("09409bfc-6239-4387-bab0-dcfa7edbf117"));

            migrationBuilder.DeleteData(
                table: "CatalogType",
                keyColumn: "CatalogTypeId",
                keyValue: new Guid("31481818-7842-4c3e-829c-62ce7e52bed7"));

            migrationBuilder.DeleteData(
                table: "CatalogType",
                keyColumn: "CatalogTypeId",
                keyValue: new Guid("54b39369-4af5-46f3-91b1-93936822a78b"));

            migrationBuilder.DeleteData(
                table: "CatalogType",
                keyColumn: "CatalogTypeId",
                keyValue: new Guid("645b0d9c-3b0d-4296-a545-31580dd2ddb2"));

            migrationBuilder.DeleteData(
                table: "CatalogType",
                keyColumn: "CatalogTypeId",
                keyValue: new Guid("c0f7edc8-042c-4fac-a68b-18ce8df9cc79"));

            migrationBuilder.DeleteData(
                table: "CatalogType",
                keyColumn: "CatalogTypeId",
                keyValue: new Guid("cebbd28c-16b2-4835-bc8a-4209c5905a3e"));

            migrationBuilder.DeleteData(
                table: "CatalogType",
                keyColumn: "CatalogTypeId",
                keyValue: new Guid("fdbe0bbe-1319-4b78-8882-376a483d5a42"));
        }
    }
}
