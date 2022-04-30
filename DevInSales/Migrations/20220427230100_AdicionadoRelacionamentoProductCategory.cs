using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevInSales.Migrations
{
    public partial class AdicionadoRelacionamentoProductCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "category",
                table: "Product",
                newName: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_CategoryId",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Product",
                newName: "category");
        }
    }
}
