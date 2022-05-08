using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class DropConstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CatalogItem_CatalogBrandId",
                table: "CatalogItem");

            migrationBuilder.DropIndex(
                name: "IX_CatalogItem_CatalogTypeId",
                table: "CatalogItem");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogItem_CatalogBrandId",
                table: "CatalogItem",
                column: "CatalogBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogItem_CatalogTypeId",
                table: "CatalogItem",
                column: "CatalogTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CatalogItem_CatalogBrandId",
                table: "CatalogItem");

            migrationBuilder.DropIndex(
                name: "IX_CatalogItem_CatalogTypeId",
                table: "CatalogItem");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogItem_CatalogBrandId",
                table: "CatalogItem",
                column: "CatalogBrandId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CatalogItem_CatalogTypeId",
                table: "CatalogItem",
                column: "CatalogTypeId",
                unique: true);
        }
    }
}
