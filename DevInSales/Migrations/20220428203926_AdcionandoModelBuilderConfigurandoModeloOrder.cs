using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevInSales.Migrations
{
    public partial class AdcionandoModelBuilderConfigurandoModeloOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "User_Id",
                table: "Order",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "Shipping_Company_Price",
                table: "Order",
                newName: "shipping_company_price");

            migrationBuilder.RenameColumn(
                name: "Shipping_Company",
                table: "Order",
                newName: "shipping_Company");

            migrationBuilder.RenameColumn(
                name: "Seller_Id",
                table: "Order",
                newName: "seller_id");

            migrationBuilder.RenameColumn(
                name: "Date_Order",
                table: "Order",
                newName: "date_order");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Order",
                newName: "id");

            migrationBuilder.AlterColumn<string>(
                name: "shipping_Company",
                table: "Order",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "Order",
                newName: "User_Id");

            migrationBuilder.RenameColumn(
                name: "shipping_company_price",
                table: "Order",
                newName: "Shipping_Company_Price");

            migrationBuilder.RenameColumn(
                name: "shipping_Company",
                table: "Order",
                newName: "Shipping_Company");

            migrationBuilder.RenameColumn(
                name: "seller_id",
                table: "Order",
                newName: "Seller_Id");

            migrationBuilder.RenameColumn(
                name: "date_order",
                table: "Order",
                newName: "Date_Order");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Order",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Shipping_Company",
                table: "Order",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
