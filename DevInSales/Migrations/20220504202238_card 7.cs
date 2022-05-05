using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevInSales.Migrations
{
    public partial class card7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShippingCompany_StatePrice_StatePriceId",
                table: "ShippingCompany");

            migrationBuilder.DropIndex(
                name: "IX_ShippingCompany_StatePriceId",
                table: "ShippingCompany");

            migrationBuilder.DropColumn(
                name: "StatePriceId",
                table: "ShippingCompany");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CityPrice",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "BasePrice",
                table: "CityPrice",
                newName: "base_preco");

            migrationBuilder.AlterColumn<decimal>(
                name: "base_preco",
                table: "CityPrice",
                type: "decimal",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateIndex(
                name: "IX_StatePrice_ShippingCompanyId",
                table: "StatePrice",
                column: "ShippingCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_StatePrice_ShippingCompany_ShippingCompanyId",
                table: "StatePrice",
                column: "ShippingCompanyId",
                principalTable: "ShippingCompany",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StatePrice_ShippingCompany_ShippingCompanyId",
                table: "StatePrice");

            migrationBuilder.DropIndex(
                name: "IX_StatePrice_ShippingCompanyId",
                table: "StatePrice");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "CityPrice",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "base_preco",
                table: "CityPrice",
                newName: "BasePrice");

            migrationBuilder.AddColumn<int>(
                name: "StatePriceId",
                table: "ShippingCompany",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "BasePrice",
                table: "CityPrice",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingCompany_StatePriceId",
                table: "ShippingCompany",
                column: "StatePriceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingCompany_StatePrice_StatePriceId",
                table: "ShippingCompany",
                column: "StatePriceId",
                principalTable: "StatePrice",
                principalColumn: "Id");
        }
    }
}
